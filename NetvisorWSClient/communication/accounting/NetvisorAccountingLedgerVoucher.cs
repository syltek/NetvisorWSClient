namespace NetvisorWSClient.communication.accounting
{
    public class NetvisorAccountingLedgerVoucher : NetvisorVoucher
    {
        public enum VoucherResponseStatus : int
        {
            VALID = 1,
            INVALIDATED = 2,
            DELETED = 3
        }

        private int m_netvisorKey;
        private string m_voucherNetvisorURI;
        private VoucherResponseStatus? m_Status = default(VoucherResponseStatus?);
        private string m_LinkedSourceType;
        private int? m_LinkedSourceNetvisorKey;

        public int netvisorKey
        {
            get
            {
                return m_netvisorKey;
            }
            set
            {
                m_netvisorKey = value;
            }
        }

        public string voucherNetvisorURI
        {
            get
            {
                return m_voucherNetvisorURI;
            }
            set
            {
                m_voucherNetvisorURI = value;
            }
        }

        public VoucherResponseStatus? Status
        {
            get
            {
                return m_Status;
            }
            set
            {
                m_Status = value;
            }
        }

        public string LinkedSourceType
        {
            get
            {
                return m_LinkedSourceType;
            }
            set
            {
                m_LinkedSourceType = value;
            }
        }

        public int? LinkedSourceNetvisorKey
        {
            get
            {
                return m_LinkedSourceNetvisorKey;
            }
            set
            {
                m_LinkedSourceNetvisorKey = value;
            }
        }
    }
}

