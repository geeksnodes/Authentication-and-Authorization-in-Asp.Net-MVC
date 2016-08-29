using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomAuth.Startup))]
namespace CustomAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
