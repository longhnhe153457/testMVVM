using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class BookDAO
    {
        private static Random random = new Random();
        public static List<Book> GetBooks()
        {
            var listBook = new List<Book>();
            try
            {
                using (var context = new AS2Context())
                {
                    listBook = context.Books.Include(x => x.Pub).ToList(); ;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBook;
        }

        public static Book GetBookById(string id)
        {
            Book? book = new();
            try
            {
                using (var context = new AS2Context())
                {
                    book = context.Books.Include(x => x.Pub).SingleOrDefault(x => x.BookId.Equals(id));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return book;
        }

        public static string SaveBook(Book book)
        {
            book.BookId = GenerateBookId();
            while (GetBookById(book.BookId) != null)
            {
                book.BookId = GenerateBookId();
            }
            try
            {
                using (var context = new AS2Context())
                {
                    context.Books.Add(book);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return book.BookId;
        }

        public static void UpdateBook(Book book)
        {
            try
            {
                using (var context = new AS2Context())
                {
                    context.Entry<Book>(book).State
                        = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteBook(Book book)
        {
            List<BookAuthor> listBookAuthor = BookAuthorDAO.GetAuthorsByBookId(book.BookId);
            if (listBookAuthor.Count > 0)
            {
                listBookAuthor.ForEach(x => BookAuthorDAO.DeleteBookAuthor(x));
            }
            DeleteBookBy(book);
        }

        public static List<Book> GetBooksByPublisherId(string pubId)
        {
            var listBook = new List<Book>();
            try
            {
                using (var context = new AS2Context())
                {
                    listBook = context.Books.Where(x => x.PubId.Equals(pubId)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBook;
        }

        internal static void DeleteBookBy(Book book)
        {
            try
            {
                using (var context = new AS2Context())
                {
                    context.Entry<Book>(book).State
                        = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static string GenerateBookId()
        {
            const string chars = "abcdefghijklmopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
