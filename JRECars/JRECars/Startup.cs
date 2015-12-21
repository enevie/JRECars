using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JRECars.Startup))]

namespace JRECars
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
