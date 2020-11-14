// Decompiled with JetBrains decompiler
// Type: BriconLib.PrintManager.AskGummyForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using MultiLang;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace BriconLib.PrintManager
{
  public class AskGummyForm : Form
  {
    private IContainer components;
    private Button buttonOK;
    public Label labelText;
    public TextBox textBoxGummy;
    public Label labelTime;

    public AskGummyForm() => this.InitializeComponent();

    private void AskGummyForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (Utils.IsCountry("BE"))
      {
        string str = "";
        foreach (char c in this.textBoxGummy.Text)
        {
          if (char.IsDigit(c))
            str += c.ToString();
        }
        if (str.Length == 4)
          return;
        if (CultureInfo.CurrentUICulture.Name == "nl")
        {
          int num1 = (int) MessageBox.Show(ml.ml_string(1391, "Foutief formaat (4 cijfers)"));
        }
        else
        {
          int num2 = (int) MessageBox.Show(ml.ml_string(1392, "Format incorrect (4 chiffres)"));
        }
        e.Cancel = true;
      }
      else
      {
        if (!(this.textBoxGummy.Text == ""))
          return;
        int num = (int) MessageBox.Show(ml.ml_string(955, "Please fill in the gunny"));
        e.Cancel = true;
      }
    }

    private void buttonOK_Click(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AskGummyForm));
      this.buttonOK = new Button();
      this.labelText = new Label();
      this.textBoxGummy = new TextBox();
      this.labelTime = new Label();
      this.SuspendLayout();
      this.buttonOK.DialogResult = DialogResult.OK;
      componentResourceManager.ApplyResources((object) this.buttonOK, "buttonOK");
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
      componentResourceManager.ApplyResources((object) this.labelText, "labelText");
      this.labelText.Name = "labelText";
      componentResourceManager.ApplyResources((object) this.textBoxGummy, "textBoxGummy");
      this.textBoxGummy.Name = "textBoxGummy";
      componentResourceManager.ApplyResources((object) this.labelTime, "labelTime");
      this.labelTime.Name = "labelTime";
      this.AcceptButton = (IButtonControl) this.buttonOK;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonOK;
      this.ControlBox = false;
      this.Controls.Add((Control) this.labelTime);
      this.Controls.Add((Control) this.textBoxGummy);
      this.Controls.Add((Control) this.labelText);
      this.Controls.Add((Control) this.buttonOK);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (AskGummyForm);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.TopMost = true;
      this.FormClosing += new FormClosingEventHandler(this.AskGummyForm_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
