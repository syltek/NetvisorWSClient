using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections;
using System.Xml;

namespace NetvisorWSClient.communication.accounting
{
    public class NetvisorApplicationAccountListReponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationAccountListReponse(string responseData) : base(responseData)
        {
        }

        public NetvisorAccountList getNetvisorAccountList()
        {
            NetvisorAccountList accountList = new NetvisorAccountList();

            XmlDocument accountListDocument = new XmlDocument();
            accountListDocument.LoadXml(base.responseData);

            Hashtable defaultAccounts = new Hashtable();
            List<NetvisorAccount> accounts = new List<NetvisorAccount>();

            foreach (XmlNode companyDefaultAccountNode in accountListDocument.SelectNodes("/Root/AccountList/CompanyDefaultAccounts"))
            {
                foreach (XmlNode child in companyDefaultAccountNode.ChildNodes)
                    defaultAccounts.Add(child.Name, child.InnerText);
            }

            foreach (XmlNode accountNode in accountListDocument.SelectNodes("/Root/AccountList/Accounts/Account"))
            {
                NetvisorAccount account = new NetvisorAccount();

                {
                    var withBlock = account;
                    withBlock.NetvisorKey = System.Convert.ToInt32(accountNode.SelectSingleNode("NetvisorKey").InnerText);
                    withBlock.Number = System.Convert.ToString(accountNode.SelectSingleNode("Number").InnerText);
                    withBlock.Name = System.Convert.ToString(accountNode.SelectSingleNode("Name").InnerText);
                    withBlock.AccountType = System.Convert.ToString(accountNode.SelectSingleNode("AccountType").InnerText);
                    withBlock.FatherNetvisorKey = System.Convert.ToInt32(accountNode.SelectSingleNode("FatherNetvisorKey").InnerText);

                    if (Strings.Len(accountNode.SelectSingleNode("IsActive").InnerText) > 0)
                        withBlock.IsActive = System.Convert.ToInt32(accountNode.SelectSingleNode("IsActive").InnerText) == 1;

                    if (Strings.Len(accountNode.SelectSingleNode("IsCumulative").InnerText) > 0)
                        withBlock.IsCumulative = System.Convert.ToInt32(accountNode.SelectSingleNode("IsCumulative").InnerText) == 1;

                    if (Strings.Len(accountNode.SelectSingleNode("Sort").InnerText) > 0)
                        withBlock.Sort = System.Convert.ToInt32(accountNode.SelectSingleNode("Sort").InnerText);

                    if (Strings.Len(accountNode.SelectSingleNode("EndSort").InnerText) > 0)
                        withBlock.EndSort = System.Convert.ToInt32(accountNode.SelectSingleNode("EndSort").InnerText);

                    if (Strings.Len(accountNode.SelectSingleNode("IsNaturalNegative").InnerText) > 0)
                        withBlock.IsNaturalNegative = System.Convert.ToInt32(accountNode.SelectSingleNode("IsNaturalNegative").InnerText) == 1;
                }

                accounts.Add(account);
            }

            accountList.accountList = accounts;
            accountList.companyDefaultAccounts = defaultAccounts;

            return accountList;
        }
    }
}
