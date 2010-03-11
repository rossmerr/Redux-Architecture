
/// <summary>
/// http://stephenwalther.com/blog/archive/2008/09/18/asp-net-mvc-tip-44-create-a-pager-html-helper.aspx
/// Updated the class to use PagedList class instead (NizzaS)
///  </summary>

using System;
using System.Web.Mvc;
using System.Collections.Generic;
using ReduxArch.Core.PagedList;

namespace ReduxArch.Web.PagedList
{
    public static class PagerHelper
    {
        public static IList<PagerItem> PagerList<T>(this HtmlHelper helper, IPagedList<T> pageOfList)
        {
            return PagerList<T>(helper, pageOfList.PageCount, pageOfList.PageIndex, null, null, null, null);
        }

        public static IList<PagerItem> PagerList<T>(this HtmlHelper helper, IPagedList<T> pageOfList, PagerOptions options)
        {
            return PagerList<T>(helper, pageOfList.PageCount, pageOfList.PageIndex, null, null, options, null);
        }


        public static IList<PagerItem> PagerList<T>(
            this HtmlHelper helper, 
            int totalPageCount, 
            int pageIndex, 
            string actionName, 
            string controllerName, 
            PagerOptions options, 
            object values)
        {
            var builder = new PagerBuilder
                (
                helper,
                actionName,
                controllerName,
                totalPageCount,
                pageIndex,
                options,
                values
                );
            return builder.ToList();
        }

        public static string Pager<T>(this HtmlHelper helper, IPagedList<T> pageOfList)
        {
            return Pager(helper, pageOfList.PageCount, pageOfList.PageIndex, null, null, null, null);
        }

        public static string Pager<T>(this HtmlHelper helper, IPagedList<T> pageOfList, PagerOptions options)
        {
            return Pager(helper, pageOfList.PageCount, pageOfList.PageIndex, null, null, options, null);
        }

        public static string Pager(this HtmlHelper helper, 
                                   int totalPageCount, 
                                   int pageIndex, 
                                   string actionName, 
                                   string controllerName, 
                                   PagerOptions options, 
                                   object values)
        {
            var builder = new PagerBuilder
                (
                helper, 
                actionName, 
                controllerName, 
                totalPageCount, 
                pageIndex, 
                options, 
                values
                );
            return builder.RenderList();

        }
    }
}