using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProdnCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace ProdnCategories.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            return Redirect("products");
        }
        [HttpGet("products")]
        public IActionResult Products(){
            ViewBag.products = dbContext.Products.ToList();
            return View();
        }
        [HttpPost("products/new")]
        public IActionResult addProduct(Product newProduct)
        {
            if(ModelState.IsValid)
            {
                newProduct.created_at = DateTime.Now;
                newProduct.updated_at = DateTime.Now;
                dbContext.Products.Add(newProduct);
                dbContext.SaveChanges();
                return RedirectToAction("Products");
            }else
            {
                ViewBag.products = dbContext.Products.ToList();
                return View("Products");

            }
        }
        [HttpGet("categories/{id}")]
        public IActionResult CategoryDetail(int id)
        {
            var result = dbContext.Categories
                .Include(c => c.Associations)
                    .ThenInclude(a => a.product)
                .FirstOrDefault(c => c.category_id == id);
            if(result == null)
            {
                return RedirectToAction("Index");
            }else
            {
                var products = dbContext.Products.ToList();
                var productsFiltered = new List<Product>();
                foreach(var product in products)
                {
                    int i = 0;
                    bool found = false;
                    while(i<result.Associations.Count)
                    {
                        if(product.product_id == result.Associations[i].product_id)
                        {
                            found = true;
                            break;
                        }
                        i++;
                    }
                    if(!found)
                    {
                        productsFiltered.Add(product);
                    }
                }
                ViewBag.products = productsFiltered;
                return View(result);
            }
        }
        [HttpGet("products/{id}")]
        public IActionResult ProductDetail(int id)
        {
            var result = dbContext.Products
                        .Include(p => p.Associations)
                            .ThenInclude(a =>a.category)
                        .FirstOrDefault(p => p.product_id == id);
            if(result == null)
            {
                return RedirectToAction("Index");
            }else
            {
                var categories = dbContext.Categories.ToList();
                var categoryFilter = new List<Category>();
                foreach(var category in categories)
                {
                    int i =0;
                    bool found = false;
                    while(i<result.Associations.Count)
                    {
                        if(category.category_id == result.Associations[i].category_id)
                        {
                            found = true;
                            break;
                        }
                        i++;
                    }
                    if(!found)
                    {
                        categoryFilter.Add(category);
                    }

                }
                
                ViewBag.categories = categoryFilter;
                return View(result);
            }
        }
        [HttpPost("products/addCategory")]
        public IActionResult addCategorytoProduct(Association newAssoc)
        {       var product = dbContext.Products.First(p => p.product_id == newAssoc.product_id);
                var category = dbContext.Categories.First(c => c.category_id == newAssoc.category_id);
                if(ModelState.IsValid)
                {
                    // newAssoc.category  = category;
                    // newAssoc.product = product;
                    dbContext.Associations.Add(newAssoc);
                    dbContext.SaveChanges();
                    return RedirectToAction("ProductDetail",new {id = product.product_id});               
                }
                return RedirectToAction("ProductDetail",new {id = product.product_id});
        }
        [HttpPost("categories/addProduct")]
        public IActionResult addProducttoCategory(Association newAssoc)
        {       var product = dbContext.Products.First(p => p.product_id == newAssoc.product_id);
                var category = dbContext.Categories.First(c => c.category_id == newAssoc.category_id);
                if(ModelState.IsValid)
                {
                    // newAssoc.category  = category;
                    // newAssoc.product = product;
                    dbContext.Associations.Add(newAssoc);
                    dbContext.SaveChanges();
                    return RedirectToAction("CategoryDetail",new {id = category.category_id});               
                }
                return RedirectToAction("CategoryDetail",new {id = category.category_id});
        }
        [HttpGet("categories")]
        public IActionResult Categories(){
            ViewBag.categories = dbContext.Categories.ToList();
            return View();
        }
        [HttpPost("categories/new")]
        public IActionResult addCategory(Category newCategory)
        {
            if(ModelState.IsValid)
            {
                newCategory.created_at = DateTime.Now;
                newCategory.updated_at = DateTime.Now;
                dbContext.Categories.Add(newCategory);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Categories");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
