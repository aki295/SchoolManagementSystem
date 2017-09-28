using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolManagementSystem.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity;

namespace SchoolManagementSystem.Tests
{
	public interface IRepository : IDisposable
	{
		List<Course> GetCourseList();
		Task<Course> GetCourse(int id);
		void Create(Course item);
		void Update(Course item);
		void Delete(int? id);
		void Save();
	}
	public class CourseRepository : IRepository
	{
		private SchoolContext db;
		public CourseRepository()
		{
			this.db = new SchoolContext();
		}
		public void Create(Course item)
		{
			db.Courses.Add(item);
		}

		public async void Delete(int? id)
		{
			Course course = await db.Courses.FindAsync(id);
			if (course != null)
				db.Courses.Remove(course);
		}

		private bool disposed = false;
		public virtual void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				if(disposing)
				{
					db.Dispose();
				}
			}
			this.disposed = true;
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public async Task<Course> GetCourse(int id)
		{
			return await db.Courses.FindAsync(id);
		}

		public List<Course> GetCourseList()
		{
			return db.Courses.ToList();
		}

		public async void Save()
		{
			await db.SaveChangesAsync();
		}

		public void Update(Course item)
		{
			db.Entry(item).State = EntityState.Modified;
		}
	}
}