﻿using System.Collections.Generic;
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
        private readonly PTEFEntities _db = new PTEFEntities();

        // GET: api/Answers
        public List<AnswerDto> GetAnswers()
        {
            var col = _db.Answers;

            List<AnswerDto> items = new List<AnswerDto>();

            foreach (Answer item in col)
            {
                items.Add(Mapper.MapToDto(item));
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

            _db.Entry(answer).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
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

            _db.Answers.Add(answer);
            _db.SaveChanges();

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
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnswerExists(int id)
        {
            return _db.Answers.Count(e => e.AnswerId == id) > 0;
        }

    }
}