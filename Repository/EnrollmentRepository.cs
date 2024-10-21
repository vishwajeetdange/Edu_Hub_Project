using System;
using Microsoft.EntityFrameworkCore;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;

namespace MVC_EduHub_Project.Repository
{
	// This class implements the IEnrollmentService interface
	public class EnrollmentRepository : IEnrollmentService
	{
		private readonly AppDbContext _context;
		// Constructor: Dependency injection of AppDbContext
		public EnrollmentRepository(AppDbContext context)
		{
			_context = context;
		}
		
		// Method to create a new enrollment
		public Enrollment CreateEnrollment(Enrollment newEnrollment)
		{
			_context.Enrollments.Add(newEnrollment);
			_context.SaveChanges();
			return newEnrollment;

		}

		// Method to delete an enrollment (not implemented)
		public bool DeleteEnrollment(int EnrollmentId)
		{
			throw new NotImplementedException();
		}

		// Method to get all enrollments (not implemented)
		public IEnumerable<Enrollment> GetAllEnrollment()
		{
			throw new NotImplementedException();
		}

		// Method to get enrollments by course ID
		public IEnumerable<Enrollment> GetEnrollmentByCourseId(int courseId)
		{
			var data = _context.Enrollments.Where(x => x.CourseId == courseId).ToList();
			return data;

		}

		// Method to get an enrollment by its ID
		public Enrollment GetEnrollmentByEnrollmentId(int EnrollmentId)
		{
			var data = _context.Enrollments.FirstOrDefault(x => x.EnrollmentId == EnrollmentId);
			return data;

		}
		
		// Method to get enrollments by user ID using a stored procedure
		public IEnumerable<GetEnrollemntByUserId> GetEnrollemntByUserId(int id)

		{
			var data = _context.getEnrollmentByuserId.FromSqlInterpolated($"SP_EnrollmentByUserId {id}").ToList();
			return data;

		}

		// Method to update an enrollment's status
		public void UpdateEnrollment(Enrollment updateEnrollment, int EnrollmentId)
		{
			//System.Console.WriteLine("id is "+ EnrollmentId);
			var data = _context.Enrollments.FirstOrDefault(x => x.EnrollmentId == EnrollmentId);
			data.Status = updateEnrollment.Status;
			_context.SaveChanges();

		}

		// Method to get enrolled courses for a user using a stored procedure
		public IEnumerable<GetEnrollCourse> GetEnrollCourse(int id)
		{
			var data = _context.getGetEnrollCourse.FromSqlInterpolated($"SP_EnrolleCourses {id}");
			return data;

		}
	}
}
