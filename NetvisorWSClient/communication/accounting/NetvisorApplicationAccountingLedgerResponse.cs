using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections;
using System.Xml;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.accounting
{
    public class NetvisorApplicationAccountingLedgerResponse : NetvisorApplicationResponse
    {
        public enum VoucherRequestStatus : int
        {
            ALL = 1,
            VALID = 2,
            INVALIDATED_AND_DELETED = 3
        }

        private readonly Dictionary<string, NetvisorAccountingLedgerVoucher.VoucherResponseStatus> m_voucherStatuses = new Dictionary<string, NetvisorAccountingLedgerVoucher.VoucherResponseStatus>();

        public NetvisorApplicationAccountingLedgerResponse(string responseData) : base(responseData)
        {
            m_voucherStatuses.Add("valid", NetvisorAccountingLedgerVoucher.VoucherResponseStatus.VALID);
            m_voucherStatuses.Add("deleted", NetvisorAccountingLedgerVoucher.VoucherResponseStatus.DELETED);
            m_voucherStatuses.Add("invalidated", NetvisorAccountingLedgerVoucher.VoucherResponseStatus.INVALIDATED);
        }

        public ArrayList getAccountingLedgers()
        {
            ArrayList netvisorAccountingLedgers = new ArrayList();
            XmlDocument netvisorAccountingLedgerDocument = new XmlDocument();

            netvisorAccountingLedgerDocument.LoadXml(base.responseData);
            foreach (XmlNode voucherNode in netvisorAccountingLedgerDocument.SelectNodes("/Root/Vouchers/Voucher"))
            {
                NetvisorAccountingLedgerVoucher voucher = new NetvisorAccountingLedgerVoucher();

                NetvisorAccountingLedgerVoucher.VoucherResponseStatus? voucherStatus = default(NetvisorAccountingLedgerVoucher.VoucherResponseStatus?);
                if (m_voucherStatuses.ContainsKey(voucherNode.Attributes["Status"].Value))
                    voucherStatus = m_voucherStatuses[voucherNode.Attributes["Status"].Value];

                XmlNode voucherSourceNode = voucherNode.SelectSingleNode("LinkedSourceNetvisorKey");
                bool isLinkedSourceProvided = Strings.Len(voucherSourceNode.Attributes["type"].InnerText) > 0;

                // tositteen tiedot
                {
                    var withBlock = voucher;
                    if (isLinkedSourceProvided)
                    {
                        withBlock.LinkedSourceType = voucherSourceNode.Attributes["type"].InnerText;
                        withBlock.LinkedSourceNetvisorKey = System.Convert.ToInt32(voucherSourceNode.InnerText);
                    }

                    if (voucherStatus.HasValue)
                        withBlock.Status = voucherStatus;

                    withBlock.netvisorKey = voucherNode.SelectSingleNode("NetvisorKey").GetInt();
                    withBlock.VoucherDate = System.Convert.ToDateTime(voucherNode.SelectSingleNode("VoucherDate").InnerText);
                    withBlock.voucherNumber = System.Convert.ToInt32(voucherNode.SelectSingleNode("VoucherNumber").InnerText);

                    if (voucherNode.SelectSingleNode("Description") != null)
                        withBlock.Description = voucherNode.SelectSingleNode("Description").InnerText;

                    withBlock.VoucherClass = voucherNode.SelectSingleNode("VoucherClass").InnerText;
                    withBlock.voucherNetvisorURI = voucherNode.SelectSingleNode("VoucherNetvisorURI").InnerText;
                }

                // tositerivit
                foreach (XmlNode voucherLineNode in voucherNode.SelectNodes("VoucherLine"))
                {
                    NetvisorVoucherLine voucherline = new NetvisorVoucherLine();

                    {
                        var withBlock1 = voucherline;
                        withBlock1.lineSum = voucherLineNode.SelectSingleNode("LineSum").GetInt();

                        if (!Information.IsNothing(voucherLineNode.SelectSingleNode("Description")))
                            withBlock1.lineDescription = voucherLineNode.SelectSingleNode("Description").InnerText;

                        withBlock1.accountNumber = voucherLineNode.SelectSingleNode("AccountNumber").GetInt();
                        withBlock1.vatPercent = voucherLineNode.SelectSingleNode("VatPercent").GetInt();
                        withBlock1.vatCodeAbbreviation = voucherLineNode.SelectSingleNode("VatCode").InnerText;

                        // tositerivin laskentakohteet
                        foreach (XmlNode dimensionNode in voucherLineNode.SelectNodes("Dimension"))
                        {
                            string dimensionName = dimensionNode.SelectSingleNode("DimensionName").InnerText;
                            string dimensionItem = dimensionNode.SelectSingleNode("DimensionItem").InnerText;

                            voucherline.addVoucherLineDimension(new NetvisorDimension(dimensionName, dimensionItem));
                        }
                    }

                    voucher.addVoucherLine(voucherline);
                }

                netvisorAccountingLedgers.Add(voucher);
            }

            return netvisorAccountingLedgers;
        }
    }
}
