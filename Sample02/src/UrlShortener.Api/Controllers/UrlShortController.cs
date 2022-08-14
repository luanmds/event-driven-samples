using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UrlShortened.Api.Domain.Commands;
using UrlShortened.Api.Domain.Queries;
using UrlShortened.Api.DTOs;
using UrlShortened.Api.Repository;

namespace UrlShortened.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlShortController : ControllerBase
    {
        private readonly ILogger<UrlShortController> _logger;
        private readonly GenerateURL _command;
        private readonly GetUrlGeneratedByIdQueryHandler _getUrlGeneratedByIdQueryHandler;
        private readonly GetOriginalUrlByCodeUrlQueryHandler _getOriginalUrlByCodeUrlQueryHandler;

        public UrlShortController(ILogger<UrlShortController> logger,
            GenerateURL command, 
            GetUrlGeneratedByIdQueryHandler getUrlGeneratedByIdQueryHandler,
            GetOriginalUrlByCodeUrlQueryHandler getOriginalUrlByCodeUrlQueryHandler)
        {
            _logger = logger;
            _command = command;
            _getUrlGeneratedByIdQueryHandler = getUrlGeneratedByIdQueryHandler;
            _getOriginalUrlByCodeUrlQueryHandler = getOriginalUrlByCodeUrlQueryHandler;
        }

        [HttpPost]
        public async Task<ActionResult<GetUrlGeneratedByIdQuery>> ShortenUrl([FromBody] OriginalUrlDTO dto)
        {
            // call command
            var id = await _command.Shorten(dto.url);
            // call query
            var query = await _getUrlGeneratedByIdQueryHandler.HandleAsync(id);
            return query;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetUrlShortenedData([FromQuery] string codeUrl)
        {
            var query = await _getOriginalUrlByCodeUrlQueryHandler.HandleAsync(codeUrl);
            return query.OriginalUrl;
        }
    }
}
