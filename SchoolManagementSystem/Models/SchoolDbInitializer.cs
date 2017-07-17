using System;
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
			context.Students.Add(new Student { Name = "Ivan", Surname = "Ivanov" });
			base.Seed(context);
		}
	}
}