using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReduxArch.Util
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class SortOrderAttribute : Attribute
    {
        public int Order { get; set; }

        public SortOrderAttribute()
        {
            Order = 0;
        }
    }
}
