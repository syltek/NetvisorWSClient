using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetvisorWSClient
{
    internal static class Strings
    {
        public static int Len(string str) => str?.Length ?? 0;

        public static string Format(DateTime date, string format) => date.ToString(format);
    }
}
