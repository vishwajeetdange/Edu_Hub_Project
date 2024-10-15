using System;
using Microsoft.EntityFrameworkCore;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;

namespace MVC_EduHub_Project.Repository
{
	public class FeedbackRepository : IFeedbackService
	{
		private readonly AppDbContext _context;
		public FeedbackRepository(AppDbContext context)
		{
			_context = context;
		}
		
		public IEnumerable<Feedback> GetFeedbackByCourseId(int courseId)
		{
			var record = _context.Feedbacks.Where(x => x.CourseId == courseId).ToList();
			return record;
			throw new NotImplementedException();
		}

		public Feedback CreateFeedback(Feedback newfeedback)
		{
			_context.Feedbacks.Add(newfeedback);
			_context.SaveChanges();
			return newfeedback;
			throw new NotImplementedException();
		}

        public IEnumerable<GetFeedback> GetFeedback(int userid)
        {
			var data = _context.getFeedback.FromSqlInterpolated($"SP_FeedbackCourses {userid}");
			return data;
		}
    }

	
}
