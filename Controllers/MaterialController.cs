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

		// Constructor to inject the IMaterialService dependency
		public MaterialController(IMaterialService materialService)

		{
			_materialService = materialService;
		}
		
		// GET: Displays the form to add a new material
		[HttpGet]
		public IActionResult AddMaterial(int id)

		{
			List<SelectListItem> contenttype = new List<SelectListItem>()
				{
				new SelectListItem { Text = "PDF", Value = "PDF" },
				new SelectListItem{ Text="HTML",Value="HTML"},
				new SelectListItem{ Text="Notes",Value="Notes"},
				new SelectListItem{ Text="Video",Value="Video"},
				};
			ViewBag.contenttype = contenttype;
			Material oldmaterial = new Material(){CourseId=id,UploadDate = DateTime.Now};
			return View(oldmaterial);
		}
		
		// POST: Handles the submission of a new material
		[HttpPost]
		public IActionResult AddMaterial(Material material, int id)

		{
			if (ModelState.IsValid)

			{
				material.CourseId = id;
				material.UploadDate = DateTime.Now;
				_materialService.CreateMaterial(material);
				return RedirectToAction("MyCourse", "Course");
			}
			return View();
		}
		
		// GET: Retrieves all materials
		[HttpGet]
		public IActionResult AllMaterial()

		{
			var data = _materialService.GetAllMaterial();
			return View(data);
		}
		
		// GET: Retrieves a specific material by its ID
		[HttpGet]
		public IActionResult GetMaterialByMayterialId(int id)

		{
			var data = _materialService.GetMaterial(id);
			return View(data);
		}
		
		// GET: Retrieves all materials for a specific course
		[HttpGet]
		public IActionResult GetMaterialByCourseId(int id)

		{
			var data = _materialService.GetMaterialByCourseId(id);
			return View(data);
		}
		
		// GET: Displays details of a specific material
		[HttpGet]
		public IActionResult Details(int id)

		{
			var data = _materialService.GetMaterial(id);
			return View(data);
		}
		
		// GET: Displays the delete confirmation page for a material
		[HttpGet]
		public IActionResult Delete(int id)

		{
			var data = _materialService.GetMaterial(id);
			return View(data);

		}
		
		// POST: Handles the deletion of a material
		[HttpPost]
		public IActionResult Delete(int id, Material material)

		{
			_materialService.DeleteMaterial(id);
			return RedirectToAction("Mycourse", "Course");

		}
		
		// GET: Displays the edit form for a material
		[HttpGet]
		public IActionResult Edit(int id)

		{
			List<SelectListItem> contenttype = new List<SelectListItem>()
				{
				new SelectListItem { Text = "PDF", Value = "PDF" },
				new SelectListItem{ Text="HTML",Value="HTML"},
				new SelectListItem{ Text="Notes",Value="Notes"},
				new SelectListItem{ Text="Video",Value="Video"},
				};
			ViewBag.contenttype = contenttype;
			var data = _materialService.GetMaterial(id);
			return View(data);

		}
		
		// Post: Add new Material for that Course
		[HttpPost]
		public IActionResult Edit(int id,Material newmaterial)

		{
			_materialService.UpdateMaterial(newmaterial, id);
			return RedirectToAction("Mycourse", "Course");

		}
		
		// GET: Displays the Details  for a material using courseId
		[HttpGet]
		public IActionResult MaterialForCourse(int id)

		{
			var data = _materialService.GetMaterialByCourseId(id);
			return View(data);
		}


	}
}

