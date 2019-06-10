using BLL.DTOs;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class BookServiceTests
    {
        private IBookService bookService;
        private Mock<IInMemoryRepository> inMemoryRepositoryMock;

        [Test]
        public void BookService_GetBook_ReturnCorrectData()
        {
            var repoBook = new Book
            {
                Id = 1,
                Title = "The Lord of the Rings",
                Author = "J. R. R. Tolkien",
            };

            BookDTO book = new BookDTO()
            {
                Id = repoBook.Id,
                Title = repoBook.Title,
                Author = repoBook.Author
            };

            inMemoryRepositoryMock = new Mock<IInMemoryRepository>();
            inMemoryRepositoryMock.Setup( x => x.GetBookById( It.IsAny<int>() ) ).Returns( repoBook );
            bookService = new BookService( inMemoryRepositoryMock.Object );

            BookDTO bookActual = bookService.GetBook( 1 );

            Assert.AreEqual( book.Id, bookActual.Id );
            Assert.AreEqual( book.Author, bookActual.Author );
            Assert.AreEqual( book.Title, bookActual.Title );
        }

        [Test]
        public void BookService_GetBooks_ReturnsCorrectData()
        {
            var repoBooks = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "The Lord of the Rings",
                    Author = "J. R. R. Tolkien",
                },
                new Book
                {
                    Id = 2,
                    Title = "Arthur and the Invisibles",
                    Author = "Luc Besson",
                },
                new Book
                {
                    Id = 3,
                    Title = "The Witcher",
                    Author = " Andrzej Sapkowski",
                }
            };

            inMemoryRepositoryMock = new Mock<IInMemoryRepository>();
            inMemoryRepositoryMock.Setup( x => x.GetBooks() ).Returns( repoBooks );
            bookService = new BookService( inMemoryRepositoryMock.Object );

            IEnumerable<BookDTO> bookActual = bookService.GetAllBooks();
            Assert.AreEqual( bookActual.Count(), 3, "Books count is not correct" );
        }
    }
}
