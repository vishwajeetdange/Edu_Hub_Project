using System;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using MVC_EduHub_Project.Models;

namespace MVC_EduHub_Project.Services
{
	public interface ICourseService
	{
		Course CreateCourse(Course newcourse);

		List<Course> GetCreatedCourse(int id);
		List<Course> AllCourses();

		Course EditCourse(int id);
		Course DeleteCourse(int id);
		
		Course DetailsCourse(int id);

	}

}