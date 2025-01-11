using Dapper;
using System.Data;
using TaskManagementWebAPi.Models;
using TaskManagementWebAPI.Data;

namespace TaskManagementWebAPI.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DapperContext context;

        public TaskRepository()
        {
            this.context = new DapperContext();
        }

        public async Task<List<TaskModel>> GetTaskList()
        {
            try
            {
                using (var connection = context.CreateConnection())
                {
                    IEnumerable<TaskModel> result = await connection.QueryAsync<TaskModel>("GetTaskList",
                        commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<TaskModel> GetTaskById(int taskId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", taskId);

                using (var connection = context.CreateConnection())
                {
                    return await connection.QuerySingleAsync<TaskModel>("GetTaskById", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<TaskModel?> GetTaskByName(string taskName)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("TaskName", taskName);

                using (var connection = context.CreateConnection())
                {
                    var result = await connection.QueryAsync<TaskModel>("GetTaskByName", parameters, commandType: CommandType.StoredProcedure);
                    return result?.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> AddTask(TaskModel taskModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("TaskName", taskModel.TaskName);
                parameters.Add("TaskDescription", taskModel.TaskDescription);
                parameters.Add("TaskStatusId", Convert.ToInt32(taskModel.TaskStatusId));

                using (var connection = context.CreateConnection())
                {
                    return await connection.ExecuteScalarAsync<int>("AddTask", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> EditTask(TaskModel taskModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", taskModel.Id);
                parameters.Add("TaskName", taskModel.TaskName);
                parameters.Add("TaskDescription", taskModel.TaskDescription);
                parameters.Add("TaskStatusId", Convert.ToInt32(taskModel.TaskStatusId));
                using (var connection = context.CreateConnection())
                {
                    int result = await connection.ExecuteScalarAsync<int>("EditTask", parameters, commandType: CommandType.StoredProcedure);
                    return result == 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteTask(int taskId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", taskId);
                using (var connection = context.CreateConnection())
                {
                    await connection.ExecuteAsync("DeleteTask", parameters, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<TaskStatusModel>> GetTaskStatusList()
        {
            try
            {
                using (var connection = context.CreateConnection())
                {
                    IEnumerable<TaskStatusModel> result = await connection.QueryAsync<TaskStatusModel>("GetTaskStatusList",
                        commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

       
    }
}
