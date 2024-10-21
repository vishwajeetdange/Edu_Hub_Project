using System;
using Microsoft.EntityFrameworkCore;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;

namespace MVC_EduHub_Project.Repository
{
	public class CourseRepository : ICourseService
	{
		private readonly AppDbContext _context;
		
		// Constructor to initialize the database context
		public CourseRepository(AppDbContext context)
		{
			_context = context;
		}

		// Method to create a new course
		public Course CreateCourse(Course course)
		{
			_context.Courses.Add(course);
			_context.SaveChanges();
			return course;
		}
		
		// Method to get all courses created by a specific user
		public List<Course> GetCreatedCourseByUser(int id)
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
		// Method to get a specific course by its ID
		public Course GetCreatedCourseByCourseId(int id)
		{

			var data = _context.Courses.FirstOrDefault(x => x.CourseId ==id);
			return data;
		}

		// Method to get all courses
		public List<Course> AllCourses()
		{
			List<Course> data = _context.Courses.Select(x => x).ToList();
			return	data;
			throw new NotImplementedException();
		}
		
		// Method to edit an existing course
		public Course EditCourse(Course newcourse,int id)
		{
			
			var data = _context.Courses.FirstOrDefault(x => x.CourseId ==id);
			//  _context.Courses.Update(newcourse);
			data.Title = newcourse.Title;
			data.Description = newcourse.Description;
			data.courseStartDate = newcourse.courseStartDate;
			data.courseStartDate = newcourse.courseStartDate;
			data.category = newcourse.category;
			data.level = newcourse.level;
			
			 _context.SaveChanges();
			return data;
			throw new NotImplementedException();
		}

		// Method to get details of a specific course
		public Course DetailsCourse(int id)
		{
			Course data = _context.Courses.FirstOrDefault(x => x.CourseId == id);
			return data;
			throw new NotImplementedException();
		}

		// Method to get accepted status of courses for a specific user
		public IEnumerable<MyCourses> GetMyCourseStatusAccpeted(int id)
		
		{
			var data = _context.getCourseStatusAccepted.FromSqlInterpolated($"SP_MyCourses {id}"); 
			return data;
		}
	}
}