using Microsoft.VisualBasic;
using System;
using System.Xml;
using System.Text;
using System.IO;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.collector
{
    public class NetvisorApplicationCollectorTripExpenseRequest
    {
        public string getTripExpenseAsXML(NetvisorCollectorTripExpense tripExpense)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("TripExpense");

                withBlock.WriteElementString("Header", tripExpense.header);
                withBlock.WriteElementString("Description", tripExpense.Description);



                // CustomLines / Muut kulurivit
                if (tripExpense.customLines.Count > 0)
                {
                    withBlock.WriteStartElement("CustomLines");

                    foreach (NetvisorCollectorTripExpenseCustomLine customLine in tripExpense.customLines)
                    {
                        withBlock.WriteStartElement("CustomLine");

                        withBlock.WriteStartElement("EmployeeIdentifier");

                        if (customLine.employeeIdentifierType == NetvisorCollectorTripExpenseCustomLine.employeeIdentifierTypes.finnishPersonalIdentifier)
                            withBlock.WriteAttributeString("type", "finnishpersonalidentifier");
                        else
                            withBlock.WriteAttributeString("type", "number");

                        withBlock.WriteString(customLine.employeeIdentifier);
                        withBlock.WriteEndElement(); // /EmployeeIdentifier

                        withBlock.WriteStartElement("Ratio");
                        withBlock.WriteAttributeString("type", "name");
                        withBlock.WriteString(customLine.ratio);
                        withBlock.WriteEndElement(); // /Ratio

                        withBlock.WriteElementString("Amount", customLine.amount);
                        withBlock.WriteElementString("CustomLineUnitPrice", customLine.customLineUnitPrice);
                        if (Strings.Len(customLine.vatPercentage) > 0)
                            withBlock.WriteElementString("VatPercentage", customLine.vatPercentage);
                        withBlock.WriteElementString("LineDescription", customLine.lineDescription);

                        if (Strings.Len(customLine.CRMProcessIdentifier) > 0)
                            withBlock.WriteElementString("CRMProcessIdentifier", customLine.CRMProcessIdentifier);

                        if (Strings.Len(customLine.customerIdentifier) > 0)
                        {
                            withBlock.WriteStartElement("CustomerIdentifier");

                            if (customLine.customerIdentifierType == NetvisorCollectorTripExpenseCustomLine.customerIdentifierTypes.netvisor)
                                withBlock.WriteAttributeString("type", "netvisor");
                            else
                                withBlock.WriteAttributeString("type", "customer");

                            withBlock.WriteString(customLine.customerIdentifier);

                            withBlock.WriteEndElement(); // /CustomerIdentifier
                        }

                        if (Strings.Len(customLine.ExpenseAccountNumber) > 0)
                            withBlock.WriteElementString("ExpenseAccountNumber", customLine.ExpenseAccountNumber);

                        if (Enum.IsDefined(typeof(NetvisorCollectorTripExpenseCustomLine.LineStatuses), customLine.lineStatus))
                            withBlock.WriteElementString("LineStatus", customLine.lineStatus.ToString());

                        if (customLine.dimensions.Count > 0)
                        {
                            foreach (NetvisorDimension dimension in customLine.dimensions)
                            {
                                withBlock.WriteStartElement("Dimension");
                                withBlock.WriteElementString("DimensionName", dimension.dimensionName);
                                withBlock.WriteStartElement("DimensionItem");

                                if (dimension.dimensionDetailFatherID > 0)
                                    withBlock.WriteAttributeString("fatherid", dimension.dimensionDetailFatherID);

                                if (Strings.Len(dimension.integrationDimensionDetailGuid) > 0)
                                    withBlock.WriteAttributeString("integrationdimensiondetailguid", dimension.integrationDimensionDetailGuid);

                                withBlock.WriteString(dimension.dimensionDetail);
                                withBlock.WriteEndElement(); // / DimensionItem
                                withBlock.WriteEndElement(); // / Dimension
                            }
                        }

                        if (customLine.attachments.Count > 0)
                        {
                            withBlock.WriteStartElement("TripExpenseAttachments");

                            foreach (NetvisorAttachment attachment in customLine.attachments)
                            {
                                withBlock.WriteStartElement("TripExpenseAttachment");

                                withBlock.WriteElementString("MimeType", attachment.mimeType);
                                withBlock.WriteElementString("AttachmentDescription", attachment.description);
                                withBlock.WriteElementString("FileName", attachment.fileName);
                                withBlock.WriteElementString("DocumentData", Convert.ToBase64String(attachment.attachmentData));

                                withBlock.WriteEndElement(); // /TripExpenseAttachment
                            }

                            withBlock.WriteEndElement(); // /TripExpenseAttachments
                        }

                        withBlock.WriteEndElement(); // /CustomLine
                    }

                    withBlock.WriteEndElement(); // /CustomLines
                }



                // TravelLines/Kilometrikorvaukset
                if (tripExpense.travelLines.Count > 0)
                {
                    withBlock.WriteStartElement("TravelLines");

                    foreach (NetvisorCollectorTripExpenseTravelLine travelLine in tripExpense.travelLines)
                    {
                        withBlock.WriteStartElement("TravelLine");

                        withBlock.WriteStartElement("EmployeeIdentifier");

                        if (travelLine.employeeIdentifierType == NetvisorCollectorTripExpenseTravelLine.employeeIdentifierTypes.finnishPersonalIdentifier)
                            withBlock.WriteAttributeString("type", "finnishpersonalidentifier");
                        else
                            withBlock.WriteAttributeString("type", "number");

                        withBlock.WriteString(travelLine.employeeIdentifier);
                        withBlock.WriteEndElement(); // /EmployeeIdentifier

                        withBlock.WriteStartElement("TravelType");

                        switch (travelLine.travelType)
                        {
                            case NetvisorCollectorTripExpenseTravelLine.travelTypes.CAR:
                                {
                                    withBlock.WriteString("car");
                                    break;
                                }

                            case NetvisorCollectorTripExpenseTravelLine.travelTypes.CAR_WITH_TRAILER:
                                {
                                    withBlock.WriteString("car_with_trailer");
                                    break;
                                }

                            case NetvisorCollectorTripExpenseTravelLine.travelTypes.CAR_WITH_CARAVAN:
                                {
                                    withBlock.WriteString("car_with_caravan");
                                    break;
                                }

                            case NetvisorCollectorTripExpenseTravelLine.travelTypes.CAR_WITH_HEAVY_CARGO:
                                {
                                    withBlock.WriteString("car_with_heavy_cargo");
                                    break;
                                }

                            case NetvisorCollectorTripExpenseTravelLine.travelTypes.CAR_WITH_BIG_MACHINERY:
                                {
                                    withBlock.WriteString("car_with_big_machinery");
                                    break;
                                }

                            case NetvisorCollectorTripExpenseTravelLine.travelTypes.CAR_WITH_DOG:
                                {
                                    withBlock.WriteString("car_with_dog");
                                    break;
                                }

                            case NetvisorCollectorTripExpenseTravelLine.travelTypes.CAR_TRAVEL_IN_ROUGH_TERRAIN:
                                {
                                    withBlock.WriteString("car_travel_in_rough_terrain");
                                    break;
                                }

                            case NetvisorCollectorTripExpenseTravelLine.travelTypes.MOTORBOAT_MAX_50HP:
                                {
                                    withBlock.WriteString("motorboat_max_50hp");
                                    break;
                                }

                            case NetvisorCollectorTripExpenseTravelLine.travelTypes.MOTORBOAT_OVER_50HP:
                                {
                                    withBlock.WriteString("motorboat_over_50hp");
                                    break;
                                }

                            case NetvisorCollectorTripExpenseTravelLine.travelTypes.SNOWMOBILE:
                                {
                                    withBlock.WriteString("snowmobile");
                                    break;
                                }

                            case NetvisorCollectorTripExpenseTravelLine.travelTypes.ATV:
                                {
                                    withBlock.WriteString("atv");
                                    break;
                                }

                            case NetvisorCollectorTripExpenseTravelLine.travelTypes.MOTORBIKE:
                                {
                                    withBlock.WriteString("motorbike");
                                    break;
                                }

                            case NetvisorCollectorTripExpenseTravelLine.travelTypes.MOPED:
                                {
                                    withBlock.WriteString("moped");
                                    break;
                                }

                            case NetvisorCollectorTripExpenseTravelLine.travelTypes.OTHER:
                                {
                                    withBlock.WriteString("other");
                                    break;
                                }

                            default:
                                {
                                    throw new InvalidDataException("Unknow travel type: " + travelLine.travelType);
                                    break;
                                }
                        }

                        withBlock.WriteEndElement(); // /TravelType

                        withBlock.WriteElementString("PassengerAmount", travelLine.passangerAmount);
                        withBlock.WriteElementString("KilometerAmount", travelLine.kilometerAmount);

                        if (travelLine.unitPrice != 0)
                            withBlock.WriteElementString("UnitPrice", travelLine.unitPrice);

                        withBlock.WriteElementString("LineDescription", travelLine.lineDescription);
                        withBlock.WriteElementString("TravelDate", travelLine.travelDate);
                        withBlock.WriteElementString("RouteDescription", travelLine.routeDescription);

                        if (Strings.Len(travelLine.CRMProcessIdentifier) > 0)
                            withBlock.WriteElementString("CRMProcessIdentifier", travelLine.CRMProcessIdentifier);

                        if (Strings.Len(travelLine.customerIdentifier) > 0)
                        {
                            withBlock.WriteStartElement("CustomerIdentifier");

                            if (travelLine.customerIdentifierType == NetvisorCollectorTripExpenseTravelLine.customerIdentifierTypes.netvisor)
                                withBlock.WriteAttributeString("type", "netvisor");
                            else
                                withBlock.WriteAttributeString("type", "customer");

                            withBlock.WriteString(travelLine.customerIdentifier);

                            withBlock.WriteEndElement(); // /CustomerIdentifier
                        }

                        if (Enum.IsDefined(typeof(NetvisorCollectorTripExpenseTravelLine.LineStatuses), travelLine.lineStatus))
                            withBlock.WriteElementString("LineStatus", travelLine.lineStatus.ToString());


                        if (travelLine.dimensions.Count > 0)
                        {
                            foreach (NetvisorDimension dimension in travelLine.dimensions)
                            {
                                withBlock.WriteStartElement("Dimension");
                                withBlock.WriteElementString("DimensionName", dimension.dimensionName);
                                withBlock.WriteStartElement("DimensionItem");

                                if (dimension.dimensionDetailFatherID > 0)
                                    withBlock.WriteAttributeString("fatherid", dimension.dimensionDetailFatherID);

                                if (Strings.Len(dimension.integrationDimensionDetailGuid) > 0)
                                    withBlock.WriteAttributeString("integrationdimensiondetailguid", dimension.integrationDimensionDetailGuid);

                                withBlock.WriteString(dimension.dimensionDetail);
                                withBlock.WriteEndElement(); // / DimensionItem
                                withBlock.WriteEndElement(); // / Dimension
                            }
                        }

                        if (travelLine.attachments.Count > 0)
                        {
                            withBlock.WriteStartElement("TripExpenseAttachments");

                            foreach (NetvisorAttachment attachment in travelLine.attachments)
                            {
                                withBlock.WriteStartElement("TripExpenseAttachment");

                                withBlock.WriteElementString("MimeType", attachment.mimeType);
                                withBlock.WriteElementString("AttachmentDescription", attachment.description);
                                withBlock.WriteElementString("FileName", attachment.fileName);
                                withBlock.WriteElementString("DocumentData", Convert.ToBase64String(attachment.attachmentData));

                                withBlock.WriteEndElement(); // /TripExpenseAttachment
                            }

                            withBlock.WriteEndElement(); // /TripExpenseAttachments
                        }

                        withBlock.WriteEndElement(); // /TravelLine
                    }

                    withBlock.WriteEndElement(); // /TravelLines
                }



                // DailyCompensationLines/DailyCompensationLines
                if (tripExpense.dailyCompensationLines.Count > 0)
                {
                    withBlock.WriteStartElement("DailyCompensationLines");

                    foreach (NetvisorCollectorTripExpenseDailyCompensationLine compensationLine in tripExpense.dailyCompensationLines)
                    {
                        withBlock.WriteStartElement("DailyCompensationLine");

                        withBlock.WriteStartElement("EmployeeIdentifier");

                        if (compensationLine.employeeIdentifierType == NetvisorCollectorTripExpenseDailyCompensationLine.employeeIdentifierTypes.finnishPersonalIdentifier)
                            withBlock.WriteAttributeString("type", "finnishpersonalidentifier");
                        else
                            withBlock.WriteAttributeString("type", "number");

                        withBlock.WriteString(compensationLine.employeeIdentifier);
                        withBlock.WriteEndElement(); // /EmployeeIdentifier

                        withBlock.WriteStartElement("CompensationType");

                        switch (compensationLine.compensationType)
                        {
                            case NetvisorCollectorTripExpenseDailyCompensationLine.compensationTypes.domesticFull:
                                {
                                    withBlock.WriteString("domesticfull");
                                    break;
                                }

                            case NetvisorCollectorTripExpenseDailyCompensationLine.compensationTypes.domesticHalf:
                                {
                                    withBlock.WriteString("domestichalf");
                                    break;
                                }

                            case NetvisorCollectorTripExpenseDailyCompensationLine.compensationTypes.foreign:
                                {
                                    withBlock.WriteString("foreign");
                                    break;
                                }

                            default:
                                {
                                    throw new InvalidDataException("Unknow compensation type: " + compensationLine.compensationType);
                                    break;
                                }
                        }

                        withBlock.WriteEndElement(); // /CompensationType

                        withBlock.WriteElementString("Amount", compensationLine.amount);

                        if (compensationLine.unitPrice != 0)
                            withBlock.WriteElementString("UnitPrice", compensationLine.UnitPrice);

                        withBlock.WriteElementString("LineDescription", compensationLine.lineDescription);
                        withBlock.WriteElementString("TimeOfDeparture", compensationLine.timeOfDeparture);
                        withBlock.WriteElementString("ReturnTime", compensationLine.returnTime);

                        if (Strings.Len(compensationLine.CRMProcessIdentifier) > 0)
                            withBlock.WriteElementString("CRMProcessIdentifier", compensationLine.CRMProcessIdentifier);

                        if (Strings.Len(compensationLine.customerIdentifier) > 0)
                        {
                            withBlock.WriteStartElement("CustomerIdentifier");

                            if (compensationLine.customerIdentifierType == NetvisorCollectorTripExpenseDailyCompensationLine.customerIdentifierTypes.netvisor)
                                withBlock.WriteAttributeString("type", "netvisor");
                            else
                                withBlock.WriteAttributeString("type", "customer");

                            withBlock.WriteString(compensationLine.customerIdentifier);

                            withBlock.WriteEndElement(); // /CustomerIdentifier
                        }

                        if (Enum.IsDefined(typeof(NetvisorCollectorTripExpenseDailyCompensationLine.LineStatuses), compensationLine.lineStatus))
                            withBlock.WriteElementString("LineStatus", compensationLine.lineStatus.ToString());

                        if (compensationLine.dimensions.Count > 0)
                        {
                            foreach (NetvisorDimension dimension in compensationLine.dimensions)
                            {
                                withBlock.WriteStartElement("Dimension");
                                withBlock.WriteElementString("DimensionName", dimension.dimensionName);
                                withBlock.WriteStartElement("DimensionItem");

                                if (dimension.dimensionDetailFatherID > 0)
                                    withBlock.WriteAttributeString("fatherid", dimension.dimensionDetailFatherID);

                                if (Strings.Len(dimension.integrationDimensionDetailGuid) > 0)
                                    withBlock.WriteAttributeString("integrationdimensiondetailguid", dimension.integrationDimensionDetailGuid);

                                withBlock.WriteString(dimension.dimensionDetail);
                                withBlock.WriteEndElement(); // / DimensionItem
                                withBlock.WriteEndElement(); // / Dimension
                            }
                        }

                        if (compensationLine.attachments.Count > 0)
                        {
                            withBlock.WriteStartElement("TripExpenseAttachments");

                            foreach (NetvisorAttachment attachment in compensationLine.attachments)
                            {
                                withBlock.WriteStartElement("TripExpenseAttachment");

                                withBlock.WriteElementString("MimeType", attachment.mimeType);
                                withBlock.WriteElementString("AttachmentDescription", attachment.description);
                                withBlock.WriteElementString("FileName", attachment.fileName);
                                withBlock.WriteElementString("DocumentData", Convert.ToBase64String(attachment.attachmentData));

                                withBlock.WriteEndElement(); // /TripExpenseAttachment
                            }

                            withBlock.WriteEndElement(); // /TripExpenseAttachments
                        }

                        withBlock.WriteEndElement(); // /DailyCompensationLine
                    }

                    withBlock.WriteEndElement(); // /DailyCompensationLines
                }

                withBlock.WriteEndElement(); // /TripExpense
                withBlock.WriteEndElement(); // /Root

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return streamReader.ReadToEnd();
        }
    }
}
