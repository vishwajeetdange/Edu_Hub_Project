using System;
using Microsoft.EntityFrameworkCore;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;

namespace MVC_EduHub_Project.Repository
{
	public class EnquiryRepository : IEnquiryService
	{
		private readonly AppDbContext _context;
		public EnquiryRepository(AppDbContext context)
		{
			_context = context;
		}

		public Enquiry CreateEnquiry(Enquiry newEnquiry)
		{
			_context.Enquiries.Add(newEnquiry);
			_context.SaveChanges();
			return newEnquiry;
		}

		public IEnumerable<GetEnquiryByCourseId> GetEnqueryByCourseId(int courseId)
		{
			var data = _context.getEnquiryByCourseId.FromSqlInterpolated($"SP_GetEnquiryByCourseId {courseId}");
			return data;
			// var data = _context.Enquiries.Where(en => en.CourseId== courseId).ToList();
			// return data;
			
		}
	 public	IEnumerable<GetCourseIdCourseName> GetCourseIdCourseName(int id)

		{
			var data = _context.getCourseIdCourseName.FromSqlInterpolated($"SP_CourseIdForEnquiry {id}");
			return data;
			
		}

		public Enquiry GetEnqueryByEnquiryId(int enquiryId)
		{
			var data = _context.Enquiries.FirstOrDefault(e =>e.EnquiryId== enquiryId);
			return data;
			
		}

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

		public Enquiry EditEnquiry(Enquiry enquiry, int id)
		{
			var data = _context.Enquiries.FirstOrDefault(x => x.EnquiryId == id);
			data.Status = enquiry.Status;
			//_context.Materials.Update(data);
			_context.SaveChanges();
			return data;
			
		}
	}
}