using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoPeluqueriaFinal.Startup))]
namespace ProyectoPeluqueriaFinal
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
