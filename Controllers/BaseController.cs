using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPMedicalCenter.Controllers
{
    public class BaseController : Controller
    {
    
        public static int UserID = 0;
        public static int UserType = 0;
        public bool ChickCooke(int type)
        {
            if (HttpContext.Session.GetInt32("UserID") != null && HttpContext.Session.GetInt32("UserID") > 0)
            {
                UserID = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
                UserType = Convert.ToInt32(HttpContext.Session.GetInt32("UserType"));
            }
            else if (Request.Cookies["UserID"] != null)
            {
                UserID = Convert.ToInt32(Request.Cookies["UserID"]);
            }
            else
            {
                return false;
            }
            return true;
        }
        public void DeleteSession()
        {
            if (Request.Cookies["UserID"] != null)
            {
                Response.Cookies.Delete("UserID");
            }
            if (HttpContext.Session.GetInt32("UserID") != null)
            {
                HttpContext.Session.SetInt32("UserID", 0);
                HttpContext.Session.SetInt32("UserType", 0);
            }
        }

        public void SetSession(int ID, bool IsSession,int Type)
        {
            // entAccounts accounts = new entAccounts(ID);          
            if (IsSession)
            {
                HttpContext.Session.SetInt32("UserID", ID);
                HttpContext.Session.SetInt32("UserType", Type);
               
            }
            else
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(365);
                Response.Cookies.Append("UserID", ID.ToString(), option);
            }
        }



    }
}
