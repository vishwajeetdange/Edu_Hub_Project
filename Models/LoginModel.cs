using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_EduHub_Project
{
	public class LoginModel
	{
		[Key]
		public string UserName { get; set; }
		
		public string Password { get; set; }
				
	  
	}
}