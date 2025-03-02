using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using TaskManagement.Models.Models;
using Newtonsoft.Json;
using System.Text;

namespace TaskManagement.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient httpClient;

        public LoginController()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7031/")
            };
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<JsonResult> ValidateUser([FromBody]LoginModel model)
        {
            try
            {
                var response = await httpClient.PostAsync($"Login/ValidateUser",
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
