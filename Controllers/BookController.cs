using Andrean_Nastanliev_11e.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Andrean_Nastanliev_11e.Data;

namespace Andrean_Nastanliev_11e.Controllers
{
	public class BookController : IController<Book, int>
	{
		public readonly MyContext context;

		public BookController()
		{
			context = new MyContext();
		}

		public BookController(MyContext context)
		{
			this.context = context;
		}

		public void Create(Book book)
		{
			context.Books.Add(book);
			context.SaveChanges();
		}

		public Book Read(int id)
		{
			return context.Books.Find(id)!;
		}

		public List<Book> ReadAll()
		{
			return context.Books.ToList();
		}

		public void Update(Book book)
		{
			var obj = context.Books.FirstOrDefault(o => o.Id == book.Id);
			if (obj == null) return;
			context.Entry(obj).CurrentValues.SetValues(book);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var book = context.Books.FirstOrDefault(u => u.Id == id);
			if (book == null) return;

			foreach(Reader r in book.Readers)
			{
				if(r.Books.Contains(book)) r.Books.Remove(book);
			}

			context.Books.Remove(book);
			context.SaveChanges();
		}

	}
}
