using BusinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IPublisherRepository
    {
        void SavePublisher(Publisher  c);
        Publisher  GetPublisherById(int id);
        void DeletePublisher(Publisher  p);
        void UpdatePublisher(Publisher  p);
        List<Publisher > GetPublisher();
    }
}
