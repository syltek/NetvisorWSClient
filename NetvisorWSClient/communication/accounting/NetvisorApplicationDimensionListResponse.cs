using System.Collections;
using System.Xml;

namespace NetvisorWSClient.communication.accounting
{
    public class NetvisorApplicationDimensionListResponse : NetvisorApplicationResponse
    {
        public NetvisorApplicationDimensionListResponse(string responseData) : base(responseData)
        {
        }

        public ArrayList getDimensionNameList()
        {
            ArrayList dimensionNameList = new ArrayList();
            XmlDocument dimensionNameListDocument = new XmlDocument();

            dimensionNameListDocument.LoadXml(base.responseData);

            foreach (XmlNode dimensionNameNode in dimensionNameListDocument.SelectNodes("/Root/DimensionNameList/DimensionName"))
            {
                NetvisorDimensionName dimensionNameListDimensionName = new NetvisorDimensionName();

                {
                    var withBlock = dimensionNameListDimensionName;
                    withBlock.NetvisorKey = System.Convert.ToInt32(dimensionNameNode.SelectSingleNode("Netvisorkey").InnerText);
                    withBlock.Name = System.Convert.ToString(dimensionNameNode.SelectSingleNode("Name").InnerText);
                    withBlock.IsHidden = System.Convert.ToBoolean(dimensionNameNode.SelectSingleNode("IsHidden").InnerText);
                    withBlock.LinkType = System.Convert.ToInt32(dimensionNameNode.SelectSingleNode("LinkType").InnerText);
                }

                foreach (XmlNode detailNode in dimensionNameNode.SelectNodes("DimensionDetails/DimensionDetail"))
                {
                    NetvisorDimensionNameDimensionDetail dimensionDetail = new NetvisorDimensionNameDimensionDetail();

                    {
                        var withBlock1 = dimensionDetail;
                        withBlock1.NetvisorKey = System.Convert.ToInt32(detailNode.SelectSingleNode("Netvisorkey").InnerText);
                        withBlock1.Name = System.Convert.ToString(detailNode.SelectSingleNode("Name").InnerText);
                        withBlock1.IsHidden = System.Convert.ToBoolean(detailNode.SelectSingleNode("IsHidden").InnerText);
                        withBlock1.Level = System.Convert.ToInt32(detailNode.SelectSingleNode("Level").InnerText);
                        withBlock1.Sort = System.Convert.ToInt32(detailNode.SelectSingleNode("Sort").InnerText);
                        withBlock1.EndSort = System.Convert.ToInt32(detailNode.SelectSingleNode("EndSort").InnerText);
                        withBlock1.FatherID = System.Convert.ToInt32(detailNode.SelectSingleNode("FatherID").InnerText);
                    }

                    dimensionNameListDimensionName.DimensionDetails.Add(dimensionDetail);
                }

                dimensionNameList.Add(dimensionNameListDimensionName);
            }

            return dimensionNameList;
        }
    }
}

