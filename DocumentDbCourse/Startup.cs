using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DocumentDbCourse.Startup))]
namespace DocumentDbCourse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
