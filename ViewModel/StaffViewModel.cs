using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace ERPMedicalCenter.Models.ViewModel
{
    public class StaffViewModel
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NationalNumber { get; set; }
        public string Major { get; set; }
        public string Experience { get; set; }
        public string salary { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public int ClinicId { get; set; }
        public string Clinic { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
        public string UserTypeName { get; set; }
        public static List<StaffViewModel> GetAllData()
        {
            List<StaffViewModel> Result = new List<StaffViewModel>();
            DataTable tblRow = SqlAdoWrapper.ExecuteQueryCommand("GetStaffData", null, false);
            foreach (DataRow item in tblRow.Rows)
            {
                Result.Add(new StaffViewModel()
                {
                    Age = (item["Age"] != DBNull.Value) ? Convert.ToInt32(item["Age"]) : 0,
                    Clinic = (item["Specialty"] != DBNull.Value) ? item["Specialty"].ToString() : "",
                    ClinicId = (item["ClinicId"] != DBNull.Value) ? Convert.ToInt32(item["ClinicId"]) : 0,
                    Department = (item["DepartmentName"] != DBNull.Value) ? item["DepartmentName"].ToString() : "",
                    DepartmentId = (item["DepartmentId"] != DBNull.Value) ? Convert.ToInt32(item["DepartmentId"]) : 0,
                    Email = (item["Email"] != DBNull.Value) ? item["Email"].ToString() : "",
                    Experience = (item["Experience"] != DBNull.Value) ? item["Experience"].ToString() : "",
                    FName = (item["FName"] != DBNull.Value) ? item["FName"].ToString() : "",
                    Gender = (item["Gender"] != DBNull.Value) ? item["Gender"].ToString() : "",
                    LName = (item["LName"] != DBNull.Value) ? item["LName"].ToString() : "",
                    Major = (item["Major"] != DBNull.Value) ? item["Major"].ToString() : "",
                    NationalNumber = (item["NationalNumber"] != DBNull.Value) ? item["NationalNumber"].ToString() : "",                  
                    Phone = (item["Phone"] != DBNull.Value) ? item["Phone"].ToString() : "",
                    salary = (item["salary"] != DBNull.Value) ? item["salary"].ToString() : "",
                    UserName = (item["UserName"] != DBNull.Value) ? item["UserName"].ToString() : "",
                    UserType = (item["UserTypeID"] != DBNull.Value) ? Convert.ToInt32(item["UserTypeID"]) : 0,
                    UserTypeName = (item["UserTypeName"] != DBNull.Value) ? item["UserTypeName"].ToString() : "",
                    ID = (item["ID"] != DBNull.Value) ? Convert.ToInt32(item["ID"]) : 0
                });
            }

            return Result;
        }
    }
}
