using StoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StoreWebApi.Controllers
{
    public class OrdersController : ApiController
    {
        StoreDbContext db = new StoreDbContext();
        public IEnumerable<Order> GetProducts()
        {
            return db.Orders;
        }

        public IHttpActionResult GetOrder(int id)
        {
           
            var order = db.Orders.Find(id);
            if(order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public IHttpActionResult CreateOrder([FromBody]Order order)
        {
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

            db.Orders.Add(order);
            db.SaveChanges();
            return Ok(order);
        }

        [HttpPut]
        public IHttpActionResult EditOrder(int id, [FromBody]Order order)
        {
            var p = db.Orders.Find(id);
            if (p == null)
            {
                return NotFound();
            }
            p.StatusName = order.StatusName;
           
            db.SaveChanges();
            return Ok(p);
        }

        [HttpDelete]
        public void DeleteOrder(int id)
        {
            var order = db.Orders.Find(id);
            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }
    }
}
