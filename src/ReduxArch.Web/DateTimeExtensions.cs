using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ReduxArch.Web
{
    public static class DateTimeExtensions
    {
        public static Dictionary<string, object> DefaultArray { get; set; }

        static DateTimeExtensions()
        {
            DefaultArray = new Dictionary<string, object>
                               {
                                   {"duration", "''"},
                                   {"showTime", "true"},
                                   {"constrainInput", "true"},
                                   {"dateFormat", "'dd/mm/yy'"},
                                   {"time24h", "true"}
                               };
        }


        public static MvcHtmlString DateTimeFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression)
        {
            DateTime flag;
            var metadata = ModelMetadata.FromLambdaExpression<TModel, bool>(expression, htmlHelper.ViewData);
            DateTime? dateTime = null;
            if ((metadata.Model != null) && DateTime.TryParse(metadata.Model.ToString(), out flag))
            {
                dateTime = new DateTime?(flag);
            }

            var modelId = htmlHelper.ForId(model => model);
            var modelName = htmlHelper.ForName(model => model);

            htmlHelper.TextBox(string.Empty, dateTime.HasValue ? dateTime.Value.ToString("dd/MM/yyyy hh:mm") : string.Empty, new {id = modelId, name = modelName});

            htmlHelper.CheckBox("CheckBox", !dateTime.HasValue, new {id = modelId + ".CheckBox", target = modelId});

            var sb = new StringBuilder();
            sb.Append("$(function() {");
            sb.Append(string.Format("$(#{0}).datepicker(", modelId));
            sb.Append("{");
            sb.Append(JavaScriptHelper.ArrayParser(DefaultArray));
            sb.Append("});");

            if(dateTime.HasValue)
            {
                sb.Append(string.Format("\n$(#{0}).attr('disabled', 'disabled');", modelId));
            }

            return null;
        }
    }
}
