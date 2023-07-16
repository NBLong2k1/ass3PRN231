using BusinessObject.Model.Entities;
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
        public static List<Publisher> GetPublisher()
        {
            var listPublisher = new List<Publisher>();

            try
            {

                using (var context = new eBookStoreContext())
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
        public static Publisher  FindPublisherById(int PublisherId)
        {
            var  p = new Publisher ();
            try
            {
                using (var context = new eBookStoreContext())
                {
                    p = context.Publishers.SingleOrDefault(x => x.PubId == PublisherId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return p;
        }
        public static void SavePublisher(Publisher  p)
        {
            try
            {
                using (var context = new eBookStoreContext())
                {
                    context.Publishers.Add(p);
                    context.SaveChanges();
                }

                Console.WriteLine("check");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void UpdatePublisher(Publisher  p)
        {
            try
            {
                using (var context = new eBookStoreContext())
                {
                    context.Publishers.Update(p);
                    // context.Entry<Products>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public static void DeletePublisher(Publisher  p)
        {
            try
            {
                using (var context = new eBookStoreContext())
                {
                    var p1 = context.Publishers.SingleOrDefault(x => x.PubId == p.PubId);
                    context.Publishers.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
