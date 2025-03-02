using TaskManagement.Models.Models;

namespace TaskManagementWebAPI.Repository
{
    public interface IUserRepository
    {
        Task<int> ValidateUser(LoginModel model);

        Task<int> AddUser(RegisterUserModel model);


    }
}
