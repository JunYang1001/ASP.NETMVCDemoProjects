﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NETMVCDemoProjects.SimpleDemo.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Enter First Name")]
        [FirstNameValidation]
        public string FirstName { get; set; }
        [StringLength(5, ErrorMessage = "Last Name length should not be greater than 5")]
        public string LastName { get; set; }
        public int? Salary { get; set; }

    }
    public class FirstNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) // Checking for Empty Value
            {
                return new ValidationResult("Please Provide First Name");
            }
            else
            {
                if (value.ToString().Contains("@"))
                {
                    return new ValidationResult("First Name should contain @");
                }
            }
            return ValidationResult.Success;
        }
    }
}