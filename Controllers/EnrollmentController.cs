using System;
using Microsoft.AspNetCore.Mvc;
using MVC_EduHub_Project.Services;
using MVC_EduHub_Project.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_EduHub_Project.Models;

namespace MVC_EduHub_Project.Controllers
{
	public class EnrollmentController : Controller
	{

		private readonly IEnrollmentService _enrollmentService;

		public EnrollmentController(IEnrollmentService enrollmentService)

		{
			_enrollmentService = enrollmentService;
		}

		[HttpGet]
		public IActionResult GetEnrollmentByCourseId(int id)
		
		{
			var data = _enrollmentService.GetEnrollmentByCourseId(id);
			return View(data);
		}
		[HttpGet]
		public IActionResult GetEnrollmentByUserId()
		
		{
			int id = Convert.ToInt32(HttpContext.Session.GetString("StudUserId"));	
			var data = _enrollmentService.GetEnrollemntByUserId(id);
			return View(data);
		}

		[HttpGet]
		public IActionResult GetEnrollCourse()

		{
			int id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
			var data = _enrollmentService.GetEnrollCourse(id);
			return View(data);
		}
		[HttpGet]
		public IActionResult Edit(int id)
		
		{
			List<SelectListItem> status = new List<SelectListItem>()
				{
				new SelectListItem { Text = "Pending", Value = "Pending" },
				new SelectListItem { Text = "Accepted", Value = "Accepted" },
				new SelectListItem{ Text="Rejected",Value="Rejected"},
				};
			ViewBag.status = status;
			var data = _enrollmentService.GetEnrollmentByEnrollmentId(id);
			return View(data);
		}
		[HttpPost]
		public IActionResult Edit(int id,Enrollment enrollment)
		
		{
			// var data = _enrollmentService.GetEnrollmentByEnrollmentId(id);
			_enrollmentService.UpdateEnrollment(enrollment,id);
			return RedirectToAction("GetEnrollCourse", "Enrollment");
		}

		[HttpGet]
		public IActionResult AddEnrollment(int id)

		{
			Enrollment oldCourseid = new Enrollment() { CourseId = id ,UserId= Convert.ToInt32(HttpContext.Session.GetString("StudUserId")),EnrollmentDate =DateTime.Now };
			return View(oldCourseid);

		}
		[HttpPost]
		public IActionResult AddEnrollment(Enrollment enrollment, int id)

		{
			//enrollment.CourseId=id;	
			enrollment.UserId = Convert.ToInt32(HttpContext.Session.GetString("StudUserId"));
			_enrollmentService.CreateEnrollment(enrollment);
			return RedirectToAction("StudentIndex", "User");

		}



	}
}

