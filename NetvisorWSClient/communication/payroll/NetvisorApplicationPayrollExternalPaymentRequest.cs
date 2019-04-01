using Microsoft.VisualBasic;
using System.Xml;
using System.Text;
using System.IO;

namespace NetvisorWSClient.communication.payroll
{
    public class NetvisorApplicationPayrollExternalPaymentRequest
    {
        public string getPayrollExternalPaymentAsXML(NetvisorPayrollExternalPayment externalPayment)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("PayrollExternalSalaryPayment");

                withBlock.WriteElementString("Description", externalPayment.Description);

                withBlock.WriteElementString("PaymentDate", Strings.Format(externalPayment.PaymentDate, "yyyy-MM-dd"));
                withBlock.WriteStartElement("ExternalPaymentSum");

                withBlock.WriteString(externalPayment.ExternalPaymentSum);

                withBlock.WriteEndElement(); // /ExternalPaymentSum

                withBlock.WriteElementString("IBAN", externalPayment.IBAN);
                withBlock.WriteElementString("BIC", externalPayment.BIC);

                withBlock.WriteElementString("HETU", externalPayment.HETU);
                withBlock.WriteElementString("Realname", externalPayment.Realname);


                withBlock.WriteEndElement(); // /ExternalPayment
                withBlock.WriteEndElement(); // /Root

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return streamReader.ReadToEnd();
        }
    }
}

