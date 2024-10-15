using System;
using Microsoft.AspNetCore.Mvc;
using MVC_EduHub_Project.Services;
using MVC_EduHub_Project.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_EduHub_Project.Models;

namespace MVC_EduHub_Project.Controllers
{
	public class EnquiryController : Controller
	{

		private readonly IEnquiryService _enquietservice;

		public EnquiryController(IEnquiryService enquietservice)

		{
			_enquietservice = enquietservice;
		}

		[HttpGet]
		public IActionResult GetEnquiryByCourseId(int id)

		{
			var data = _enquietservice.GetEnqueryByCourseId(id);
			return View(data);
		}

		[HttpGet]
		public IActionResult AddEnquiry(int id)

		{
			Enquiry enquiry = new Enquiry() { CourseId = id,UserId= Convert.ToInt32(HttpContext.Session.GetString("StudUserId")),EnquiryDate=DateTime.Now, Status= "In Progress" };
			return View(enquiry);
		}
		[HttpPost]
		public IActionResult AddEnquiry(Enquiry enquiry, int id)

		{
			enquiry.CourseId = id;
			enquiry.UserId= Convert.ToInt32(HttpContext.Session.GetString("StudUserId"));
			if (ModelState.IsValid)

			{
				_enquietservice.CreateEnquiry(enquiry);
				return RedirectToAction("StudentIndex", "User");
			}
			return View();
		}

		[HttpGet]
		public IActionResult EnquiryList()

		{
			int Id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
			var data = _enquietservice.GetCourseIdCourseName(Id);
			return View(data);
		}
		
		[HttpGet]
		public IActionResult Delete(int id)
		
		{
			var data = _enquietservice.GetEnqueryByEnquiryId(id);
			if (data == null)
			
			{
				return NotFound();
			}
			else
			
			{
				return View(data);
			}
		}
		[HttpPost]
		public IActionResult Delete(int id,Enquiry enquiry)
		
		{
			 _enquietservice.DeleteEnquery(id);
			 return RedirectToAction("EnquiryList");
		}
		[HttpGet]
		public IActionResult Edit(int id)
		
		{
			List<SelectListItem> EnqiryStatus = new List<SelectListItem>()
				{
				new SelectListItem { Text = "InProgress", Value = "InProgress" },
				new SelectListItem{ Text="Closed",Value="Closed"},
				new SelectListItem{ Text="Open",Value="Open"},
				};
			ViewBag.Status = EnqiryStatus;

			var data = _enquietservice.GetEnqueryByEnquiryId(id);
			if (data == null)
			
			{
				return NotFound();
			}
			else
			
			{
				return View(data);
			}
		}
		[HttpPost]
		public IActionResult Edit(int id,Enquiry enquiry)
		
		{
			 _enquietservice.EditEnquiry(enquiry,id);
			 return RedirectToAction("EnquiryList");
		}

	}
}

