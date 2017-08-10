using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Models
{
	public class Student : Person
	{
		[Key]
		[HiddenInput (DisplayValue = false)]
		public int StudentId { get; set; }
		[Display(Name = "E-mail")]
		public string Email { get; set; }
		public bool Sex { get; set; }
		public bool Activity { get; set; }
		public ICollection<Course> Courses { get; set; }
		public Student()
		{
			Courses = new List<Course>();
		}
	}
}