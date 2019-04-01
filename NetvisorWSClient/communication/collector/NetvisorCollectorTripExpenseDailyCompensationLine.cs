using System.Collections;
using System;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.collector
{
    public class NetvisorCollectorTripExpenseDailyCompensationLine
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

        public enum compensationTypes : int
        {
            domesticFull = 1,
            domesticHalf = 2,
            foreign = 3
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
        private compensationTypes m_compensationType;
        private decimal m_amount;
        private decimal m_unitPrice;
        private string m_lineDescription;
        private DateTime m_timeOfDeparture;
        private DateTime m_returnTime;
        private string m_CRMProcessIdentifier;
        private string m_customerIdentifier;
        private customerIdentifierTypes m_customerIdentifierType;
        private LineStatuses m_lineStatus;

        private ArrayList m_dimensions = new ArrayList();
        private ArrayList m_attachments = new ArrayList();

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

        public compensationTypes compensationType
        {
            get
            {
                return m_compensationType;
            }
            set
            {
                m_compensationType = value;
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

        public decimal unitPrice
        {
            get
            {
                return m_unitPrice;
            }
            set
            {
                m_unitPrice = value;
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

        public DateTime timeOfDeparture
        {
            get
            {
                return m_timeOfDeparture;
            }
            set
            {
                m_timeOfDeparture = value;
            }
        }

        public DateTime returnTime
        {
            get
            {
                return m_returnTime;
            }
            set
            {
                m_returnTime = value;
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
    }
}
