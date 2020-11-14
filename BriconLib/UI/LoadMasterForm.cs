// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.LoadMasterForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Updater;
using MultiLang;
using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Forms;

namespace BriconLib.UI
{
  public class LoadMasterForm : Form
  {
    private bool _antennaInsteadOfMaster;
    private IContainer components;
    private Button buttonLoad;
    private ComboBox comboBox1;
    private Label label2;
    private Button buttonRefresh;
    private Button button1;
    private Label label3;
    private Label label1;
    private Label label4;
    private Label label5;

    public LoadMasterForm(bool antennaInsteadOfMaster)
    {
      this._antennaInsteadOfMaster = antennaInsteadOfMaster;
      this.InitializeComponent();
      this.buttonRefresh_Click((object) null, (EventArgs) null);
      if (!this._antennaInsteadOfMaster)
        return;
      this.label4.Visible = false;
      this.label5.Visible = false;
    }

    private void buttonRefresh_Click(object sender, EventArgs e)
    {
      this.comboBox1.Items.Clear();
      foreach (object portName in SerialPort.GetPortNames())
        this.comboBox1.Items.Add(portName);
    }

    private void button1_Click(object sender, EventArgs e) => this.Close();

    private void buttonLoad_Click(object sender, EventArgs e)
    {
      string str = "0";
      foreach (char c in this.comboBox1.Text.ToCharArray())
      {
        if (char.IsDigit(c))
          str += c.ToString();
      }
      int int32 = Convert.ToInt32(str);
      if (int32 < 1 || int32 > 20)
      {
        int num = (int) MessageBox.Show(ml.ml_string(340, "Invalid port"));
      }
      else
      {
        MasterUpdater.UpdateMaster(0, int32, (Form) this, this._antennaInsteadOfMaster);
        this.Close();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (LoadMasterForm));
      this.buttonLoad = new Button();
      this.comboBox1 = new ComboBox();
      this.label2 = new Label();
      this.buttonRefresh = new Button();
      this.button1 = new Button();
      this.label3 = new Label();
      this.label1 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.buttonLoad, "buttonLoad");
      this.buttonLoad.Name = "buttonLoad";
      this.buttonLoad.UseVisualStyleBackColor = true;
      this.buttonLoad.Click += new EventHandler(this.buttonLoad_Click);
      this.comboBox1.FormattingEnabled = true;
      componentResourceManager.ApplyResources((object) this.comboBox1, "comboBox1");
      this.comboBox1.Name = "comboBox1";
      componentResourceManager.ApplyResources((object) this.label2, "label2");
      this.label2.Name = "label2";
      componentResourceManager.ApplyResources((object) this.buttonRefresh, "buttonRefresh");
      this.buttonRefresh.Name = "buttonRefresh";
      this.buttonRefresh.UseVisualStyleBackColor = true;
      this.buttonRefresh.Click += new EventHandler(this.buttonRefresh_Click);
      componentResourceManager.ApplyResources((object) this.button1, "button1");
      this.button1.Name = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      componentResourceManager.ApplyResources((object) this.label3, "label3");
      this.label3.Name = "label3";
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      componentResourceManager.ApplyResources((object) this.label4, "label4");
      this.label4.Name = "label4";
      componentResourceManager.ApplyResources((object) this.label5, "label5");
      this.label5.Name = "label5";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.buttonRefresh);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.comboBox1);
      this.Controls.Add((Control) this.buttonLoad);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (LoadMasterForm);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
