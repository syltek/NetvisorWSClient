using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NetvisorWSClient 
{ 
    static class Information
    {
        public static bool IsNothing(object r) => r is null;

        internal static bool IsNumeric(string s) => decimal.TryParse(s, out decimal d);
    }

    static class HelperExtensions
    {
        public static int GetInt(this XmlNode node) => int.TryParse(node?.InnerText, out int r) ? r : default(int);
        public static decimal GetDecimal(this XmlNode node) => decimal.TryParse(node?.InnerText, out decimal r) ? r : default(decimal);
        public static DateTime GetDateTime(this XmlNode node) => DateTime.TryParse(node?.InnerText, out DateTime r) ? r : default(DateTime);
        public static void WriteElementString(this XmlWriter w, string n, object o) => w.WriteElementString(n, o?.ToString() ?? "");
        public static void WriteString(this XmlTextWriter w, object o) => w.WriteString(o?.ToString() ?? "");
    }
}
