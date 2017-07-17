using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
	public class Course
	{
		public int CourseId { get; set; }
		public string Name { get; set; }
		public Language Language { get; set; }
		public LanguageProficiency LanguageProficiency { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public ICollection<Teacher> Teachers { get; set; }
		public ICollection<Student> Students { get; set; }
		public Course()
		{
			Teachers = new List<Teacher>();
			Students = new List<Student>();
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
	/*public sealed class LanguageProficiency
	{
		private readonly string name;
		private readonly int value;
		private LanguageProficiency(int value, string name)
		{
			this.name = name;
			this.value = value;
		}
		public override string ToString()
		{
			return name;
		}
		public static readonly LanguageProficiency A1_Begginer = new LanguageProficiency(1, "A1 - Begginer");
		public static readonly LanguageProficiency A1_Elementary = new LanguageProficiency(2, "A1 - Elementary");
		public static readonly LanguageProficiency A2_PreIntermediate = new LanguageProficiency(3, "A1 - Pre-Intermediate");
		public static readonly LanguageProficiency B1_Intermediate = new LanguageProficiency(4, "B1 - Intermediate");
		public static readonly LanguageProficiency B1_IntermediatePlus = new LanguageProficiency(5, "B1 - Intermediate+");
		public static readonly LanguageProficiency B2_UpperIntermediate = new LanguageProficiency(6, "B2 - Upper-Intermediate");
		public static readonly LanguageProficiency C1_Advanced = new LanguageProficiency(7, "C1 - Advanced");
		public static readonly LanguageProficiency C2_Proficiency = new LanguageProficiency(8, "C2 - Proficiency");
	}*/
}