using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Collections.Generic;
using System;

namespace Wedding_Planner.Models
{
    public class Planning : BaseEntity
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Wedder One cannot be left blank.")]
        [MinLength(2, ErrorMessage = "Wedder One must be at least 2 characters in length.")]
        [Display(Name = "Wedder One")]
        public string wedderone { get; set; }

        [Required(ErrorMessage = "Wedder Two cannot be left blank.")]
        [MinLength(2, ErrorMessage = "Wedder Two must be at least 2 characters in length.")]
        public string weddertwo { get; set; }

        [Required(ErrorMessage = "Date cannot be left blank.")]
        [FutureDate]
        [DataType(DataType.Date)]
        // public string date { get; set; }
        public DateTime date { get; set; }

        [Required(ErrorMessage = "Address cannot be left blank.")]
        public string address { get; set; }

        public int Userid { get; set; }

        public User User { get; set; }
        public RSVP RSVP { get; set; }
        // public List<RSVP> RSVP { get; set; }
        // public Planning()
        // {
        //     RSVP = new List<RSVP>();
        // }

    }

    public class RSVP : BaseEntity
    {
        public int id { get; set; }
        public User Guest { get; set; }
        public int Userid { get; set; }
        public int Planningid { get; set; }
        public Planning Planning { get; set; }

    }


    public class FutureDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = (DateTime)value;
            return date < DateTime.Now ? new ValidationResult("Date must be in future.") : ValidationResult.Success;
        }
    }

}