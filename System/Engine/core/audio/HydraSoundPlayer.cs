using System;
using System.Diagnostics;
using System.IO;

namespace HydraOS.Core.Audio
{
    public static class HydraSoundPlayer
    {
        private static readonly string SoundsDir =
            "hydraos/core/grub/themes/hydra/sounds";

        public static void Play(string soundName)
        {
            string path = Path.Combine(SoundsDir, $"{soundName}.ogg");

            if (!File.Exists(path))
            {
                Console.WriteLine($"[HYDRA-AUDIO] Missing sound: {soundName}");
                return;
            }

            Console.WriteLine($"[HYDRA-AUDIO] Playing: {soundName}");

            var p = new Process();
            p.StartInfo.FileName = "ffplay";
            p.StartInfo.Arguments = $"-nodisp -autoexit \"{path}\"";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;

            p.Start();
            p.WaitForExit();
        }
    }
}
