﻿using System.Web;
using System.Web.Mvc;

namespace MVC50Ders2_StatikMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
