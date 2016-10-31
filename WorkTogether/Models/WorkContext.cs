using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WorkTogether.Models
{
    public class WorkContext : IdentityDbContext
    {
        public WorkContext()
            : base("DefaultConnection")
        {
        }

        public static WorkContext Create()
        {
            return new WorkContext();
        }

        public DbSet<WorkDay> WorkDay { get; set; }
        public DbSet<WorkWeek> WorkWeek { get; set; }
        public DbSet<User> User { get; set; }

    }
}