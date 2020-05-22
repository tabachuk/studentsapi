using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsAPI.Controllers;
using StudentsAPI.Models;

namespace StudentsAPI.Tests.Controllers
{
	[TestClass]
	public class StudentsControllerTest
	{
		private readonly StudentsController _controller = new StudentsController
		{
			Request = new HttpRequestMessage(),
			Configuration = new HttpConfiguration()
		};

		[TestMethod]
		public void Test()
		{
			var result = _controller.PostStudent(new Models.Student
			{
				FirstName = "Andriy",
				MiddleName = "Olegovich",
				LastName = "Melnik",
				DateOfBirth = new DateTime(1997, 10, 2)
			});

			Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);

			result = _controller.PostStudent(new Models.Student
			{
				FirstName = "Oleg",
				MiddleName = "Andriyovich",
				LastName = "Burnasenkov",
				DateOfBirth = new DateTime(1997, 12, 8)
			});

			Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);

			result = _controller.PostStudent(new Models.Student
			{
				FirstName = "Ivan",
				MiddleName = "Igorovich",
				LastName = "Yefimov",
				DateOfBirth = new DateTime(1997, 5, 8)
			});

			Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);

			result = _controller.GetStudents();

			Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);
			var students = result.Content.ReadAsAsync<List<Student>>().GetAwaiter().GetResult();
			Assert.IsNotNull(students);
			Assert.AreEqual(students.Count, 3);

			result = _controller.GetStudent(students[0].Id);

			Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);

			var student = result.Content.ReadAsAsync<Student>().GetAwaiter().GetResult();
			Assert.IsNotNull(student);
			Assert.AreEqual(student.FirstName, "Andriy");
			Assert.AreEqual(student.MiddleName, "Olegovich");
			Assert.AreEqual(student.LastName, "Melnik");
			Assert.AreEqual(student.DateOfBirth, new DateTime(1997, 10, 2));

			foreach (var st in students)
			{
				result = _controller.DeleteStudent(st.Id);
				Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);
			}

			result = _controller.GetStudents();

			Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);
			students = result.Content.ReadAsAsync<List<Student>>().GetAwaiter().GetResult();
			Assert.IsNotNull(students);
			Assert.AreEqual(students.Count, 0);
		}
	}
}
