using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HackathonService.Logic
{
    // ReSharper disable All
    public class ChallengeRepository
    {
        public string[] GetAll()
        {
            var codeBase = HttpContext.Current.Request.PhysicalApplicationPath;
            var appDirContent = IoHelper.GetAllItem(Path.GetDirectoryName(codeBase));
            var root = appDirContent.FirstOrDefault(a => a.EndsWith("App_Data"));
            return Directory.GetDirectories(root).ToArray();
        }

        public string[] GetAllTasks(string challengeId)
        {
            return new TaskRepository(challengeId).GetAll();
        }

        public TaskRepository GetChallenge(string challengeId)
        {
            var challenges = GetAll();
            var challengePath = challenges.First(t => t.EndsWith(challengeId));
            return new TaskRepository(challengePath);
        }

        public static List<string> GetFolders()
        {
            var result = new List<string>();
            var challengeRepository = new ChallengeRepository();
            var challenges = challengeRepository.GetAll();
            foreach (var challenge in challenges)
            {
                var taskRepository = new TaskRepository(challenge);
                var tasks = taskRepository.GetAll();
                foreach (var task in tasks)
                {
                    var teamRepository = new TeamRepository(task);
                    var teams = teamRepository.GetAll();
                    result.AddRange(teams);
                    //foreach (var team in teams)
                    //{
                    //    result.Add(team);
                    //}
                }
            }
            return result;
        }

        public async Task<Dictionary<string, string>> GetSolutions()
        {
            var folders = GetFolders();
            var result = new Dictionary<string, string>();
            foreach (var folder in folders)
            {
                result.Add(folder, new StoryboardRepository(folder).GetSolution());
            }

            return result;
        }

    }
}