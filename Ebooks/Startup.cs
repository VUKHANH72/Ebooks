using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ebooks.Startup))]
namespace Ebooks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
