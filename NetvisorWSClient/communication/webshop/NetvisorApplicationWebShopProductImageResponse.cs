using System.Collections;
using System;
using System.Xml;

namespace NetvisorWSClient.communication.webshop
{
    public class NetvisorApplicationWebShopProductImageResponse : NetvisorApplicationResponse
    {
        public const string PARAMETER_IDENTIFIER = "identifier";

        public NetvisorApplicationWebShopProductImageResponse(string responseData) : base(responseData)
        {
        }

        public ArrayList getNetvisorWebShopProductImageList()
        {
            ArrayList images = new ArrayList();
            XmlDocument productImagesListDocument = new XmlDocument();

            productImagesListDocument.LoadXml(base.responseData);

            foreach (XmlNode imageNode in productImagesListDocument.SelectNodes("/Root/WebShopProductImages/WebShopProductImage"))
            {
                NetvisorWebShopProductImage image = new NetvisorWebShopProductImage();

                {
                    var withBlock = image;
                    withBlock.MimeType = System.Convert.ToString(imageNode.SelectSingleNode("MimeType").InnerText);
                    withBlock.Title = System.Convert.ToString(imageNode.SelectSingleNode("Title").InnerText);
                    withBlock.FileName = System.Convert.ToString(imageNode.SelectSingleNode("FileName").InnerText);
                    withBlock.DocumentData = Convert.FromBase64String(System.Convert.ToString(imageNode.SelectSingleNode("DocumentData").InnerText));
                }

                images.Add(image);
            }

            return images;
        }
    }
}
