using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class BagController : ApiController
    {
        private BagStoreEntities db = new BagStoreEntities();
        [HttpGet]
        public IEnumerable<BagTBL> GetActiveBagList()
        {
            return db.BagTBLs.Select(bag => new BagTBL
            {
                bagID = bag.bagID,
                bagName = bag.bagName,
                image = bag.image,
                price = bag.price,
                quantity = bag.quantity,
                size = bag.size,
                status = bag.status
            }).Where(bag => bag.status.Equals("Active") && bag.quantity > 0
            ).AsEnumerable();
        }
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(string id, BagTBL bag)
        {
            if (id != bag.bagID)
            {
                return BadRequest();
            }

            db.Entry(bag).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        private bool BagExists(string id)
        {
            return db.BagTBLs.Count(b => b.bagID == id) > 0;
        }
        [ResponseType(typeof(BagTBL))]
        public IHttpActionResult Get(string id)
        {
            BagTBL bag = db.BagTBLs.Find(id);
            if (bag == null)
            {
                return NotFound();
            }

            return Ok(bag);
        }
        [HttpPost]
        public void Add([FromBody] BagTBL bag)
        {
            db.BagTBLs.Add(bag);
        }

        [HttpDelete]
        public void Delete(string id)
        {
            BagTBL bag = db.BagTBLs.SingleOrDefault(x => x.bagID.Equals(id));
            db.BagTBLs.Remove(bag);
        }
    }
}
