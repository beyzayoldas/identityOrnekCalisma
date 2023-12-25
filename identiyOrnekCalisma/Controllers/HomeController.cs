using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using identiyOrnekCalisma.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            //var userId = User.Identity.GetUserId();
            //var userRoles = userManager.GetRoles(userId);

            //if (userRoles.Contains("Freelancer"))
            //{
            //    return RedirectToAction("JobAcceptance", "Freelancer");
            //}
            //else if (userRoles.Contains("Customer"))
            //{
            //    return RedirectToAction("JobAssignment", "Customer");
            //}
            //else
            //{
            //    // Diğer roller için varsayılan sayfa veya hata sayfasına yönlendirme yapabilirsiniz.
            //    return View();
            //}

            return View();

        }
    }
}
