using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
	public class HomeController : Controller
	{
		private DatabaseContext db;
		public HomeController(DatabaseContext _context)
		{
			db = _context;
		}

		public IActionResult Index(string id)
		{
			var viewModel = new ViewModel();
			List<Post> posts;

			var search = id?.Trim().ToUpper();

			var categories = db.PostCategories.ToList();

			if(string.IsNullOrEmpty(search) || search == "")
				posts = db.Posts.ToList();
			else
				posts = db.Posts.Where(s => s.Headline.Contains(search)).ToList();

			ViewBag.search = id?.Trim();

			viewModel.Categories = categories;
			viewModel.Posts = posts.OrderByDescending(s => s.Id).ToList();

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreatePost(Post post)
		{
			if(!ModelState.IsValid)				
				return RedirectToAction("Index");

			post.CategoryType.CategoryName = post.CategoryType.CategoryName.ToUpper();

			//If the categorytype already exists in database. Set the categorytype to its id.
			if(db.PostCategories.Any(s => s.CategoryName.Trim().ToUpper() == post.CategoryType.CategoryName.Trim()))
				post.CategoryType = db.PostCategories.FirstOrDefault(s => s.CategoryName.Trim().ToUpper() == post.CategoryType.CategoryName);

			post.PostDate = DateTime.Now;
			
			db.Posts.Add(post);
			db.SaveChanges();
			
			return RedirectToAction("Index");
		}

		public IActionResult DeletePost(int id)
		{
			var deleted = db.Posts.FirstOrDefault(s => s.Id == id);

			db.Posts.Remove(deleted);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

	}
}
