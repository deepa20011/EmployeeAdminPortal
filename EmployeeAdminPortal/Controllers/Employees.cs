using EmployeeAdminPortal.Controllers.Models.Entitties;
using EmployeeAdminPortal.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employees : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;
        private readonly ApplicationDBContext dbcontent;

        //public Employees(ApplicationDBContext dBContext)
        //{
        //    this.dBContext = dBContext;
        //}
        public Employees(ApplicationDBContext dbcontent)
        {
            this.dbcontent = dbcontent;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
         var allemployees=   dBContext.Employees.ToList();
            return Ok(allemployees);

        }

        [HttpPost]
        public IActionResult AddEmployees(AddEmployees addemployeeData)
        {
            var empEnity = new Employee()
            {
                Email = addemployeeData.Email,
                Name = addemployeeData.Name,
                Phone = addemployeeData.Phone,
                Salary = addemployeeData.Salary,
            };
            dBContext.Employees.Add(empEnity);
            dBContext.SaveChanges();
            return Ok(empEnity);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeByID(Guid id)
        {
        var employee=dbcontent.Employees.Find(id);
            if (employee is null)
            { return NotFound(); }
            else
            {
                return Ok(employee);

            }
        }

        [HttpPut]
        [Route("{id:guid}")]

        public IActionResult UpdateEmployee(Guid id,AddEmployees dto)
        {
            var employee = dbcontent.Employees.Find(id);
            if (employee is null)
            { return NotFound(); }
         
            employee.Name=dto.Name;
            employee.Salary = dto.Salary;
            employee.Phone = dto.Phone;
            employee.Email=dto.Email;
            dbcontent.SaveChanges();
            return Ok(employee);
          //  dbcontent.Employees.Add(employee);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbcontent.Employees.Find(id);
            if (employee is null)
            { return NotFound(); }
            dbcontent.Employees.Remove(employee);
            dbcontent.SaveChanges();
            return Ok(employee);
        }
    }
}
