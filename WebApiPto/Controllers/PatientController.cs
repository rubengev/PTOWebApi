using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPto.Models;
using WebApiPto.DataClasses;
using WebApiPto.Classes;

namespace WebApiPto.Controllers
{
    public class PatientsController : ApiController
    {
        private PTEFEntities db = new PTEFEntities();

        public IEnumerable<PatientDto> GetAllPatients()
        {
            var col = db.PatientListViews;

            List<PatientDto> items = new List<PatientDto>();

            foreach (PatientListView item in col)
            {
                items.Add(Mapper.MapToDTO(item));
            }
            return items;
        }

        public PatientDto GetPatient(string id)
        {
            var item = db.PatientListViews.FirstOrDefault(p => p.PatientId == id);
            return Mapper.MapToDTO(item);
        }

    }
}
