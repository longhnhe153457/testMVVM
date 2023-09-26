using BusinessObject.Models;
using DataAccess.DAO;

namespace DataAccess.RepositoryImpl
{
    public class BookAuthorRepo : IBookAuthorRepo
    {
        public List<BookAuthor> GetBooksAuthors() => BookAuthorDAO.GetBooksAuthors();

        public List<BookAuthor> GetAuthorsByBookId(string id) => BookAuthorDAO.GetAuthorsByBookId(id);

        public List<BookAuthor> GetBooksByAuthorId(string id) => BookAuthorDAO.GetBooksByAuthorId(id);

        public void SaveBookAuthor(BookAuthor bookAuthor) => BookAuthorDAO.SaveBookAuthor(bookAuthor);

        public void UpdateBookAuthor(BookAuthor bookAuthor, string bookId, string authorId) => BookAuthorDAO.UpdateBookAuthor(bookAuthor, bookId, authorId);

        public void DeleteBookAuthor(BookAuthor bookAuthor) => BookAuthorDAO.DeleteBookAuthor(bookAuthor);

        public BookAuthor GetBookAuthorById(string bookId, string authorId) => BookAuthorDAO.GetBookAuthorById(bookId, authorId);

    }
}
