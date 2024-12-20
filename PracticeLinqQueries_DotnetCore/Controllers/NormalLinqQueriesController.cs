﻿
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PracticeLinqQueries_DotnetCore.Models;
using PracticeLinqQueries_DotnetCore.NorthWind_Db_Connect;
using PracticeLinqQueries_DotnetCore.NorthWind_DbConnect;
namespace LinqQueriesPractiseInDotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormalLinqQueriesController : ControllerBase
    {
        private readonly NorthwindDb1Context _northwind_DBContext;
        private readonly NorthwindContext _northwindContext;
        public NormalLinqQueriesController(NorthwindDb1Context northwind_DBContext, NorthwindContext northwindContext)
        {
            _northwind_DBContext = northwind_DBContext;
            _northwindContext = northwindContext;
        }
        [HttpGet]
        [Route("GetEmployeesData")]
        public async Task<IActionResult> GetEmployeesData()
        {//here we are fetching all employess  data.
            var result = from abc in _northwindContext.Employees select abc;

            //This Line version Compatable issue
            var JsonSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            //It converts your data to jsonformat
            var convertedData = JsonConvert.SerializeObject(result, JsonSettings);
            return StatusCode(StatusCodes.Status200OK, convertedData);
        }


        [HttpGet]
        [Route("GetEmployeesDatawith_ITDepartment")]
        public async Task<IActionResult> GetEmployeesDatawith_ITDepartment()
        {//it will return employee data with it department along with all the columns data
            var result = from a in _northwind_DBContext.Employees where a.Designation == "IT" select a;
            //It converts your data to jsonformat
            var convertedData = JsonConvert.SerializeObject(result);
            return StatusCode(StatusCodes.Status200OK, convertedData);

        }

        [HttpGet]
        [Route("GetEmpData_WithItDepartment_Names")]
        public async Task<IActionResult> GetEmpData_WithItDepartment_Names()
        {
            //here fetching data it department wit names only
            var result = from itname in _northwind_DBContext.Employees select new { FullName = itname.Name };

            var convertedData=JsonConvert.SerializeObject(result);
            return StatusCode(StatusCodes.Status200OK, convertedData);

        }

        [HttpGet]
        [Route("GetCustomerData_WithContactName_FirstLetter")]
        public async Task<IActionResult> GetCustomerData_WithContactName_FirstLetter()
        {
            //here fetching data contactName first Letter By Using Customer Table reference
            var result = from contname in _northwind_DBContext.Customers where contname.ContactName.StartsWith("A") select contname;

            var convertedData=JsonConvert.SerializeObject(result);
            return StatusCode(StatusCodes.Status200OK,convertedData);
        }

        [HttpGet]
        [Route("GetEmp_DepetData_ByUsing_Joins")]
        public async Task<IActionResult> GetEmp_DepetData_ByUsing_Joins()
        {
            //here fetching data two tables by using joins
            var result = from e in _northwindContext.Employees join d in _northwindContext.Departments on e.EmpId equals d.Id orderby e.City select new { e.FirstName, e.LastName, e.City, d.DeptName };

            var convertedData = JsonConvert.SerializeObject(result);
            return StatusCode(StatusCodes.Status200OK, convertedData);
        }

        [HttpGet]
        [Route("take(number) Usage")]
        public async Task<IActionResult> TakeUsage()
        {
            //if you want to get the only first 5 records in atable use this take(number) method.
            //select top 5 * from customers
            var result = (from lstcustmer in _northwindContext.Customers select lstcustmer).Take(5);
            //It converts your data to jsonformat
            var convertedData = JsonConvert.SerializeObject(result);
            return StatusCode(StatusCodes.Status200OK, convertedData);

        }

        [HttpGet]
        [Route("Skip(number) Usage")]
        public async Task<IActionResult> SkipUsage()
        {
            //if you want to get the only first 5 records in a table use this take(number) method.
            //after using the take() method you can use skip() method .
            //skip will skip or ignore the given count of records after taking the records.
            //select top 5 * from customers
            var result = (from lstcustmer in _northwindContext.Customers select lstcustmer).Take(5).Skip(4);
            //It converts your data to jsonformat
            var convertedData = JsonConvert.SerializeObject(result);
            return StatusCode(StatusCodes.Status200OK, convertedData);

        }


        [HttpGet]
        [Route("AgeWithFilter")]
        public async Task<IActionResult> AgeWithFilter()
        {
            //example with dummydata
            List<StudentData> lststudentsObj = new List<StudentData>()
            {
               new StudentData() { StudentID = 1, StudentName = "John", Age = 13} ,
               new StudentData() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
               new StudentData() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
               new StudentData() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
               new StudentData() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };
            var filteredResult = from s in lststudentsObj
                                 where s.Age > 15 && s.Age <= 20
                                 select new { FullName = s.StudentName };//giving the alisaname
                                                                         //It converts your data to jsonformat
            var convertedData = JsonConvert.SerializeObject(filteredResult);
            return StatusCode(StatusCodes.Status200OK, convertedData);

        }


        [HttpGet]
        [Route("OrderByusage")]
        public async Task<IActionResult> OrderbyUsage()
        {
            //example with dummydata
            List<StudentData> lststudentsObj = new List<StudentData>()
            {
               new StudentData() { StudentID = 1, StudentName = "John", Age = 13} ,
               new StudentData() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
               new StudentData() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
               new StudentData() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
               new StudentData() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };
            var orderByAscendingResult = from s in lststudentsObj
                                         orderby s.StudentName ascending
                                         select s;

            var orderByDescendingResult = from s in lststudentsObj
                                          orderby s.StudentName descending
                                          select s;
            //It converts your data to jsonformat
            var convertedData = JsonConvert.SerializeObject(orderByDescendingResult);
            return StatusCode(StatusCodes.Status200OK, convertedData);

        }

        [HttpGet]
        [Route("GroupByusage")]
        public async Task<IActionResult> GroupByusage()
        {
            //example with dummydata
            List<StudentData> lststudentsObj = new List<StudentData>()
            {
               new StudentData() { StudentID = 1, StudentName = "John", Age = 13} ,
               new StudentData() { StudentID = 2, StudentName = "Moin",  Age = 13 } ,
               new StudentData() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
               new StudentData() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
               new StudentData() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };
            var groupedStudents = lststudentsObj.GroupBy(s => s.Age)
                                     .Select(g => new { Age = g.Key, Students = g.ToList() });
            //It converts your data to jsonformat
            var convertedData = JsonConvert.SerializeObject(groupedStudents);
            return StatusCode(StatusCodes.Status200OK, convertedData);

        }

        [HttpGet]
        [Route("GroupByusageWithCount")]
        public async Task<IActionResult> GroupByusageWithCount()
        {
            //example with dummydata
            // Define a list of fruits
            List<string> fruits = new List<string>
        {
            "apple", "banana", "orange", "apple", "grape", "banana", "apple"
        };

            // Group the fruits using Query syntax(RealTime Usethis one)
            var groupedFruits = fruits.GroupBy(f => f)
                          .Select(g => new { Fruit = g.Key, Count = g.Count() });

            // Group the fruits using method syntax
            var fruitsGrouped1 = fruits.GroupBy(fruit => fruit);

            // Print the grouped fruits
            foreach (var group in fruitsGrouped1)
            {
                Console.WriteLine($"Fruit: {group.Key}, Count: {group.Count()}");
            }
            //It converts your data to jsonformat
            var convertedData = JsonConvert.SerializeObject(groupedFruits);
            return StatusCode(StatusCodes.Status200OK, convertedData);

        }
    }
}



