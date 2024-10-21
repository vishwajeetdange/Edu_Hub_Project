using System;
using Microsoft.AspNetCore.Mvc;
using MVC_EduHub_Project.Services;
using MVC_EduHub_Project.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_EduHub_Project.Controllers
{
	// This controller handles all course-related operations
	public class CourseController : Controller
	{

		// Dependency injection for ICourseService
		public readonly ICourseService _courseservice;

		// Constructor to initialize the course service
		public CourseController(ICourseService courseService)

		{
			_courseservice = courseService;
		}

		// Default action method for the controller
		public IActionResult Index()

		{
			return View();
		}
		// GET method to display the form for adding a new course
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
			return View();

		}
		// POST method to handle the submission of a new course

		[HttpPost]
		public IActionResult AddCourse(Course course)

		{

			course.userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
			_courseservice.CreateCourse(course);
			return RedirectToAction("EducatorIndex", "User");

		}
		// GET method to display courses created by the current user

		[HttpGet]
		public IActionResult MyCourse()

		{

			var id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
			var data = _courseservice.GetCreatedCourseByUser(id);
			return View(data);

		}
		// GET method to display course status accepted  for a student
		[HttpGet]
		public IActionResult MyCoursesStatusAccepted()

		{

			var id = Convert.ToInt32(HttpContext.Session.GetString("StudUserId"));
			var data = _courseservice.GetMyCourseStatusAccpeted(id);
			return View(data);

		}

		// Action method to display all courses
		public IActionResult AllCourses()

		{

			var data = _courseservice.AllCourses();
			return View(data);

		}
		// Another action method to display all courses (possibly for a different view)
		public IActionResult AllCourse()

		{

			var data = _courseservice.AllCourses();
			return View(data);

		}
		// GET method to display the form for editing a course

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
			var data = _courseservice.GetCreatedCourseByCourseId(id);
			return View(data);
		}

		// POST method to handle the submission of an edited course

		[HttpPost]
		public IActionResult Edit(Course course, int id)

		{
			_courseservice.EditCourse(course, id);
			return RedirectToAction("MyCourse", "Course");

		}
		// Get method to handle the Course details using course id

		[HttpGet]
		public IActionResult Details(int id)

		{
			var data = _courseservice.DetailsCourse(id);
			return View(data);
		}

		// Get method to handle the ShowDetails of course  using course id

		[HttpGet]
		public IActionResult ShowDetails(int id)

		{
			var data = _courseservice.DetailsCourse(id);
			return View(data);
		}



	}
}