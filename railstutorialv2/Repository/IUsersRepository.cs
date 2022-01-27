using System;
using railstutorialv2.Models;

namespace railstutorialv2.Repository;

public interface IUsersRepository
{
    Task<List<User>> GetUsersAsync();
    Task<User> GetUserByIdAsync(int id);
    //Task<TodosContainer> GetTodosAndCountAsync();
    Task<int> SaveAsync(User newTodo);
    Task<int> UpdateAsync(User updateUser);
    Task<int> DeleteAsync(int id);
}
