using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ERPMedicalCenter.Controllers.Admin
{
    public class ClinicController : BaseController
    {
        public IActionResult Index()
        {
            if (!ChickCooke(0))
            {
                return RedirectToAction("Login", "Users");
            }

            DataTable clinicData = mngrClinic.GetClinic();
            List<entClinic> clincs = new List<entClinic>();

            foreach (DataRow item in clinicData.Rows)
            {
                clincs.Add(new entClinic()
                {
                    ClinicId = Convert.ToInt32(item["ClinicId"]),
                    Specialty = item["Specialty"].ToString()

                });
            }
            return View(clincs);
        }

        [HttpPost]
        public IActionResult Create(entClinic model)
        {
            if (!ChickCooke(0))
            {
                return RedirectToAction("Login", "Users");
            }
            if (model.Specialty.Length <= 0)
            {
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "Invalid Request",
                    ErrorCode = 1
                }));
            }
            else
            {
                mngrClinic.Insert(model);
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "Create Successfully",
                    ErrorCode = 0
                }));
            }
        }

        [HttpPost]
        public IActionResult Edit(entClinic model)
        {
            if (!ChickCooke(0))
            {
                return RedirectToAction("Login", "Users");
            }
            if (model.ClinicId  <= 0)
            {
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "Invalid Request",
                    ErrorCode = 1
                }));
            }
            else
            {
                mngrClinic.Update(model);
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "update Successfully",
                    ErrorCode = 0
                }));
            }
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (!ChickCooke(0))
            {
                return RedirectToAction("Login", "Users");
            }
            if (id == null || id <= 0)
            {
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "Invalid Request",
                    ErrorCode = 1
                }));
            }
            else
            {
                int iResult = mngrClinic.Delete((int)id);
                if (iResult > 0)
                {
                    return Json(JsonConvert.SerializeObject(new
                    {
                        Message = "Delete Successfully",
                        ErrorCode = 0
                    }));
                }
                else
                {
                    return Json(JsonConvert.SerializeObject(new
                    {
                        Message = "Can't Complete Deleting",
                        ErrorCode = 1
                    }));
                }
               
            }
        }

        [HttpPost]
        public IActionResult GetData(int? id)
        {
            if (!ChickCooke(0))
            {
                return RedirectToAction("Login", "Users");
            }
            if (id == null || id <=0) 
            {
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "Invalid Request",
                    ErrorCode = 1
                }));
            }
            else
            {
                entClinic clinic = new entClinic((int)id);
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "",
                    ErrorCode = 0,
                    Data = clinic
                }));
            }           
        }

    }
}
