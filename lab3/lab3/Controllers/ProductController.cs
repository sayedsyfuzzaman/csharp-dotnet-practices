using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using lab3.DB;

namespace lab3.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var db = new lab3Entities();
            var products = db.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            //add book to db
            var db = new lab3Entities();
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Create");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new lab3Entities();
            var product = (from p in db.Products
                        where p.id == id
                        select p).SingleOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit (Product product)
        {
            var db = new lab3Entities();
            //
            //db.Books.Find(book.Id);
            var ext = (from p in db.Products
                       where p.id == product.id
                       select p).SingleOrDefault();
            //ext.Author = book.Author;
            //ext.Name = book.Name;
            //ext.Price = book.Price;
            //ext.Edition = book.Edition;

            db.Entry(ext).CurrentValues.SetValues(product);

            db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new lab3Entities();
            var product = (from p in db.Products
                           where p.id == id
                           select p).SingleOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Purchase()
        {
            var db = new lab3Entities();
            var products = db.Products.ToList();
            if (Session["ProductCart"] != null)
            {
                string json = (string)Session["ProductCart"];
                var cart = new JavaScriptSerializer().Deserialize<List<Product>>(json);
                ViewBag.cart = cart;
            }
            
            return View(products);
        }

        [HttpGet]
        public ActionResult AddToCart(int id)
        {
            var db = new lab3Entities();
            var product = (from p in db.Products
                           where p.id == id
                           select p).SingleOrDefault();

            if (string.IsNullOrEmpty(Session["ProductCart"] as string))
            {
                List<Product> products = new List<Product>();
                product.quantity = 1;
                products.Add(product);
                string json = new JavaScriptSerializer().Serialize(products);
                Session["ProductCart"] = json;
                Session["TotalPrice"] = product.price * product.quantity;
            } 
            else
            {
                string json = (string)Session["ProductCart"];
                var products = new JavaScriptSerializer().Deserialize<List<Product>>(json);
                product.quantity = 1;
                products.Add(product);
                json = new JavaScriptSerializer().Serialize(products);
                Session["ProductCart"] = json;
                Session["TotalPrice"] = (double)Session["TotalPrice"]+(product.price * product.quantity);
            }

            return RedirectToAction("Purchase");
        }

        [HttpGet]
        public ActionResult RemoveItemFromCart(int id)
        {
            string json = (string)Session["ProductCart"];
            var products = new JavaScriptSerializer().Deserialize<List<Product>>(json);

            foreach (var product in products.ToList())
            {
                if(product.id == id)
                {
                    Session["TotalPrice"] = (double)Session["TotalPrice"] - (product.price * product.quantity);
                    products.Remove(product);
                    break;
                }
            }
            json = new JavaScriptSerializer().Serialize(products);
            Session["ProductCart"] = json;
            return RedirectToAction("Purchase");
        }
        [HttpGet]
        public ActionResult Checkout()
        {
            Order order = new Order();
            //randon number for order id
            Random r = new Random();
            int id = r.Next(0, 100);
            order.TotalPrice = (double)Session["TotalPrice"];
            order.OrderId = id;
            order.OrderDate = DateTime.Now;

            var db = new lab3Entities();
            db.Orders.Add(order);
            db.SaveChanges();


            string json = (string)Session["ProductCart"];
            var products = new JavaScriptSerializer().Deserialize<List<Product>>(json);
            foreach (Product product in products.ToList())
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OrderId = id;
                orderDetail.ProductId = product.id;
                orderDetail.Quantity = product.id;
                
                db = new lab3Entities();
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
                products.Remove(product);

            }
            Session.Remove("TotalPrice");
            Session.Remove("ProductCart");

            return RedirectToAction("Purchase");
        }
    }
}