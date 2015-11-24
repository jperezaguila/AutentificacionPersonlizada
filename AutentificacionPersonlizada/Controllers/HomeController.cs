using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutentificacionPersonlizada.Utilidades;

namespace AutentificacionPersonlizada.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
       [Authorize]
        public ActionResult Index()
        {
            //Esta es una prueba antes de ìmplentar las clases en la carpeta Seguridad

            //var clave = ConfigurationManager.AppSettings["ClaveCifrado"];

            //var cifrado = SeguridadUtilidades.Cifrar("joseantonio.perez-ruibal@tajamar365.es", clave);

            //var data = Convert.FromBase64String(cifrado);

            //var descifrado = SeguridadUtilidades.Descifrar(data, clave);

            return View();
        }
    }
}