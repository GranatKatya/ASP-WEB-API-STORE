using StoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StoreWebApi.Controllers
{
    public class ProductsController : ApiController
    {
        StoreDbContext db = new StoreDbContext();
        public IEnumerable<Product> GetProducts()
        {
            return db.Products;
        }

        public IHttpActionResult GetProduct(int id)
        {
           
            var product = db.Products.Find(id);
            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IHttpActionResult CreateProduct([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            db.SaveChanges();
            return Ok(product);
        }

        [HttpPut]
        public IHttpActionResult EditProduct(int id, [FromBody]Product product)
        {
            var p = db.Products.Find(id);
            if (p == null)
            {
                return NotFound();
            }

            p.Name = product.Name;
            p.Price = product.Price;

            db.SaveChanges();
            return Ok(p);
        }

        [HttpDelete]
        public void DeleteProduct(int id)
        {
            var product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }
    }
}
