using System.Collections;
using System;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.purchase
{
    public class NetvisorPurchaseInvoice
    {
        public const int MAX_VENDOR_NAME_LENGTH = 250;
        public const int MAX_VENDOR_ADDRESSLINE_LENGTH = 80;
        public const int MAX_VENDOR_POST_NUMBER_LENGTH = 50;
        public const int MAX_VENDOR_TOWN_LENGTH = 50;
        public const int MAX_VENDOR_COUNTRY_LENGTH = 50;
        public const int MAX_VENDOR_PHONENUMBER_LENGTH = 80;
        public const int MAX_VENDOR_FAXNUMBER_LENGTH = 80;
        public const int MAX_VENDOR_EMAIL_LENGTH = 80;
        public const int MAX_VENDOR_HOMEPAGE_LENGTH = 80;
        public const int MAX_INVOICE_BANKREFERENCENUMBER_LENGTH = 70;
        public const int MAX_INVOICE_OURREFERENCE_LENGTH = 200;
        public const int MAX_INVOICE_YOURREFERENCE_LENGTH = 200;
        public const int MAX_INVOICE_DELIVERYTERMS_LENGTH = 255;
        public const int MAX_INVOICE_DELIVERYMETHOD_LENGTH = 255;
        public const int MAX_INVOICE_COMMENT_LENGTH = 255;

        public enum invoiceSources : int
        {
            MANUAL = 1,
            FINVOICE = 2,
            CLARUS = 3,
            ITELLA = 4,
            MAVENTA_SCAN = 5,
            MAVENTA_FINVOICE = 6
        }

        public enum NetvisorPurchaseInvoiceRounds : int
        {
            UNHANDLED = 0,
            CONTENTSUPERVISORED = 2,
            ACCEPTED = 4
        }

        private string m_invoiceNumber;
        private DateTime m_invoiceDate;
        private DateTime m_valueDate;
        private DateTime m_dueDate;
        private NetvisorPurchaseInvoiceRounds m_InvoiceRound;
        private string m_vendorName;
        private string m_vendorAddressline;
        private string m_vendorPostNumber;
        private string m_vendorCity;
        private string m_vendorCountry;
        private string m_vendorPhoneNumber;
        private string m_vendorFaxNumber;
        private string m_vendorEmail;
        private string m_vendorHomepage;
        private decimal m_amount;
        private string m_accountNumber;
        private string m_organizationIdentifier;
        private invoiceSources m_invoiceSource;
        private DateTime m_deliveryDate;
        private decimal m_overdueFinePercent;
        private string m_bankReferenceNumber;
        private string m_ourReference;
        private string m_yourReference;
        private string m_currencyCode;
        private string m_deliveryTerms;
        private string m_deliveryMethod;
        private string m_comment;
        private string m_checkSum;
        private int m_pdfExtraPages;
        private bool m_findNextOpenDateIfInLockedPeriod;
        private int m_NetvisorKey;
        private bool m_readyForAccounting;

        private ArrayList m_invoiceLines = new ArrayList();
        private ArrayList m_attachments = new ArrayList();
        private ArrayList m_invoiceCommentLines = new ArrayList();
        private ArrayList m_invoiceSubLines = new ArrayList();

        private int m_lineCounter = 1;


        public int NetvisorKey
        {
            get
            {
                return m_NetvisorKey;
            }
            set
            {
                m_NetvisorKey = value;
            }
        }

        public bool findNextOpenDateIfInLockedPeriod
        {
            get
            {
                return m_findNextOpenDateIfInLockedPeriod;
            }
            set
            {
                m_findNextOpenDateIfInLockedPeriod = value;
            }
        }

        public string comment
        {
            get
            {
                return m_comment;
            }
            set
            {
                m_comment = value;
            }
        }

        public int pdfExtraPages
        {
            get
            {
                return m_pdfExtraPages;
            }
            set
            {
                m_pdfExtraPages = value;
            }
        }

        public string checkSum
        {
            get
            {
                return m_checkSum;
            }
            set
            {
                m_checkSum = value;
            }
        }

        public string organizationIdentifier
        {
            get
            {
                return m_organizationIdentifier;
            }
            set
            {
                m_organizationIdentifier = value;
            }
        }

        public invoiceSources invoiceSource
        {
            get
            {
                return m_invoiceSource;
            }
            set
            {
                m_invoiceSource = value;
            }
        }

        public DateTime deliveryDate
        {
            get
            {
                return m_deliveryDate;
            }
            set
            {
                m_deliveryDate = value;
            }
        }

        public decimal overdueFinePercent
        {
            get
            {
                return m_overdueFinePercent;
            }
            set
            {
                m_overdueFinePercent = value;
            }
        }

        public string bankReferenceNumber
        {
            get
            {
                return m_bankReferenceNumber;
            }
            set
            {
                m_bankReferenceNumber = value;
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

        public string currencyCode
        {
            get
            {
                return m_currencyCode;
            }
            set
            {
                m_currencyCode = value;
            }
        }

        public string deliveryTerms
        {
            get
            {
                return m_deliveryTerms;
            }
            set
            {
                m_deliveryTerms = value;
            }
        }

        public string deliveryMethod
        {
            get
            {
                return m_deliveryMethod;
            }
            set
            {
                m_deliveryMethod = value;
            }
        }

        public string vendorCountry
        {
            get
            {
                return m_vendorCountry;
            }
            set
            {
                m_vendorCountry = value;
            }
        }

        public string vendorPhoneNumber
        {
            get
            {
                return m_vendorPhoneNumber;
            }
            set
            {
                m_vendorPhoneNumber = value;
            }
        }

        public string vendorFaxNumber
        {
            get
            {
                return m_vendorFaxNumber;
            }
            set
            {
                m_vendorFaxNumber = value;
            }
        }

        public string vendorEmail
        {
            get
            {
                return m_vendorEmail;
            }
            set
            {
                m_vendorEmail = value;
            }
        }

        public string vendorHomepage
        {
            get
            {
                return m_vendorHomepage;
            }
            set
            {
                m_vendorHomepage = value;
            }
        }

        public string InvoiceNumber
        {
            get
            {
                return m_invoiceNumber;
            }
            set
            {
                m_invoiceNumber = value;
            }
        }

        public DateTime InvoiceDate
        {
            get
            {
                return m_invoiceDate;
            }
            set
            {
                m_invoiceDate = value;
            }
        }

        public DateTime ValueDate
        {
            get
            {
                return m_valueDate;
            }
            set
            {
                m_valueDate = value;
            }
        }

        public DateTime DueDate
        {
            get
            {
                return m_dueDate;
            }
            set
            {
                m_dueDate = value;
            }
        }

        public NetvisorPurchaseInvoiceRounds InvoiceRound
        {
            get
            {
                return m_InvoiceRound;
            }
            set
            {
                m_InvoiceRound = value;
            }
        }

        public string VendorName
        {
            get
            {
                return m_vendorName;
            }
            set
            {
                m_vendorName = value;
            }
        }

        public string VendorAddressline
        {
            get
            {
                return m_vendorAddressline;
            }
            set
            {
                m_vendorAddressline = value;
            }
        }

        public string VendorPostNumber
        {
            get
            {
                return m_vendorPostNumber;
            }
            set
            {
                m_vendorPostNumber = value;
            }
        }

        public string VendorCity
        {
            get
            {
                return m_vendorCity;
            }
            set
            {
                m_vendorCity = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return m_amount;
            }
            set
            {
                m_amount = value;
            }
        }

        public string AccountNumber
        {
            get
            {
                return m_accountNumber;
            }
            set
            {
                m_accountNumber = value;
            }
        }

        public ArrayList invoiceSubLines
        {
            get
            {
                return m_invoiceSubLines;
            }
        }

        public bool readyForAccounting
        {
            get
            {
                return m_readyForAccounting;
            }
            set
            {
                m_readyForAccounting = value;
            }
        }

        public ArrayList invoiceLines
        {
            get
            {
                return m_invoiceLines;
            }
        }


        public void addInvoiceLine(NetvisorPurchaseInvoiceLine line)
        {
            if (line.sort == 0)
                line.sort = m_lineCounter;
            else if (line.sort > m_lineCounter)
                m_lineCounter = line.sort;

            m_lineCounter += 1;

            m_invoiceLines.Add(line);
        }

        public void clearInvoiceLines()
        {
            m_invoiceLines.Clear();
        }

        public ArrayList attachments
        {
            get
            {
                return m_attachments;
            }
        }

        public void addAttachment(NetvisorAttachment attachment)
        {
            m_attachments.Add(attachment);
        }

        public void clearAttachments()
        {
            m_attachments.Clear();
        }

        public ArrayList invoiceCommentLines
        {
            get
            {
                return m_invoiceCommentLines;
            }
        }

        public void addInvoiceCommentLine(NetvisorPurchaseInvoiceCommentLine line)
        {
            if (line.sort == 0)
                line.sort = m_lineCounter;
            else if (line.sort > m_lineCounter)
                m_lineCounter = line.sort;

            m_lineCounter += 1;

            m_invoiceCommentLines.Add(line);
        }

        public void clearInvoiceCommentLines()
        {
            m_invoiceCommentLines.Clear();
        }

        public void addInvoiceSubLine(NetvisorPurchaseInvoiceSubLine line)
        {
            if (line.sort == 0)
                line.sort = m_lineCounter;
            else if (line.sort > m_lineCounter)
                m_lineCounter = line.sort;

            m_lineCounter += 1;

            m_invoiceSubLines.Add(line);
        }

        public void clearInvoiceSubLines()
        {
            m_invoiceSubLines.Clear();
        }
    }
}
