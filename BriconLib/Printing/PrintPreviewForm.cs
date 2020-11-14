// Decompiled with JetBrains decompiler
// Type: BriconLib.Printing.PrintPreviewForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BriconLib.Printing
{
  public class PrintPreviewForm : Form
  {
    private IContainer components;
    public ReportViewer reportViewer;

    public PrintPreviewForm() => this.InitializeComponent();

    private void PrintPreviewForm_Load(object sender, EventArgs e)
    {
      this.reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
      this.reportViewer.Visible = true;
    }

    private void PrintPreviewForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this.reportViewer == null)
        return;
      this.reportViewer.LocalReport.ReleaseSandboxAppDomain();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (PrintPreviewForm));
      this.reportViewer = new ReportViewer();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.reportViewer, "reportViewer");
      this.reportViewer.Name = "reportViewer";
      this.reportViewer.ShowBackButton = false;
      this.reportViewer.ShowDocumentMapButton = false;
      this.reportViewer.ShowFindControls = false;
      this.reportViewer.ShowRefreshButton = false;
      this.reportViewer.ShowStopButton = false;
      this.reportViewer.ZoomMode = ZoomMode.FullPage;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.reportViewer);
      this.Name = nameof (PrintPreviewForm);
      this.ShowInTaskbar = false;
      this.WindowState = FormWindowState.Maximized;
      this.FormClosing += new FormClosingEventHandler(this.PrintPreviewForm_FormClosing);
      this.Load += new EventHandler(this.PrintPreviewForm_Load);
      this.ResumeLayout(false);
    }
  }
}
