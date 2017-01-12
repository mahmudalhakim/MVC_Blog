using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Post
    {
		public int Id { get; set; }

		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Max 50 characters, at least 1 character")]
		[Display(Name = "Headline:")]
		public string Headline { get; set; }

		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 2000, MinimumLength = 3, ErrorMessage = "Max 2000 characters, at least 3 characters")]	
		public string PostMessage { get; set; }

		public DateTime PostDate { get; set; }

		public Category CategoryType { get; set; }
	}
}
