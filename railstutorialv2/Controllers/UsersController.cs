using System;
using Microsoft.AspNetCore.Mvc;
using railstutorialv2.Models;
using railstutorialv2.Repository;
using railstutorialv2.ViewModels;

namespace railstutorialv2.Controllers;

[Route("api")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;

    public UsersController(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        var result = await _usersRepository.GetUsersAsync();
        return Ok(result);
    }

    [HttpGet]
    [Route("[controller]/{id}")]
    public async Task<IActionResult> GetUserByIdAsync([FromRoute] int id)
    {
        var result = await _usersRepository.GetUserByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    [Route("signup")]
    public async Task<IActionResult> SaveAsync(UserViewModel viewModel)
    {
        var model = new User()
        {
            Name = viewModel.Name,
            Email = viewModel.Email,
            PasswordDigest = viewModel.PasswordDigest
        };
        model.Id = await _usersRepository.SaveAsync(model);
        if(model.Id != 0)
        {
            return Redirect($"/api/users/{model.Id}");
        }
        return Ok(model);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateAsync(User updateUser)
    {
        var result = await _usersRepository.UpdateAsync(updateUser);
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        var result = await _usersRepository.DeleteAsync(id);
        return Ok(result);
    }
}


