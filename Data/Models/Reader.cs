using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Andrean_Nastanliev_11e.Data.Models
{
	[Table("Readers")]
	public class Reader
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }
		
		[Required]
		[Range(10,80)]
		public byte Age { get; set; }

		[EmailAddress]
		[Required]
		[MaxLength(20)]
		public string Email { get; set; }

		[Required]
		[MinLength(10)]
		[MaxLength(10)]
		public string PhoneNumber { get; set; }

		public List<Book> Books { get; set; }
	}
}
