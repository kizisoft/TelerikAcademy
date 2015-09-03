using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormsSumApp.Startup))]
namespace WebFormsSumApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
