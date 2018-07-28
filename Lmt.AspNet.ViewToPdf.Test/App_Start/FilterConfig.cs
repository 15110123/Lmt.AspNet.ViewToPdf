using System.Web;
using System.Web.Mvc;

namespace Lmt.AspNet.ViewToPdf.Test
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
