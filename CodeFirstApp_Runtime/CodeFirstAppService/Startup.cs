using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CodeFirstAppService.Startup))]

namespace CodeFirstAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}