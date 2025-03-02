using Dapper;
using System.Data;
using TaskManagement.Models.Models;
using TaskManagementWebAPI.Data;

namespace TaskManagementWebAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext context;

        public UserRepository()
        {
            this.context = new DapperContext();
        }

        public async Task<int> AddUser(RegisterUserModel model)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Email", model.Email);
                parameters.Add("Password", model.Password);
                parameters.Add("UserName", model.UserName);
                parameters.Add("MobileNumber", model.MobileNumber);

                using (var connection = context.CreateConnection())
                {
                    return await connection.ExecuteScalarAsync<int>("InsertUser", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> ValidateUser(LoginModel model)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Email", model.Email);
                parameters.Add("Password", model.Password);

                using (var connection = context.CreateConnection())
                {
                    return await connection.ExecuteScalarAsync<int>("ValidateUser", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
