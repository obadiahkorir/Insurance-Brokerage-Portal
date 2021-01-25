using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KYM_Portal.Startup))]
namespace KYM_Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
