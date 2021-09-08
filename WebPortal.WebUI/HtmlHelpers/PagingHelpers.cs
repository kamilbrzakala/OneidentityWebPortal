using System;
using System.Text;
using System.Web.Mvc;
using WebPortal.WebUI.Models;

namespace WebPortal.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        /*
         * PageLinks is extension method for HtmlHelper
          Extension methods are defined as static methods but are called by using instance method syntax.
          Their first parameter specifies which type the method operates on.
          The parameter is preceded by the 'this' modifier.
          Extension methods are only in scope when you explicitly import the namespace into your source code with a using directive.
        */
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl) 
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

    }
}