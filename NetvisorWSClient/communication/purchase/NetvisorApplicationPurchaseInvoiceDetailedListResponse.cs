using System.Collections;
using System.Xml;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.purchase
{
    public class NetvisorApplicationPurchaseInvoiceDetailedListResponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationPurchaseInvoiceDetailedListResponse(string responseData) : base(responseData)
        {
        }

        public ArrayList getPurchaseInvoiceList()
        {
            ArrayList purchaseInvoiceList = new ArrayList();
            XmlDocument purchaseInvoiceListDocument = new XmlDocument();

            purchaseInvoiceListDocument.LoadXml(base.responseData);

            foreach (XmlNode purchaseInvoiceNode in purchaseInvoiceListDocument.SelectNodes("/Root/PurchaseInvoiceList/PurchaseInvoice"))
            {
                NetvisorPurchaseInvoice invoice = new NetvisorPurchaseInvoice();

                {
                    var withBlock = invoice;
                    withBlock.NetvisorKey = purchaseInvoiceNode.SelectSingleNode("netvisorKey").InnerText;
                    withBlock.InvoiceNumber = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceNumber").InnerText;
                    withBlock.Amount = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceAmount").InnerText;
                    withBlock.DueDate = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceDueDate").InnerText;
                    withBlock.InvoiceDate = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceDate").InnerText;

                    withBlock.VendorName = purchaseInvoiceNode.SelectSingleNode("VendorName").InnerText;
                }

                foreach (XmlNode node in purchaseInvoiceNode.SelectNodes("InvoiceLines/PurchaseInvoiceLine"))
                {
                    NetvisorPurchaseInvoiceLine line = new NetvisorPurchaseInvoiceLine();

                    {
                        var withBlock1 = line;
                        withBlock1.netvisorKey = node.SelectSingleNode("NetvisorKey").InnerText;
                        withBlock1.Description = node.SelectSingleNode("Description").InnerText;
                        withBlock1.UnitName = node.SelectSingleNode("Unit").InnerText;

                        double vatPercent;
                        double orderedAmount;
                        double deliveredAmount;
                        double discountPercentage;
                        double lineSum;

                        double.TryParse(node.SelectSingleNode("DeliveredAmount").InnerText, out deliveredAmount);
                        double.TryParse(node.SelectSingleNode("VatPercent").InnerText, out vatPercent);
                        double.TryParse(node.SelectSingleNode("OrderedAmount").InnerText, out orderedAmount);
                        double.TryParse(node.SelectSingleNode("DiscountPercentage").InnerText, out discountPercentage);
                        double.TryParse(node.SelectSingleNode("LineSum").InnerText, out lineSum);

                        withBlock1.LineSum = lineSum;
                        withBlock1.VatPercent = vatPercent;
                        withBlock1.VatCode = node.SelectSingleNode("VatCode").InnerText;
                        withBlock1.UnitPrice = node.SelectSingleNode("UnitPrice").InnerText;
                        withBlock1.OrderedAmount = orderedAmount;
                        withBlock1.DeliveredAmount = deliveredAmount;
                        withBlock1.ProductCode = node.SelectSingleNode("ProductCode").InnerText;
                        withBlock1.ProductName = node.SelectSingleNode("ProductName").InnerText;
                        withBlock1.DiscountPercentage = discountPercentage;

                        foreach (XmlNode dimensionNode in node.SelectNodes("PurchaseInvoiceLineDimensions/Dimension"))
                        {
                            NetvisorDimension dimension = new NetvisorDimension();

                            {
                                var withBlock2 = dimension;
                                withBlock2.dimensionName = dimensionNode.SelectSingleNode("DimensionName").InnerText;
                                withBlock2.dimensionDetail = dimensionNode.SelectSingleNode("DimensionDetailName").InnerText;
                            }

                            line.addDimension(dimension);
                        }
                    }

                    invoice.addInvoiceLine(line);
                }

                purchaseInvoiceList.Add(invoice);
            }

            return purchaseInvoiceList;
        }
    }
}

