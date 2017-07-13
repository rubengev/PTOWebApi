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
    public class FormTypeController : ApiController
    {
        private PTEFEntities db = new PTEFEntities();

        public IEnumerable<FormTypeDto> GetAllFormTypes()
        {
            var col = db.FormTypes;

            List<FormTypeDto> items = new List<FormTypeDto>();

            foreach (FormType item in col)
            {
                items.Add(Mapper.MapToDTO(item));
            }
            return items;
        }

        public FormTypeDto GetFormType(int id)
        {
            var item = db.FormTypes.FirstOrDefault(p => p.FormTypeId == id);
            return Mapper.MapToDTO(item);
        }

    }
}
