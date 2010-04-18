using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace ReduxArch.Web
{
    public static class HtmlExtension
    {
        public static string ForId<TModel, TProperty>(this System.Web.Mvc.HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            return htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
        }

        public static string ForName<TModel, TProperty>(this System.Web.Mvc.HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            return htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
        }

        public static string DisplayName<TModel, TProperty>(this System.Web.Mvc.HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).DisplayName;
        }
        
        public static IEnumerable<SelectListItem> DefaultSelectListItem(this IEnumerable<SelectListItem> selectListItems, string text)
        {
            return DefaultSelectListItem(selectListItems, text, string.Empty);
        }

        public static IEnumerable<SelectListItem> DefaultSelectListItem(this IEnumerable<SelectListItem> selectListItems, string text, string value)
        {
            var list = selectListItems.ToList();
            list.Insert(0, new SelectListItem { Text = text, Value = value });
            return list;           
        }
    }
}