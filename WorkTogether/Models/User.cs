using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace WorkTogether.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public User()
        {
            this.UserTimeTable = new HashSet<WorkWeek>();
        }
        [Display(Name = "Imię:")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko:")]
        public string LastName { get; set; }
        [Display(Name = "Data urodzenia:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [NotMapped]
        [Display(Name = "Pan/Pani:")]
        public string Name { get { return FirstName + " " + LastName; } }

        public virtual ICollection<WorkWeek> UserTimeTable { get; private set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}