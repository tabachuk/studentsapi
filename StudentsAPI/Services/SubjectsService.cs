using StudentsAPI.DBContexts;
using StudentsAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentsAPI.Services
{
	public class SubjectsService
	{
		private static SubjectsService _instance;
		public static SubjectsService Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new SubjectsService();
				}

				return _instance;
			}
		}

		private readonly StudentsDBContext _dataBase;

		public SubjectsService()
		{
			_dataBase = StudentsDBContext.Instance;
		}

		public List<Subject> GetSubjects(int studentId)
		{
			return _dataBase.Students.FirstOrDefault(x => x.Id == studentId)?.Subjects?.ToList();
		}

		public Subject GetSubject(int studentId, string subjectName)
		{
			return GetSubjects(studentId)?.FirstOrDefault(x => x.Name == subjectName);
		}

		public void AddSubject(int studentId, Subject subject)
		{
			var student = _dataBase.Students.FirstOrDefault(x => x.Id == studentId);
			student?.Subjects.Add(subject);
			_dataBase.SaveChanges();
		}

		public void SetMark(int subjectId, int mark)
		{
			var subject = _dataBase.Subjects.FirstOrDefault(x => x.Id == subjectId);
			
			if (subject != null)
			{
				subject.Mark = mark;
				_dataBase.SaveChanges();
			}
		}

		public void RemoveSubject(int studentId, string subjectName)
		{
			_dataBase.Subjects.Remove(GetSubject(studentId, subjectName));
			_dataBase.SaveChanges();
		}
	}
}