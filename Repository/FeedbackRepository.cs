using System;
using Microsoft.EntityFrameworkCore;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;

namespace MVC_EduHub_Project.Repository
{
	// Repository class for handling Feedback-related database operations
	public class FeedbackRepository : IFeedbackService
	{
		private readonly AppDbContext _context;
		// Constructor to inject the database context
		public FeedbackRepository(AppDbContext context)
		{
			_context = context;
		}

		// Method to retrieve all feedback for a specific course
		public IEnumerable<Feedback> GetFeedbackByCourseId(int courseId)
		{
			var record = _context.Feedbacks.Where(x => x.CourseId == courseId).ToList();
			return record;
			
		}

		// Method to create a new feedback entry in the database
		public Feedback CreateFeedback(Feedback newfeedback)
		{
			_context.Feedbacks.Add(newfeedback);
			_context.SaveChanges();
			return newfeedback;
			
		}

		// Method to get feedback using a stored procedure
		public IEnumerable<GetFeedback> GetFeedback(int userid)
		{
			var data = _context.getFeedback.FromSqlInterpolated($"SP_FeedbackCourses {userid}");
			return data;
		}
	}

	
}
