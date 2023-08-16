using EmployeeFront.Models;
using Newtonsoft.Json;

namespace EmployeeFront.Data
{
    public class ApiClient
    {
        private HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {

            //code to  bypass SSL certificate validation 
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

            _httpClient = new HttpClient(httpClientHandler);

            //_httpClient = httpClient;
        }

        public async Task<List<EmployeeVM>> GetDataFromApiAsync(string apiUrl)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                List<EmployeeVM> employees = JsonConvert.DeserializeObject<List<EmployeeVM>>(content);
                return employees;
            }
            return null;
        }

        public async Task<List<UsersVM>> GetUsersFromApiAsync(string apiUrl)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                List<UsersVM> users = JsonConvert.DeserializeObject<List<UsersVM>>(content);
                return users;
            }
            return null;
        }
        public async Task<bool> CreateEmployeeAsync(EmployeeVM newEmployee)
        {
            try
            {
               
                string json = JsonConvert.SerializeObject(newEmployee);

               
                string apiUrl = "https://localhost:7279/api/Employee/Post";

               
                HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

               
                HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);

                
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    
                    return false;
                }
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }
        public async Task<EmployeeVM> GetEmployeeByIdAsync(int id)
        {
            try
            {
                
                string apiUrl = $"https://localhost:7279/api/Employee/Get/{id}";

                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                
                if (response.IsSuccessStatusCode)
                {
                   
                    string content = await response.Content.ReadAsStringAsync();

                    
                    EmployeeVM employee = JsonConvert.DeserializeObject<EmployeeVM>(content);
                    return employee;
                }
                else
                {
                    
                    return null;
                }
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeVM updatedEmployee)
        {
            try
            {
                
                string json = JsonConvert.SerializeObject(updatedEmployee);

                
                string apiUrl = "https://localhost:7279/api/Employee/Put";
                
                HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PutAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            try
            {
            
                string apiUrl = $"https://localhost:7279/api/Employee/Delete?id={id}";
                
                HttpResponseMessage response = await _httpClient.DeleteAsync(apiUrl);
                
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
