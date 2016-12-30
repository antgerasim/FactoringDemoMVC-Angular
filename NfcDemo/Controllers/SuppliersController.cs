using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using NfcDemo.Models;

namespace NfcDemo.Controllers
{
    public class SuppliersController : ApiController
    {
        private NfcDemoContext db = new NfcDemoContext();

        // GET: api/Suppliers
        public IQueryable<SupplierVm> GetSuppliers()
        {
            IQueryable<SupplierVm> suppls;
            try
            {
                suppls = db.Suppliers.Select(s => new SupplierVm()
                {
                    Id = s.Id,
                    Itin = s.Itin.ToString(),
                    CompanyName = s.CompanyName
                });
            }
            catch (Exception)
            {
                
                throw;
            }

            //var result = db.Suppliers;
            return suppls;
        }

        // GET: api/Suppliers/5
        [ResponseType(typeof(SupplierVm))]
        public async Task<IHttpActionResult> GetSupplier(int id)
        {
            Supplier entity = await db.Suppliers.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            var vm = new SupplierVm()
            {
                Id = entity.Id,
                Itin = entity.Itin.ToString(),
                CompanyName = entity.CompanyName
            };
            return Ok(vm);
        }

        // PUT: api/Suppliers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSupplier(int id, SupplierVm vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vm.Id)
            {
                return BadRequest();
            }

            var supplier = new Supplier()
            {
                Id = vm.Id,
                Itin = long.Parse(vm.Itin),
                CompanyName = vm.CompanyName
            };

            db.Entry(supplier).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
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

        // POST: api/Suppliers
        [ResponseType(typeof(SupplierVm))]
        public async Task<IHttpActionResult> PostSupplier(SupplierVm vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = new Supplier()
            {
                Itin = long.Parse(vm.Itin),
                CompanyName = vm.CompanyName

            };

            db.Suppliers.Add(entity);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vm.Id }, vm);
        }

        // DELETE: api/Suppliers/5
        [ResponseType(typeof(SupplierVm))]
        public async Task<IHttpActionResult> DeleteSupplier(int id)
        {
            Supplier supplier = await db.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            db.Suppliers.Remove(supplier);
            await db.SaveChangesAsync();

            return Ok(supplier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupplierExists(int id)
        {
            return db.Suppliers.Count(e => e.Id == id) > 0;
        }
    }
}