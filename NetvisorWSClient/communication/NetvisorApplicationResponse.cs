using Microsoft.VisualBasic;
using System;
using System.Xml;

namespace NetvisorWSClient.communication
{

    public class NetvisorApplicationResponse
    {




        private bool m_isResponseOK;
        private string m_ErrorMessage;
        private string m_responsedata;
        private string m_insertedDataIdentifier;

        public bool IsresponseOK
        {
            get
            {
                return m_isResponseOK;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return m_ErrorMessage;
            }
        }

        public string responseData
        {
            get
            {
                return m_responsedata;
            }
        }

        public string insertedDataIdentifier
        {
            get
            {
                return m_insertedDataIdentifier;
            }
        }

        public NetvisorApplicationResponse()
        {
        }

        public NetvisorApplicationResponse(string responseData)
        {
            m_responsedata = responseData;

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(responseData);

                XmlNodeList responseStatus = doc.SelectNodes("/Root/ResponseStatus/Status");

                if (responseStatus.Item(0).InnerText == "OK")
                {
                    m_isResponseOK = true;

                    foreach (XmlNode reply in doc.SelectNodes("/Root/Replies"))
                    {
                        if (reply.FirstChild.Name == "InsertedDataIdentifier")
                            m_insertedDataIdentifier = reply.SelectSingleNode("InsertedDataIdentifier").InnerText;
                    }
                }
                else
                {
                    m_isResponseOK = false;
                    m_ErrorMessage = responseStatus.Item(1).InnerText;
                }
            }
            catch (Exception ex)
            {
                m_isResponseOK = false;
                m_ErrorMessage = "Error while processing response: " + ex.Message;
            }
        }
    }
}
