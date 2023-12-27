using identiyOrnekCalisma.Project;
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
        private ProjectDataContext dbContext;

        public FreelancerController()
        {
            dbContext = new ProjectDataContext();
        }

        [HttpGet]
        public ActionResult JobAcceptance(string search)
        {
            var projects = dbContext.ProjectModels.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                projects = projects.Where(p =>
                    p.ProjectTitle.Contains(search) || p.Description.Contains(search));
            }

            var availableProjects = projects.ToList();
            return View(availableProjects);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplyForJob(int projectId)
        {
            // Başvuru işlemlerini gerçekleştir (örneğin, veritabanına başvuruyu kaydet)
            // ...

            return RedirectToAction("JobAcceptance");
        }
    }

}