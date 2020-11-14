// Decompiled with JetBrains decompiler
// Type: BriconLib.PrintManager.AskWingmarkForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System.ComponentModel;
using System.Windows.Forms;

namespace BriconLib.PrintManager
{
  public class AskWingmarkForm : Form
  {
    private IContainer components;
    private Button buttonOK;
    public Label labelText;
    public TextBox textBoxWingmark;

    public AskWingmarkForm() => this.InitializeComponent();

    private void AskGummyForm_FormClosing(object sender, FormClosingEventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AskWingmarkForm));
      this.buttonOK = new Button();
      this.labelText = new Label();
      this.textBoxWingmark = new TextBox();
      this.SuspendLayout();
      this.buttonOK.DialogResult = DialogResult.OK;
      componentResourceManager.ApplyResources((object) this.buttonOK, "buttonOK");
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.labelText, "labelText");
      this.labelText.Name = "labelText";
      componentResourceManager.ApplyResources((object) this.textBoxWingmark, "textBoxWingmark");
      this.textBoxWingmark.Name = "textBoxWingmark";
      this.AcceptButton = (IButtonControl) this.buttonOK;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonOK;
      this.ControlBox = false;
      this.Controls.Add((Control) this.textBoxWingmark);
      this.Controls.Add((Control) this.labelText);
      this.Controls.Add((Control) this.buttonOK);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (AskWingmarkForm);
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
