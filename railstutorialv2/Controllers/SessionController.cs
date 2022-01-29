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
        [HttpGet]
        [Route("login")]
        public OkObjectResult New(LoginViewModel viewModel)
        {
            var email = viewModel.Email;
            //var user = await _usersRepository.GetUserByEmailAsync(email);
            //if(viewModel.Authenticate())
            //{

            //}

            return Ok("hello world");
        }

        [HttpPost]
        [Route("login")]
        public OkObjectResult Create()
        {
            return Ok("post!");
        }

        [HttpDelete]
        [Route("logout")]
        public OkObjectResult Destroy()
        {
            return Ok("delete");
        }
    }
}

