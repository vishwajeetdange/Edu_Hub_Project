using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_EduHub_Project.Models
{
	public class Feedback
	{
		[Key]
		public int FeedbackId { get; set; }
		public string feedback { get; set; }
		
		public DateTime Date { get; set; }= DateTime.Now;
		public int UserId { get; set; }
		public int CourseId { get; set; }
	  
	}
}