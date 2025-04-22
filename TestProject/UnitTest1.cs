using Andrean_Nastanliev_11e.Data;
using Andrean_Nastanliev_11e.Data.Models;
using Andrean_Nastanliev_11e.Controllers;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace TestProject1
{
	public class Tests
	{
		private MyContext context;
		private GenreController controller;

		[SetUp]
		public void Setup()
		{
			var options = new DbContextOptionsBuilder<MyContext>().UseInMemoryDatabase(databaseName : "Library").Options; 

			context = new MyContext(options);
			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			var genre = new Genre { Name = "Adventure" };

			context.Genres.Add(genre);
			context.SaveChanges();

			controller = new GenreController(context);

		}


		[TearDown]
		public void InitializeContext()
		{
			context.Dispose();
		}

		[Test]
		public void Create_AddsGenre()
		{
			var genre = new Genre { Name = "Mystery" };

			controller.Create(genre);

			var result = context.Genres.FirstOrDefault(g => g.Name == "Mystery");
			Assert.That(result, Is.Not.Null);
		}

		[Test]
		public void Read_ReturnsCorrectGenre()
		{

			var result = controller.Read(1);

			Assert.That(result, Is.Not.Null);
		}

		[Test]
		public void ReadAll_ReturnsAllGenres()
		{

			var result = controller.ReadAll();

			Assert.That(1,Is.EqualTo(result.Count));
		}

		[Test]
		public void Update_UpdatesGenre()
		{
			var genre = context.Genres.FirstOrDefault(g => g.Name == "Adventure");
			genre.Name += "2";
			controller.Update(genre);

			var result = context.Genres.Find(genre.Id);

			Assert.That(result, Is.Not.Null);
			Assert.That("Adventure2", Is.EqualTo(result.Name));

		}

 		[Test]
		public void Delete_RemovesGenre()
		{
			var genre = new Genre { Name = "Romance" };
			context.Genres.Add(genre);
			context.SaveChanges();

			controller.Delete(genre.Id);

			var result = context.Genres.FirstOrDefault(g => g.Id == genre.Id);
			Assert.That(result, Is.Null);
		}
	
    }
}
