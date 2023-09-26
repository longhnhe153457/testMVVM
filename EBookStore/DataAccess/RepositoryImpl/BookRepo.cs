using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RepositoryImpl
{
    public class BookRepo : IBookRepo
    {
        public Book GetBookById(string id) => BookDAO.GetBookById(id);

        public List<Book> GetBooks() => BookDAO.GetBooks();

        public string SaveBook(Book book) => BookDAO.SaveBook(book);

        public void UpdateBook(Book book) => BookDAO.UpdateBook(book);

        public void DeleteBook(Book book) => BookDAO.DeleteBook(book);
    }
}
