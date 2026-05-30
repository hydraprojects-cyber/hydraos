using System;
using System.Threading;

namespace HydraOS.GRUB
{
    public static class GrubFade
    {
        public static void FadeIn(int durationMs = 1200, int steps = 12)
        {
            int delay = durationMs / steps;

            for (int i = 0; i <= steps; i++)
            {
                double opacity = (double)i / steps;

                Console.WriteLine($"[GRUB] Fade-in opacity: {opacity:0.00}");
                Thread.Sleep(delay);
            }
        }
    }
}
