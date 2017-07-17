using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
	public class HomeController : Controller
	{
		SchoolContext db = new SchoolContext();
		public ActionResult Index()
		{
			IEnumerable<Student> students = db.Students;
			ViewBag.Students = students;
			return View();
		}
		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}
	}
}