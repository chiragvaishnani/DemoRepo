using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json;
using TaskManagement.Models.Models;
using TaskModel = TaskManagement.Models.Models.TaskModel;

namespace TaskManagement.Controllers
{
    public class TaskController : Controller
    {
        //private readonly ITaskRepository _taskRepository;

        private readonly HttpClient httpClient;

        public TaskController()
        {
            //_taskRepository = taskRepository;
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7031/")
            };
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var result = new List<TaskModel>();

                var response = await httpClient.GetAsync("Task/GetAllTask1");

                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    result = System.Text.Json.JsonSerializer.Deserialize<List<TaskModel>>(stringResponse, new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    // Add the deserialized ProductsResponse to the result list

                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new Exception("Products not found.");
                    }
                    else
                    {
                        throw new Exception("Failed to fetch data from the server. Status code: " + response.StatusCode);
                    }
                }

                return View(result);

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
            // return View(await _taskRepository.GetTaskList());
        }

        public async Task<ActionResult> Insert()
        {
            try
            {
                //var result = await _taskRepository.GetTaskStatusList();
                var response = await httpClient.GetAsync($"Task/GetTaskStatusList");

                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<TaskStatusModel>>(stringResponse, new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    TaskModel model = new TaskModel()
                    {
                        StatusList = result.ConvertAll(a =>
                        {
                            return new SelectListItem()
                            {
                                Text = a.StatusName,
                                Value = a.Id.ToString(),
                                Selected = false
                            };
                        })
                    };
                    return View(model);

                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new Exception("Task is not found.");
                    }
                    else
                    {
                        throw new Exception("Failed to fetch data from the server. Status code: " + response.StatusCode);
                    }
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

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                //var result = new List<TaskModel>();

                var response = await httpClient.GetAsync("Task/GetAllTask");

                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<TaskModel>>(stringResponse, new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    TaskModel model = new TaskModel(); // await _taskRepository.GetTaskById(id);
                    model.StatusList = result.ConvertAll(a =>
                    {
                        return new SelectListItem()
                        {
                            Text = a.StatusName,
                            Value = a.Id.ToString(),
                            Selected = model.TaskStatusId == a.Id.ToString()
                        };
                    });

                    return View(model);

                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new Exception("Products not found.");
                    }
                    else
                    {
                        throw new Exception("Failed to fetch data from the server. Status code: " + response.StatusCode);
                    }
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
            //var statusResult = await _taskRepository.GetTaskStatusList();
            
        }

        public async Task<ActionResult> View(int id)
        {
            try
            {
                TaskModel result = new TaskModel();

                var response = await httpClient.GetAsync($"Task/GetTaskById/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    result = System.Text.Json.JsonSerializer.Deserialize<TaskModel>(stringResponse, new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    // Add the deserialized ProductsResponse to the result list

                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new Exception("Task is not found.");
                    }
                    else
                    {
                        throw new Exception("Failed to fetch data from the server. Status code: " + response.StatusCode);
                    }
                }

                return View(result);

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

            //return View(model);
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteTask(int id)
        {
            if (id > 0)
            {
                try
                {
                    var response = await httpClient.DeleteAsync($"Task/DeleteTask/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        var stringResponse = await response.Content.ReadAsStringAsync();
                        bool result = System.Text.Json.JsonSerializer.Deserialize<bool>(stringResponse, new JsonSerializerOptions()
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });
                        return result ? Json("Sucess") : Json($"Error occurred, try again!");
                        // Add the deserialized ProductsResponse to the result list

                    }
                    else
                    {
                        if (response.StatusCode == HttpStatusCode.NotFound)
                        {
                            throw new Exception("Task is not found.");
                        }
                        else
                        {
                            throw new Exception("Failed to fetch data from the server. Status code: " + response.StatusCode);
                        }
                    }

                    //return Json($"Error occurred, try again!");

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
            else
                return Json($"Id is not valid");
        }


        [HttpPost]
        public async Task<JsonResult> AddTask([FromBody] TaskModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await httpClient.PostAsync($"Task/AddTask", 
                        new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        var stringResponse = await response.Content.ReadAsStringAsync();
                        var result = System.Text.Json.JsonSerializer.Deserialize<int>(stringResponse, new JsonSerializerOptions()
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });
                        return result != 0 ? Json("Sucess") : Json($"Error occurred, try again!");
                        
                    }
                    else
                    {
                        if (response.StatusCode == HttpStatusCode.NotFound)
                        {
                            throw new Exception("Task is not found.");
                        }
                        else
                        {
                            throw new Exception("Failed to fetch data from the server. Status code: " + response.StatusCode);
                        }
                    }

                    //return Json($"Error occurred, try again!");

                }
                catch (HttpRequestException ex)
                {
                    throw new Exception("HTTP request failed: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("An unexpected error occurred: " + ex.Message);
                }

                ////check if task exist
                //var task = await _taskRepository.GetTaskByName(model.TaskName);
                //if (task == null)
                //{
                //    var result = await _taskRepository.AddTask(model);
                //    return result == 0 ? Json("Sucess") : Json($"Error occurred, try again!");
                //}
                //else
                //    return Json($"{model.TaskName} is already exist!");
            }
            else
                return Json(string.Join(',', ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage))));
        }

        [HttpPost]
        public async Task<JsonResult> UpdateTask([FromBody] TaskModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await httpClient.PutAsync($"Task/UpdateTask",
                        new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        var stringResponse = await response.Content.ReadAsStringAsync();
                        var result = System.Text.Json.JsonSerializer.Deserialize<bool>(stringResponse, new JsonSerializerOptions()
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });
                        return result ? Json("Sucess") : Json($"Error occurred, try again!");

                    }
                    else
                    {
                        if (response.StatusCode == HttpStatusCode.NotFound)
                        {
                            throw new Exception("Task is not found.");
                        }
                        else
                        {
                            throw new Exception("Failed to fetch data from the server. Status code: " + response.StatusCode);
                        }
                    }

                    //return Json($"Error occurred, try again!");

                }
                catch (HttpRequestException ex)
                {
                    throw new Exception("HTTP request failed: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("An unexpected error occurred: " + ex.Message);
                }

                ////TODO : we can check if the updated task name is match with existing records
                //var result = await _taskRepository.EditTask(model);
                //return result ? Json("Sucess") : Json($"Error occurred, try again!");
            }
            else
                return Json(string.Join(',', ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage))));
        }
    }
}
