using System;

namespace HydraOS.Kernel;

public static class HydraHostModeGnu
{
    public static string Detect()
    {
        long totalGB = DetectMemory();

        // Filosofia Hydra: adapta-se, não julga
        if (totalGB <= 1)
            return "ultra-light";   // PCs XP, netbooks, Raspberry Pi antigos

        if (totalGB <= 2)
            return "light";         // PCs modestos, 2GB

        if (totalGB <= 4)
            return "balanced";      // PCs normais, 3–4GB

        if (totalGB <= 8)
            return "performance";   // PCs decentes

        return "high-performance";  // máquinas modernas
    }

    private static long DetectMemory()
    {
        try
        {
            var lines = System.IO.File.ReadAllLines("/proc/meminfo");
            foreach (var line in lines)
            {
                if (line.StartsWith("MemTotal:"))
                {
                    var parts = line.Split(':')[1].Trim().Split(' ')[0];
                    long kb = long.Parse(parts);
                    return kb / 1024 / 1024;
                }
            }
        }
        catch
        {
            // fallback universal
            return 2; // assume 2GB se não conseguir ler
        }

        return 2;
    }
}
