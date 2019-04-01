namespace NetvisorWSClient.communication.purchase
{
    public class NetvisorPurchaseOrderCommentLine
    {
        private string m_comment;

        public NetvisorPurchaseOrderCommentLine()
        {
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
    }
}

