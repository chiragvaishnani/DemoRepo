using TaskManagement.Models.Models;

namespace TaskManagementWebAPI.Repository
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetTaskList();

        Task<TaskModel> GetTaskById(int taskId);

        Task<TaskModel?> GetTaskByName(string taskName);

        Task<int> AddTask(TaskModel taskModel);

        Task<bool> EditTask(TaskModel taskModel);

        Task<bool> DeleteTask(int taskId);

        Task<List<TaskStatusModel>> GetTaskStatusList();
    }
}
