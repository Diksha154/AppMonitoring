using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApplicationMoniteringApplication.Startup))]
namespace ApplicationMoniteringApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
