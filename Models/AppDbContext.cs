using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace MVC_EduHub_Project.Models
{
	public class AppDbContext : DbContext
	{

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<LoginModel> LoginModel { get; set; }
	
		 public DbSet<Course> Courses { get; set; }
		 public DbSet<Material> Materials { get; set; }
		 public DbSet<Enrollment> Enrollments { get; set; }
		 public DbSet<Feedback> Feedbacks { get; set; }
		 public DbSet<Enquiry> Enquiries { get; set; }
		 public DbSet<GetCourseIdCourseName> getCourseIdCourseName { get; set; }
		 public DbSet<GetEnrollemntByUserId> getEnrollmentByuserId { get; set; }
		 public DbSet<MyCourses> getCourseStatusAccepted { get; set; }
		 public DbSet<GetEnrollCourse> getGetEnrollCourse { get; set; }
		 public DbSet<GetFeedback> getFeedback { get; set; }
		 public DbSet<GetEnquiryByCourseId> getEnquiryByCourseId { get; set; }

	}
}