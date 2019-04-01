using System.Collections;
using System;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.collector
{
    public class NetvisorCollectorTripExpenseTravelLine
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

        public enum travelTypes : int
        {
            CAR = 1,
            CAR_WITH_TRAILER = 2,
            CAR_WITH_CARAVAN = 3,
            CAR_WITH_HEAVY_CARGO = 4,
            CAR_WITH_BIG_MACHINERY = 5,
            CAR_WITH_DOG = 6,
            CAR_TRAVEL_IN_ROUGH_TERRAIN = 7,
            MOTORBOAT_MAX_50HP = 8,
            MOTORBOAT_OVER_50HP = 9,
            SNOWMOBILE = 10,
            ATV = 11,
            MOTORBIKE = 12,
            MOPED = 13,
            OTHER = 14
        }

        private string m_employeeIdentifier;
        private employeeIdentifierTypes m_employeeIdentifierType;
        private travelTypes m_travelType;
        private decimal m_passangerAmount;
        private decimal m_kilometerAmount;
        private decimal m_unitPrice;
        private string m_routeDescription;
        private string m_lineDescription;
        private DateTime m_travelDate;
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

        public travelTypes travelType
        {
            get
            {
                return m_travelType;
            }
            set
            {
                m_travelType = value;
            }
        }

        public decimal passangerAmount
        {
            get
            {
                return m_passangerAmount;
            }
            set
            {
                m_passangerAmount = value;
            }
        }

        public decimal kilometerAmount
        {
            get
            {
                return m_kilometerAmount;
            }
            set
            {
                m_kilometerAmount = value;
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

        public string routeDescription
        {
            get
            {
                return m_routeDescription;
            }
            set
            {
                m_routeDescription = value;
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

        public DateTime travelDate
        {
            get
            {
                return m_travelDate;
            }
            set
            {
                m_travelDate = value;
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
