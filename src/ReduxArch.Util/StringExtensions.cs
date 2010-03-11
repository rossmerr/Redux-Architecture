using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReduxArch.Util
{
    public static class StringExtensions
    {
        public static string Replace(this string str, Dictionary<string, string> dict)
        {
            var sb = new StringBuilder(str);
            return sb.Replace(dict).ToString();
        }

        public static StringBuilder Replace(this StringBuilder sb, Dictionary<string, string> dict)
        {
            foreach (var replacement in dict)
            {
                sb.Replace(replacement.Key, replacement.Value);
            }

            return sb;
        }

    }
}