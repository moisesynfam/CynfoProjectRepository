using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CynfoProject.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = " An Entity name is required.")]
        public string Entity { get; set; }

        [Required(ErrorMessage = " An email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "An Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = " Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

       
    }
}