using System;
using System.Threading;

namespace HydraOS.GRUB
{
    public static class GrubEntryAnimator
    {
        public static void Animate(string entry)
        {
            string[] states = { "INITIALIZING", "CHECKING", "READY" };

            Console.Write($" > {entry} ");

            foreach (var state in states)
            {
                Console.Write($".{state}");
                Thread.Sleep(180);
                Console.Write("\r");
                Console.Write($" > {entry} ");
            }

            Console.WriteLine("........ READY");
        }
    }
}
