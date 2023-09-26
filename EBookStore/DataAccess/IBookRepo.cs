using AutoMapper.Execution;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IBookRepo
    {
        Book GetBookById(string id);
        List<Book> GetBooks();
        string SaveBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}
