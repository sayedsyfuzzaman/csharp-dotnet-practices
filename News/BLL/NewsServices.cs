using BLL.Models;
using DAL.DB;
using DAL.IRepo;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NewsServices
    {
        public void Create(NewsModel data)
        {
            var obj = new NewsRepo();
            var news = new News()
            {
                Title = data.Title,
                CategoryId = data.CategoryId,
                Date = data.Date
            };
            obj.Create(news);

        }
        public void Delete(int id)
        {
            var obj = new NewsRepo();
            obj.Delete(id);

        }
        public void Update(NewsModel data)
        {
            var obj = new NewsRepo();
            var news = new News()
            {
                Id = data.Id,
                Title = data.Title,
                CategoryId = data.CategoryId,
                Date = data.Date
            };
            obj.Update(news);

        }
        public static List<NewsModel> Get()
        {
            var list = new List<NewsModel>();
            var obj = new NewsRepo();
            var newses = obj.Get();

            foreach (var news in newses)
            {
                var item = new NewsModel()
                {
                    Id = news.Id,
                    Title = news.Title,
                    CategoryId = news.CategoryId,
                    Date = news.Date
                };
                list.Add(item);
            }
            return list;
        }

        public static NewsModel Get(int id)
        {
            var obj = new NewsRepo();
            var news = obj.Get(id);
            var n = new NewsModel()
            {
                Id= news.Id,
                Title = news.Title,
                CategoryId = news.CategoryId,
                Date = news.Date
            };
            return n;
        }
    }
}
