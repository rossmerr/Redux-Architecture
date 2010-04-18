using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace ReduxArch.Web
{
    /// <summary>
    /// Strongly type to SelectListItem
    /// </summary>
    public static class SelectListItemExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectList<TModel>(this IEnumerable<TModel> collection, Expression<Func<TModel, object>> text,
                    Expression<Func<TModel, string>> value)
        {
            var model = new List<TModel>();
            return collection.ToSelectList(text, value, model);
        }

        public static IEnumerable<SelectListItem> ToSelectList<TModel>(this IEnumerable<TModel> collection, Expression<Func<TModel, object>> text,
            Expression<Func<TModel, string>> value, TModel selected)
        {
            var model = new List<TModel> { selected };
            return collection.ToSelectList(text, value, model);
        }

        public static IEnumerable<SelectListItem> ToSelectList<TModel>(this IEnumerable<TModel> collection, Expression<Func<TModel, object>> text,
            Expression<Func<TModel, string>> value, IEnumerable<TModel> selected)
        {
            var dlgText = (Func<TModel, object>)CreatePropertyDelegate<TModel>(ExpressionHelper.GetExpressionText(text));
            var dlgValue = (Func<TModel, object>)CreatePropertyDelegate<TModel>(ExpressionHelper.GetExpressionText(value));

            if (dlgText == null) throw new NullReferenceException("Text Property not found");

            if (dlgValue == null) throw new NullReferenceException("Value Property not found");

            if (selected.Count() > 0)
            {
                var selectedValues = selected.Select(model => dlgValue(model).ToString()).ToList();

                return collection.Select(p => new SelectListItem
                {
                    Text = dlgText(p).ToString(),
                    Value = dlgValue(p).ToString(),
                    Selected = selectedValues.Contains(dlgValue(p).ToString())
                });
            }

            return collection.Select(p => new SelectListItem
            {
                Text = dlgText(p).ToString(),
                Value = dlgValue(p).ToString()
            });
        }

        private static Delegate CreatePropertyDelegate<TModel>(string property)
        {
            var propertyInfo = typeof(TModel).GetProperty(property);

            var method = propertyInfo.GetAccessors(true);
            if (method != null && method.Count() > 0)
            {
                return Delegate.CreateDelegate(typeof(Func<TModel, object>), method.First());
            }

            return null;
        }
    }
}
