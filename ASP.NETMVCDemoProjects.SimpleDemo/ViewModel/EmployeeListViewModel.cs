﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NETMVCDemoProjects.SimpleDemo.ViewModel
{
    public class EmployeeListViewModel:BaseViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; }
       
    }
}