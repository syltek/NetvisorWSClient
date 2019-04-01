
namespace NetvisorWSClient.communication.sales
{
    public class NetvisorInvoiceCommentLine : INetvisorInvoiceLine
    {
        private string m_comment;

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
