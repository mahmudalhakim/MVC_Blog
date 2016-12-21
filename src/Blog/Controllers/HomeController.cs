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
			List<Post> posts;

			var search = id?.Trim().ToUpper();

			var categories = db.PostCategories.ToList(); //ASK why this is needed. Without this the "post.categorytype" is null

			if(string.IsNullOrEmpty(search) || search == "")
				posts = db.Posts.ToList();
			else
			{
				switch(search)
				{
					case "MTG":
						posts = db.Posts.Where(s => s.CategoryType.CategoryName == "MTG").ToList();
						break;
					case "GAME":
						posts = db.Posts.Where(s => s.CategoryType.CategoryName == "GAME").ToList();
						break;
					case "RANT":
						posts = db.Posts.Where(s => s.CategoryType.CategoryName == "RANT").ToList();
						break;
					default:
						posts = db.Posts.Where(s => s.Headline.Contains(search)).ToList();
						break;
				}
			}

			ViewBag.search = id?.Trim();
			return View(posts);
		}

		public IActionResult CreatePost(string textContent, string headline, string type)
		{
			var categoryType = new PostCategory() { CategoryName = type.ToUpper() };

			//If the categorytype exists in database. Set the categorytype to its id.
			if(db.PostCategories.Any(s => s.CategoryName.Trim().ToLower() == type.Trim().ToLower()))
				categoryType = db.PostCategories.FirstOrDefault(s => s.CategoryName.Trim().ToLower() == type.Trim().ToLower());

			var newPost = new Post()
			{
				PostMessage = textContent,
				Headline = headline,
				PostDate = DateTime.Now,
				CategoryType = categoryType
			};

			db.Posts.Add(newPost);
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
