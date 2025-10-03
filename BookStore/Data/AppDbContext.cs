using System;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;

namespace BookStore.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

	public DbSet<Books> Books { get; set; }
	}
}
