using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RepositoryImpl
{
    public class PublisherRepo : IPublisherRepo
    {
        public Publisher GetPublisherById(string id) => PublisherDAO.GetPublisherById(id);
        public List<Publisher> GetPublishers() => PublisherDAO.GetPublishers();
        public void SavePublisher(Publisher publisher) => PublisherDAO.SavePublisher(publisher);
        public void UpdatePublisher(Publisher publisher) => PublisherDAO.UpdatePublisher(publisher);
        public void DeletePublisher(Publisher publisher) => PublisherDAO.DeletePublisher(publisher);
    }
}
