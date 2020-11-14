// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.LoadingXtreme
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Communications;
using MultiLang;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BriconLib.UI
{
  public class LoadingXtreme : Form
  {
    private IContainer components;
    private Button buttonCancel;
    private Button buttonOK;
    private Label label1;
    private Label label2;
    private Label label3;

    public LoadingXtreme(string versionFrom, string versionTo)
    {
      this.InitializeComponent();
      if (CommunicationState.Instance.IsExtreme)
        this.label2.Text = string.Format(this.label2.Text, (object) versionFrom, (object) versionTo);
      else
        this.label2.Text = string.Format(ml.ml_string(1288, "There is new software available for this device, to install please follow the steps below or press cancel if you don't want to update now.\r\n\r\nStep 1\r\nDisconnect the power from the device\r\n\r\nStep 2\r\nPress and hold down the 'C' button on the device.\r\n\r\nStep 3\r\nReconnect the device with the USB cable\r\nThe screen will go blank \r\n\r\nStep 4\r\nRelease the 'C' button and press 'OK' to start the upgrade from {0} to {1}"), (object) versionFrom, (object) versionTo);
    }

    private void label3_Click(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (LoadingXtreme));
      this.buttonCancel = new Button();
      this.buttonOK = new Button();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.buttonCancel, "buttonCancel");
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.buttonOK, "buttonOK");
      this.buttonOK.DialogResult = DialogResult.OK;
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.ForeColor = Color.Red;
      this.label1.Name = "label1";
      componentResourceManager.ApplyResources((object) this.label2, "label2");
      this.label2.ForeColor = Color.Black;
      this.label2.Name = "label2";
      componentResourceManager.ApplyResources((object) this.label3, "label3");
      this.label3.ForeColor = Color.Red;
      this.label3.Name = "label3";
      this.label3.Click += new EventHandler(this.label3_Click);
      this.AcceptButton = (IButtonControl) this.buttonOK;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonCancel;
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonOK);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (LoadingXtreme);
      this.ShowIcon = false;
      this.TopMost = true;
      this.ResumeLayout(false);
    }
  }
}
