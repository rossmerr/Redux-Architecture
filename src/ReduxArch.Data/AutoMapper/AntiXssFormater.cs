using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace ReduxArch.Data.AutoMapper
{
    public class AntiXssFormater : ValueFormatter<string>
    {
        protected override string FormatValueCore(string value)
        {
            return Microsoft.Security.Application.AntiXss.HtmlEncode(value);
        }
    }
}
