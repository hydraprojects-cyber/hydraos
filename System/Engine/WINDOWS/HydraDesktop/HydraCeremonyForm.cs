using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HydraDesktop.Windows;

public class HydraCeremonyForm : Form
{
    private float opacityLevel = 0f;
    private readonly string soundPath;

    public HydraCeremonyForm()
    {
        FormBorderStyle = FormBorderStyle.None;
        WindowState = FormWindowState.Maximized;
        BackColor = Color.Black;
        ForeColor = Color.White;
        ShowInTaskbar = false;
        DoubleBuffered = true;
        Cursor.Hide();

        Opacity = 0;

        // Caminho base dos sons HydraLocal
        soundPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "HydraLocal", "HydraSounds");

        Paint += OnPaintCeremony;
    }

    protected override async void OnShown(EventArgs e)
    {
        base.OnShown(e);

        // BOOT SOUND
        //HydraSoundPlayer.Play(Path.Combine(soundPath, "boot.wav"));

        await FadeIn();

        await Task.Delay(2000);

        await FadeOut();

        Close();
    }

    private async Task FadeIn()
    {
        // PULSE SOUND
        //HydraSoundPlayer.Play(Path.Combine(soundPath, "pulse.wav"));

        while (opacityLevel < 1.0f)
        {
            opacityLevel += 0.05f;
            Opacity = opacityLevel;
            await Task.Delay(30);
        }
    }

    private async Task FadeOut()
    {
        // CHIME SOUND
       // HydraSoundPlayer.Play(Path.Combine(soundPath, "chime.wav"));

        while (opacityLevel > 0.0f)
        {
            opacityLevel -= 0.05f;
            Opacity = opacityLevel;
            await Task.Delay(30);
        }
    }

    private void OnPaintCeremony(object? sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        g.Clear(Color.Black);

        var font = new Font("Consolas", 22, FontStyle.Regular);
        string text = """
HydraOS Ritual Mode

Nothing is lost,
everything is transformed.
""";

        var size = g.MeasureString(text, font);
        float x = (ClientSize.Width - size.Width) / 2;
        float y = (ClientSize.Height - size.Height) / 2;

        g.DrawString(text, font, Brushes.White, x, y);
    }
}

