using Microsoft.VisualBasic;
using System;

namespace NetvisorWSClient.util
{
    public class UniqueIdentifierGenerator
    {
        private string m_identifier;

        public string identifier
        {
            get
            {
                return m_identifier;
            }
        }

        public UniqueIdentifierGenerator()
        {
            m_identifier = Strings.Format(DateTime.Now, "yyMMddhhmmss") 
                         + DateTime.Now.Millisecond 
                         + new Random().Next(0, 10000);
        }
    }
}
