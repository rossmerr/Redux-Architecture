using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace ReduxArch.Web
{
    public static class WrapperExtension
    {
        public static string Wrapper(this string obj, string tagName, IDictionary<string, object> htmlAttributes)
        {
            if (!string.IsNullOrEmpty(obj))
            {
                var tag = new TagBuilder(tagName) { InnerHtml = obj };
                tag.MergeAttributes(htmlAttributes);
                return tag.ToString(TagRenderMode.Normal);
            }

            return string.Empty;
        }

        public static string Wrapper(this string obj, string tagName, object htmlAttributes)
        {
            return Wrapper(obj, tagName, new RouteValueDictionary(htmlAttributes));
        }

        public static string Wrapper(this string obj, string tagName)
        {
            return Wrapper(obj, tagName, null);
        }

    }
}
