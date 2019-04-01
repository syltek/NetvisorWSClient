using System.Collections;

namespace NetvisorWSClient.communication.escan
{
    public class EScanDocument
    {
        public const string TARGET_SALES_INVOICE = "salesinvoice";
        public const string TARGET_PURCHASE_INVOICE = "purchaseinvoice";
        public const string TARGET_TRIP_EXPENSE_MONEY_TRANSFER = "tripexpensemoneytransfer";

        public enum EScanDocumentTargets : int
        {
            SALES_INVOICE = 1,
            PURCHASE_INVOICE = 2,
            TRIP_EXPENSE_MONEY_TRANSFER = 3
        }

        public enum CompressionSettings : int
        {
            GZIP = 1,
            NO_COMPRESSION = 2
        }

        public enum SupportedDocumentMimeTypes : int
        {
            IMAGE_BMP = 1,
            IMAGE_EMF = 2,
            IMAGE_EXIF = 3,
            IMAGE_GIF = 4,
            IMAGE_ICON = 5,
            IMAGE_JPEG = 6,
            IMAGE_PNG = 7,
            IMAGE_TIFF = 8,
            APPLICATION_PDF = 9,
            IMAGE_WMF = 10
        }

        private int m_Version;
        private string m_DocumentType;
        private string m_Description;
        private string m_DocumentMimeType;
        private CompressionSettings m_Compression;
        private byte[] m_documentData;
        private int m_fileSize;
        private ArrayList m_targets = new ArrayList();

        public int Version
        {
            get
            {
                return m_Version;
            }
            set
            {
                m_Version = value;
            }
        }

        public string DocumentType
        {
            get
            {
                return m_DocumentType;
            }
            set
            {
                m_DocumentType = value;
            }
        }

        public string Description
        {
            get
            {
                return m_Description;
            }
            set
            {
                m_Description = value;
            }
        }

        public SupportedDocumentMimeTypes DocumentMimeType
        {
            get
            {
                return m_DocumentMimeType;
            }
            set
            {
                m_DocumentMimeType = value;
            }
        }

        public CompressionSettings Compression
        {
            get
            {
                return m_Compression;
            }
            set
            {
                m_Compression = value;
            }
        }

        public byte[] documentData
        {
            get
            {
                return m_documentData;
            }
            set
            {
                m_documentData = value;
            }
        }

        public int fileSize
        {
            get
            {
                return m_fileSize;
            }
            set
            {
                m_fileSize = value;
            }
        }

        public ArrayList targets
        {
            get
            {
                return m_targets;
            }
        }

        public void addTarget(EScanDocumentTargets target, int targetIdentifier)
        {
            m_targets.Add(new int[] { target, targetIdentifier });
        }
    }
}
