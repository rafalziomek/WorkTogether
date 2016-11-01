using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkTogether.Models
{
    public class WorkDay
    {
        public WorkDay()
        {
        }
        [Key]
        [Display(Name = "Id dnia pracy:")]
        public int Id { get; set; }

        [Display(Name = "Opis:")]
        [MaxLength(160)]
        public string Description { get; set; }

        [Display(Name = "Wydział:")]
        [MaxLength(30)]
        public string Department { get; set; }

        [Display(Name = "Początek pracy:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartWork { get; set;  }

        [Display(Name = "Koniec pracy:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndWork { get; set; }

        public int WorkWeekId { get; set; }
        public WorkWeek WorkWeek { get; set; }
    }
}