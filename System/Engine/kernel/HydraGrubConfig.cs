using System;
using System.Collections.Generic;
using System.IO;

namespace HydraOS.Kernel
{
    public static class HydraGrubConfig
    {
        private static readonly string ConfigPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "HydraLocal/HydraConfig/hydra_grub.cfg");

        private static readonly Dictionary<string, string> Values = new();

        public static void Load()
        {
            if (!File.Exists(ConfigPath))
                return;

            foreach (var line in File.ReadAllLines(ConfigPath))
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                var parts = line.Split('=');
                if (parts.Length == 2)
                {
                    var key = parts[0].Trim();
                    var value = parts[1].Trim().Trim('"');
                    Values[key] = value;
                }
            }
        }

        public static string Get(string key, string fallback = "")
        {
            return Values.ContainsKey(key) ? Values[key] : fallback;
        }
    }
}
