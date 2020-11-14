// Decompiled with JetBrains decompiler
// Type: BriconLib.PrintManager.EmailForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BriconLib.PrintManager
{
  public class EmailForm : Form
  {
    private IContainer components;
    private Button buttonCancel;
    private Button buttonOK;
    private TextBox textBox1;
    private Button button1;
    private Button button2;
    public CheckedListBox checkedListBox1;

    public EmailForm() => this.InitializeComponent();

    private void button1_Click(object sender, EventArgs e) => this.checkedListBox1.Items.Add((object) this.textBox1.Text, true);

    private void button2_Click(object sender, EventArgs e)
    {
      if (this.checkedListBox1.SelectedItem == null)
        return;
      this.checkedListBox1.Items.Remove(this.checkedListBox1.SelectedItem);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (EmailForm));
      this.checkedListBox1 = new CheckedListBox();
      this.buttonCancel = new Button();
      this.buttonOK = new Button();
      this.textBox1 = new TextBox();
      this.button1 = new Button();
      this.button2 = new Button();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.checkedListBox1, "checkedListBox1");
      this.checkedListBox1.FormattingEnabled = true;
      this.checkedListBox1.Name = "checkedListBox1";
      componentResourceManager.ApplyResources((object) this.buttonCancel, "buttonCancel");
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.buttonOK, "buttonOK");
      this.buttonOK.DialogResult = DialogResult.OK;
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.textBox1, "textBox1");
      this.textBox1.Name = "textBox1";
      componentResourceManager.ApplyResources((object) this.button1, "button1");
      this.button1.Name = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      componentResourceManager.ApplyResources((object) this.button2, "button2");
      this.button2.Name = "button2";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.AcceptButton = (IButtonControl) this.buttonOK;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonCancel;
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonOK);
      this.Controls.Add((Control) this.checkedListBox1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (EmailForm);
      this.ShowInTaskbar = false;
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
