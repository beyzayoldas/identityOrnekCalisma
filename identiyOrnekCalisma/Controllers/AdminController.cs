using identiyOrnekCalisma.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace identiyOrnekCalisma.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> userManager;

        public AdminController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager = new UserManager<ApplicationUser>(userStore);
        }
        // GET: Admin
        public ActionResult Index()
        {
            // userManager.Users koleksiyonunun eleman sayısını al
            int userCount = userManager.Users.Count();

            // Daha sonra istediğiniz işlemleri gerçekleştirebilirsiniz
            // Örneğin, ViewBag aracılığıyla View'a gönderme:
            ViewBag.UserCount = userCount;
            return View(userManager.Users);
        }
    }
}