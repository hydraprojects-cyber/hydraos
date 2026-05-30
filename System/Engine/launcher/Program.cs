using System;
using HydraLauncher;

namespace HydraLauncherEntry
{
    internal static class Program
    {
        public static int Main(string[] args)
        {
            Console.Title = "HydraLauncher";

            try
            {
                var launcher = new HydraBootLauncher();
                launcher.Run(args);
                return 0;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[HydraLauncher] Fatal error:");
                Console.ResetColor();
                Console.WriteLine(ex);
                return 1;
            }
        }
    }
}
