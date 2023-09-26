using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AuthorDAO
    {
        private static Random random = new Random();
        public static List<Author> GetAuthors()
        {
            var listAuthor = new List<Author>();
            try
            {
                using (var context = new AS2Context())
                {
                    listAuthor = context.Authors.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listAuthor;
        }

        public static Author GetAuthorById(string id)
        {
            Author? author = new();
            try
            {
                using (var context = new AS2Context())
                {
                    author = context.Authors.SingleOrDefault(x => x.AuthorId.Equals(id));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return author;
        }

        public static string SaveAuthor(Author author)
        {
            author.AuthorId = GenerateAuthorId();
            //if id gen exists, gen new id
            while (GetAuthorById(author.AuthorId) != null)
            {
                author.AuthorId = GenerateAuthorId();
            }
            try
            {
                using (var context = new AS2Context())
                {
                    context.Authors.Add(author);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return author.AuthorId;
        }

        public static void UpdateAuthor(Author author)
        {
            try
            {
                using (var context = new AS2Context())
                {
                    context.Entry<Author>(author).State
                        = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteAuthor(Author author)
        {
            List<BookAuthor> listBookAuthor = BookAuthorDAO.GetBooksByAuthorId(author.AuthorId);
            if (listBookAuthor.Count > 0)
            {
                listBookAuthor.ForEach(x => BookAuthorDAO.DeleteBookAuthor(x));
            }
            DeleteAuthorBy(author);
        }

        internal static void DeleteAuthorBy(Author author)
        {
            try
            {
                using (var context = new AS2Context())
                {
                    context.Entry<Author>(author).State
                        = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static string GenerateAuthorId()
        {
            const string chars = "abcdefghijklmopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
