using System;
using System.IO;

namespace HydraOS.GRUB
{
    public static class GrubCeremony
    {
        /// <summary>
        /// Executa o ritual visual do GRUB antes de entregar ao SplashScreen.
        /// </summary>
        public static void Start()
        {
            // 1. Garantir que os assets existem (estágio anterior)
            GrubAssets.Ensure();

            // 2. Carregar tema
            LoadTheme();

            // 3. Renderizar fundo + logo (versão simbólica)
            RenderBackground();
            RenderLogo();

            // 4. Renderizar entradas de boot
            RenderEntries();

            // 5. Efeito de transição visual
            FadeIn();

            // 6. Entregar controlo ao SplashScreen
            TransitionToSplash();
        }

        private static void LoadTheme()
        {
            Console.WriteLine("[GRUB] Loading theme...");
            Console.WriteLine($"Background: {GrubTheme.BackgroundPath}");
            Console.WriteLine($"Logo: {GrubTheme.LogoPath}");
            Console.WriteLine($"Layout: {GrubTheme.Layout}");
        }

        private static void RenderBackground()
        {
            HydraFakeImageRenderer.Show("background.jpg");
        }

        private static void RenderLogo()
        {
            HydraFakeImageRenderer.Show("hydralogo.png", lines: 2, width: 20);
        }

        private static void RenderEntries()
        {
            Console.WriteLine("[GRUB] Rendering boot entries...");

            foreach (var entry in GrubConfig.BootEntries)
                GrubEntryAnimator.Animate(entry);
        }

        private static void FadeIn()
        {
            GrubPulse.BootPulse();
            GrubFade.FadeIn();
        }

        private static void TransitionToSplash()
        {
            Console.WriteLine("[GRUB] Preparing transition...");
            GrubFadeOut.FadeOut();
            Console.WriteLine("[GRUB] Transitioning to SplashScreen...");
        }
    }
}
