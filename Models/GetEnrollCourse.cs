using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_EduHub_Project.Models
{
	public class GetEnrollCourse
	{
		[Key]
		public int EnrollmentId { get; set; }
		public DateTime EnrollmentDate { get; set; }
		public int CourseId { get; set; }
		public int UserId { get; set; }
		public string Status { get; set; }
		public String Title { get; set; }
		public String UserName { get; set; }
	}
}