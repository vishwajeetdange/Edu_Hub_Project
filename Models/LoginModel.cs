using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_EduHub_Project.Models
{
	public class LoginModel
	{
		[Key]
		public string UserName { get; set; }
		[Required]
		public string Password { get; set; }
				
	  
	}
}