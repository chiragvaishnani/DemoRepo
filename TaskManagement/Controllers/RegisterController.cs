using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TaskManagement.Models.Models;

namespace TaskManagement.Controllers
{
    public class RegisterController : Controller
    {
        private readonly HttpClient httpClient;
        public RegisterController()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7031/")
            };
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> RegisterUser([FromBody] RegisterUserModel model)
        {
            try
            {
                var response = await httpClient.PostAsync($"Register/RegisterUser",
                        new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return Json("Sucess");
                }
                else
                {
                    return Json($"Error occurred, try again!");
                }

                //return View(result);

            }
            catch (HttpRequestException ex)
            {
                throw new Exception("HTTP request failed: " + ex.Message);
            }
            catch (System.Text.Json.JsonException ex)
            {
                throw new Exception("JSON deserialization failed: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred: " + ex.Message);
            }


        }
    }
}
 
