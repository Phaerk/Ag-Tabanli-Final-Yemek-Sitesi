using Microsoft.EntityFrameworkCore;
using Delicious_Food_Recipes.Models;

namespace Delicious_Food_Recipes.Services.Contract
{
    public interface IUserService
    {
        // Method to get user
        Task<User> GetUser(string email, string key);

        //Method to save user
        Task<User> SaveUser(User model);
    }
}