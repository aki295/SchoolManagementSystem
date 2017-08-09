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
		[Required]
		public string Patronymic { get; set; }
		[Required]
		[Display(Name = "Date of birth")]
		public DateTime DateOfBirth { get; set; }
		[Required]
		[Display(Name = "Phone number")]
		public string PhoneNumber { get; set; }
		[Required]
		[Display(Name = "E-mail")]
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
		[Display(Name = "Information")]
		public string AddInformation { get; set; }
		[Required]
		[Display(Name = "Hourly wage")]
		public int SalaryPerHour { get; set; }
		[Required]
		public int Salary { get; set; }
	}
}