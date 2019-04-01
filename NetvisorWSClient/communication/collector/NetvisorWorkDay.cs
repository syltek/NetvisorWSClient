using Microsoft.VisualBasic;
using System.Collections;
using System;

namespace NetvisorWSClient.communication.collector
{

    public class NetvisorWorkDay
    {




        public enum employeeIdentifierTypes : int
        {
            number = 1,
            personalidentificationnumber = 2
        }

        public enum dateMethods : int
        {
            replace = 1,
            increment = 2
        }

        public enum employeeDefaultDimensionHandlingTypes : int
        {
            none = 1,
            usedefault = 2
        }

        private DateTime m_date;
        private dateMethods m_dateMethod;
        private string m_employeeIdentifier;
        private employeeIdentifierTypes m_employeeIdentifierType;
        private employeeDefaultDimensionHandlingTypes m_employeeDefaultDimensionHandlingType;
        private ArrayList m_workDayHours = new ArrayList();

        public NetvisorWorkDay()
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

        public dateMethods dateMethod
        {
            get
            {
                return m_dateMethod;
            }
            set
            {
                m_dateMethod = value;
            }
        }

        public employeeDefaultDimensionHandlingTypes employeeDefaultDimensionHandlingType
        {
            get
            {
                return m_employeeDefaultDimensionHandlingType;
            }
            set
            {
                m_employeeDefaultDimensionHandlingType = value;
            }
        }


        public ArrayList workDayHours
        {
            get
            {
                return m_workDayHours;
            }
        }

        public void addHours(NetvisorWorkDayHour hour)
        {
            m_workDayHours.Add(hour);
        }

        public void clearHours()
        {
            m_workDayHours.Clear();
        }
    }
}
