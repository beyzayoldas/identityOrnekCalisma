using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

[assembly: OwinStartup(typeof(identiyOrnekCalisma.IdentityConfig))]

namespace identiyOrnekCalisma
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            // Uygulamanızı nasıl yapılandıracağınız hakkında daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=316888 adresini ziyaret edin

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType=DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}
