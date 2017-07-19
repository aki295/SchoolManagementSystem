using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Models
{
	public class Teacher : Person
	{
		[Key]
		[HiddenInput(DisplayValue = false)]
		public int TeacherId { get; set; }
		public string Position { get; set; }
		public string AddInformation { get; set; }
		public int SalaryPerHour { get; set; }
		public Course Course { get; set; }
		public int? CourseId { get; set; }
	}
}