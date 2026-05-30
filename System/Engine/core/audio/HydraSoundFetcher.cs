using System;
using System.Diagnostics;
using System.IO;

namespace HydraOS.Core.Audio
{
    public static class HydraSoundFetcher
    {
        private static readonly string SoundsDir =
            "hydraos/core/grub/themes/hydra/sounds";

        public static void Fetch(string url, string outputName)
        {
            Directory.CreateDirectory(SoundsDir);

            string tempFile = Path.Combine(SoundsDir, "temp_audio");
            string finalFile = Path.Combine(SoundsDir, $"{outputName}.ogg");

            Console.WriteLine($"[HYDRA-AUDIO] Downloading: {url}");

            Run("yt-dlp", $"-o \"{tempFile}.%(ext)s\" -f bestaudio {url}");

            Console.WriteLine("[HYDRA-AUDIO] Converting to OGG...");

            Run("ffmpeg", $"-y -i \"{tempFile}.webm\" -vn -acodec libvorbis \"{finalFile}\"");

            Console.WriteLine($"[HYDRA-AUDIO] Saved: {finalFile}");

            CleanupTempFiles();
        }

        private static void Run(string cmd, string args)
        {
            var p = new Process();
            p.StartInfo.FileName = cmd;
            p.StartInfo.Arguments = args;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;

            p.Start();
            p.WaitForExit();
        }

        private static void CleanupTempFiles()
        {
            foreach (var file in Directory.GetFiles(SoundsDir, "temp_audio*"))
                File.Delete(file);
        }
    }
}
