using System;
using System.IO;
using System.Linq;
using System.Text;

namespace HackathonService.Logic
{
    // ReSharper disable All
    public class StoryboardRepository
    {
        private readonly string _teamPath;

        public StoryboardRepository(string teamPath)
        {
            _teamPath = teamPath;
        }

        public string GetSolution()
        {
            var path = Directory.GetFiles(_teamPath).Where(f => Path.GetFileName(f) == "sln.txt").FirstOrDefault();
            var file = new FileStream(path, FileMode.Open);
            var buffer = new Byte[file.Length];
            file.ReadAsync(buffer, 0, (int)file.Length);
            var reader = new StreamReader(file);
            return reader.ReadToEnd();
        }
    }
}