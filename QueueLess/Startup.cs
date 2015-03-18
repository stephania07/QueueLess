using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QueueLess.Startup))]
namespace QueueLess
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
