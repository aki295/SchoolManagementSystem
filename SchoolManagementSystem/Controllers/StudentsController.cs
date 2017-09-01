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
using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Students
        public async Task<ActionResult> Index()
        {
            return View(await db.Students.ToListAsync());
        }

		public async Task<ActionResult> GetStudents()
		{
			var students = await db.Students.OrderBy(name => name.Name).ToListAsync();
			return Json(new { data = students }, JsonRequestBehavior.AllowGet);
		}
        // GET: Students/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
			ViewBag.Courses = new SelectList(db.Courses.OrderBy(c => c.Name), "CourseId", "Name");
			return View();
        }

        // POST: Students/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]//[Bind(Include = "StudentId,Name,Surname,Patronymic,DateOfBirth,Email,Activity,Sex,PhoneNumber")]
		public async Task<ActionResult> Create(StudentViewModel studentView)
        {
			if (studentView == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			if (ModelState.IsValid)
			{
				var student = studentView.Student;
				var newCourses = db.Courses.Where(c => studentView.SelectedCourses.Contains(c.CourseId)).ToList();
				var updatedCourses = new HashSet<int>(studentView.SelectedCourses);
				foreach (Course course in db.Courses)
				{
					student.Courses.Add(course);
				}
				db.Students.Add(student);
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(studentView);
		}

        // GET: Students/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			var studentViewModel = new StudentViewModel { Student = await db.Students.Include(i => i.Courses).FirstAsync(i => i.StudentId == id) };
            if (studentViewModel == null)
            {
                return HttpNotFound();
            }
			var allChosenCoursesList = await db.Courses.Where(c => studentViewModel.SelectedCourses.Contains(c.CourseId)).OrderBy(c => c.Name).ToListAsync();
			studentViewModel.AllCourses = allChosenCoursesList.Select(co => new SelectListItem { Text = co.Name, Value = co.CourseId.ToString() });
			ViewBag.Courses = new SelectList(db.Courses.Where(c => !studentViewModel.SelectedCourses.Contains(c.CourseId)).OrderBy(c => c.Name), "CourseId", "Name");
			return View(studentViewModel);
        }

        // POST: Students/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] //[Bind(Include = "StudentId,Name,Surname,Patronymic,DateOfBirth,Email,Activity,Sex,PhoneNumber")]
		public async Task<ActionResult> Edit(StudentViewModel studentView)
        {
			if (studentView == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			if (ModelState.IsValid)
			{
				var studentToUpdate = await db.Students.Include(s => s.Courses).FirstAsync(s => s.StudentId == studentView.Student.StudentId);
				if (TryUpdateModel(studentToUpdate, "Student", new string[] { "Name", "Surname", "Patronymic", "DateOfBirth", "Email", "Activity", "Sex", "PhoneNumber" }))
				{
					var newCourses = db.Courses.Where(c => studentView.SelectedCourses.Contains(c.CourseId)).ToList();
					var updatedCourses = new HashSet<int>(studentView.SelectedCourses);
					foreach (Course course in db.Courses)
					{
						if (!updatedCourses.Contains(course.CourseId))
						{
							studentToUpdate.Courses.Remove(course);
						}
						else
						{
							studentToUpdate.Courses.Add(course);
						}
					}
					db.Entry(studentToUpdate).State = EntityState.Modified;
					await db.SaveChangesAsync();
				}
				return RedirectToAction("Index");
			}
			return View(studentView);
		}

        // GET: Students/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
			
            Student student = await db.Students.FindAsync(id);
            db.Students.Remove(student);
            await db.SaveChangesAsync();
			return new JsonResult { Data = new { status = true } };
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
