using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Inscripcion_Universidad.Startup))]
namespace Inscripcion_Universidad
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
