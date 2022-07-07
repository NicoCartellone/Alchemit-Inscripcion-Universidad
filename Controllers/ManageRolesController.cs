using Inscripcion_Universidad.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Inscripcion_Universidad.Controllers
{
    public class ManageRolesController : Controller
    {
        ApplicationDbContext context;
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //Default Constructor context
        public ManageRolesController()
        {
            context = new ApplicationDbContext();
        }

        //GET: /ManageUsers
        public ActionResult Index()
        {
            return RedirectToAction("RolesProUsuario");
        }

        //GET: /ManageUsers/CrearRol
        public ActionResult CrearRol()
        {
            var roles = context.Roles.OrderBy(r => r.Name).ToList();
            ViewBag.ResultMessage = "";
            return View(roles);
        }

        //POST: /ManageUsers/CrearRol
        [HttpPost]
        public async Task<ActionResult> CrearRol(FormCollection collection)
        {
            try
            {
                context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = collection["RoleName"]
                });
                await context.SaveChangesAsync();
                ViewBag.ResultMessage = collection["RoleName"].ToString();

                var roles = await context.Roles.OrderBy(r => r.Name).ToListAsync();

                return View("CrearRol", roles);
            }
            catch
            {
                return View();
            }
        }
    }
}