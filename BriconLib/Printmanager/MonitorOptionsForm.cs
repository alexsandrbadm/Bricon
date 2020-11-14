// Decompiled with JetBrains decompiler
// Type: BriconLib.PrintManager.MonitorOptionsForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.BriconWeb;
using BriconLib.Other;
using BriconLib.Properties;
using BriconLib.Sounds;
using BriconLib.UI;
using MultiLang;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace BriconLib.PrintManager
{
  public class MonitorOptionsForm : Form
  {
    private Decimal _oldPort;
    private IContainer components;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private Button buttonOK;
    private CheckBox checkboxEnableNetWorkPolling;
    private CheckBox checkBox1;
    private CheckBox checkBox2;
    private Label labelEmailSS;
    private TextBox textBox5;
    private CheckBox checkBox3;
    private Button buttonTestBW;
    private Label label6;
    private NumericUpDown numericUpDown1;
    private Button buttonEmailAdresses;
    private Button buttonEmailAdressesSignon;
    private LinkLabel linkLabelWebServer;
    private CheckBox checkBox4;
    private CheckBox checkBoxSendMonitor;
    private CheckBox checkBoxPigeonCloud;
    private Button button2;
    private CheckBox checkBoxShowTotalsPerCategory;
    private Label labelSound;
    private ComboBox comboBoxSound;
    private Button buttonSoundTest;
    private CheckBox checkBoxLoop;
    private CheckBox checkBox5;
    private CheckBox checkBoxCC;

    public MonitorOptionsForm()
    {
      this.InitializeComponent();
      this._oldPort = Settings.Default.WebServerPort;
      string selectedAlarmSound = Settings.Default.SelectedAlarmSound;
      this.comboBoxSound.DataSource = (object) new SoundManager().GetSounds();
      this.comboBoxSound.SelectedValue = (object) selectedAlarmSound;
      if (Utils.IsCountry("UK"))
      {
        this.checkBox2.Visible = false;
        this.checkBoxSendMonitor.Visible = false;
        this.checkBoxShowTotalsPerCategory.Visible = false;
      }
      this.checkBoxCC.Visible = Utils.IsCountry("NL");
    }

    private void buttonOK_Click(object sender, EventArgs e) => this.Close();

    private void MonitorOptionsForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (this._oldPort != Settings.Default.WebServerPort)
      {
        int num = (int) MessageBox.Show(ml.ml_string(1180, "Webserver port is changed, please restart the program to apply it"));
      }
      Settings.Default.Save();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (Settings.Default.LoginBriconWeb == "")
      {
        int num1 = (int) MessageBox.Show(ml.ml_string(1129, "Please fill in the login"));
      }
      else
      {
        if (!BriconWebHelper.TestConnection())
          return;
        int num2 = (int) MessageBox.Show(ml.ml_string(1130, "Test was successfull"));
      }
    }

    private void buttonEmailAdresses_Click(object sender, EventArgs e)
    {
      StringCollection stringCollection1;
      StringCollection stringCollection2;
      string str1;
      if (sender == this.buttonEmailAdresses)
      {
        stringCollection1 = Settings.Default.EmailAdresses;
        stringCollection2 = Settings.Default.EmailAdressesActive;
        str1 = Settings.Default.EmailAddress;
      }
      else
      {
        stringCollection1 = Settings.Default.EmailAdressesSignon;
        stringCollection2 = Settings.Default.EmailAdressesSignonActive;
        str1 = Settings.Default.EmailAddressSignon;
      }
      if (stringCollection1 == null)
        stringCollection1 = new StringCollection();
      if (stringCollection2 == null)
        stringCollection2 = new StringCollection();
      stringCollection2.Clear();
      string str2 = str1;
      char[] chArray = new char[3]{ ';', ' ', ',' };
      foreach (string str3 in str2.Split(chArray))
      {
        if (!stringCollection1.Contains(str3))
          stringCollection1.Add(str3);
        if (!stringCollection2.Contains(str3))
          stringCollection2.Add(str3);
      }
      EmailForm emailForm = new EmailForm();
      foreach (string str3 in stringCollection1)
        emailForm.checkedListBox1.Items.Add((object) str3, stringCollection2.Contains(str3));
      if (emailForm.ShowDialog() != DialogResult.OK)
        return;
      string str4 = "";
      stringCollection1.Clear();
      stringCollection2.Clear();
      foreach (object obj in (ListBox.ObjectCollection) emailForm.checkedListBox1.Items)
        stringCollection1.Add(obj as string);
      foreach (object checkedItem in emailForm.checkedListBox1.CheckedItems)
      {
        stringCollection2.Add(checkedItem as string);
        str4 = str4 + (checkedItem as string) + ";";
      }
      string str5 = str4.TrimEnd(';');
      if (sender == this.buttonEmailAdresses)
      {
        Settings.Default.EmailAdresses = stringCollection1;
        Settings.Default.EmailAdressesActive = stringCollection2;
        Settings.Default.EmailAddress = str5;
      }
      else
      {
        Settings.Default.EmailAdressesSignon = stringCollection1;
        Settings.Default.EmailAdressesSignonActive = stringCollection2;
        Settings.Default.EmailAddressSignon = str5;
      }
      Settings.Default.Save();
    }

    private static string GetIpAddress(string hostName)
    {
      foreach (IPAddress address in Dns.GetHostEntry(hostName).AddressList)
      {
        if (address.AddressFamily == AddressFamily.InterNetwork)
          return address.ToString();
      }
      return "";
    }

    private void MonitorOptionsForm_Load(object sender, EventArgs e)
    {
      this.numericUpDown1_ValueChanged(sender, e);
      if (!Utils.IsCountry("NL"))
        return;
      this.checkBoxPigeonCloud.Visible = true;
    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
      string ipAddress = MonitorOptionsForm.GetIpAddress(Dns.GetHostName());
      if (ipAddress != "")
        this.linkLabelWebServer.Text = "http://" + ipAddress.ToString() + ":" + this.numericUpDown1.Value.ToString() + "/";
      else
        this.linkLabelWebServer.Text = ml.ml_string(1276, "No ipaddress");
    }

    private void linkLabelWebServer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (this._oldPort != Settings.Default.WebServerPort)
      {
        int num = (int) MessageBox.Show(ml.ml_string(1181, "Webserver port is changed, please restart the program first"));
      }
      else
        Process.Start(this.linkLabelWebServer.Text);
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void label2_Click(object sender, EventArgs e)
    {
    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
    }

    private void button2_Click(object sender, EventArgs e)
    {
      int num = (int) new AdvancedMailSettingsForm().ShowDialog();
    }

    private void MonitorOptionsForm_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyValue != 68 || !e.Alt || (!e.Control || !e.Shift))
        return;
      this.checkBox1.Visible = !this.checkBox1.Visible;
    }

    private void buttonSoundTest_Click(object sender, EventArgs e)
    {
      if (this.buttonSoundTest.Text != "STOP")
      {
        if (this.checkBoxLoop.Checked)
          this.buttonSoundTest.Text = "STOP";
        new SoundManager().Play(this.comboBoxSound.SelectedValue as string, this.checkBoxLoop.Checked);
      }
      else
      {
        this.buttonSoundTest.Text = "Test";
        new SoundManager().Stop();
      }
    }

    private void comboBoxSound_SelectedIndexChanged(object sender, EventArgs e)
    {
      Settings.Default.SelectedAlarmSound = this.comboBoxSound.SelectedValue as string;
      if (Settings.Default.SelectedAlarmSound == "None" || string.IsNullOrWhiteSpace(Settings.Default.SelectedAlarmSound) || Settings.Default.SelectedAlarmSound == "Beep")
      {
        this.checkBoxLoop.Checked = false;
        this.checkBoxLoop.Visible = false;
      }
      else
        this.checkBoxLoop.Visible = true;
    }

    private void MonitorOptionsForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!Settings.Default.EmailAddressSignon.ToLower().Contains("@bricon") && !Settings.Default.EmailAddressSignon.ToLower().Contains("@pipa") && (!Settings.Default.EmailAddress.ToLower().Contains("@bricon") && !Settings.Default.EmailAddress.ToLower().Contains("@pipa")))
        return;
      int num = (int) MessageBox.Show(ml.ml_string(1275, "Please don't use @bricon or @pipa as email address, but use your own email address"));
      e.Cancel = true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MonitorOptionsForm));
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.buttonOK = new Button();
      this.labelEmailSS = new Label();
      this.buttonTestBW = new Button();
      this.label6 = new Label();
      this.buttonEmailAdresses = new Button();
      this.buttonEmailAdressesSignon = new Button();
      this.linkLabelWebServer = new LinkLabel();
      this.button2 = new Button();
      this.labelSound = new Label();
      this.comboBoxSound = new ComboBox();
      this.buttonSoundTest = new Button();
      this.checkBox5 = new CheckBox();
      this.checkBoxLoop = new CheckBox();
      this.checkBoxShowTotalsPerCategory = new CheckBox();
      this.checkBoxPigeonCloud = new CheckBox();
      this.numericUpDown1 = new NumericUpDown();
      this.checkBox4 = new CheckBox();
      this.checkBox3 = new CheckBox();
      this.checkBox2 = new CheckBox();
      this.checkBox1 = new CheckBox();
      this.checkBoxSendMonitor = new CheckBox();
      this.checkboxEnableNetWorkPolling = new CheckBox();
      this.textBox4 = new TextBox();
      this.textBox5 = new TextBox();
      this.textBox3 = new TextBox();
      this.textBox2 = new TextBox();
      this.textBox1 = new TextBox();
      this.checkBoxCC = new CheckBox();
      this.numericUpDown1.BeginInit();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      this.label1.Click += new EventHandler(this.label1_Click);
      componentResourceManager.ApplyResources((object) this.label2, "label2");
      this.label2.Name = "label2";
      this.label2.Click += new EventHandler(this.label2_Click);
      componentResourceManager.ApplyResources((object) this.label3, "label3");
      this.label3.Name = "label3";
      componentResourceManager.ApplyResources((object) this.label4, "label4");
      this.label4.Name = "label4";
      componentResourceManager.ApplyResources((object) this.buttonOK, "buttonOK");
      this.buttonOK.DialogResult = DialogResult.OK;
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
      componentResourceManager.ApplyResources((object) this.labelEmailSS, "labelEmailSS");
      this.labelEmailSS.Name = "labelEmailSS";
      componentResourceManager.ApplyResources((object) this.buttonTestBW, "buttonTestBW");
      this.buttonTestBW.Name = "buttonTestBW";
      this.buttonTestBW.UseVisualStyleBackColor = true;
      this.buttonTestBW.Click += new EventHandler(this.button1_Click);
      componentResourceManager.ApplyResources((object) this.label6, "label6");
      this.label6.Name = "label6";
      componentResourceManager.ApplyResources((object) this.buttonEmailAdresses, "buttonEmailAdresses");
      this.buttonEmailAdresses.Name = "buttonEmailAdresses";
      this.buttonEmailAdresses.UseVisualStyleBackColor = true;
      this.buttonEmailAdresses.Click += new EventHandler(this.buttonEmailAdresses_Click);
      componentResourceManager.ApplyResources((object) this.buttonEmailAdressesSignon, "buttonEmailAdressesSignon");
      this.buttonEmailAdressesSignon.Name = "buttonEmailAdressesSignon";
      this.buttonEmailAdressesSignon.UseVisualStyleBackColor = true;
      this.buttonEmailAdressesSignon.Click += new EventHandler(this.buttonEmailAdresses_Click);
      componentResourceManager.ApplyResources((object) this.linkLabelWebServer, "linkLabelWebServer");
      this.linkLabelWebServer.Name = "linkLabelWebServer";
      this.linkLabelWebServer.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabelWebServer_LinkClicked);
      componentResourceManager.ApplyResources((object) this.button2, "button2");
      this.button2.Name = "button2";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      componentResourceManager.ApplyResources((object) this.labelSound, "labelSound");
      this.labelSound.Name = "labelSound";
      this.comboBoxSound.DisplayMember = "Value";
      this.comboBoxSound.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxSound.FormattingEnabled = true;
      this.comboBoxSound.Items.AddRange(new object[4]
      {
        (object) componentResourceManager.GetString("comboBoxSound.Items"),
        (object) componentResourceManager.GetString("comboBoxSound.Items1"),
        (object) componentResourceManager.GetString("comboBoxSound.Items2"),
        (object) componentResourceManager.GetString("comboBoxSound.Items3")
      });
      componentResourceManager.ApplyResources((object) this.comboBoxSound, "comboBoxSound");
      this.comboBoxSound.Name = "comboBoxSound";
      this.comboBoxSound.ValueMember = "Key";
      this.comboBoxSound.SelectedIndexChanged += new EventHandler(this.comboBoxSound_SelectedIndexChanged);
      componentResourceManager.ApplyResources((object) this.buttonSoundTest, "buttonSoundTest");
      this.buttonSoundTest.Name = "buttonSoundTest";
      this.buttonSoundTest.UseVisualStyleBackColor = true;
      this.buttonSoundTest.Click += new EventHandler(this.buttonSoundTest_Click);
      componentResourceManager.ApplyResources((object) this.checkBox5, "checkBox5");
      this.checkBox5.Checked = Settings.Default.OnlyFirstSignon;
      this.checkBox5.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "OnlyFirstSignon", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBox5.Name = "checkBox5";
      this.checkBox5.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.checkBoxLoop, "checkBoxLoop");
      this.checkBoxLoop.Checked = Settings.Default.PlayAlarmInLoop;
      this.checkBoxLoop.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "PlayAlarmInLoop", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBoxLoop.Name = "checkBoxLoop";
      this.checkBoxLoop.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.checkBoxShowTotalsPerCategory, "checkBoxShowTotalsPerCategory");
      this.checkBoxShowTotalsPerCategory.Checked = Settings.Default.ShowTotalsPerCategory;
      this.checkBoxShowTotalsPerCategory.CheckState = CheckState.Checked;
      this.checkBoxShowTotalsPerCategory.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "ShowTotalsPerCategory", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBoxShowTotalsPerCategory.Name = "checkBoxShowTotalsPerCategory";
      this.checkBoxShowTotalsPerCategory.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.checkBoxPigeonCloud, "checkBoxPigeonCloud");
      this.checkBoxPigeonCloud.Checked = Settings.Default.SendToPigeonCloud;
      this.checkBoxPigeonCloud.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "SendToPigeonCloud", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBoxPigeonCloud.Name = "checkBoxPigeonCloud";
      this.checkBoxPigeonCloud.UseVisualStyleBackColor = true;
      this.numericUpDown1.DataBindings.Add(new Binding("Value", (object) Settings.Default, "WebServerPort", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.numericUpDown1, "numericUpDown1");
      this.numericUpDown1.Maximum = new Decimal(new int[4]
      {
        64000,
        0,
        0,
        0
      });
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Value = Settings.Default.WebServerPort;
      this.numericUpDown1.ValueChanged += new EventHandler(this.numericUpDown1_ValueChanged);
      componentResourceManager.ApplyResources((object) this.checkBox4, "checkBox4");
      this.checkBox4.Checked = Settings.Default.SendToOmar;
      this.checkBox4.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "SendToOmar", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBox4.Name = "checkBox4";
      this.checkBox4.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.checkBox3, "checkBox3");
      this.checkBox3.Checked = Settings.Default.SendToPitts;
      this.checkBox3.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "SendToPitts", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.checkBox2, "checkBox2");
      this.checkBox2.Checked = Settings.Default.SendToPipa;
      this.checkBox2.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "SendToPipa", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.checkBox1, "checkBox1");
      this.checkBox1.Checked = Settings.Default.BriconWebTestMode;
      this.checkBox1.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "BriconWebTestMode", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.checkBoxSendMonitor, "checkBoxSendMonitor");
      this.checkBoxSendMonitor.Checked = Settings.Default.SendMonitorDataToBW;
      this.checkBoxSendMonitor.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "SendMonitorDataToBW", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBoxSendMonitor.Name = "checkBoxSendMonitor";
      this.checkBoxSendMonitor.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.checkboxEnableNetWorkPolling, "checkboxEnableNetWorkPolling");
      this.checkboxEnableNetWorkPolling.Checked = Settings.Default.EnableNetWorkPolling;
      this.checkboxEnableNetWorkPolling.CheckState = CheckState.Checked;
      this.checkboxEnableNetWorkPolling.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "EnableNetWorkPolling", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkboxEnableNetWorkPolling.Name = "checkboxEnableNetWorkPolling";
      this.checkboxEnableNetWorkPolling.UseVisualStyleBackColor = true;
      this.textBox4.DataBindings.Add(new Binding("Text", (object) Settings.Default, "OutMailServer", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBox4, "textBox4");
      this.textBox4.Name = "textBox4";
      this.textBox4.Text = Settings.Default.OutMailServer;
      this.textBox5.DataBindings.Add(new Binding("Text", (object) Settings.Default, "EmailAddressSignon", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBox5, "textBox5");
      this.textBox5.Name = "textBox5";
      this.textBox5.Text = Settings.Default.EmailAddressSignon;
      this.textBox3.DataBindings.Add(new Binding("Text", (object) Settings.Default, "EmailAddress", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBox3, "textBox3");
      this.textBox3.Name = "textBox3";
      this.textBox3.Text = Settings.Default.EmailAddress;
      this.textBox2.DataBindings.Add(new Binding("Text", (object) Settings.Default, "PasswordBriconWeb", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBox2, "textBox2");
      this.textBox2.Name = "textBox2";
      this.textBox2.Text = Settings.Default.PasswordBriconWeb;
      this.textBox2.TextChanged += new EventHandler(this.textBox2_TextChanged);
      this.textBox1.DataBindings.Add(new Binding("Text", (object) Settings.Default, "LoginBriconWeb", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBox1, "textBox1");
      this.textBox1.Name = "textBox1";
      this.textBox1.Text = Settings.Default.LoginBriconWeb;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      componentResourceManager.ApplyResources((object) this.checkBoxCC, "checkBoxCC");
      this.checkBoxCC.Checked = Settings.Default.SendToCompuClub;
      this.checkBoxCC.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "SendToCompuClub", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBoxCC.Name = "checkBoxCC";
      this.checkBoxCC.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.buttonOK;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.checkBox5);
      this.Controls.Add((Control) this.checkBoxLoop);
      this.Controls.Add((Control) this.buttonSoundTest);
      this.Controls.Add((Control) this.comboBoxSound);
      this.Controls.Add((Control) this.labelSound);
      this.Controls.Add((Control) this.checkBoxShowTotalsPerCategory);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.checkBoxPigeonCloud);
      this.Controls.Add((Control) this.linkLabelWebServer);
      this.Controls.Add((Control) this.buttonEmailAdressesSignon);
      this.Controls.Add((Control) this.buttonEmailAdresses);
      this.Controls.Add((Control) this.numericUpDown1);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.buttonTestBW);
      this.Controls.Add((Control) this.checkBox4);
      this.Controls.Add((Control) this.checkBox3);
      this.Controls.Add((Control) this.checkBoxCC);
      this.Controls.Add((Control) this.checkBox2);
      this.Controls.Add((Control) this.checkBox1);
      this.Controls.Add((Control) this.checkBoxSendMonitor);
      this.Controls.Add((Control) this.checkboxEnableNetWorkPolling);
      this.Controls.Add((Control) this.buttonOK);
      this.Controls.Add((Control) this.textBox4);
      this.Controls.Add((Control) this.textBox5);
      this.Controls.Add((Control) this.textBox3);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.labelEmailSS);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (MonitorOptionsForm);
      this.ShowInTaskbar = false;
      this.FormClosing += new FormClosingEventHandler(this.MonitorOptionsForm_FormClosing);
      this.FormClosed += new FormClosedEventHandler(this.MonitorOptionsForm_FormClosed);
      this.Load += new EventHandler(this.MonitorOptionsForm_Load);
      this.KeyDown += new KeyEventHandler(this.MonitorOptionsForm_KeyDown);
      this.numericUpDown1.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
