using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Repository;
using MVC_EduHub_Project.Services;
using NuGet.Protocol.Core.Types;

namespace MVC_EduHub_Project.Controllers;

public class UserController : Controller
{
	//public	readonly	UserRepository _userRepository =null;
	public readonly IUserService _userservice;
	public UserController(IUserService userservice)

	{
		_userservice = userservice;

	}

	public IActionResult Index()
	{
		return View();
	}
	public IActionResult EducatorIndex()
	{
		return View();
	}
	public IActionResult StudentIndex()
	{
		return View();
	}

	[HttpGet]
	public IActionResult AddUser()
	{
		try

		{

			List<SelectListItem> userroles = new List<SelectListItem>()
				{
				new SelectListItem { Text = "Educator", Value = "Educator" },
				new SelectListItem{ Text="Student",Value="student"},
				};
			ViewBag.role = userroles;
			return View();
		}
		catch (Exception ex)

		{
			System.Console.WriteLine("my exception  " + ex.Message);
		}
		return View();
	}
	[HttpPost]
	public IActionResult AddUser(User newuser)
	{
		_userservice.CreateUser(newuser);
		return RedirectToAction("Index", "Home");
	}

	[HttpGet]
	public IActionResult Student_Login()

	{
		return View();
	}
	[HttpPost]
	public IActionResult Student_Login(LoginModel loginModel)

	{
     		var data = _userservice.StudentLogin(loginModel);
			HttpContext.Session.SetString("StudUserId", data.UserId.ToString());
		if (data != null)
		{
			TempData["Student"] = loginModel.UserName;
			return RedirectToAction("StudentIndex", "User");
		}
		else
		{
			//System.Console.WriteLine("Not login");
			return RedirectToAction("Student_Login", "User");
		}
	}

	[HttpGet]
	public IActionResult Educator_Login()

	{
		return View();
	}
	[HttpPost]
	public IActionResult Educator_Login(LoginModel loginModel)

	{
		// if (_userservice.EducatorLogin(loginModel))
		// {
		// 	//System.Console.WriteLine("Sucssefull");
		// 	TempData["Educator"] = loginModel.UserName;
		// //	TempData["UserId"] = loginModel.UserId;
		// 	return RedirectToAction("EducatorIndex", "User");
		// }
		var data = _userservice.EducatorLogin(loginModel);
		 //  var id =data.UserId;
		 HttpContext.Session.SetString("UserId",data.UserId.ToString());
		 	// TempData["UserId"]=data.UserId;
		 //  System.Console.WriteLine("id is : "+id);
		if (data != null)
		
		{
			TempData["Educator"] = loginModel.UserName;
		//	TempData["EducatorId"] = data.UserId;
			TempData.Keep();			
			return RedirectToAction("EducatorIndex", "User");
		}
		else
		{
			//System.Console.WriteLine("Not login");
			return RedirectToAction("Educator_Login", "User");
		}
	}
	public ActionResult LogOut()
	{
		return RedirectToAction("Index", "Home");
	}
	// public ActionResult EducatorLogOut()
	// {
	// 	return RedirectToAction("Index", "Home");
	// }


}
