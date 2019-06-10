using BLL.DTOs;
using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Text;

namespace Tests
{
    [TestFixture]
    public class InMemoryRepositoryTests
    {
        private DbContextOptions<MyDBContext> options = new DbContextOptionsBuilder<MyDBContext>()
            .UseInMemoryDatabase( databaseName: "BooksDb" ).Options;

        [Test]
        public void InMemoryRepository_CreateBook_PostCorrectData()
        {
            using (var context = new MyDBContext(options))
            {
                var repository = new InMemoryRepository(context);

                var expected = new Book
                {
                    Id = 1,
                    Title = "The Lord of the Rings",
                    Author = "J. R. R. Tolkien",
                };
                repository.CreateBook(expected);

                var actual = repository.GetBookById(1);

                Assert.IsTrue(actual.Id == expected.Id
                              && actual.Author == expected.Author
                              && actual.Title == expected.Title);
            }
        }

    }
}
