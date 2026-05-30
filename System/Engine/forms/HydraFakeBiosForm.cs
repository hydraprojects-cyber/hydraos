using System;
using System.Drawing;
using System.Windows.Forms;
using HydraOS.Kernel;

namespace HydraOS.Forms
{
    public class HydraFakeBiosForm : Form
    {
        private Label headerLabel;
        private Label infoLabel;
        private Timer postTimer;
        private int seconds = 3;

        public HydraFakeBiosForm()
        {
            InitializeComponent();
            RenderInfo();
            StartPost();
        }

        private void InitializeComponent()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Black;
            this.ForeColor = Color.Lime;
            this.WindowState = FormWindowState.Maximized;
            this.Font = new Font("Consolas", 14, FontStyle.Regular);
            this.KeyPreview = true;

            headerLabel = new Label()
            {
                Text = "HydraOS Firmware v0.1 (Fake BIOS)",
                ForeColor = Color.Lime,
                AutoSize = true,
                Location = new Point(40, 40),
                Font = new Font("Consolas", 18, FontStyle.Bold)
            };

            infoLabel = new Label()
            {
                Text = "",
                ForeColor = Color.Lime,
                AutoSize = true,
                Location = new Point(40, 90)
            };

            this.Controls.Add(headerLabel);
            this.Controls.Add(infoLabel);

            this.KeyDown += HydraFakeBiosForm_KeyDown;
        }

        private void RenderInfo()
        {
            string hostMode = HydraHostMode.Detect();
            string text =
                $"CPU:   Detected by HydraHostMode\n" +
                $"RAM:   Classified as: {hostMode}\n" +
                $"GPU:   (simulated)\n\n" +
                $"Press F10 to continue, ESC to exit...\n";

            infoLabel.Text = text;
        }

        private void StartPost()
        {
            postTimer = new Timer();
            postTimer.Interval = 1000;
            postTimer.Tick += (s, e) =>
            {
                seconds--;
                if (seconds <= 0)
                {
                    postTimer.Stop();
                    GoToGrub();
                }
            };
            postTimer.Start();
        }

        private void GoToGrub()
        {
            var grub = new HydraFakeGrubForm();
            grub.Show();
            this.Hide();
        }

        private void HydraFakeBiosForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10 || e.KeyCode == Keys.Enter)
                GoToGrub();

            if (e.KeyCode == Keys.Escape)
                Application.Exit();
        }
    }
}
