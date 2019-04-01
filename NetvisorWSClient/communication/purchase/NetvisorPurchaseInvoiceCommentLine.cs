
// 
// 
// 
// Revisio $Revision$
// 
// Ilmentää netvisoriin vietävän ostolaskun kommenttirivin
// 

namespace NetvisorWSClient.communication.purchase
{
    public class NetvisorPurchaseInvoiceCommentLine
    {
        private string m_comment;
        private int m_sort;


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

        public int sort
        {
            get
            {
                return m_sort;
            }
            set
            {
                m_sort = value;
            }
        }
    }
}
