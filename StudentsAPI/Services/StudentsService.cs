using StudentsAPI.DBContexts;
using StudentsAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentsAPI.Services
{
	public class StudentsService
	{
		private static StudentsService _instance;
		public static StudentsService Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new StudentsService();
				}

				return _instance;
			}
		}

		private readonly StudentsDBContext _dataBase;

		public StudentsService()
		{
			_dataBase = StudentsDBContext.Instance;
		}

		public List<Student> GetStudents()
		{
			return _dataBase.Students.ToList();
		}

		public Student GetStudent(int id)
		{
			return _dataBase.Students.FirstOrDefault(x => x.Id == id);
		}

		public void AddStudent(Student student)
		{
			_dataBase.Students.Add(student);
			_dataBase.SaveChanges();
		}

		public void ChangeStudent(int id, Student student)
		{
			var oldStudent = GetStudent(id);

			oldStudent.Address = student.Address;
			oldStudent.DateOfBirth = student.DateOfBirth;
			oldStudent.FirstName = student.FirstName;
			oldStudent.MiddleName = student.MiddleName;
			oldStudent.LastName = student.LastName;

			_dataBase.SaveChanges();
		}

		public void RemoveStudent(int id)
		{
			_dataBase.Students.Remove(GetStudent(id));
			_dataBase.SaveChanges();
		}
	}
}