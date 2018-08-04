using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dappersample2018.Startup))]
namespace dappersample2018
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
