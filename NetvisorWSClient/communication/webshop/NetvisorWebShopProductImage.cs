
namespace NetvisorWSClient.communication.webshop
{
    public class NetvisorWebShopProductImage
    {
        private string m_MimeType;
        private string m_Title;
        private string m_FileName;
        private byte[] m_DocumentData;

        public string MimeType
        {
            get
            {
                return m_MimeType;
            }
            set
            {
                m_MimeType = value;
            }
        }

        public string Title
        {
            get
            {
                return m_title;
            }
            set
            {
                m_title = value;
            }
        }

        public string FileName
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

        public byte[] DocumentData
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
    }
}
