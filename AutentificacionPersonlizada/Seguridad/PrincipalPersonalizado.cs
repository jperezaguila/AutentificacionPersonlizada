using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AutentificacionPersonlizada.Seguridad
{
    public class PrincipalPersonalizado:IPrincipal
    {
        public bool IsInRole(string role)
        {
            //Es necesario obtener True/False 
            //if (MIdentityPersonalizado.Rol==role)
            //{
            //    return true;
            //  return false;
            //}

            return MIdentityPersonalizado.Rol == role;
        }

        public IIdentity Identity { get; private set; }

        public IdentityPersonalizado MIdentityPersonalizado
        {
            get { return (IdentityPersonalizado) Identity; }
            set { Identity = value; }
        }

        public PrincipalPersonalizado(IdentityPersonalizado identity)
        {
            Identity = identity;
        }

    }
}
