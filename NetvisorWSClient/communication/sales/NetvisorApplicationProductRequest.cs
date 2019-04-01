using Microsoft.VisualBasic;
using System.Xml;
using System.Text;
using System.IO;

namespace NetvisorWSClient.communication.sales
{

    public class NetvisorApplicationProductRequest
    {




        public NetvisorApplicationProductRequest()
        {
        }

        public string getProductAsXML(NetvisorProduct product)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;

                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("Product");

                withBlock.WriteStartElement("ProductBaseInformation");

                withBlock.WriteElementString("ProductCode", product.productCode);
                withBlock.WriteElementString("ProductGroup", product.productGroup);
                withBlock.WriteElementString("Name", product.name);
                withBlock.WriteElementString("Description", product.description);

                string unitPriceType;
                if (product.unitPriceType == NetvisorProduct.unitPriceTypes.net)
                    unitPriceType = "net";
                else if (product.unitPriceType == NetvisorProduct.unitPriceTypes.gross)
                    unitPriceType = "gross";
                else
                    throw new InvalidDataException("Invalid unitpricetype");

                withBlock.WriteStartElement("UnitPrice");
                withBlock.WriteAttributeString("type", unitPriceType);
                withBlock.WriteString(product.unitPrice);
                withBlock.WriteEndElement(); // / UnitPrice

                withBlock.WriteElementString("Unit", product.unit);
                withBlock.WriteElementString("UnitWeight", product.unitWeight);
                withBlock.WriteElementString("PurchasePrice", product.purchaseprice);
                withBlock.WriteElementString("TariffHeading", product.tariffHeading);
                withBlock.WriteElementString("ComissionPercentage", product.comissionPercentage);

                int active;
                if (product.isActive)
                    active = 1;
                else
                    active = 0;

                withBlock.WriteElementString("IsActive", active);

                int salesproduct;
                if (product.isSalesproduct)
                    salesproduct = 1;
                else
                    salesproduct = 0;

                withBlock.WriteElementString("IsSalesproduct", salesproduct);

                withBlock.WriteEndElement(); // / ProductBaseInformation

                withBlock.WriteStartElement("ProductBookkeepingDetails");
                withBlock.WriteElementString("DefaultVatPercentage", product.defaultVatPercentage);
                withBlock.WriteEndElement(); // / ProductBookkeepingDetails

                withBlock.WriteEndElement(); // / Product
                withBlock.WriteEndElement(); // / Root

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return streamReader.ReadToEnd();
        }
    }
}
