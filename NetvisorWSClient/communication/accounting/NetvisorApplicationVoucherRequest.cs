using Microsoft.VisualBasic;
using System;
using System.Xml;
using System.Text;
using System.IO;
using NetvisorWSClient.util;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.accounting
{
    public class NetvisorApplicationVoucherRequest
    {
        public string getVoucherAsXML(NetvisorVoucher voucher)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("Voucher");

                string calculationMode;
                if (voucher.voucherCalculationModeIsGross)
                    calculationMode = "gross";
                else
                    calculationMode = "net";
                withBlock.WriteElementString("CalculationMode", calculationMode);

                withBlock.WriteStartElement("VoucherDate");
                withBlock.WriteAttributeString("format", "ansi");
                withBlock.WriteString(voucher.VoucherDate);
                withBlock.WriteEndElement();

                if (voucher.voucherNumber > 0)
                    withBlock.WriteElementString("Number", voucher.voucherNumber);

                withBlock.WriteElementString("Description", voucher.Description);
                withBlock.WriteElementString("VoucherClass", voucher.VoucherClass);

                if (voucher.voucherLines.Count > 0)
                {
                    foreach (NetvisorVoucherLine line in voucher.voucherLines)
                    {
                        withBlock.WriteStartElement("VoucherLine");

                        withBlock.WriteElementString("LineSum", line.lineSum);
                        withBlock.WriteElementString("Description", line.lineDescription);
                        withBlock.WriteElementString("AccountNumber", line.accountNumber);

                        string vatCodeAsString = null;
                        switch (line.vatCode)
                        {
                            case VatCode.vatCodes.DOMESTIC_PURCHASE:
                                {
                                    vatCodeAsString = VatCode.DOMESTIC_PURCHASE;
                                    break;
                                }

                            case VatCode.vatCodes.DOMESTIC_SALES:
                                {
                                    vatCodeAsString = VatCode.DOMESTIC_SALES;
                                    break;
                                }

                            case VatCode.vatCodes.EU_PURCHASE:
                                {
                                    vatCodeAsString = VatCode.EU_PURCHASE;
                                    break;
                                }

                            case VatCode.vatCodes.EU_SALES:
                                {
                                    vatCodeAsString = VatCode.EU_SALES;
                                    break;
                                }

                            case VatCode.vatCodes.EU_SERVICE_PURCHASE:
                                {
                                    vatCodeAsString = VatCode.EU_SERVICE_PURCHASE;
                                    break;
                                }

                            case VatCode.vatCodes.HUNDREDPERCENT_DEDUCTED_TAX:
                                {
                                    vatCodeAsString = VatCode.HUNDREDPERCENT_DEDUCTED_TAX;
                                    break;
                                }

                            case VatCode.vatCodes.NO_VAT_HANDLING:
                                {
                                    vatCodeAsString = VatCode.NO_VAT_HANDLING;
                                    break;
                                }

                            case VatCode.vatCodes.NON_EU_PURCHASE:
                                {
                                    vatCodeAsString = VatCode.NON_EU_PURCHASE;
                                    break;
                                }

                            case VatCode.vatCodes.NON_EU_SALES:
                                {
                                    vatCodeAsString = VatCode.NON_EU_SALES;
                                    break;
                                }

                            case util.VatCode.vatCodes.EU_SERVICE_SALES_312:
                                {
                                    vatCodeAsString = util.VatCode.EU_SERVICE_SALES_312;
                                    break;
                                }

                            case util.VatCode.vatCodes.EU_SERVICE_SALES_309:
                                {
                                    vatCodeAsString = util.VatCode.EU_SERVICE_SALES_309;
                                    break;
                                }

                            case util.VatCode.vatCodes.NO_TAX_SALES:
                                {
                                    vatCodeAsString = util.VatCode.NO_TAX_SALES;
                                    break;
                                }

                            case util.VatCode.vatCodes.NO_DEDUCTIBLE_EU_PURCHASE:
                                {
                                    vatCodeAsString = util.VatCode.NO_DEDUCTIBLE_EU_PURCHASE;
                                    break;
                                }

                            case util.VatCode.vatCodes.NO_DEDUCTIBLE_EU_SERVICEPURHASE:
                                {
                                    vatCodeAsString = util.VatCode.NO_DEDUCTIBLE_EU_SERVICEPURHASE;
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }

                        withBlock.WriteStartElement("VatPercent");

                        if (!string.IsNullOrEmpty(vatCodeAsString))
                            withBlock.WriteAttributeString("vatcode", vatCodeAsString);

                        withBlock.WriteString(line.vatPercent);
                        withBlock.WriteEndElement();

                        if (line.voucherLineDimensions.Count > 0)
                        {
                            foreach (NetvisorDimension dimension in line.voucherLineDimensions)
                            {
                                withBlock.WriteStartElement("Dimension");

                                withBlock.WriteElementString("DimensionName", dimension.dimensionName);
                                withBlock.WriteElementString("DimensionItem", dimension.dimensionDetail);

                                withBlock.WriteEndElement(); // /Dimension
                            }
                        }

                        withBlock.WriteEndElement(); // /VoucherLine
                    }
                }

                if (voucher.attachments.Count > 0)
                {
                    withBlock.WriteStartElement("VoucherAttachments");

                    foreach (NetvisorAttachment attachment in voucher.attachments)
                    {
                        withBlock.WriteStartElement("VoucherAttachment");

                        withBlock.WriteElementString("MimeType", attachment.mimeType);
                        withBlock.WriteElementString("AttachmentDescription", attachment.description);
                        withBlock.WriteElementString("FileName", attachment.fileName);
                        withBlock.WriteElementString("DocumentData", Convert.ToBase64String(attachment.attachmentData));

                        withBlock.WriteEndElement(); // /VoucherAttachment
                    }

                    withBlock.WriteEndElement(); // /VoucherAttachments
                }

                withBlock.WriteEndElement(); // /Voucher
                withBlock.WriteEndElement(); // /Root

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return streamReader.ReadToEnd();
        }
    }
}
