using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiPto.Models;
using WebApiPto.DataClasses;
using WebApiPto.Classes;

namespace WebApiPto.Controllers
{
    public class AnswerController : ApiController
    {
        private PTEFEntities db = new PTEFEntities();

        // GET: api/Answers
        public List<AnswerDto> GetAnswers()
        {
            var col = db.Answers;

            List<AnswerDto> items = new List<AnswerDto>();

            foreach (Answer item in col)
            {
                items.Add(Mapper.MapToDTO(item));
            }
            return items;

        }

        // PUT: api/Answers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnswer(int id, Answer answer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != answer.AnswerId)
            {
                return BadRequest();
            }

            db.Entry(answer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerExists(id))
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

        // POST: api/Answers
        [ResponseType(typeof(Answer))]
        public IHttpActionResult PostAnswer(Answer answer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Answers.Add(answer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = answer.AnswerId }, answer);
        }

        //// DELETE: api/Answers/5
        //[ResponseType(typeof(Answer))]
        //public IHttpActionResult DeleteAnswer(int id)
        //{
        //    Answer answer = db.Answers.Find(id);
        //    if (answer == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Answers.Remove(answer);
        //    db.SaveChanges();

        //    return Ok(answer);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnswerExists(int id)
        {
            return db.Answers.Count(e => e.AnswerId == id) > 0;
        }

    }
}