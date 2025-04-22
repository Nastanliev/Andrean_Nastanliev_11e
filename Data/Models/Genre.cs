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
	[Table("Genres")]
	public class Genre
	{
		[Key]
		public int Id { get; set; }

		[MaxLength(20)]
		[Required]
		public string Name { get; set; }

		public List<Reader> Readers { get; set; }	

	}
}
