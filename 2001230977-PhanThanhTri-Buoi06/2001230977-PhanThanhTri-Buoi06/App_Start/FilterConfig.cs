using System.Web;
using System.Web.Mvc;

namespace _2001230977_PhanThanhTri_Buoi06
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}