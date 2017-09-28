using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Tests
{
    public class CoursesController : Controller
    {
		IRepository repo;
		public CoursesController(IRepository r)
		{
			repo = r;
		}
		public CoursesController()
		{
			repo = new CourseRepository();
		}
        // GET: Course
        public ActionResult Index()
        {
			var model = repo.GetCourseList();
            return View(model);
        }
		protected override void Dispose(bool disposing)
		{
			repo.Dispose();
			base.Dispose(disposing);
		}
	}
}