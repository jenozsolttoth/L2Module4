using System.IO;
using System.Linq;

namespace HackathonService.Logic
{
    public class TaskRepository
    {
        private readonly string _challengePath;

        public TaskRepository(string challengePath)
        {
            _challengePath = challengePath;
        }

        public string[] GetAll()
        {
            return Directory.GetDirectories(_challengePath).ToArray();
        }

        public string[] GetAllTeams(string taskId)
        {
            var tasks = GetAll();
            var taskPath = tasks.First(t => t.EndsWith(taskId));
            return new TeamRepository(taskPath).GetAll();
        }

        public TeamRepository GetTask(string taskId)
        {
            var tasks = GetAll();
            var taskPath = tasks.First(t => t.EndsWith(taskId));
            return new TeamRepository(taskPath);
        }
    }
}