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
	public class SubjectsControllerTest
	{
		private readonly StudentsController _studentsController = new StudentsController
		{
			Request = new HttpRequestMessage(),
			Configuration = new HttpConfiguration()
		};

		private readonly SubjectsController _subjectsController = new SubjectsController
		{
			Request = new HttpRequestMessage(),
			Configuration = new HttpConfiguration()
		};

		[TestMethod]
		public void Test()
		{
			var result = _studentsController.PostStudent(new Student
			{
				FirstName = "Andriy",
				MiddleName = "Olegovich",
				LastName = "Melnik",
				DateOfBirth = new DateTime(1997, 10, 2)
			});

			Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);

			result = _subjectsController.PostSubject(14, new Subject
			{
				Name = "Programming",
				Mark = 60
			});

			Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);

			result = _subjectsController.GetSubjects(14);

			Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);

			var subjects = result.Content.ReadAsAsync<List<Subject>>().GetAwaiter().GetResult();
			
			Assert.IsNotNull(subjects);
			Assert.AreEqual(subjects.Count, 1);

			var subject = subjects[0];

			Assert.AreEqual(subject.Name, "Programming");
			Assert.AreEqual(subject.Mark, 60);
		}
	}
}
