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
using WebApiPto.Models;
using WebApiPto.DataClasses;
using WebApiPto.Classes;

namespace WebApiPto.Controllers
{
    public class PatientFormController : ApiController
    {
        private PTEFEntities db = new PTEFEntities();

        // GET: api/PatientForm
        public List<PatientFormDto> GetPatientForms(string id)
        {
            var col = db.PatientForms.Where(x=> x.PatientId == id);

            List<PatientFormDto> items = new List<PatientFormDto>();

            foreach (PatientForm item in col)
            {
                items.Add(Mapper.MapToDTO(item));
            }
            return items;
        }

        //// GET: api/PatientForm/5
        //[ResponseType(typeof(PatientForm))]
        //public async Task<IHttpActionResult> GetPatientForm(int id)
        //{
        //    PatientForm patientForm = await db.PatientForms.FindAsync(id);
        //    if (patientForm == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(Mapper.MapToDTO(patientForm));
        //}

        // PUT: api/PatientForm/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPatientForm(int id, PatientForm patientForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patientForm.PatientFormId)
            {
                return BadRequest();
            }

            db.Entry(patientForm).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientFormExists(id))
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

        // POST: api/PatientForm
        [ResponseType(typeof(PatientForm))]
        public async Task<IHttpActionResult> PostPatientForm(PatientForm patientForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PatientForms.Add(patientForm);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = patientForm.PatientFormId }, patientForm);
        }

        // DELETE: api/PatientForm/5
        [ResponseType(typeof(PatientForm))]
        public async Task<IHttpActionResult> DeletePatientForm(int id)
        {
            PatientForm patientForm = await db.PatientForms.FindAsync(id);
            if (patientForm == null)
            {
                return NotFound();
            }

            db.PatientForms.Remove(patientForm);
            await db.SaveChangesAsync();

            return Ok(patientForm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientFormExists(int id)
        {
            return db.PatientForms.Count(e => e.PatientFormId == id) > 0;
        }


    }
}