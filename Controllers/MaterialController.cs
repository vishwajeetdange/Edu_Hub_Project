using System;
using Microsoft.AspNetCore.Mvc;
using MVC_EduHub_Project.Services;
using MVC_EduHub_Project.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_EduHub_Project.Models;
using Microsoft.AspNetCore.Identity;

namespace MVC_EduHub_Project.Controllers
{
	public class MaterialController : Controller
	{

		private readonly IMaterialService _materialService;

		public MaterialController(IMaterialService materialService)

		{
			_materialService = materialService;
		}

		[HttpGet]
		public IActionResult AddMaterial(int id)

		{
			Material oldmaterial = new Material(){CourseId=id,UploadDate = DateTime.Now};
			return View(oldmaterial);
		}
		[HttpPost]
		public IActionResult AddMaterial(Material material, int courseId)

		{
			material.CourseId = courseId;
			if (ModelState.IsValid)

			{
				_materialService.CreateMaterial(material);
				return RedirectToAction("MyCourse", "Course");
			}
			return View();
		}

		[HttpGet]
		public IActionResult AllMaterial()

		{
			var data = _materialService.GetAllMaterial();
			return View(data);
		}
		[HttpGet]
		public IActionResult GetMaterialByMayterialId(int id)

		{
			var data = _materialService.GetMaterial(id);
			return View(data);
		}

		[HttpGet]
		public IActionResult GetMaterialByCourseId(int id)

		{
			var data = _materialService.GetMaterialByCourseId(id);
			return View(data);
		}
		[HttpGet]
		public IActionResult Details(int id)

		{
			var data = _materialService.GetMaterial(id);
			return View(data);
		}

		[HttpGet]
		public IActionResult Delete(int id)

		{
			var data = _materialService.GetMaterial(id);
			return View(data);

		}
		[HttpPost]
		public IActionResult Delete(int id, Material material)

		{
			_materialService.DeleteMaterial(id);
			return RedirectToAction("Mycourse", "Course");

		}
		[HttpGet]
		public IActionResult Edit(int id)

		{
			var data = _materialService.GetMaterial(id);
			return View(data);

		}
		[HttpPost]
		public IActionResult Edit(int id,Material newmaterial)

		{
			_materialService.UpdateMaterial(newmaterial, id);
			return RedirectToAction("Mycourse", "Course");

		}

		[HttpGet]
		public IActionResult MaterialForCourse(int id)

		{
			var data = _materialService.GetMaterialByCourseId(id);
			return View(data);
		}


	}
}

