using System;
using System.Collections.Generic;

namespace HRApplication.Models
{

    public class Classes
    { 
    }  
 
    public class Region
    {
        public int RegionId { get; set; } // decimal(5,0) NOT NULL,
        public string RegionName { get; set; } // varchar(25) DEFAULT NULL,

        public virtual List<Country> Countries { get; set; }
    }
    
    public class Country
    {
        public string CountryId { get; set; } //varchar(2) NOT NULL,
        public string CountryName { get; set; } // varchar(40) DEFAULT NULL,
        
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }

        public virtual List<Location> Locations { get; set; }

    }

    public class Location
    {
        public string LocationId { get; set; } // decimal(4,0) NOT NULL DEFAULT '0',
        public string StreetAddress { get; set; } // varchar(40) DEFAULT NULL,
        public string PostCode { get; set; } // archar(12) DEFAULT NULL,
        public string City { get; set; } // varchar(30) NOT NULL,
        public string County { get; set; } // varchar(25) DEFAULT NULL,
        public string CountryId { get; set; } // archar(2) DEFAULT NULL,
        public virtual Country Country { get; set; }
        public List<Department> Departments { get; set; }
    }
    
    public class Department
    {
        public string DepartmentId { get; set; } //decimal(4,0) NOT NULL DEFAULT '0',
        public string DepartmentName { get; set; } //varchar(30) NOT NULL,
        public string ManagerId { get; set; } //decimal(6,0) DEFAULT NULL,
        public string LocationId { get; set; } //decimal(4,0) DEFAULT NULL,
        public virtual Location Location { get; set; }

        public List<Employee> Employees { get; set; }
        public List<Job> Jobs { get; set; }
    }

    public class Job
    {
        public string JobId { get; set; } // varchar(10) NOT NULL DEFAULT '',
        public string JobTitle { get; set; } //  varchar(35) NOT NULL,
        public decimal MinSalary { get; set; } // decimal(6,0) DEFAULT NULL,
        public decimal MaxSalary { get; set; } // decimal(6,0) DEFAULT NULL,

        public virtual Department Department { get; set; }

        public List<Employee> Employees { get; set; }
    }
    
    public class Employee
    {
        public string EmployeeId { get; set; } //decimal(6,0) NOT NULL DEFAULT '0',
        public string FirstName { get; set; } //varchar(20) DEFAULT NULL,
        public string LastName { get; set; } //varchar(25) NOT NULL,
        public string Email { get; set; } //varchar(25) NOT NULL,
        public string PhoneNumber { get; set; } //varchar(20) DEFAULT NULL,
        public DateTime HireDate { get; set; } //date NOT NULL,
        public string JobId { get; set; } //varchar(10) NOT NULL,
        public decimal Salary { get; set; } //decimal(8,2) DEFAULT NULL,
        public decimal CommissionPCT { get; set; } //decimal(2,2) DEFAULT NULL,
        public string ManagerId { get; set; } //decimal(6,0) DEFAULT NULL,
        public string DepartmentId { get; set; } //decimal(4,0) DEFAULT NULL,

        public virtual Department Department { get; set; }
    }

    //public class JobHistory
    //{
    //    public int EmployeeId { get; set; } //decimal(6,0) NOT NULL,
    //    public DateTime StartDate { get; set; } //date NOT NULL,
    //    public DateTime EndDate { get; set; } //Date NOT NULL,
    //    public string JobId { get; set; } //varchar(10) NOT NULL,
    //    public int DepartmentId { get; set; } //decimal(4,0) DEFAULT NULL,

    //    public virtual Department Department { get; set; }
    //}
}
