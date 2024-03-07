using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Products.DAL;
using Products.Models;

namespace Products.Controllers
{
	public class ProductController : Controller
	{
		private readonly MyAppDbContext _context;

		public ProductController(MyAppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var products = _context.Products.Include("Categories");
			return View(products);
		}


		//Create
		[HttpGet]
		public IActionResult Create()
		{
			LoadCategories();
			return View();
		}

		[NonAction]
		private void LoadCategories()
		{
			var categories = _context.Categories.ToList();
			ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
		}

		[HttpPost]
		public IActionResult Create(Product model)
		{
			if (!ModelState.IsValid)
			{
				_context.Products.Add(model);
				_context.SaveChanges();
				TempData["Sweet"] = "Products added successfully!";
				return RedirectToAction(nameof(Index));
			}
			return View();
		}

		//Edit and Save
		[HttpGet]
		public IActionResult Edit(int? id)
		{
			if (id != null)
			{
				NotFound();
			}
			LoadCategories();
			var product = _context.Products.Find(id);
			return View(product);
		}
		//Save
		[HttpPost]
		public IActionResult Edit(Product model)
		{
			ModelState.Remove("Categories");
			if (ModelState.IsValid)
			{
				_context.Products.Update(model);
				_context.SaveChanges();
                TempData["Edit"] = "Products edit successfully!";
                return RedirectToAction(nameof(Index));
			}
			return View();
		}

		[HttpGet]
		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = _context.Products
							.Include(p => p.Categories)
							.FirstOrDefault(p => p.Id == id);

			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}


		// Delete
		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id != null)
			{
				NotFound();
			}
			LoadCategories();
			var product = _context.Products.Find(id);
			return View(product);
			

		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(Product model)
		{
			_context.Products.Remove(model);
			_context.SaveChanges();
            TempData["Delete"] = "Products deleted successfully!";
            return RedirectToAction(nameof(Index));
		}
		
	}
}