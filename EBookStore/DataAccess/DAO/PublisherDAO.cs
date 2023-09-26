using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class PublisherDAO
    {
        private static Random random = new Random();
        public static List<Publisher> GetPublishers()
        {
            var listPublisher = new List<Publisher>();
            try
            {
                using (var context = new AS2Context())
                {
                    listPublisher = context.Publishers.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listPublisher;
        }

        public static Publisher GetPublisherById(string id)
        {
            Publisher? publisher = new();
            try
            {
                using (var context = new AS2Context())
                {
                    publisher = context.Publishers.SingleOrDefault(x => x.PubId.Equals(id));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return publisher;
        }

        public static void SavePublisher(Publisher publisher)
        {
            publisher.PubId = GeneratePubId();
            while (GetPublisherById(publisher.PubId) != null)
            {
                publisher.PubId = GeneratePubId();
            }
            try
            {
                using (var context = new AS2Context())
                {
                    context.Publishers.Add(publisher);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdatePublisher(Publisher publisher)
        {
            try
            {
                using (var context = new AS2Context())
                {
                    context.Entry<Publisher>(publisher).State
                        = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeletePublisher(Publisher publisher)
        {
            List<User> users = UserDAO.GetUsersByPublisherId(publisher.PubId);
            List<Book> books = BookDAO.GetBooksByPublisherId(publisher.PubId);
            if (users.Count > 0)
            {
                users.ForEach(x => UserDAO.DeleteUser(x));
            }
            if (books.Count > 0)
            {
                books.ForEach(x => BookDAO.DeleteBook(x));
            }
            DeletePublisherBy(publisher);
        }
        internal static void DeletePublisherBy(Publisher publisher)
        {
            try
            {
                using (var context = new AS2Context())
                {
                    context.Entry<Publisher>(publisher).State
                        = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static string GeneratePubId()
        {
            const string chars = "abcdefghijklmopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
