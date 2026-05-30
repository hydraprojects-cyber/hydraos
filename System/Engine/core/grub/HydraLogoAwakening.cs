using System;
using System.Threading;

namespace HydraOS.GRUB
{
    public static class HydraLogoAwakening
    {
        public static void Run()
        {
            Console.WriteLine("[HYDRA-LOGO] Awakening sequence initiated...");

            string[] frames =
            {
                "█                    █",
                "██                  ██",
                "███                ███",
                "████              ████",
                "█████            █████",
                "██████          ██████",
                "███████        ███████",
                "████████      ████████",
                "█████████    █████████",
                "██████████  ██████████",
                "██████████████████████"
            };

            foreach (var f in frames)
            {
                Console.WriteLine(f);
                Thread.Sleep(60);
            }

            Console.WriteLine("[HYDRA-LOGO] Online.");
        }
    }
}
