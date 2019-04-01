// 
// 
// 
// Revisio $Revision$
// 
// Ilmentää netvisorin laskentakohteen
// esim. tosite tai laskuriville
// 

using System.Data;
using Microsoft.VisualBasic;
using System.Linq;
using System.Collections.Generic;
using System.Xml;

namespace NetvisorWSClient.communication.common
{

    public class NetvisorDimension
    {
        public enum DimensionMetadataType : int
        {
            StartDate = 1,
            OrganizationIdentifier = 2,
            CurrencyISO4217Code = 3,
            Other = 4,
            DimensionType = 5
        }





        private string m_dimensionName;
        private string m_dimensionDetail;
        private int m_dimensionDetailFatherID;
        private string m_integrationDimensionDetailGuid;
        private string m_dimensionDetailOldItem;
        private string m_dimensionDetailFatherItem;
        private string m_integrationDimensionDetailFatherGuid;
        private List<KeyValuePair<string, DimensionMetadataType?>> m_dimensionDetailMetaDataList = new List<KeyValuePair<string, DimensionMetadataType?>>();

        public string dimensionDetailOldItem
        {
            get
            {
                return m_dimensionDetailOldItem;
            }
            set
            {
                m_dimensionDetailOldItem = value;
            }
        }


        public string dimensionDetailFatherItem
        {
            get
            {
                return m_dimensionDetailFatherItem;
            }
            set
            {
                m_dimensionDetailFatherItem = value;
            }
        }


        public string integrationDimensionDetailFatherGuid
        {
            get
            {
                return m_integrationDimensionDetailFatherGuid;
            }
            set
            {
                m_integrationDimensionDetailFatherGuid = value;
            }
        }

        public NetvisorDimension()
        {
        }

        public NetvisorDimension(string dimensionName, string dimensionDetail)
        {
            m_dimensionName = dimensionName;
            m_dimensionDetail = dimensionDetail;
        }

        public NetvisorDimension(string dimensionName, string dimensionDetail, int dimensionDetailFatherID)
        {
            m_dimensionName = dimensionName;
            m_dimensionDetail = dimensionDetail;
            m_dimensionDetailFatherID = dimensionDetailFatherID;
        }

        public string dimensionName
        {
            get
            {
                return m_dimensionName;
            }
            set
            {
                m_dimensionName = value;
            }
        }

        public string dimensionDetail
        {
            get
            {
                return m_dimensionDetail;
            }
            set
            {
                m_dimensionDetail = value;
            }
        }

        public int dimensionDetailFatherID
        {
            get
            {
                return m_dimensionDetailFatherID;
            }
            set
            {
                m_dimensionDetailFatherID = value;
            }
        }

        public string integrationDimensionDetailGuid
        {
            get
            {
                return m_integrationDimensionDetailGuid;
            }
            set
            {
                m_integrationDimensionDetailGuid = value;
            }
        }


        public void writeDimensionElement(ref XmlTextWriter xmlWriter)
        {
            {
                var withBlock = xmlWriter;
                withBlock.WriteStartElement("Dimension");
                withBlock.WriteElementString("DimensionName", m_dimensionName);
                withBlock.WriteStartElement("DimensionItem");

                if (m_dimensionDetailFatherID > 0)
                    withBlock.WriteAttributeString("fatherid", m_dimensionDetailFatherID.ToString());


                withBlock.WriteString(m_dimensionDetail);
                withBlock.WriteEndElement(); // / DimensionItem
                withBlock.WriteEndElement(); // / Dimension
            }
        }

        public void addDimensionDetailMetaData(string data)
        {
            addDimensionDetailMetaData(data, default(DimensionMetadataType?));
        }

        public void addDimensionDetailMetaDataWithType(string data, DimensionMetadataType type)
        {
            addDimensionDetailMetaData(data, type);
        }

        private void addDimensionDetailMetaData(string data, DimensionMetadataType? type)
        {
            m_dimensionDetailMetaDataList.Add(new KeyValuePair<string, DimensionMetadataType?>(data, type));
        }

        public List<string> dimensionDetailMetaDataList
        {
            get
            {
                return m_dimensionDetailMetaDataList.Select(x => x.Key).ToList();
            }
        }

        public List<KeyValuePair<string, DimensionMetadataType?>> dimensionDetailMetaDataListWithType
        {
            get
            {
                return m_dimensionDetailMetaDataList;
            }
        }
    }
}
