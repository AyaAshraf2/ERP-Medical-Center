﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPMedicalCenter.Models.ViewModel
{
    public class LoginViewModel
    {
        
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
    }
}
