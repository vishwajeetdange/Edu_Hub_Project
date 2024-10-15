using System;
using MVC_EduHub_Project.Models;

namespace MVC_EduHub_Project.Services
{
	public interface IEnrollmentService
	{
		Enrollment GetEnrollmentByEnrollmentId(int EnrollmentId);
		IEnumerable<GetEnrollemntByUserId> GetEnrollemntByUserId(int id);
		IEnumerable<GetEnrollCourse> GetEnrollCourse(int id);

		IEnumerable<Enrollment> GetAllEnrollment();
		IEnumerable<Enrollment> GetEnrollmentByCourseId(int courseId);

		Enrollment CreateEnrollment(Enrollment newEnrollment);
		void UpdateEnrollment(Enrollment updateEnrollment, int EnrollmentId);
		bool DeleteEnrollment(int EnrollmentId);

	}
}