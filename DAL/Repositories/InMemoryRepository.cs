using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class InMemoryRepository: IInMemoryRepository
    {
        private readonly MyDBContext db;

        public InMemoryRepository( MyDBContext context )
        {
            db = context;
        }

        public void DeleteBook( int id )
        {
            var book = db.Books.Find( id );
            db.Books.Remove( book );
            db.SaveChanges();
        }

        public Book GetBookById( int id )
        {
            var resultBook = (from book in db.Books
                              where book.Id == id
                              select new Book
                              {
                                  Id = book.Id,
                                  Title = book.Title,
                                  Author = book.Author
                              }).SingleOrDefault();

            return resultBook;
        }

        public IEnumerable<Book> GetBooks()
        {
            var books = (from book in db.Books
                        select new Book
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Author = book.Author
                        }).ToList();

            return books;
        }

        public void CreateBook( Book book )
        {
            int maxIndex;
            try
            {
                maxIndex = db.Books.Select( c => c.Id ).Max() + 1;
            }
            catch
            {
                maxIndex = 1;
            }

            var newBook = new Book()
            {
                Id = maxIndex,
                Title = book.Title,
                Author = book.Author,
            };
            db.Books.Add( newBook );
            db.SaveChanges();
        }

        public void UpdateBook( Book book )
        {
            var newBook = db.Books.Find( book.Id );

            newBook.Title = book.Title;
            newBook.Author = book.Author;

            db.SaveChanges();
        }
    }
}
