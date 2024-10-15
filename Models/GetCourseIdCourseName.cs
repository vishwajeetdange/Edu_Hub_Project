using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_EduHub_Project.Models
{
	public class GetCourseIdCourseName
	{
		[Key]
	  public int CourseId { get; set; }
	  public string Title { get; set; }
	}
}