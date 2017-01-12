using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class ViewModel
    {
		public List<Post> Posts { get; set; }
		public List<Category> Categories { get; set; }
		public Post Post { get; set; }
		public Category Category { get; set; }
	}
}
