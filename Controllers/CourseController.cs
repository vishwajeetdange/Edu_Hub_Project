using System;
using Microsoft.AspNetCore.Mvc;
using MVC_EduHub_Project.Services;
using MVC_EduHub_Project.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_EduHub_Project.Controllers
{
	public class CourseController : Controller
	{
	  
	  public readonly ICourseService _courseservice;
	  
	  public	CourseController(ICourseService courseService)
	  
	  {
			_courseservice = courseService;
	  }
	  
	  public IActionResult Index()
	  
	  {
	  	return View();
	  }
	  
	  [HttpGet]
	  public IActionResult AddCourse()
	  
	  {
			List<SelectListItem> courselevel = new List<SelectListItem>()
				{
				new SelectListItem { Text = "Beginner", Value = "Beginner" },
				new SelectListItem{ Text="Advanced",Value="Advanced"},
				new SelectListItem{ Text="Intermediate",Value="Intermediate"},
				};
			ViewBag.level = courselevel;
			return	View();
		
	  }
		[HttpPost]
		public IActionResult AddCourse(Course course)

		{
			
			course.userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
			_courseservice.CreateCourse(course);
			return RedirectToAction("EducatorIndex", "User");

		}

		[HttpGet]
		public IActionResult MyCourse()

		{
			//var id = Convert.ToInt32(TempData["EducatorId"]);
			
			var id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
			var data =_courseservice.GetCreatedCourseByUser(id);
			return View(data);

		}
		[HttpGet]
		public IActionResult MyCoursesStatusAccepted()

		{
			//var id = Convert.ToInt32(TempData["EducatorId"]);
			
			var id = Convert.ToInt32(HttpContext.Session.GetString("StudUserId"));
			var data =_courseservice.GetMyCourseStatusAccpeted(id);
			return View(data);

		}

		public IActionResult AllCourses()

		{

			var data = _courseservice.AllCourses();
			return View(data);

		}
		public IActionResult AllCourse()

		{

			var data = _courseservice.AllCourses();
			return View(data);

		}
		
		[HttpGet]
		public IActionResult Edit(int id)
		
		{
			List<SelectListItem> courselevel = new List<SelectListItem>()
				{
				new SelectListItem { Text = "Beginner", Value = "Beginner" },
				new SelectListItem{ Text="Advanced",Value="Advanced"},
				new SelectListItem{ Text="Intermediate",Value="Intermediate"},
				};
			ViewBag.level = courselevel;
			var data =_courseservice.GetCreatedCourseByCourseId(id);
			return	View(data);
		}


		[HttpPost]
		public IActionResult Edit(Course course, int id)

		{
			
			//System.Console.WriteLine("Id in controleler : "+id);
			_courseservice.EditCourse(course,id);
			return RedirectToAction("MyCourse", "Course");
			
			
		}

		[HttpGet]
		public IActionResult Details(int id)

		{
			var data = _courseservice.DetailsCourse(id);
			return View(data);
		}
		[HttpGet]
		public IActionResult ShowDetails(int id)

		{
			var data = _courseservice.DetailsCourse(id);
			return View(data);
		}

		

	}
}