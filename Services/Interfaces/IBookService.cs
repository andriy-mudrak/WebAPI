using BLL.DTOs;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetAllBooks();
        BookDTO GetBook( int id );
        void CreateBook( BookDTO book );
        void UpdateBook( BookDTO book );
        void DeleteBook( int id );

    }
}
