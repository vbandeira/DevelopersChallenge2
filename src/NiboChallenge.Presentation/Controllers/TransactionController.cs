using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NiboChallenge.Application;
using NiboChallenge.Infrastructure.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NiboChallenge.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        ITransactionsService _transactionService;
        public TransactionController(ITransactionsService transactionService)
        {
            _transactionService = transactionService;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_transactionService.Get().OrderBy(x => x.DatePosted));
            }
            catch (Exception)
            {
                throw;
            }

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_transactionService.GetById(id).FirstOrDefault());
            }
            catch (Exception)
            {
                return NotFound(id);
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody] TransactionDTO[] transactions)
        {
            try
            {
                _transactionService.Add(transactions);
                return Created(nameof(Post), null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost, Route("CheckNewTransactions")]
        public IActionResult CheckNewTransactions([FromBody] TransactionDTO[] transactions)
        {
            try
            {
                IEnumerable<TransactionDTO> dbTransactions = _transactionService.Get();
                IEnumerable<TransactionDTO> newTransactions = transactions.Where(t => !dbTransactions.Contains(t));
                return Ok(newTransactions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
