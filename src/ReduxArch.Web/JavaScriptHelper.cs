using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReduxArch.Web
{
    internal class JavaScriptHelper
    {
        public static string ArrayParser(Dictionary<string, object> jQueryArray)
        {
            var sb = new StringBuilder();

            foreach (var s in jQueryArray)
            {
                sb.Append(string.Format("\n{0} : {1},", s.Key, s.Value));
            }

            return sb.ToString(0, (sb.Length - 1));
        }

    }
}
