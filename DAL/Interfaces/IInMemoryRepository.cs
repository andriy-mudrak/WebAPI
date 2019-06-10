using DAL.Models;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IInMemoryRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById( int id );
        void CreateBook( Book book );
        void UpdateBook( Book book );
        void DeleteBook( int id );
    }
}
