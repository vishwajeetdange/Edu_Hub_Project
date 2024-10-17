using System;
using MVC_EduHub_Project.Models;

namespace MVC_EduHub_Project.Services
{
	public interface IEnquiryService
	{
		IEnumerable<GetEnquiryByCourseId> GetEnqueryByCourseId(int courseId);
		Enquiry GetEnqueryByEnquiryId(int enquiryId);
		bool DeleteEnquery(int id);
		Enquiry EditEnquiry(Enquiry enquiry, int id);
		IEnumerable<GetCourseIdCourseName> GetCourseIdCourseName(int id);
		Enquiry CreateEnquiry(Enquiry newEnquiry);
	}
   
}