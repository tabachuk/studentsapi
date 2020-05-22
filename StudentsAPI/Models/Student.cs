using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsAPI.Models
{
	[Table("Students")]
	public class Student
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string MiddleName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public DateTime DateOfBirth { get; set; }

		public string Address { get; set; }

		public virtual ICollection<Subject> Subjects { get; set; }

		public Student()
		{
			Subjects = new List<Subject>();
		}
	}
}