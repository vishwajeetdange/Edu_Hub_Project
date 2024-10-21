using System;
using Microsoft.AspNetCore.Mvc;
using MVC_EduHub_Project.Services;
using MVC_EduHub_Project.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_EduHub_Project.Models;

namespace MVC_EduHub_Project.Controllers
{
	// Controller responsible for handling feedback-related actions
	public class FeedbackController : Controller
	{
		// Private field to store the feedback service
		private readonly IFeedbackService _feedbackservice;
		
		// Constructor to inject the feedback service
		public FeedbackController(IFeedbackService feedbackservice)

		{
			_feedbackservice = feedbackservice;
		}
		
		// GET action to retrieve feedback for a specific course
		[HttpGet]
		public IActionResult GetFeedbackByCourseId(int id)

		{
			var data = _feedbackservice.GetFeedbackByCourseId(id);
			return View(data);
		}
		
		// GET action to retrieve feedback for the current user
		[HttpGet]
		public IActionResult GetFeedback()

		{
			int id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
			var data = _feedbackservice.GetFeedback(id);
			return View(data);
		}
		
		// GET action to display the form for adding new feedback
		[HttpGet]
		public IActionResult AddFeedback(int id)

		{	
			//System.Console.WriteLine("Id if "+id);
			 Feedback newfeedback = new Feedback() { CourseId = id,UserId= Convert.ToInt32(HttpContext.Session.GetString("StudUserId")) };
			return View(newfeedback);
		}
		
		// POST action to handle the submission of new feedback
		[HttpPost]
		public IActionResult AddFeedback(Feedback feed ,int id)

		{
				feed.UserId = Convert.ToInt32(HttpContext.Session.GetString("StudUserId"));
				feed.CourseId=id;
				_feedbackservice.CreateFeedback(feed);
				return RedirectToAction("StudentIndex", "User");
			
		}

	}
}

