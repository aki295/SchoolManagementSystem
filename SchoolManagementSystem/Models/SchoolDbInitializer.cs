﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SchoolManagementSystem.Models
{
	public class SchoolDbInitializer : DropCreateDatabaseAlways<SchoolContext>
	{
		protected override void Seed(SchoolContext context)
		{
			
			Student s1 = new Student { Name = "Ivan", Surname = "Ivanov", Patronymic = "Ivanovich", PhoneNumber = "+79132223311", Email = "asdf@mail.ru", Activity = true, Sex = true, DateOfBirth = new DateTime(1991, 11, 25) };
			Course c1 = new Course { Name = "FirstCourse", Language = Language.English, LanguageProficiency = LanguageProficiency.B2_UpperIntermediate, StartDate = new DateTime(2017, 8, 24), EndDate = new DateTime(2017, 12, 31), Students = new List<Student> { s1 } };
			Course c2 = new Course { Name = "SecondCourse", Language = Language.English, LanguageProficiency = LanguageProficiency.B2_UpperIntermediate, StartDate = new DateTime(2017, 8, 24), EndDate = new DateTime(2017, 12, 31) };
			Course c3 = new Course { Name = "ThirdCourse", Language = Language.English, LanguageProficiency = LanguageProficiency.B2_UpperIntermediate, StartDate = new DateTime(2017, 8, 24), EndDate = new DateTime(2017, 12, 31), Students = new List<Student> { s1 } };
			Course c4 = new Course { Name = "FourthCourse", Language = Language.English, LanguageProficiency = LanguageProficiency.B2_UpperIntermediate, StartDate = new DateTime(2017, 8, 24), EndDate = new DateTime(2017, 12, 31), Students = new List<Student> { s1 } };
			context.Students.Add(s1);
			context.Courses.Add(c1);
			context.Courses.Add(c2);
			context.Courses.Add(c3);
			context.Courses.Add(c4);
			base.Seed(context);
		}
	}
}