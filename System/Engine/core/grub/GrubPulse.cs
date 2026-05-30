using System;
using System.Threading;
using HydraOS.Core.Audio;

namespace HydraOS.GRUB
{
    public static class GrubPulse
    {
        public static void BootPulse(int cycles = 3, int speedMs = 120)
        {
            for (int c = 0; c < cycles; c++)
            {
                HydraSoundPlayer.Play("pulse"); // som sincronizado

                // Crescer
                for (int i = 0; i <= 4; i++)
                {
                    Console.WriteLine($"[GRUB] Logo pulse +{i}");
                    Thread.Sleep(speedMs);
                }

                // Recolher
                for (int i = 4; i >= 0; i--)
                {
                    Console.WriteLine($"[GRUB] Logo pulse -{i}");
                    Thread.Sleep(speedMs);
                }
            }
        }
    }
}
