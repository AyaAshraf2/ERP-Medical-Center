using ERPMedicalCenter.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ERPMedicalCenter.Controllers.Admin
{
    public class StaffController : BaseController
    {
        public IActionResult Index()
        {
            if (!ChickCooke(0))
            {
                return RedirectToAction("Login", "Users");
            }
            List<StaffViewModel> result = StaffViewModel.GetAllData();
            return View(result);
        }

        [HttpPost]
        public IActionResult Create(StaffViewModel model)
        {
            if (!ChickCooke(0))
            {
                return RedirectToAction("Login", "Users");
            }
            if (model.Age <= 0 || model.ClinicId <= 0 || model.DepartmentId <= 0 || model.FName.Length <= 0 || model.FName.Length <= 0 || model.UserName.Length <= 0 || model.UserType < 0)
            {
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "Invalid Request",
                    ErrorCode = 1
                }));
            }
            else
            {
                entPerson person = new entPerson();
                person.Age = model.Age;
                person.Email = model.Email;
                person.FName = model.FName;
                person.Gender = model.Gender;
                person.LName = model.LName;
                person.Phone = model.Phone;
                int personID = mngrPerson.Insert(person);
                if (personID > 0)
                {
                    entStuff stuff = new entStuff();
                    stuff.ClinicId = model.ClinicId;
                    stuff.DepartmentId = model.DepartmentId;
                    stuff.Experience = model.Experience;
                    stuff.Major = model.Major;
                    stuff.NationalNumber = model.NationalNumber;
                    stuff.PersonId = personID;
                    stuff.salary = model.salary;
                    int stuffID = mngrStuff.Insert(stuff);
                    if (stuffID > 0)
                    {
                        entUser user = new entUser();
                        user.StaffID = stuffID;
                        user.UserName = model.UserName;
                        user.Password = Utilities.WebHelper.MD5Hash(model.Password);
                        user.UserType = model.UserType;
                        int userID = mngrUser.Insert(user);
                        if (userID > 0)
                        {
                            return Json(JsonConvert.SerializeObject(new
                            {
                                Message = "Create Successfully",
                                ErrorCode = 0
                            }));
                        }
                        else
                        {
                            mngrStuff.Delete(stuffID);
                            mngrPerson.Delete(personID);
                            return Json(JsonConvert.SerializeObject(new
                            {
                                Message = "Error While Saving Data",
                                ErrorCode = 1
                            }));
                        }
                    }
                    else
                    {
                        mngrPerson.Delete(personID);
                        return Json(JsonConvert.SerializeObject(new
                        {
                            Message = "Error While Saving Data",
                            ErrorCode = 1
                        }));
                    }


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
        }

        [HttpPost]
        public IActionResult Edit(StaffViewModel model)
        {
            if (!ChickCooke(0))
            {
                return RedirectToAction("Login", "Users");
            }
            if (model.ID <= 0)
            {
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "Invalid Request",
                    ErrorCode = 1
                }));
            }
            else
            {

                entStuff Oldstuff = new entStuff(model.ID);
                entPerson person = new entPerson(Oldstuff.PersonId);
                person.Age = model.Age;
                person.Email = model.Email;
                person.FName = model.FName;
                person.Gender = model.Gender;
                person.LName = model.LName;
                person.Phone = model.Phone;
                int personID = mngrPerson.Update(person);
                if (personID > 0)
                {
                    entStuff stuff = Oldstuff;
                    stuff.ClinicId = model.ClinicId;
                    stuff.DepartmentId = model.DepartmentId;
                    stuff.Experience = model.Experience;
                    stuff.Major = model.Major;
                    stuff.NationalNumber = model.NationalNumber;
                    stuff.PersonId = person.ID;
                    stuff.salary = model.salary;
                    int stuffID = mngrStuff.Update(stuff);
                    if (stuffID > 0)
                    {
                        DataRow[] UserData = mngrUser.GetUser().Select($"StaffID = {model.ID}");
                        int userID = 0;
                        if (UserData == null || UserData.Length <= 0)
                        {
                            entUser user = new entUser();
                            user.StaffID = stuff.ID;
                            user.UserName = model.UserName;
                            user.Password = Utilities.WebHelper.MD5Hash(model.Password);
                            user.UserType = model.UserType;
                            userID = mngrUser.Insert(user);
                        }
                        else
                        {
                            entUser user = new entUser(Convert.ToInt32(UserData[0]["ID"]));
                            user.StaffID = stuff.ID;
                            user.UserName = model.UserName;
                            if (!string.IsNullOrWhiteSpace(model.Password) && !string.IsNullOrEmpty(model.Password))
                            {
                                user.Password = Utilities.WebHelper.MD5Hash(model.Password);
                            }
                            user.UserType = model.UserType;
                            userID = mngrUser.Update(user);
                        }

                        if (userID > 0)
                        {
                            return Json(JsonConvert.SerializeObject(new
                            {
                                Message = "Save Successfully",
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
                    else
                    {

                        return Json(JsonConvert.SerializeObject(new
                        {
                            Message = "Error While Saving Data",
                            ErrorCode = 1
                        }));
                    }


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
                DataRow[] UserData = mngrUser.GetUser().Select($"StaffID = {id}");
                if (UserData.Length > 0)
                {
                    int userid = Convert.ToInt32(UserData[0]["ID"]);
                    mngrUser.Delete(userid);
                }

                entStuff stuff = new entStuff((int)id);
                mngrStuff.Delete(stuff.ID);
                int iResult = mngrPerson.Delete(stuff.PersonId);
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
                List<StaffViewModel> result = StaffViewModel.GetAllData();
                StaffViewModel model = result.FindAll(s => s.ID == (int)id)[0];
                return Json(JsonConvert.SerializeObject(new
                {
                    Message = "",
                    ErrorCode = 0,
                    Data = model
                }));
            }
        }






    }
}
