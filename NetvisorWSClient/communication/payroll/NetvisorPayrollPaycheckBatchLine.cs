using System.Collections;
using NetvisorWSClient.communication.common;

// 
// 
// 
// Revisio $Revision$
// 
// Ilmentää Netvisorin palkkalaskelman rivin
// 

namespace NetvisorWSClient.communication.payroll
{
    public class NetvisorPayrollPaycheckBatchLine
    {
        public const string RATIO_IDENTIFIER_RATIO_NUMBER = "rationumber";

        public enum payrollRatioIdentifierTypes
        {
            rationumber = 1
        }

        private object m_payrollRatioIdentifier;
        private payrollRatioIdentifierTypes m_payrollRatioIdentifierType;
        private decimal m_units;
        private decimal m_unitAmount;
        private decimal m_lineSum;
        private string m_description;
        private ArrayList m_batchLineDimensions = new ArrayList();

        public object payrollRatioIdentifier
        {
            get
            {
                return m_payrollRatioIdentifier;
            }
            set
            {
                m_payrollRatioIdentifier = value;
            }
        }

        public payrollRatioIdentifierTypes payrollRatioIdentifierType
        {
            get
            {
                return m_payrollRatioIdentifierType;
            }
            set
            {
                m_payrollRatioIdentifierType = value;
            }
        }

        public decimal units
        {
            get
            {
                return m_units;
            }
            set
            {
                m_units = value;
            }
        }

        public decimal unitAmount
        {
            get
            {
                return m_unitAmount;
            }
            set
            {
                m_unitAmount = value;
            }
        }

        public decimal lineSum
        {
            get
            {
                return m_lineSum;
            }
            set
            {
                m_lineSum = value;
            }
        }

        public string description
        {
            get
            {
                return m_description;
            }
            set
            {
                m_description = value;
            }
        }

        public ArrayList batchLineDimensions
        {
            get
            {
                return m_batchLineDimensions;
            }
        }

        public void addNewDimension(NetvisorDimension dimension)
        {
            m_batchLineDimensions.Add(dimension);
        }
    }
}
