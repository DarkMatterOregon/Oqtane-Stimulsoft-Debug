using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using DarkMatter.Stimtest.Repository;
using Oqtane.Controllers;
using System.Net;

namespace DarkMatter.Stimtest.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class StimtestController : ModuleControllerBase
    {
        private readonly IStimtestRepository _StimtestRepository;

        public StimtestController(IStimtestRepository StimtestRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _StimtestRepository = StimtestRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.Stimtest> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && ModuleId == AuthEntityId(EntityNames.Module))
            {
                return _StimtestRepository.GetStimtests(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Stimtest Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.Stimtest Get(int id)
        {
            Models.Stimtest Stimtest = _StimtestRepository.GetStimtest(id);
            if (Stimtest != null && Stimtest.ModuleId == AuthEntityId(EntityNames.Module))
            {
                return Stimtest;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Stimtest Get Attempt {StimtestId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Stimtest Post([FromBody] Models.Stimtest Stimtest)
        {
            if (ModelState.IsValid && Stimtest.ModuleId == AuthEntityId(EntityNames.Module))
            {
                Stimtest = _StimtestRepository.AddStimtest(Stimtest);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Stimtest Added {Stimtest}", Stimtest);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Stimtest Post Attempt {Stimtest}", Stimtest);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                Stimtest = null;
            }
            return Stimtest;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Stimtest Put(int id, [FromBody] Models.Stimtest Stimtest)
        {
            if (ModelState.IsValid && Stimtest.ModuleId == AuthEntityId(EntityNames.Module) && _StimtestRepository.GetStimtest(Stimtest.StimtestId, false) != null)
            {
                Stimtest = _StimtestRepository.UpdateStimtest(Stimtest);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Stimtest Updated {Stimtest}", Stimtest);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Stimtest Put Attempt {Stimtest}", Stimtest);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                Stimtest = null;
            }
            return Stimtest;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.Stimtest Stimtest = _StimtestRepository.GetStimtest(id);
            if (Stimtest != null && Stimtest.ModuleId == AuthEntityId(EntityNames.Module))
            {
                _StimtestRepository.DeleteStimtest(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Stimtest Deleted {StimtestId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Stimtest Delete Attempt {StimtestId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
