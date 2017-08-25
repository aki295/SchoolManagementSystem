using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolManagementSystem.Models;
using System.Web.Mvc;

namespace SchoolManagementSystem.ViewModels
{
	public class StudentViewModel
	{
		public Student Student { get; set; }
		public IEnumerable<SelectListItem> AllCourses { get; set; }
		private List<int> _selectedCourses;
		public List<int> SelectedCourses
		{
			get
			{
				if (_selectedCourses == null)
				{
					_selectedCourses = Student.Courses.Select(s => s.CourseId).ToList();
				}
				return _selectedCourses;
			}
			set { _selectedCourses = value; }
		}
	}
}