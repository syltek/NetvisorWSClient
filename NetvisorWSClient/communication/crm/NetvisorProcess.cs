using System.Data;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Xml.Linq;
using NetvisorWSClient.communication.sales;

// 
// Revisio $Revision$
// 
// Ilmentää tehtävän Netvisorin asiakkuuden hallinnassa
// 

namespace NetvisorWSClient.communication.crm
{
    public class NetvisorProcess
    {
        private NetvisorProcessTemplate m_ProcessTemplate;
        private string m_ProcessIdentifier;
        private string m_CustomerIdentifier;
        private string m_Description;
        private string m_Name;
        private DateTime m_DueDate;
        private bool m_IsClosed;
        private NetvisorCustomer m_Customer;
        private string m_CurrentProcessStageName;
        private NetvisorProcessProject m_Project;
        private string m_CorrespondPersonName;
        private DateTime m_CompletedDate;
        private string m_ContactPersonName;
        private string m_ContactPersonPhoneNumber;
        private string m_ContactPersonEmail;
        private string m_SalesInvoiceStatusDescription;
        private ArrayList m_SalesInvoices;
        private ArrayList m_Expences;
        private ArrayList m_Comments;
        private string m_InvoicingStatusIdentifier;


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

        public string ProcessIdentifier
        {
            get
            {
                return m_ProcessIdentifier;
            }
            set
            {
                m_ProcessIdentifier = value;
            }
        }

        public string InvoicingStatusIdentifier
        {
            get
            {
                return m_InvoicingStatusIdentifier;
            }
            set
            {
                m_InvoicingStatusIdentifier = value;
            }
        }

        public string CustomerIdentifier
        {
            get
            {
                return m_CustomerIdentifier;
            }
            set
            {
                m_CustomerIdentifier = value;
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
                return m_DueDate;
            }
            set
            {
                m_DueDate = value;
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

        public NetvisorProcessProject Project
        {
            get
            {
                return m_Project;
            }
            set
            {
                m_Project = value;
            }
        }

        public string CorrespondPersonName
        {
            get
            {
                return m_CorrespondPersonName;
            }
            set
            {
                m_CorrespondPersonName = value;
            }
        }

        public string ContactPersonName
        {
            get
            {
                return m_ContactPersonName;
            }
            set
            {
                m_ContactPersonName = value;
            }
        }

        public string ContactPersonPhoneNumber
        {
            get
            {
                return m_ContactPersonPhoneNumber;
            }
            set
            {
                m_ContactPersonPhoneNumber = value;
            }
        }

        public string ContactPersonEmail
        {
            get
            {
                return m_ContactPersonEmail;
            }
            set
            {
                m_ContactPersonEmail = value;
            }
        }

        public string SalesInvoiceStatusDescription
        {
            get
            {
                return m_SalesInvoiceStatusDescription;
            }
            set
            {
                m_SalesInvoiceStatusDescription = value;
            }
        }

        public DateTime CompletedDate
        {
            get
            {
                return m_CompletedDate;
            }
            set
            {
                m_CompletedDate = value;
            }
        }

        public ArrayList Comments
        {
            get
            {
                return m_Comments;
            }
            set
            {
                m_Comments = value;
            }
        }

        public ArrayList SalesInvoices
        {
            get
            {
                return m_SalesInvoices;
            }
            set
            {
                m_SalesInvoices = value;
            }
        }

        public ArrayList Expences
        {
            get
            {
                return m_Expences;
            }
            set
            {
                m_Expences = value;
            }
        }
    }
}
