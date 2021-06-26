using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Directionary.Startup))]
namespace Directionary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
