using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HackathonService.Logic;
using System.Diagnostics;

namespace HackathonService.Controllers
{
    // ReSharper disable All
    [Route("[controller]")]
    public class TeamController : ApiController
    {
        private readonly ITeamManager _teamManager;

        public TeamController()
        {
            _teamManager = new TeamManager();
        }

        [HttpGet]
        [Route("all")]
        public async Task<IHttpActionResult> List()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = _teamManager.AllAsync().Result;

            if (result == null)
                return NotFound();
            sw.Stop();
            var lastresult = result.ToList();
            lastresult.Add(sw.Elapsed.ToString());
            return Json(lastresult);
        }

        [HttpGet]
        [Route("{challenge}/{task}/{team}")]
        public async Task<IHttpActionResult> GetStoryboard(string challenge, string task, string team)
        {
            try
            {
                var result = _teamManager.GetAsync(challenge, task, team).Result;

                if (result == null)
                    return NotFound();

                return Json(result);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}