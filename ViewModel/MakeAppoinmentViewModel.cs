using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPMedicalCenter.Models.ViewModel
{
    public class MakeAppoinmentViewModel
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Gender { get; set; }
        public string EMail { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public int Clinic { get; set; }
        public int AppoinmentType { get; set; }
        public DateTime AppoinmentDate { get; set; }
        public TimeSpan AppoinmentTime { get; set; }
        public string Notes { get; set; }
    }
}
