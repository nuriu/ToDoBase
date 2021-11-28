using System.Threading.Tasks;
using ToDoBase.Core.Entities;

namespace ToDoBase.Core.Services
{
    public interface IUserService
    {
        Task<bool> IsUserExists(string username);
        Task<User> CreateUser(string username, string password);
        Task<User> GetUser(string username);
        Task<User> GetAndAuthenticateUser(string username, string password);
        Task<bool> UpdateUser(User user);
    }
}
