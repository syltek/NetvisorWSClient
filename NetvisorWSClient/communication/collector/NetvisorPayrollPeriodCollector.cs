using Microsoft.VisualBasic;
using System.Collections;
using System;

namespace NetvisorWSClient.communication.collector
{

    public class NetvisorPayrollPeriodCollector
    {




        public enum employeeIdentifierTypes : int
        {
            number = 1,
            personalidentificationnumber = 2
        }

        private DateTime m_date;
        private string m_employeeIdentifier;
        private employeeIdentifierTypes m_employeeIdentifierType;
        private ArrayList m_ratioLines = new ArrayList();

        public NetvisorPayrollPeriodCollector()
        {
        }

        public DateTime date
        {
            get
            {
                return m_date;
            }
            set
            {
                m_date = value;
            }
        }

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

        public ArrayList ratioLines
        {
            get
            {
                return m_ratioLines;
            }
        }

        public void addRatioLine(NetvisorPayrollRatioLine line)
        {
            m_ratioLines.Add(line);
        }

        public void clearRatioLines()
        {
            m_ratioLines.Clear();
        }
    }
}
