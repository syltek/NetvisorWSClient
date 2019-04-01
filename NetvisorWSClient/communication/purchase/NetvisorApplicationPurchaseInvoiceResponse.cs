using System;
using System.Xml;
using NetvisorWSClient.communication.common;

// 
// 
// 
// Revisio $Revision$
// 
// 
// 

namespace NetvisorWSClient.communication.purchase
{
    public class NetvisorApplicationPurchaseInvoiceResponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationPurchaseInvoiceResponse(string responseData) : base(responseData)
        {
        }

        public NetvisorPurchaseInvoice getPurchaseInvoice()
        {
            NetvisorPurchaseInvoice invoice = new NetvisorPurchaseInvoice();
            XmlDocument purchaseInvoiceDocument = new XmlDocument();

            purchaseInvoiceDocument.LoadXml(base.responseData);

            XmlNode purchaseInvoiceNode = purchaseInvoiceDocument.SelectSingleNode("/Root/PurchaseInvoice");

            {
                var withBlock = invoice;
                withBlock.InvoiceNumber = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceNumber").InnerText;
                withBlock.Amount = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceAmount").InnerText;
                withBlock.DueDate = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceDueDate").InnerText;
                withBlock.ourReference = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceOurReference").InnerText;
                withBlock.yourReference = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceYourReference").InnerText;
                withBlock.ValueDate = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceValueDate").InnerText;
                withBlock.comment = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceDescription").InnerText;
                withBlock.InvoiceDate = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceDate").InnerText;

                withBlock.VendorName = purchaseInvoiceNode.SelectSingleNode("VendorName").InnerText;
                withBlock.VendorAddressline = purchaseInvoiceNode.SelectSingleNode("VendorAddressline").InnerText;
                withBlock.VendorPostNumber = purchaseInvoiceNode.SelectSingleNode("VendorPostnumber").InnerText;
                withBlock.VendorCity = purchaseInvoiceNode.SelectSingleNode("VendorTown").InnerText;
                withBlock.vendorCountry = purchaseInvoiceNode.SelectSingleNode("VendorCountry").InnerText;
            }

            foreach (XmlNode node in purchaseInvoiceNode.SelectNodes("Attachments/Attachment"))
            {
                NetvisorAttachment attachment = new NetvisorAttachment();

                {
                    var withBlock1 = attachment;
                    withBlock1.attachmentData = Convert.FromBase64String(node.SelectSingleNode("AttachmentBase64Data").InnerText);
                    withBlock1.fileName = node.SelectSingleNode("FileName").InnerText;
                    withBlock1.description = node.SelectSingleNode("Comment").InnerText;
                    withBlock1.mimeType = node.SelectSingleNode("ContentType").InnerText;
                }

                invoice.addAttachment(attachment);
            }


            foreach (XmlNode node in purchaseInvoiceNode.SelectNodes("InvoiceLines/PurchaseInvoiceLine"))
            {
                NetvisorPurchaseInvoiceLine line = new NetvisorPurchaseInvoiceLine();

                {
                    var withBlock2 = line;
                    withBlock2.netvisorKey = node.SelectSingleNode("NetvisorKey").InnerText;
                    withBlock2.Description = node.SelectSingleNode("Description").InnerText;
                    withBlock2.LineSum = node.SelectSingleNode("LineSum").InnerText;
                    withBlock2.UnitName = node.SelectSingleNode("Unit").InnerText;

                    double vatPercent;
                    double orderedAmount;
                    double deliveredAmount;
                    double discountPercentage;

                    double.TryParse(node.SelectSingleNode("DeliveredAmount").InnerText, out DeliveredAmount);
                    double.TryParse(node.SelectSingleNode("VatPercent").InnerText, out vatPercent);
                    double.TryParse(node.SelectSingleNode("OrderedAmount").InnerText, out orderedAmount);
                    double.TryParse(node.SelectSingleNode("DiscountPercentage").InnerText, out discountPercentage);

                    withBlock2.VatPercent = vatPercent;
                    withBlock2.UnitPrice = node.SelectSingleNode("UnitPrice").InnerText;
                    withBlock2.OrderedAmount = orderedAmount;
                    withBlock2.DeliveredAmount = deliveredAmount;
                    withBlock2.ProductCode = node.SelectSingleNode("ProductCode").InnerText;
                    withBlock2.ProductName = node.SelectSingleNode("ProductName").InnerText;
                    withBlock2.DiscountPercentage = discountPercentage;

                    foreach (XmlNode dimensionNode in node.SelectNodes("PurchaseInvoiceLineDimensions/Dimension"))
                    {
                        NetvisorDimension dimension = new NetvisorDimension();

                        {
                            var withBlock3 = dimension;
                            withBlock3.dimensionName = dimensionNode.SelectSingleNode("DimensionName").InnerText;
                            withBlock3.dimensionDetail = dimensionNode.SelectSingleNode("DimensionDetailName").InnerText;
                        }

                        line.addDimension(dimension);
                    }
                }

                invoice.addInvoiceLine(line);
            }

            return invoice;
        }
    }
}


