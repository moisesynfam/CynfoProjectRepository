using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

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

    public class Place
    {

        [Key]
        public string PlaceID { get; set; }

        [Required(ErrorMessage ="A place name is required.")]
        public string PlaceName { get; set; }

        public string PlaceDescription { get; set; }
        
        public string PlaceLogoURL { get; set; }

        [Required(ErrorMessage = "A place identifier is required.")]
        [Display(Name = "Place Identifier")]
        public int PlaceMajor { get; set; }

        [Required(ErrorMessage = "A place must have an address")]
        public string PlaceAddress { get; set; }

        [Required(ErrorMessage = "A telephone number is required")]
        [DataType(DataType.PhoneNumber)]
        public string Placecontact { get; set; }
       
        public int UserID { get; set; }


    }

}