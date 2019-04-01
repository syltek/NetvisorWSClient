using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Xml;
using System.Text;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.purchase
{
    public class NetvisorApplicationPurchaseInvoiceRequest
    {
        public string getInvoiceAsXML(NetvisorPurchaseInvoice invoice)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("PurchaseInvoice");

                withBlock.WriteElementString("InvoiceNumber", invoice.InvoiceNumber);

                withBlock.WriteStartElement("InvoiceDate");
                withBlock.WriteAttributeString("format", "ansi");
                if (invoice.findNextOpenDateIfInLockedPeriod)
                    withBlock.WriteAttributeString("findopendate", "true");
                withBlock.WriteString(Strings.Format(invoice.InvoiceDate, "yyyy-MM-dd"));
                withBlock.WriteEndElement(); // /IvoiceDate

                string invoiceSource;
                switch (invoice.invoiceSource)
                {
                    case NetvisorPurchaseInvoice.invoiceSources.MANUAL:
                        {
                            invoiceSource = "manual";
                            break;
                        }

                    case NetvisorPurchaseInvoice.invoiceSources.FINVOICE:
                        {
                            invoiceSource = "finvoice";
                            break;
                        }

                    case NetvisorPurchaseInvoice.invoiceSources.CLARUS:
                        {
                            invoiceSource = "clarus";
                            break;
                        }

                    case NetvisorPurchaseInvoice.invoiceSources.ITELLA:
                        {
                            invoiceSource = "itella";
                            break;
                        }

                    case NetvisorPurchaseInvoice.invoiceSources.MAVENTA_SCAN:
                        {
                            invoiceSource = "maventascan";
                            break;
                        }

                    case NetvisorPurchaseInvoice.invoiceSources.MAVENTA_FINVOICE:
                        {
                            invoiceSource = "maventafinvoice";
                            break;
                        }

                    default:
                        {
                            throw new ApplicationException("Invalid invoiceSource: " + invoice.invoiceSource);
                            break;
                        }
                }

                withBlock.WriteElementString("InvoiceSource", invoiceSource);

                withBlock.WriteStartElement("ValueDate");
                withBlock.WriteAttributeString("format", "ansi");
                withBlock.WriteString(Strings.Format(invoice.ValueDate, "yyyy-MM-dd"));
                withBlock.WriteEndElement(); // /ValueDate

                withBlock.WriteStartElement("DueDate");
                withBlock.WriteAttributeString("format", "ansi");
                withBlock.WriteString(Strings.Format(invoice.DueDate, "yyyy-MM-dd"));
                withBlock.WriteEndElement(); // /DueDate

                withBlock.WriteStartElement("PurchaseInvoiceOnRound");
                withBlock.WriteAttributeString("type", "netvisor");
                switch (invoice.InvoiceRound)
                {
                    case NetvisorPurchaseInvoice.NetvisorPurchaseInvoiceRounds.UNHANDLED:
                        {
                            withBlock.WriteString("open");
                            break;
                        }

                    case NetvisorPurchaseInvoice.NetvisorPurchaseInvoiceRounds.CONTENTSUPERVISORED:
                        {
                            withBlock.WriteString("approved");
                            break;
                        }

                    case NetvisorPurchaseInvoice.NetvisorPurchaseInvoiceRounds.ACCEPTED:
                        {
                            withBlock.WriteString("accepted");
                            break;
                        }

                    default:
                        {
                            throw new ApplicationException("Invalid purchaseinvoiceround: " + invoice.InvoiceRound);
                            break;
                        }
                }
                withBlock.WriteEndElement(); // /PurchaseInvoiceOnRound

                withBlock.WriteElementString("VendorName", invoice.VendorName);
                withBlock.WriteElementString("VendorAddressLine", invoice.VendorAddressline);
                withBlock.WriteElementString("VendorPostNumber", invoice.VendorPostNumber);
                withBlock.WriteElementString("VendorCity", invoice.VendorCity);
                withBlock.WriteElementString("VendorCountry", invoice.vendorCountry);
                withBlock.WriteElementString("VendorPhoneNumber", invoice.vendorPhoneNumber);
                withBlock.WriteElementString("VendorFaxNumber", invoice.vendorFaxNumber);
                withBlock.WriteElementString("VendorEmail", invoice.vendorEmail);
                withBlock.WriteElementString("VendorHomepage", invoice.vendorHomepage);

                withBlock.WriteElementString("Amount", invoice.Amount);
                withBlock.WriteElementString("AccountNumber", invoice.AccountNumber);
                withBlock.WriteElementString("OrganizationIdentifier", invoice.organizationIdentifier);

                if (invoice.deliveryDate != DateTime.MinValue)
                {
                    withBlock.WriteStartElement("DeliveryDate");
                    withBlock.WriteAttributeString("format", "ansi");
                    withBlock.WriteString(Strings.Format(invoice.deliveryDate, "yyyy-MM-dd"));
                    withBlock.WriteEndElement();
                }

                withBlock.WriteElementString("OverdueFinePercent", invoice.overdueFinePercent);
                withBlock.WriteElementString("BankReferenceNumber", invoice.bankReferenceNumber);
                withBlock.WriteElementString("OurReference", invoice.ourReference);
                withBlock.WriteElementString("YourReference", invoice.yourReference);
                withBlock.WriteElementString("CurrencyCode", invoice.currencyCode);
                withBlock.WriteElementString("DeliveryTerms", invoice.deliveryTerms);
                withBlock.WriteElementString("DeliveryMethod", invoice.deliveryMethod);
                withBlock.WriteElementString("Comment", invoice.comment);

                withBlock.WriteElementString("CheckSum", invoice.checkSum);
                withBlock.WriteElementString("PdfExtraPages", invoice.pdfExtraPages);

                if (invoice.readyForAccounting)
                    withBlock.WriteElementString("ReadyForAccounting", 1);

                if (invoice.invoiceLines.Count > 0)
                {
                    withBlock.WriteStartElement("PurchaseInvoiceLines");

                    foreach (NetvisorPurchaseInvoiceLine line in invoice.invoiceLines)
                    {
                        withBlock.WriteStartElement("PurchaseInvoiceLine");

                        withBlock.WriteElementString("ProductCode", line.ProductCode);
                        withBlock.WriteElementString("ProductName", line.ProductName);
                        withBlock.WriteElementString("OrderedAmount", line.OrderedAmount);
                        withBlock.WriteElementString("DeliveredAmount", line.DeliveredAmount);
                        withBlock.WriteElementString("UnitName", line.UnitName);
                        withBlock.WriteElementString("UnitPrice", line.UnitPrice);
                        withBlock.WriteElementString("DiscountPercentage", line.DiscountPercentage);
                        withBlock.WriteElementString("VatPercent", line.VatPercent);

                        withBlock.WriteStartElement("LineSum");
                        withBlock.WriteAttributeString("type", "brutto");
                        withBlock.WriteString(line.LineSum);
                        withBlock.WriteEndElement(); // /LineSum

                        withBlock.WriteElementString("Description", line.Description);
                        withBlock.WriteElementString("Sort", line.sort);
                        withBlock.WriteElementString("AccountingSuggestion", line.accountNumberSuggestion);

                        if (line.Dimensions.Count > 0)
                        {
                            foreach (NetvisorDimension dimension in line.Dimensions)
                            {
                                withBlock.WriteStartElement("Dimension");

                                withBlock.WriteElementString("DimensionName", dimension.dimensionName);
                                withBlock.WriteElementString("DimensionItem", dimension.dimensionDetail);

                                withBlock.WriteEndElement(); // /Dimension
                            }
                        }


                        withBlock.WriteEndElement(); // /PurchaseInvoiceLine
                    }

                    withBlock.WriteEndElement(); // /PurchaseInvoiceLines
                }

                if (invoice.invoiceSubLines.Count > 0)
                {
                    withBlock.WriteStartElement("PurchaseInvoiceSubLines");

                    foreach (NetvisorPurchaseInvoiceSubLine subLine in invoice.invoiceSubLines)
                    {
                        withBlock.WriteStartElement("PurchaseInvoiceSubLine");

                        withBlock.WriteElementString("ProductCode", subLine.ProductCode);
                        withBlock.WriteElementString("ProductName", subLine.ProductName);
                        withBlock.WriteElementString("OrderedAmount", subLine.OrderedAmount);
                        withBlock.WriteElementString("DeliveredAmount", subLine.DeliveredAmount);
                        withBlock.WriteElementString("UnitName", subLine.UnitName);
                        withBlock.WriteElementString("UnitPrice", subLine.UnitPrice);
                        withBlock.WriteElementString("DiscountPercentage", subLine.DiscountPercentage);
                        withBlock.WriteElementString("VatPercent", subLine.VatPercent);

                        withBlock.WriteStartElement("LineSum");
                        withBlock.WriteAttributeString("type", "brutto");
                        withBlock.WriteString(subLine.LineSum);
                        withBlock.WriteEndElement(); // /LineSum

                        withBlock.WriteElementString("Description", subLine.Description);
                        withBlock.WriteElementString("Sort", subLine.sort);

                        withBlock.WriteEndElement(); // /PurchaseInvoiceSubLine
                    }

                    withBlock.WriteEndElement(); // /PurchaseInvoiceSubLines
                }

                if (invoice.invoiceCommentLines.Count > 0)
                {
                    withBlock.WriteStartElement("PurchaseInvoiceCommentLines");

                    foreach (NetvisorPurchaseInvoiceCommentLine line in invoice.invoiceCommentLines)
                    {
                        withBlock.WriteStartElement("PurchaseInvoiceCommentLine");
                        withBlock.WriteElementString("Comment", line.comment);
                        withBlock.WriteElementString("Sort", line.sort);
                        withBlock.WriteEndElement(); // /PurchaseInvoiceCommentLine
                    }

                    withBlock.WriteEndElement(); // /PurchaseInvoiceCommentLines
                }

                if (invoice.attachments.Count > 0)
                {
                    withBlock.WriteStartElement("PurchaseInvoiceAttachments");

                    foreach (NetvisorAttachment attachment in invoice.attachments)
                    {
                        withBlock.WriteStartElement("PurchaseInvoiceAttachment");

                        withBlock.WriteElementString("MimeType", attachment.mimeType);
                        withBlock.WriteElementString("AttachmentDescription", attachment.description);
                        withBlock.WriteElementString("Filename", attachment.fileName);
                        withBlock.WriteStartElement("DocumentData");
                        if (attachment.purchaseInvoiceAttachmentCategory > 0)
                        {
                            switch (attachment.purchaseInvoiceAttachmentCategory)
                            {
                                case NetvisorAttachment.AttachmentCategory.invoiceImage:
                                    {
                                        withBlock.WriteAttributeString("documenttype", "invoiceimage");
                                        break;
                                    }

                                case NetvisorAttachment.AttachmentCategory.otherAttachment:
                                    {
                                        withBlock.WriteAttributeString("documenttype", "otherattachment");
                                        break;
                                    }

                                default:
                                    {
                                        throw new ApplicationException("Invalid purchaseInvoiceAttachmentCategory: " + attachment.purchaseInvoiceAttachmentCategory);
                                        break;
                                    }
                            }
                        }

                        withBlock.WriteString(Convert.ToBase64String(attachment.attachmentData));
                        withBlock.WriteEndElement(); // /DocumentData

                        withBlock.WriteEndElement(); // /PurchaseInvoiceAttachment
                    }

                    withBlock.WriteEndElement(); // /PurchaseInvoiceAttachments
                }

                withBlock.WriteEndElement(); // /PurchaseInvoice
                withBlock.WriteEndElement(); // /Root

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return streamReader.ReadToEnd();
        }
    }
}
