using System.Web;
using System.Web.Mvc;

namespace AGA_SCE_CLIENTE
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
