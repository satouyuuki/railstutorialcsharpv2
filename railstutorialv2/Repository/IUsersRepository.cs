using System;
using railstutorialv2.Models;
using railstutorialv2.ViewModels;

namespace railstutorialv2.Repository;

public interface IUsersRepository
{
    Task<List<User>> GetUsersAsync();
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetUserByEmailAsync(string email);
    //Task<TodosContainer> GetTodosAndCountAsync();
    Task<int> SaveAsync(User newUser);
    Task<int> UpdateAsync(User updateUser);
    Task<int> DeleteAsync(int id);
}
