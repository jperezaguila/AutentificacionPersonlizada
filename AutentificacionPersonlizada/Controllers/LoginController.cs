using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutentificacionPersonlizada.Models;
using AutentificacionPersonlizada.Utilidades;

namespace AutentificacionPersonlizada.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(Usuario model)
        {
            var clave = ConfigurationManager.AppSettings["ClaveCifrado"];
            if (Membership.ValidateUser(model.login, model.password))
            {
                var l = SeguridadUtilidades.Descifrar(Convert.FromBase64String(model.login), clave);
                FormsAuthentication.RedirectFromLoginPage(model.login, false);

                return null;

            }
            return View(model);
        }
    }

}