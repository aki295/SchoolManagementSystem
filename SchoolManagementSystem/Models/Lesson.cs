using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
	public class Lesson
	{
		[Key]
		public int LessonId { get; set; }
		public string Homework { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public DayOfWeek DayOfWeek { get; set; }
		public int? CourseId { get; set; }
		public Course Course { get; set; }
		public StudyRoom StudyRoom { get; set; }
	}
}