using Microsoft.VisualBasic;
using System.Collections;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.collector
{

    public class NetvisorWorkDayHour
    {




        public enum acceptanceStatuses : int
        {
            confirmed = 1,
            accepted = 2
        }

        public enum billingType : int
        {
            unbillable = 1,
            billable = 2
        }

        private decimal m_Hours;
        private string m_CollectorRatioNumber;
        private acceptanceStatuses m_AcceptanceStatus;
        private string m_Description;
        private string m_CrmProcessIdentifier;
        private billingType m_CrmProcessIdentifierBillingType;
        private string m_InvoicingProductIdentifier;
        private ArrayList m_dimensions = new ArrayList();

        public decimal Hours
        {
            get
            {
                return m_Hours;
            }
            set
            {
                m_Hours = value;
            }
        }

        public void setHours(string hours)
        {
            m_Hours = decimal.Parse(hours);
        }

        public string CollectorRatioNumber
        {
            get
            {
                return m_CollectorRatioNumber;
            }
            set
            {
                m_CollectorRatioNumber = value;
            }
        }

        public acceptanceStatuses AcceptanceStatus
        {
            get
            {
                return m_AcceptanceStatus;
            }
            set
            {
                m_AcceptanceStatus = value;
            }
        }

        public string CrmProcessIdentifier
        {
            get
            {
                return m_CrmProcessIdentifier;
            }
            set
            {
                m_CrmProcessIdentifier = value;
            }
        }

        public billingType CrmProcessIdentifierBillingType
        {
            get
            {
                return m_CrmProcessIdentifierBillingType;
            }
            set
            {
                m_CrmProcessIdentifierBillingType = value;
            }
        }

        public string InvoicingProductIdentifier
        {
            get
            {
                return m_InvoicingProductIdentifier;
            }
            set
            {
                m_InvoicingProductIdentifier = value;
            }
        }

        public string Description
        {
            get
            {
                return m_Description;
            }
            set
            {
                m_Description = value;
            }
        }

        public ArrayList dimensions
        {
            get
            {
                return m_dimensions;
            }
        }

        public void setAcceptanceConfirmed()
        {
            m_AcceptanceStatus = acceptanceStatuses.confirmed;
        }

        public void addDimension(NetvisorDimension dimension)
        {
            m_dimensions.Add(dimension);
        }

        public void clearDimensions()
        {
            m_dimensions.Clear();
        }
    }
}
