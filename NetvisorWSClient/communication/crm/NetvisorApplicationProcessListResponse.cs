using Microsoft.VisualBasic;
using System.Collections;
using System.Xml;
using NetvisorWSClient.communication.sales;

namespace NetvisorWSClient.communication.crm
{
    public class NetvisorApplicationProcessListResponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationProcessListResponse(string responseData) : base(responseData)
        {
        }

        public ArrayList getProcessList()
        {
            ArrayList processList = new ArrayList();
            XmlDocument processListDocument = new XmlDocument();
            string netvisorKey;

            processListDocument.LoadXml(base.responseData);

            foreach (XmlNode processNode in processListDocument.SelectNodes("/Root/Processes/Process"))
            {
                NetvisorProcessListProcess processListProcess = new NetvisorProcessListProcess();

                {
                    var withBlock = processListProcess;
                    withBlock.NetvisorKey = System.Convert.ToInt32(processNode.Attributes["netvisorKey"].Value);
                    withBlock.Duedate = System.Convert.ToDateTime(processNode.SelectSingleNode("DueDate").InnerText);
                    withBlock.IsClosed = System.Convert.ToBoolean(processNode.SelectSingleNode("IsClosed").InnerText);
                    withBlock.ProcessIdentifier = System.Convert.ToString(processNode.SelectSingleNode("ProcessIdentifier").InnerText);
                    withBlock.Name = System.Convert.ToString(processNode.SelectSingleNode("ProcessName").InnerText);

                    NetvisorProcessTemplate template = new NetvisorProcessTemplate();

                    netvisorKey = processNode.SelectSingleNode("ProcessTemplate").Attributes["netvisorKey"].Value;

                    if (Strings.Len(netvisorKey) > 0)
                        template.netvisorKey = System.Convert.ToInt32(netvisorKey);

                    template.Name = System.Convert.ToString(processNode.SelectSingleNode("ProcessTemplate").InnerText);
                    withBlock.ProcessTemplate = template;

                    NetvisorCustomer customer = new NetvisorCustomer();

                    netvisorKey = processNode.SelectSingleNode("Customer").Attributes["netvisorKey"].Value;

                    if (Strings.Len(netvisorKey) > 0)
                        customer.netvisorKey = System.Convert.ToInt32(netvisorKey);

                    customer.Name = System.Convert.ToString(processNode.SelectSingleNode("Customer").InnerText);
                    withBlock.Customer = customer;

                    withBlock.Description = System.Convert.ToString(processNode.SelectSingleNode("ProcessDescription").InnerText);
                    withBlock.CurrentProcessStageName = System.Convert.ToString(processNode.SelectSingleNode("CurrentProcessStageName").InnerText);
                }

                processList.Add(processListProcess);
            }

            return processList;
        }
    }
}
