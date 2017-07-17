using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SchoolManagementSystem.Models
{
	public class SchoolContext : DbContext
	{
		public SchoolContext() : base("SchoolContext") { }
		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Lesson> Lessons { get; set; }
		public DbSet<Course> Courses { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>()
			.Map(m =>
			{
				m.MapInheritedProperties();
				m.ToTable("Students");
			});
			modelBuilder.Entity<Teacher>()
			.Map(m =>
			{
				m.MapInheritedProperties();
				m.ToTable("Teachers");
			});
		}
	}
}