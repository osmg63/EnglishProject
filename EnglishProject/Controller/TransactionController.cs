using EnglishProject.Data.DTOs;
using EnglishProject.Data.Entities;
using EnglishProject.Service.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnglishProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpPost("CreateTransaction")]
        public void Add(CreateTransactionDto transaction) {

            






            _transactionService.CreateTransaction(transaction);
        }


        [HttpGet("GetWordByUserId")]
        public IActionResult GetWords(int userId, string wordType) {
            var data=_transactionService.GetWords(userId, wordType);
            return Ok(data);
        }
        [HttpGet("GetWordKnowUser")]
        public IActionResult GetWordsUserKnow(int userId)
        {
            var data = _transactionService.GetWordsUserKnows(userId);
            return Ok(data);

        }
        [HttpGet("GetWordKnowUserCount")]
        public IActionResult GetWordsUserKnowCount(int userId)
        {
            var data=_transactionService.GetWordsUserNotKnowsCount(userId);
            return Ok(data);
        }
        [HttpGet("GetWordUserNotKnow")]
        public IActionResult GetWordsUserNotKnow(int userId)
        {
            var data= _transactionService.GetWordsUserNotKnows(userId);
            return Ok(data);
        }

    }
}
