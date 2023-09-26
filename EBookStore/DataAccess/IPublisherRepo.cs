using AutoMapper.Execution;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IPublisherRepo
    {
        Publisher GetPublisherById(string id);
        List<Publisher> GetPublishers();
        void SavePublisher(Publisher publisher);
        void UpdatePublisher(Publisher publisher);
        void DeletePublisher(Publisher publisher);
    }
}
