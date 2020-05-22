using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsAPI.Models
{
	[Table("Subjects")]
	public class Subject
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public int Mark { get; set; }

		[JsonIgnore]
		public virtual Student Student { get; set; }
	}
}