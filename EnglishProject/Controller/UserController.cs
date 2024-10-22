using EnglishProject.Data.DTOs;
using EnglishProject.Service.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {

            var data = _userService.GetUserById(id);
            return Ok(data);
        }
        [HttpGet("GetByUsername/{Username}")]
        public IActionResult GetByUserName(string Username)
        {

            var data = _userService.GetUserByUserName(Username);
            return Ok(data);
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(UserLoginDto userEntity)
        {
           var apiKullanici = _userService.Login(userEntity);
           return Ok(apiKullanici);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _userService.GetAllUsers();
            return Ok(data);
        }
        [AllowAnonymous]
        [HttpPost("Create")]
        public IActionResult Add(PostUserDto user)
        {
             _userService.AddUser(user);
            return Ok();
        }

    }
}
