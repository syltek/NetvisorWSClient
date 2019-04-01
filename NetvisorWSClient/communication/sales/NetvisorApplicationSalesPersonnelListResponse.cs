using Microsoft.VisualBasic;
using System.Collections;
using System.Xml;

namespace NetvisorWSClient.communication.sales
{
    public class NetvisorApplicationSalesPersonnelListResponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationSalesPersonnelListResponse(string responseData) : base(responseData)
        {
        }

        public ArrayList getSalesPersonnelList()
        {
            ArrayList salesPersonnelList = new ArrayList();
            XmlDocument salesPersonnelListDocument = new XmlDocument();

            salesPersonnelListDocument.LoadXml(base.responseData);

            foreach (XmlNode salesPersonNode in salesPersonnelListDocument.SelectNodes("/Root/SalesPersonnelList/SalesPerson"))
            {
                NetvisorSalesPersonnelListSalesPerson salesPersonnelListSalesPerson = new NetvisorSalesPersonnelListSalesPerson();

                {
                    var withBlock = salesPersonnelListSalesPerson;
                    withBlock.netvisorKey = System.Convert.ToInt32(salesPersonNode.Attributes.GetNamedItem("NetvisorKey").InnerText);
                    withBlock.firstName = System.Convert.ToString(salesPersonNode.SelectSingleNode("FirstName").InnerText);
                    withBlock.lastName = System.Convert.ToString(salesPersonNode.SelectSingleNode("LastName").InnerText);
                    if (Strings.Len(salesPersonNode.SelectSingleNode("ProvisionPercent").InnerText) > 0)
                        withBlock.provisionPercent = System.Convert.ToDecimal(salesPersonNode.SelectSingleNode("ProvisionPercent").InnerText);
                }

                salesPersonnelList.Add(salesPersonnelListSalesPerson);
            }

            return salesPersonnelList;
        }
    }
}
