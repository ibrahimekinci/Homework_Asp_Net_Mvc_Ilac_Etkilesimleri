using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ilac_etkilesimleri.Startup))]
namespace ilac_etkilesimleri
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
