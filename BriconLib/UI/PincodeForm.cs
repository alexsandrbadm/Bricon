// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.PincodeForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using MultiLang;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BriconLib.UI
{
  public class PincodeForm : Form
  {
    private string _oldPincode;
    private IContainer components;
    private Label labelOldPincode;
    private TextBox textBoxOldPincode;
    private Label label2;
    private TextBox textBoxNewPincode;
    private Label label3;
    private TextBox textBoxNewPincode2;
    private Button buttonChange;
    private Button buttonCancel;
    private ErrorProvider errorProvider;

    public PincodeForm(string oldPincode)
    {
      this._oldPincode = oldPincode;
      this.InitializeComponent();
    }

    private void buttonCancel_Click(object sender, EventArgs e) => this.Close();

    public string Pincode => this.textBoxNewPincode2.Text;

    private void buttonChange_Click(object sender, EventArgs e)
    {
      bool flag = true;
      this.errorProvider.Clear();
      if (!this._oldPincode.Equals("999999") && !this.textBoxOldPincode.Text.Equals(this._oldPincode))
      {
        this.errorProvider.SetError((Control) this.textBoxOldPincode, ml.ml_string(358, "Wrong pincode"));
        flag = false;
      }
      if (!Validation.Pincode(this.textBoxNewPincode.Text))
      {
        this.errorProvider.SetError((Control) this.textBoxNewPincode, ml.ml_string(359, "Invalid pincode"));
        flag = false;
      }
      if (!Validation.Pincode(this.textBoxNewPincode2.Text))
      {
        this.errorProvider.SetError((Control) this.textBoxNewPincode2, ml.ml_string(359, "Invalid pincode"));
        flag = false;
      }
      if (!this.textBoxNewPincode.Text.Equals(this.textBoxNewPincode2.Text))
      {
        this.errorProvider.SetError((Control) this.textBoxNewPincode, ml.ml_string(359, "Invalid pincode"));
        this.errorProvider.SetError((Control) this.textBoxNewPincode2, ml.ml_string(359, "Invalid pincode"));
        flag = false;
      }
      if (!flag)
        return;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void PincodeForm_Load(object sender, EventArgs e)
    {
      if (!this._oldPincode.Equals("999999"))
        return;
      this.textBoxOldPincode.Text = this._oldPincode;
      this.textBoxOldPincode.Enabled = false;
      this.textBoxOldPincode.ReadOnly = true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (PincodeForm));
      this.labelOldPincode = new Label();
      this.textBoxOldPincode = new TextBox();
      this.label2 = new Label();
      this.textBoxNewPincode = new TextBox();
      this.label3 = new Label();
      this.textBoxNewPincode2 = new TextBox();
      this.buttonChange = new Button();
      this.buttonCancel = new Button();
      this.errorProvider = new ErrorProvider(this.components);
      ((ISupportInitialize) this.errorProvider).BeginInit();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.labelOldPincode, "labelOldPincode");
      this.labelOldPincode.Name = "labelOldPincode";
      componentResourceManager.ApplyResources((object) this.textBoxOldPincode, "textBoxOldPincode");
      this.textBoxOldPincode.Name = "textBoxOldPincode";
      componentResourceManager.ApplyResources((object) this.label2, "label2");
      this.label2.Name = "label2";
      componentResourceManager.ApplyResources((object) this.textBoxNewPincode, "textBoxNewPincode");
      this.textBoxNewPincode.Name = "textBoxNewPincode";
      componentResourceManager.ApplyResources((object) this.label3, "label3");
      this.label3.Name = "label3";
      componentResourceManager.ApplyResources((object) this.textBoxNewPincode2, "textBoxNewPincode2");
      this.textBoxNewPincode2.Name = "textBoxNewPincode2";
      componentResourceManager.ApplyResources((object) this.buttonChange, "buttonChange");
      this.buttonChange.Name = "buttonChange";
      this.buttonChange.UseVisualStyleBackColor = true;
      this.buttonChange.Click += new EventHandler(this.buttonChange_Click);
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      componentResourceManager.ApplyResources((object) this.buttonCancel, "buttonCancel");
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      this.errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
      this.errorProvider.ContainerControl = (ContainerControl) this;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonCancel;
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonChange);
      this.Controls.Add((Control) this.textBoxNewPincode2);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.textBoxNewPincode);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.textBoxOldPincode);
      this.Controls.Add((Control) this.labelOldPincode);
      this.Name = nameof (PincodeForm);
      this.Load += new EventHandler(this.PincodeForm_Load);
      ((ISupportInitialize) this.errorProvider).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
