using EmployeeWebAPI.Data;
using EmployeeWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _db;
        public EmployeeController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var employees = _db.Employee.ToList();
                if (employees == null || employees.Count == 0)
                {
                    return NotFound("Employee Not Available");
                }
                return Ok(employees);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var employee = _db.Employee.FirstOrDefault(c => c.EmpID == id);
                if (employee == null)
                {
                    return NotFound("Employee Not Available");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {

            try
            {
                _db.Employee.Add(employee);
                _db.SaveChanges();
                return Ok("Employee Added");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public IActionResult Put(Employee employee)
        {
            if(employee == null)
            {
                return BadRequest("Inavid Data");
            }
            else if(employee.EmpID == 0)
            {
                return BadRequest("Inavid Emp Id");
            }
            else
            {
                try
                {
                    var empObj = _db.Employee.FirstOrDefault(c => c.EmpID == employee.EmpID);
                    if (empObj == null)
                    {
                        return NotFound("Inavid Emp Id");
                    }
                    else
                    {
                        empObj.FirstName = employee.FirstName;
                        empObj.LastName = employee.LastName;
                        empObj.Salary = employee.Salary;
                        _db.SaveChanges();
                        return Ok("Updated Succesfully");

                    }
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var employee = _db.Employee.FirstOrDefault(c => c.EmpID == id);
                if (employee == null)
                {
                    return NotFound("Inavid Emp Id");
                }
                _db.Remove(employee);
                _db.SaveChanges();
                return Ok("Deleted Employee");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetUser()
        {
            try
            {
                var users = _db.Users.ToList();
                if (users == null || users.Count == 0)
                {
                    return NotFound("User Not Available");
                }
                return Ok(users);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
