namespace NetvisorWSClient.communication
{
    public class NetvisorApplicationRequest
    {
        private string m_xmlData;
        private string m_url;

        public string requestURL
        {
            set
            {
                m_url = value;
            }
            get
            {
                return m_url;
            }
        }

        public string requestData
        {
            get
            {
                return m_xmlData;
            }
            set
            {
                m_xmlData = value;
            }
        }
    }
}
