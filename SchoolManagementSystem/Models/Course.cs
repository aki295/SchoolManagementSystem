using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
	public class Course
	{
		public int CourseId { get; set; }
		public string Name { get; set; }
		public Language Language { get; set; }
		[Display(Name = "Language Proficiency")]
		public LanguageProficiency LanguageProficiency { get; set; }
		[Display(Name = "Start")]
		[DataType(DataType.Date)]
		public DateTime StartDate { get; set; }
		[Display(Name = "End")]
		[DataType(DataType.Date)]
		public DateTime EndDate { get; set; }
		public int NumberOfLessonsPerWeek { get; set; }
		public string TeacherId { get; set; }
		public Teacher Teacher { get; set; }
		public ICollection<Student> Students { get; set; }
		public ICollection<Lesson> Lessons { get; set; }
		public Course()
		{
			Students = new List<Student>();
			Lessons = new List<Lesson>();
		}
	}
	public enum Language
	{
		English,
		French,
		Spanish,
		Russian,
		German,
		Chinese,
		Italian
	}
	public enum LanguageProficiency
	{
		A1_Begginer,
		A1_Elementary,
		A2_PreIntermediate,
		B1_Intermediate,
		B1_IntermediatePlus,
		B2_UpperIntermediate,
		C1_Advanced,
		C2_Proficiency
	}
}