using Microsoft.VisualBasic;
using System.Xml;
using System.Text;
using System.IO;
using NetvisorWSClient.util;

namespace NetvisorWSClient.communication.payroll
{
    public class NetvisorApplicationPayrollAdvanceRequest
    {
        public string getPayrollAdvanceAsXML(NetvisorPayrollAdvance advance)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("PayrollAdvance");

                withBlock.WriteElementString("Description", advance.Description);
                withBlock.WriteStartElement("EmployeeIdentifier");

                if (FinnishPersonalIdentificationNumber.isPersonalIdCorrect(advance.EmployeeIdentifier))
                    withBlock.WriteAttributeString("type", "finnishpersonalidentifier");
                else
                    withBlock.WriteAttributeString("type", "number");

                withBlock.WriteString(advance.EmployeeIdentifier);

                withBlock.WriteEndElement(); // /EmployeeIdentifier

                withBlock.WriteElementString("PaymentDate", Strings.Format(advance.PaymentDate, "yyyy-MM-dd"));
                withBlock.WriteStartElement("AdvanceSum");

                if (advance.AdvancePaymentStatusType == NetvisorPayrollAdvance.advancePaymentTypes.ispaid)
                    withBlock.WriteAttributeString("paymentstatus", "ispaid");
                else
                    withBlock.WriteAttributeString("paymentstatus", "notpaid");

                withBlock.WriteString(advance.AdvanceSum);

                withBlock.WriteEndElement(); // /AdvanceSum

                if (advance.AdvanceType == NetvisorPayrollAdvance.advanceTypes.payroll)
                    withBlock.WriteElementString("PaymentType", "payroll");
                else
                    withBlock.WriteElementString("PaymentType", "tripexpence");


                withBlock.WriteEndElement(); // /PayrollAdvance
                withBlock.WriteEndElement(); // /Root

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return streamReader.ReadToEnd();
        }
    }
}

