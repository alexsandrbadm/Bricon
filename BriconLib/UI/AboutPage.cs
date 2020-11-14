// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.AboutPage
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Properties;
using MultiLang;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace BriconLib.UI
{
  public class AboutPage : UserControl
  {
    public static string Messages = string.Empty;
    private IContainer components;
    private Label labelVersion;
    private Label labelLibrary;
    private Label labelDeveloppedBy;
    private LinkLabel linkLabelWebSite;
    private Label labelCopyRight;
    private PictureBox pictureBox1;
    private TextBox textBox1;

    public AboutPage() => this.InitializeComponent();

    private void linkLabelWebSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start(ml.ml_string(166, "http://www.bricon.be"));

    private void AboutPage_Load(object sender, EventArgs e)
    {
      if (this.DesignMode)
        return;
      Assembly entryAssembly = Assembly.GetEntryAssembly();
      this.textBox1.Text = AboutPage.Messages;
      string str1 = string.Empty;
      string str2 = string.Empty;
      string str3 = string.Empty;
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      foreach (object customAttribute in entryAssembly.GetCustomAttributes(true))
      {
        if (customAttribute.GetType() == typeof (AssemblyCopyrightAttribute))
          str1 = ((AssemblyCopyrightAttribute) customAttribute).Copyright;
        if (customAttribute.GetType() == typeof (AssemblyCompanyAttribute))
          str2 = ((AssemblyCompanyAttribute) customAttribute).Company;
        if (customAttribute.GetType() == typeof (AssemblyTitleAttribute))
          str3 = ((AssemblyTitleAttribute) customAttribute).Title;
        if (customAttribute.GetType() == typeof (AssemblyProductAttribute))
        {
          string product = ((AssemblyProductAttribute) customAttribute).Product;
        }
        if (customAttribute.GetType() == typeof (AssemblyDescriptionAttribute))
        {
          string description = ((AssemblyDescriptionAttribute) customAttribute).Description;
        }
        if (customAttribute.GetType() == typeof (AssemblyVersionAttribute))
        {
          string version = ((AssemblyVersionAttribute) customAttribute).Version;
        }
      }
      this.Text = string.Format((IFormatProvider) CultureInfo.CurrentUICulture, this.Text, (object) str3);
      this.labelVersion.Text = string.Format((IFormatProvider) CultureInfo.CurrentUICulture, this.labelVersion.Text, (object) str3, (object) entryAssembly.GetName().Version.ToString());
      this.labelCopyRight.Text = string.Format((IFormatProvider) CultureInfo.CurrentUICulture, this.labelCopyRight.Text, (object) str1, (object) str2);
      Assembly executingAssembly = Assembly.GetExecutingAssembly();
      this.labelLibrary.Text = string.Format(this.labelLibrary.Text, (object) Path.GetFileName(executingAssembly.Location), (object) executingAssembly.GetName().Version);
    }

    private void AboutPage_Paint(object sender, PaintEventArgs e) => this.textBox1.Text = AboutPage.Messages;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AboutPage));
      this.labelVersion = new Label();
      this.labelLibrary = new Label();
      this.labelDeveloppedBy = new Label();
      this.linkLabelWebSite = new LinkLabel();
      this.labelCopyRight = new Label();
      this.pictureBox1 = new PictureBox();
      this.textBox1 = new TextBox();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.labelVersion, "labelVersion");
      this.labelVersion.Name = "labelVersion";
      componentResourceManager.ApplyResources((object) this.labelLibrary, "labelLibrary");
      this.labelLibrary.Name = "labelLibrary";
      componentResourceManager.ApplyResources((object) this.labelDeveloppedBy, "labelDeveloppedBy");
      this.labelDeveloppedBy.BackColor = Color.Transparent;
      this.labelDeveloppedBy.Name = "labelDeveloppedBy";
      componentResourceManager.ApplyResources((object) this.linkLabelWebSite, "linkLabelWebSite");
      this.linkLabelWebSite.Name = "linkLabelWebSite";
      this.linkLabelWebSite.TabStop = true;
      this.linkLabelWebSite.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabelWebSite_LinkClicked);
      componentResourceManager.ApplyResources((object) this.labelCopyRight, "labelCopyRight");
      this.labelCopyRight.Name = "labelCopyRight";
      this.pictureBox1.Image = (Image) Resources.Splash;
      componentResourceManager.ApplyResources((object) this.pictureBox1, "pictureBox1");
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.TabStop = false;
      this.textBox1.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      componentResourceManager.ApplyResources((object) this.textBox1, "textBox1");
      this.textBox1.Name = "textBox1";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.labelDeveloppedBy);
      this.Controls.Add((Control) this.labelVersion);
      this.Controls.Add((Control) this.labelLibrary);
      this.Controls.Add((Control) this.linkLabelWebSite);
      this.Controls.Add((Control) this.labelCopyRight);
      this.Controls.Add((Control) this.pictureBox1);
      this.Name = nameof (AboutPage);
      this.Load += new EventHandler(this.AboutPage_Load);
      this.Paint += new PaintEventHandler(this.AboutPage_Paint);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
