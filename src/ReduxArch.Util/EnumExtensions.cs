using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ReduxArch.Util
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        public static string GetEnumDescriptionEmpty(this Enum value)
        {
            var customAttributes = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return customAttributes.Length <= 0 ? null : customAttributes[0].Description;
        }


        public static Enum[] GetEnumSortOrder(this System.Array value)
        {
            var coll = new SortedDictionary<Enum, int>();

            foreach (Enum @enum in value)
            {

                var order = @enum.GetEnumSortOrder();
                coll.Add(@enum, order);
            }

            return coll.OrderBy(p => p.Value).Select(p => p.Key).ToArray();
        }

        public static int GetEnumSortOrder(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (SortOrderAttribute[])fi.GetCustomAttributes(typeof(SortOrderAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Order : 0;
        }
    }
}
