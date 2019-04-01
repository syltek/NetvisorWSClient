using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace NetvisorWSClient.communication.payroll
{
    public class NetvisorApplicationGetPayslipResponse : NetvisorApplicationResponse
    {
        public const string FORMAT_PARAMETER = "Format";
        public const string FORMAT_PAYSLIP_XML = "1";
        public const string PAYSLIPID_PARAMETER = "PayslipID";

        public NetvisorApplicationGetPayslipResponse(string responseData) : base(responseData)
        {
        }

        public PayslipContentRoot getPayslip()
        {
            XmlDocument payslipDocument = new XmlDocument();

            try
            {
                payslipDocument.LoadXml(base.responseData);
            }
            catch (XmlException ex)
            {
                throw new FormatException("Loading of XML failed.", ex);
            }


            StringReader reader = new StringReader(payslipDocument.InnerXml);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PayslipContentRoot));

            PayslipContentRoot payslip = new PayslipContentRoot();

            try
            {
                payslip = xmlSerializer.Deserialize(reader);
            }
            catch (InvalidOperationException ex)
            {
                throw new FormatException("Deserialization of XML failed.", ex);
            }

            return payslip;
        }
    }
}

