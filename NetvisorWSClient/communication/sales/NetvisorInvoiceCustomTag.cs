
namespace NetvisorWSClient.communication.sales
{
    public class NetvisorInvoiceCustomTag
    {
        public const string ATTRIBUTE_DATATYPE_DATE = "date";
        public const string ATTRIBUTE_DATATYPE_ENUM = "enum";
        public const string ATTRIBUTE_DATATYPE_TEXT = "text";
        public const string ATTRIBUTE_DATATYPE_FLOAT = "float";

        public enum CustomTagDataTypes : int
        {
            date = 1,
            @enum = 2,
            text = 3,
            @float = 4
        }

        private string m_name;
        private string m_value;
        private CustomTagDataTypes m_valueDataType;

        public string name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }

        public string value
        {
            get
            {
                return m_value;
            }
            set
            {
                m_value = value;
            }
        }

        public CustomTagDataTypes valueDataType
        {
            get
            {
                return m_valueDataType;
            }
            set
            {
                m_valueDataType = value;
            }
        }
    }
}
