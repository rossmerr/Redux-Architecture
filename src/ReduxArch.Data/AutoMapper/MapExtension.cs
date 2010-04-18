using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace ReduxArch.Data.AutoMapper
{
    public static class MapExtension
    {
        public static TDest Map<TSource, TDest>(this TSource model)
        {
            return Mapper.Map<TSource, TDest>(model);
        }

        public static IEnumerable<TDest> Map<TSource, TDest>(this IEnumerable<TSource> model)
        {
            return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDest>>(model);
        }
    }
}