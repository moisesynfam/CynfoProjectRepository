using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace CynfoProject.Models
{


    public class RegistrationModel
    {

        [Required(ErrorMessage = " An Entity name is required.")]
        public string Entity { get; set; }

        [Required(ErrorMessage = " An email address is required.")]
        [EmailAddress(ErrorMessage ="Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "An Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = " Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Please confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }

    public class LoginModel
    {
        [Required(ErrorMessage = "An Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = " Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }


    }