// Decompiled with JetBrains decompiler
// Type: BriconLib.BCE.SplashForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace BriconLib.BCE
{
  public class SplashForm : Form
  {
    private static bool _showit;
    private static Thread _thread;
    private IContainer components;
    private Label labelVersion;
    private Label label4;
    private Label label1;

    private SplashForm()
    {
      this.InitializeComponent();
      this.labelVersion.Text = string.Format(this.labelVersion.Text, (object) Assembly.GetEntryAssembly().GetName().Version.ToString());
    }

    public static void ShowSplash()
    {
      SplashForm._showit = true;
      SplashForm._thread = new Thread(new ThreadStart(SplashForm.DoSplash));
      if (Settings.Default.Language != "Auto")
        SplashForm._thread.CurrentUICulture = new CultureInfo(Settings.Default.Language);
      SplashForm._thread.Start();
    }

    public static void HideSplash() => SplashForm._showit = false;

    private static void DoSplash()
    {
      SplashForm splashForm = new SplashForm();
      splashForm.Show();
      splashForm.Refresh();
      do
        ;
      while (SplashForm._showit);
      splashForm.Close();
    }

    private void SplashForm_Click(object sender, EventArgs e) => this.Close();

    private void SplashForm_Load(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (SplashForm));
      this.labelVersion = new Label();
      this.label4 = new Label();
      this.label1 = new Label();
      this.SuspendLayout();
      this.labelVersion.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.labelVersion, "labelVersion");
      this.labelVersion.ForeColor = Color.White;
      this.labelVersion.Name = "labelVersion";
      componentResourceManager.ApplyResources((object) this.label4, "label4");
      this.label4.BackColor = Color.Transparent;
      this.label4.Name = "label4";
      this.label1.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.ForeColor = Color.White;
      this.label1.Name = "label1";
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.Navy;
      this.BackgroundImage = (Image) Resources.Splash;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.labelVersion);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (SplashForm);
      this.ShowInTaskbar = false;
      this.TransparencyKey = Color.DarkRed;
      this.Load += new EventHandler(this.SplashForm_Load);
      this.Click += new EventHandler(this.SplashForm_Click);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
