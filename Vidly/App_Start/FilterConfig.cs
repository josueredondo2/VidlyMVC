using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //Le aplica la regla de estar logueado a todos 
            filters.Add(new AuthorizeAttribute());
            //Solicita que la conexion tenga centificado de seguridad https
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
