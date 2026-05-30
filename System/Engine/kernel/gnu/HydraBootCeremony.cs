using System;
using System.Collections.Generic;

namespace HydraOS.Kernel
{
    public static class HydraBootCeremony
    {
        // ============================================================
        // 1) VERSÃO ORIGINAL (Console) — NÃO MEXER
        // ============================================================
        public static void Run(HydraDesktopBounds bounds, string mode)
        {
            Console.Clear();

            int centerY = bounds.TerminalRows / 3;

            string[] logo =
            {
                "                                   .::!!!!!!!:.",
                "  .!!!!!:.                        .:!!!!!!!!!!!!",
                "  ~~~~!!!!!!.                 .:!!!!!!!!!UWWW$$$",
                "      :$$NWX!!:           .:!!!!!!XUWW$$$$$$$$$P",
                "      $$$$$##WX!:      .<!!!!UW$$$$\"  $$$$$$$$#",
                "      $$$$$  $$$UX   :!!UW$$$$$$$$$   4$$$$$*",
                "      ^$$$B  $$$$\\     $$$$$$$$$$$$   d$$R\"",
                "        \"*$bd$$$$      '*$$$$$$$$$$$o+#\"",
                "             \"\"\"\"          \"\"\"\"\"\"\""
            };

            int centerX = (bounds.TerminalCols / 2);

            foreach (var line in logo)
            {
                int pad = centerX - (line.Length / 2);
                if (pad < 0) pad = 0;
                Console.SetCursorPosition(pad, centerY++);
                Console.WriteLine(line);
            }

            string quote = "Nothing is lost, everything is transformed.";
            int qPad = centerX - (quote.Length / 2);
            Console.SetCursorPosition(qPad, centerY + 1);
            Console.WriteLine(quote);

            string modeLine = $"HydraOS Mode: {mode}";
            int mPad = centerX - (modeLine.Length / 2);
            Console.SetCursorPosition(mPad, centerY + 3);
            Console.WriteLine(modeLine);

            Thread.Sleep(1500);
        }

        // ============================================================
        // 2) VERSÃO TEXTUAL (para HydraDummyTerminal)
        // ============================================================
        public static string[] GetBootCeremonyText(string mode)
        {
            List<string> lines = new();

            lines.AddRange(new[]
            {
                "                                   .::!!!!!!!:.",
                "  .!!!!!:.                        .:!!!!!!!!!!!!",
                "  ~~~~!!!!!!.                 .:!!!!!!!!!UWWW$$$",
                "      :$$NWX!!:           .:!!!!!!XUWW$$$$$$$$$P",
                "      $$$$$##WX!:      .<!!!!UW$$$$\"  $$$$$$$$#",
                "      $$$$$  $$$UX   :!!UW$$$$$$$$$   4$$$$$*",
                "      ^$$$B  $$$$\\     $$$$$$$$$$$$   d$$R\"",
                "        \"*$bd$$$$      '*$$$$$$$$$$$o+#\"",
                "             \"\"\"\"          \"\"\"\"\"\"\""
            });

            lines.Add("");
            lines.Add("Nothing is lost, everything is transformed.");
            lines.Add("");
            lines.Add($"HydraOS Mode: {mode}");
            lines.Add("");

            return lines.ToArray();
        }
    }
}
