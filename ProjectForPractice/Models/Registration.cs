using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectForPractice.Models
{
    public class Registration
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        [Required]

        public string Gender { get; set; }
        [Required]

        public string Profile { get; set; }
        [Required]

        public string Qualification { get; set; }
        [Required]

        public string DOB { get; set; }
        [Required]

        public string State { get; set; }
        [Required]

        public string City { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]
        [Display(Name = "Pin Code")]
        public string PinCode { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]

        [Compare("Password")]
        [Display(Name ="Confirm Password")]
        public string Confirm_Password { get; set; }
    }
}