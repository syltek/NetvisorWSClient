using Microsoft.VisualBasic;
using System;
using System.Xml;
using System.Text;
using System.IO;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.controller
{

    public class NetvisorApplicationAccountingBudgetRequest
    {




        public string getAccountingBudgetAsXML(NetvisorAccountingBudget budget)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("AccountingBudget");

                string ratioType;

                switch (budget.ratioType)
                {
                    case NetvisorAccountingBudget.ratioTypes.accountNumber:
                        {
                            ratioType = "account";
                            break;
                        }

                    default:
                        {
                            throw new ApplicationException("Invalid ratiotype: " + budget.ratioType);
                            break;
                        }
                }

                withBlock.WriteStartElement("Ratio");
                withBlock.WriteAttributeString("type", ratioType);
                withBlock.WriteString(budget.ratio);
                withBlock.WriteEndElement();

                withBlock.WriteElementString("Sum", budget.sum);
                withBlock.WriteElementString("Year", budget.year);
                withBlock.WriteElementString("Month", budget.month);
                withBlock.WriteElementString("Version", budget.budgetVersion);
                withBlock.WriteElementString("VatClass", budget.vatClass);

                withBlock.WriteStartElement("Combinations");

                foreach (NetvisorAccountingBudgetCombination combination in budget.combinations)
                {
                    withBlock.WriteStartElement("Combination");

                    withBlock.WriteElementString("CombinationSum", combination.combinationSum);

                    foreach (NetvisorDimension dimension in combination.dimensions)
                        dimension.writeDimensionElement(ref xmlWriter);

                    withBlock.WriteEndElement(); // /Combination
                }

                withBlock.WriteEndElement(); // /Combinations

                withBlock.WriteEndElement(); // /AccountingBudget
                withBlock.WriteEndElement(); // /Root

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return streamReader.ReadToEnd();
        }
    }
}
