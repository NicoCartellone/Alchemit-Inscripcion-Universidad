using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inscripcion_Universidad.Models.ViewModels
{
    public class UserRolesViewData
    {
        public IEnumerable<RolesByUser> RolesByUser { get; set; }
    }
}