using System;
using Microsoft.AspNetCore.Mvc;
using MVC_EduHub_Project.Services;
using MVC_EduHub_Project.Repository;

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
	  	return	View();
		
	  }
		[HttpPost]
		public IActionResult AddCourse(Course course)

		{
			_courseservice.CreateCourse(course);
			return RedirectToAction("EducatorIndex", "User");

		}

		[HttpGet]
		public IActionResult MyCourse(int id)

		{
			id = (int)TempData["UserId"];
			var data =_courseservice.GetCreatedCourse(id);
			return View(data);

		}

		public IActionResult AllCourses()

		{

			var data = _courseservice.AllCourses();
			return View(data);

		}
		
		[HttpGet]
		public IActionResult Edit(int id)
		
		{
			//System.Console.WriteLine("Cours id" + id);
			var data =_courseservice.DetailsCourse(id);
			return	View(data);
		}


		[HttpPost]
		public IActionResult Edit(int id,Course course)

		{
			//System.Console.WriteLine("Id in controleler : "+id);
			_courseservice.EditCourse(id);
			return RedirectToAction("MyCourse", "Course");
			//var data = _courseservice.EditCourse(id);
			
		}

		[HttpGet]
		public IActionResult Details(int id)

		{
			var data = _courseservice.DetailsCourse(id);
			return View(data);
		}

		[HttpGet]
		public IActionResult Delete(int id)

		{
			//System.Console.WriteLine("Cours id" + id);
			var data = _courseservice.DetailsCourse(id);
			return View(data);
		}
		[HttpPost]
		public IActionResult Delete(Course course,int id)

		{
			//System.Console.WriteLine("Cours id" + id);
			var data = _courseservice.DeleteCourse(id);
			return RedirectToAction("MyCourse", "Course");
			
		}
		
		

	}
}