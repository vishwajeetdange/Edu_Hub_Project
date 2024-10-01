using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;

namespace MVC_EduHub_Project.Repository
{
	public class UserRepository : IUserService
	{
		private readonly AppDbContext _context;
		public UserRepository(AppDbContext context)
		{
			_context = context;
		}

		public User CreateUser(User newuser)
		{
			_context.Users.Add(newuser);
			_context.SaveChanges();
			return newuser;
			
		}


		public bool StudentLogin(LoginModel user)
		{
			// System.Console.WriteLine("Name"+user.UserName);
			// System.Console.WriteLine("Paas"+user.Password);
			//System.Console.WriteLine("Role"+user.Role);
			 var user1 = _context.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password && u.Role=="Student");
			 if (user1 != null)
			 {
				return true;
			 }
			else
				
			{
				return false;
			}
								
		//	throw new NotImplementedException();
		}
	public bool EducatorLogin(LoginModel loginModel)
		{
			var user1 = _context.Users.FirstOrDefault(u => u.UserName == loginModel.UserName && u.Password == loginModel.Password && u.Role == "Educator");
			if (user1 != null)
			{
				return true;
			}
			else

			{
				return false;
			}
			//throw new NotImplementedException();
		}

		
	}
}