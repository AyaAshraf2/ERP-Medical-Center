using ERPMedicalCenter.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPMedicalCenter.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Appointment()
        {
            if (!ChickCooke(0))
            {
                return RedirectToAction("Login", "Users");
            }
            if (UserType == 1)
            {
                return RedirectToAction("Index", "Clinic");
            }
            if (UserType == 2)
            {
                return RedirectToAction("viewAppointment" );
            }
            ViewBag.UserType = UserType;
            List<AppointmentViewModel> model = AppointmentViewModel.GetAppointmentData(UserID);
            return View(model);
        }
        [HttpGet]
        public IActionResult Patient(int ID)
        {
            if (!ChickCooke(0))
            {
                return RedirectToAction("Login", "Users");
            }
            if (UserType == 1)
            {
                return RedirectToAction("Index", "Clinic");
            }
            ViewBag.UserType = UserType;
            AppointmentViewModel model = AppointmentViewModel.GetAppointmentData(UserID).FindAll(a=>a.ID == ID)[0];
            return View(model);
        }


        [HttpPost]
        public IActionResult CreateNurseInfo(entPatientNurseInfo model)
        {
            if (!ChickCooke(0))
            {
                return RedirectToAction("Login", "Users");
            }
            ViewBag.UserType = UserType;
            if (mngrPatientNurseInfo.Insert(model) > 0)
            {
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "Save Successfuly",
                    ErrorCode = 0
                }));
            }
            else
            {
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "Error While Saving Data",
                    ErrorCode = 1
                }));
            }
           
        }


        [HttpPost]
        public IActionResult CreateRaysInfo(entPatientRayRelation model)
        {
            if (!ChickCooke(0))
            {
                return RedirectToAction("Login", "Users");
            }
            ViewBag.UserType = UserType;
            if (mngrPatientRayRelation.Insert(model) > 0)
            {
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "Save Successfuly",
                    ErrorCode = 0
                }));
            }
            else
            {
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "Error While Saving Data",
                    ErrorCode = 1
                }));
            }

        }

        [HttpPost]
        public IActionResult CreateLabTestInfo(entPatientLabRelation model)
        {
            if (!ChickCooke(0))
            {
                return RedirectToAction("Login", "Users");
            }
            ViewBag.UserType = UserType;
            if (mngrPatientLabRelation.Insert(model) > 0)
            {
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "Save Successfuly",
                    ErrorCode = 0
                }));
            }
            else
            {
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "Error While Saving Data",
                    ErrorCode = 1
                }));
            }

        }

        [HttpPost]
        public IActionResult CreateDiagnosisInfo(entPatientDiagnosisRelation model)
        {
            if (!ChickCooke(0))
            {
                return RedirectToAction("Login", "Users");
            }
            ViewBag.UserType = UserType;
            if (mngrPatientDiagnosisRelation.Insert(model) > 0)
            {
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "Save Successfuly",
                    ErrorCode = 0
                }));
            }
            else
            {
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "Error While Saving Data",
                    ErrorCode = 1
                }));
            }

        }

        [HttpPost]
        public IActionResult CreateDrugInfo(entPatientDrug model)
        {
            if (!ChickCooke(0))
            {
                return RedirectToAction("Login", "Users");
            }
            ViewBag.UserType = UserType;
            if (mngrPatientDrug.Insert(model) > 0)
            {
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "Save Successfuly",
                    ErrorCode = 0
                }));
            }
            else
            {
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "Error While Saving Data",
                    ErrorCode = 1
                }));
            }

        }


        [HttpGet]
        public IActionResult viewAppointment()
        {
            if (!ChickCooke(0))
            {
                return RedirectToAction("Login", "Users");
            }
            if (UserType != 2)
            {
                return RedirectToAction("Appointment", "Dashboard");
            }
            ViewBag.UserType = UserType;
            List<AppointmentViewModel> model = AppointmentViewModel.GetAppointmentData(null);
            return View(model);
        }






    }
}
