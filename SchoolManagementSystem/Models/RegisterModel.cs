using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
	public class RegisterModel
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Surname { get; set; }
		public string Patronymic { get; set; }
		[Required]
		public DateTime DateOfBirth { get; set; }

		[Display(Name = "Phone number")]
		public string PhoneNumber { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required]
		[Compare("Password", ErrorMessage = "Passwords don't match")]
		[DataType(DataType.Password)]
		public string PasswordConfirm { get; set; }
		[Required]
		public string Position { get; set; }
		public string AddInformation { get; set; }
		[Required]
		public int SalaryPerHour { get; set; }
	}
}