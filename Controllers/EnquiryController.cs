using System;
using Microsoft.AspNetCore.Mvc;
using MVC_EduHub_Project.Services;
using MVC_EduHub_Project.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_EduHub_Project.Models;

namespace MVC_EduHub_Project.Controllers
{
	// Controller for handling enquiry-related operations
	public class EnquiryController : Controller
	{

		private readonly IEnquiryService _enquietservice;

		// Constructor with dependency injection
		public EnquiryController(IEnquiryService enquietservice)

		{
			_enquietservice = enquietservice;
		}
		
		// GET: Retrieves enquiries for a specific course
		[HttpGet]
		public IActionResult GetEnquiryByCourseId(int id)

		{
			var data = _enquietservice.GetEnqueryByCourseId(id);
			return View(data);
		}
		
		// GET: Displays form to add a new enquiry
		[HttpGet]
		public IActionResult AddEnquiry(int id)

		{
			Enquiry enquiry = new Enquiry() { CourseId = id,UserId= Convert.ToInt32(HttpContext.Session.GetString("StudUserId")),EnquiryDate=DateTime.Now, Status= "Open" };
			return View(enquiry);
		}
		
		// POST: Handles the submission of a new enquiry
		[HttpPost]
		public IActionResult AddEnquiry(Enquiry enquiry, int id)

		{
			enquiry.CourseId = id;
			enquiry.EnquiryDate = DateTime.Now;
			enquiry.Status = "Open";
			enquiry.UserId= Convert.ToInt32(HttpContext.Session.GetString("StudUserId"));
			if (ModelState.IsValid)

			{
				_enquietservice.CreateEnquiry(enquiry);
				return RedirectToAction("StudentIndex", "User");
			}
			return View();
		}
		
		// GET: Retrieves a list of enquiries for the logged-in user
		[HttpGet]
		public IActionResult EnquiryList()

		{
			int Id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
			var data = _enquietservice.GetCourseIdCourseName(Id);
			return View(data);
		}

		// GET: Displays confirmation page for deleting an enquiry
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
		
		// POST: Handles the deletion of an enquiry
		[HttpPost]
		public IActionResult Delete(int id,Enquiry enquiry)
		
		{
			 _enquietservice.DeleteEnquery(id);
			 return RedirectToAction("EnquiryList");
		}
		
		// GET: Displays form to edit an existing enquiry
		[HttpGet]
		public IActionResult Edit(int id)
		
		{
			List<SelectListItem> EnqiryStatus = new List<SelectListItem>()
				{
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
		
		// POST: Handles the Edit of an enquiry
		[HttpPost]
		public IActionResult Edit(int id,Enquiry enquiry)
		
		{
			 _enquietservice.EditEnquiry(enquiry,id);
			 return RedirectToAction("EnquiryList");
		}

	}
}

