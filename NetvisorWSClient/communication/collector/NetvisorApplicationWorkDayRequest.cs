using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Xml;
using System.Text;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.collector
{

    public class NetvisorApplicationWorkDayRequest
    {




        public string getWorkDayAsXML(NetvisorWorkDay workDay)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("WorkDay");

                string dateMethod;

                if (workDay.dateMethod == 0)
                    workDay.dateMethod = NetvisorWorkDay.dateMethods.replace;

                switch (workDay.dateMethod)
                {
                    case NetvisorWorkDay.dateMethods.replace:
                        {
                            dateMethod = "replace";
                            break;
                        }

                    case NetvisorWorkDay.dateMethods.increment:
                        {
                            dateMethod = "increment";
                            break;
                        }

                    default:
                        {
                            throw new ApplicationException("Invalid date method: " + workDay.dateMethod);
                            break;
                        }
                }


                withBlock.WriteStartElement("Date");
                withBlock.WriteAttributeString("format", "ansi");
                withBlock.WriteAttributeString("method", dateMethod);
                withBlock.WriteString(Strings.Format(workDay.date, "yyyy-MM-dd"));
                withBlock.WriteEndElement();

                string employeeIdentifierType;

                switch (workDay.employeeIdentifierType)
                {
                    case NetvisorWorkDay.employeeIdentifierTypes.number:
                        {
                            employeeIdentifierType = "number";
                            break;
                        }

                    case NetvisorWorkDay.employeeIdentifierTypes.personalidentificationnumber:
                        {
                            employeeIdentifierType = "personalidentificationnumber";
                            break;
                        }

                    default:
                        {
                            throw new ApplicationException("Invalid employee identifiertype: " + workDay.employeeIdentifierType);
                            break;
                        }
                }

                string employeeDefaultDimensionHandlingType;

                if (workDay.employeeDefaultDimensionHandlingType == 0)
                    workDay.employeeDefaultDimensionHandlingType = NetvisorWorkDay.employeeDefaultDimensionHandlingTypes.none;

                switch (workDay.employeeDefaultDimensionHandlingType)
                {
                    case NetvisorWorkDay.employeeDefaultDimensionHandlingTypes.none:
                        {
                            employeeDefaultDimensionHandlingType = "none";
                            break;
                        }

                    case NetvisorWorkDay.employeeDefaultDimensionHandlingTypes.usedefault:
                        {
                            employeeDefaultDimensionHandlingType = "usedefault";
                            break;
                        }

                    default:
                        {
                            throw new ApplicationException("Invalid employee defaultdimensionhandlingtype: " + workDay.employeeDefaultDimensionHandlingType);
                            break;
                        }
                }

                withBlock.WriteStartElement("EmployeeIdentifier");
                withBlock.WriteAttributeString("type", employeeIdentifierType);
                withBlock.WriteAttributeString("defaultdimensionhandlingtype", employeeDefaultDimensionHandlingType);
                withBlock.WriteString(workDay.employeeIdentifier);
                withBlock.WriteEndElement();

                foreach (NetvisorWorkDayHour workDayHour in workDay.workDayHours)
                {
                    withBlock.WriteStartElement("WorkDayHour");

                    withBlock.WriteElementString("Hours", workDayHour.Hours.ToString());

                    withBlock.WriteStartElement("CollectorRatio");
                    withBlock.WriteAttributeString("type", "number");
                    withBlock.WriteString(workDayHour.CollectorRatioNumber);
                    withBlock.WriteEndElement();

                    string acceptanceStatus = null;

                    switch (workDayHour.AcceptanceStatus)
                    {
                        case NetvisorWorkDayHour.acceptanceStatuses.accepted:
                            {
                                acceptanceStatus = "accepted";
                                break;
                            }

                        case NetvisorWorkDayHour.acceptanceStatuses.confirmed:
                            {
                                acceptanceStatus = "confirmed";
                                break;
                            }

                        default:
                            {
                                throw new ApplicationException("Invalid acceptancestatus: " + workDayHour.AcceptanceStatus);
                                break;
                            }
                    }

                    withBlock.WriteElementString("AcceptanceStatus", acceptanceStatus);
                    withBlock.WriteElementString("Description", workDayHour.Description);

                    if (Strings.Len(workDayHour.CrmProcessIdentifier) > 0)
                    {
                        string billingType = null;

                        if (workDayHour.CrmProcessIdentifierBillingType == 0)
                            workDayHour.CrmProcessIdentifierBillingType = NetvisorWorkDayHour.billingType.unbillable;

                        switch (workDayHour.CrmProcessIdentifierBillingType)
                        {
                            case NetvisorWorkDayHour.billingType.unbillable:
                                {
                                    billingType = "unbillable";
                                    break;
                                }

                            case NetvisorWorkDayHour.billingType.billable:
                                {
                                    billingType = "billable";
                                    break;
                                }

                            default:
                                {
                                    throw new ApplicationException("Invalid crmprocessidentifierbillingtype: " + workDayHour.CrmProcessIdentifierBillingType);
                                    break;
                                }
                        }


                        withBlock.WriteStartElement("CrmProcessIdentifier");
                        withBlock.WriteAttributeString("billingtype", billingType);
                        withBlock.WriteString(workDayHour.CrmProcessIdentifier);
                        withBlock.WriteEndElement();

                        if (Strings.Len(workDayHour.InvoicingProductIdentifier) > 0)
                            withBlock.WriteElementString("InvoicingProductIdentifier", workDayHour.InvoicingProductIdentifier);
                    }


                    foreach (NetvisorDimension dimension in workDayHour.dimensions)
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

                    withBlock.WriteEndElement(); // /WorkDayHour
                }

                withBlock.WriteEndElement(); // /WorkDay
                withBlock.WriteEndElement(); // /Root

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return streamReader.ReadToEnd();
        }
    }
}
