using System;
using System.Diagnostics;
using System.IO;

namespace HydraLauncher
{
    public class HydraBootLauncher
    {
        private readonly string _hydraLocal;
        private readonly string _hydraConfig;
        private readonly string _hydraLogs;

        public HydraBootLauncher()
        {
            _hydraLocal = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "HydraLocal");

            _hydraConfig = Path.Combine(_hydraLocal, "HydraConfig");
            _hydraLogs = Path.Combine(_hydraLocal, "HydraLogs");
        }

        public void Run(string[] args)
        {
            Banner();
            EnsureDirectories();
            LoadDefaults();
            LaunchHydraTerminal();
        }

        private void Banner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("HydraLauncher v1");
            Console.WriteLine("----------------");
            Console.ResetColor();
        }

        private void EnsureDirectories()
        {
            Directory.CreateDirectory(_hydraLocal);
            Directory.CreateDirectory(_hydraConfig);
            Directory.CreateDirectory(_hydraLogs);
        }

        private void LoadDefaults()
        {
            var defaults = Path.Combine(_hydraConfig, "defaults.cfg");

            if (!File.Exists(defaults))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[HydraLauncher] No defaults.cfg found.");
                Console.WriteLine("Run hydra-system-analyzer.sh first.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"[HydraLauncher] Loaded defaults: {defaults}");
            }
        }

        private void LaunchHydraTerminal()
        {
            Console.WriteLine("[HydraLauncher] Launching HydraTerminal...");

            var repo = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "GitHub", "programs", "HydraDynamics", "hydraos");

            var psi = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = "run --project GNU/HydraTerminal",
                WorkingDirectory = repo,
                UseShellExecute = false
            };

            using var proc = Process.Start(psi);
            proc?.WaitForExit();

            Console.WriteLine("[HydraLauncher] HydraTerminal exited.");
        }
    }
}
