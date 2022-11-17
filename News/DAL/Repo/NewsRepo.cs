using DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public class NewsRepo : IRepo<News, int>
    {
        public void Create(News data)
        {
            var db = new NewsAppEntities();
            db.Newses.Add(data);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var db = new NewsAppEntities();
            db.Newses.Remove(db.Newses.Find(id));
            db.SaveChanges();
        }

        public List<News> Get()
        {
            var db = new NewsAppEntities();
            var newses = db.Newses.ToList();
            return newses;
        }

        public News Get(int id)
        {
            var db = new NewsAppEntities();
            var news = db.Newses.SingleOrDefault(n => n.Id == id);
            return news;
        }

        public News Update(News data)
        {
            var db = new NewsAppEntities();
            var news = db.Newses.SingleOrDefault(n => n.Id == data.Id);
            news.Title = data.Title;
            news.CategoryId = data.CategoryId;
            news.Date = data.Date;
            db.SaveChanges();
            return news;

        }
    }
}
