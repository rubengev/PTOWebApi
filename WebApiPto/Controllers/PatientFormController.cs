using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
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
        private PTEFEntities _db = new PTEFEntities();

        // GET: api/PatientForm
        public List<PatientFormDto> GetPatientForms(string id)
        {
            var col = _db.PatientForms.Where(x=> x.PatientId == id);

            List<PatientFormDto> items = new List<PatientFormDto>();

            foreach (PatientForm item in col)
            {
                items.Add(Mapper.MapToDto(item));
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

            _db.Entry(patientForm).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
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

            _db.PatientForms.Add(patientForm);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = patientForm.PatientFormId }, patientForm);
        }

        // DELETE: api/PatientForm/5
        [ResponseType(typeof(PatientForm))]
        public async Task<IHttpActionResult> DeletePatientForm(int id)
        {
            PatientForm patientForm = await _db.PatientForms.FindAsync(id);
            if (patientForm == null)
            {
                return NotFound();
            }

            _db.PatientForms.Remove(patientForm);
            await _db.SaveChangesAsync();

            return Ok(patientForm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientFormExists(int id)
        {
            return _db.PatientForms.Count(e => e.PatientFormId == id) > 0;
        }


    }
}