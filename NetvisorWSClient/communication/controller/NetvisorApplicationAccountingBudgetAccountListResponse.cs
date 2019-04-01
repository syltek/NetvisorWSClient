using System.Collections.Generic;
using System.Collections;
using System.Xml;

namespace NetvisorWSClient.communication.controller
{
    public class NetvisorApplicationAccountingBudgetAccountListResponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationAccountingBudgetAccountListResponse(string responseData) : base(responseData)
        {
        }

        public ArrayList getAccountList()
        {
            List<NetvisorAccountingBudgetAccountListAccount> accounts = new List<NetvisorAccountingBudgetAccountListAccount>();

            XmlDocument accountListDocument = new XmlDocument();
            accountListDocument.LoadXml(base.responseData);

            foreach (XmlNode accountNode in accountListDocument.SelectNodes("/Root/AccountingBudgetAccountList/Account"))
            {
                NetvisorAccountingBudgetAccountListAccount account = new NetvisorAccountingBudgetAccountListAccount();
                account.NetvisorKey = System.Convert.ToInt32(accountNode.SelectSingleNode("NetvisorKey").InnerText);
                account.Name = accountNode.SelectSingleNode("Name").InnerText;
                account.Number = System.Convert.ToInt32(accountNode.SelectSingleNode("Number").InnerText);
                account.Group = System.Convert.ToInt32(accountNode.SelectSingleNode("Group").InnerText);
                account.Type = System.Convert.ToInt32(accountNode.SelectSingleNode("Type").InnerText);

                accounts.Add(account);
            }

            return ArrayList.Adapter(accounts);
        }
    }
}

