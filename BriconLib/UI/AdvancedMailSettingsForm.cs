// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.AdvancedMailSettingsForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using BriconLib.Properties;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BriconLib.UI
{
  public class AdvancedMailSettingsForm : Form
  {
    private IContainer components;
    private TextBox textBox4;
    private Label label8;
    private Label label1;
    private NumericUpDown numericUpDownPort;
    private CheckBox checkBox1;
    private Button button1;
    private Label label2;
    private TextBox textBox1;
    private TextBox textBox2;
    private Label label3;
    private TextBox textBox3;
    private Label label4;
    private TextBox textBox5;
    private Label label5;
    private Button button2;
    private Button button3;
    private Button button4;
    private Button button5;

    public AdvancedMailSettingsForm() => this.InitializeComponent();

    private void button1_Click(object sender, EventArgs e) => this.Close();

    private void button3_Click(object sender, EventArgs e)
    {
      Settings.Default.OutMailServer = "out.telenet.be";
      Settings.Default.EmailFromName = "Printmanager";
      Settings.Default.EmailFromAddress = "Printmanager@bricon.be";
      Settings.Default.EmailServerPort = 25M;
      Settings.Default.EmailUseSSL = false;
      Settings.Default.EmailUser = "";
      Settings.Default.EmailPWD = "";
    }

    private void button2_Click(object sender, EventArgs e)
    {
      Settings.Default.OutMailServer = "smtp.gmail.com";
      Settings.Default.EmailFromName = "Printmanager";
      Settings.Default.EmailFromAddress = "youraccount@gmail.com";
      Settings.Default.EmailServerPort = 587M;
      Settings.Default.EmailUseSSL = true;
      Settings.Default.EmailUser = "youraccount@gmail.com";
      Settings.Default.EmailPWD = "yourpassword";
    }

    private void button4_Click(object sender, EventArgs e)
    {
      Settings.Default.OutMailServer = "relay.belgacom.net";
      Settings.Default.EmailFromName = "Printmanager";
      Settings.Default.EmailFromAddress = "Printmanager@bricon.be";
      Settings.Default.EmailServerPort = 25M;
      Settings.Default.EmailUseSSL = false;
      Settings.Default.EmailUser = "";
      Settings.Default.EmailPWD = "";
    }

    private void button5_Click(object sender, EventArgs e) => EmailHelper.SendTestmail();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AdvancedMailSettingsForm));
      this.label8 = new Label();
      this.label1 = new Label();
      this.numericUpDownPort = new NumericUpDown();
      this.textBox4 = new TextBox();
      this.checkBox1 = new CheckBox();
      this.button1 = new Button();
      this.label2 = new Label();
      this.textBox1 = new TextBox();
      this.textBox2 = new TextBox();
      this.label3 = new Label();
      this.textBox3 = new TextBox();
      this.label4 = new Label();
      this.textBox5 = new TextBox();
      this.label5 = new Label();
      this.button2 = new Button();
      this.button3 = new Button();
      this.button4 = new Button();
      this.button5 = new Button();
      this.numericUpDownPort.BeginInit();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.label8, "label8");
      this.label8.Name = "label8";
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      this.numericUpDownPort.DataBindings.Add(new Binding("Value", (object) Settings.Default, "EmailServerPort", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.numericUpDownPort, "numericUpDownPort");
      this.numericUpDownPort.Maximum = new Decimal(new int[4]
      {
        999999,
        0,
        0,
        0
      });
      this.numericUpDownPort.Name = "numericUpDownPort";
      this.numericUpDownPort.Value = Settings.Default.EmailServerPort;
      this.textBox4.DataBindings.Add(new Binding("Text", (object) Settings.Default, "OutMailServer", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBox4, "textBox4");
      this.textBox4.Name = "textBox4";
      this.textBox4.Text = Settings.Default.OutMailServer;
      componentResourceManager.ApplyResources((object) this.checkBox1, "checkBox1");
      this.checkBox1.Checked = Settings.Default.EmailUseSSL;
      this.checkBox1.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "EmailUseSSL", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.button1, "button1");
      this.button1.Name = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      componentResourceManager.ApplyResources((object) this.label2, "label2");
      this.label2.Name = "label2";
      this.textBox1.DataBindings.Add(new Binding("Text", (object) Settings.Default, "EmailUser", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBox1, "textBox1");
      this.textBox1.Name = "textBox1";
      this.textBox1.Text = Settings.Default.EmailUser;
      this.textBox2.DataBindings.Add(new Binding("Text", (object) Settings.Default, "EmailPWD", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBox2, "textBox2");
      this.textBox2.Name = "textBox2";
      this.textBox2.Text = Settings.Default.EmailPWD;
      componentResourceManager.ApplyResources((object) this.label3, "label3");
      this.label3.Name = "label3";
      this.textBox3.DataBindings.Add(new Binding("Text", (object) Settings.Default, "EmailFromName", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBox3, "textBox3");
      this.textBox3.Name = "textBox3";
      this.textBox3.Text = Settings.Default.EmailFromName;
      componentResourceManager.ApplyResources((object) this.label4, "label4");
      this.label4.Name = "label4";
      this.textBox5.DataBindings.Add(new Binding("Text", (object) Settings.Default, "EmailFromAddress", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBox5, "textBox5");
      this.textBox5.Name = "textBox5";
      this.textBox5.Text = Settings.Default.EmailFromAddress;
      componentResourceManager.ApplyResources((object) this.label5, "label5");
      this.label5.Name = "label5";
      componentResourceManager.ApplyResources((object) this.button2, "button2");
      this.button2.Name = "button2";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      componentResourceManager.ApplyResources((object) this.button3, "button3");
      this.button3.Name = "button3";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.button3_Click);
      componentResourceManager.ApplyResources((object) this.button4, "button4");
      this.button4.Name = "button4";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new EventHandler(this.button4_Click);
      componentResourceManager.ApplyResources((object) this.button5, "button5");
      this.button5.Name = "button5";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new EventHandler(this.button5_Click);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button5);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.checkBox1);
      this.Controls.Add((Control) this.numericUpDownPort);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.textBox5);
      this.Controls.Add((Control) this.textBox3);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.textBox4);
      this.Controls.Add((Control) this.label8);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (AdvancedMailSettingsForm);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.numericUpDownPort.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
