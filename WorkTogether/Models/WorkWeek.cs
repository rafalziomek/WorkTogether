using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WorkTogether.Models
{
    public class WorkWeek
    {
        public WorkWeek()
        {
            this.WorkDay = new HashSet<WorkDay>();
        }

        [Key]
        [Display(Name = "Id tygodnia pracy:")]
        public int Id { get; set; }

        [Display(Name = "Początek tygodnia:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartWeek { get; set; }

        [NotMapped]
        [Display(Name = "Koniec tygodnia:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndWeek
        {
            get { return StartWeek.AddDays(7); }
        }

        //One to many with User connection
        public string UserId { get; set; }
        public virtual User User { get; set; }

        //One to many with WorkDay connection
        public virtual ICollection<WorkDay> WorkDay { get; private set; }
    }
}