using EmployeeFront.Data;
using EmployeeFront.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeFront.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApiClient _apiClient;

        public LoginController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsersVM user)
        {

            string apiUrl = "https://localhost:7279/api/Employee/GetUser";
            List<UsersVM> userslist = await _apiClient.GetUsersFromApiAsync(apiUrl);

            if (userslist.Any(i => i.UserName == user.UserName && i.PassWord == user.PassWord))
            {
                HttpContext.Session.SetString("UserName", user.UserName);
                HttpContext.Session.SetInt32("UserId", user.UserID);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "User not found";
            return View();
        }
    }
}
