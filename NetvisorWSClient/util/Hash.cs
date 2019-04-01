using Microsoft.VisualBasic;

namespace NetvisorWSClient.util
{
    public class Hash
    {
        private string m_stringToEncode;

        private string m_32CharHexString;
        private byte[] m_bytes;

        enum hashType : int
        {
            byteArray = 1,
            s32CharHexString = 2
        }

        public Hash(string stringToEncode)
        {
            m_stringToEncode = stringToEncode;
        }

        public byte[] getHashAsByteArray()
        {
            compute(hashType.byteArray);

            return m_bytes;
        }

        public string getHashAs32CharHexString()
        {
            compute(hashType.s32CharHexString);

            return m_32CharHexString;
        }

        private void compute(hashType type)
        {
            System.Text.Encoding Ne = System.Text.Encoding.Default;
            System.Security.Cryptography.SHA256CryptoServiceProvider SHA256 = new System.Security.Cryptography.SHA256CryptoServiceProvider();
            byte[] bytes = SHA256.ComputeHash(Ne.GetBytes(m_stringToEncode));

            switch (type)
            {
                case hashType.byteArray:
                    {
                        m_bytes = m_bytes;
                        break;
                    }

                case hashType.s32CharHexString:
                    {
                        string ret = Constants.vbNullString;

                        foreach (byte bytByte in bytes)

                            ret += bytByte.ToString("X2");

                        m_32CharHexString = ret;
                        break;
                    }
            }

            Ne = null;
            SHA256 = null;
        }
    }
}

