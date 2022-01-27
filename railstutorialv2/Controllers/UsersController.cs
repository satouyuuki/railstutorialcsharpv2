using System;
using Microsoft.AspNetCore.Mvc;
using railstutorialv2.Models;
using railstutorialv2.Repository;

namespace railstutorialv2.Controllers;

[Route("api/[controller]")]
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
    [Route("{id}")]
    public async Task<IActionResult> GetUserByIdAsync([FromRoute] int id)
    {
        var result = await _usersRepository.GetUserByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    [Route("save")]
    public async Task<IActionResult> SaveAsync(User newUser)
    {
        var result = await _usersRepository.SaveAsync(newUser);
        return Ok(result);
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


