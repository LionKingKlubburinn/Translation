using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Translation.Startup))]
namespace Translation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
