using EmployeeFront.Data;
using EmployeeFront.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeFront.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApiClient _apiClient;

        public EmployeeController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }


        public async Task<IActionResult> Index()
        {

            string apiUrl = "https://localhost:7279/api/Employee/Get";
            List<EmployeeVM> employees = await _apiClient.GetDataFromApiAsync(apiUrl);

           
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVM newEmployee)
        {
            if (ModelState.IsValid)
            {
                bool success = await _apiClient.CreateEmployeeAsync(newEmployee);

                if (success)
                {
                    TempData["success"] = "Employee was created";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Employee was Not created";
                    return RedirectToAction("Index");
                }
            }

            
            return View(newEmployee);
        }
        public async Task<IActionResult> Edit(int id)
        {
            
            EmployeeVM existingEmployee = await _apiClient.GetEmployeeByIdAsync(id);

            if (existingEmployee == null)
            {
                TempData["error"] = "Employee was not found";

                return RedirectToAction("Index");
            }

            return View(existingEmployee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeVM updatedEmployee)
        {
            if (ModelState.IsValid)
            {
                bool success = await _apiClient.UpdateEmployeeAsync(updatedEmployee);

                if (success)
                {
                    TempData["success"] = "Employee was updated";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Employee was Not updated";
                    return RedirectToAction("Error");
                }
            }

            
            return View(updatedEmployee);
        }
        public async Task<IActionResult> Delete(int id)
        {
            bool success = await _apiClient.DeleteEmployeeAsync(id);

            if (success)
            {
                TempData["success"] = "Employee was deleted";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["success"] = "Employee was not deleted";
                return RedirectToAction("Index");
            }
        }
    }
}
