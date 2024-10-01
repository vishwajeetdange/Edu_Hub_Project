using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_EduHub_Project.Models
{
	public class Enquiry
	{
		[Key]
	  public int EnquiryId { get; set; }
	  public string Subject { get; set; }
	  public string Message { get; set; }
	  public DateTime EnquiryDate { get; set; }
	  public string Status { get; set; }
	  public string Response { get; set; }
	  public int UserId { get; set; }
	  public int CourseId { get; set; }
	}
}