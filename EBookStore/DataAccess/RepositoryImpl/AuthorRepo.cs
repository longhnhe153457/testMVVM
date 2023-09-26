using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RepositoryImpl
{
    public class AuthorRepo : IAuthorRepo
    {
        public Author GetAuthorById(string id) => AuthorDAO.GetAuthorById(id);

        public List<Author> GetAuthors() => AuthorDAO.GetAuthors();

        public string SaveAuthor(Author author) => AuthorDAO.SaveAuthor(author);

        public void UpdateAuthor(Author author) => AuthorDAO.UpdateAuthor(author);

        public void DeleteAuthor(Author author) => AuthorDAO.DeleteAuthor(author);

    }
}
