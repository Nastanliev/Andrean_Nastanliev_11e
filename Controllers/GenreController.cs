using Andrean_Nastanliev_11e.Data;
using Andrean_Nastanliev_11e.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andrean_Nastanliev_11e.Controllers
{
	public class GenreController : IController <Genre, int>
	{
		public readonly MyContext context;

		public GenreController()
		{
			context = new MyContext();
		}

		public GenreController(MyContext context)
		{
			this.context = context;
		}

		public void Create(Genre genre)
		{
			context.Genres.Add(genre);
			context.SaveChanges();
		}

		public Genre Read(int id)
		{
			return context.Genres.Find(id)!;
		}

		public List<Genre> ReadAll()
		{
			return context.Genres.ToList();
		}

		public void Update(Genre genre)
		{
			var obj = context.Genres.FirstOrDefault(o => o.Id == genre.Id);
			if (obj == null) return;
			context.Entry(obj).CurrentValues.SetValues(genre);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var genre = context.Genres.FirstOrDefault(u => u.Id == id);
			if (genre == null) return;

			List<Book> books = context.Books.ToList();

			foreach (Book b in books)
			{
				if(b.Genres.Contains(genre))
				{
					b.Genres.Remove(genre);
				}
			}

			context.Genres.Remove(genre);
			context.SaveChanges();
		}

	}
}
