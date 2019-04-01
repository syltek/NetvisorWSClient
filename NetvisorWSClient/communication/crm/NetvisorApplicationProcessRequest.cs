using Microsoft.VisualBasic;
using System.IO;
using System.Xml;
using System.Text;

namespace NetvisorWSClient.communication.crm
{
    public class NetvisorApplicationProcessRequest
    {
        public string getCRMProcessAsXML(NetvisorProcess process)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("CrmProcess");

                withBlock.WriteElementString("ProcessIdentifier", process.ProcessIdentifier);
                withBlock.WriteElementString("Name", process.Name);
                withBlock.WriteElementString("Description", process.Description);
                withBlock.WriteElementString("ProcessTemplateName", process.ProcessTemplate.Name);
                withBlock.WriteElementString("CustomerIdentifier", process.CustomerIdentifier);

                if (Strings.Len(process.Duedate) > 0)
                {
                    withBlock.WriteStartElement("DueDate");
                    withBlock.WriteAttributeString("format", "ansi");
                    withBlock.WriteString(process.Duedate.ToString("dd-MM-yyyy"));
                    withBlock.WriteEndElement(); // /DueDate
                }

                if (Strings.Len(process.InvoicingStatusIdentifier) > 0)
                    withBlock.WriteElementString("InvoicingStatusIdentifier", process.InvoicingStatusIdentifier);

                if (process.IsClosed)
                    withBlock.WriteElementString("IsClosed", "1");

                withBlock.WriteEndElement(); // / CrmProcess
                withBlock.WriteEndElement(); // /Root

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return streamReader.ReadToEnd();
        }
    }
}
