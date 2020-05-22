using StudentsAPI.Models;
using StudentsAPI.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsAPI.Controllers
{
	public class StudentsController : ApiController
	{
		private StudentsService StudentsService => StudentsService.Instance;

		[Route("api/students")]
		public HttpResponseMessage GetStudents()
		{
			var students = StudentsService.GetStudents();
			var response = Request.CreateResponse(HttpStatusCode.OK, students);
			return response;
		}

		[Route("api/students/{id}")]
		public HttpResponseMessage GetStudent(int id)
		{
			var student = StudentsService.GetStudent(id);
			var response = Request.CreateResponse(HttpStatusCode.OK, student);
			return response;
		}

		[Route("api/students")]
		public HttpResponseMessage PostStudent([FromBody]Student student)
		{
			StudentsService.AddStudent(student);
			var response = Request.CreateResponse(HttpStatusCode.OK);
			return response;
		}

		[Route("api/students/{id}")]
		public HttpResponseMessage PutStudent(int id, [FromBody]Student student)
		{
			StudentsService.ChangeStudent(id, student);
			var response = Request.CreateResponse(HttpStatusCode.OK);
			return response;
		}

		[Route("api/students/{id}")]
		public HttpResponseMessage DeleteStudent(int id)
		{
			StudentsService.RemoveStudent(id);
			var response = Request.CreateResponse(HttpStatusCode.OK);
			return response;
		}
	}
}
