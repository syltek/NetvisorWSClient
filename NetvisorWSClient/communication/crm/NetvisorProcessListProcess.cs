using System;
using NetvisorWSClient.communication.sales;

// 
// Revisio $Revision$
// 
// Ilmentää netvisorin tehtävälistauksessa tulevan tehtävän
// 

namespace NetvisorWSClient.communication.crm
{
    public class NetvisorProcessListProcess
    {
        private int m_netvisorKey;
        private NetvisorProcessTemplate m_ProcessTemplate;
        private string m_ProcessIdentifier;
        private string m_Name;
        private DateTime m_DueDate;
        private bool m_IsClosed;
        private NetvisorCustomer m_Customer;
        private string m_CurrentProcessStageName;
        private string m_Description;

        public int NetvisorKey
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

        public NetvisorProcessTemplate ProcessTemplate
        {
            get
            {
                return m_ProcessTemplate;
            }
            set
            {
                m_ProcessTemplate = value;
            }
        }

        public string ProcessIdentifier
        {
            get
            {
                return m_processIdentifier;
            }
            set
            {
                m_processIdentifier = value;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }

        public bool IsClosed
        {
            get
            {
                return m_IsClosed;
            }
            set
            {
                m_IsClosed = value;
            }
        }

        public DateTime Duedate
        {
            get
            {
                return m_duedate;
            }
            set
            {
                m_duedate = value;
            }
        }


        public NetvisorCustomer Customer
        {
            get
            {
                return m_Customer;
            }
            set
            {
                m_Customer = value;
            }
        }

        public string CurrentProcessStageName
        {
            get
            {
                return m_CurrentProcessStageName;
            }
            set
            {
                m_CurrentProcessStageName = value;
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
    }
}
