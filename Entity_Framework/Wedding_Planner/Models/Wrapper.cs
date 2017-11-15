using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Wedding_Planner.Models
{
    public class Wrapper : BaseEntity
    {
        public List<User> Users { get; set; }
        public List<Planning> Planning { get; set; }
        public List<RSVP> RSVP { get; set; }

        public Wrapper(List<User> theUsers, List<Planning> thePlans, List<RSVP> theGuests)
        {
            Users = theUsers;
            Planning = thePlans;
            RSVP = theGuests;

        }
    }
}