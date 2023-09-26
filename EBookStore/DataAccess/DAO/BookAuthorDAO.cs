using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class BookAuthorDAO
    {
        public static List<BookAuthor> GetAuthorsByBookId(string id)
        {
            var listBookAuthor = new List<BookAuthor>();
            try
            {
                using (var context = new AS2Context())
                {
                    listBookAuthor = context.BookAuthors.Where(x => x.BookId.Equals(id)).Include(x => x.Author).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBookAuthor;
        }

        public static List<BookAuthor> GetBooksByAuthorId(string id)
        {
            var listBookAuthor = new List<BookAuthor>();
            try
            {
                using (var context = new AS2Context())
                {
                    listBookAuthor = context.BookAuthors.Where(x => x.AuthorId.Equals(id)).Include(x => x.Book).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBookAuthor;
        }

        public static List<BookAuthor> GetBooksAuthors()
        {
            var listBookAuthor = new List<BookAuthor>();
            try
            {
                using (var context = new AS2Context())
                {
                    listBookAuthor = context.BookAuthors.Include(x => x.Author).Include(x => x.Book).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBookAuthor;
        }

        public static void SaveBookAuthor(BookAuthor bookAuthor)
        {
            if (GetBookAuthorById(bookAuthor.BookId, bookAuthor.AuthorId) == null)
            {
                try
                {
                    using (var context = new AS2Context())
                    {
                        context.BookAuthors.Add(bookAuthor);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void UpdateBookAuthor(BookAuthor bookAuthor, string bookId, string authorId)
        {
            if (bookAuthor.BookId != bookId || bookAuthor.AuthorId != authorId)
            {
                if (GetBookAuthorById(bookId, authorId) == null)
                {
                    SaveBookAuthor(bookAuthor);
                    bookAuthor.BookId = bookId;
                    bookAuthor.AuthorId = authorId;
                    DeleteBookAuthor(bookAuthor);
                }
            } else
            {

                try
                {
                    using (var context = new AS2Context())
                    {
                        context.Entry<BookAuthor>(bookAuthor).State
                            = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void DeleteBookAuthor(BookAuthor bookAuthor)
        {
            try
            {
                using (var context = new AS2Context())
                {
                    context.Entry<BookAuthor>(bookAuthor).State
                        = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        
        public static BookAuthor GetBookAuthorById(string bookId, string authorId)
        {
            BookAuthor? bookAuthor = new();
            try
            {
                using (var context = new AS2Context())
                {
                    bookAuthor = context.BookAuthors.SingleOrDefault(x => x.BookId.Equals(bookId)
                                                                        && x.AuthorId.Equals(authorId));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bookAuthor;
        }
        
    }
}
