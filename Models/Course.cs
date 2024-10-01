using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_EduHub_Project
{
	public class Course
	{
	 [Key]
	  public int CourseId { get; set; }
	  [Required]
	  public string Title { get; set; }
	  [Required]
	  public string Description { get; set; }
	  public DateTime courseStartDate { get; set; }
	  public DateTime courseEndDate	 { get; set; }
	  public string category { get; set; }
	  public string level { get; set; }
	  public int userId { get; set; }
	  
	}
}