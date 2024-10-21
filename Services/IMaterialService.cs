using System;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using MVC_EduHub_Project.Models;

namespace MVC_EduHub_Project.Services
{
	public interface IMaterialService
	{
		Material GetMaterial(int materialId);

		IEnumerable<Material> GetAllMaterial();
		IEnumerable<Material> GetMaterialByCourseId(int courseId);
		
		Material CreateMaterial(Material newmaterial);
		Material UpdateMaterial(Material material, int id);
		bool DeleteMaterial(int materialId);
		

	}

}