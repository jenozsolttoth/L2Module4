using System.Collections.Generic;
using System.IO;

namespace HackathonService.Logic
{
    // ReSharper disable All
    internal class IoHelper
    {
        public static string[] GetAllItem(string path)
        {
            var list = new List<string>();
            try
            {
                foreach (var directory in Directory.GetDirectories(path))
                {
                    list.Add(directory);
                }
                foreach (var files in Directory.GetFiles(path))
                {
                    list.Add(files);
                }

                foreach (var directory in list.ToArray())
                {
                    list.AddRange(GetAllItem(directory));
                }
                return list.ToArray();
            }
            catch
            {
                return new string[0];
            }
        }
    }
}