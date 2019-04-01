using System.Collections;
using System;
using System.Xml;

namespace NetvisorWSClient.communication.purchase
{
    public class NetvisorApplicationPurchaseOrderListResponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationPurchaseOrderListResponse(string responseData) : base(responseData)
        {
        }

        public ArrayList getPurchaseOrderList()
        {
            ArrayList response = new ArrayList();
            XmlDocument purchaseOrderListDocument = new XmlDocument();
            purchaseOrderListDocument.LoadXml(base.responseData);

            foreach (XmlNode node in purchaseOrderListDocument.SelectNodes("/Root/PurchaseOrderList/PurchaseOrder"))
            {
                NetvisorPurchaseOrderListOrder orderListOrder = new NetvisorPurchaseOrderListOrder();

                {
                    var withBlock = orderListOrder;
                    int.TryParse(node.SelectSingleNode("NetvisorKey").InnerText, out withBlock.netvisorKey);
                    withBlock.orderNumber = node.SelectSingleNode("OrderNumber").InnerText;
                    DateTime.TryParse(node.SelectSingleNode("OrderDate").InnerText, out withBlock.orderDate);
                    withBlock.orderStatus = node.SelectSingleNode("OrderStatus").InnerText;
                    withBlock.vendorName = node.SelectSingleNode("VendorName").InnerText;
                    double.TryParse(node.SelectSingleNode("Amount").InnerText, out withBlock.amount);
                    withBlock.uri = node.SelectSingleNode("Uri").InnerText;
                }
                response.Add(orderListOrder);
            }

            return response;
        }
    }
}


