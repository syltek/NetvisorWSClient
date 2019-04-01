using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Xml;

namespace NetvisorWSClient.communication.accounting
{
    public class NetvisorApplicationAccountingPeriodListResponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationAccountingPeriodListResponse(string responseData) : base(responseData)
        {
        }

        public NetvisorAccountingPeriodList getNetvisorAccountingPeriods()
        {
            NetvisorAccountingPeriodList periodList = new NetvisorAccountingPeriodList();

            XmlDocument periodListDocument = new XmlDocument();
            periodListDocument.LoadXml(base.responseData);

            if (Strings.Len(periodListDocument.SelectSingleNode("/Root/AccountingPeriodList/PeriodLockInformation/AccountingPeriodLockDate").InnerText) > 0)
                periodList.AccountingPeriodLockDate = periodListDocument.SelectSingleNode("/Root/AccountingPeriodList/PeriodLockInformation/AccountingPeriodLockDate").GetDateTime();

            if (Strings.Len(periodListDocument.SelectSingleNode("/Root/AccountingPeriodList/PeriodLockInformation/VatPeriodLockDate").InnerText) > 0)
                periodList.VatPeriodLockDate = periodListDocument.SelectSingleNode("/Root/AccountingPeriodList/PeriodLockInformation/VatPeriodLockDate").GetDateTime();

            if (Strings.Len(periodListDocument.SelectSingleNode("/Root/AccountingPeriodList/PeriodLockInformation/PurchaseLockDate").InnerText) > 0)
                periodList.PurchaseLockDate = periodListDocument.SelectSingleNode("/Root/AccountingPeriodList/PeriodLockInformation/PurchaseLockDate").GetDateTime();

            List<NetvisorPeriod> periods = new List<NetvisorPeriod>();

            foreach (XmlNode periodNode in periodListDocument.SelectNodes("/Root/AccountingPeriodList/Period"))
            {
                NetvisorPeriod period = new NetvisorPeriod();

                {
                    var withBlock = period;
                    withBlock.netvisorKey = periodNode.SelectSingleNode("NetvisorKey").GetInt();
                    withBlock.Name = System.Convert.ToString(periodNode.SelectSingleNode("Name").InnerText);
                    withBlock.beginDate = System.Convert.ToDateTime(periodNode.SelectSingleNode("BeginDate").InnerText);
                    withBlock.endDate = System.Convert.ToDateTime(periodNode.SelectSingleNode("EndDate").InnerText);
                }

                periods.Add(period);
            }

            periodList.periods = periods;

            return periodList;
        }
    }
}
