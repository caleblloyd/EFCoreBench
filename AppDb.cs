using System;
using System.Data.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using EFCoreBench.Models;

namespace EFCoreBench
{
	public class AppDb : DbContext
	{
		public AppDb(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Blog> Blogs { get; set; }
	}
}
