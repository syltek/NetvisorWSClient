using Microsoft.VisualBasic;
using System.Xml;
using System.IO;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.purchase
{
    public class NetvisorApplicationPurchaseOrderRequest
    {
        public string getOrderAsXML(NetvisorPurchaseOrder sourceOrder)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, System.Text.Encoding.UTF8);

            {
                var withBlock = writer;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("PurchaseOrder");

                withBlock.WriteElementString("OrderNumber", sourceOrder.orderNumber);
                withBlock.WriteElementString("OrderStatus", sourceOrder.orderStatus);

                withBlock.WriteStartElement("OrderDate");
                withBlock.WriteAttributeString("format", "ansi");
                withBlock.WriteString(Strings.Format(sourceOrder.orderDate, "yyyy-MM-dd"));
                withBlock.WriteEndElement();

                withBlock.WriteStartElement("VendorIdentifier");
                withBlock.WriteAttributeString("type", sourceOrder.vendorIdentifier_type);
                withBlock.WriteString(sourceOrder.vendorIdentifier);
                withBlock.WriteEndElement();

                withBlock.WriteElementString("VendorAddressline", sourceOrder.vendorAddressline);
                withBlock.WriteElementString("VendorPostNumber", sourceOrder.vendorPostnumber);
                withBlock.WriteElementString("VendorCity", sourceOrder.vendorCity);

                withBlock.WriteStartElement("VendorCountry");
                withBlock.WriteAttributeString("type", "ISO-3166");
                withBlock.WriteString(sourceOrder.vendorCountry);
                withBlock.WriteEndElement();

                withBlock.WriteElementString("DeliveryTerm", sourceOrder.deliveryTerm);
                withBlock.WriteElementString("DeliveryMethod", sourceOrder.deliveryMethod);
                withBlock.WriteElementString("DeliveryAddressline", sourceOrder.deliveryAddressLine);
                withBlock.WriteElementString("DeliveryPostNumber", sourceOrder.deliveryPostNumber);
                withBlock.WriteElementString("DeliveryCity", sourceOrder.deliveryCity);

                withBlock.WriteStartElement("DeliveryCountry");
                withBlock.WriteAttributeString("type", "ISO-3166");
                withBlock.WriteString(sourceOrder.deliveryCountry);
                withBlock.WriteEndElement();

                withBlock.WriteElementString("PrivateComment", sourceOrder.privateComment);
                withBlock.WriteElementString("Comment", sourceOrder.comment);
                withBlock.WriteElementString("OurReference", sourceOrder.ourReference);

                withBlock.WriteElementString("PaymentTermNetDays", sourceOrder.paymentTermNetDays.ToString());
                withBlock.WriteElementString("PaymentTermCashDiscountDays", sourceOrder.paymentTermCashDiscountDays.ToString());
                withBlock.WriteElementString("PaymentTermDiscountPercent", sourceOrder.paymentTermDiscountPercent.ToString());

                withBlock.WriteStartElement("Amount");

                if (!string.IsNullOrEmpty(sourceOrder.currency))
                    withBlock.WriteAttributeString("iso4217currencycode", sourceOrder.currency);

                if (sourceOrder.currency_ExchangeRate > 0)
                    withBlock.WriteAttributeString("exchangerate", sourceOrder.currency_ExchangeRate.ToString());

                withBlock.WriteString(sourceOrder.amount.ToString());
                withBlock.WriteEndElement(); // amount

                withBlock.WriteStartElement("PurchaseOrderLines");

                foreach (NetvisorPurchaseOrderLine line in sourceOrder.ProductLines)
                {
                    withBlock.WriteStartElement("PurchaseOrderProductLine");

                    withBlock.WriteStartElement("ProductCode");
                    withBlock.WriteAttributeString("type", line.productCode_type);
                    withBlock.WriteString(line.productCode);
                    withBlock.WriteEndElement();

                    withBlock.WriteElementString("ProductName", line.productName);
                    withBlock.WriteElementString("VendorProductCode", line.vendorProductCode);
                    withBlock.WriteElementString("OrderedAmount", line.orderedAmount.ToString());
                    withBlock.WriteElementString("UnitPrice", line.unitPrice.ToString());
                    withBlock.WriteElementString("VatPercent", line.vatPercent.ToString());

                    withBlock.WriteStartElement("DeliveryDate");
                    withBlock.WriteAttributeString("format", "ansi");
                    withBlock.WriteString(Strings.Format(line.DeliveryDate, "yyyy-MM-dd"));
                    withBlock.WriteEndElement();


                    if (!string.IsNullOrEmpty(line.inventoryPlace))
                    {
                        withBlock.WriteStartElement("InventoryPlace");
                        withBlock.WriteAttributeString("type", line.inventoryPlace_type);
                        withBlock.WriteString(line.inventoryPlace);
                        withBlock.WriteEndElement();
                    }


                    withBlock.WriteElementString("AccountingSuggestion", line.accountingSuggestion);

                    foreach (NetvisorDimension dimension in line.dimensions)
                    {
                        withBlock.WriteStartElement("Dimension");

                        withBlock.WriteElementString("DimensionName", dimension.dimensionName);
                        withBlock.WriteElementString("DimensionItem", dimension.dimensionDetail);

                        withBlock.WriteEndElement(); // Dimension
                    }

                    withBlock.WriteEndElement(); // PurchaseOrderProductLine
                }

                foreach (NetvisorPurchaseOrderCommentLine commentLine in sourceOrder.CommentLines)
                {
                    withBlock.WriteStartElement("PurchaseOrderComment");

                    withBlock.WriteElementString("Comment", commentLine.comment);

                    withBlock.WriteEndElement(); // PurchaseOrderComment
                }

                withBlock.WriteEndElement(); // PurchaseOrderLines
                withBlock.WriteEndElement(); // PurchaseOrder
                withBlock.WriteEndElement(); // Root
                withBlock.Flush();
            }

            XmlDocument doc = new XmlDocument();

            stream.Seek(0, SeekOrigin.Begin);
            StreamReader reader = new StreamReader(stream);
            doc.LoadXml(reader.ReadToEnd());
            return reader.ReadToEnd();
        }
    }
}

