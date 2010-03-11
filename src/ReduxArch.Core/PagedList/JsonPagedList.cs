using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReduxArch.Core.PagedList
{
    public class JsonPagedList<T>
    {
        public JsonPagedList(IPagedList<T> list)
        {
            List = list;
            HasNextPage = list.HasNextPage;
            HasPreviousPage = list.HasPreviousPage;
            IsFirstPage = list.IsFirstPage;
            IsLastPage = list.IsLastPage;
            PageCount = list.PageCount;
            PageIndex = list.PageIndex;
            PageNumber = list.PageNumber;
            PageSize = list.PageSize;
            TotalItemCount = list.TotalItemCount;
        }

        public bool HasNextPage { get; private set; }
        public bool HasPreviousPage { get; private set; }
        public bool IsFirstPage { get; private set; }
        public bool IsLastPage { get; private set; }
        public int PageCount { get; private set; }
        public int PageIndex { get; private set; }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int TotalItemCount { get; private set; }

        public IEnumerable<T> List { get; private set; }
    }
}