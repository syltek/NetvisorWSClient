using Microsoft.VisualBasic;
using System.Xml;

namespace NetvisorWSClient.communication.controller
{
    public class NetvisorApplicationAccountingBudgetAccountBudgetResponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationAccountingBudgetAccountBudgetResponse(string responseData) : base(responseData)
        {
        }

        public NetvisorAccountingBudgetAccountBudget getAccountBudget()
        {
            NetvisorAccountingBudgetAccountBudget accountBudget = new NetvisorAccountingBudgetAccountBudget();

            XmlDocument accountBudgetingDocument = new XmlDocument();
            accountBudgetingDocument.LoadXml(base.responseData);

            foreach (XmlNode lockedDimensionNode in accountBudgetingDocument.SelectNodes("/Root/AccountingBudgetAccountBudget/LockedDimension"))
            {
                NetvisorAccountingBudgetLockedDimension lockedDimension = new NetvisorAccountingBudgetLockedDimension();
                lockedDimension.DimensionName = lockedDimensionNode.SelectSingleNode("DimensionName").InnerText;
                lockedDimension.DimensionItemName = lockedDimensionNode.SelectSingleNode("DimensionItemName").InnerText;

                accountBudget.addLockedDimension(lockedDimension);
            }

            foreach (XmlNode accountNode in accountBudgetingDocument.SelectNodes("/Root/AccountingBudgetAccountBudget/BudgetAccount"))
            {
                NetvisorAccountingBudgetAccount account = new NetvisorAccountingBudgetAccount();
                account.AccountNumber = System.Convert.ToInt32(accountNode.SelectSingleNode("AccountNumber").InnerText);
                account.AccountName = accountNode.SelectSingleNode("AccountName").InnerText;
                account.AccountGroup = System.Convert.ToInt32(accountNode.SelectSingleNode("AccountGroup").InnerText);

                foreach (XmlNode monthNode in accountNode.SelectNodes("BudgetMonth"))
                {
                    NetvisorAccountingBudgetMonth month = new NetvisorAccountingBudgetMonth();
                    month.Sum = System.Convert.ToDouble(Strings.Replace(monthNode.SelectSingleNode("Sum").InnerText, ".", ","));
                    month.VAT = System.Convert.ToDouble(monthNode.SelectSingleNode("Vat").InnerText);
                    month.Month = System.Convert.ToInt32(monthNode.SelectSingleNode("Month").InnerText);
                    month.Year = System.Convert.ToInt32(monthNode.SelectSingleNode("Year").InnerText);

                    account.addMonth(month);
                }

                accountBudget.addBudgetAccount(account);
            }

            return accountBudget;
        }
    }
}

