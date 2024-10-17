using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_EduHub_Project.Models
{
	public class GetEnrollemntByUserId
	{
		[Key]
		public int CourseId { get; set; }
		public int UserId { get; set; }
		public DateTime EnrollmentDate { get; set; }
		public string Status { get; set; }
		public string Title { get; set; }
	}
}