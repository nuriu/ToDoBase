using Couchbase.KeyValue;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ToDoBase.Core.Entities;
using ToDoBase.Core.Services;

namespace ToDoBase.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly ICouchbaseService _couchbaseService;

        public UserService(ICouchbaseService couchbaseService)
        {
            _couchbaseService = couchbaseService;
        }

        public async Task<bool> IsUserExists(string username)
        {
            var result = await _couchbaseService.UserCollection.ExistsAsync(
                $"user::{username}", new ExistsOptions());

            return result.Exists;
        }

        public async Task<User> CreateUser(string username, string password)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = username,
                Password = CalculateMd5Hash(password),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            try
            {
                await _couchbaseService.UserCollection.InsertAsync(
                    $"user::{username}", user, new InsertOptions());
            }
            catch
            {
                return null;
            }

            return user;
        }

        public async Task<User> GetUser(string username)
        {
            try
            {
                var result = await _couchbaseService.UserCollection.GetAsync(
                    $"user::{username}", new GetOptions());
                return result.ContentAs<User>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<User> GetAndAuthenticateUser(string username, string password)
        {
            var user = await GetUser(username);

            if (user == null || user.Password != CalculateMd5Hash(password))
                return null;

            return user;
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                await _couchbaseService.UserCollection.ReplaceAsync(
                    $"user::{user.Username}", user, new ReplaceOptions());
            }
            catch
            {
                return false;
            }

            return true;
        }

        private static string CalculateMd5Hash(string password)
        {
            using var md5 = MD5.Create();
            var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return string.Concat(bytes.Select(x => x.ToString("x2")));
        }
    }
}
