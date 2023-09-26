using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IBookAuthorRepo
    {
        List<BookAuthor> GetBooksAuthors();
        List<BookAuthor> GetAuthorsByBookId(string id);
        List<BookAuthor> GetBooksByAuthorId(string id);
        void SaveBookAuthor(BookAuthor bookAuthor);
        void UpdateBookAuthor(BookAuthor bookAuthor, string bookId, string authorId);
        void DeleteBookAuthor(BookAuthor bookAuthor);
        BookAuthor GetBookAuthorById(string bookId, string authorId);
    }
}
