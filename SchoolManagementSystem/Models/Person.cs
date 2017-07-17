using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
	abstract public class Person
	{
		public string Name { get; set; }
		public string Surname { get; set;}
		public string Patronymic { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }

	}
}