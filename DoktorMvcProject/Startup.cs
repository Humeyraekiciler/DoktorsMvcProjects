using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoktorMvcProject.Startup))]
namespace DoktorMvcProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
