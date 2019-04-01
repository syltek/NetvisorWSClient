using System.Collections.Generic;
using System.Xml;

namespace NetvisorWSClient.communication.purchase
{
    public class NetvisorApplicationPaymentListResponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationPaymentListResponse(string responseData) : base(responseData)
        {
        }

        public List<NetvisorPaymentListPayment> getPaymentList()
        {
            List<NetvisorPaymentListPayment> paymentList = new List<NetvisorPaymentListPayment>();
            XmlDocument paymentListDocument = new XmlDocument();

            paymentListDocument.LoadXml(base.responseData);

            foreach (XmlNode paymentNode in paymentListDocument.SelectNodes("/Root/PaymentList/Payment"))
            {
                NetvisorPaymentListPayment paymentListPayment = new NetvisorPaymentListPayment();

                {
                    var withBlock = paymentListPayment;
                    withBlock.NetvisorKey = paymentNode.SelectSingleNode("NetvisorKey").InnerText;
                    withBlock.PayerName = paymentNode.SelectSingleNode("PayerName").InnerText;
                    withBlock.Date = paymentNode.SelectSingleNode("Date").InnerText;
                    withBlock.HomeCurrencySum = paymentNode.SelectSingleNode("HomeCurrencySum").InnerText;

                    if (!string.IsNullOrEmpty(paymentNode.SelectSingleNode("ForeignCurrencySum").InnerText))
                        withBlock.ForeignCurrencySum = paymentNode.SelectSingleNode("ForeignCurrencySum").InnerText;

                    withBlock.Reference = paymentNode.SelectSingleNode("Reference").InnerText;
                    withBlock.InvoiceKey = paymentNode.SelectSingleNode("InvoiceKey").InnerText;
                    withBlock.InvoiceNumber = paymentNode.SelectSingleNode("InvoiceNumber").InnerText;

                    if (!string.IsNullOrEmpty(paymentNode.SelectSingleNode("InvoiceUri").InnerText))
                        withBlock.invoiceURI = paymentNode.SelectSingleNode("InvoiceUri").InnerText;

                    if (!string.IsNullOrEmpty(paymentNode.SelectSingleNode("VoucherKey").InnerText))
                        withBlock.VoucherKey = paymentNode.SelectSingleNode("VoucherKey").InnerText;

                    if (!string.IsNullOrEmpty(paymentNode.SelectSingleNode("VoucherNumber").InnerText))
                        withBlock.VoucherNumber = paymentNode.SelectSingleNode("VoucherNumber").InnerText;
                }

                paymentList.Add(paymentListPayment);
            }

            return paymentList;
        }
    }
}
