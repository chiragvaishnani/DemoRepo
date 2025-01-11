using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManagement.Model;
using TaskManagement.Repository;

namespace TaskManagement.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _taskRepository.GetTaskList());
        }

        public async Task<ActionResult> Insert()
        {
            var result = await _taskRepository.GetTaskStatusList();
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

        public async Task<ActionResult> Edit(int id)
        {
            var statusResult = await _taskRepository.GetTaskStatusList();
            TaskModel model = await _taskRepository.GetTaskById(id);
            model.StatusList = statusResult.ConvertAll(a =>
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

        public async Task<ActionResult> View(int id)
        {
            TaskModel model = await _taskRepository.GetTaskById(id);
            return View(model);
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteTask(int id)
        {
            if (id > 0)
            {
                var result = await _taskRepository.DeleteTask(id);
                return result ? Json("Sucess") : Json($"Error occurred, try again!");
            }
            else
                return Json($"Id is not valid");
        }


        [HttpPost]
        public async Task<JsonResult> AddTask([FromBody] TaskModel model)
        {
            if (ModelState.IsValid)
            {
                //check if task exist
                var task = await _taskRepository.GetTaskByName(model.TaskName);
                if (task == null)
                {
                    var result = await _taskRepository.AddTask(model);
                    return result == 0 ? Json("Sucess") : Json($"Error occurred, try again!");
                }
                else
                    return Json($"{model.TaskName} is already exist!");
            }
            else
                return Json(string.Join(',', ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage))));
        }

        [HttpPost]
        public async Task<JsonResult> UpdateTask([FromBody] TaskModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO : we can check if the updated task name is match with existing records
                var result = await _taskRepository.EditTask(model);
                return result ? Json("Sucess") : Json($"Error occurred, try again!");
            }
            else
                return Json(string.Join(',', ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage))));
        }
    }
}
