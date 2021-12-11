using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrogFraternityBeta.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }


        // Font Color will be simple strings like "red", "green", "blue" 
        // Then when FontColor is called, it will translate into an RGB value 
        public string fontColor { get; set; }

        // The profile pic will be a link stored in a string that points to an image 
        public string profilePic { get; set; }
    }

    public class RegisterViewModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Compare(nameof(Email))]
        [Required]
        [Display(Name = "Confirm Email")]
        [StringLength(200)]
        public string ConfirmEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(120, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Key]

        public int id { get; set; }
        [Required]
        [Display(Name = "Username or Email")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}