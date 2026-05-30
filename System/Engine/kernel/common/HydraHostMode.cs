using System;

namespace HydraOS.Kernel;

public static class HydraHostMode
{
    public static string Detect()
    {
        // Tenta ler memória real do Linux via /proc/meminfo
        try
        {
            var lines = System.IO.File.ReadAllLines("/proc/meminfo");
            foreach (var line in lines)
            {
                if (line.StartsWith("MemTotal:"))
                {
                    // Exemplo: "MemTotal:       2048000 kB"
                    var parts = line.Split(':')[1].Trim().Split(' ')[0];
                    long kb = long.Parse(parts);
                    long totalGB = kb / 1024 / 1024;

                    // Filosofia Hydra: não julgar hardware fraco
                    if (totalGB < 2)
                        return "ultra-light";     // máquinas antigas, XP-era, netbooks

                    if (totalGB < 4)
                        return "light";           // PCs modestos, 2–3GB

                    if (totalGB < 8)
                        return "balanced";        // PCs normais

                    return "high-performance";    // máquinas modernas
                }
            }
        }
        catch
        {
            // fallback universal
            return "balanced";
        }

        return "balanced";
    }
}
