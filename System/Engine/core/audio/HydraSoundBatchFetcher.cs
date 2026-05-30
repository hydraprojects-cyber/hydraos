using System;
using System.IO;

namespace HydraOS.Core.Audio
{
    public static class HydraSoundBatchFetcher
    {
        private static readonly string DownloadList =
            "hydraos/core/audio/sounds_download.txt";

        public static void FetchAll()
        {
            if (!File.Exists(DownloadList))
            {
                Console.WriteLine("[HYDRA-AUDIO] sounds_download.txt not found.");
                return;
            }

            Console.WriteLine("[HYDRA-AUDIO] Reading sounds_download.txt...");

            foreach (var line in File.ReadAllLines(DownloadList))
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 2)
                    continue;

                string url = parts[0];
                string name = parts[1];

                Console.WriteLine($"[HYDRA-AUDIO] Processing: {name}");
                HydraSoundFetcher.Fetch(url, name);
            }

            Console.WriteLine("[HYDRA-AUDIO] All sounds processed.");
        }
    }
}
