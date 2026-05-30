using System;
using System.IO;

namespace HydraOS.Kernel;

public class HydraDesktopBounds
{
    public int TerminalCols { get; private set; }
    public int TerminalRows { get; private set; }
    public int ScreenWidth { get; private set; }
    public int ScreenHeight { get; private set; }

    public bool HasFramebufferInfo { get; private set; }

    public HydraDesktopBounds()
    {
        DetectTerminalBounds();
        DetectFramebufferResolution();
    }

    private void DetectTerminalBounds()
    {
        try
        {
            TerminalCols = Console.WindowWidth;
            TerminalRows = Console.WindowHeight;
        }
        catch
        {
            TerminalCols = 80;
            TerminalRows = 24;
        }
    }

    private void DetectFramebufferResolution()
    {
        try
        {
            string fbPath = "/sys/class/graphics/fb0/virtual_size";

            if (File.Exists(fbPath))
            {
                var raw = File.ReadAllText(fbPath).Trim();
                var parts = raw.Split(',');

                ScreenWidth = int.Parse(parts[0]);
                ScreenHeight = int.Parse(parts[1]);

                HasFramebufferInfo = true;
                return;
            }
        }
        catch
        {
            // fallback
        }

        // fallback se não houver framebuffer
        ScreenWidth = TerminalCols * 8;   // aproximação
        ScreenHeight = TerminalRows * 16; // aproximação
        HasFramebufferInfo = false;
    }

    public override string ToString()
    {
        return $"Terminal: {TerminalCols}x{TerminalRows} | Screen: {ScreenWidth}x{ScreenHeight} | FB: {HasFramebufferInfo}";
    }
}
