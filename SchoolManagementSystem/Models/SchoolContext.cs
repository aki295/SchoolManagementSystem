using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolManagementSystem.Models
{
	public class SchoolContext : IdentityDbContext<ApplicationUser>
	{
		public SchoolContext() : base("SchoolContext") { }
		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Lesson> Lessons { get; set; }
		public DbSet<Course> Courses { get; set; }
		public static SchoolContext Create() => new SchoolContext();
	}
}