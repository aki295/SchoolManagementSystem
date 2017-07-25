using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolManagementSystem.Models
{
	public class ApplicationUser : IdentityUser
	{
		public Teacher Profile { get; set; }
		public ApplicationUser()
		{ }
	}
}