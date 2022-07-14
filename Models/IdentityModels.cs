using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Inscripcion_Universidad.Models.Dominio;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Inscripcion_Universidad.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Correlativa> Correlativas { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<MateriaPorCorrelativa> MateriaPorCorrelativas { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }

        public DbSet<HistorialAcademico> HistorialesAcademicos { get; set; }


        public System.Data.Entity.DbSet<Inscripcion_Universidad.Models.ViewModels.Materias.MateriasViewModel> MateriasViewModels { get; set; }
    }
}