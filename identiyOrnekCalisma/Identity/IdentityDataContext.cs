// IdentityDataContext.cs
using identiyOrnekCalisma.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace identiyOrnekCalisma.Identity
{
    public class IdentityDataContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext() : base("identityConnection")
        {
        }
    }
}
