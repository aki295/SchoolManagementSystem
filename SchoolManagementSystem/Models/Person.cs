using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
	abstract public class Person
	{
		public string Name { get; set; }
		public string Surname { get; set;}
		public string Patronymic { get; set; }
		
		[Display(Name = "Phone number")]
		public string PhoneNumber { get; set; }

	}
}