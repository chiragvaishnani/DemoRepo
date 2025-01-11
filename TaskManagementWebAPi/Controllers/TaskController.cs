using Microsoft.AspNetCore.Mvc;
using TaskManagementWebAPi.Models;
using TaskManagementWebAPI.Repository;

namespace TaskManagementWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }


        [HttpGet("GetTaskById/{id}")]
        public async Task<ActionResult<TaskModel>> GetTaskById(int id)
        {
            if (id > 0)
            {
                var result = await _taskRepository.GetTaskById(id);
                return Ok(result);
            }
            else
                return BadRequest("Id is not valid");
        }

        [HttpGet("GetAllTask")]
        public async Task<ActionResult<List<TaskModel>>> GetAllTask()
        {
            var result = await _taskRepository.GetTaskList();
            return Ok(result);
        }


        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteTask(int id)
        {
            if (id > 0)
            {
                var result = await _taskRepository.DeleteTask(id);
                return Ok(result);
            }
            else
                return BadRequest("Id is not valid");
        }


        [HttpPost("AddTask")]
        public async Task<ActionResult> AddTask([FromBody] TaskModel model)
        {
            if (ModelState.IsValid)
            {
                //check if task exist
                var task = await _taskRepository.GetTaskByName(model.TaskName);
                if (task == null)
                {
                    var result = await _taskRepository.AddTask(model);
                    return result == 0 ? Ok(result) : BadRequest($"Error occurred, try again!");
                }
                else
                    return BadRequest($"{model.TaskName} is already exist!");
            }
            else
                return BadRequest(string.Join(',', ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage))));
        }

        [HttpPost("UpdateTask")]
        public async Task<ActionResult> UpdateTask([FromBody] TaskModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO : we can check if the updated task name is match with existing records
                var result = await _taskRepository.EditTask(model);
                return result ? Ok(result) : BadRequest($"Error occurred, try again!");
            }
            else
                return BadRequest(string.Join(',', ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage))));
        }
    }
}
