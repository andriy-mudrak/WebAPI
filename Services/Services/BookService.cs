using BLL.DTOs;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
namespace BLL.Services
{
    public class BookService: IBookService
    {
        private IInMemoryRepository iInMemoryRepository;

        public BookService( IInMemoryRepository iInMemoryRepository )
        {
            this.iInMemoryRepository = iInMemoryRepository;
        }

        public void CreateBook( BookDTO book )
        {
            var newBook = new Book()
            {
                Title = book.Title,
                Author = book.Author,
            };

            iInMemoryRepository.CreateBook( newBook );
        }

        public void DeleteBook( int id )
        {
            iInMemoryRepository.DeleteBook( id );
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            var books = (from book in iInMemoryRepository.GetBooks()
                        select new BookDTO
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Author = book.Author
                        }).ToList();
            return books;
        }
           

        public BookDTO GetBook( int id )
        {
            var book = iInMemoryRepository.GetBookById( id );
            return new BookDTO()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
            };
        }

        public void UpdateBook( BookDTO book )
        {
            var newBook = new Book()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
            };
            iInMemoryRepository.UpdateBook( newBook );
        }
    }
}
