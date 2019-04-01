using System.Collections;
using System.Xml;

namespace NetvisorWSClient.communication.sales
{
    public class NetvisorApplicationCustomerListResponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationCustomerListResponse(string responseData) : base(responseData)
        {
        }

        public ArrayList getCustomerList()
        {
            ArrayList customerList = new ArrayList();
            XmlDocument customerListDocument = new XmlDocument();

            customerListDocument.LoadXml(base.responseData);

            foreach (XmlNode customerNode in customerListDocument.SelectNodes("/Root/Customerlist/Customer"))
            {
                NetvisorCustomerListCustomer customerListCustomer = new NetvisorCustomerListCustomer();

                {
                    var withBlock = customerListCustomer;
                    withBlock.netvisorKey = System.Convert.ToInt32(customerNode.SelectSingleNode("Netvisorkey").InnerText);
                    withBlock.name = System.Convert.ToString(customerNode.SelectSingleNode("Name").InnerText);
                    withBlock.code = System.Convert.ToString(customerNode.SelectSingleNode("Code").InnerText);
                    withBlock.organisationIdentifier = System.Convert.ToString(customerNode.SelectSingleNode("OrganisationIdentifier").InnerText);
                    withBlock.uri = System.Convert.ToString(customerNode.SelectSingleNode("Uri").InnerText);
                }

                customerList.Add(customerListCustomer);
            }

            return customerList;
        }
    }
}
