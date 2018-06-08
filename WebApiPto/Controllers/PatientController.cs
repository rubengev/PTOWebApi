using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiPto.Models;
using WebApiPto.DataClasses;
using WebApiPto.Classes;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System;


namespace WebApiPto.Controllers
{
    public class PatientsController : ApiController
    {
        private readonly PTEFEntities _db = new PTEFEntities();

        public IEnumerable<PatientDto> GetAllPatients()
        {
            List<PatientDto> items = new List<PatientDto>();
            string query = "Select * from PatientListView";

            using (OleDbConnection con = new OleDbConnection(AppModule.ConnectionString))
            {
                OleDbCommand command = new OleDbCommand(query, con);

                try
                {
                    con.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        PatientDto patient = new PatientDto();

                        patient.Id = reader[0].ToString();
                        patient.LastName = reader[1].ToString();
                        patient.FirstName = reader[2].ToString();
                        patient.LastVisitDate = reader.IsDBNull(3) ? (DateTime?)null : Convert.ToDateTime(reader[3]);

                        items.Add(patient);
                    }
                    return items.OrderBy(x=> x.LastName).ThenBy(x => x.FirstName);
                }
                catch (Exception ex)
                {
                    return items;
                }
            }
        }

        public PatientDto GetPatient(string id)
        {
            string query = "Select * from PatientListView where PatientId = ?";

            using (OleDbConnection con = new OleDbConnection(AppModule.ConnectionString))
            {
                OleDbCommand command = new OleDbCommand(query, con);
                command.Parameters.AddWithValue("@Id", id);

                PatientDto patient = new PatientDto();

                try
                {
                    con.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        patient.Id = reader[0].ToString();
                        patient.LastName = reader[1].ToString();
                        patient.FirstName = reader[2].ToString();
                        patient.LastVisitDate = reader.IsDBNull(3) ? (DateTime?)null : Convert.ToDateTime(reader[3]);

                        break;
                    }
                    return patient;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
