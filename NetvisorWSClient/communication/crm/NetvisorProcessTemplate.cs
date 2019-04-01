namespace NetvisorWSClient.communication.crm
{
    public class NetvisorProcessTemplate
    {
        private int m_NetvisorKey = default(int);
        private string m_Name;

        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }

        public string netvisorKey
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
    }
}

