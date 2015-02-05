using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(matidesign.Startup))]
namespace matidesign
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
