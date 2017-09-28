using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using SchoolManagementSystem.Controllers;
using System.Web.Mvc;
using System.Threading.Tasks;
using Moq;

namespace SchoolManagementSystem.Tests
{
	[TestFixture]
	public class CourseControllerTest
	{
		
		[Test]
		public void Parse()
		{
			var days = new List<string> { "Monday", "Sunday" };
			var st = new List<string> { "12:20", "14:20" };
			var et = new List<string> { "17:00", "20:00" };
			var mock = new Mock<IRepository>();

			CoursesController controller = new CoursesController(mock.Object);
			controller.CreateLessons(days, st, et);
			Assert.AreEqual(days, st);
		}
		[Test]
		public void TestForTestingTest()
		{
			var mock = new Mock<IRepository>();
			mock.Setup(a => a.GetCourseList()).Returns(new List<Models.Course>());
			CoursesController controller = new CoursesController(mock.Object);
			ViewResult result = controller.Index() as ViewResult;
			Assert.IsNotNull(result.Model);
		}
	}
}