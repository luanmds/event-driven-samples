using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UrlShortened.Api.Domain.Commands;
using UrlShortened.Api.Domain.Queries;
using UrlShortened.Api.Repository;

namespace UrlShortened.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlShortController : ControllerBase
    {
        private readonly ILogger<UrlShortController> _logger;
        private readonly GenerateURL _command;
        private readonly UrlGeneratedQueryHandler _queryHandler;

        public UrlShortController(ILogger<UrlShortController> logger,
            GenerateURL command, UrlGeneratedQueryHandler queryHandler)
        {
            _logger = logger;
            _command = command;
            _queryHandler = queryHandler;
        }

        [HttpPost]
        public async Task<IActionResult> ShortenUrl([FromBody] string url)
        {
            // call command
            var id = await _command.Shorten(url);
            // call query
            var query = _queryHandler.HandleAsync(id);
            return Ok(query);
        }
    }
}
