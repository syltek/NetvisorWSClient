using System.Collections;
using System.Xml;

namespace NetvisorWSClient.communication.sales
{
    public class NetvisorApplicationProductListResponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationProductListResponse(string responseData) : base(responseData)
        {
        }

        public ArrayList getProductList()
        {
            ArrayList productList = new ArrayList();
            XmlDocument productListDocument = new XmlDocument();

            productListDocument.LoadXml(base.responseData);

            foreach (XmlNode productNode in productListDocument.SelectNodes("/Root/ProductList/Product"))
            {
                NetvisorProductListProduct productListProduct = new NetvisorProductListProduct();

                {
                    var withBlock = productListProduct;
                    withBlock.netvisorKey = System.Convert.ToInt32(productNode.SelectSingleNode("NetvisorKey").InnerText);
                    withBlock.productCode = System.Convert.ToString(productNode.SelectSingleNode("ProductCode").InnerText);
                    withBlock.name = System.Convert.ToString(productNode.SelectSingleNode("Name").InnerText);
                    withBlock.unitPrice = System.Convert.ToDecimal(productNode.SelectSingleNode("UnitPrice").InnerText);
                    withBlock.uri = System.Convert.ToString(productNode.SelectSingleNode("Uri").InnerText);
                }

                productList.Add(productListProduct);
            }

            return productList;
        }
    }
}
