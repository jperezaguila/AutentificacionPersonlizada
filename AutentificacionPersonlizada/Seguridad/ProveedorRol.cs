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
    //Encargada de gestionar los roles , RoleProvider es una clase abtracta y define todas las operaciones a implementar para un rol

    public class ProveedorRol:RoleProvider
    {
        //devuelve un booleano
        public override bool IsUserInRole(string username, string roleName)
        {
            var clave = ConfigurationManager.AppSettings["ClaveCifrado"];
            var cif = SeguridadUtilidades.Cifrar(username, clave);
            using (var db=new autenticacionEntities())
            {
                var us = db.Usuario.First(o => o.login == cif);
                try
                {
                    return us.Rol.nombre == roleName;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        //
        public override string[] GetRolesForUser(string username)
        {
            var clave = ConfigurationManager.AppSettings["ClaveCifrado"];
            var cif = SeguridadUtilidades.Cifrar(username, clave);
            using (var db = new autenticacionEntities())
            {
                var us = db.Usuario.First(o => o.login == cif);
                try
                {
                    return new[] {us.Rol.nombre};
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }


        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}
