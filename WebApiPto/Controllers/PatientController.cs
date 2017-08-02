using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiPto.Models;
using WebApiPto.DataClasses;
using WebApiPto.Classes;

namespace WebApiPto.Controllers
{
    public class PatientsController : ApiController
    {
        private readonly PTEFEntities _db = new PTEFEntities();

        public IEnumerable<PatientDto> GetAllPatients()
        {
            var col = _db.PatientListViews;

            List<PatientDto> items = new List<PatientDto>();

            foreach (PatientListView item in col)
            {
                items.Add(Mapper.MapToDto(item));
            }
            return items.OrderBy(x => x.LastName).ThenBy(x=> x.FirstName); 
        }

        public PatientDto GetPatient(string id)
        {
            var item = _db.PatientListViews.FirstOrDefault(p => p.PatientId == id);
            return Mapper.MapToDto(item);
        }

    }
}
