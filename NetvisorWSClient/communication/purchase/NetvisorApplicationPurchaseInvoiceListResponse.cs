using System.Collections;
using System.Xml;

namespace NetvisorWSClient.communication.purchase
{
    public class NetvisorApplicationPurchaseInvoiceListResponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationPurchaseInvoiceListResponse(string responseData) : base(responseData)
        {
        }

        public ArrayList getPurchaseInvoiceList()
        {
            ArrayList purchaseInvoiceList = new ArrayList();
            XmlDocument purchaseInvoiceListDocument = new XmlDocument();

            purchaseInvoiceListDocument.LoadXml(base.responseData);

            foreach (XmlNode invoiceNode in purchaseInvoiceListDocument.SelectNodes("/Root/PurchaseInvoiceList/PurchaseInvoice"))
            {
                NetvisorPurchaseInvoiceListInvoice invoiceListInvoice = new NetvisorPurchaseInvoiceListInvoice();

                {
                    var withBlock = invoiceListInvoice;
                    withBlock.NetvisorKey = invoiceNode.SelectSingleNode("NetvisorKey").InnerText;
                    withBlock.invoiceNumber = invoiceNode.SelectSingleNode("InvoiceNumber").InnerText;

                    if (!string.IsNullOrEmpty(invoiceNode.SelectSingleNode("InvoiceDate").InnerText))
                        withBlock.invoiceDate = System.Convert.ToDateTime(invoiceNode.SelectSingleNode("InvoiceDate").InnerText);

                    withBlock.vendor = invoiceNode.SelectSingleNode("Vendor").InnerText;
                    withBlock.sum = System.Convert.ToDecimal(invoiceNode.SelectSingleNode("Sum").InnerText);
                    withBlock.payments = System.Convert.ToDecimal(invoiceNode.SelectSingleNode("Payments").InnerText);
                    withBlock.openSum = System.Convert.ToDecimal(invoiceNode.SelectSingleNode("OpenSum").InnerText);
                    withBlock.Uri = System.Convert.ToString(invoiceNode.SelectSingleNode("Uri").InnerText);
                }

                purchaseInvoiceList.Add(invoiceListInvoice);
            }

            return purchaseInvoiceList;
        }
    }
}

