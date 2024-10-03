using System;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;

namespace MVC_EduHub_Project.Repository
{
	public class CourseRepository : ICourseService
	{
		private readonly AppDbContext _context;
		public CourseRepository(AppDbContext context)
		{
			_context = context;
		}

	  
		public Course CreateCourse(Course course)
		{
			_context.Courses.Add(course);
			_context.SaveChanges();
			return course;
		}
		public List<Course> GetCreatedCourse(int id)
		{
			//System.Console.WriteLine("ID is "+id);
			List<Course> data = _context.Courses.Where(x => x.userId ==id).ToList();
			// foreach (var item in data)
			// {
			// 	System.Console.WriteLine(item.CourseId);
			// 	System.Console.WriteLine(item.userId);
			// 	System.Console.WriteLine(item.level);
			// 	System.Console.WriteLine(item.Title);
			// }
			return data;
		}

		public List<Course> AllCourses()
		{
			List<Course> data = _context.Courses.Select(x => x).ToList();
			return	data;
			throw new NotImplementedException();
		}

		public Course EditCourse(int id)
		{
			//System.Console.WriteLine("Id is "+course.CourseId);
			var data = _context.Courses.FirstOrDefault(x => x.CourseId ==id);
		    _context.Courses.Update(data);
			_context.SaveChanges();
			//System.Console.WriteLine("data is "+data.Description);
			return data;
			throw new NotImplementedException();
		}

		public Course DeleteCourse(int id)
		{
			var data = _context.Courses.FirstOrDefault(x => x.CourseId == id);
			_context.Courses.Remove(data);
			return data;
			throw new NotImplementedException();
		}

		public Course DetailsCourse(int id)
		{
			Course data = _context.Courses.FirstOrDefault(x => x.CourseId == id);
			return data;
			throw new NotImplementedException();
		}
	}
}