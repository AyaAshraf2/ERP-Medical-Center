using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ERPMedicalCenter.Models;
using ERPMedicalCenter.Models.ViewModel;
using System.Data;

namespace ERPMedicalCenter.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            // Get Clinics
            // Get Appoinment Types

            return View();
        }
        [HttpPost]
        public IActionResult MakeAppoinment(MakeAppoinmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                entPerson Person = new entPerson()
                {
                    Age = model.Age,
                    Email = model.EMail,
                    FName = model.FName,
                    Gender = model.Gender,
                    LName = model.LName,
                    Phone = model.Phone
                };
                int PersonID = mngrPerson.Insert(Person);
                if (PersonID > 0)
                {
                    entPatient patient = new entPatient()
                    {
                        PersonId = PersonID
                    };
                    int patientID = mngrPatient.Insert(patient);
                    if (patientID > 0)
                    {
                        entAppointment appointment = new entAppointment();
                        appointment.Date = model.AppoinmentDate;
                        appointment.PatientCode = patientID;
                        appointment.Type = model.AppoinmentType;
                        int appointmentID = mngrAppointment.Insert(appointment);
                        if (appointmentID > 0)
                        {
                            entAppointmentClinic appointmentClinic = new entAppointmentClinic()
                            {
                                AppointmentId = appointmentID,
                                ClinicIId = model.Clinic

                            };
                            mngrAppointmentClinic.Insert(appointmentClinic);
                        }
                    }
                }
            }
            if (UserID != null && UserID > 0)
            {
                return RedirectToAction("viewAppointment", "Dashboard");
            }
            else
            {
                return RedirectToAction("Index");
            }

           

        }

        [HttpPost]
        public IActionResult ContactUs(ContactUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                entContactUs contactUs = new entContactUs()
                {
                    EMail = model.EMail,
                    Message = model.Message,
                    Name = model.Name,
                    Subject = model.Subject
                };
                mngrContactUs.Insert(contactUs);
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult ContactUs()
        {
            if (!ChickCooke(0))
            {
                return RedirectToAction("Login", "Users");
            }
            if (UserType != 1)
            {
                return RedirectToAction("Index");
            }
            DataTable clinicData = mngrContactUs.GetContactUs();
            List<entContactUs> clincs = new List<entContactUs>();
            foreach (DataRow item in clinicData.Rows)
            {
                clincs.Add(new entContactUs()
                {
                    EMail = item["EMail"].ToString(),
                    Message = item["Message"].ToString(),
                    Name = item["Name"].ToString(),
                    Subject = item["Subject"].ToString()

                });
            }
            return View(clincs);
          
        }


        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
