using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Xml;
using System.Text;
using NetvisorWSClient.util;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.payroll
{
    public class NetvisorApplicationPayrollPaycheckBatchRequest
    {
        public string getPaycheckBatchAsXML(NetvisorPayrollPaycheckBatch batch)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("PayrollPaycheckBatch");

                string employeeIdentifierType;
                string employeeIdentifier;
                switch (batch.employeeIdentifierType)
                {
                    case NetvisorPayrollPaycheckBatch.employeeIdentifierTypes.employeeNumber:
                        {
                            employeeIdentifierType = NetvisorPayrollPaycheckBatch.IDENTIFIER_EMPLOYEE_NUMBER;
                            employeeIdentifier = System.Convert.ToInt32(batch.employeeIdentifier);
                            break;
                        }

                    case NetvisorPayrollPaycheckBatch.employeeIdentifierTypes.finnishPersonalIdentifier:
                        {
                            employeeIdentifierType = NetvisorPayrollPaycheckBatch.IDENTIFIER_FINNISH_PERSONAL_IDENTIFIER;
                            employeeIdentifier = ((FinnishPersonalIdentificationNumber)batch.employeeIdentifier).getHumanReadableLongFormat();
                            break;
                        }

                    default:
                        {
                            throw new ApplicationException("Invalid employee identifiertype: " + batch.employeeIdentifierType);
                            break;
                        }
                }

                withBlock.WriteStartElement("EmployeeIdentifier");
                withBlock.WriteAttributeString("type", employeeIdentifierType);
                withBlock.WriteString(employeeIdentifier);
                withBlock.WriteEndElement(); // /EmployeeIdentifier

                withBlock.WriteStartElement("RuleGroupPeriodStart");
                withBlock.WriteAttributeString("format", "ansi");
                withBlock.WriteString(Strings.Format(batch.ruleGroupPeriodStart, "yyyy-MM-dd"));
                withBlock.WriteEndElement(); // /RuleGroupPeriodStart

                withBlock.WriteStartElement("RuleGroupPeriodEnd");
                withBlock.WriteAttributeString("format", "ansi");
                withBlock.WriteString(Strings.Format(batch.ruleGroupPeriodEnd, "yyyy-MM-dd"));
                withBlock.WriteEndElement(); // /RuleGroupPeriodEnd

                withBlock.WriteElementString("FreeTextBeforeLines", batch.freeTextBeforeLines);
                withBlock.WriteElementString("FreeTextAfterLines", batch.freeTextAfterLines);

                if (batch.dueDate > DateTime.MinValue)
                {
                    withBlock.WriteStartElement("DueDate");
                    withBlock.WriteAttributeString("format", "ansi");
                    withBlock.WriteString(Strings.Format(batch.dueDate, "yyyy-MM-dd"));
                    withBlock.WriteEndElement(); // /RuleGroupPeriodStart
                }

                if (batch.valueDate > DateTime.MinValue)
                {
                    withBlock.WriteStartElement("ValueDate");
                    withBlock.WriteAttributeString("format", "ansi");
                    withBlock.WriteString(Strings.Format(batch.valueDate, "yyyy-MM-dd"));
                    withBlock.WriteEndElement(); // /RuleGroupPeriodStart
                }

                foreach (NetvisorPayrollPaycheckBatchLine line in batch.batchLines)
                {
                    withBlock.WriteStartElement("PayrollPaycheckBatchLine");

                    string ratioIdentifierType;
                    switch (line.payrollRatioIdentifierType)
                    {
                        case NetvisorPayrollPaycheckBatchLine.payrollRatioIdentifierTypes.rationumber:
                            {
                                ratioIdentifierType = NetvisorPayrollPaycheckBatchLine.RATIO_IDENTIFIER_RATIO_NUMBER;
                                break;
                            }

                        default:
                            {
                                throw new ApplicationException("Invalid payroll ratio identifier type: " + line.payrollRatioIdentifierType);
                                break;
                            }
                    }

                    withBlock.WriteStartElement("PayrollRatioIdentifier");
                    withBlock.WriteAttributeString("type", ratioIdentifierType);
                    withBlock.WriteString(line.payrollRatioIdentifier);
                    withBlock.WriteEndElement(); // /RuleGroupPeriodEnd

                    withBlock.WriteElementString("Units", line.units);
                    withBlock.WriteElementString("UnitAmount", line.unitAmount);
                    withBlock.WriteElementString("LineSum", line.lineSum);
                    withBlock.WriteElementString("LineDescription", line.description);

                    if (line.batchLineDimensions.Count > 0)
                    {
                        foreach (NetvisorDimension dimension in line.batchLineDimensions)
                        {
                            withBlock.WriteStartElement("Dimension");
                            withBlock.WriteElementString("DimensionName", dimension.dimensionName);
                            withBlock.WriteElementString("DimensionItem", dimension.dimensionDetail);
                            withBlock.WriteEndElement(); // /Dimension
                        }
                    }


                    withBlock.WriteEndElement(); // / PayrollPaycheckBatchLine
                }

                withBlock.WriteEndElement(); // / PayrollPaycheckBatch
                withBlock.WriteEndElement(); // /Root

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return streamReader.ReadToEnd();
        }
    }
}
