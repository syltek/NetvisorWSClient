using Microsoft.VisualBasic;
using System.Collections;
using System.Xml;

namespace NetvisorWSClient.communication.webshop
{
    public class NetvisorApplicationWebShopProductResponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationWebShopProductResponse(string responseData) : base(responseData)
        {
        }

        public ArrayList getNetvisorWebShopProductList()
        {
            ArrayList webShopProducts = new ArrayList();
            XmlDocument webShopProductListDocument = new XmlDocument();

            webShopProductListDocument.LoadXml(base.responseData);

            foreach (XmlNode webShopProductNode in webShopProductListDocument.SelectNodes("/Root/WebShopProductList/WebShopProduct"))
            {
                NetvisorWebShopProduct product = new NetvisorWebShopProduct();

                foreach (XmlNode name in webShopProductNode.SelectNodes("Name"))
                    product.addNameWithCountryCode(name.Attributes.GetNamedItem("language").InnerText, name.InnerText);

                foreach (XmlNode description in webShopProductNode.SelectNodes("Description"))
                    product.addDescriptionWithCountryCode(description.Attributes.GetNamedItem("language").InnerText, description.InnerText);

                foreach (XmlNode groupName in webShopProductNode.SelectNodes("ProductGroups/ProductGroup/Name"))
                {
                    NetvisorWebShopProductGroup group = new NetvisorWebShopProductGroup();

                    group.addNameWithCountryCode(groupName.Attributes.GetNamedItem("language").InnerText, groupName.InnerText);

                    product.addProductGroup(group);
                }

                foreach (XmlNode variantNode in webShopProductNode.SelectNodes("Variants/Variant"))
                {
                    NetvisorWebShopProductVariant productVariant = new NetvisorWebShopProductVariant();

                    foreach (XmlNode name in variantNode.SelectNodes("Name"))
                        productVariant.addNameWithCountryCode(name.Attributes.GetNamedItem("language").InnerText, name.InnerText);

                    foreach (XmlNode description in variantNode.SelectNodes("Description"))
                        productVariant.addDescriptionWithCountryCode(description.Attributes.GetNamedItem("language").InnerText, description.InnerText);

                    productVariant.variantIdentifier = System.Convert.ToString(variantNode.SelectSingleNode("VariantIdentifier").InnerText);
                    productVariant.imageURI = System.Convert.ToString(variantNode.SelectSingleNode("ImageURI").InnerText);

                    if (!(variantNode.SelectSingleNode("LastChangeDate") == null))
                        productVariant.lastChangeDate = System.Convert.ToString(variantNode.SelectSingleNode("LastChangeDate").InnerText);

                    if (!(variantNode.SelectSingleNode("Price") == null) && Strings.Len(System.Convert.ToString(variantNode.SelectSingleNode("Price").InnerText)) > 0)
                        productVariant.price = System.Convert.ToString(variantNode.SelectSingleNode("Price").InnerText);

                    product.addProductVariant(productVariant);
                }

                webShopProducts.Add(product);
            }

            return webShopProducts;
        }
    }
}
