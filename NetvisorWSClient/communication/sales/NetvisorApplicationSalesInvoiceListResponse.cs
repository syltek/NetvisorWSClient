using System.Collections;
using System.Xml;

namespace NetvisorWSClient.communication.sales
{
    public class NetvisorApplicationSalesInvoiceListResponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationSalesInvoiceListResponse(string responseData) : base(responseData)
        {
        }

        public ArrayList getSalesInvoiceList()
        {
            ArrayList salesInvoiceList = new ArrayList();
            XmlDocument invoiceListDocument = new XmlDocument();

            invoiceListDocument.LoadXml(base.responseData);

            foreach (XmlNode invoiceNode in invoiceListDocument.SelectNodes("/Root/SalesInvoiceList/SalesInvoice"))
            {
                NetvisorSalesInvoiceListInvoice invoiceListInvoice = new NetvisorSalesInvoiceListInvoice();

                {
                    var withBlock = invoiceListInvoice;
                    withBlock.netvisorKey = System.Convert.ToInt32(invoiceNode.SelectSingleNode("NetvisorKey").InnerText);
                    withBlock.invoiceNumber = invoiceNode.SelectSingleNode("InvoiceNumber").InnerText;
                    withBlock.invoiceDate = System.Convert.ToDateTime(invoiceNode.SelectSingleNode("Invoicedate").InnerText);
                    withBlock.invoiceStatus = invoiceNode.SelectSingleNode("InvoiceStatus").InnerText;

                    XmlNode invoiceStatusNode = invoiceNode.SelectSingleNode("InvoiceStatus");
                    if (invoiceStatusNode.Attributes.Count > 0)
                    {
                        if (invoiceStatusNode.Attributes.ItemOf["substatus"] != null)
                            withBlock.invoiceSubStatus = invoiceStatusNode.Attributes["substatus"].InnerText;

                        if (invoiceStatusNode.Attributes.ItemOf["isincollection"] != null)
                            withBlock.isInCollection = invoiceStatusNode.Attributes["isincollection"].InnerText;
                    }

                    withBlock.CustomerCode = invoiceNode.SelectSingleNode("CustomerCode").InnerText;
                    withBlock.customerName = invoiceNode.SelectSingleNode("CustomerName").InnerText;
                    withBlock.referenceNumber = invoiceNode.SelectSingleNode("InvoiceNumber").InnerText;
                    withBlock.invoiceSum = System.Convert.ToDecimal(invoiceNode.SelectSingleNode("InvoiceSum").InnerText);
                    withBlock.openSum = System.Convert.ToDecimal(invoiceNode.SelectSingleNode("OpenSum").InnerText);
                    withBlock.uri = invoiceNode.SelectSingleNode("Uri").InnerText;
                }

                salesInvoiceList.Add(invoiceListInvoice);
            }

            return salesInvoiceList;
        }
    }
}
