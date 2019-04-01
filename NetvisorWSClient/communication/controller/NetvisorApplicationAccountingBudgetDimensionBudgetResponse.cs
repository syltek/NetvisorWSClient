using Microsoft.VisualBasic;
using System.Xml;

namespace NetvisorWSClient.communication.controller
{
    public class NetvisorApplicationAccountingBudgetDimensionBudgetResponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationAccountingBudgetDimensionBudgetResponse(string responseData) : base(responseData)
        {
        }

        public NetvisorAccountingBudgetDimensionBudget getDimensionBudget()
        {
            NetvisorAccountingBudgetDimensionBudget dimensionBudget = new NetvisorAccountingBudgetDimensionBudget();

            XmlDocument accountBudgetingDocument = new XmlDocument();
            accountBudgetingDocument.LoadXml(base.responseData);

            foreach (XmlNode lockedDimensionNode in accountBudgetingDocument.SelectNodes("/Root/AccountingBudgetDimensionBudget/LockedDimension"))
            {
                NetvisorAccountingBudgetLockedDimension lockedDimension = new NetvisorAccountingBudgetLockedDimension();
                lockedDimension.DimensionName = lockedDimensionNode.SelectSingleNode("DimensionName").InnerText;
                lockedDimension.DimensionItemName = lockedDimensionNode.SelectSingleNode("DimensionItemName").InnerText;

                dimensionBudget.addLockedDimension(lockedDimension);
            }

            dimensionBudget.AccountGroup = System.Convert.ToInt32(accountBudgetingDocument.SelectSingleNode("/Root/AccountingBudgetDimensionBudget/AccountGroup").InnerText);
            dimensionBudget.AccountNumber = System.Convert.ToInt32(accountBudgetingDocument.SelectSingleNode("/Root/AccountingBudgetDimensionBudget/AccountNumber").InnerText);
            dimensionBudget.AccountName = accountBudgetingDocument.SelectSingleNode("/Root/AccountingBudgetDimensionBudget/AccountName").InnerText;

            foreach (XmlNode dimensionNode in accountBudgetingDocument.SelectNodes("/Root/AccountingBudgetDimensionBudget/BudgetDimension"))
            {
                NetvisorAccountingBudgetDimension dimension = new NetvisorAccountingBudgetDimension();
                dimension.DimensionName = dimensionNode.SelectSingleNode("DimensionName").InnerText;
                dimension.DimensionItemName = dimensionNode.SelectSingleNode("DimensionItemName").InnerText;

                foreach (XmlNode monthNode in dimensionNode.SelectNodes("BudgetMonth"))
                {
                    NetvisorAccountingBudgetMonth month = new NetvisorAccountingBudgetMonth();
                    month.Sum = System.Convert.ToDouble(Strings.Replace(monthNode.SelectSingleNode("Sum").InnerText, ".", ","));
                    month.VAT = System.Convert.ToDouble(monthNode.SelectSingleNode("Vat").InnerText);
                    month.Month = System.Convert.ToInt32(monthNode.SelectSingleNode("Month").InnerText);
                    month.Year = System.Convert.ToInt32(monthNode.SelectSingleNode("Year").InnerText);

                    dimension.addMonth(month);
                }

                dimensionBudget.addBudgetDimension(dimension);
            }

            return dimensionBudget;
        }
    }
}

