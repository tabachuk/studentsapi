using StudentsAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentsAPI.DBContexts
{
	public class StudentsDBContext : DbContext
	{
		private static StudentsDBContext _instance;

		public static StudentsDBContext Instance
		{
			get
			{
				if (_instance == null)
					_instance = new StudentsDBContext();

				return _instance;
			}
		}

		public StudentsDBContext() : base("Server=DESKTOP-52LQESQ\\SQLEXPRESS;Database=StudentsDB;Trusted_Connection=True")
		{

		}

		public DbSet<Student> Students { get; set; }

		public DbSet<Subject> Subjects { get; set; }
	}
}