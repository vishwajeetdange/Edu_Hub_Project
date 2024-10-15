using System;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using MVC_EduHub_Project.Models;

namespace MVC_EduHub_Project.Services
{
	public interface IUserService
	{
		User CreateUser(User newuser);
		User StudentLogin(LoginModel user);
		User EducatorLogin(LoginModel loginModel);
	} 
  
}