using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace NetvisorWSClient.communication.payroll
{
    public class NetvisorApplicationPaysliplistResponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationPaysliplistResponse(string responseData) : base(responseData)
        {
        }

        public PaysliplistXml getPayslipList()
        {
            XmlDocument paysliplistDocument = new XmlDocument();

            try
            {
                paysliplistDocument.LoadXml(base.responseData);
            }
            catch (XmlException ex)
            {
                throw new FormatException("Loading of XML failed.", ex);
            }

            StringReader reader = new StringReader(paysliplistDocument.InnerXml);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PaysliplistXml));

            PaysliplistXml payslipList = new PaysliplistXml();

            try
            {
                payslipList = xmlSerializer.Deserialize(reader);
            }
            catch (InvalidOperationException ex)
            {
                throw new FormatException("Deserialization of XML failed.", ex);
            }

            return payslipList;
        }
    }
}

