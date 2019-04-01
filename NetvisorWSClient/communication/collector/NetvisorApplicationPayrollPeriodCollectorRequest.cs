using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Xml;
using System.Text;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.collector
{

    public class NetvisorApplicationPayrollPeriodCollectorRequest
    {




        public string getPeriodCollectorAsXML(NetvisorPayrollPeriodCollector periodCollector)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("PayrollPeriodCollector");

                withBlock.WriteStartElement("Date");
                withBlock.WriteAttributeString("format", "ansi");
                withBlock.WriteString(Strings.Format(periodCollector.date, "yyyy-MM-dd"));
                withBlock.WriteEndElement();

                string employeeIdentifierType;

                switch (periodCollector.employeeIdentifierType)
                {
                    case NetvisorPayrollPeriodCollector.employeeIdentifierTypes.number:
                        {
                            employeeIdentifierType = "number";
                            break;
                        }

                    case NetvisorPayrollPeriodCollector.employeeIdentifierTypes.personalidentificationnumber:
                        {
                            employeeIdentifierType = "personalidentificationnumber";
                            break;
                        }

                    default:
                        {
                            throw new ApplicationException("Invalid employee identifiertype: " + periodCollector.employeeIdentifierType);
                        }
                }

                withBlock.WriteStartElement("EmployeeIdentifier");
                withBlock.WriteAttributeString("type", employeeIdentifierType);
                withBlock.WriteString(periodCollector.employeeIdentifier);
                withBlock.WriteEndElement();

                foreach (NetvisorPayrollRatioLine ratioLine in periodCollector.ratioLines)
                {
                    withBlock.WriteStartElement("PayrollRatioLine");

                    withBlock.WriteElementString("Amount", ratioLine.Amount.ToString());

                    withBlock.WriteStartElement("PayrollRatio");
                    withBlock.WriteAttributeString("type", "number");
                    withBlock.WriteString(ratioLine.PayrollRatioNumber);
                    withBlock.WriteEndElement();

                    foreach (NetvisorDimension dimension in ratioLine.dimensions)
                    {
                        withBlock.WriteStartElement("Dimension");
                        withBlock.WriteElementString("DimensionName", dimension.dimensionName);
                        withBlock.WriteStartElement("DimensionItem");

                        if (dimension.dimensionDetailFatherID > 0)
                            withBlock.WriteAttributeString("fatherid", dimension.dimensionDetailFatherID.ToString());

                        withBlock.WriteString(dimension.dimensionDetail);
                        withBlock.WriteEndElement(); // / DimensionItem
                        withBlock.WriteEndElement(); // / Dimension
                    }

                    withBlock.WriteEndElement(); // /PayrollRatioLine
                }

                withBlock.WriteEndElement(); // /PayrollPeriodCollector
                withBlock.WriteEndElement(); // /Root

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return streamReader.ReadToEnd();
        }
    }
}
