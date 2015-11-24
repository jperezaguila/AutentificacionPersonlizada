using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using AutentificacionPersonlizada.Models;
using AutentificacionPersonlizada.Utilidades;

namespace AutentificacionPersonlizada.Seguridad
{
    //Almacenar en memoria la informacion del usuario que me interese
    class UsuarioMembership:MembershipUser

    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string imagen { get; set; }

        public override String Email { get; set; }

        public String  Rol { get; set; }

        //Creacion de un constructor
        public UsuarioMembership(Usuario us)
        {
            var clave = ConfigurationManager.AppSettings["ClaveCifrado"];
            id = us.id;
            nombre = us.nombre;
            apellidos = us.apellidos;
            imagen = us.imagen;
            Rol = us.Rol.nombre;
            Email  = SeguridadUtilidades.Descifrar(Convert.FromBase64String(us.email), clave);
            login = us.login;

        }
    }

}
