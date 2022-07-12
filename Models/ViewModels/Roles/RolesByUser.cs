using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inscripcion_Universidad.Models.ViewModels
{
    public class RolesByUser
    {
        public RolesByUser()
        {
            this.RolesUser = new List<RoleUserExist>();
        }
        public string UserName { get; set; }
        public List<RoleUserExist> RolesUser { get; set; }
    }
}