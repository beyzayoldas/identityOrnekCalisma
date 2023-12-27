using identiyOrnekCalisma.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace identiyOrnekCalisma.Project
{
    public class ProjectDataContext : DbContext
    {
        public DbSet<ProjectModel> ProjectModels { get; set; }

    }
}