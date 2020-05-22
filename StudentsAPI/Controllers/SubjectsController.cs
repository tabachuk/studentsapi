using StudentsAPI.Models;
using StudentsAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace StudentsAPI.Controllers
{
    public class SubjectsController : ApiController
    {
		private SubjectsService SubjectsService => SubjectsService.Instance;

		[Route("api/subjects/{studentId}")]
		public HttpResponseMessage GetSubjects(int studentId)
		{
			var subjects = SubjectsService.GetSubjects(studentId);
			var response = Request.CreateResponse(HttpStatusCode.OK, subjects);
			return response;
		}

		[Route("api/subjects/{studentId}/{subjectName}")]
		public HttpResponseMessage GetSubject(int studentId, string subjectName)
		{
			var subject = SubjectsService.GetSubject(studentId, subjectName);
			var response = Request.CreateResponse(HttpStatusCode.OK, subject);
			return response;
		}

		[Route("api/subjects/{studentId}")]
		public HttpResponseMessage PostSubject(int studentId, [FromBody]Subject subject)
		{
			SubjectsService.AddSubject(studentId, subject);
			var response = Request.CreateResponse(HttpStatusCode.OK);
			return response;
		}

		[HttpPut]
		[Route("api/subjects/setMark/{subjectId}/{mark}")]
		public HttpResponseMessage SetMark(int subjectId, int mark)
		{
			SubjectsService.SetMark(subjectId, mark);
			var response = Request.CreateResponse(HttpStatusCode.OK);
			return response;
		}

		[Route("api/subjects/{studentId}/{subjectName}")]
		public HttpResponseMessage DeleteSubject(int studentId, string subjectName)
		{
			SubjectsService.RemoveSubject(studentId, subjectName);
			var response = Request.CreateResponse(HttpStatusCode.OK);
			return response;
		}
	}
}