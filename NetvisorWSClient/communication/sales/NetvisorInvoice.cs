using Microsoft.VisualBasic;
using System.Collections;
using System;
using NetvisorWSClient.util;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.sales
{
    public class NetvisorInvoice
    {
        public const string DIRECT_DEBIT_LINK_ERROR_MODE_IGNORE = "ignore_error";
        public const string DIRECT_DEBIT_LINK_ERROR_MODE_FAIL = "fail_on_error";

        public const string NETVISOR_TEMP_CUSTOMER_CODE = "TEMP";

        public const string TAX_HANDLING_TYPE_COUNTRY_GROUP = "countrygroup";
        public const string TAX_HANDLING_TYPE_DOMESTIC_CONSTRUCTION_SERVICES = "domesticconstructionservice";
        public const string TAX_HANDLING_TYPE_NO_VAT_HANDLING = "notaxhandling";

        public enum NetvisorInvoiceTypes
        {
            invoice = 1,
            order = 2
        }

        public enum NetvisorInvoiceStatuses
        {
            UnSent = 9,
            Open = 1
        }

        public enum NetvisorInvoiceTaxHandlingTypes : int
        {
            countryGroup = 1,
            domesticConstructionService = 2,
            noVatHandling = 3
        }

        public enum NetvisorOrderStatuses
        {
            Delivered = 8,
            unDelivered = 9
        }

        public enum CustomerIdentifierSource : int
        {
            EXTERNAL_IDENTIFIER = 1,
            NETVISOR_IDENTIFIER = 2
        }

        public enum PrintChannelFormatSource : int
        {
            EXTERNAL_IDENTIFIER = 1,
            NETVISOR_IDENTIFIER = 2
        }

        public enum SecondNameSource : int
        {
            EXTERNAL_IDENTIFIER = 1,
            NETVISOR_IDENTIFIER = 2
        }

        public enum paymentTermCashDiscountTypes : int
        {
            PERCENTAGE = 1
        }

        public enum invoiceSubjectTypes : int
        {
            memberInvoice = 1
        }

        public enum salesinvoiceAccrualTypes : int
        {
            useCustomVoucher = 1,
            @default = 2
        }

        private FinnishOrganisationIdentifier m_requestNetvisorRecipientOrganisationID;

        private ArrayList m_invoiceLines = new ArrayList();
        private ArrayList m_invoiceCustomTags = new ArrayList();
        private ArrayList m_invoiceVoucherLines = new ArrayList();
        private ArrayList m_invoiceAccrualEntries = new ArrayList();
        private ArrayList m_invoiceAttachments = new ArrayList();

        private NetvisorInvoiceTypes m_invoiceType;
        private NetvisorInvoiceStatuses m_InvoiceStatus;
        private string m_InvoiceNumber;
        private DateTime m_InvoiceDate;
        private DateTime m_DeliveryDate;
        private ReferenceNumber m_ReferenceNumber;
        private string m_sellerName;
        private int m_sellerIdentifier;

        private CustomerIdentifierSource m_CustomerIdentifierType;
        private string m_CustomerIdentifier;
        private string m_CustomerName;
        private string m_CustomerNameExtension;
        private string m_CustomerAddress;
        private string m_CustomerPostNumber;
        private string m_CustomerTown;
        private string m_CustomerCountryISO3166Code;

        private string m_DeliveryName;
        private string m_DeliveryAddress;
        private string m_DeliveryPostNumber;
        private string m_DeliveryTown;
        private string m_DeliveryCountryISO3166Code;

        private string m_DeliveryTerm;
        private string m_DeliveryMethod;

        private decimal? m_invoiceSum;
        private string m_iso4217currencycode;
        private decimal m_overrideCurrencyRate;
        private byte[] m_verifyingAttachmentData;
        private string m_salesInvoiceFreeTextBeforeLines;
        private string m_salesInvoiceFreeTextAfterLines;
        private string m_ourReference;
        private string m_yourReference;
        private string m_privateComment;
        private NetvisorInvoiceTaxHandlingTypes m_taxHandlingType;

        private int m_PaymentTermNetDays;
        private object m_paymentTermCashDiscountDays;
        private object m_paymentTermCashDiscount;
        private paymentTermCashDiscountTypes m_paymentTermCashDiscountType;

        private bool m_TryDirectDebitLink;
        private bool m_IgnoreDirectDebitLinkError;

        private int m_OverrideVoucherSalesReceivablesAccountNumber;
        private int m_OverrideDefaultSalesAccrualAccountNumber;
        private salesinvoiceAccrualTypes m_salesinvoiceAccrualType;

        private string m_printChannelFormat;
        private PrintChannelFormatSource m_printChannelFormatType;

        private string m_secondname;
        private SecondNameSource m_secondnameType;

        private invoiceSubjectTypes m_invoiceSubjectType;
        private decimal? m_OverrideRateOfOverdue;

        public NetvisorInvoice()
        {
            m_CustomerIdentifierType = CustomerIdentifierSource.EXTERNAL_IDENTIFIER;
        }

        public FinnishOrganisationIdentifier requestNetvisorRecipientOrganisationID
        {
            get
            {
                return m_requestNetvisorRecipientOrganisationID;
            }
            set
            {
                m_requestNetvisorRecipientOrganisationID = value;
            }
        }

        public NetvisorInvoiceTypes invoiceType
        {
            get
            {
                return m_invoiceType;
            }
            set
            {
                m_invoiceType = value;
            }
        }

        public string InvoiceStatus
        {
            get
            {
                return m_InvoiceStatus;
            }
            set
            {
                m_InvoiceStatus = value;
            }
        }

        public string InvoiceNumber
        {
            get
            {
                return m_InvoiceNumber;
            }
            set
            {
                m_InvoiceNumber = value;
            }
        }

        public DateTime InvoiceDate
        {
            get
            {
                return m_InvoiceDate;
            }
            set
            {
                m_InvoiceDate = value;
            }
        }

        public DateTime DeliveryDate
        {
            get
            {
                return m_DeliveryDate;
            }
            set
            {
                m_DeliveryDate = value;
            }
        }

        public ReferenceNumber ReferenceNumber
        {
            get
            {
                return m_ReferenceNumber;
            }
            set
            {
                m_ReferenceNumber = value;
            }
        }

        public string sellerName
        {
            get
            {
                return m_sellerName;
            }
            set
            {
                if (Strings.Len(value) > 50)
                    throw new ApplicationException("Sellername too long");
                else
                    m_sellerName = value;
            }
        }

        public int sellerIdentifier
        {
            get
            {
                return m_sellerIdentifier;
            }
            set
            {
                m_sellerIdentifier = value;
            }
        }

        public CustomerIdentifierSource CustomerIdentifierType
        {
            get
            {
                return m_CustomerIdentifierType;
            }
            set
            {
                m_CustomerIdentifierType = value;
            }
        }

        public string CustomerIdentifier
        {
            get
            {
                return m_CustomerIdentifier;
            }
            set
            {
                m_CustomerIdentifier = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return m_CustomerName;
            }
            set
            {
                if (Strings.Len(value) > 250)
                    throw new ApplicationException("Customername too long");
                else
                    m_CustomerName = value;
            }
        }

        public string CustomerAddress
        {
            get
            {
                return m_CustomerAddress;
            }
            set
            {
                if (Strings.Len(value) > 100)
                    throw new ApplicationException("Customeraddress too long");
                else
                    m_CustomerAddress = value;
            }
        }

        public string CustomerPostNumber
        {
            get
            {
                return m_CustomerPostNumber;
            }
            set
            {
                m_CustomerPostNumber = value;
            }
        }

        public string CustomerTown
        {
            get
            {
                return m_CustomerTown;
            }
            set
            {
                m_CustomerTown = value;
            }
        }

        public string CustomerCountryISO3166Code
        {
            get
            {
                return m_CustomerCountryISO3166Code;
            }
            set
            {
                m_CustomerCountryISO3166Code = value;
            }
        }

        public string CustomerNameExtension
        {
            get
            {
                return m_CustomerNameExtension;
            }
            set
            {
                m_CustomerNameExtension = value;
            }
        }

        public string DeliveryName
        {
            get
            {
                return m_DeliveryName;
            }
            set
            {
                if (Strings.Len(value) > 250)
                    throw new ApplicationException("Deliveryname too long");
                else
                    m_DeliveryName = value;
            }
        }

        public string DeliveryAddress
        {
            get
            {
                return m_DeliveryAddress;
            }
            set
            {
                if (Strings.Len(value) > 100)
                    throw new ApplicationException("Deliveryaddress too long");
                else
                    m_DeliveryAddress = value;
            }
        }

        public string DeliveryPostNumber
        {
            get
            {
                return m_DeliveryPostNumber;
            }
            set
            {
                m_DeliveryPostNumber = value;
            }
        }

        public string DeliveryTown
        {
            get
            {
                return m_DeliveryTown;
            }
            set
            {
                m_DeliveryTown = value;
            }
        }

        public string DeliveryCountryISO3166Code
        {
            get
            {
                return m_DeliveryCountryISO3166Code;
            }
            set
            {
                m_DeliveryCountryISO3166Code = value;
            }
        }


        public string DeliveryTerm
        {
            get
            {
                return m_DeliveryTerm;
            }
            set
            {
                m_DeliveryTerm = value;
            }
        }


        public string DeliveryMethod
        {
            get
            {
                return m_DeliveryMethod;
            }
            set
            {
                m_DeliveryMethod = value;
            }
        }

        public NetvisorInvoiceTaxHandlingTypes taxHandlingType
        {
            get
            {
                return m_taxHandlingType;
            }
            set
            {
                m_taxHandlingType = value;
            }
        }

        public int PaymentTermNetDays
        {
            get
            {
                return m_PaymentTermNetDays;
            }
            set
            {
                m_PaymentTermNetDays = value;
            }
        }

        public object paymentTermCashDiscountDays
        {
            get
            {
                return m_paymentTermCashDiscountDays;
            }
            set
            {
                m_paymentTermCashDiscountDays = value;
            }
        }


        public object paymentTermCashDiscount
        {
            get
            {
                return m_paymentTermCashDiscount;
            }
            set
            {
                m_paymentTermCashDiscount = value;
            }
        }


        public paymentTermCashDiscountTypes paymentTermCashDiscountType
        {
            get
            {
                return m_paymentTermCashDiscountType;
            }
            set
            {
                m_paymentTermCashDiscountType = value;
            }
        }

        public decimal? InvoiceSum
        {
            get
            {
                return m_invoiceSum;
            }
            set
            {
                m_invoiceSum = value;
            }
        }

        public string iso4217currencycode
        {
            get
            {
                return m_iso4217currencycode;
            }
            set
            {
                m_iso4217currencycode = value;
            }
        }

        public decimal overrideCurrencyRate
        {
            get
            {
                return m_overrideCurrencyRate;
            }
            set
            {
                m_overrideCurrencyRate = value;
            }
        }

        public byte[] VerifyingAttachmentData
        {
            get
            {
                return m_verifyingAttachmentData;
            }
            set
            {
                m_verifyingAttachmentData = value;
            }
        }

        public string SalesInvoiceFreeTextBeforeLines
        {
            get
            {
                return m_salesInvoiceFreeTextBeforeLines;
            }
            set
            {
                if (Strings.Len(value) > 500)
                    throw new ApplicationException("Freetext before invoicelines too long");
                else
                    m_salesInvoiceFreeTextBeforeLines = value;
            }
        }

        public string SalesInvoiceFreeTextAfterLines
        {
            get
            {
                return m_salesInvoiceFreeTextAfterLines;
            }
            set
            {
                if (Strings.Len(value) > 500)
                    throw new ApplicationException("Freetext after invoicelines too long");
                else
                    m_salesInvoiceFreeTextAfterLines = value;
            }
        }

        public string ourReference
        {
            get
            {
                return m_ourReference;
            }
            set
            {
                m_ourReference = value;
            }
        }

        public string yourReference
        {
            get
            {
                return m_yourReference;
            }
            set
            {
                m_yourReference = value;
            }
        }

        public string privateComment
        {
            get
            {
                return m_privateComment;
            }
            set
            {
                if (Strings.Len(value) > 255)
                    throw new ApplicationException("Privatecomment too long");
                else
                    m_privateComment = value;
            }
        }

        public int OverrideVoucherSalesReceivablesAccountNumber
        {
            get
            {
                return m_OverrideVoucherSalesReceivablesAccountNumber;
            }
            set
            {
                m_OverrideVoucherSalesReceivablesAccountNumber = value;
            }
        }

        public invoiceSubjectTypes invoiceSubjectType
        {
            get
            {
                return m_invoiceSubjectType;
            }
            set
            {
                m_invoiceSubjectType = value;
            }
        }

        public string printChannelFormat
        {
            get
            {
                return m_printChannelFormat;
            }
            set
            {
                m_printChannelFormat = value;
            }
        }

        public PrintChannelFormatSource printChannelFormatType
        {
            get
            {
                return m_printChannelFormatType;
            }
            set
            {
                m_printChannelFormatType = value;
            }
        }


        public string secondname
        {
            get
            {
                return m_secondname;
            }
            set
            {
                m_secondname = value;
            }
        }

        public SecondNameSource secondnameType
        {
            get
            {
                return m_secondnameType;
            }
            set
            {
                m_secondnameType = value;
            }
        }

        public ArrayList invoiceLines
        {
            get
            {
                return m_invoiceLines;
            }
        }

        public void addInvoiceLine(INetvisorInvoiceLine line)
        {
            m_invoiceLines.Add(line);
        }

        public void clearInvoiceLines()
        {
            m_invoiceLines.Clear();
        }

        public ArrayList invoiceAccrualEntries
        {
            get
            {
                return m_invoiceAccrualEntries;
            }
        }

        public void addInvoiceAccrualEntry(NetvisorInvoiceAccrualEntry entry)
        {
            m_invoiceAccrualEntries.Add(entry);
        }

        public void clearInvoiceAccrualEntries()
        {
            m_invoiceAccrualEntries.Clear();
        }

        public int OverrideDefaultSalesAccrualAccountNumber
        {
            get
            {
                return m_OverrideDefaultSalesAccrualAccountNumber;
            }
            set
            {
                m_OverrideDefaultSalesAccrualAccountNumber = value;
            }
        }

        public salesinvoiceAccrualTypes salesinvoiceAccrualType
        {
            get
            {
                return m_salesinvoiceAccrualType;
            }
            set
            {
                m_salesinvoiceAccrualType = value;
            }
        }

        public ArrayList invoiceCustomTags
        {
            get
            {
                return m_invoiceCustomTags;
            }
        }

        public bool TryDirectDebitLink
        {
            get
            {
                return m_TryDirectDebitLink;
            }
            set
            {
                m_TryDirectDebitLink = value;
            }
        }

        public bool IgnoreDirectDebitLinkError
        {
            get
            {
                return m_IgnoreDirectDebitLinkError;
            }
            set
            {
                m_IgnoreDirectDebitLinkError = value;
            }
        }

        public void addInvoiceCustomTag(NetvisorInvoiceCustomTag tag)
        {
            m_invoiceCustomTags.Add(tag);
        }

        public void clearInvoiceCustomTags()
        {
            m_invoiceCustomTags.Clear();
        }

        public ArrayList invoiceVoucherLines
        {
            get
            {
                return m_invoiceVoucherLines;
            }
        }

        public decimal? OverrideRateOfOverdue
        {
            get
            {
                return m_OverrideRateOfOverdue;
            }
            set
            {
                m_OverrideRateOfOverdue = value;
            }
        }


        public void addInvoiceVoucherLine(NetvisorInvoiceVoucherLine line)
        {
            m_invoiceVoucherLines.Add(line);
        }

        public void clearInvoiceVoucherLines()
        {
            m_invoiceVoucherLines.Clear();
        }

        public decimal getInvoiceTotalAmountCalculatedFromProductLines()
        {
            decimal totalAmount;

            foreach (INetvisorInvoiceLine line in m_invoiceLines)
            {
                if ((line) is NetvisorInvoiceProductLine)
                {
                    NetvisorInvoiceProductLine invoiceLine = line;

                    if (invoiceLine.productUnitPriceIsGross)
                        totalAmount += Math.Round(invoiceLine.DeliveredQuantity * (invoiceLine.ProductUnitPrice - (invoiceLine.ProductUnitPrice * (invoiceLine.LineDiscountPercentage / 100))), 2, MidpointRounding.AwayFromZero);
                    else
                        totalAmount += Math.Round(invoiceLine.DeliveredQuantity * (invoiceLine.ProductUnitPrice - (invoiceLine.ProductUnitPrice * (invoiceLine.LineDiscountPercentage / 100))) * (1 + invoiceLine.ProductVatPercentage / 100), 2, MidpointRounding.AwayFromZero);
                }
            }

            return totalAmount;
        }

        public void addAttachment(NetvisorAttachment attachment)
        {
            m_invoiceAttachments.Add(attachment);
        }

        public ArrayList invoiceAttachments
        {
            get
            {
                return m_invoiceAttachments;
            }
        }
    }
}

