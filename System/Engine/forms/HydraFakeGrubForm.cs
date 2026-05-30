using System;
using System.Drawing;
using System.Windows.Forms;
using HydraOS.Kernel;

namespace HydraOS.Forms
{
    public class HydraFakeGrubForm : Form
    {
        private ListBox grubMenu;
        private Label titleLabel;
        private Label timeoutLabel;
        private Timer bootTimer;
        private int timeout;

        public HydraFakeGrubForm()
        {
            HydraGrubConfig.Load();
            timeout = int.Parse(HydraGrubConfig.Get("HYDRA_GRUB_TIMEOUT", "5"));

            InitializeComponent();
            RenderMenu();
            StartCountdown();
        }

        private void InitializeComponent()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Black;
            this.ForeColor = Color.FromArgb(0, 174, 239);
            this.WindowState = FormWindowState.Maximized;
            this.Font = new Font("Consolas", 16, FontStyle.Regular);
            this.KeyPreview = true;

            titleLabel = new Label()
            {
                Text = "HydraOS Fake GRUB",
                ForeColor = Color.FromArgb(0, 174, 239),
                AutoSize = true,
                Location = new Point(50, 40),
                Font = new Font("Consolas", 22, FontStyle.Bold)
            };

            grubMenu = new ListBox()
            {
                Location = new Point(50, 120),
                Size = new Size(700, 350),
                BackColor = Color.Black,
                ForeColor = Color.FromArgb(0, 174, 239),
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Consolas", 20),
                ItemHeight = 40
            };

            timeoutLabel = new Label()
            {
                Text = "",
                ForeColor = Color.FromArgb(0, 174, 239),
                AutoSize = true,
                Location = new Point(50, 500),
                Font = new Font("Consolas", 16)
            };

            this.Controls.Add(titleLabel);
            this.Controls.Add(grubMenu);
            this.Controls.Add(timeoutLabel);

            this.KeyDown += HydraFakeGrubForm_KeyDown;
        }

        private void RenderMenu()
        {
            string defaultEntry = HydraGrubConfig.Get("HYDRA_GRUB_DEFAULT", "HydraOS");

            grubMenu.Items.Add(defaultEntry);
            grubMenu.Items.Add("HydraOS (Recovery Mode)");
            grubMenu.Items.Add("HydraOS (Terminal Mode)");

            grubMenu.SelectedIndex = 0;

            string hostMode = HydraGrubConfig.Get("HYDRA_GRUB_HOST_MODE", "balanced");
            titleLabel.Text = $"HydraOS Fake GRUB  •  Host Mode: {hostMode}";
        }

        private void StartCountdown()
        {
            bootTimer = new Timer();
            bootTimer.Interval = 1000;
            bootTimer.Tick += (s, e) =>
            {
                timeout--;
                timeoutLabel.Text = $"Booting in {timeout} seconds...";

                if (timeout <= 0)
                {
                    bootTimer.Stop();
                    BootSelected();
                }
            };
            bootTimer.Start();
        }

        private void BootSelected()
        {
            var ceremony = new HydraCeremonyForm();
            ceremony.Show();
            this.Hide();
        }

        private void HydraFakeGrubForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (grubMenu.SelectedIndex > 0)
                    grubMenu.SelectedIndex--;
            }

            if (e.KeyCode == Keys.Down)
            {
                if (grubMenu.SelectedIndex < grubMenu.Items.Count - 1)
                    grubMenu.SelectedIndex++;
            }

            if (e.KeyCode == Keys.Enter)
                BootSelected();

            if (e.KeyCode == Keys.Escape)
                Application.Exit();
        }
    }
}
