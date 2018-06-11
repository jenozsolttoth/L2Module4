using System.IO;
using System.Linq;

namespace HackathonService.Logic
{
    public class TeamRepository
    {
        private readonly string _taskPath;

        public TeamRepository(string taskPath)
        {
            _taskPath = taskPath;
        }

        public string[] GetAll()
        {
            return Directory.GetDirectories(_taskPath).ToArray();
        }

        public StoryboardRepository GetTeam(string teamId)
        {
            var teams = GetAll();
            var teamPath = teams.First(t => t.EndsWith(teamId));
            return new StoryboardRepository(teamPath);
        }
    }
}