using System;
using System.Xml;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.purchase
{
    public class NetvisorApplicationPurchaseOrderResponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationPurchaseOrderResponse(string responseData) : base(responseData)
        {
        }

        public NetvisorPurchaseOrder getPurchaseOrder()
        {
            NetvisorPurchaseOrder response = new NetvisorPurchaseOrder();
            XmlDataDocument PurchaseOrderDocument = new XmlDataDocument();

            PurchaseOrderDocument.LoadXml(base.responseData);
            XmlNode purchaseOrderNode = PurchaseOrderDocument.SelectSingleNode("/Root/PurchaseOrder");

            {
                var withBlock = response;
                int.TryParse(purchaseOrderNode.SelectSingleNode("NetvisorKey").InnerText, out withBlock.netvisorKey);
                withBlock.orderNumber = purchaseOrderNode.SelectSingleNode("OrderNumber").InnerText;
                withBlock.orderStatus = purchaseOrderNode.SelectSingleNode("OrderStatus").InnerText;
                DateTime.TryParse(purchaseOrderNode.SelectSingleNode("OrderDate").InnerText, out withBlock.orderDate);
                withBlock.vendorName = purchaseOrderNode.SelectSingleNode("VendorName").InnerText;
                withBlock.vendorAddressline = purchaseOrderNode.SelectSingleNode("VendorAddressLine").InnerText;
                withBlock.vendorPostnumber = purchaseOrderNode.SelectSingleNode("VendorPostNumber").InnerText;
                withBlock.vendorCity = purchaseOrderNode.SelectSingleNode("VendorCity").InnerText;
                withBlock.vendorCountry = purchaseOrderNode.SelectSingleNode("VendorCountry").InnerText;
                withBlock.deliveryTerm = purchaseOrderNode.SelectSingleNode("DeliveryTerm").InnerText;
                withBlock.deliveryMethod = purchaseOrderNode.SelectSingleNode("DeliveryMethod").InnerText;
                withBlock.deliveryName = purchaseOrderNode.SelectSingleNode("DeliveryName").InnerText;
                withBlock.deliveryAddressLine = purchaseOrderNode.SelectSingleNode("DeliveryAddressLine").InnerText;
                withBlock.deliveryPostNumber = purchaseOrderNode.SelectSingleNode("DeliveryPostNumber").InnerText;
                withBlock.deliveryCity = purchaseOrderNode.SelectSingleNode("DeliveryCity").InnerText;
                withBlock.deliveryCountry = purchaseOrderNode.SelectSingleNode("DeliveryCountry").InnerText;
                withBlock.comment = purchaseOrderNode.SelectSingleNode("Comment").InnerText;
                withBlock.privateComment = purchaseOrderNode.SelectSingleNode("PrivateComment").InnerText;
                withBlock.ourReference = purchaseOrderNode.SelectSingleNode("OurReference").InnerText;
                withBlock.paymentTermDescription = purchaseOrderNode.SelectSingleNode("PaymentTerm").InnerText;
                decimal.TryParse(purchaseOrderNode.SelectSingleNode("Amount").InnerText, out withBlock.amount);
            }

            foreach (XmlNode node in PurchaseOrderDocument.SelectNodes("/Root/PurchaseOrder/PurchaseOrderLines/PurchaseOrderProductLine"))
            {
                NetvisorPurchaseOrderLine productLine = new NetvisorPurchaseOrderLine();
                {
                    var withBlock1 = productLine;
                    withBlock1.productCode = node.SelectSingleNode("ProductCode").InnerText;
                    withBlock1.productName = node.SelectSingleNode("ProductName").InnerText;
                    withBlock1.vendorProductCode = node.SelectSingleNode("VendorProductCode").InnerText;
                    decimal.TryParse(node.SelectSingleNode("OrderedAmount").InnerText, out withBlock1.orderedAmount);
                    decimal.TryParse(node.SelectSingleNode("DeliveredAmount").InnerText, out withBlock1.deliveredAmount);
                    decimal.TryParse(node.SelectSingleNode("UnitPrice").InnerText, out withBlock1.unitPrice);
                    decimal.TryParse(node.SelectSingleNode("VatPercent").InnerText, out withBlock1.vatPercent);
                    decimal.TryParse(node.SelectSingleNode("LineSum").InnerText, out withBlock1.lineSum);
                    decimal.TryParse(node.SelectSingleNode("FreightRate").InnerText, out withBlock1.freightRate);
                    DateTime.TryParse(node.SelectSingleNode("DeliveryDate").InnerText, out withBlock1.DeliveryDate);
                    withBlock1.inventoryPlace = node.SelectSingleNode("InventoryPlace").InnerText;
                    int.TryParse(node.SelectSingleNode("AccountingSuggestion").InnerText, out withBlock1.accountingSuggestion);
                }



                foreach (XmlNode dimensionNode in node.SelectNodes("Dimension"))
                {
                    NetvisorDimension lineDimension = new NetvisorDimension();

                    lineDimension.dimensionName = dimensionNode.SelectSingleNode("DimensionName").InnerText;
                    lineDimension.dimensionDetail = dimensionNode.SelectSingleNode("DimensionItem").InnerText;

                    productLine.addDimension(lineDimension);
                }
                response.addProductline(productLine);
            }

            foreach (XmlNode node in PurchaseOrderDocument.SelectNodes("/Root/PurchaseOrder/PurchaseOrderLines/PurchaseOrderCommentLine"))
            {
                NetvisorPurchaseOrderCommentLine commentLine = new NetvisorPurchaseOrderCommentLine();
                commentLine.comment = node.InnerText;

                response.addCommentLine(commentLine);
            }

            return response;
        }
    }
}

