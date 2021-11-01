using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Language2.Middleware
{
    public class ChangeLanguage
    {
        RequestDelegate _next;
        public ChangeLanguage(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var lang = context.Request.Query["culture"].ToString();
            if(lang != "")
            {
                context.Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(new CultureInfo(lang))));
            }
            await _next.Invoke(context);
        }

    }
}
