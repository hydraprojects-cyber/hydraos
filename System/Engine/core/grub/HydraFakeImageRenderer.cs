using System;
using System.Threading;

namespace HydraOS.GRUB
{
    public static class HydraFakeImageRenderer
    {
        public static void Show(string imageName, int lines = 3, int width = 30)
        {
            Console.WriteLine($"[HYDRA-IMG] {imageName} loaded");

            string bar = new string('█', width);

            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine(bar);
                Thread.Sleep(80); // animação suave
            }
        }
    }
}
