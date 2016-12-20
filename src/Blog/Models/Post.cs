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

		[MaxLength(2000)]
		public string PostMessage { get; set; }

		[MaxLength(50)]
		public string Headline { get; set; }

		[Column(TypeName = "date")]
		public DateTime PostDate { get; set; }

		public PostCategory CategoryType { get; set; }
	}
}
