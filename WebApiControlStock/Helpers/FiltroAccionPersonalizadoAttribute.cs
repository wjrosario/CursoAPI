using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebApiControlStock.Helpers
{
    public class FiltroAccionPersonalizadoAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("Se ejecuto el filtro de accion OnActionExecuted - ocurre despues de ejecutar action");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            Debug.WriteLine("Se ejecuto el filtro de accion nActionExecuting - ocurre antes de ejecutar action");
        }
    }
}
