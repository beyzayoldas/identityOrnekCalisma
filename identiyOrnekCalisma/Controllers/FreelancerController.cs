using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace identiyOrnekCalisma.Controllers
{
    [Authorize(Roles = "Freelancer")]
    public class FreelancerController : Controller
    {
        public ActionResult JobAcceptance()
        {
            return View();
        }
    }
}