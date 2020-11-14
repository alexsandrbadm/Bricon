// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.CheckRingsForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Communications;
using BriconLib.Other;
using BriconLib.Properties;
using MultiLang;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BriconLib.UI
{
  public class CheckRingsForm : Form
  {
    private IContainer components;
    private Button buttonCancel;
    private Label label1;
    private Label label2;
    private TextBox textBoxClub;
    private GroupBox groupBox1;
    private ListBox listBoxRings;
    private Button buttonExport;
    private SaveFileDialog saveFileDialog1;

    public CheckRingsForm() => this.InitializeComponent();

    public void AddRing(CheckRingCommand cmd)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendFormat("{0};{1};{2};{3};{4}", (object) cmd.Ring, (object) cmd.Licence.ToString(), (object) this.textBoxClub.Text, (object) DateTime.Now.ToShortDateString(), (object) DateTime.Now.ToLongTimeString());
      this.listBoxRings.Items.Add((object) stringBuilder.ToString());
      this.groupBox1.Text = ml.ml_string(1095, "Rings read (") + this.listBoxRings.Items.Count.ToString() + ")";
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      CommunicationState.Instance.ReadingRing = false;
      if (!Settings.Default.AntenneWithoutMaster)
      {
        int num = (int) MessageBox.Show(ml.ml_string(210, "Please press <C> on the master for at least one second to activate the master again"), Defines.MessageBoxCaption);
      }
      CommunicationState.Instance.Modified = true;
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void buttonExport_Click(object sender, EventArgs e)
    {
      if (this.saveFileDialog1.ShowDialog() != DialogResult.OK)
        return;
      StringBuilder stringBuilder = new StringBuilder();
      using (StreamWriter streamWriter = new StreamWriter(this.saveFileDialog1.OpenFile()))
      {
        foreach (string str in this.listBoxRings.Items)
          streamWriter.WriteLine(str);
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (CheckRingsForm));
      this.buttonCancel = new Button();
      this.label1 = new Label();
      this.label2 = new Label();
      this.textBoxClub = new TextBox();
      this.groupBox1 = new GroupBox();
      this.listBoxRings = new ListBox();
      this.buttonExport = new Button();
      this.saveFileDialog1 = new SaveFileDialog();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.buttonCancel, "buttonCancel");
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.ForeColor = Color.Black;
      this.label1.Name = "label1";
      componentResourceManager.ApplyResources((object) this.label2, "label2");
      this.label2.Name = "label2";
      componentResourceManager.ApplyResources((object) this.textBoxClub, "textBoxClub");
      this.textBoxClub.Name = "textBoxClub";
      componentResourceManager.ApplyResources((object) this.groupBox1, "groupBox1");
      this.groupBox1.Controls.Add((Control) this.listBoxRings);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.TabStop = false;
      componentResourceManager.ApplyResources((object) this.listBoxRings, "listBoxRings");
      this.listBoxRings.FormattingEnabled = true;
      this.listBoxRings.Name = "listBoxRings";
      componentResourceManager.ApplyResources((object) this.buttonExport, "buttonExport");
      this.buttonExport.Name = "buttonExport";
      this.buttonExport.UseVisualStyleBackColor = true;
      this.buttonExport.Click += new EventHandler(this.buttonExport_Click);
      this.saveFileDialog1.DefaultExt = "csv";
      this.saveFileDialog1.FileName = Settings.Default.CheckRingsFileName;
      componentResourceManager.ApplyResources((object) this.saveFileDialog1, "saveFileDialog1");
      this.saveFileDialog1.InitialDirectory = Settings.Default.CheckRingsInitialDirectory;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonCancel;
      this.Controls.Add((Control) this.buttonExport);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.textBoxClub);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.buttonCancel);
      this.Name = nameof (CheckRingsForm);
      this.ShowInTaskbar = false;
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
