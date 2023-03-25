using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace ERPMedicalCenter.Models.ViewModel
{
    public class AppointmentViewModel
    {
        public int ID { get; set; }
        public string PersonName { get; set; }
        public DateTime Date { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Clinic { get; set; }
        public string AppoinmentType { get; set; }
        public int PatientID { get; set; }

        public static List<AppointmentViewModel> GetAppointmentData(int? UserID)
        {
            List<AppointmentViewModel> Result = new List<AppointmentViewModel>();
            SqlParameter[] parameters = new SqlParameter[1];
            if (UserID == null)
            {
                parameters[0] = new SqlParameter("@UserID", DBNull.Value);
            }
            else
            {
                parameters[0] = new SqlParameter("@UserID", UserID);
            }

            DataTable tblRow = SqlAdoWrapper.ExecuteQueryCommand("GetAppointmentData", parameters, false);
            foreach (DataRow item in tblRow.Rows)
            {
                Result.Add(new AppointmentViewModel()
                {
                    Age = (item["Age"] != DBNull.Value) ? Convert.ToInt32(item["Age"]) : 0,
                    Clinic = (item["Clinic"] != DBNull.Value) ? item["Clinic"].ToString() : "",
                    Gender = (item["Gender"] != DBNull.Value) ? item["Gender"].ToString() : "",
                    Phone = (item["Phone"] != DBNull.Value) ? item["Phone"].ToString() : "",
                    ID = (item["ID"] != DBNull.Value) ? Convert.ToInt32(item["ID"]) : 0,
                    AppoinmentType = (item["AppoinmentType"] != DBNull.Value) ? item["AppoinmentType"].ToString() : "",
                    Date = (item["Date"] != DBNull.Value) ? Convert.ToDateTime(item["Date"]) : DateTime.Now,
                    PersonName = (item["PersonName"] != DBNull.Value) ? item["PersonName"].ToString() : "",
                    PatientID = (item["PatientCode"] != DBNull.Value) ? Convert.ToInt32(item["PatientCode"]) : 0,
                });
            }


            return Result;
        }




    }
}
