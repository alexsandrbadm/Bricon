// Decompiled with JetBrains decompiler
// Type: BriconLib.PrintManager.DescriptionForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BriconLib.PrintManager
{
  public class DescriptionForm : Form
  {
    private IContainer components;
    private Button buttonOK;
    private Button buttonCancel;
    private Label label1;
    internal TextBox textBoxDescription;

    public DescriptionForm() => this.InitializeComponent();

    private void buttonOK_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DescriptionForm));
      this.buttonOK = new Button();
      this.buttonCancel = new Button();
      this.label1 = new Label();
      this.textBoxDescription = new TextBox();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.buttonOK, "buttonOK");
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      componentResourceManager.ApplyResources((object) this.buttonCancel, "buttonCancel");
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      componentResourceManager.ApplyResources((object) this.textBoxDescription, "textBoxDescription");
      this.textBoxDescription.Name = "textBoxDescription";
      this.AcceptButton = (IButtonControl) this.buttonOK;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonCancel;
      this.Controls.Add((Control) this.textBoxDescription);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonOK);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (DescriptionForm);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
