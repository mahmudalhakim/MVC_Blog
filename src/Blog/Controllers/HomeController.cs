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

		public IActionResult Index()
        {
			var posts = db.Posts.ToList();
			var categories = db.PostCategories.ToList(); //ASK why this is needed. Without this the "post.categorytype" is null.

			return View(posts);
        }

		public IActionResult CreatePost(string content, string headline, string type)
		{
			var newPost = new Post()
			{
				PostMessage = content,
				Headline = headline,
				PostDate = DateTime.Now,
				CategoryType = new PostCategory() { CategoryName = type }	
			};

			db.Posts.Add(newPost);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

	}
}
