using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ReduxArch.Web
{
    public static class TinyMceExtensions
    {
        public static Dictionary<string, object> DefaultArray { get; set; }

        static TinyMceExtensions()
        {
            DefaultArray = new Dictionary<string, object>
                               {
                                   {"mode", "'textareas'"},
                                   {"theme", "'advanced'"},
                                   {"editor_selector", "'mceEditor'"},
                                   {
                                       "theme_advanced_buttons1",
                                       "'mymenubutton,bold,italic,underline,separator,strikethrough,justifyleft,justifycenter,justifyright,justifyfull,bullist,numlist,undo,redo,link,unlink,'"
                                       },
                                   {"theme_advanced_buttons2", "''"},
                                   {"theme_advanced_buttons3", "''"},
                                   {"theme_advanced_toolbar_location", "'top'"},
                                   {"theme_advanced_toolbar_align", "'left'"}
                               };
        }

        /// <summary>
        /// Requires the tinyMCE javascript library.
        /// </summary>
        /// <param name="htmlHelper">
        /// The html helper.
        /// </param>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <typeparam name="TModel">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public static MvcHtmlString TinyMceFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression)
        {
            return TinyMceFor<TModel>(htmlHelper, expression, DefaultArray);
        }

        /// <summary>
        /// Requires the tinyMCE javascript library.
        /// </summary>
        /// <param name="htmlHelper">
        /// The html helper.
        /// </param>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <param name="jQueryArray">
        /// The jQueryArray.
        /// </param>
        /// <typeparam name="TModel">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public static MvcHtmlString TinyMceFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, Dictionary<string, object> jQueryArray)
        {
            var sb = new StringBuilder();
            sb.Append("tinyMCE.init({");
            sb.Append(JavaScriptHelper.ArrayParser(jQueryArray));
            sb.Append("});");

            var builder = new TagBuilder("script");
            builder.MergeAttribute("type", "text/javascript");
            builder.SetInnerText(sb.ToString());
	
            var textArea = htmlHelper.TextAreaFor(model => model, new {@class = "mceEditor", stye = "width: 100%;"});

            return MvcHtmlString.Create(textArea.ToString() + builder.ToString(TagRenderMode.Normal));
        }
    }
}
