using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using DarkMatter.Stimulsoft.Repository;
using Oqtane.Controllers;
using System.Net;

namespace DarkMatter.Stimulsoft.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class StimulsoftController : ModuleControllerBase
    {
        private readonly IStimulsoftRepository _StimulsoftRepository;

        public StimulsoftController(IStimulsoftRepository StimulsoftRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _StimulsoftRepository = StimulsoftRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.Stimulsoft> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && ModuleId == AuthEntityId(EntityNames.Module))
            {
                return _StimulsoftRepository.GetStimulsofts(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Stimulsoft Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.Stimulsoft Get(int id)
        {
            Models.Stimulsoft Stimulsoft = _StimulsoftRepository.GetStimulsoft(id);
            if (Stimulsoft != null && Stimulsoft.ModuleId == AuthEntityId(EntityNames.Module))
            {
                return Stimulsoft;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Stimulsoft Get Attempt {StimulsoftId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Stimulsoft Post([FromBody] Models.Stimulsoft Stimulsoft)
        {
            if (ModelState.IsValid && Stimulsoft.ModuleId == AuthEntityId(EntityNames.Module))
            {
                Stimulsoft = _StimulsoftRepository.AddStimulsoft(Stimulsoft);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Stimulsoft Added {Stimulsoft}", Stimulsoft);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Stimulsoft Post Attempt {Stimulsoft}", Stimulsoft);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                Stimulsoft = null;
            }
            return Stimulsoft;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Stimulsoft Put(int id, [FromBody] Models.Stimulsoft Stimulsoft)
        {
            if (ModelState.IsValid && Stimulsoft.ModuleId == AuthEntityId(EntityNames.Module) && _StimulsoftRepository.GetStimulsoft(Stimulsoft.StimulsoftId, false) != null)
            {
                Stimulsoft = _StimulsoftRepository.UpdateStimulsoft(Stimulsoft);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Stimulsoft Updated {Stimulsoft}", Stimulsoft);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Stimulsoft Put Attempt {Stimulsoft}", Stimulsoft);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                Stimulsoft = null;
            }
            return Stimulsoft;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.Stimulsoft Stimulsoft = _StimulsoftRepository.GetStimulsoft(id);
            if (Stimulsoft != null && Stimulsoft.ModuleId == AuthEntityId(EntityNames.Module))
            {
                _StimulsoftRepository.DeleteStimulsoft(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Stimulsoft Deleted {StimulsoftId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Stimulsoft Delete Attempt {StimulsoftId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
