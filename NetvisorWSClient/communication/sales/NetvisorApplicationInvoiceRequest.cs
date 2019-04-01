using Microsoft.VisualBasic;
using System;
using System.Xml;
using System.Text;
using System.IO;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.sales
{
    public class NetvisorApplicationInvoiceRequest
    {
        public string getInvoiceAsXML(NetvisorInvoice invoice)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("SalesInvoice");

                if (Strings.Len(invoice.InvoiceNumber) > 0 && System.Convert.ToInt64(invoice.InvoiceNumber) > 0)
                {
                    withBlock.WriteStartElement("SalesInvoiceNumber");
                    withBlock.WriteString(invoice.InvoiceNumber);
                    withBlock.WriteEndElement();
                }

                withBlock.WriteStartElement("SalesInvoiceDate");
                withBlock.WriteAttributeString("format", "ansi");
                withBlock.WriteString(invoice.InvoiceDate.Year + "-" + invoice.InvoiceDate.Month + "-" + invoice.InvoiceDate.Day);
                withBlock.WriteEndElement();

                withBlock.WriteStartElement("SalesInvoiceDeliveryDate");
                withBlock.WriteAttributeString("format", "ansi");
                withBlock.WriteString(invoice.DeliveryDate.Year + "-" + invoice.DeliveryDate.Month + "-" + invoice.DeliveryDate.Day);
                withBlock.WriteEndElement();

                if (!Information.IsNothing(invoice.ReferenceNumber))
                {
                    withBlock.WriteStartElement("SalesInvoiceReferenceNumber");
                    withBlock.WriteString(invoice.ReferenceNumber.getMachineReadableFormat());
                    withBlock.WriteEndElement();
                }

                decimal totalAmount;
                bool calculateTotalSumFromInvoiceLines = !invoice.InvoiceSum.HasValue;

                if (calculateTotalSumFromInvoiceLines)
                    totalAmount = invoice.getInvoiceTotalAmountCalculatedFromProductLines();
                else
                    totalAmount = Math.Round(invoice.InvoiceSum.Value, 2, MidpointRounding.AwayFromZero);

                withBlock.WriteStartElement("SalesInvoiceAmount");

                if (Strings.Len(invoice.iso4217currencycode) > 0)
                {
                    withBlock.WriteAttributeString("iso4217currencycode", invoice.iso4217currencycode);

                    if (invoice.overrideCurrencyRate > 0)
                        withBlock.WriteAttributeString("currencyrate", invoice.overrideCurrencyRate);
                }

                withBlock.WriteString(totalAmount.ToString());
                withBlock.WriteEndElement();

                if (invoice.sellerIdentifier > 0)
                {
                    withBlock.WriteStartElement("SellerIdentifier");
                    withBlock.WriteAttributeString("type", "netvisor");
                    withBlock.WriteString(invoice.sellerIdentifier);
                    withBlock.WriteEndElement();
                }

                if (!string.IsNullOrEmpty(invoice.sellerName))
                {
                    withBlock.WriteStartElement("SellerName");
                    withBlock.WriteString(invoice.sellerName);
                    withBlock.WriteEndElement();
                }

                string invoiceType;
                switch (invoice.invoiceType)
                {
                    case NetvisorInvoice.NetvisorInvoiceTypes.invoice:
                        {
                            invoiceType = "invoice";
                            break;
                        }

                    case NetvisorInvoice.NetvisorInvoiceTypes.order:
                        {
                            invoiceType = "order";
                            break;
                        }

                    default:
                        {
                            // jos tilaa ei annettu, niin oletetaan että lasku
                            invoiceType = "invoice";
                            invoice.invoiceType = NetvisorInvoice.NetvisorInvoiceTypes.invoice;
                            break;
                        }
                }

                withBlock.WriteElementString("InvoiceType", invoiceType);

                withBlock.WriteStartElement("SalesInvoiceStatus");
                withBlock.WriteAttributeString("type", "netvisor");

                if (invoice.invoiceType == NetvisorInvoice.NetvisorInvoiceTypes.invoice)
                {
                    if (invoice.InvoiceStatus != 0)
                    {
                        switch (invoice.InvoiceStatus)
                        {
                            case NetvisorInvoice.NetvisorInvoiceStatuses.Open:
                                {
                                    withBlock.WriteString("open");
                                    break;
                                }

                            case NetvisorInvoice.NetvisorInvoiceStatuses.UnSent:
                                {
                                    withBlock.WriteString("unsent");
                                    break;
                                }

                            default:
                                {
                                    throw new ApplicationException("Invalid salesinvoicestatus: " + invoice.InvoiceStatus);
                                    break;
                                }
                        }
                    }
                    else
                        withBlock.WriteString("open");
                }
                else if (invoice.invoiceType == NetvisorInvoice.NetvisorInvoiceTypes.order)
                {
                    switch (invoice.InvoiceStatus)
                    {
                        case NetvisorInvoice.NetvisorOrderStatuses.Delivered:
                            {
                                withBlock.WriteString("delivered");
                                break;
                            }

                        case NetvisorInvoice.NetvisorOrderStatuses.unDelivered:
                            {
                                withBlock.WriteString("undelivered");
                                break;
                            }

                        default:
                            {
                                throw new ApplicationException("Invalid preinvoice status: " + invoice.InvoiceStatus);
                                break;
                            }
                    }
                }

                withBlock.WriteEndElement();

                withBlock.WriteElementString("SalesInvoiceFreeTextBeforeLines", invoice.SalesInvoiceFreeTextBeforeLines);
                withBlock.WriteElementString("SalesInvoiceFreeTextAfterLines", invoice.SalesInvoiceFreeTextAfterLines);

                withBlock.WriteElementString("SalesInvoiceOurReference", invoice.ourReference);
                withBlock.WriteElementString("SalesInvoiceYourReference", invoice.yourReference);

                if (!string.IsNullOrEmpty(invoice.privateComment))
                    withBlock.WriteElementString("SalesInvoicePrivateComment", invoice.privateComment);

                withBlock.WriteStartElement("InvoicingCustomerIdentifier");

                switch (invoice.CustomerIdentifierType)
                {
                    case NetvisorInvoice.CustomerIdentifierSource.EXTERNAL_IDENTIFIER:
                        {
                            withBlock.WriteAttributeString("type", "customer");
                            break;
                        }

                    case NetvisorInvoice.CustomerIdentifierSource.NETVISOR_IDENTIFIER:
                        {
                            withBlock.WriteAttributeString("type", "netvisor");
                            break;
                        }

                    default:
                        {
                            throw new ApplicationException("Unkown customer identifier type: " + invoice.CustomerIdentifierType);
                            break;
                        }
                }

                withBlock.WriteString(invoice.CustomerIdentifier);
                withBlock.WriteEndElement();

                withBlock.WriteStartElement("InvoicingCustomerName");
                withBlock.WriteString(invoice.CustomerName);
                withBlock.WriteEndElement();

                withBlock.WriteStartElement("InvoicingCustomerNameExtension");
                withBlock.WriteString(invoice.CustomerNameExtension);
                withBlock.WriteEndElement();

                withBlock.WriteStartElement("InvoicingCustomerAddressLine");
                withBlock.WriteString(invoice.CustomerAddress);
                withBlock.WriteEndElement();

                withBlock.WriteStartElement("InvoicingCustomerPostNumber");
                withBlock.WriteString(invoice.CustomerPostNumber);
                withBlock.WriteEndElement();

                withBlock.WriteStartElement("InvoicingCustomerTown");
                withBlock.WriteString(invoice.CustomerTown);
                withBlock.WriteEndElement();

                withBlock.WriteStartElement("InvoicingCustomerCountryCode");
                withBlock.WriteAttributeString("type", "ISO-3166");
                withBlock.WriteString(invoice.CustomerCountryISO3166Code);
                withBlock.WriteEndElement();

                if (!Information.IsNothing(invoice.DeliveryAddress) && invoice.DeliveryAddress.Length() > 0)
                {
                    withBlock.WriteStartElement("deliveryaddressname");
                    withBlock.WriteString(invoice.DeliveryName);
                    withBlock.WriteEndElement();

                    withBlock.WriteStartElement("deliveryaddressline");
                    withBlock.WriteString(invoice.DeliveryAddress);
                    withBlock.WriteEndElement();

                    withBlock.WriteStartElement("deliveryaddresspostnumber");
                    withBlock.WriteString(invoice.DeliveryPostNumber);
                    withBlock.WriteEndElement();

                    withBlock.WriteStartElement("deliveryaddresstown");
                    withBlock.WriteString(invoice.DeliveryTown);
                    withBlock.WriteEndElement();

                    withBlock.WriteStartElement("deliveryaddresscountrycode");
                    withBlock.WriteAttributeString("type", "ISO-3166");
                    withBlock.WriteString(invoice.DeliveryCountryISO3166Code);
                    withBlock.WriteEndElement();
                }

                if (!string.IsNullOrEmpty(invoice.DeliveryMethod))
                {
                    withBlock.WriteStartElement("DeliveryMethod");
                    withBlock.WriteString(invoice.DeliveryMethod);
                    withBlock.WriteEndElement();
                }

                if (!string.IsNullOrEmpty(invoice.DeliveryTerm))
                {
                    withBlock.WriteStartElement("DeliveryTerm");
                    withBlock.WriteString(invoice.DeliveryTerm);
                    withBlock.WriteEndElement();
                }

                if (invoice.taxHandlingType > 0)
                {
                    switch (invoice.taxHandlingType)
                    {
                        case NetvisorInvoice.NetvisorInvoiceTaxHandlingTypes.countryGroup:
                            {
                                withBlock.WriteElementString("SalesInvoiceTaxHandlingType", NetvisorInvoice.TAX_HANDLING_TYPE_COUNTRY_GROUP);
                                break;
                            }

                        case NetvisorInvoice.NetvisorInvoiceTaxHandlingTypes.domesticConstructionService:
                            {
                                withBlock.WriteElementString("SalesInvoiceTaxHandlingType", NetvisorInvoice.TAX_HANDLING_TYPE_DOMESTIC_CONSTRUCTION_SERVICES);
                                break;
                            }

                        case NetvisorInvoice.NetvisorInvoiceTaxHandlingTypes.noVatHandling:
                            {
                                withBlock.WriteElementString("SalesInvoiceTaxHandlingType", NetvisorInvoice.TAX_HANDLING_TYPE_NO_VAT_HANDLING);
                                break;
                            }

                        default:
                            {
                                throw new ApplicationException("Unknow taxhandling type: " + invoice.taxHandlingType);
                                break;
                            }
                    }
                }

                withBlock.WriteStartElement("PaymentTermNetDays");
                withBlock.WriteString(invoice.PaymentTermNetDays.ToString());
                withBlock.WriteEndElement();

                if (!Information.IsNothing(invoice.paymentTermCashDiscountDays) & !Information.IsNothing(invoice.paymentTermCashDiscount))
                {
                    withBlock.WriteStartElement("paymentTermCashDiscountDays");
                    withBlock.WriteString(invoice.paymentTermCashDiscountDays.ToString());
                    withBlock.WriteEndElement();

                    string cashDiscountType;

                    switch (invoice.paymentTermCashDiscountType)
                    {
                        case NetvisorInvoice.paymentTermCashDiscountTypes.PERCENTAGE:
                            {
                                cashDiscountType = "percentage";
                                break;
                            }

                        default:
                            {
                                throw new ApplicationException("Valid CashDiscountType must be set in order to use PaymentTermCashDiscount");
                                break;
                            }
                    }

                    withBlock.WriteStartElement("PaymentTermCashDiscount");
                    withBlock.WriteAttributeString("type", cashDiscountType);
                    withBlock.WriteString(invoice.paymentTermCashDiscount.ToString());
                    withBlock.WriteEndElement();
                }

                withBlock.WriteStartElement("ExpectPartialPayments");
                withBlock.WriteString("1");
                withBlock.WriteEndElement();

                if (invoice.TryDirectDebitLink)
                {
                    withBlock.WriteStartElement("TryDirectDebitLink");

                    string mode = Constants.vbNullString;
                    if (invoice.IgnoreDirectDebitLinkError)
                        mode = NetvisorInvoice.DIRECT_DEBIT_LINK_ERROR_MODE_IGNORE;
                    else
                        mode = NetvisorInvoice.DIRECT_DEBIT_LINK_ERROR_MODE_FAIL;

                    withBlock.WriteAttributeString("mode", mode);
                    withBlock.WriteString("1");
                    withBlock.WriteEndElement();
                }

                if (invoice.OverrideVoucherSalesReceivablesAccountNumber > 0)
                    withBlock.WriteElementString("OverrideVoucherSalesReceivablesAccountNumber", invoice.OverrideVoucherSalesReceivablesAccountNumber);

                if (invoice.invoiceSubjectType > 0)
                {
                    string subjectType = string.Empty;

                    switch (invoice.invoiceSubjectType)
                    {
                        case NetvisorInvoice.invoiceSubjectTypes.memberInvoice:
                            {
                                subjectType = "memberinvoice";
                                break;
                            }

                        default:
                            {
                                throw new ApplicationException("Invalid invoice subject type: " + invoice.invoiceSubjectType);
                                break;
                            }
                    }

                    withBlock.WriteElementString("InvoiceSubjectType", subjectType);
                }

                if (Strings.Len(invoice.printChannelFormat) > 0)
                {
                    withBlock.WriteStartElement("PrintChannelFormat");
                    switch (invoice.printChannelFormatType)
                    {
                        case NetvisorInvoice.PrintChannelFormatSource.EXTERNAL_IDENTIFIER:
                            {
                                withBlock.WriteAttributeString("type", "customer");
                                break;
                            }

                        case NetvisorInvoice.PrintChannelFormatSource.NETVISOR_IDENTIFIER:
                            {
                                withBlock.WriteAttributeString("type", "netvisor");
                                break;
                            }

                        default:
                            {
                                throw new ApplicationException("Unkown print channel format identifier type: " + invoice.printChannelFormatType);
                                break;
                            }
                    }
                    withBlock.WriteString(invoice.printChannelFormat);
                    withBlock.WriteEndElement();
                }

                if (Strings.Len(invoice.secondname) > 0)
                {
                    withBlock.WriteStartElement("SecondName");
                    switch (invoice.secondnameType)
                    {
                        case NetvisorInvoice.SecondNameSource.EXTERNAL_IDENTIFIER:
                            {
                                withBlock.WriteAttributeString("type", "customer");
                                break;
                            }

                        case NetvisorInvoice.SecondNameSource.NETVISOR_IDENTIFIER:
                            {
                                withBlock.WriteAttributeString("type", "netvisor");
                                break;
                            }

                        default:
                            {
                                throw new ApplicationException("Unkown print channel format identifier type: " + invoice.secondnameType);
                                break;
                            }
                    }
                    withBlock.WriteString(invoice.secondname);
                    withBlock.WriteEndElement();
                }

                if (!Information.IsNothing(invoice.OverrideRateOfOverdue))
                    withBlock.WriteElementString("OverrideRateOfOverdue", invoice.OverrideRateOfOverdue);

                withBlock.WriteStartElement("InvoiceLines");

                foreach (INetvisorInvoiceLine line in invoice.invoiceLines)
                {
                    withBlock.WriteStartElement("InvoiceLine");

                    if ((line) is NetvisorInvoiceCommentLine)
                    {
                        NetvisorInvoiceCommentLine invoiceLine = line;

                        withBlock.WriteStartElement("SalesInvoiceCommentLine");
                        withBlock.WriteElementString("Comment", invoiceLine.comment);
                        withBlock.WriteEndElement(); // /SalesInvoiceCommentLine 
                    }
                    else
                    {
                        NetvisorInvoiceProductLine invoiceLine = line;

                        withBlock.WriteStartElement("SalesInvoiceProductLine");

                        withBlock.WriteStartElement("ProductIdentifier");

                        if (invoiceLine.ProductIdentifierType > 0)
                        {
                            switch (invoiceLine.ProductIdentifierType)
                            {
                                case NetvisorInvoiceProductLine.productIdentifierTypes.EXTERNAL_IDENTIFIER:
                                    {
                                        withBlock.WriteAttributeString("type", "customer");
                                        break;
                                    }

                                case NetvisorInvoiceProductLine.productIdentifierTypes.NETVISOR_IDENTIFIER:
                                    {
                                        withBlock.WriteAttributeString("type", "netvisor");
                                        break;
                                    }

                                default:
                                    {
                                        throw new ApplicationException("Unkown product identifier type: " + invoiceLine.ProductIdentifierType);
                                        break;
                                    }
                            }
                        }
                        else
                            withBlock.WriteAttributeString("type", "customer");

                        withBlock.WriteString(invoiceLine.ProductIdentifier);
                        withBlock.WriteEndElement();

                        withBlock.WriteStartElement("ProductName");
                        withBlock.WriteString(invoiceLine.ProductName);
                        withBlock.WriteEndElement();

                        withBlock.WriteStartElement("ProductUnitPrice");

                        string vatType;
                        if (invoiceLine.productUnitPriceIsGross)
                            vatType = "gross";
                        else
                            vatType = "net";

                        withBlock.WriteAttributeString("type", vatType);
                        withBlock.WriteString(invoiceLine.ProductUnitPrice.ToString());
                        withBlock.WriteEndElement();

                        string vatCode = Constants.vbNullString;
                        switch (invoiceLine.productVatCode)
                        {
                            case util.VatCode.vatCodes.DOMESTIC_PURCHASE:
                                {
                                    vatCode = util.VatCode.DOMESTIC_PURCHASE;
                                    break;
                                }

                            case util.VatCode.vatCodes.DOMESTIC_SALES:
                                {
                                    vatCode = util.VatCode.DOMESTIC_SALES;
                                    break;
                                }

                            case util.VatCode.vatCodes.EU_PURCHASE:
                                {
                                    vatCode = util.VatCode.EU_PURCHASE;
                                    break;
                                }

                            case util.VatCode.vatCodes.EU_SALES:
                                {
                                    vatCode = util.VatCode.EU_SALES;
                                    break;
                                }

                            case util.VatCode.vatCodes.EU_SERVICE_PURCHASE:
                                {
                                    vatCode = util.VatCode.EU_SERVICE_PURCHASE;
                                    break;
                                }

                            case util.VatCode.vatCodes.HUNDREDPERCENT_DEDUCTED_TAX:
                                {
                                    vatCode = util.VatCode.HUNDREDPERCENT_DEDUCTED_TAX;
                                    break;
                                }

                            case util.VatCode.vatCodes.NO_VAT_HANDLING:
                                {
                                    vatCode = util.VatCode.NO_VAT_HANDLING;
                                    break;
                                }

                            case util.VatCode.vatCodes.NON_EU_PURCHASE:
                                {
                                    vatCode = util.VatCode.NON_EU_PURCHASE;
                                    break;
                                }

                            case util.VatCode.vatCodes.NON_EU_SALES:
                                {
                                    vatCode = util.VatCode.NON_EU_SALES;
                                    break;
                                }

                            case util.VatCode.vatCodes.EU_SERVICE_SALES_312:
                                {
                                    vatCode = util.VatCode.EU_SERVICE_SALES_312;
                                    break;
                                }

                            case util.VatCode.vatCodes.EU_SERVICE_SALES_309:
                                {
                                    vatCode = util.VatCode.EU_SERVICE_SALES_309;
                                    break;
                                }

                            case util.VatCode.vatCodes.NO_TAX_SALES:
                                {
                                    vatCode = util.VatCode.NO_TAX_SALES;
                                    break;
                                }

                            case util.VatCode.vatCodes.NO_DEDUCTIBLE_EU_PURCHASE:
                                {
                                    vatCode = util.VatCode.NO_DEDUCTIBLE_EU_PURCHASE;
                                    break;
                                }

                            case util.VatCode.vatCodes.NO_DEDUCTIBLE_EU_SERVICEPURHASE:
                                {
                                    vatCode = util.VatCode.NO_DEDUCTIBLE_EU_SERVICEPURHASE;
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }

                        withBlock.WriteStartElement("ProductVatPercentage");

                        if (!string.IsNullOrEmpty(vatCode))
                            withBlock.WriteAttributeString("vatcode", vatCode);

                        withBlock.WriteString(invoiceLine.ProductVatPercentage.ToString());
                        withBlock.WriteEndElement();

                        withBlock.WriteStartElement("SalesInvoiceProductlineQuantity");
                        withBlock.WriteString(invoiceLine.DeliveredQuantity.ToString());
                        withBlock.WriteEndElement();

                        if (invoiceLine.LineDiscountPercentage != 0)
                            withBlock.WriteElementString("SalesInvoiceProductLineDiscountPercentage", invoiceLine.LineDiscountPercentage);

                        if (Strings.Len(invoiceLine.LineText) > 0)
                        {
                            withBlock.WriteStartElement("SalesInvoiceProductLineFreeText");
                            withBlock.WriteString(invoiceLine.LineText);
                            withBlock.WriteEndElement();
                        }

                        if (invoiceLine.LineVatSum.HasValue)
                            withBlock.WriteElementString("SalesInvoiceProductLineVatSum", invoiceLine.LineVatSum);

                        if (invoiceLine.LineSum.HasValue)
                            withBlock.WriteElementString("SalesInvoiceProductLineSum", invoiceLine.LineSum);

                        if (invoiceLine.AccountingSuggestionAccountNumber > 0)
                            withBlock.WriteElementString("AccountingAccountSuggestion", invoiceLine.AccountingSuggestionAccountNumber);

                        if (invoiceLine.skipAccrual)
                            withBlock.WriteElementString("SkipAccrual", "1");

                        foreach (NetvisorDimension dimension in invoiceLine.dimensions)
                        {
                            withBlock.WriteStartElement("Dimension");
                            withBlock.WriteElementString("DimensionName", dimension.dimensionName);
                            withBlock.WriteStartElement("DimensionItem");

                            if (Strings.Len(dimension.integrationDimensionDetailGuid) > 0)
                                withBlock.WriteAttributeString("integrationdimensiondetailguid", dimension.integrationDimensionDetailGuid);

                            withBlock.WriteValue(dimension.dimensionDetail);
                            withBlock.WriteEndElement(); // /DimensionItem

                            if (dimension.dimensionDetailMetaDataList.Count > 0)
                            {
                                foreach (string value in dimension.dimensionDetailMetaDataList)
                                {
                                    withBlock.WriteStartElement("Metadata");
                                    withBlock.WriteElementString("data", value);
                                    withBlock.WriteEndElement(); // /Metadata
                                }
                            }

                            withBlock.WriteEndElement(); // /Dimension
                        }

                        withBlock.WriteEndElement(); // /salesinvoiceproductline
                    }

                    withBlock.WriteEndElement(); // /invoiceline
                }

                withBlock.WriteEndElement(); // /invoicelines

                if (invoice.invoiceVoucherLines.Count > 0)
                {
                    withBlock.WriteStartElement("InvoiceVoucherLines");

                    foreach (NetvisorInvoiceVoucherLine voucherLine in invoice.invoiceVoucherLines)
                    {
                        withBlock.WriteStartElement("VoucherLine");

                        withBlock.WriteStartElement("LineSum");

                        if (voucherLine.LineSumType == NetvisorInvoiceVoucherLine.lineSumTypes.NET)
                            withBlock.WriteAttributeString("type", "net");
                        else
                            withBlock.WriteAttributeString("type", "gross");

                        withBlock.WriteString(voucherLine.lineSum);
                        withBlock.WriteEndElement();

                        withBlock.WriteStartElement("Description");
                        withBlock.WriteString(voucherLine.LineDescription);
                        withBlock.WriteEndElement();

                        withBlock.WriteStartElement("AccountNumber");
                        withBlock.WriteString(voucherLine.AccountNumber);
                        withBlock.WriteEndElement();

                        withBlock.WriteStartElement("VatPercent");
                        withBlock.WriteAttributeString("vatcode", voucherLine.vatCode);
                        withBlock.WriteString(voucherLine.vatClass);
                        withBlock.WriteEndElement();

                        if (voucherLine.skipAccrual)
                            withBlock.WriteElementString("SkipAccrual", "1");

                        if (voucherLine.Dimensions.Count > 0)
                        {
                            foreach (NetvisorDimension dimension in voucherLine.Dimensions)
                            {
                                withBlock.WriteStartElement("Dimension");

                                withBlock.WriteElementString("DimensionName", dimension.dimensionName);
                                withBlock.WriteStartElement("DimensionItem");

                                if (Strings.Len(dimension.integrationDimensionDetailGuid) > 0)
                                    withBlock.WriteAttributeString("integrationdimensiondetailguid", dimension.integrationDimensionDetailGuid);

                                withBlock.WriteValue(dimension.dimensionDetail);
                                withBlock.WriteEndElement(); // /DimensionItem

                                if (dimension.dimensionDetailMetaDataList.Count > 0)
                                {
                                    foreach (string value in dimension.dimensionDetailMetaDataList)
                                    {
                                        withBlock.WriteStartElement("Metadata");
                                        withBlock.WriteElementString("data", value);
                                        withBlock.WriteEndElement(); // /Metadata
                                    }
                                }

                                withBlock.WriteEndElement(); // /Dimension
                            }
                        }
                        else if (!(voucherLine.dimensionName == Constants.vbNullString) & !(voucherLine.dimensionItem == Constants.vbNullString))
                        {
                            withBlock.WriteStartElement("Dimension");

                            withBlock.WriteStartElement("DimensionName");
                            withBlock.WriteString(voucherLine.dimensionName);
                            withBlock.WriteEndElement();

                            withBlock.WriteStartElement("DimensionItem");
                            withBlock.WriteString(voucherLine.dimensionItem);
                            withBlock.WriteEndElement();

                            withBlock.WriteEndElement(); // /Dimension
                        }

                        withBlock.WriteEndElement(); // /VoucherLine
                    }

                    withBlock.WriteEndElement(); // /invoicevoucherlines
                }

                if (invoice.invoiceAccrualEntries.Count > 0)
                {
                    withBlock.WriteStartElement("SalesInvoiceAccrual");

                    if (invoice.OverrideDefaultSalesAccrualAccountNumber > 0)
                        withBlock.WriteElementString("OverrideDefaultSalesAccrualAccountNumber", invoice.OverrideDefaultSalesAccrualAccountNumber);

                    if (invoice.salesinvoiceAccrualType > 0)
                    {
                        switch (invoice.salesinvoiceAccrualType)
                        {
                            case NetvisorInvoice.salesinvoiceAccrualTypes.useCustomVoucher:
                                {
                                    withBlock.WriteElementString("SalesinvoiceAccrualType", "custom");
                                    break;
                                }

                            default:
                                {
                                    withBlock.WriteElementString("SalesinvoiceAccrualType", "default");
                                    break;
                                }
                        }
                    }

                    foreach (NetvisorInvoiceAccrualEntry entry in invoice.invoiceAccrualEntries)
                    {
                        withBlock.WriteStartElement("AccrualVoucherEntry");

                        withBlock.WriteElementString("Month", entry.month);
                        withBlock.WriteElementString("Year", entry.year);
                        withBlock.WriteElementString("Sum", entry.sum);

                        withBlock.WriteEndElement(); // /AccrualVoucherEntry
                    }

                    withBlock.WriteEndElement(); // /SalesInvoiceAccrual
                }

                if (invoice.invoiceAttachments.Count > 0)
                {
                    withBlock.WriteStartElement("SalesInvoiceAttachments");

                    foreach (NetvisorAttachment attachment in invoice.invoiceAttachments)
                    {
                        withBlock.WriteStartElement("SalesInvoiceAttachment");

                        withBlock.WriteElementString("MimeType", attachment.mimeType);
                        withBlock.WriteElementString("AttachmentDescription", attachment.description);
                        withBlock.WriteElementString("Filename", attachment.fileName);

                        withBlock.WriteStartElement("Documentdata");

                        if (attachment.type == NetvisorAttachment.AttachmentTypes.finvoice)
                            withBlock.WriteAttributeString("type", "finvoice");

                        withBlock.WriteString(Convert.ToBase64String(attachment.attachmentData));
                        withBlock.WriteEndElement(); // / Documentdata

                        if (attachment.printByDefaultOnSalesInvoice)
                            withBlock.WriteElementString("PrintByDefault", "1");

                        withBlock.WriteEndElement(); // /SalesInvoiceAttachment
                    }

                    withBlock.WriteEndElement(); // /SalesInvoiceAttachments
                }

                if (invoice.invoiceCustomTags.Count > 0)
                {
                    withBlock.WriteStartElement("CustomTags");

                    foreach (NetvisorInvoiceCustomTag tag in invoice.invoiceCustomTags)
                    {
                        withBlock.WriteStartElement("Tag");

                        withBlock.WriteElementString("TagName", tag.name);

                        withBlock.WriteStartElement("TagValue");

                        string tagDataType;
                        switch (tag.valueDataType)
                        {
                            case NetvisorInvoiceCustomTag.CustomTagDataTypes.date:
                                {
                                    tagDataType = NetvisorInvoiceCustomTag.ATTRIBUTE_DATATYPE_DATE;
                                    break;
                                }

                            case NetvisorInvoiceCustomTag.CustomTagDataTypes.@enum:
                                {
                                    tagDataType = NetvisorInvoiceCustomTag.ATTRIBUTE_DATATYPE_ENUM;
                                    break;
                                }

                            case NetvisorInvoiceCustomTag.CustomTagDataTypes.@float:
                                {
                                    tagDataType = NetvisorInvoiceCustomTag.ATTRIBUTE_DATATYPE_FLOAT;
                                    break;
                                }

                            case NetvisorInvoiceCustomTag.CustomTagDataTypes.text:
                                {
                                    tagDataType = NetvisorInvoiceCustomTag.ATTRIBUTE_DATATYPE_TEXT;
                                    break;
                                }

                            default:
                                {
                                    throw new ApplicationException("Invalid customtag datatype: " + tag.valueDataType);
                                    break;
                                }
                        }

                        withBlock.WriteAttributeString("datatype", tagDataType);
                        withBlock.WriteString(tag.value);
                        withBlock.WriteEndElement(); // /TagValue

                        withBlock.WriteEndElement(); // /Tag
                    }

                    withBlock.WriteEndElement(); // /CustomTags
                }

                withBlock.WriteEndElement(); // /salesinvoice
                withBlock.WriteEndElement(); // /root

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return streamReader.ReadToEnd();
        }
    }
}
