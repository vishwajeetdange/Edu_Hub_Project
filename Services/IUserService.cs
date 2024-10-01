using System;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace MVC_EduHub_Project.Services
{
	public interface IUserService
	{
		User CreateUser(User newuser);
		bool StudentLogin(LoginModel user);
		bool EducatorLogin(LoginModel loginModel);
	} 
  
}