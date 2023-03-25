using ERPMedicalCenter.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ERPMedicalCenter.Controllers.Account
{
    public class UsersController : BaseController
    {
        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            if (ChickCooke(0))
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new LoginViewModel());
        }
        [Route("Login")]
        public IActionResult Login(LoginViewModel model)
        { 
            if (!ChickCooke(0))
            {
                DataTable userData = mngrUser.GetUser();
                DataRow[] dataRows = userData.Select($"UserName = '{model.UserName}' and Password = '{Utilities.WebHelper.MD5Hash(model.Password)}'");
                if (dataRows.Length > 0)
                {
                    int UserID = Convert.ToInt32(dataRows[0]["ID"]);
                    int UserType = Convert.ToInt32(dataRows[0]["UserType"]);
                    SetSession(UserID,true, UserType);
                    switch (UserType)
                    {
                        case 1:
                            return RedirectToAction("Index", "Clinic");
                            break;
                        case 2:
                        case 3:
                        case 4:
                            return RedirectToAction("Appointment", "Dashboard");
                            break;
                        default:
                            return RedirectToAction("Index", "Home");
                            break;
                    }



                }
                else
                {
                    model.ErrorMessage = "UserName or Password Is Incorrect";
                }
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Logout()
        {
            DeleteSession();
            return RedirectToAction("Index", "Home");
        }
    }
}
