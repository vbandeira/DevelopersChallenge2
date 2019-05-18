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
        public IEnumerable<TransactionDTO> Get()
        {
            return _transactionService.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TransactionDTO GetById(string id)
        {
            return _transactionService.GetById(id).FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
