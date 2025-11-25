using System;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

// Assembly metadata - Discord bunları okur
[assembly: AssemblyTitle("VALORANT")]
[assembly: AssemblyProduct("VALORANT")]
[assembly: AssemblyDescription("VALORANT")]
[assembly: AssemblyCompany("Riot Games")]
[assembly: AssemblyVersion("1.0.0.0")]

namespace TaskbarApp
{
    public class MainForm : Form
    {
        private NotifyIcon trayIcon;
        
        public MainForm()
        {
            // Form ayarları - görünmez ama taskbar'da var
            this.Text = "VALORANT";
            this.Size = new Size(1, 1);
            this.Opacity = 0.0;  // Tamamen görünmez
            this.ShowInTaskbar = true;
            this.FormBorderStyle = FormBorderStyle.None;
            
            // Icon'u ayarla - logo.ico
            try
            {
                this.Icon = new Icon("logo.ico");
            }
            catch
            {
                MessageBox.Show("logo.ico bulunamadı!");
            }
            
            // Sistem tepsisi ikonu
            trayIcon = new NotifyIcon();
            trayIcon.Icon = this.Icon;
            trayIcon.Text = "VALORANT";
            trayIcon.Visible = true;
            
            // Sağ tıklama menüsü
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Uygulamayı Kapat", null, OnQuit);
            trayIcon.ContextMenuStrip = contextMenu;
            
            // Pencere kapatma olayı
            this.FormClosing += OnFormClosing;
        }
        
        private void OnQuit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            trayIcon.Dispose();
            Application.Exit();
        }
        
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            trayIcon.Visible = false;
            trayIcon.Dispose();
        }
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}

