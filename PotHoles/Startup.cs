using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PotHoles.Startup))]
namespace PotHoles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
