using System.Collections;
using System;

namespace NetvisorWSClient.communication.payroll
{
    public class NetvisorPayrollPaycheckBatch
    {
        public const string IDENTIFIER_EMPLOYEE_NUMBER = "employeenumber";
        public const string IDENTIFIER_FINNISH_PERSONAL_IDENTIFIER = "finnishpersonalidentifier";

        public enum employeeIdentifierTypes
        {
            employeeNumber = 1,
            finnishPersonalIdentifier = 2
        }

        private object m_employeeIdentifier;
        private employeeIdentifierTypes m_employeeIdentifierType;
        private DateTime m_ruleGroupPeriodStart;
        private DateTime m_ruleGroupPeriodEnd;
        private string m_freeTextBeforeLines;
        private string m_freeTextAfterLines;
        private DateTime m_dueDate;
        private DateTime m_valueDate;
        private ArrayList m_batchLines = new ArrayList();

        public object employeeIdentifier
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

        public DateTime ruleGroupPeriodStart
        {
            get
            {
                return m_ruleGroupPeriodStart;
            }
            set
            {
                m_ruleGroupPeriodStart = value;
            }
        }

        public DateTime ruleGroupPeriodEnd
        {
            get
            {
                return m_ruleGroupPeriodEnd;
            }
            set
            {
                m_ruleGroupPeriodEnd = value;
            }
        }

        public string freeTextBeforeLines
        {
            get
            {
                return m_freeTextBeforeLines;
            }
            set
            {
                m_freeTextBeforeLines = value;
            }
        }

        public string freeTextAfterLines
        {
            get
            {
                return m_freeTextAfterLines;
            }
            set
            {
                m_freeTextAfterLines = value;
            }
        }

        public DateTime dueDate
        {
            get
            {
                return m_dueDate;
            }
            set
            {
                m_dueDate = value;
            }
        }

        public DateTime valueDate
        {
            get
            {
                return m_valueDate;
            }
            set
            {
                m_valueDate = value;
            }
        }

        public ArrayList batchLines
        {
            get
            {
                return m_batchLines;
            }
        }

        public void addBatchLine(NetvisorPayrollPaycheckBatchLine batchLine)
        {
            m_batchLines.Add(batchLine);
        }

        public void clearBatchLines()
        {
            m_batchLines.Clear();
        }
    }
}
