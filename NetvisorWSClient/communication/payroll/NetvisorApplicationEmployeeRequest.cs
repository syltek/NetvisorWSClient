using Microsoft.VisualBasic;
using System.Xml;
using System.Text;
using System.IO;

namespace NetvisorWSClient.communication.payroll
{
    public class NetvisorApplicationEmployeeRequest
    {
        public const string PARAMETER_METHOD = "method";
        public const string PARAMETER_METHOD_ADD = "add";
        public const string PARAMETER_METHOD_EDIT = "edit";

        public string getEmployeeAsXML(NetvisorEmployee employee)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("Employee");

                withBlock.WriteStartElement("EmployeeBaseInformation");

                if (Strings.Len(employee.Employeeidentifier) > 0)
                    withBlock.WriteElementString("employeeidentifier", employee.Employeeidentifier);

                if (Strings.Len(employee.FirstName) > 0)
                    withBlock.WriteElementString("FirstName", employee.FirstName);

                if (Strings.Len(employee.LastName) > 0)
                    withBlock.WriteElementString("LastName", employee.LastName);

                if (Strings.Len(employee.PhoneNumber) > 0)
                    withBlock.WriteElementString("PhoneNumber", employee.PhoneNumber);

                if (Strings.Len(employee.Email) > 0)
                    withBlock.WriteElementString("Email", employee.Email);

                withBlock.WriteEndElement();

                withBlock.WriteStartElement("EmployeePayrollInformation");

                if (Strings.Len(employee.StreetAddress) > 0)
                    withBlock.WriteElementString("StreetAddress", employee.StreetAddress);

                if (Strings.Len(employee.PostNumber) > 0)
                    withBlock.WriteElementString("PostNumber", employee.PostNumber);

                if (Strings.Len(employee.City) > 0)
                    withBlock.WriteElementString("City", employee.City);

                if (Strings.Len(employee.Municipality) > 0)
                    withBlock.WriteElementString("Municipality", employee.Municipality);

                if (Strings.Len(employee.Country) > 0)
                    withBlock.WriteElementString("Country", employee.Country);

                if (Strings.Len(employee.Nationality) > 0)
                    withBlock.WriteElementString("Nationality", employee.Nationality);

                if (Strings.Len(employee.Language) > 0)
                    withBlock.WriteElementString("Language", employee.Language);

                if (employee.EmployeeNumber > -1)
                    withBlock.WriteElementString("EmployeeNumber", employee.EmployeeNumber.ToString());

                if (Strings.Len(employee.Profession) > 0)
                    withBlock.WriteElementString("Profession", employee.Profession);

                if (Strings.Len(employee.JobBeginDate) > 0)
                {
                    withBlock.WriteStartElement("JobBeginDate");
                    withBlock.WriteAttributeString("format", "ansi");
                    withBlock.WriteString(Strings.Format(employee.JobBeginDate, "yyyy-MM-dd"));
                    withBlock.WriteEndElement();
                }

                if (Strings.Len(employee.Payrollrulegroupname) > 0)
                    withBlock.WriteElementString("PayrollRuleGroupName", employee.Payrollrulegroupname);

                if (Strings.Len(employee.Bankaccountnumber) > 0)
                    withBlock.WriteElementString("BankAccountNumber", employee.Bankaccountnumber);

                if (Strings.Len(employee.BankIdentificationCode) > 0)
                    withBlock.WriteElementString("BankIdentificationCode", employee.BankIdentificationCode);

                if (employee.Accountingaccountnumber > -1)
                    withBlock.WriteElementString("AccountingAccountNumber", employee.Accountingaccountnumber.ToString());

                withBlock.WriteEndElement();

                withBlock.WriteEndElement();
                withBlock.WriteEndElement();

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return streamReader.ReadToEnd();
        }
    }
}
