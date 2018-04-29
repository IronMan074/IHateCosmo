using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AzureCosmosDBA.Startup))]
namespace AzureCosmosDBA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
