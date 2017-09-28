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
		public SchoolContext() : base("SchoolContext")
		{
			AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
		}
		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Lesson> Lessons { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<File> Files { get; set; }
		public static SchoolContext Create() => new SchoolContext();
		/*protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Course>().HasMany(c => c.Students)
				.WithMany(s => s.Courses)
				.Map(t => t.MapLeftKey("CourseId")
				.MapRightKey("StusentId")
				.ToTable("CourseStudent"));
		}*/
	}
}