using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_EduHub_Project.Repository
{  
	  // UserRepository class implements IUserService interface
	public class UserRepository : IUserService
	{
		private readonly AppDbContext _context;
		// Constructor to inject AppDbContext
		public UserRepository(AppDbContext context)
		{
			_context = context;
		}

		// Method to create a new user
		public User CreateUser(User newuser)
		{
			_context.Users.Add(newuser);
			_context.SaveChanges();
			return newuser;
			
		}


		// Method to authenticate student login
		public User StudentLogin(LoginModel user)
		{
			//select * from users where username=user.username and password = user.password and role="Student"; 
			var user1 = _context.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password && u.Role=="Student");
			if (user1 != null)
			 {
				return user1;
			 }
			else
				
			{
				return null;
			}
								
		}
		
		// Method to authenticate educator login
		public User EducatorLogin(LoginModel loginModel)
		{
			var user2 = _context.Users.FirstOrDefault(u => u.UserName == loginModel.UserName && u.Password == loginModel.Password && u.Role == "Educator");
			
			if (user2 != null)
			{
				return user2;
			}
			else

			{
				return null;
			}
		}

		// Method to retrieve student data by ID
		public User StudentData(int id)
	
		{
			var data=	_context.Users.FirstOrDefault(x => x.UserId==id);
			return data;
		}
			// Method to retrieve educator data by ID
		public User EducatorData(int id)
		
		{
			var data=	_context.Users.FirstOrDefault(x => x.UserId==id);
			return data;
		}

			
	}
}