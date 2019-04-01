using System;

namespace NetvisorWSClient.communication.crm
{
    public class NetvisorProcessComment
    {
        private string m_WriterName;
        private string m_Message;
        private DateTime m_CreatedTimeStamp;

        public string WriterName
        {
            get
            {
                return m_WriterName;
            }
            set
            {
                m_WriterName = value;
            }
        }

        public string Message
        {
            get
            {
                return m_Message;
            }
            set
            {
                m_Message = value;
            }
        }

        public DateTime CreatedTimeStamp
        {
            get
            {
                return m_CreatedTimeStamp;
            }
            set
            {
                m_CreatedTimeStamp = value;
            }
        }
    }
}


