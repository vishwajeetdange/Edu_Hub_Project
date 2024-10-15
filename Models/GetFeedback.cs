using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_EduHub_Project.Models
{
	public class GetFeedback
	{
		[Key]
		public int CourseId { get; set; }
		public string Title { get; set; }
		public string feedback { get; set; }

		public DateTime Date { get; set; } = DateTime.Now;
		public string UserName { get; set; }

	}
}