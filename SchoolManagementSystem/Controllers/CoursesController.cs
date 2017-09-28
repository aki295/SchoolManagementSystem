using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolManagementSystem.Models;
using System.Globalization;

namespace SchoolManagementSystem.Controllers
{
	public class CoursesController : Controller
	{
		private SchoolContext db = new SchoolContext();
		
		// GET: Courses
		public async Task<ActionResult> Index()
		{
			return View(await db.Courses.ToListAsync());
		}

		public async Task<ActionResult> GetCourses()
		{
			var courses = await db.Courses.OrderBy(name => name.Name).Select(
				co => new { co.CourseId, co.Name, co.Students, co.Teacher, co.TeacherId, co.Language, co.LanguageProficiency, co.StartDate, co.EndDate })
				.ToListAsync();
			var courseForTable = courses.Select(co => new {
				co.CourseId,
				co.Name,
				co.Students,
				co.Teacher,
				co.TeacherId,
				Language = co.Language.ToString(),
				LanguageProficiency = co.LanguageProficiency.ToString(),
				StartDate = co.StartDate.ToShortDateString(),
				EndDate = co.EndDate.ToShortDateString()
			});
			return Json(new { data = courseForTable }, JsonRequestBehavior.AllowGet);
		}

		// GET: Courses/Details/5
		public async Task<ActionResult> Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Course course = await db.Courses.FindAsync(id);
			if (course == null)
			{
				return HttpNotFound();
			}
			return View(course);
		}

		// GET: Courses/Create
		public ActionResult Create()
		{
			ViewBag.Teachers = new SelectList(db.Teachers, "Id", "Surname");
			return View();
		}

		// POST: Courses/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "CourseId,Name,Language,LanguageProficiency,StartDate,EndDate,TeacherId,NumberOfLessonsPerWeek")] Course course,
			FormCollection form)
		{
			if (ModelState.IsValid)
			{
				db.Courses.Add(course);
				await db.SaveChangesAsync();
				var days = form["daysOfWeek"].ToString().Split(',').ToList();
				var startTimes = form["startTime"].ToString().Split(',').ToList();
				var endTimes = form["endTime"].ToString().Split(',').ToList();
				CreateLessons(days, startTimes, endTimes);
				return RedirectToAction("Index");
			}
			return View(course);
		}

		public async void CreateLessons(List<string> days, List<string> startTimes, List<string> endTimes)
		{
			
			var x = await db.Courses.ToListAsync();
			db.Courses.OrderBy(b => b.CourseId);
			var y = await db.Courses.ToListAsync();
		}

		public ActionResult ShowDaysOfweek(int? countDays)
		{
			ViewBag.CountDays = countDays;
			var days =  new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday };
			ViewBag.DaysOfWeek = new SelectList(days);
			return PartialView("ShowDaysOfweek");
		}

		// GET: Courses/Edit/5
		public async Task<ActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Course course = await db.Courses.FindAsync(id);
			var allTeachers = new List<Teacher> { course.Teacher };
			var teachersExceptThis = await db.Teachers.OrderBy(t => t.Surname).Except(allTeachers).ToListAsync();
			var unionTeachers  = allTeachers.Concat(teachersExceptThis).ToList();
			ViewBag.Teachers = new SelectList(unionTeachers, "Id", "Surname", course.TeacherId);
			if (course == null)
			{
				return HttpNotFound();
			}
			return View(course);
		}

		// POST: Courses/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind(Include = "CourseId,Name,Language,LanguageProficiency,StartDate,EndDate,TeacherId")] Course course)
		{
			if (ModelState.IsValid)
			{
				db.Entry(course).State = EntityState.Modified;
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(course);
		}

		// GET: Courses/Delete/5
		public async Task<ActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Course course = await db.Courses.FindAsync(id);
			if (course == null)
			{
				return HttpNotFound();
			}
			return View(course);
		}

		// POST: Courses/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			Course course = await db.Courses.FindAsync(id);
			db.Courses.Remove(course);
			await db.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}