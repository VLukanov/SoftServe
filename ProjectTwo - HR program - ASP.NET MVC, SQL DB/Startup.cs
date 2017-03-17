using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demo2._1.Startup))]
namespace Demo2._1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
