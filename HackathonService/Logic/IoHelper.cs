using System;
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

        public static string[] GetAllFiles(string path)
        {
            try
            {
                var list = new List<string>();
                list.AddRange(Directory.GetFiles(path));
                return list.ToArray();
            }
            catch (Exception e)
            {
                return new string[0];
            }

        }
    }
}