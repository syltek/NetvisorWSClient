using System.Collections;

namespace NetvisorWSClient.communication.collector
{
    public class NetvisorCollectorTripExpense
    {
        private string m_header;
        private string m_description;

        private ArrayList m_customLines = new ArrayList();
        private ArrayList m_travelLines = new ArrayList();
        private ArrayList m_dailyCompensationLines = new ArrayList();

        public string header
        {
            get
            {
                return m_header;
            }
            set
            {
                m_header = value;
            }
        }

        public string Description
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

        public ArrayList customLines
        {
            get
            {
                return m_customLines;
            }
        }

        public ArrayList travelLines
        {
            get
            {
                return m_travelLines;
            }
        }

        public ArrayList dailyCompensationLines
        {
            get
            {
                return m_dailyCompensationLines;
            }
        }

        public void addCustomLine(NetvisorCollectorTripExpenseCustomLine customLine)
        {
            m_customLines.Add(customLine);
        }

        public void addTravelLine(NetvisorCollectorTripExpenseTravelLine travelLine)
        {
            m_travelLines.Add(travelLine);
        }

        public void addDailyCompensationLine(NetvisorCollectorTripExpenseDailyCompensationLine compensationLine)
        {
            m_dailyCompensationLines.Add(compensationLine);
        }
    }
}
