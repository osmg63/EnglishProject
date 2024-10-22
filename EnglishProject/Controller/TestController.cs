using EnglishProject.Data.DTOs;
using EnglishProject.Service.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnglishProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {
        private readonly TestService _testService;

        public TestController(TestService testService)
        {
            _testService = testService;
        }

        [HttpGet("GetTest")]
        public IActionResult GetTest()
           {


            var data = _testService.Test();
            return Ok(data);
        }
        [HttpGet("KnowTestCount")]
        public IActionResult KnowTestCount(int UserId)
        {


            var data = _testService.KnowTestCount(UserId);
            return Ok(data);
        }
        [HttpGet("NotKnowTestCount")]
        
        public IActionResult NotKnowTestCount(int UserId)
        {


            var data = _testService.NotKnowTestCount(UserId);
            return Ok(data);
        }
        [HttpPost("CreateTest")]
        public IActionResult AddTestTransaction(CreateTestRequestDto test)
        {
 
            var data = _testService.AddTest(test);
            return Ok(data);
        }



    }
}
