using Microsoft.VisualBasic;
using System;
using System.Xml;
using System.Text;
using System.IO;

namespace NetvisorWSClient.communication.common
{
    public class NetvisorApplicationOutgoingPaymentRequest
    {
        public string getOutgoingPaymentAsXML(NetvisorOutgoingPayment payment)
        {
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("Payment");

                withBlock.WriteStartElement("BankPaymentMessageType");
                switch (payment.BankPaymentMessageType)
                {
                    case NetvisorOutgoingPayment.BankPaymentMessageTypes.FINNISH_REFERENCE:
                        {
                            withBlock.WriteString("FinnishReference");
                            break;
                        }

                    case NetvisorOutgoingPayment.BankPaymentMessageTypes.FREETEXT:
                        {
                            withBlock.WriteString("FreeText");
                            break;
                        }

                    default:
                        {
                            throw new ApplicationException("Invalid outgoing payment BankPaymentMessageType: " + payment.BankPaymentMessageType);
                            break;
                        }
                }
                withBlock.WriteEndElement(); // /BankPaymentMessageType

                withBlock.WriteStartElement("BankPaymentMessage");
                withBlock.WriteString(payment.BankPaymentMessage);
                withBlock.WriteEndElement(); // /BankPaymentMessage

                withBlock.WriteStartElement("Recipient");

                withBlock.WriteStartElement("OrganizationCode");
                withBlock.WriteString(payment.RecipientOrganizationCode.getHumanReadableFormat());
                withBlock.WriteEndElement(); // /OrganizationCode

                withBlock.WriteStartElement("Name");
                withBlock.WriteString(payment.RecipientName);
                withBlock.WriteEndElement(); // /Name

                withBlock.WriteEndElement(); // /Recipient

                withBlock.WriteStartElement("SourceBankAccountNumber");
                withBlock.WriteString(payment.SourceBankAccountNumber.getHumanReadableLongFormat());
                withBlock.WriteEndElement(); // /SourceBankAccountNumber

                withBlock.WriteStartElement("DestinationBankAccount");

                withBlock.WriteStartElement("BankName");
                withBlock.WriteString(payment.DestinationBankName);
                withBlock.WriteEndElement(); // /BankName

                withBlock.WriteStartElement("BankBranch");
                withBlock.WriteString(payment.DestinationBankBranch);
                withBlock.WriteEndElement(); // /BankBranch 

                withBlock.WriteStartElement("DestinationBankAccountNumber");
                withBlock.WriteString(payment.DestinationBankAccountNumber.getHumanReadableLongFormat());
                withBlock.WriteEndElement(); // /DestinationBankAccountNumber

                withBlock.WriteEndElement(); // /DestinationBankAccount

                withBlock.WriteElementString("DueDate", Strings.Format(payment.DueDate, "yyyy-MM-dd"));

                withBlock.WriteStartElement("Amount");
                withBlock.WriteString(payment.Amount);
                withBlock.WriteEndElement(); // /Amount

                withBlock.WriteEndElement(); // /Payment
                withBlock.WriteEndElement(); // /Root

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return streamReader.ReadToEnd();
        }
    }
}
