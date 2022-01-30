using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using railstutorialv2.Repository;
using railstutorialv2.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace railstutorialv2.Controllers
{
    [Route("api")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public SessionController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        // GET: /<controller>/
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Create(LoginViewModel viewModel)
        {
            var email = viewModel.Email;
            var user = await _usersRepository.GetUserByEmailAsync(email);
            if (user.Authenticate(viewModel.Password))
            {
                return Redirect($"/api/users/{user.Id}");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("login")]
        public OkObjectResult New()
        {
            return Ok("new!");
        }

        [HttpDelete]
        [Route("logout")]
        public OkObjectResult Destroy()
        {
            return Ok("delete");
        }
    }
}

