using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstProjectCMS.Utilities
{
        public static class YesNoHtmlHelper
        {
            public static MvcHtmlString YesNo(this HtmlHelper htmlHelper, bool yesNo)
            {
                var text = yesNo ? "فعال" : "غیرفعال";
                return new MvcHtmlString(text);
            }
        }
}