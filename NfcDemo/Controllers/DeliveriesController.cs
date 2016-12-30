using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using NfcDemo.Models;

namespace NfcDemo.Controllers
{
    public class DeliveriesController : ApiController
    {
        private readonly NfcDemoContext db = new NfcDemoContext();

        // GET: api/Deliveries
        public IQueryable<DeliveryVm> GetDeliveries()
        {
            IQueryable<DeliveryVm> dels;
            try
            {
             
                dels = db.Deliveries.Select(d => new DeliveryVm
                {
                    Id = d.Id,
                    Currency = d.Currency,
                    Total = d.Sum,
                    DelNo = d.DelNo,
                    SupplierItin = d.Supplier.Itin,
                    SupplierId = d.SupplierId
                });
            }
            catch (Exception e)
            {
                throw;
            }


            //return db.Deliveries;
            return dels;
        }

        // GET: api/Deliveries/5
        [ResponseType(typeof (DeliveryVm))]
        public async Task<IHttpActionResult> GetDelivery(int id)
        {

            #region Old

                        //Delivery delivery = await db.Deliveries.FindAsync(id);
/*            var del = await db.Deliveries.Include(d => d.Supplier)
                .Select(d => new DeliveryVm
                {
                    Id = d.Id,
                    Currency = d.Currency,
                    Sum = d.Sum,
                    DelNo = d.DelNo,
                    SupplierInn = d.Supplier.Inn
                }).SingleOrDefaultAsync(d => d.Id == id);*/

            #endregion
            
            var del = await db.Deliveries
                .Select(d => new DeliveryVm
                {
                    //Id = d.Id,
                    Currency = d.Currency,
                    Total = d.Sum,
                    DelNo = d.DelNo,
                    SupplierItin = d.Supplier.Itin
                }).SingleOrDefaultAsync(d => d.Id == id);


            if (del == null)
            {
                return NotFound();
            }

            return Ok(del);
        }

        // PUT: api/Deliveries/5
        [ResponseType(typeof (void))]
        public async Task<IHttpActionResult> PutDelivery(int id, Delivery delivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != delivery.Id)
            {
                return BadRequest();
            }

            db.Entry(delivery).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Deliveries
        [ResponseType(typeof (DeliveryVm))]
        public async Task<IHttpActionResult> PostDelivery(DeliveryVm d)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

          var supp=  db.Suppliers.First(s => s.CompanyName.Equals(d.Supplier));

            var entiy = new Delivery()
            {
                
                Currency = d.Currency,
                DelNo = d.DelNo,
                Sum = d.Total,
                SupplierId = supp.Id,
                Supplier = supp
            };

            try
            {
                db.Deliveries.Add(entiy);
                await db.SaveChangesAsync();

                //Load Supplier
                //db.Entry(d).Reference(x=>x.Supplier).Load();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

/*
            var dto = new DeliveryVm()
            {
                Id = delivery.Id,
                Currency = delivery.Currency,
                DelNo = delivery.DelNo,
                Sum = delivery.Sum,
                SupplierInn = delivery.Supplier.Inn
            };
*/

            return CreatedAtRoute("DefaultApi", new { id = d.Id }, d);
        }

        // DELETE: api/Deliveries/5
        [ResponseType(typeof (Delivery))]
        public async Task<IHttpActionResult> DeleteDelivery(int id)
        {
            var delivery = await db.Deliveries.FindAsync(id);
            if (delivery == null)
            {
                return NotFound();
            }

            db.Deliveries.Remove(delivery);
            await db.SaveChangesAsync();

            return Ok(delivery);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeliveryExists(int id)
        {
            return db.Deliveries.Count(e => e.Id == id) > 0;
        }
    }
}