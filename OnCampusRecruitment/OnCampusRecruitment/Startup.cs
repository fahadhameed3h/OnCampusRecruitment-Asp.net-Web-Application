using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnCampusRecruitment.Startup))]
namespace OnCampusRecruitment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
