using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_EduHub_Project
{
    public class UserCreateViewModel
    {
        
        [Required(ErrorMessage = "Name is Must")]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is Must")]
        [MinLength(8), MaxLength(15)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        public string Role { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Enter valid Phone number")]
        [Required]
        public string Mobile_no { get; set; }
        public IFormFile Photo { get; set; }


    }
}