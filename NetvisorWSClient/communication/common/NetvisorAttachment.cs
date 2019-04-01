
namespace NetvisorWSClient.communication.common
{
    public class NetvisorAttachment
    {
        public enum AttachmentTypes : int
        {
            pdf = 1,
            finvoice = 2
        }

        public enum AttachmentCategory : int
        {
            invoiceImage = 1,
            otherAttachment = 2
        }

        private byte[] m_attachmentData;
        private string m_description;
        private string m_mimeType;
        private string m_fileName;
        private bool m_printByDefaultOnSalesInvoice;
        private AttachmentTypes m_type;
        private AttachmentCategory m_purchaseInvoiceAttachmentCategory;


        public AttachmentCategory purchaseInvoiceAttachmentCategory
        {
            get
            {
                return m_purchaseInvoiceAttachmentCategory;
            }
            set
            {
                m_purchaseInvoiceAttachmentCategory = value;
            }
        }

        public AttachmentTypes type
        {
            get
            {
                return m_type;
            }
            set
            {
                m_type = value;
            }
        }

        public byte[] attachmentData
        {
            get
            {
                return m_attachmentData;
            }
            set
            {
                m_attachmentData = value;
            }
        }

        public string description
        {
            get
            {
                return m_description;
            }
            set
            {
                m_description = value;
            }
        }

        public string mimeType
        {
            get
            {
                return m_mimeType;
            }
            set
            {
                m_mimeType = value;
            }
        }

        public string fileName
        {
            get
            {
                return m_fileName;
            }
            set
            {
                m_fileName = value;
            }
        }

        public bool printByDefaultOnSalesInvoice
        {
            get
            {
                return m_printByDefaultOnSalesInvoice;
            }
            set
            {
                m_printByDefaultOnSalesInvoice = value;
            }
        }
    }
}
