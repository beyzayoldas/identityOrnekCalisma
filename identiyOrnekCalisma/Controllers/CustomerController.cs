using System;
using System.Linq;
using System.Web.Mvc;
using identiyOrnekCalisma.Models;
using identiyOrnekCalisma.Project; // Bu using ifadesi eklenmiştir
using Microsoft.AspNet.Identity;

namespace identiyOrnekCalisma.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        private ProjectDataContext dbContext;

        public CustomerController()
        {
            dbContext = new ProjectDataContext();
        }

        [HttpGet]
        public ActionResult JobAssignment()
        {
            return View();
        }
        public ActionResult MyProject() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitJob(ProjectModel project)
        {
            if (ModelState.IsValid)
            {
                project.CustomerName = User.Identity.Name;
                dbContext.ProjectModels.Add(project);
                dbContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View("JobAssignment", project);
        }

        [HttpGet]
        public ActionResult ProjectTable()
        {
            string customerName = User.Identity.Name;
            var customerProjects = dbContext.ProjectModels
                .Where(p => p.CustomerName == customerName)
                .ToList();

            return PartialView("_ProjectTable", customerProjects);
        }

        public ActionResult Edit(int id)
        {
            using (var context = new ProjectDataContext()) // DbContext'inizle aynı context adını kullanmalısınız
            {
                var project = context.ProjectModels.Find(id);

                if (project == null)
                {
                    return HttpNotFound(); // veya başka bir hata sayfasına yönlendirme yapabilirsiniz
                }

                return View(project);
            }
        }

        [HttpPost]
        public ActionResult SaveEdit(ProjectModel editedProject)
        {
            if (ModelState.IsValid)
            {
                using (var context = new ProjectDataContext()) // DbContext'inizle aynı context adını kullanmalısınız
                {
                    var existingProject = context.ProjectModels.Find(editedProject.ProjectId);

                    if (existingProject != null)
                    {
                        existingProject.ProjectTitle = editedProject.ProjectTitle;
                        existingProject.Description = editedProject.Description;
                        existingProject.Budget = editedProject.Budget;
                        existingProject.EndTime = editedProject.EndTime;

                        context.SaveChanges();

                        return RedirectToAction("JobAssignment"); // veya başka bir sayfaya yönlendirme yapabilirsiniz
                    }
                }
            }

            // Model doğrulama başarısızsa veya proje bulunamazsa aynı sayfada kal
            return View("Edit", editedProject);
        }

        public ActionResult Delete(int id)
        {
            using (var context = new ProjectDataContext()) // DbContext'inizle aynı context adını kullanmalısınız
            {
                var project = context.ProjectModels.Find(id);

                if (project == null)
                {
                    return HttpNotFound(); // veya başka bir hata sayfasına yönlendirme yapabilirsiniz
                }

                return View(project);
            }
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            using (var context = new ProjectDataContext()) // DbContext'inizle aynı context adını kullanmalısınız
            {
                var project = context.ProjectModels.Find(id);

                if (project == null)
                {
                    return HttpNotFound(); // veya başka bir hata sayfasına yönlendirme yapabilirsiniz
                }

                context.ProjectModels.Remove(project);
                context.SaveChanges();

                return RedirectToAction("JobAssignment"); // veya başka bir sayfaya yönlendirme yapabilirsiniz
            }
        }

    }
}
