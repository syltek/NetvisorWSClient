using System.Collections;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.collector
{
    public class NetvisorCollectorTripExpenseCustomLine
    {
        public enum employeeIdentifierTypes : int
        {
            finnishPersonalIdentifier = 1,
            number = 2
        }

        public enum customerIdentifierTypes : int
        {
            netvisor = 1,
            customerCode = 2
        }

        public enum LineStatuses : int
        {
            OPEN = 1,
            CONFIRMED = 2,
            CONTENTSUPERVISORED = 6,
            ACCEPTED = 3,
            PAID = 5
        }


        private string m_employeeIdentifier;
        private employeeIdentifierTypes m_employeeIdentifierType;
        private string m_ratio;
        private decimal m_amount;
        private decimal m_customLineUnitPrice;
        private string m_vatPercentage;
        private string m_lineDescription;
        private string m_CRMProcessIdentifier;
        private string m_customerIdentifier;
        private customerIdentifierTypes m_customerIdentifierType;
        private string m_ExpenseAccountNumber;
        private ArrayList m_dimensions = new ArrayList();
        private ArrayList m_attachments = new ArrayList();
        private LineStatuses m_lineStatus;

        public string employeeIdentifier
        {
            get
            {
                return m_employeeIdentifier;
            }
            set
            {
                m_employeeIdentifier = value;
            }
        }

        public employeeIdentifierTypes employeeIdentifierType
        {
            get
            {
                return m_employeeIdentifierType;
            }
            set
            {
                m_employeeIdentifierType = value;
            }
        }

        public string ratio
        {
            get
            {
                return m_ratio;
            }
            set
            {
                m_ratio = value;
            }
        }

        public decimal amount
        {
            get
            {
                return m_amount;
            }
            set
            {
                m_amount = value;
            }
        }

        public decimal customLineUnitPrice
        {
            get
            {
                return m_customLineUnitPrice;
            }
            set
            {
                m_customLineUnitPrice = value;
            }
        }

        public string vatPercentage
        {
            get
            {
                return m_vatPercentage;
            }
            set
            {
                m_vatPercentage = value;
            }
        }

        public string lineDescription
        {
            get
            {
                return m_lineDescription;
            }
            set
            {
                m_lineDescription = value;
            }
        }

        public string CRMProcessIdentifier
        {
            get
            {
                return m_CRMProcessIdentifier;
            }
            set
            {
                m_CRMProcessIdentifier = value;
            }
        }

        public string customerIdentifier
        {
            get
            {
                return m_customerIdentifier;
            }
            set
            {
                m_customerIdentifier = value;
            }
        }

        public customerIdentifierTypes customerIdentifierType
        {
            get
            {
                return m_customerIdentifierType;
            }
            set
            {
                m_customerIdentifierType = value;
            }
        }

        public string ExpenseAccountNumber
        {
            get
            {
                return m_ExpenseAccountNumber;
            }
            set
            {
                m_ExpenseAccountNumber = value;
            }
        }

        public LineStatuses lineStatus
        {
            get
            {
                return m_lineStatus;
            }
            set
            {
                m_lineStatus = value;
            }
        }


        public void addDimension(NetvisorDimension dimension)
        {
            m_dimensions.Add(dimension);
        }

        public void addAttachment(NetvisorAttachment attachment)
        {
            m_attachments.Add(attachment);
        }

        public ArrayList dimensions
        {
            get
            {
                return m_dimensions;
            }
        }

        public ArrayList attachments
        {
            get
            {
                return m_attachments;
            }
        }
    }
}
