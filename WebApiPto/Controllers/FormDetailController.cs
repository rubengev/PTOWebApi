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
using System.Xml;
using System.Data.SqlTypes;

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
                VisitDate = DateTime.Now.Date,
                FormTypeName = formType.FormTypeName,
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
                Id = id,
                VisitDate = DateTime.Now.Date,
                FormTypeName = patientForm.FormType.FormTypeName,
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
                SqlDbType = SqlDbType.Text,
                Direction = ParameterDirection.Input,
                Value = new SqlXml(new XmlTextReader(GetXmlValue(formDetailDto), XmlNodeType.Document, null))
            };

            var param5 = new SqlParameter
            {
                ParameterName = "@SavedId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output,
                Value = 0
            };

            try
            {
                _db.Database.ExecuteSqlCommand(
                    "spSaveFormDetail @PatientFormId, @FormTypeId, @PatientId, @XmlData, @SavedId OUT",
                        param1, param2, param3, param4, param5);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }            

            return CreatedAtRoute("DefaultApi", new { id = param5.Value }, formDetailDto);
        }


        private static string GetXmlValue(FormDetailDto formDetailDto)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<Questions>");
           foreach (var item in formDetailDto.Questions)
            {
                sb.Append(
                    $"<Question><Answer>{item.Answer}</Answer><Checked>{item.Checked}</Checked><QuestionId>{item.Id}</QuestionId></Question>"
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
