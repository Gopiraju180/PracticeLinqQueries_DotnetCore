using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PracticeLinqQueries_DotnetCore.Models;
using PracticeLinqQueries_DotnetCore.NorthWind_Db_Connect;
using PracticeLinqQueries_DotnetCore.NorthWind_DbConnect;

namespace PracticeLinqQueries_DotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LamdaLinqQueriesController : ControllerBase
    {
        private readonly NorthwindDb1Context _northwind_DBContext;
        private readonly NorthwindContext _northwindContext;
        public LamdaLinqQueriesController(NorthwindDb1Context northwind_DBContext, NorthwindContext northwindContext)
        {
            _northwind_DBContext = northwind_DBContext;
            _northwindContext = northwindContext;
        }

        [HttpGet]
        [Route("GetEmployeeData")]
        public async Task<IActionResult> GetEmployeeData()
        {
            var result = _northwindContext.Employees.ToList();
            var jsonSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

            var convertedData = JsonConvert.SerializeObject(result, jsonSettings);
            return StatusCode(StatusCodes.Status200OK, convertedData);
        }

        [HttpGet]
        [Route("GetEmployeesDatawith_ITDepartment")]
        public async Task<IActionResult> GetEmployeesDatawith_ITDepartment()
        {//it will return employee data with it department along with all the columns data
         // var result = from a in _northwind_DBContext.Employees where a.Designation == "IT" select a;

            var result = _northwindContext.Employees.Where(a => a.City == "London").ToList();
            //It converts your data to jsonformat
            var convertedData = JsonConvert.SerializeObject(result);
            return StatusCode(StatusCodes.Status200OK, convertedData);

        }

        [HttpGet]
        [Route("GetEmpData_WithItDepartment_Names")]
        public async Task<IActionResult> GetEmpData_WithItDepartment_Names()
        {
            //here fetching data it department wit names only
            //var result = from itname in _northwind_DBContext.Employees select new { FullName = itname.Name };

            var result = _northwindContext.Employees.Select(e => new {e.LastName,e.FirstName }).ToList();

            var convertedData = JsonConvert.SerializeObject(result);
            return StatusCode(StatusCodes.Status200OK, convertedData);

        }

        [HttpGet]
        [Route("OrderByusage")]
        public async Task<IActionResult> OrderbyUsage()
        {
            ////example with dummydata
            //List<StudentData> lststudentsObj = new List<StudentData>()
            //{
            //   new StudentData() { StudentID = 1, StudentName = "John", Age = 13} ,
            //   new StudentData() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
            //   new StudentData() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
            //   new StudentData() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
            //   new StudentData() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            //};
            //var orderByAscendingResult = from s in lststudentsObj
            //                             orderby s.StudentName ascending
            //                             select s;

            //var orderByDescendingResult = from s in lststudentsObj
            //                              orderby s.StudentName descending
            //                              select s;

           // var orderByDescendingResult = _northwindContext.Employees.OrderBy(e=>e.City).ToList();
            var assendin=_northwind_DBContext.Customers.OrderBy(c=>c.ContactName).ToList();
            //It converts your data to jsonformat
            var convertedData = JsonConvert.SerializeObject(assendin);
            return StatusCode(StatusCodes.Status200OK, convertedData);

        }

        [HttpGet]
        [Route("GroupByusage")]
        public async Task<IActionResult> GroupByusage()
        {
            ////example with dummydata
            //List<StudentData> lststudentsObj = new List<StudentData>()
            //{
            //   new StudentData() { StudentID = 1, StudentName = "John", Age = 13} ,
            //   new StudentData() { StudentID = 2, StudentName = "Moin",  Age = 13 } ,
            //   new StudentData() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
            //   new StudentData() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
            //   new StudentData() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            //};
            //var groupedStudents = lststudentsObj.GroupBy(s => s.Age)
            //                         .Select(g => new { Age = g.Key, Students = g.ToList() });

            var groupby = _northwind_DBContext.Customers.GroupBy(s => s.CompanyName)
                                        .Select(g => new { CompanyName = g.Key, CompanyName1 = g.ToList() });
                                        //It converts your data to jsonformat
            var convertedData = JsonConvert.SerializeObject(groupby);
            return StatusCode(StatusCodes.Status200OK, convertedData);

        }
    }
}
