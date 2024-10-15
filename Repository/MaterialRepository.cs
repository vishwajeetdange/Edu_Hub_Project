using System;
using Microsoft.AspNetCore.Mvc;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;

namespace MVC_EduHub_Project.Repository
{
	public class MaterialRepository : IMaterialService
	{
		private readonly AppDbContext _context;
		public MaterialRepository(AppDbContext context)
		{
			_context = context;
		}

		public void CreateMaterial(Material newmaterial)
		{
			
			_context.Materials.Add(newmaterial);
			_context.SaveChanges();
			
		}

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

		public IEnumerable<Material> GetAllMaterial()
		{
			return _context.Materials.ToList();
			throw new NotImplementedException();
		}

		public Material GetMaterial(int materialId)
		{
			Material data = _context.Materials.FirstOrDefault(x => x.MaterialId==materialId);
			return data;
			
		}

		
		public IEnumerable<Material> GetMaterialByCourseId(int courseId)
		{
			var data = _context.Materials.Where(x => x.CourseId == courseId).ToList();
			return data;
			
		}

		public Material UpdateMaterial(Material material, int id)
		{
			var data = _context.Materials.FirstOrDefault(x => x.MaterialId==id);
			data.Title = material.Title;
			data.Description = material.Description;
			data.URL = material.URL;
			data.UploadDate = material.UploadDate;
			data.ContentType= material.ContentType;
			//_context.Materials.Update(data);
			_context.SaveChanges();
			return data;
			
		}
	}
}