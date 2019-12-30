using System;
using System.Linq;
using HRApplication.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace HRApplication.Models
{
    public class DataFeed
    {
        

        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();



                // Look for any Regions.
                if (context.Regions.Any())
                {
                    return; // DB has already been seeded.
                }
                /*
                // Look for any Countries.
                if (context.Countries.Any())
                {
                    return; // DB has already been seeded.
                }
                // Look for any Locations.
                if (context.Locations.Any())
                {
                    return; // DB has already been seeded.
                }
                // Look for any Departments.
                if (context.Departments.Any())
                {
                    return; // DB has already been seeded.
                }
                // Look for any Jobs.
                if (context.Jobs.Any())
                {
                    return; // DB has already been seeded.
                }
                // Look for any Employees.
                if (context.Employees.Any())
                {
                    return; // DB has already been seeded.
                }
                */
                var regions = DataFeed.GetRegions().ToArray();
                context.Regions.AddRange(regions);
                context.SaveChanges();

                var countries = DataFeed.GetCountries(context).ToArray();
                context.Countries.AddRange(countries);
                context.SaveChanges();

                var locations = DataFeed.GetLocations(context).ToArray();
                context.Locations.AddRange(locations);
                context.SaveChanges();

                var departments = DataFeed.GetDepartments(context).ToArray();
                context.Departments.AddRange(departments);
                context.SaveChanges();

                var jobs = DataFeed.GetJobs(context).ToArray();
                context.Jobs.AddRange(jobs);
                context.SaveChanges();

                var employees = DataFeed.GetEmployees(context).ToArray();
                context.Employees.AddRange(employees);
                context.SaveChanges();


                //var jobHistories = DataFeed.GetJobhistories(context).ToArray();
                //context.Jobhistories.AddRange(jobHistories);
                //context.SaveChanges();

            }
        }


        public static List<Region> GetRegions()
        {
            List<Region> regions = new List<Region>()
            {
                new Region(){ RegionName = "Europe", },
                new Region(){ RegionName = "Americas",},
                new Region(){ RegionName = "Asia",},
                new Region(){ RegionName = "Middle East and Africa",},
                /*
                new Region(){RegionId = 1, RegionName = "Europe", },
                new Region(){RegionId = 2, RegionName = "Americas",},
                new Region(){RegionId = 3, RegionName = "Asia",},
                new Region(){RegionId = 4, RegionName = "Middle East and Africa",},
                */
            };
            return regions;
        }

        public static List<Country> GetCountries(ApplicationDbContext context)
        {
            List<Country> countries = new List<Country>() {
            new Country{ CountryId = "AR", CountryName = "Argentina", RegionId = 2,},
            new Country{ CountryId = "AU", CountryName = "Australia", RegionId = 3,},
            new Country{ CountryId = "BE", CountryName = "Belgium", RegionId = 1,},
            new Country{ CountryId = "BR", CountryName = "Brazil", RegionId = 2,},
            new Country{ CountryId = "CA", CountryName = "Canada", RegionId = 2,},
            new Country{ CountryId = "CH", CountryName = "Switzerland", RegionId = 1,},
            new Country{ CountryId = "CN", CountryName = "China", RegionId = 3,},
            new Country{ CountryId = "DE", CountryName = "Germany", RegionId = 1,},
            new Country{ CountryId = "DK", CountryName = "Denmark", RegionId = 1,},
            new Country{ CountryId = "EG", CountryName = "Egypt", RegionId = 4,},
            new Country{ CountryId = "FR", CountryName = "France", RegionId = 1,},
            new Country{ CountryId = "HK", CountryName = "HongKong", RegionId = 3,},
            new Country{ CountryId = "IL", CountryName = "Israel", RegionId = 4,},
            new Country{ CountryId = "IN", CountryName = "India", RegionId = 3,},
            new Country{ CountryId = "IT", CountryName = "Italy", RegionId = 1,},
            new Country{ CountryId = "JP", CountryName = "Japan", RegionId = 3,},
            new Country{ CountryId = "KW", CountryName = "Kuwait", RegionId = 4,},
            new Country{ CountryId = "MX", CountryName = "Mexico", RegionId = 2,},
            new Country{ CountryId = "NG", CountryName = "Nigeria", RegionId = 4,},
            new Country{ CountryId = "NL", CountryName = "Netherlands", RegionId = 1,},
            new Country{ CountryId = "SG", CountryName = "Singapore", RegionId = 3,},
            new Country{ CountryId = "UK", CountryName = "United KingdomRegionId ", RegionId = 1,},
            new Country{ CountryId = "US", CountryName = "United States RegionId = of America", RegionId = 2,},
            new Country{ CountryId = "ZM", CountryName = "Zambia", RegionId = 4,},
            new Country{ CountryId = "ZW", CountryName = "Zimbabwe", RegionId = 4,},
            };
            return countries;
        }

        public static List<Location> GetLocations(ApplicationDbContext context)
        {
            List<Location> locations = new List<Location>()
            {
new Location{ LocationId = "1000",  StreetAddress = "1297 Via Cola di Rie", PostCode = "989", City = "Roma", County = "", CountryId = "IT",},
new Location{ LocationId = "1100",  StreetAddress = "93091 Calle della Testa",  PostCode = "10934",  City = "Venice",  County = "", CountryId = "IT",},
new Location{ LocationId = "1200",  StreetAddress = "2017 Shinjuku-ku",  PostCode = "1689",  City = "Tokyo",  County = "Tokyo Prefecture", CountryId = "JP",},
new Location{ LocationId = "1300",  StreetAddress = "9450 Kamiya-cho",  PostCode = "6823",  City = "Hiroshima",  County = "", CountryId = "JP",},
new Location{ LocationId = "1400",  StreetAddress = "2014 Jabberwocky Rd",  PostCode = "26192",  City = "Southlake",  County = "Texas", CountryId = "US",},
new Location{ LocationId = "1500",  StreetAddress = "2011 Interiors Blvd",  PostCode = "99236",  City = "South San Francisco",  County = "California", CountryId = "US",},
new Location{ LocationId = "1600",  StreetAddress = "2007 Zagora St",  PostCode = "50090",  City = "South Brunswick",  County = "New Jersey", CountryId = "US",},
new Location{ LocationId = "1700",  StreetAddress = "2004 Charade Rd",  PostCode = "98199",  City = "Seattle",  County = "Washington", CountryId = "US",},
new Location{ LocationId = "1800",  StreetAddress = "147 Spadina Ave",  PostCode = "M5V 2L7",  City = "Toronto",  County = "Ontario", CountryId = "CA",},
new Location{ LocationId = "1900",  StreetAddress = "6092 Boxwood St",  PostCode = "YSW 9T2",  City = "Whitehorse",  County = "Yukon", CountryId = "CA",},
new Location{ LocationId = "2000",  StreetAddress = "40-5-12 Laogianggen",  PostCode = "190518",  City = "Beijing",  County = "", CountryId = "CN",},
new Location{ LocationId = "2100",  StreetAddress = "1298 Vileparle E",  PostCode = "490231",  City = "Bombay",  County = "Maharashtra", CountryId = "IN",},
new Location{ LocationId = "2200",  StreetAddress = "12-98 Victoria Street",  PostCode = "2901",  City = "Sydney",  County = "New South Wales", CountryId = "AU",},
new Location{ LocationId = "2300",  StreetAddress = "198 Clementi North",  PostCode = "540198",  City = "Singapore",  County = "",CountryId =  "SG",},
new Location{ LocationId = "2400",  StreetAddress = "8204 Arthur St",  PostCode = "",  City = "London",  County = "", CountryId = "UK",},
new Location{ LocationId = "2500",  StreetAddress = "Magdalen Centre, The Oxford ",  PostCode = "OX9 9ZB",  City = "Oxford",  County = "", CountryId = "UK",},
new Location{ LocationId = "2600",  StreetAddress = "9702 Chester Road",  PostCode = "9629850293",   City = "Manchester",  County = "", CountryId = "UK",},
new Location{ LocationId = "2700",  StreetAddress = "Schwanthalerstr. 7031",  PostCode = "80925",  City = "Munich",  County = "Bavaria", CountryId = "DE",},
new Location{ LocationId = "2800",  StreetAddress = "Rua Frei Caneca 1360", PostCode =  "01307-002",  City = "Sao Paulo",  County = "Sao Paulo", CountryId = "BR",},
new Location{ LocationId = "2900",  StreetAddress = "20 Rue des Corps-Saints",  PostCode = "1730",  City = "Geneva",  County = "Geneve", CountryId = "CH",},
new Location{ LocationId = "3000",  StreetAddress = "Murtenstrasse 921",  PostCode = "3095",  City = "Bern",  County = "BE", CountryId = "CH",},
new Location{ LocationId = "3100",  StreetAddress = "Pieter Breughelstraat 837",  PostCode = "3029SK",  City = "Utrecht",  County = "Utrecht", CountryId = "NL",},
new Location{ LocationId = "3200",  StreetAddress = "Mariano Escobedo 9991",  PostCode = "11932",  City = "Mexico City",  County = "Distrito Federal", CountryId = "MX",},
            };
            return locations;
        }

        public static List<Department> GetDepartments(ApplicationDbContext context)
        {
            List<Department> departments = new List<Department>()
            {
                new Department{ DepartmentId = "10", DepartmentName = "Administration", ManagerId = "200", LocationId = "1700",},
                new Department{ DepartmentId = "20", DepartmentName = "Marketing", ManagerId = "201", LocationId = "1800",},
                new Department{ DepartmentId = "30", DepartmentName = "Purchasing", ManagerId = "114", LocationId = "1700",},
                new Department{ DepartmentId = "40", DepartmentName = "Human Resources", ManagerId = "20", LocationId = "2400",},
                new Department{ DepartmentId = "50", DepartmentName = "Shipping", ManagerId = "121", LocationId = "1500",},
                new Department{ DepartmentId = "60", DepartmentName = "IT", ManagerId = "103", LocationId = "1400",},
                new Department{ DepartmentId = "70", DepartmentName = "Public Relations", ManagerId = "20", LocationId = "2700",},
                new Department{ DepartmentId = "80", DepartmentName = "Sales", ManagerId = "145", LocationId = "2500",},
                new Department{ DepartmentId = "90", DepartmentName = "Executive", ManagerId = "100", LocationId = "1700",},
                new Department{ DepartmentId = "100", DepartmentName = "Finance", ManagerId = "108", LocationId = "1700",},
                new Department{ DepartmentId = "110", DepartmentName = "Accounting", ManagerId = "205", LocationId = "1700",},
                new Department{ DepartmentId = "120", DepartmentName = "Treasury", ManagerId = "0", LocationId = "1700",},
                new Department{ DepartmentId = "130", DepartmentName = "Corporate Tax", ManagerId = "0", LocationId =  "1700",},
                new Department{ DepartmentId = "140", DepartmentName = "Control And redit", ManagerId = "0", LocationId = "1700",},
                new Department{ DepartmentId = "150", DepartmentName = "Shareholder Services", ManagerId = "0", LocationId =  "1700",},
                new Department{ DepartmentId = "160", DepartmentName = "Benefits", ManagerId = "0", LocationId = "1700",},
                new Department{ DepartmentId = "170", DepartmentName = "Manufacturing", ManagerId = "0", LocationId = "1700",},
                new Department{ DepartmentId = "180", DepartmentName = "Construction", ManagerId = "0", LocationId = "1700",},
                new Department{ DepartmentId = "190", DepartmentName = "Contracting", ManagerId = "0", LocationId = "1700",},
                new Department{ DepartmentId = "200", DepartmentName = "Operations", ManagerId = "0", LocationId = "1700",},
                new Department{ DepartmentId = "210", DepartmentName = "IT Support", ManagerId = "0", LocationId =  "1700",},
                new Department{ DepartmentId = "220", DepartmentName = "NOC", ManagerId = "0", LocationId = "1700",},
                new Department{ DepartmentId = "230", DepartmentName = "IT Helpdesk", ManagerId = "0", LocationId =  "1700",},
                new Department{ DepartmentId = "240", DepartmentName = "Government Sales", ManagerId = "0", LocationId =  "1700",},
                new Department{ DepartmentId = "250", DepartmentName = "Retail Sales", ManagerId = "0", LocationId =  "1700",},
                new Department{ DepartmentId = "260", DepartmentName = "Recruiting", ManagerId = "0", LocationId = "1700",},
                new Department{ DepartmentId = "270", DepartmentName = "Payroll", ManagerId = "0", LocationId = "1700",},
            };
            return departments;
        }
        
        public static List<Job> GetJobs(ApplicationDbContext context)
        {
            List<Job> jobs = new List<Job>() 
            {
                    new Job { JobId = "AD_PRES", JobTitle = "President", MinSalary = 20000, MaxSalary = 40000,},
                    new Job { JobId = "AD_VP", JobTitle =  "Administration Vice President", MinSalary = 15000, MaxSalary = 30000,},
                    new Job { JobId = "AD_ASST", JobTitle =  "Administration Assistant", MinSalary = 3000, MaxSalary = 6000,},
                    new Job { JobId = "FI_MGR", JobTitle =  "Finance Manager", MinSalary = 8200, MaxSalary = 16000,},
                    new Job { JobId = "FI_ACCOUNT", JobTitle =  "Accountant", MinSalary = 4200, MaxSalary = 9000,},
                    new Job { JobId = "AC_MGR", JobTitle =  "Accounting Manager", MinSalary = 8200, MaxSalary = 16000,},
                    new Job { JobId = "AC_ACCOUNT", JobTitle =  "Public Accountant", MinSalary = 4200, MaxSalary = 9000,},
                    new Job { JobId = "SA_MAN", JobTitle =  "Sales Manager", MinSalary = 10000, MaxSalary = 20000,},
                    new Job { JobId = "SA_REP", JobTitle =  "Sales Representative", MinSalary = 6000, MaxSalary = 12000,},
                    new Job { JobId = "PU_MAN", JobTitle =  "Purchasing Manager", MinSalary = 8000, MaxSalary = 15000,},
                    new Job { JobId = "PU_CLERK", JobTitle =  "Purchasing Clerk", MinSalary = 2500, MaxSalary = 5500,},
                    new Job { JobId = "ST_MAN", JobTitle =  "Stock Manager", MinSalary = 5500, MaxSalary = 8500,},
                    new Job { JobId = "ST_CLERK", JobTitle =  "Stock Clerk", MinSalary = 2000, MaxSalary = 5000,},
                    new Job { JobId = "SH_CLERK", JobTitle =  "Shipping Clerk", MinSalary = 2500, MaxSalary = 5500,},
                    new Job { JobId = "IT_PROG", JobTitle =  "Programmer", MinSalary = 4000, MaxSalary = 10000,},
                    new Job { JobId = "MK_MAN", JobTitle =  "Marketing Manager", MinSalary = 9000, MaxSalary = 15000,},
                    new Job { JobId = "MK_REP", JobTitle =  "Marketing Representative", MinSalary = 4000, MaxSalary = 9000,},
                    new Job { JobId = "HR_REP", JobTitle =  "Human Resources Representative", MinSalary = 4000, MaxSalary = 9000,},
                    new Job { JobId = "PR_REP", JobTitle =  "Public Relations Representative", MinSalary = 4500, MaxSalary = 10500,},
            };
            return jobs;
        }

        public static List<Employee> GetEmployees(ApplicationDbContext context)
        {
            List<Employee> employees = new List<Employee>()
            {
new Employee{ EmployeeId = "100", FirstName = "Steven", LastName = "King", Email = "SKING", PhoneNumber = "515.123.4567", HireDate = Convert.ToDateTime("1987-06-17"), JobId = "AD_PRES", Salary = 24000.00m, CommissionPCT = 0.00m, ManagerId = "0", DepartmentId = "90",},
new Employee{ EmployeeId = "101", FirstName = "Neena", LastName = "Kochhar", Email = "NKOCHHAR", PhoneNumber = "515.123.4568", HireDate = Convert.ToDateTime("1987-06-18"), JobId = "AD_VP", Salary = 17000.00m, CommissionPCT = 0.00m, ManagerId = "100", DepartmentId = "90",},
new Employee{ EmployeeId = "102", FirstName = "Lex", LastName = "De Haan", Email = "LDEHAAN", PhoneNumber = "515.123.4569", HireDate = Convert.ToDateTime("1987-06-19"), JobId = "AD_VP", Salary = 17000.00m, CommissionPCT = 0.00m, ManagerId = "100", DepartmentId = "90",},
new Employee{ EmployeeId = "103", FirstName = "Alexander", LastName = "Hunold", Email = "AHUNOLD", PhoneNumber = "590.423.4567", HireDate = Convert.ToDateTime("1987-06-20"), JobId = "IT_PROG", Salary = 9000.00m, CommissionPCT = 0.00m, ManagerId = "102", DepartmentId = "60",},
new Employee{ EmployeeId = "104", FirstName = "Bruce", LastName = "Ernst", Email = "BERNST", PhoneNumber = "590.423.4568", HireDate = Convert.ToDateTime("1987-06-21"), JobId = "IT_PROG", Salary = 6000.00m, CommissionPCT = 0.00m, ManagerId = "103", DepartmentId = "60",},
new Employee{ EmployeeId = "105", FirstName = "David", LastName = "Austin", Email = "DAUSTIN", PhoneNumber = "590.423.4569", HireDate = Convert.ToDateTime("1987-06-22"), JobId = "IT_PROG", Salary = 4800.00m, CommissionPCT = 0.00m, ManagerId = "103", DepartmentId = "60",},
new Employee{ EmployeeId = "106", FirstName = "Valli", LastName = "Pataballa", Email = "VPATABAL", PhoneNumber = "590.423.4560", HireDate = Convert.ToDateTime("1987-06-23"), JobId = "IT_PROG", Salary = 4800.00m, CommissionPCT = 0.00m, ManagerId = "103", DepartmentId = "60",},
new Employee{ EmployeeId = "107", FirstName = "Diana", LastName = "Lorentz", Email = "DLORENTZ", PhoneNumber = "590.423.5567", HireDate = Convert.ToDateTime("1987-06-24"), JobId = "IT_PROG", Salary = 4200.00m, CommissionPCT = 0.00m, ManagerId = "103", DepartmentId = "60",},
new Employee{ EmployeeId = "108", FirstName = "Nancy", LastName = "Greenberg", Email = "NGREENBE", PhoneNumber = "515.124.4569", HireDate = Convert.ToDateTime("1987-06-25"), JobId = "FI_MGR", Salary = 12000.00m, CommissionPCT = 0.00m, ManagerId = "101", DepartmentId = "100",},
new Employee{ EmployeeId = "109", FirstName = "Daniel", LastName = "Faviet", Email = "DFAVIET", PhoneNumber = "515.124.4169", HireDate = Convert.ToDateTime("1987-06-26"), JobId = "FI_ACCOUNT", Salary = 9000.00m, CommissionPCT = 0.00m, ManagerId = "108", DepartmentId = "100",},
new Employee{ EmployeeId = "110", FirstName = "John", LastName = "Chen", Email = "JCHEN", PhoneNumber = "515.124.4269", HireDate = Convert.ToDateTime("1987-06-27"), JobId = "FI_ACCOUNT", Salary = 8200.00m, CommissionPCT = 0.00m, ManagerId = "108", DepartmentId = "100",},
new Employee{ EmployeeId = "111", FirstName = "Ismael", LastName = "Sciarra", Email = "ISCIARRA", PhoneNumber = "515.124.4369", HireDate = Convert.ToDateTime("1987-06-28"), JobId = "FI_ACCOUNT", Salary = 7700.00m, CommissionPCT = 0.00m, ManagerId = "108", DepartmentId = "100",},
new Employee{ EmployeeId = "112", FirstName = "Jose Manuel", LastName = "Urman", Email = "JMURMAN", PhoneNumber = "515.124.4469", HireDate = Convert.ToDateTime("1987-06-29"), JobId = "FI_ACCOUNT", Salary = 7800.00m, CommissionPCT = 0.00m, ManagerId = "108", DepartmentId = "100",},
new Employee{ EmployeeId = "113", FirstName = "Luis", LastName = "Popp", Email = "LPOPP", PhoneNumber = "515.124.4567", HireDate = Convert.ToDateTime("1987-06-30"), JobId = "FI_ACCOUNT", Salary = 6900.00m, CommissionPCT = 0.00m, ManagerId = "108", DepartmentId = "100",},
new Employee{ EmployeeId = "114", FirstName = "Den", LastName = "Raphaely", Email = "DRAPHEAL", PhoneNumber = "515.127.4561", HireDate = Convert.ToDateTime("1987-07-01"), JobId = "PU_MAN", Salary = 11000.00m, CommissionPCT = 0.00m, ManagerId = "100", DepartmentId = "30",},
new Employee{ EmployeeId = "115", FirstName = "Alexander", LastName = "Khoo", Email = "AKHOO", PhoneNumber = "515.127.4562", HireDate = Convert.ToDateTime("1987-07-02"), JobId = "PU_CLERK", Salary = 3100.00m, CommissionPCT = 0.00m, ManagerId = "114", DepartmentId = "30",},
new Employee{ EmployeeId = "116", FirstName = "Shelli", LastName = "Baida", Email = "SBAIDA", PhoneNumber = "515.127.4563", HireDate = Convert.ToDateTime("1987-07-03"), JobId = "PU_CLERK", Salary = 2900.00m, CommissionPCT = 0.00m, ManagerId = "114", DepartmentId = "30",},
new Employee{ EmployeeId = "117", FirstName = "Sigal", LastName = "Tobias", Email = "STOBIAS", PhoneNumber = "515.127.4564", HireDate = Convert.ToDateTime("1987-07-04"), JobId = "PU_CLERK", Salary = 2800.00m, CommissionPCT = 0.00m, ManagerId = "114", DepartmentId = "30",},
new Employee{ EmployeeId = "118", FirstName = "Guy", LastName = "Himuro", Email = "GHIMURO", PhoneNumber = "515.127.4565", HireDate = Convert.ToDateTime("1987-07-05"), JobId = "PU_CLERK", Salary = 2600.00m, CommissionPCT = 0.00m, ManagerId = "114", DepartmentId = "30",},
new Employee{ EmployeeId = "119", FirstName = "Karen", LastName = "Colmenares", Email = "KCOLMENA", PhoneNumber = "515.127.4566", HireDate = Convert.ToDateTime("1987-07-06"), JobId = "PU_CLERK", Salary = 2500.00m, CommissionPCT = 0.00m, ManagerId = "114", DepartmentId = "30",},
new Employee{ EmployeeId = "120", FirstName = "Matthew", LastName = "Weiss", Email = "MWEISS", PhoneNumber = "650.123.1234", HireDate = Convert.ToDateTime("1987-07-07"), JobId = "ST_MAN", Salary = 8000.00m, CommissionPCT = 0.00m, ManagerId = "100", DepartmentId = "50",},
new Employee{ EmployeeId = "121", FirstName = "Adam", LastName = "Fripp", Email = "AFRIPP", PhoneNumber = "650.123.2234", HireDate = Convert.ToDateTime("1987-07-08"), JobId = "ST_MAN", Salary = 8200.00m, CommissionPCT = 0.00m, ManagerId = "100", DepartmentId = "50",},
new Employee{ EmployeeId = "122", FirstName = "Payam", LastName = "Kaufling", Email = "PKAUFLIN", PhoneNumber = "650.123.3234", HireDate = Convert.ToDateTime("1987-07-09"), JobId = "ST_MAN", Salary = 7900.00m, CommissionPCT = 0.00m, ManagerId = "100", DepartmentId = "50",},
new Employee{ EmployeeId = "123", FirstName = "Shanta", LastName = "Vollman", Email = "SVOLLMAN", PhoneNumber = "650.123.4234", HireDate = Convert.ToDateTime("1987-07-10"), JobId = "ST_MAN", Salary = 6500.00m, CommissionPCT = 0.00m, ManagerId = "100", DepartmentId = "50",},
new Employee{ EmployeeId = "124", FirstName = "Kevin", LastName = "Mourgos", Email = "KMOURGOS", PhoneNumber = "650.123.5234", HireDate = Convert.ToDateTime("1987-07-11"), JobId = "ST_MAN", Salary = 5800.00m, CommissionPCT = 0.00m, ManagerId = "100", DepartmentId = "50",},
new Employee{ EmployeeId = "125", FirstName = "Julia", LastName = "Nayer", Email = "JNAYER", PhoneNumber = "650.124.1214", HireDate = Convert.ToDateTime("1987-07-12"), JobId = "ST_CLERK", Salary = 3200.00m, CommissionPCT = 0.00m, ManagerId = "120", DepartmentId = "50",},
new Employee{ EmployeeId = "126", FirstName = "Irene", LastName = "Mikkilineni", Email = "IMIKKILI", PhoneNumber = "650.124.1224", HireDate = Convert.ToDateTime("1987-07-13"), JobId = "ST_CLERK", Salary = 2700.00m, CommissionPCT = 0.00m, ManagerId = "120", DepartmentId = "50",},
new Employee{ EmployeeId = "127", FirstName = "James", LastName = "Landry", Email = "JLANDRY", PhoneNumber = "650.124.1334", HireDate = Convert.ToDateTime("1987-07-14"), JobId = "ST_CLERK", Salary = 2400.00m, CommissionPCT = 0.00m, ManagerId = "120", DepartmentId = "50",},
new Employee{ EmployeeId = "128", FirstName = "Steven", LastName = "Markle", Email = "SMARKLE", PhoneNumber = "650.124.1434", HireDate = Convert.ToDateTime("1987-07-15"), JobId = "ST_CLERK", Salary = 2200.00m, CommissionPCT = 0.00m, ManagerId = "120", DepartmentId = "50",},
new Employee{ EmployeeId = "129", FirstName = "Laura", LastName = "Bissot", Email = "LBISSOT", PhoneNumber = "650.124.5234", HireDate = Convert.ToDateTime("1987-07-16"), JobId = "ST_CLERK", Salary = 3300.00m, CommissionPCT = 0.00m, ManagerId = "121", DepartmentId = "50",},
new Employee{ EmployeeId = "130", FirstName = "Mozhe", LastName = "Atkinson", Email = "MATKINSO", PhoneNumber = "650.124.6234", HireDate = Convert.ToDateTime("1987-07-17"), JobId = "ST_CLERK", Salary = 2800.00m, CommissionPCT = 0.00m, ManagerId = "121", DepartmentId = "50",},
new Employee{ EmployeeId = "131", FirstName = "James", LastName = "Marlow", Email = "JAMRLOW", PhoneNumber = "650.124.7234", HireDate = Convert.ToDateTime("1987-07-18"), JobId = "ST_CLERK", Salary = 2500.00m, CommissionPCT = 0.00m, ManagerId = "121", DepartmentId = "50",},
new Employee{ EmployeeId = "132", FirstName = "TJ", LastName = "Olson", Email = "TJOLSON", PhoneNumber = "650.124.8234", HireDate = Convert.ToDateTime("1987-07-19"), JobId = "ST_CLERK", Salary = 2100.00m, CommissionPCT = 0.00m, ManagerId = "121", DepartmentId = "50",},
new Employee{ EmployeeId = "133", FirstName = "Jason", LastName = "Mallin", Email = "JMALLIN", PhoneNumber = "650.127.1934", HireDate = Convert.ToDateTime("1987-07-20"), JobId = "ST_CLERK", Salary = 3300.00m, CommissionPCT = 0.00m, ManagerId = "122", DepartmentId = "50",},
new Employee{ EmployeeId = "134", FirstName = "Michael", LastName = "Rogers", Email = "MROGERS", PhoneNumber = "650.127.1834", HireDate = Convert.ToDateTime("1987-07-21"), JobId = "ST_CLERK", Salary = 2900.00m, CommissionPCT = 0.00m, ManagerId = "122", DepartmentId = "50",},
new Employee{ EmployeeId = "135", FirstName = "Ki", LastName = "Gee", Email = "KGEE", PhoneNumber = "650.127.1734", HireDate = Convert.ToDateTime("1987-07-22"), JobId = "ST_CLERK", Salary = 2400.00m, CommissionPCT = 0.00m, ManagerId = "122", DepartmentId = "50",},
new Employee{ EmployeeId = "136", FirstName = "Hazel", LastName = "Philtanker", Email = "HPHILTAN", PhoneNumber = "650.127.1634", HireDate = Convert.ToDateTime("1987-07-23"), JobId = "ST_CLERK", Salary = 2200.00m, CommissionPCT = 0.00m, ManagerId = "122", DepartmentId = "50",},
new Employee{ EmployeeId = "137", FirstName = "Renske", LastName = "Ladwig", Email = "RLADWIG", PhoneNumber = "650.121.1234", HireDate = Convert.ToDateTime("1987-07-24"), JobId = "ST_CLERK", Salary = 3600.00m, CommissionPCT = 0.00m, ManagerId = "123", DepartmentId = "50",},
new Employee{ EmployeeId = "138", FirstName = "Stephen", LastName = "Stiles", Email = "SSTILES", PhoneNumber = "650.121.2034", HireDate = Convert.ToDateTime("1987-07-25"), JobId = "ST_CLERK", Salary = 3200.00m, CommissionPCT = 0.00m, ManagerId = "123", DepartmentId = "50",},
new Employee{ EmployeeId = "139", FirstName = "John", LastName = "Seo", Email = "JSEO", PhoneNumber = "650.121.2019", HireDate = Convert.ToDateTime("1987-07-26"), JobId = "ST_CLERK", Salary = 2700.00m, CommissionPCT = 0.00m, ManagerId = "123", DepartmentId = "50",},
new Employee{ EmployeeId = "140", FirstName = "Joshua", LastName = "Patel", Email = "JPATEL", PhoneNumber = "650.121.1834", HireDate = Convert.ToDateTime("1987-07-27"), JobId = "ST_CLERK", Salary = 2500.00m, CommissionPCT = 0.00m, ManagerId = "123", DepartmentId = "50",},
new Employee{ EmployeeId = "141", FirstName = "Trenna", LastName = "Rajs", Email = "TRAJS", PhoneNumber = "650.121.8009", HireDate = Convert.ToDateTime("1987-07-28"), JobId = "ST_CLERK", Salary = 3500.00m, CommissionPCT = 0.00m, ManagerId = "124", DepartmentId = "50",},
new Employee{ EmployeeId = "142", FirstName = "Curtis", LastName = "Davies", Email = "CDAVIES", PhoneNumber = "650.121.2994", HireDate = Convert.ToDateTime("1987-07-29"), JobId = "ST_CLERK", Salary = 3100.00m, CommissionPCT = 0.00m, ManagerId = "124", DepartmentId = "50",},
new Employee{ EmployeeId = "143", FirstName = "Randall", LastName = "Matos", Email = "RMATOS", PhoneNumber = "650.121.2874", HireDate = Convert.ToDateTime("1987-07-30"), JobId = "ST_CLERK", Salary = 2600.00m, CommissionPCT = 0.00m, ManagerId = "124", DepartmentId = "50",},
new Employee{ EmployeeId = "144", FirstName = "Peter", LastName = "Vargas", Email = "PVARGAS", PhoneNumber = "650.121.2004", HireDate = Convert.ToDateTime("1987-07-31"), JobId = "ST_CLERK", Salary = 2500.00m, CommissionPCT = 0.00m, ManagerId = "124", DepartmentId = "50",},
new Employee{ EmployeeId = "145", FirstName = "John", LastName = "Russell", Email = "JRUSSEL", PhoneNumber = "099.44.1344.429268", HireDate = Convert.ToDateTime("1987-08-01"), JobId = "SA_MAN", Salary = 14000.00m, CommissionPCT = 0.40m, ManagerId = "100", DepartmentId = "80",},
new Employee{ EmployeeId = "146", FirstName = "Karen", LastName = "Partners", Email = "KPARTNER", PhoneNumber = "44.1344.467268", HireDate = Convert.ToDateTime("1987-08-02"), JobId = "SA_MAN", Salary = 13500.00m, CommissionPCT = 0.30m, ManagerId = "100", DepartmentId = "80",},
new Employee{ EmployeeId = "147", FirstName = "Alberto", LastName = "Errazuriz", Email = "AERRAZUR", PhoneNumber = " .44.1344.429278", HireDate = Convert.ToDateTime("1987-08-03"), JobId = "SA_MAN", Salary = 12000.00m, CommissionPCT = 0.30m, ManagerId = "100", DepartmentId = "80",},
new Employee{ EmployeeId = "148", FirstName = "Gerald", LastName = "Cambrault", Email = "GCAMBRAU", PhoneNumber = " .44.1344.619268", HireDate = Convert.ToDateTime("1987-08-04"), JobId = "SA_MAN", Salary = 11000.00m, CommissionPCT = 0.30m, ManagerId = "100", DepartmentId = "80",},
new Employee{ EmployeeId = "149", FirstName = "Eleni", LastName = "Zlotkey", Email = "EZLOTKEY", PhoneNumber = " .44.1344.429018", HireDate = Convert.ToDateTime("1987-08-05"), JobId = "SA_MAN", Salary = 10500.00m, CommissionPCT = 0.20m, ManagerId = "100", DepartmentId = "80",},
new Employee{ EmployeeId = "150", FirstName = "Peter", LastName = "Tucker", Email = "PTUCKER", PhoneNumber = " .44.1344.129268", HireDate = Convert.ToDateTime("1987-08-06"), JobId = "SA_REP", Salary = 10000.00m, CommissionPCT = 0.30m, ManagerId = "145", DepartmentId = "80",},
new Employee{ EmployeeId = "151", FirstName = "David", LastName = "Bernstein", Email = "DBERNSTE", PhoneNumber = " .44.1344.345268", HireDate = Convert.ToDateTime("1987-08-07"), JobId = "SA_REP", Salary = 9500.00m, CommissionPCT = 0.25m, ManagerId = "145", DepartmentId = "80",},
new Employee{ EmployeeId = "152", FirstName = "Peter", LastName = "Hall", Email = "PHALL", PhoneNumber = " .44.1344.478968", HireDate = Convert.ToDateTime("1987-08-08"), JobId = "SA_REP", Salary = 9000.00m, CommissionPCT = 0.25m, ManagerId = "145", DepartmentId = "80",},
new Employee{ EmployeeId = "153", FirstName = "Christopher", LastName = "Olsen", Email = "COLSEN", PhoneNumber = " .44.1344.498718", HireDate = Convert.ToDateTime("1987-08-09"), JobId = "SA_REP", Salary = 8000.00m, CommissionPCT = 0.20m, ManagerId = "145", DepartmentId = "80",},
new Employee{ EmployeeId = "154", FirstName = "Nanette", LastName = "Cambrault", Email = "NCAMBRAU", PhoneNumber = " .44.1344.987668", HireDate = Convert.ToDateTime("1987-08-10"), JobId = "SA_REP", Salary = 7500.00m, CommissionPCT = 0.20m, ManagerId = "145", DepartmentId = "80",},
new Employee{ EmployeeId = "155", FirstName = "Oliver", LastName = "Tuvault", Email = "OTUVAULT", PhoneNumber = " .44.1344.486508", HireDate = Convert.ToDateTime("1987-08-11"), JobId = "SA_REP", Salary = 7000.00m, CommissionPCT = 0.15m, ManagerId = "145", DepartmentId = "80",},
new Employee{ EmployeeId = "156", FirstName = "Janette", LastName = "King", Email = "JKING", PhoneNumber = " .44.1345.429268", HireDate = Convert.ToDateTime("1987-08-12"), JobId = "SA_REP", Salary = 10000.00m, CommissionPCT = 0.35m, ManagerId = "146", DepartmentId = "80",},
new Employee{ EmployeeId = "157", FirstName = "Patrick", LastName = "Sully", Email = "PSULLY", PhoneNumber = " .44.1345.929268", HireDate = Convert.ToDateTime("1987-08-13"), JobId = "SA_REP", Salary = 9500.00m, CommissionPCT = 0.35m, ManagerId = "146", DepartmentId = "80",},
new Employee{ EmployeeId = "158", FirstName = "Allan", LastName = "McEwen", Email = "AMCEWEN", PhoneNumber = " .44.1345.829268", HireDate = Convert.ToDateTime("1987-08-14"), JobId = "SA_REP", Salary = 9000.00m, CommissionPCT = 0.35m, ManagerId = "146", DepartmentId = "80",},
new Employee{ EmployeeId = "159", FirstName = "Lindsey", LastName = "Smith", Email = "LSMITH", PhoneNumber = " .44.1345.729268", HireDate = Convert.ToDateTime("1987-08-15"), JobId = "SA_REP", Salary = 8000.00m, CommissionPCT = 0.30m, ManagerId = "146", DepartmentId = "80",},
new Employee{ EmployeeId = "160", FirstName = "Louise", LastName = "Doran", Email = "LDORAN", PhoneNumber = " .44.1345.629268", HireDate = Convert.ToDateTime("1987-08-16"), JobId = "SA_REP", Salary = 7500.00m, CommissionPCT = 0.30m, ManagerId = "146", DepartmentId = "80",},
new Employee{ EmployeeId = "161", FirstName = "Sarath", LastName = "Sewall", Email = "SSEWALL", PhoneNumber = " .44.1345.529268", HireDate = Convert.ToDateTime("1987-08-17"), JobId = "SA_REP", Salary = 7000.00m, CommissionPCT = 0.25m, ManagerId = "146", DepartmentId = "80",},
new Employee{ EmployeeId = "162", FirstName = "Clara", LastName = "Vishney", Email = "CVISHNEY", PhoneNumber = " .44.1346.129268", HireDate = Convert.ToDateTime("1987-08-18"), JobId = "SA_REP", Salary = 10500.00m, CommissionPCT = 0.25m, ManagerId = "147", DepartmentId = "80",},
new Employee{ EmployeeId = "163", FirstName = "Danielle", LastName = "Greene", Email = "DGREENE", PhoneNumber = " .44.1346.229268", HireDate = Convert.ToDateTime("1987-08-19"), JobId = "SA_REP", Salary = 9500.00m, CommissionPCT = 0.15m, ManagerId = "147", DepartmentId = "80",},
new Employee{ EmployeeId = "164", FirstName = "Mattea", LastName = "Marvins", Email = "MMARVINS", PhoneNumber = " .44.1346.329268", HireDate = Convert.ToDateTime("1987-08-20"), JobId = "SA_REP", Salary = 7200.00m, CommissionPCT = 0.10m, ManagerId = "147", DepartmentId = "80",},
new Employee{ EmployeeId = "165", FirstName = "David", LastName = "Lee", Email = "DLEE", PhoneNumber = " .44.1346.529268", HireDate = Convert.ToDateTime("1987-08-21"), JobId = "SA_REP", Salary = 6800.00m, CommissionPCT = 0.10m, ManagerId = "147", DepartmentId = "80",},
new Employee{ EmployeeId = "166", FirstName = "Sundar", LastName = "Ande", Email = "SANDE", PhoneNumber = " .44.1346.629268", HireDate = Convert.ToDateTime("1987-08-22"), JobId = "SA_REP", Salary = 6400.00m, CommissionPCT = 0.10m, ManagerId = "147", DepartmentId = "80",},
new Employee{ EmployeeId = "167", FirstName = "Amit", LastName = "Banda", Email = "ABANDA", PhoneNumber = " .44.1346.729268", HireDate = Convert.ToDateTime("1987-08-23"), JobId = "SA_REP", Salary = 6200.00m, CommissionPCT = 0.10m, ManagerId = "147", DepartmentId = "80",},
new Employee{ EmployeeId = "168", FirstName = "Lisa", LastName = "Ozer", Email = "LOZER", PhoneNumber = " .44.1343.929268", HireDate = Convert.ToDateTime("1987-08-24"), JobId = "SA_REP", Salary = 11500.00m, CommissionPCT = 0.25m, ManagerId = "148", DepartmentId = "80",},
new Employee{ EmployeeId = "169", FirstName = "Harrison", LastName = "Bloom", Email = "HBLOOM", PhoneNumber = " .44.1343.829268", HireDate = Convert.ToDateTime("1987-08-25"), JobId = "SA_REP", Salary = 10000.00m, CommissionPCT = 0.20m, ManagerId = "148", DepartmentId = "80",},
new Employee{ EmployeeId = "170", FirstName = "Tayler", LastName = "Fox", Email = "TFOX", PhoneNumber = " .44.1343.729268", HireDate = Convert.ToDateTime("1987-08-26"), JobId = "SA_REP", Salary = 9600.00m, CommissionPCT = 0.20m, ManagerId = "148", DepartmentId = "80",},
new Employee{ EmployeeId = "171", FirstName = "William", LastName = "Smith", Email = "WSMITH", PhoneNumber = " .44.1343.629268", HireDate = Convert.ToDateTime("1987-08-27"), JobId = "SA_REP", Salary = 7400.00m, CommissionPCT = 0.15m, ManagerId = "148", DepartmentId = "80",},
new Employee{ EmployeeId = "172", FirstName = "Elizabeth", LastName = "Bates", Email = "EBATES", PhoneNumber = " .44.1343.529268", HireDate = Convert.ToDateTime("1987-08-28"), JobId = "SA_REP", Salary = 7300.00m, CommissionPCT = 0.15m, ManagerId = "148", DepartmentId = "80",},
new Employee{ EmployeeId = "173", FirstName = "Sundita", LastName = "Kumar", Email = "SKUMAR", PhoneNumber = " .44.1343.329268", HireDate = Convert.ToDateTime("1987-08-29"), JobId = "SA_REP", Salary = 6100.00m, CommissionPCT = 0.10m, ManagerId = "148", DepartmentId = "80",},
new Employee{ EmployeeId = "174", FirstName = "Ellen", LastName = "Abel", Email = "EABEL", PhoneNumber = " .44.1644.429267", HireDate = Convert.ToDateTime("1987-08-30"), JobId = "SA_REP", Salary = 11000.00m, CommissionPCT = 0.30m, ManagerId = "149", DepartmentId = "80",},
new Employee{ EmployeeId = "175", FirstName = "Alyssa", LastName = "Hutton", Email = "AHUTTON", PhoneNumber = " .44.1644.429266", HireDate = Convert.ToDateTime("1987-08-31"), JobId = "SA_REP", Salary = 8800.00m, CommissionPCT = 0.25m, ManagerId = "149", DepartmentId = "80",},
new Employee{ EmployeeId = "176", FirstName = "Jonathon", LastName = "Taylor", Email = "TAYLOR", PhoneNumber = " .44.1644.429265", HireDate = Convert.ToDateTime("1987-09-01"), JobId = "SA_REP", Salary = 8600.00m, CommissionPCT = 0.20m, ManagerId = "149", DepartmentId = "80",},
new Employee{ EmployeeId = "177", FirstName = "Jack", LastName = "Livingston", Email = "JLIVINGS", PhoneNumber = " .44.1644.429264", HireDate = Convert.ToDateTime("1987-09-02"), JobId = "SA_REP", Salary = 8400.00m, CommissionPCT = 0.20m, ManagerId = "149", DepartmentId = "80",},
new Employee{ EmployeeId = "178", FirstName = "Kimberely", LastName = "Grant", Email = "KGRANT", PhoneNumber = " .44.1644.429263", HireDate = Convert.ToDateTime("1987-09-03"), JobId = "SA_REP", Salary = 7000.00m, CommissionPCT = 0.15m, ManagerId = "149", DepartmentId = "80",},
new Employee{ EmployeeId = "179", FirstName = "Charles", LastName = "Johnson", Email = "CJOHNSON", PhoneNumber = " .44.1644.429262", HireDate = Convert.ToDateTime("1987-09-04"), JobId = "SA_REP", Salary = 6200.00m, CommissionPCT = 0.10m, ManagerId = "149", DepartmentId = "80",},
new Employee{ EmployeeId = "180", FirstName = "Winston", LastName = "Taylor", Email = "WTAYLOR", PhoneNumber = "650.507.9876", HireDate = Convert.ToDateTime("1987-09-05"), JobId = "SH_CLERK", Salary = 3200.00m, CommissionPCT = 0.00m, ManagerId = "120", DepartmentId = "50",},
new Employee{ EmployeeId = "181", FirstName = "Jean", LastName = "Fleaur", Email = "JFLEAUR", PhoneNumber = "650.507.9877", HireDate = Convert.ToDateTime("1987-09-06"), JobId = "SH_CLERK", Salary = 3100.00m, CommissionPCT = 0.00m, ManagerId = "120", DepartmentId = "50",},
new Employee{ EmployeeId = "182", FirstName = "Martha", LastName = "Sullivan", Email = "MSULLIVA", PhoneNumber = "650.507.9878", HireDate = Convert.ToDateTime("1987-09-07"), JobId = "SH_CLERK", Salary = 2500.00m, CommissionPCT = 0.00m, ManagerId = "120", DepartmentId = "50",},
new Employee{ EmployeeId = "183", FirstName = "Girard", LastName = "Geoni", Email = "GGEONI", PhoneNumber = "650.507.9879", HireDate = Convert.ToDateTime("1987-09-08"), JobId = "SH_CLERK", Salary = 2800.00m, CommissionPCT = 0.00m, ManagerId = "120", DepartmentId = "50",},
new Employee{ EmployeeId = "184", FirstName = "Nandita", LastName = "Sarchand", Email = "NSARCHAN", PhoneNumber = "650.509.1876", HireDate = Convert.ToDateTime("1987-09-09"), JobId = "SH_CLERK", Salary = 4200.00m, CommissionPCT = 0.00m, ManagerId = "121", DepartmentId = "50",},
new Employee{ EmployeeId = "185", FirstName = "Alexis", LastName = "Bull", Email = "ABULL", PhoneNumber = "650.509.2876", HireDate = Convert.ToDateTime("1987-09-10"), JobId = "SH_CLERK", Salary = 4100.00m, CommissionPCT = 0.00m, ManagerId = "121", DepartmentId = "50",},
new Employee{ EmployeeId = "186", FirstName = "Julia", LastName = "Dellinger", Email = "JDELLING", PhoneNumber = "650.509.3876", HireDate = Convert.ToDateTime("1987-09-11"), JobId = "SH_CLERK", Salary = 3400.00m, CommissionPCT = 0.00m, ManagerId = "121", DepartmentId = "50",},
new Employee{ EmployeeId = "187", FirstName = "Anthony", LastName = "Cabrio", Email = "ACABRIO", PhoneNumber = "650.509.4876", HireDate = Convert.ToDateTime("1987-09-12"), JobId = "SH_CLERK", Salary = 3000.00m, CommissionPCT = 0.00m, ManagerId = "121", DepartmentId = "50",},
new Employee{ EmployeeId = "188", FirstName = "Kelly", LastName = "Chung", Email = "KCHUNG", PhoneNumber = "650.505.1876", HireDate = Convert.ToDateTime("1987-09-13"), JobId = "SH_CLERK", Salary = 3800.00m, CommissionPCT = 0.00m, ManagerId = "122", DepartmentId = "50",},
new Employee{ EmployeeId = "189", FirstName = "Jennifer", LastName = "Dilly", Email = "JDILLY", PhoneNumber = "650.505.2876", HireDate = Convert.ToDateTime("1987-09-14"), JobId = "SH_CLERK", Salary = 3600.00m, CommissionPCT = 0.00m, ManagerId = "122", DepartmentId = "50",},
new Employee{ EmployeeId = "190", FirstName = "Timothy", LastName = "Gates", Email = "TGATES", PhoneNumber = "650.505.3876", HireDate = Convert.ToDateTime("1987-09-15"), JobId = "SH_CLERK", Salary = 2900.00m, CommissionPCT = 0.00m, ManagerId = "122", DepartmentId = "50",},
new Employee{ EmployeeId = "191", FirstName = "Randall", LastName = "Perkins", Email = "RPERKINS", PhoneNumber = "650.505.4876", HireDate = Convert.ToDateTime("1987-09-16"), JobId = "SH_CLERK", Salary = 2500.00m, CommissionPCT = 0.00m, ManagerId = "122", DepartmentId = "50",},
new Employee{ EmployeeId = "192", FirstName = "Sarah", LastName = "Bell", Email = "SBELL", PhoneNumber = "650.501.1876", HireDate = Convert.ToDateTime("1987-09-17"), JobId = "SH_CLERK", Salary = 4000.00m, CommissionPCT = 0.00m, ManagerId = "123", DepartmentId = "50",},
new Employee{ EmployeeId = "193", FirstName = "Britney", LastName = "Everett", Email = "BEVERETT", PhoneNumber = "650.501.2876", HireDate = Convert.ToDateTime("1987-09-18"), JobId = "SH_CLERK", Salary = 3900.00m, CommissionPCT = 0.00m, ManagerId = "123", DepartmentId = "50",},
new Employee{ EmployeeId = "194", FirstName = "Samuel", LastName = "McCain", Email = "SMCCAIN", PhoneNumber = "650.501.3876", HireDate = Convert.ToDateTime("1987-09-19"), JobId = "SH_CLERK", Salary = 3200.00m, CommissionPCT = 0.00m, ManagerId = "123", DepartmentId = "50",},
new Employee{ EmployeeId = "195", FirstName = "Vance", LastName = "Jones", Email = "VJONES", PhoneNumber = "650.501.4876", HireDate = Convert.ToDateTime("1987-09-20"), JobId = "SH_CLERK", Salary = 2800.00m, CommissionPCT = 0.00m, ManagerId = "123", DepartmentId = "50",},
new Employee{ EmployeeId = "196", FirstName = "Alana", LastName = "Walsh", Email = "AWALSH", PhoneNumber = "650.507.9811", HireDate = Convert.ToDateTime("1987-09-21"), JobId = "SH_CLERK", Salary = 3100.00m, CommissionPCT = 0.00m, ManagerId = "124", DepartmentId = "50",},
new Employee{ EmployeeId = "197", FirstName = "Kevin", LastName = "Feeney", Email = "KFEENEY", PhoneNumber = "650.507.9822", HireDate = Convert.ToDateTime("1987-09-22"), JobId = "SH_CLERK", Salary = 3000.00m, CommissionPCT = 0.00m, ManagerId = "124", DepartmentId = "50",},
new Employee{ EmployeeId = "198", FirstName = "Donald", LastName = "OConnell", Email = "DOCONNEL", PhoneNumber = "650.507.9833", HireDate = Convert.ToDateTime("1987-09-23"), JobId = "SH_CLERK", Salary = 2600.00m, CommissionPCT = 0.00m, ManagerId = "124", DepartmentId = "50",},
new Employee{ EmployeeId = "199", FirstName = "Douglas", LastName = "Grant", Email = "DGRANT", PhoneNumber = "650.507.9844", HireDate = Convert.ToDateTime("1987-09-24"), JobId = "SH_CLERK", Salary = 2600.00m, CommissionPCT = 0.00m, ManagerId = "124", DepartmentId = "50",},
new Employee{ EmployeeId = "200", FirstName = "Jennifer", LastName = "Whalen", Email = "JWHALEN", PhoneNumber = "515.123.4444", HireDate = Convert.ToDateTime("1987-09-25"), JobId = "AD_ASST", Salary = 4400.00m, CommissionPCT = 0.00m, ManagerId = "101", DepartmentId = "10",},
new Employee{ EmployeeId = "201", FirstName = "Michael", LastName = "Hartstein", Email = "MHARTSTE", PhoneNumber = "515.123.5555", HireDate = Convert.ToDateTime("1987-09-26"), JobId = "MK_MAN", Salary = 13000.00m, CommissionPCT = 0.00m, ManagerId = "100", DepartmentId = "20",},
new Employee{ EmployeeId = "202", FirstName = "Pat", LastName = "Fay", Email = "PFAY", PhoneNumber = "603.123.6666", HireDate = Convert.ToDateTime("1987-09-27"), JobId = "MK_REP", Salary = 6000.00m, CommissionPCT = 0.00m, ManagerId = "201", DepartmentId = "20",},
new Employee{ EmployeeId = "203", FirstName = "Susan", LastName = "Mavris", Email = "SMAVRIS", PhoneNumber = "515.123.7777", HireDate = Convert.ToDateTime("1987-09-28"), JobId = "HR_REP", Salary = 6500.00m, CommissionPCT = 0.00m, ManagerId = "101", DepartmentId = "40",},
new Employee{ EmployeeId = "204", FirstName = "Hermann", LastName = "Baer", Email = "HBAER", PhoneNumber = "515.123.8888", HireDate = Convert.ToDateTime("1987-09-29"), JobId = "PR_REP", Salary = 10000.00m, CommissionPCT = 0.00m, ManagerId = "101", DepartmentId = "70",},
new Employee{ EmployeeId = "205", FirstName = "Shelley", LastName = "Higgins", Email = "SHIGGINS", PhoneNumber = "515.123.8080", HireDate = Convert.ToDateTime("1987-09-30"), JobId = "AC_MGR", Salary = 12000.00m, CommissionPCT = 0.00m, ManagerId = "101", DepartmentId = "110",},
new Employee{ EmployeeId = "206", FirstName = "William", LastName = "Gietz", Email = "WGIETZ", PhoneNumber = "515.123.8181", HireDate = Convert.ToDateTime("1987-10-01"), JobId = "AC_ACCOUNT", Salary = 8300.00m, CommissionPCT = 0.00m, ManagerId = "205", DepartmentId = "110",}, };
//new Employee{ EmployeeId = "102", FirstName = "Lex", LastName = "De Haan",  Email = "LDEHAAN", PhoneNumber = "515.123.4569", HireDate = Convert.ToDateTime("1987-06-19"), JobId =  "AD_VPSalary", Salary= 17000.00m, CommissionPCT =  0.00m, ManagerId =  100, DepartmentId =  "90",},
//new Employee{ EmployeeId = "112", FirstName = "Jose Manuel", LastName = "Urman", Email = "JMURMAN", PhoneNumber =  "515.124.4469", HireDate = Convert.ToDateTime("1987-06-29"),JobId =  "FI_ACCOUNTSalary", Salary =  7800.00m, CommissionPCT =  0.00m, ManagerId =  108, DepartmentId = "100",},


            return employees;
        }

        /*
        public static List<JobHistory> GetJobhistories(ApplicationDbContext context)
        {
            List<JobHistory> jobhistories = new List<JobHistory>() {
new JobHistory{ EmployeeId = 102, StartDate = Convert.ToDateTime("1993-01-13"), EndDate = Convert.ToDateTime("1998-07-24"), JobId = "IT_PROG", DepartmentId = 60,},
new JobHistory{ EmployeeId = 101, StartDate = Convert.ToDateTime("1989-09-21"), EndDate = Convert.ToDateTime("1993-10-27"), JobId = "AC_ACCOUNT", DepartmentId = 110,},
new JobHistory{ EmployeeId = 101, StartDate = Convert.ToDateTime("1993-10-28"), EndDate = Convert.ToDateTime("1997-03-15"), JobId = "AC_MGR", DepartmentId = 110,},
new JobHistory{ EmployeeId = 201, StartDate = Convert.ToDateTime("1996-02-17"), EndDate = Convert.ToDateTime("1999-12-19"), JobId = "MK_REP", DepartmentId = 20,},
new JobHistory{ EmployeeId = 114, StartDate = Convert.ToDateTime("1998-03-24"), EndDate = Convert.ToDateTime("1999-12-31"), JobId = "ST_CLERK", DepartmentId = 50,},
new JobHistory{ EmployeeId = 122, StartDate = Convert.ToDateTime("1999-01-01"), EndDate = Convert.ToDateTime("1999-12-31"), JobId = "ST_CLERK", DepartmentId = 50,},
new JobHistory{ EmployeeId = 200, StartDate = Convert.ToDateTime("1987-09-17"), EndDate = Convert.ToDateTime("1993-06-17"), JobId = "AD_ASST", DepartmentId = 90,},
new JobHistory{ EmployeeId = 176, StartDate = Convert.ToDateTime("1998-03-24"), EndDate = Convert.ToDateTime("1998-12-31"), JobId = "SA_REP", DepartmentId = 80,},
new JobHistory{ EmployeeId = 176, StartDate = Convert.ToDateTime("1999-01-01"), EndDate = Convert.ToDateTime("1999-12-31"), JobId = "SA_MAN", DepartmentId = 80,},
new JobHistory{ EmployeeId = 200, StartDate = Convert.ToDateTime("1994-07-01"), EndDate = Convert.ToDateTime("1998-12-31"), JobId = "AC_ACCOUNT", DepartmentId = 90,},
            };
            return jobhistories;
        }

    */
    }
}
