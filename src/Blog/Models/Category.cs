using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
	public class Category
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Required!")]
		public string CategoryName { get; set; }
	}
}
