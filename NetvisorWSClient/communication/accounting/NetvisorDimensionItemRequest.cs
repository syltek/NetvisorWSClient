using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.IO;
using NetvisorWSClient.communication.common;

namespace NetvisorWSClient.communication.accounting
{
    public class NetvisorDimensionItemRequest
    {
        public const string PARAMETER_METHOD = "method";
        public const string PARAMETER_METHOD_ADD = "add";
        public const string PARAMETER_METHOD_EDIT = "edit";

        public string getDimensionItemAsXML(NetvisorDimension dimensionItem)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            {
                var withBlock = xmlWriter;
                withBlock.Formatting = Formatting.Indented;
                withBlock.Indentation = 4;


                withBlock.WriteStartElement("Root");
                withBlock.WriteStartElement("DimensionItem");
                withBlock.WriteElementString("Name", dimensionItem.dimensionName);
                withBlock.WriteElementString("Item", dimensionItem.dimensionDetail);

                if (Strings.Len(dimensionItem.dimensionDetailOldItem) > 0)
                    withBlock.WriteElementString("OldItem", dimensionItem.dimensionDetailOldItem);

                if (Strings.Len(dimensionItem.integrationDimensionDetailGuid) > 0)
                    withBlock.WriteElementString("IntegrationDimensionDetailGuid", dimensionItem.integrationDimensionDetailGuid);

                if (dimensionItem.dimensionDetailFatherID > 0)
                    withBlock.WriteElementString("FatherId", dimensionItem.dimensionDetailFatherID);

                if (Strings.Len(dimensionItem.dimensionDetailFatherItem) > 0)
                    withBlock.WriteElementString("FatherItem", dimensionItem.dimensionDetailFatherItem);

                if (Strings.Len(dimensionItem.integrationDimensionDetailFatherGuid) > 0)
                    withBlock.WriteElementString("IntegrationDimensionDetailFatherGuid", dimensionItem.integrationDimensionDetailFatherGuid);

                if (dimensionItem.dimensionDetailMetaDataList.Count > 0)
                {
                    foreach (KeyValuePair<string, NetvisorDimension.DimensionMetadataType?> data in dimensionItem.dimensionDetailMetaDataListWithType)
                    {
                        string dataValue = data.Key;
                        NetvisorDimension.DimensionMetadataType? dataType = data.Value;

                        withBlock.WriteStartElement("MetaData");
                        withBlock.WriteElementString("Data", dataValue);
                        withBlock.WriteElementString("Type", dataType.HasValue ? dataType.Value : "");
                        withBlock.WriteEndElement(); // /MetaData
                    }
                }

                withBlock.WriteEndElement(); // /DimensionItem
                withBlock.WriteEndElement(); // /Root

                withBlock.Flush();
            }

            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return streamReader.ReadToEnd();
        }
    }
}
