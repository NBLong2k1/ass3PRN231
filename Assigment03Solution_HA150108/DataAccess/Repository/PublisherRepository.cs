using BusinessObject.Model.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        public void DeletePublisher(Publisher  p) => PublisherDAO.DeletePublisher(p);

        public List<Publisher > GetPublisher() => PublisherDAO.GetPublisher();

        public Publisher  GetPublisherById(int id) => PublisherDAO.FindPublisherById(id);

        public void SavePublisher(Publisher  c) => PublisherDAO.SavePublisher(c);

        public void UpdatePublisher(Publisher  p) => PublisherDAO.UpdatePublisher(p);
    }
}
