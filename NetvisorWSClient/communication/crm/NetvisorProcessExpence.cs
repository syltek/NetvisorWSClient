using System;

namespace NetvisorWSClient.communication.crm
{
    public class NetvisorProcessExpence
    {
        public static readonly string purchaseInvoice = "PurchaseInvoice";
        public static readonly string tripCustomExpence = "TripCustomExpence";
        public static readonly string tripCompensationExpence = "TripCompensationExpence";
        public static readonly string tripTravelExpence = "TripTravelExpence";
        public static readonly string workHours = "WorkHours";

        public enum ExpenceTypes
        {
            purchaseInvoice = 1,
            tripCustomExpence = 2,
            tripCompensationExpence = 3,
            tripTravelExpence = 4,
            workHours = 5
        }

        private ExpenceTypes m_ExpenceType;
        private string m_ExpenceDescription;
        private double m_ExpenceSum;

        public ExpenceTypes ExpenceType
        {
            get
            {
                return m_ExpenceType;
            }
            set
            {
                m_ExpenceType = value;
            }
        }

        public string ExpenceDescription
        {
            get
            {
                return m_ExpenceDescription;
            }
            set
            {
                m_ExpenceDescription = value;
            }
        }

        public double ExpenceSum
        {
            get
            {
                return m_ExpenceSum;
            }
            set
            {
                m_ExpenceSum = value;
            }
        }

        public ExpenceTypes getExpenceType(string typeString)
        {
            switch (typeString)
            {
                case object _ when purchaseInvoice:
                    {
                        return ExpenceTypes.purchaseInvoice;
                    }

                case object _ when tripCompensationExpence:
                    {
                        return ExpenceTypes.tripCompensationExpence;
                    }

                case object _ when tripCustomExpence:
                    {
                        return ExpenceTypes.tripCustomExpence;
                    }

                case object _ when tripTravelExpence:
                    {
                        return ExpenceTypes.tripTravelExpence;
                    }

                case object _ when workHours:
                    {
                        return ExpenceTypes.workHours;
                    }

                default:
                    {
                        throw new Exception("not supported expence type");
                        break;
                    }
            }
        }
    }
}

