using Microsoft.VisualBasic;
using System;
using System.Xml;
using System.Text;
using System.IO;

namespace NetvisorWSClient.communication.sales
{
    public class NetvisorApplicationSalesPaymentRequest
    {
        public string getSalesPaymentAsXML(NetvisorSalesPayment payment)
        {
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("SalesPayment");

                withBlock.WriteStartElement("Sum");
                withBlock.WriteAttributeString("currency", payment.currency);
                withBlock.WriteString(payment.sum);
                withBlock.WriteEndElement(); // /Sum

                withBlock.WriteElementString("PaymentDate", Strings.Format(payment.paymentDate, "yyyy-MM-dd"));

                string targetIdentifierType;
                switch (payment.targetIdentifierType)
                {
                    case NetvisorSalesPayment.targetIdentifierTypes.invoiceId:
                        {
                            targetIdentifierType = "netvisor";
                            break;
                        }

                    case NetvisorSalesPayment.targetIdentifierTypes.invoiceNumber:
                        {
                            targetIdentifierType = "invoicenumber";
                            break;
                        }

                    case NetvisorSalesPayment.targetIdentifierTypes.invoiceReferenceNumber:
                        {
                            targetIdentifierType = "reference";
                            break;
                        }

                    default:
                        {
                            throw new ApplicationException("Invalid salespayment targetidentifiertype: " + payment.targetIdentifierType);
                            break;
                        }
                }

                string targetType = "";
                switch (payment.targetType)
                {
                    case NetvisorSalesPayment.targetTypes.order:
                        {
                            targetType = "order";
                            break;
                        }

                    default:
                        {
                            targetType = "invoice";
                            break;
                        }
                }

                withBlock.WriteStartElement("TargetIdentifier");
                withBlock.WriteAttributeString("type", targetIdentifierType);
                withBlock.WriteAttributeString("targettype", targetType);
                withBlock.WriteString(payment.targetIdentifier);
                withBlock.WriteEndElement(); // /TargetIdentifier

                withBlock.WriteElementString("SourceName", payment.sourceName);

                string paymentMethodType;
                switch (payment.paymentMethodType)
                {
                    case NetvisorSalesPayment.paymentMethodTypes.alternative:
                        {
                            paymentMethodType = "alternative";
                            break;
                        }

                    case NetvisorSalesPayment.paymentMethodTypes.bankaccount:
                        {
                            paymentMethodType = "bankaccount";
                            break;
                        }

                    default:
                        {
                            throw new ApplicationException("Unknow paymentMethodType: " + payment.paymentMethodType);
                            break;
                        }
                }

                withBlock.WriteStartElement("PaymentMethod");
                withBlock.WriteAttributeString("type", paymentMethodType);

                if (payment.doOverrideAccountingAccountNumber)
                    withBlock.WriteAttributeString("overrideaccountingaccountnumber", payment.overrideAccountingAccountNumber);

                if (payment.doOverrideSalesRecivablesAccountNumber)
                    withBlock.WriteAttributeString("overridesalesreceivableaccountnumber", payment.overrideSalesReceivablesAccountNumber);

                withBlock.WriteString(payment.paymentMethod);
                withBlock.WriteEndElement(); // /PaymentMethod

                withBlock.WriteEndElement(); // /SalesPayment
                withBlock.WriteEndElement(); // /Root

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return streamReader.ReadToEnd();
        }
    }
}
