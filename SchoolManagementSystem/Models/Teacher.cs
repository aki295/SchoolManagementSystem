using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Models
{
	public class Teacher : Person
	{
		[Key]
		[HiddenInput(DisplayValue = false)]
		[ForeignKey("ApplicationUser")]
		public string Id { get; set; }
		public string Position { get; set; }
		[Display(Name = "Information")]
		public string AddInformation { get; set; }
		[Display(Name = "Hourly wage")]
		public int SalaryPerHour { get; set; }
		public int Salary { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
		public ICollection<Course> Courses { get; set; }
		public Teacher()
		{
			Courses = new List<Course>();
		}
	}
}