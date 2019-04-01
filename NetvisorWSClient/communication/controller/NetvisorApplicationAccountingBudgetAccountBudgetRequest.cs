using Microsoft.VisualBasic;
using System.Xml;
using System.Text;
using System.IO;

namespace NetvisorWSClient.communication.controller
{

    public class NetvisorApplicationAccountingBudgetAccountBudgetRequest
    {




        public string getAccountingBudgetAsXML(NetvisorAccountingBudgetAccountBudget accountBudget)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("AccountingBudgetAccountBudget");
                withBlock.WriteElementString("method", accountBudget.Method);

                foreach (NetvisorAccountingBudgetLockedDimension lockedDimension in accountBudget.LockedDimensionList)
                {
                    withBlock.WriteStartElement("LockedDimension");
                    withBlock.WriteElementString("DimensionName", lockedDimension.DimensionName);
                    withBlock.WriteElementString("DimensionItemName", lockedDimension.DimensionItemName);
                    withBlock.WriteEndElement();
                }

                foreach (NetvisorAccountingBudgetAccount account in accountBudget.BudgetAccountList)
                {
                    withBlock.WriteStartElement("BudgetAccount");

                    withBlock.WriteStartElement("AccountIdentifier");
                    withBlock.WriteElementString("AccountNumber", account.AccountNumber);
                    withBlock.WriteElementString("AccountName", account.AccountName);
                    withBlock.WriteElementString("AccountGroup", account.AccountGroup);
                    withBlock.WriteEndElement();

                    foreach (NetvisorAccountingBudgetMonth month in account.MonthList)
                    {
                        withBlock.WriteStartElement("BudgetMonth");

                        withBlock.WriteElementString("Sum", month.Sum);
                        withBlock.WriteElementString("VAT", month.VAT);
                        withBlock.WriteElementString("Month", month.Month);
                        withBlock.WriteElementString("Year", month.Year);

                        withBlock.WriteEndElement(); // /BudgetMonth
                    }

                    withBlock.WriteEndElement(); // /BudgetAccount
                }

                withBlock.WriteEndElement(); // /AccountingBudgetAccountBudget
                withBlock.WriteEndElement(); // /Root

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return streamReader.ReadToEnd();
        }
    }
}
