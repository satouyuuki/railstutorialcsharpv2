using System;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;
using railstutorialv2.Models;

namespace railstutorialv2.Repository;
public class UsersRepository: IUsersRepository
{
    private string myDbConnection = string.Empty;
    private IDbConnection Connection
    {
        get
        {
            return new MySqlConnection(myDbConnection);
        }
    }
    public UsersRepository(IConfiguration configuration)
    {
        myDbConnection = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<int> DeleteAsync(int id)
    {
        using (IDbConnection conn = Connection)
        {
            string command = "delete from users where Id = @Id";
            var result = await conn.ExecuteAsync(
                sql: command,
                param: new { id });
            return result;
        }
    }

    public async Task<List<User>> GetUsersAsync()
    {
        using (IDbConnection conn = Connection)
        {
            string query = "SELECT * FROM users";
            List<User> users = (await conn.QueryAsync<User>(sql: query))
                .ToList();
            return users;
        }
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        using (IDbConnection conn = Connection)
        {
            string query = "SELECT * FROM users WHERE Id = @id";
            User user = await conn.QueryFirstOrDefaultAsync<User>(
                sql: query,
                param: new { id });
            return user;
        }
    }

    public async Task<int> SaveAsync(User newTodo)
    {
        using (IDbConnection conn = Connection)
        {
            string command = @"
insert into users(Name, Email)
values(@Name, @Email)
";
            var result = await conn.ExecuteAsync(
                sql: command,
                param: newTodo);
            return result;
        }
    }

    public async Task<int> UpdateAsync(User updateUser)
    {
        using (IDbConnection conn = Connection)
        {
            string command = @"
update users set
Email = @Email,
Name = @Name
where Id = @Id";
            var result = await conn.ExecuteAsync(
                sql: command,
                param: updateUser);
            return result;
        }
    }
}


