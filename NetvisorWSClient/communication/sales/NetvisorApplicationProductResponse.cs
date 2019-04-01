using System.Xml;

namespace NetvisorWSClient.communication.sales
{
    public class NetvisorApplicationProductResponse : NetvisorApplicationResponse
    {
        private const string UNIT_PRICE_TYPE_NET = "net";
        private const string PRODUCT_BASE_INFORMATION_PATH = "/Root/Product/ProductBaseInformation/";
        private const string PRODUCT_BOOKKEEPING_DETAILS_PATH = "/Root/Product/ProductBookKeepingDetails/";
        private const string PRODUCT_INVENTORY_DETAILS_PATH = "/Root/Product/ProductInventoryDetails/";

        public NetvisorApplicationProductResponse(string responseData) : base(responseData)
        {
        }

        public NetvisorProduct getProduct()
        {
            XmlDocument productDocument = new XmlDocument();
            productDocument.LoadXml(base.responseData);

            NetvisorProduct product = new NetvisorProduct();
            {
                var withBlock = product;
                withBlock.netvisorKey = System.Convert.ToInt32(productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH + "NetvisorKey").InnerText);
                withBlock.productCode = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH + "ProductCode").InnerText;
                withBlock.productGroup = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH + "ProductGroup").InnerText;
                withBlock.name = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH + "Name").InnerText;
                withBlock.description = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH + "Description").InnerText;

                string unitPrice = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH + "UnitPrice").InnerText;
                if (!string.IsNullOrEmpty(unitPrice))
                    withBlock.unitPrice = System.Convert.ToDecimal(unitPrice);

                if (productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH + "UnitPrice").Attributes["type"].InnerText == UNIT_PRICE_TYPE_NET)
                    withBlock.unitPriceType = NetvisorProduct.unitPriceTypes.net;
                else
                    withBlock.unitPriceType = NetvisorProduct.unitPriceTypes.gross;

                withBlock.unit = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH + "Unit").InnerText;

                string unitWeight = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH + "UnitWeight").InnerText;
                if (!string.IsNullOrEmpty(unitWeight))
                    withBlock.unitWeight = System.Convert.ToDecimal(unitWeight);

                string purchasePrice = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH + "PurchasePrice").InnerText;
                if (!string.IsNullOrEmpty(purchasePrice))
                    withBlock.purchaseprice = System.Convert.ToDecimal(purchasePrice);

                withBlock.tariffHeading = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH + "TariffHeading").InnerText;

                string comissionPercentage = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH + "ComissionPercentage").InnerText;
                if (!string.IsNullOrEmpty(comissionPercentage))
                    withBlock.comissionPercentage = System.Convert.ToDecimal(comissionPercentage);

                string isActive = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH + "IsActive").InnerText;
                if (!string.IsNullOrEmpty(isActive))
                    withBlock.isActive = (System.Convert.ToInt32(isActive) == 1);

                string isSalesProduct = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH + "IsSalesProduct").InnerText;
                if (!string.IsNullOrEmpty(isSalesProduct))
                    withBlock.isSalesproduct = (System.Convert.ToInt32(isSalesProduct) == 1);

                string defaultVatPercentage = productDocument.SelectSingleNode(PRODUCT_BOOKKEEPING_DETAILS_PATH + "DefaultVatPercent").InnerText;
                if (!string.IsNullOrEmpty(defaultVatPercentage))
                    withBlock.defaultVatPercentage = System.Convert.ToDecimal(defaultVatPercentage);

                string defaultDomesticAccountNumber = productDocument.SelectSingleNode(PRODUCT_BOOKKEEPING_DETAILS_PATH + "DefaultDomesticAccountNumber").InnerText;
                if (!string.IsNullOrEmpty(defaultDomesticAccountNumber))
                    withBlock.DefaultDomesticAccountNumber = System.Convert.ToInt32(defaultDomesticAccountNumber);

                string defaultEuAccountNumber = productDocument.SelectSingleNode(PRODUCT_BOOKKEEPING_DETAILS_PATH + "DefaultEuAccountNumber").InnerText;
                if (!string.IsNullOrEmpty(defaultEuAccountNumber))
                    withBlock.DefaultEuAccountNumber = System.Convert.ToInt32(defaultEuAccountNumber);

                string defaultOutsideEUAccountNumber = productDocument.SelectSingleNode(PRODUCT_BOOKKEEPING_DETAILS_PATH + "DefaultOutsideEUAccountNumber").InnerText;
                if (!string.IsNullOrEmpty(DefaultOutsideEUAccountNumber))
                    withBlock.DefaultOutsideEUAccountNumber = System.Convert.ToDecimal(defaultOutsideEUAccountNumber);

                string InventoryAmount = productDocument.SelectSingleNode(PRODUCT_INVENTORY_DETAILS_PATH + "InventoryAmount").InnerText;
                if (!string.IsNullOrEmpty(InventoryAmount))
                    withBlock.InventoryAmount = System.Convert.ToDecimal(InventoryAmount);

                string InventoryMidPrice = productDocument.SelectSingleNode(PRODUCT_INVENTORY_DETAILS_PATH + "InventoryMidPrice").InnerText;
                if (!string.IsNullOrEmpty(InventoryMidPrice))
                    withBlock.InventoryMidPrice = System.Convert.ToDecimal(InventoryMidPrice);

                string InventoryValue = productDocument.SelectSingleNode(PRODUCT_INVENTORY_DETAILS_PATH + "InventoryValue").InnerText;
                if (!string.IsNullOrEmpty(InventoryValue))
                    withBlock.InventoryValue = System.Convert.ToDecimal(InventoryValue);

                string InventoryReservedAmount = productDocument.SelectSingleNode(PRODUCT_INVENTORY_DETAILS_PATH + "InventoryReservedAmount").InnerText;
                if (!string.IsNullOrEmpty(InventoryReservedAmount))
                    withBlock.InventoryReservedAmount = System.Convert.ToDecimal(InventoryReservedAmount);

                string InventoryOrderedAmount = productDocument.SelectSingleNode(PRODUCT_INVENTORY_DETAILS_PATH + "InventoryOrderedAmount").InnerText;
                if (!string.IsNullOrEmpty(InventoryOrderedAmount))
                    withBlock.InventoryOrderedAmount = System.Convert.ToDecimal(InventoryOrderedAmount);
            }

            return product;
        }
    }
}
