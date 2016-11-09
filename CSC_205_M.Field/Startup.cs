using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSC_205_M.Field.Startup))]
namespace CSC_205_M.Field
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
