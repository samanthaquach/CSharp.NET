using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Form_Submission.Models
{

    public class FormContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public FormContext(DbContextOptions<FormContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }

    

    public abstract class BaseEntity {}
    public class User : BaseEntity
    {
        public int id { get; set; }

        [Required(ErrorMessage = "First name cannot be left blank.")]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters in length.")]
        [Display(Name = "First Name")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "Last name cannot be left blank.")]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters in length.")]
        public string lastname { get; set; }

        [Required(ErrorMessage = "Restaurant name cannot be left blank.")]
        public string restaurant { get; set; }

        [Required(ErrorMessage = "Review cannot be left blank.")]
        [MinLength(10, ErrorMessage = "Review must be at least 10 characters in length.")]
        public string review { get; set; }

        [Required(ErrorMessage = "Date of Visit cannot be left blank.")]
        [DataType(DataType.DateTime)]
        public string datevisit { get; set; }

        [Required(ErrorMessage = "Rating cannot be left blank.")]
        public int rating { get; set; }

        
    }
    public class LogUser : BaseEntity
    { 
        [Required(ErrorMessage = "Email address cannot be left blank")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password cannot be left blank")]
        public string password { get; set; }
    }

    public class LoginRegViewModel : BaseEntity
    {
        public LogUser loginVM { get; set; }
        public User registerVM { get; set; }
    }
}