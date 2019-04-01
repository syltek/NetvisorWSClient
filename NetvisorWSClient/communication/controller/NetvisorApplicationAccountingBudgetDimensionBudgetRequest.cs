using Microsoft.VisualBasic;
using System.Xml;
using System.Text;
using System.IO;

namespace NetvisorWSClient.communication.controller
{

    public class NetvisorApplicationAccountingBudgetDimensionBudgetRequest
    {




        public string getAccountingBudgetAsXML(NetvisorAccountingBudgetDimensionBudget dimensionBudget)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("AccountingBudgetDimensionBudget");
                withBlock.WriteElementString("method", dimensionBudget.Method);

                foreach (NetvisorAccountingBudgetLockedDimension lockedDimension in dimensionBudget.LockedDimensionList)
                {
                    withBlock.WriteStartElement("LockedDimension");
                    withBlock.WriteElementString("DimensionName", lockedDimension.DimensionName);
                    withBlock.WriteElementString("DimensionItemName", lockedDimension.DimensionItemName);
                    withBlock.WriteEndElement();
                }

                withBlock.WriteStartElement("AccountIdentifier");
                withBlock.WriteElementString("AccountNumber", dimensionBudget.AccountNumber);
                withBlock.WriteElementString("AccountName", dimensionBudget.AccountName);
                withBlock.WriteElementString("AccountGroup", dimensionBudget.AccountGroup);
                withBlock.WriteEndElement();

                foreach (NetvisorAccountingBudgetDimension dimension in dimensionBudget.BudgetDimensionList)
                {
                    withBlock.WriteStartElement("BudgetDimension");

                    withBlock.WriteElementString("DimensionName", dimension.DimensionName);
                    withBlock.WriteElementString("DimensionItemName", dimension.DimensionItemName);

                    foreach (NetvisorAccountingBudgetMonth month in dimension.MonthList)
                    {
                        withBlock.WriteStartElement("BudgetMonth");

                        withBlock.WriteElementString("Sum", month.Sum);
                        withBlock.WriteElementString("VAT", month.VAT);
                        withBlock.WriteElementString("Month", month.Month);
                        withBlock.WriteElementString("Year", month.Year);

                        withBlock.WriteEndElement(); // /BudgetMonth
                    }

                    withBlock.WriteEndElement(); // /BudgetDimension
                }

                withBlock.WriteEndElement(); // /AccountingBudgetDimensionBudget
                withBlock.WriteEndElement(); // /Root

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return streamReader.ReadToEnd();
        }
    }
}
