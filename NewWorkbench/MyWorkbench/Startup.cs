using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyWorkbench.Startup))]
namespace MyWorkbench
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
