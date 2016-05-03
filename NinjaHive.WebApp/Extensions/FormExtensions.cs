﻿using NinjaHive.WebApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using NinjaHive.Core.Extensions;

namespace NinjaHive.WebApp.Extensions
{
    public static class FormExtensions
    {
        public static MvcForm BeginForm<TController>(this HtmlHelper htmlHelper, Expression<Action<TController>> expression)
            where TController : Controller
        {
            return htmlHelper.BeginForm(expression, null);
        }

        public static MvcForm BeginForm<TController>(this HtmlHelper htmlHelper, Expression<Action<TController>> expression, object htmlAttributes)
            where TController : Controller
        {
            var urlParts = UrlProvider<TController>.GetRouteValues(expression);

            var controller = urlParts["controller"].ToString();
            var action = urlParts["action"].ToString();
            return htmlHelper.BeginForm(action, controller, FormMethod.Post, htmlAttributes);
        }

        
        public static MvcHtmlString FormGroupFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
                                                                 Expression<Func<TModel, TValue>> expression,
                                                                 object editorHtmlAttributes = null,
                                                                 object containerHtmlAttributes = null)
        {
            var containerAttributes = containerHtmlAttributes ?? new { @class = "form-group" };
            var editorAttributes = editorHtmlAttributes ?? new { @class = "form-control" };



            var builder = new StringBuilder();
            builder.AppendLine( htmlHelper.BeginElement("div", containerAttributes).ToHtmlString() );
            builder.AppendLine(htmlHelper.LabelFor(expression, new { @class = "col-md-4 control-label" }).ToHtmlString());
            builder.AppendLine("<div class='col-md-8'>");
            builder.AppendLine(htmlHelper.EditorFor(expression, new { htmlAttributes = editorAttributes }).ToHtmlString());
            builder.AppendLine(htmlHelper.ValidationMessageFor(expression, "", new { @class = "text-danger" }).ToHtmlString());
            builder.AppendLine("</div></div>");

            return new MvcHtmlString(builder.ToString());
        }

        public static MvcHtmlString FormGroupFor<TModel>(this HtmlHelper<TModel> htmlHelper,
                                                         Expression<Func<TModel, bool>> expression,
                                                         object editorHtmlAttributes = null,
                                                         object containerHtmlAttributes = null)
        {
            var containerAttributes = containerHtmlAttributes ?? new { @class = "form-group" };
            var editorAttributes = editorHtmlAttributes ?? new {};

            var builder = new StringBuilder();
            builder.AppendLine(htmlHelper.BeginElement("div", containerAttributes).ToHtmlString());
            builder.AppendLine(htmlHelper.EditorFor(expression, new { htmlAttributes = editorAttributes }).ToHtmlString());
            builder.AppendLine(htmlHelper.LabelFor(expression, new { @class = "control-label" }).ToHtmlString());
            builder.AppendLine("</div>");

            return new MvcHtmlString(builder.ToString());
        }


        public static MvcHtmlString FormGroupFor<TModel,TValue>(this HtmlHelper<TModel> htmlHelper,
                                                            Expression<Func<TModel, TValue>> expression,
                                                            IEnumerable<SelectListItem> list,
                                                            object editorHtmlAttributes = null,
                                                            object containerHtmlAttributes = null)
        {
            var containerAttributes = containerHtmlAttributes ?? new { @class = "form-group" };
            var editorAttributes = editorHtmlAttributes ?? new { @class = "form-control"};


            var builder = new StringBuilder();
            builder.AppendLine(htmlHelper.BeginElement("div", containerAttributes).ToHtmlString());
            builder.AppendLine(htmlHelper.LabelFor(expression, new { @class = "col-md-4 control-label" }).ToHtmlString());
            builder.AppendLine("<div class='col-md-8'>");
            
            builder.AppendLine(htmlHelper.DropDownList(expression.GetPropertyNameFromExpression(),
                                                        list,
                                                        editorAttributes
                                                    ).ToHtmlString()
                                                );
            builder.AppendLine(htmlHelper.ValidationMessageFor(expression, "", new { @class = "text-danger" }).ToHtmlString());
            builder.AppendLine("</div></div>");

            return new MvcHtmlString(builder.ToString());
        }
    }
}