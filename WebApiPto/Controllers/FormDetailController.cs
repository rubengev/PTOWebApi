using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiPto.Models;
using WebApiPto.DataClasses;
using WebApiPto.Classes;

namespace WebApiPto.Controllers
{
    public class FormDetailController : ApiController
    {
        private PTEFEntities db = new PTEFEntities();

        // GET: api/formdetail/1/mmm
        [ResponseType(typeof(FormDetailDto))]
        public IHttpActionResult GetQuestions(int formtypeid, string patientid)
        {
            FormType formType = db.FormTypes.Where(x => x.FormTypeId == formtypeid).FirstOrDefault();
            if (formType == null)
            {
                return NotFound();
            }
            IQueryable<Question> col = db.Questions.Where(x => x.FormTypeId == formtypeid);

            List<QuestionDto> questions = new List<QuestionDto>();
            foreach (Question item in col)
            {
                questions.Add(Mapper.MapToDTO(item));
            }
            FormDetailDto formDetails = new FormDetailDto {
                Id = 0,
                Date = DateTime.Now.Date,
                FormType = formType.FormTypeName,
                FormTypeId = formtypeid,
                PatientId = patientid,
                Questions = questions
            };

            return Ok(formDetails);
        }

        [ResponseType(typeof(FormDetailDto))]
        public IHttpActionResult GetQuestions(int id)
        {
            PatientForm patientForm = db.PatientForms.Where(x => x.PatientFormId == id).FirstOrDefault();
            if (patientForm == null)
            {
                return NotFound();
            }

            IQueryable<AnswerListView> col = db.AnswerListViews.Where(p => p.PatientFormId==id);
            //.Where(x => x.PatientFormId== id);

            List<QuestionDto> questions = new List<QuestionDto>();
            foreach (AnswerListView item in col)
            {
                questions.Add(Mapper.MapToDTO(item));
            }

            FormDetailDto formDetails = new FormDetailDto {
                Id = 0,
                Date = DateTime.Now.Date,
                FormType = patientForm.FormType.FormTypeName,
                FormTypeId = patientForm.FormType.FormTypeId,
                PatientId = patientForm.PatientId,
                Questions = questions
            };

            return Ok(formDetails);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
