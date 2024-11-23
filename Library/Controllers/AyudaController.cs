using System.Web.Mvc;

namespace Biblioteca.Controllers
{
    public class AyudaController : Controller
    {
        // Acción para mostrar la vista con información de contacto
        [HttpGet]
        public ActionResult Ayuda()
        {
            // Información de contacto
            ViewBag.Contacto = "Si necesitas ayuda, contáctanos al correo: soporte@biblioteca.com o al teléfono: +123 456 789.";
            return View();
        }
        public ActionResult Index()
        {
            return RedirectToAction("Ayuda");
        }

        // Acción para redirigir a la ayuda
        [HttpGet]
        public ActionResult ObtenerAyuda()
        {
            return RedirectToAction("Ayuda");
        }
    }
}
