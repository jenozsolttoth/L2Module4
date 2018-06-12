using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace HackathonService.Logic
{
    public class TeamManager : ITeamManager
    {
        public Task<string[]> AllAsync()
        {
            var allTeams = new List<string>();
            var folders = ChallengeRepository.GetFolders();
            foreach (var folder in folders)
            {
                var exists = allTeams.FirstOrDefault(t => t == Path.GetFileName(folder));
                if (exists == null) allTeams.Add(Path.GetFileName(folder));
            }
            return Task.FromResult(allTeams.ToArray());
        }

        public Task<string> GetAsync(string challengeId, string taskId, string teamId)
        {
            string result = null;
            try
            {
                result = new ChallengeRepository().GetSolutions().Result
                    .First(kvp => kvp.Key.EndsWith("\\" + challengeId + "\\" + taskId + "\\" + teamId)).Value;
            }
            catch (Exception ex)
            {
                var ioex = (IOException) ex;
            }
            return Task.FromResult(result);
        }
    }
}