using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using InzeratnyPortal.Models;

namespace InzeratnyPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<InzeratnyPortal.Models.Category> Category { get; set; }
        public DbSet<InzeratnyPortal.Models.Item> Item { get; set; }

        public DbSet<AppUser> appUser;
    }
}
