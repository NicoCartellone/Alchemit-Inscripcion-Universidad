using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inscripcion_Universidad.Models.ViewModels
{
    public class AssignRolesUsersViewData
    {
        public IEnumerable<string> users { get; set; }
        public IEnumerable<string> roles { get; set; }
    }
}