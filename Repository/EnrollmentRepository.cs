using System;
using Microsoft.EntityFrameworkCore;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;

namespace MVC_EduHub_Project.Repository
{
	public class EnrollmentRepository : IEnrollmentService
	{
		private readonly AppDbContext _context;
		public EnrollmentRepository(AppDbContext context)
		{
			_context = context;
		}

		public Enrollment CreateEnrollment(Enrollment newEnrollment)
		{
			_context.Enrollments.Add(newEnrollment);
			_context.SaveChanges();
			return newEnrollment;
			
		}

		public bool DeleteEnrollment(int EnrollmentId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Enrollment> GetAllEnrollment()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Enrollment> GetEnrollmentByCourseId(int courseId)
		{
			var data = _context.Enrollments.Where(x=>x.CourseId==courseId).ToList();
			return data;
			
		}

		public Enrollment GetEnrollmentByEnrollmentId(int EnrollmentId)
		{
			var data = _context.Enrollments.FirstOrDefault(x => x.EnrollmentId == EnrollmentId);
			return data;
			
		}
		public IEnumerable<GetEnrollemntByUserId> GetEnrollemntByUserId(int id)
		
		{
			//System.Console.WriteLine("Id is "+id);	
			var data = _context.getEnrollmentByuserId.FromSqlInterpolated($"SP_EnrollmentByUserId {id}"); ;
			 return data;
			
		}

		public void UpdateEnrollment(Enrollment updateEnrollment, int EnrollmentId)
		{
			//System.Console.WriteLine("id is "+ EnrollmentId);
			var data = _context.Enrollments.FirstOrDefault(x => x.EnrollmentId == EnrollmentId);
			data.Status = updateEnrollment.Status;
			_context.SaveChanges();
			
		}

		public IEnumerable<GetEnrollCourse> GetEnrollCourse(int id)
		{
			var data = _context.getGetEnrollCourse.FromSqlInterpolated($"SP_EnrolleCourses {id}"); 
			return data;
			
		}
	}
}
