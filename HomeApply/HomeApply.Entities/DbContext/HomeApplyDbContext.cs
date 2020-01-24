using HomeApply.Entities.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApply.Entities.DbContext
{
    public class ApplicationUser : IdentityUser
    {
        public int ProviderId { get; set; }
        public string ProviderType { get; set; }
    }
    public class HomeApplyContext : IdentityDbContext<ApplicationUser>
    {
        public HomeApplyContext(DbContextOptions options) : base(options)
        {

        }
        DbSet<Users> User { get; set; }

    }
}
