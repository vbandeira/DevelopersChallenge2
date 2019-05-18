using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NiboChallenge.Application;
using NiboChallenge.Infrastructure.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NiboChallenge.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        private readonly IOFXMergerApplication _ofxApplication;

        public UploadController(IOFXMergerApplication ofxApplication)
        {
            _ofxApplication = ofxApplication;
        }

        // POST api/values
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Post()
        {
            try
            {
                IEnumerable<TransactionDTO> mergedTransactions = null;
                foreach (var file in Request.Form.Files)
                {
                    Stream fileStream = file.OpenReadStream();
                    mergedTransactions = _ofxApplication.ImportFiles(fileStream);
                }

                return Created(nameof(Post), mergedTransactions.OrderBy(t => t.DatePosted));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
