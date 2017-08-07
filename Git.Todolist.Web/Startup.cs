using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Git.Todolist.Web.Startup))]
namespace Git.Todolist.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
