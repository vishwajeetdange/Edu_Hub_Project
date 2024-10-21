using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Repository;
using MVC_EduHub_Project.Services;
using NuGet.Protocol.Core.Types;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace MVC_EduHub_Project.Controllers;

// UserController handles user-related actions such as registration, login, and profile management
public class UserController : Controller
{
	// Dependencies injected through constructor
	public readonly IUserService _userservice;
	private readonly IHostingEnvironment _hostEnviroment;
	public UserController(IUserService userservice, IHostingEnvironment hostEnviroment)

	{
		_userservice = userservice;
		_hostEnviroment = hostEnviroment;

	}

	public IActionResult Index()
	{
		return View();
	}
	
	// Display educator's profile
	public IActionResult EducatorIndex()
	{
		TempData.Keep();
		var id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
		var data = _userservice.EducatorData(id);
		return View(data);
	}
	
	// Display student's profile
   public IActionResult StudentIndex()
	{
		TempData.Keep();
		var id = Convert.ToInt32(HttpContext.Session.GetString("StudUserId"));
		var data = _userservice.StudentData(id);
		return View(data);
	}
	
	// GET: Display user registration form
	[HttpGet]
	public IActionResult AddUser()
	{
		try

		{

			List<SelectListItem> userroles = new List<SelectListItem>()
				{
				new SelectListItem { Text = "Educator", Value = "Educator" },
				new SelectListItem{ Text="Student",Value="Student"},
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
	
	// POST: Handle user registration
	[HttpPost]
	public IActionResult AddUser(UserCreateViewModel model)
	{
		try
		{
		if (ModelState.IsValid)
		{
			string uniqueFileName = null;
			if (model.Photo != null)
			{
				string uploadsFolder = Path.Combine(_hostEnviroment.WebRootPath, "assests/userimages");
				uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
				string filePath = Path.Combine(uploadsFolder, uniqueFileName);
				model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
			}
			User newuser = new User

			{
				UserName = model.UserName,
				Password = model.Password,
				Role = model.Role,
				Email = model.Email,
				Mobile_no = model.Mobile_no,
				ProfileImage = uniqueFileName

			};

			_userservice.CreateUser(newuser);
			TempData["successmsg"] = "Registration SuccessFull";
			return RedirectToAction("Index", "Home");
		
		}
		}
		catch (Exception ex)

		{
			TempData["errormsg"] = ex.Message;
		}
			return View();
		
	}
	
	// GET: Display student login form
	[HttpGet]
	public IActionResult Student_Login()

	{
		return View();
	}
	
	// POST: Handle student login
	[HttpPost]
	public IActionResult Student_Login(LoginModel loginModel)

	{	
				var data = _userservice.StudentLogin(loginModel);
				if (data != null)
				{
					HttpContext.Session.SetString("StudUserId", data.UserId.ToString());
					TempData["Student"] = loginModel.UserName;
					TempData.Keep();
					TempData["successmsg"] = "Login SuccessFull";
					return RedirectToAction("StudentIndex", "User");
				}
				else
				{
					TempData["errormsg"] = "Login Failed!";
					return View();
				}
		
	}
	
	// GET: Display Educator  login form
	[HttpGet]
	public IActionResult Educator_Login()

	{
		return View();
	}

	// POST: Handle Educator login
	[HttpPost]
	public IActionResult Educator_Login(LoginModel loginModel)

	{
		
		var data = _userservice.EducatorLogin(loginModel);		
		
		if (data != null)

		{
		HttpContext.Session.SetString("UserId", data.UserId.ToString());
			TempData["Educator"] = loginModel.UserName;
			TempData.Keep();
			TempData["successmsg"] = "Login SuccessFull";
			return RedirectToAction("EducatorIndex", "User");
		}
		else
		{
			TempData["errormsg"] = "Login Failed!";
			return View();
		}
	}

	// Perform  LogOut Method
	public ActionResult LogOut()
	{
		return RedirectToAction("Index", "Home");
	}

	
}
