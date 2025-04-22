using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Andrean_Nastanliev_11e.Data.Models
{
	[Table("Books")]
	public class Book
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Title { get; set; }

		[MaxLength(50)]	
		public string Author { get; set; }	

		public List<Reader> Readers { get; set; }

		public List<Genre > Genres { get; set; }
	}
}
