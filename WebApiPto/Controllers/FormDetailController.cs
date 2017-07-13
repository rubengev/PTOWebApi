using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiPto.Models;
using WebApiPto.DataClasses;
using WebApiPto.Classes;

namespace WebApiPto.Controllers
{
    public class FormDetailController : ApiController
    {
        private readonly PTEFEntities _db = new PTEFEntities();

        // GET: api/formdetail/1/mmm
        [ResponseType(typeof(FormDetailDto))]
        public IHttpActionResult GetQuestions(int formtypeid, string patientid)
        {
            FormType formType = _db.FormTypes.FirstOrDefault(x => x.FormTypeId == formtypeid);
            if (formType == null)
            {
                return NotFound();
            }
            IQueryable<Question> col = _db.Questions.Where(x => x.FormTypeId == formtypeid);

            List<QuestionDto> questions = new List<QuestionDto>();
            foreach (Question item in col)
            {
                questions.Add(Mapper.MapToDto(item));
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
            PatientForm patientForm = _db.PatientForms.FirstOrDefault(x => x.PatientFormId == id);
            if (patientForm == null)
            {
                return NotFound();
            }

            IQueryable<AnswerListView> col = _db.AnswerListViews.Where(p => p.PatientFormId==id);

            List<QuestionDto> questions = new List<QuestionDto>();
            foreach (AnswerListView item in col)
            {
                questions.Add(Mapper.MapToDto(item));
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


        // POST: api/formdetail
        [ResponseType(typeof(FormDetailDto))]
        public IHttpActionResult PostPatientForm(FormDetailDto formDetailDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var param1 = new SqlParameter
            {
                ParameterName = "@PatientFormId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.InputOutput,
                Value = formDetailDto.Id
            };

            var param2 = new SqlParameter
            {
                ParameterName = "@FormTypeId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = formDetailDto.FormTypeId
            };

            var param3 = new SqlParameter
            {
                ParameterName = "@PatientId",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 20,
                Value = formDetailDto.PatientId
           };

            var param4 = new SqlParameter
            {
                ParameterName = "@XmlData",
                SqlDbType = SqlDbType.Xml,
                Direction = ParameterDirection.Input,
                Value = GetXmlValue(formDetailDto)
            };

            int retval = _db.Database.ExecuteSqlCommand(
                "[dbo].spSaveFormDetail @PatientFormId, @FormTypeId, @PatientId, @XmlData",
                new SqlParameter("PatientFormId", param1),
                new SqlParameter("FormTypeId", param2),
                new SqlParameter("PatientId", param3),
                new SqlParameter("XmlData", param4)
            );

            return CreatedAtRoute("DefaultApi", new { id = retval }, formDetailDto);
        }


        private static string GetXmlValue(FormDetailDto formDetailDto)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<Questions>");
           foreach (var item in formDetailDto.Questions)
            {
                sb.Append(
                    $"<QuestionDto><Answer>{item.Answer}</Answer><Checked>{item.Checked}</Checked><QuestionId>{item.Id}</QuestionId></QuestionDto>"
                );
            }
            sb.Append("</Questions>");
            return sb.ToString();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
