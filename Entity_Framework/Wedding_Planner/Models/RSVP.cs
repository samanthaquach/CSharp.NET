using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Collections.Generic;
using System;

namespace Wedding_Planner.Models
{
    public class RSVP : BaseEntity
    {
        public int id { get; set; }
        public User Guest { get; set; }
        public int Userid { get; set; }
        public int Planningid { get; set; }
        public Planning Planning { get; set; }

    }
}