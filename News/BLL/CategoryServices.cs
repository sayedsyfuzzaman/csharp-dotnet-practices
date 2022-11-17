using BLL.Models;
using DAL.DB;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryServices
    {
        public void Create(CategoryModel data)
        {
            var obj = new CategoryRepo();
            var category = new Category()
            {
                Name = data.Name
            };
            obj.Create(category);

        }
        public void Delete(int id)
        {
            var obj = new CategoryRepo();
            obj.Delete(id);

        }
        public void Update(CategoryModel data)
        {
            var obj = new CategoryRepo();
            var category = new Category()
            {
                Id = data.Id,
                Name = data.Name
            };
            obj.Update(category);

        }
        public static List<CategoryModel> Get()
        {
            var list = new List<CategoryModel>();
            var obj = new CategoryRepo();
            var categories = obj.Get();

            foreach (var category in categories) 
            {
                var item = new CategoryModel()
                {
                    Id = category.Id,
                    Name = category.Name
                };
                list.Add(item);
            }
            return list;
        }

        public static CategoryModel Get(int id)
        {
            var obj = new CategoryRepo();
            var category = obj.Get(id);
            var c = new CategoryModel()
            {
                Id=category.Id,
                Name=category.Name
            };
            return c;
        }
    }
}
