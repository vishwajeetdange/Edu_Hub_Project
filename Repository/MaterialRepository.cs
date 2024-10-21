using System;
using Microsoft.AspNetCore.Mvc;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;

namespace MVC_EduHub_Project.Repository
{
	// Method to get feedback using a stored procedure
	public class MaterialRepository : IMaterialService
	{
		private readonly AppDbContext _context;
		// Constructor that injects the AppDbContext
		public MaterialRepository(AppDbContext context)
		{
			_context = context;
		}

		// Method to create a new material
		public Material CreateMaterial(Material newmaterial)
		{
			
			_context.Materials.Add(newmaterial);
			_context.SaveChanges();
			return newmaterial;
		}

		// Method to delete a material by its ID
		public bool DeleteMaterial(int materialId)
		{
			var material = _context.Materials.Find(materialId);
			if (material != null)
			{
				_context.Materials.Remove(material);
				_context.SaveChanges();
				return true;
			}
			return false;
			
		}

		// Method to get all materials
		public IEnumerable<Material> GetAllMaterial()
		{
			return _context.Materials.ToList();
		}

		// Method to get a specific material by its ID
		public Material GetMaterial(int materialId)
		{
			Material data = _context.Materials.FirstOrDefault(x => x.MaterialId==materialId);
			return data;
		}


		// Method to get all materials for a specific course
		public IEnumerable<Material> GetMaterialByCourseId(int courseId)
		{
			var data = _context.Materials.Where(x => x.CourseId == courseId).ToList();
			return data;
			
		}

		// Method to update an existing material
		public Material UpdateMaterial(Material material, int id)
		{
			var data = _context.Materials.FirstOrDefault(x => x.MaterialId==id);
			data.Title = material.Title;
			data.Description = material.Description;
			data.URL = material.URL;
			data.UploadDate = material.UploadDate;
			data.ContentType= material.ContentType;
			_context.SaveChanges();
			return data;
			
		}
	}
}