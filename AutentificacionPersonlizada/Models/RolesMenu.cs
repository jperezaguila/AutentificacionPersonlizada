//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutentificacionPersonlizada.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RolesMenu
    {
        public int idRol { get; set; }
        public int idMenu { get; set; }
        public int orden { get; set; }
    
        public virtual Menu Menu { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
