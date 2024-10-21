using System;
using Microsoft.EntityFrameworkCore;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;

namespace MVC_EduHub_Project.Repository
{
	// Repository class for handling Enquiry-related database operations
	public class EnquiryRepository : IEnquiryService
	{
		private readonly AppDbContext _context;

		// Constructor to inject the database context
		public EnquiryRepository(AppDbContext context)
		{
			_context = context;
		}
		
		// Method to create a new enquiry
		public Enquiry CreateEnquiry(Enquiry newEnquiry)
		{
			_context.Enquiries.Add(newEnquiry);
			_context.SaveChanges();
			return newEnquiry;
		}
		
		// Method to get enquiries by course ID using a stored procedure
		public IEnumerable<GetEnquiryByCourseId> GetEnqueryByCourseId(int courseId)
		{
			var data = _context.getEnquiryByCourseId.FromSqlInterpolated($"SP_GetEnquiryByCourseId {courseId}");
			return data;
						
		}
		
		// Method to get course ID and name by ID using a stored procedure
		public IEnumerable<GetCourseIdCourseName> GetCourseIdCourseName(int id)

		{
			var data = _context.getCourseIdCourseName.FromSqlInterpolated($"SP_CourseIdForEnquiry {id}");
			return data;
			
		}

		// Method to get an enquiry by its ID
		public Enquiry GetEnqueryByEnquiryId(int enquiryId)
		{
			var data = _context.Enquiries.FirstOrDefault(e =>e.EnquiryId== enquiryId);
			return data;
			
		}
		
		// Method to delete an enquiry by its ID
		public bool DeleteEnquery(int id)
		{
			var enquiry = _context.Enquiries.Find(id);
			if (enquiry != null)
			{
				_context.Enquiries.Remove(enquiry);
				_context.SaveChanges();
				return true;
			}
			return false;
			
		}
		
		// Method to edit an enquiry's status
		public Enquiry EditEnquiry(Enquiry enquiry, int id)
		{
			var data = _context.Enquiries.FirstOrDefault(x => x.EnquiryId == id);
			data.Status = enquiry.Status;
			_context.SaveChanges();
			return data;
			
		}
	}
}