using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using identiyOrnekCalisma.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using identiyOrnekCalisma.Models;
using System.Collections.Generic;
using identiyOrnekCalisma.Project;

namespace identiyOrnekCalisma.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<ApplicationUser> userManager;

        public HomeController()
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityDataContext()));
        }

        public ActionResult Index()
        {
            using (var context = new ProjectDataContext()) // DbContext'inizle aynı context adını kullanmalısınız
            {
                var allProjects = context.ProjectModels.ToList(); // Tüm projeleri çek

                return View(allProjects);
            }
        }
    }
}
