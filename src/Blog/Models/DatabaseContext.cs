using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Blog.Models
{
    public class DatabaseContext : DbContext
    {
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

		DbSet<Post> Posts { get; set; } 
	}
}
