using System;
using System.Threading;

namespace HydraOS.GRUB
{
    public static class GrubFadeOut
    {
        public static void FadeOut(int durationMs = 900, int steps = 10)
        {
            int delay = durationMs / steps;

            for (int i = steps; i >= 0; i--)
            {
                double opacity = (double)i / steps;

                Console.WriteLine($"[GRUB] Fade-out opacity: {opacity:0.00}");
                Thread.Sleep(delay);
            }
        }
    }
}
