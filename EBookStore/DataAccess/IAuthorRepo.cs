using AutoMapper.Execution;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
     public interface IAuthorRepo
    {
        Author GetAuthorById(string id);
        List<Author> GetAuthors();
        string SaveAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(Author author);
    }
}
