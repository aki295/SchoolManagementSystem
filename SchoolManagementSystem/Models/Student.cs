using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
	public class Student : Person
	{
		[Key]
		public int StudentId { get; set; }
		public ICollection<Course> Courses { get; set; }
		public Student()
		{
			Courses = new List<Course>();
		}
	}
}