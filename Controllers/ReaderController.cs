using Andrean_Nastanliev_11e.Data.Models;
using Andrean_Nastanliev_11e.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andrean_Nastanliev_11e.Controllers
{
	public class ReaderController : IController<Reader, int>
	{
		public readonly MyContext context;

		public ReaderController()
		{
			context = new MyContext();
		}

		public ReaderController(MyContext context)
		{
			this.context = context;
		}

		public void Create(Reader reader)
		{
			context.Readers.Add(reader);
			context.SaveChanges();
		}

		public Reader Read(int id)
		{
			return context.Readers.Find(id)!;
		}

		public List<Reader> ReadAll()
		{
			return context.Readers.ToList();
		}

		public void Update(Reader reader)
		{
			var obj = context.Readers.FirstOrDefault(o => o.Id == reader.Id);
			if (obj == null) return;
			context.Entry(obj).CurrentValues.SetValues(reader);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var reader = context.Readers.FirstOrDefault(u => u.Id == id);
			if (reader == null) return;

			List<Genre> genres = context.Genres.ToList();

			foreach (var genre in genres)
			{
				if (genre.Readers.Contains(reader))
				{
					genre.Readers.Remove(reader);
				}
			}

			List<Book> books = context.Books.ToList();

			foreach (var book in books)
			{
				if(book.Readers.Contains(reader))
				{
					book.Readers.Remove(reader);
				}
			}

			context.Readers.Remove(reader);
			context.SaveChanges();
		}

	}
}
