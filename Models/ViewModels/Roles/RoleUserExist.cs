using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inscripcion_Universidad.Models.ViewModels
{
    public class RoleUserExist
    {
        public RoleUserExist()
        {
            this.HasRole = true;
        }
        public string RoleName { get; set; }
        public bool HasRole { get; set; }
    }
}