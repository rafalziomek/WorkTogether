namespace WorkTogether.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<WorkTogether.Models.WorkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WorkTogether.Models.WorkContext context)
        {
            if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();
            SeedRoles(context);
            SeedUsers(context);
            SeedWorkWeek(context);
        }
        private void SeedRoles(WorkContext context)
        {
            var roleManager = new RoleManager<IdentityRole>
                 (new RoleStore<IdentityRole>());

            if(!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
        }
        private void SeedUsers(WorkContext context)
        {
            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);
            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var user = new User { UserName = "Admin", DateOfBirth = DateTime.Now};
                var adminresult = manager.Create(user, "Abcd123##");
                if (adminresult.Succeeded)
                    manager.AddToRole(user.Id, "Admin");
            }
        }
        private void SeedWorkWeek(WorkContext context)
        {
            var userId = context.Set<User>()
                .Where(u => u.UserName == "Admin")
                .FirstOrDefault().Id;
            
            for (int i = 0; i < 10; i++)
            {
                DateTime mondayInTheWeek = getLastMonday().AddDays(i * 7);
                var workWeek = new WorkWeek()
                {
                    Id = i,
                    UserId = userId,
                    StartWeek = mondayInTheWeek,
                    WorkDay = getCollectionOfWorkDays(mondayInTheWeek, i)
                };
                context.Set<WorkWeek>().AddOrUpdate(workWeek);
            }
            context.SaveChanges();
        }
        private DateTime getLastMonday()
        {
            DateTime d = DateTime.Today;
            int offset = d.DayOfWeek - DayOfWeek.Monday;
            DateTime lastMonday = d.AddDays(-offset);
            return lastMonday;
        }
        private ICollection<WorkDay> getCollectionOfWorkDays(DateTime firstDay, int workWeekId)
        {
            var WorkDays = new List<WorkDay>();
            for (int i = 0; i < 7; i++)
            {
                var WorkDay = new WorkDay()
                {
                    Id = i,
                    Department = "Department " + i,
                    Description = "Description " + i,
                    StartWork = firstDay.AddDays(i).Date.Add(new TimeSpan(6, 0, 0)),
                    EndWork = firstDay.AddDays(i).Date.Add(new TimeSpan(14, 0, 0)),
                    WorkWeekId = workWeekId
                };
                WorkDays.Add(WorkDay);
            }
            return WorkDays;
        }

        
        
    }
}
