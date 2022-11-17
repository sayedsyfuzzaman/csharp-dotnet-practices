using DAL.DB;
using DAL.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class CategoryRepo : IRepo<Category, int>
    {
        public void Create(Category data)
        {
            var db = new NewsAppEntities();
            db.Categories.Add(data);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var db = new NewsAppEntities();
            db.Categories.Remove(db.Categories.Find(id));
            db.SaveChanges();
        }

        public List<Category> Get()
        {
            var db = new NewsAppEntities();
            var categories = db.Categories.ToList();
            return categories;
        }

        public Category Get(int id)
        {
            var db = new NewsAppEntities();
            var category = db.Categories.SingleOrDefault(c => c.Id == id);
            return category;
        }

        public Category Update(Category data)
        {
            var db = new NewsAppEntities();
            var category = db.Categories.SingleOrDefault(c => c.Id == data.Id);
            category.Name = data.Name;
            db.SaveChanges();
            return category;

        }
    }
}
