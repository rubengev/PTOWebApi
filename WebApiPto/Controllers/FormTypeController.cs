using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiPto.Models;
using WebApiPto.DataClasses;
using WebApiPto.Classes;

namespace WebApiPto.Controllers
{
    public class FormTypeController : ApiController
    {
        private readonly PTEFEntities _db = new PTEFEntities();

        public IEnumerable<FormTypeDto> GetAllFormTypes()
        {
            var col = _db.FormTypes;

            List<FormTypeDto> items = new List<FormTypeDto>();

            foreach (FormType item in col)
            {
                items.Add(Mapper.MapToDto(item));
            }
            return items;
        }

        public FormTypeDto GetFormType(int id)
        {
            var item = _db.FormTypes.FirstOrDefault(p => p.FormTypeId == id);
            return Mapper.MapToDto(item);
        }

    }
}
