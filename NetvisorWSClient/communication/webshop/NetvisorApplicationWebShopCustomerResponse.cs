using System.Collections;
using System.Xml;

namespace NetvisorWSClient.communication.webshop
{
    public class NetvisorApplicationWebShopCustomerResponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationWebShopCustomerResponse(string responseData) : base(responseData)
        {
        }

        public ArrayList getNetvisorWebShopCustomerList()
        {
            ArrayList webShopCustomers = new ArrayList();
            XmlDocument webShopCustomerListDocument = new XmlDocument();

            webShopCustomerListDocument.LoadXml(base.responseData);

            foreach (XmlNode webShopCustomerNode in webShopCustomerListDocument.SelectNodes("/Root/NetvisorWebShopCustomers/NetvisorWebShopCustomer"))
            {
                NetvisorWebShopCustomer customer = new NetvisorWebShopCustomer();

                {
                    var withBlock = customer;
                    withBlock.OrganisationIdentifier = System.Convert.ToString(webShopCustomerNode.SelectSingleNode("OrganisationIdentifier").InnerText);
                    withBlock.Name = System.Convert.ToString(webShopCustomerNode.SelectSingleNode("Name").InnerText);
                    withBlock.Address = System.Convert.ToString(webShopCustomerNode.SelectSingleNode("Address").InnerText);
                    withBlock.PostNumber = System.Convert.ToString(webShopCustomerNode.SelectSingleNode("PostNumber").InnerText);
                    withBlock.City = System.Convert.ToString(webShopCustomerNode.SelectSingleNode("City").InnerText);
                    withBlock.Phone = System.Convert.ToString(webShopCustomerNode.SelectSingleNode("Phone").InnerText);
                    withBlock.Email = System.Convert.ToString(webShopCustomerNode.SelectSingleNode("Email").InnerText);
                    withBlock.ProductListURI = System.Convert.ToString(webShopCustomerNode.SelectSingleNode("ProductListURI").InnerText);
                }

                webShopCustomers.Add(customer);
            }

            return webShopCustomers;
        }
    }
}
