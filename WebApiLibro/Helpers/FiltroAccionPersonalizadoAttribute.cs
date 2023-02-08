using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics; //Habilita errores en el suceso de eventos de windows

namespace WebApiLibro.Helpers
{
    public class FiltroAccionPersonalizadoAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("Se ejecuto el filtro de accion OnActionExecuting - ocurre despues de ejecutar action");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
            Debug.WriteLine("Se ejecuto el filtro de accion OnActionExecuted - ocurre antes de ejecutar action");
        }
    }
}
