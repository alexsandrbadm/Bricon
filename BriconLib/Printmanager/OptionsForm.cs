// Decompiled with JetBrains decompiler
// Type: BriconLib.PrintManager.OptionsForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.BriconWeb;
using BriconLib.Other;
using BriconLib.Properties;
using MultiLang;
using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Forms;

namespace BriconLib.PrintManager
{
  public class OptionsForm : Form
  {
    private IContainer components;
    private GroupBox groupBoxSerialPort;
    private ComboBox comboBoxPort;
    private Label label3;
    private GroupBox groupBoxLocalisation;
    private Label label2;
    private Label label1;
    private ComboBox comboBoxCountry;
    private ComboBox comboBoxLanguage;
    private GroupBox groupBoxAutomaticUpdates;
    private CheckBox checkBoxInstallAutomatically;
    private CheckBox checkBoxCheckForNewerVersion;
    private CheckBox checkBoxDownloadAutomatically;
    private Button buttonOK;
    private Button buttonCancel;
    private GroupBox groupBoxBC;
    private CheckBox checkBoxSendToBC;
    private Button buttonTest;
    private TextBox textBoxBCPassword;
    private TextBox textBoxBCUser;
    private Label labelBCPassword;
    private Label labelBCUser;

    public OptionsForm()
    {
      this.InitializeComponent();
      this.comboBoxLanguage.Items.Clear();
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem("Albanian", "sq"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem("Arabic (SA)", "ar-SA"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(743, "Bulgarian"), "bg"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(617, "Croatian"), "hr"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(151, "Czech"), "cs"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(155, "Dutch"), "nl"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(152, "English"), "en"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(153, "French"), "fr"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(535, "Greek"), "el"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(150, "German"), "de"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(156, "Hungarian"), "hu"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(511, "Japanese"), "ja"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(618, "Lithuanian"), "lt"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem("Morocan", "ar-MA"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(619, "Polish"), "pl"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(157, "Portuguese"), "pt"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(620, "Romanian"), "ro"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(1131, "Serbian"), "sr"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem("Russian", "ru"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(621, "Slovakia"), "sk"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(154, "Spanish"), "es"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(744, "Turkish"), "tr"));
      this.comboBoxLanguage.Items.Add((object) new OptionsForm.ComboBoxTextItem("Ukraine", "uk"));
      this.comboBoxCountry.Items.Clear();
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem("Albania", "AL"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(226, "Australia"), "AU"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(158, "Belgium"), "BE"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(745, "Bulgaria"), "BG"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(227, "Croatia"), "CR"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(228, "Spain"), "ES"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(982, "Finland"), "FI"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(161, "France"), "FR"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(159, "Germany"), "DE"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(536, "Greece"), "GR"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem("India", "IN"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem("Iran", "RN"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(750, "Iraq"), "IQ"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(229, "Hungary"), "HU"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(513, "Japan"), "JP"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(230, "Luxembourg"), "LU"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(984, "Moroco"), "MA"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(231, "Mexico"), "MX"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(160, "Netherlands"), "NL"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(232, "New Zealand"), "NZ"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(233, "Poland"), "PL"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(234, "Portugal"), "PT"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(235, "Saudi Arabia"), "KSA"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(1132, "Serbia"), "SR"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(236, "South Africa"), "SA"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(169, "Taiwan"), "TW"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(238, "Czech"), "CZ"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(237, "Turkey"), "TR"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(168, "United Kingdom/Ireland"), "UK"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(167, "United States"), "US"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(622, "Romania"), "RO"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem("Moldavia", "MD"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(1133, "Russia"), "RU"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(623, "Lithuania"), "LT"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(679, "Slovakia"), "SK"));
      this.comboBoxCountry.Items.Add((object) new OptionsForm.ComboBoxTextItem(ml.ml_string(624, "Ukraine"), "UA"));
      this.comboBoxLanguage.SelectedIndexChanged -= new EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
      this.comboBoxCountry.SelectedIndexChanged -= new EventHandler(this.comboBoxCountry_SelectedIndexChanged);
      this.comboBoxPort.SelectedIndexChanged -= new EventHandler(this.comboBoxPort_SelectedIndexChanged);
      this.comboBoxCountry.SelectedIndex = 2;
      this.comboBoxLanguage.SelectedIndex = 1;
      foreach (OptionsForm.ComboBoxTextItem comboBoxTextItem in this.comboBoxLanguage.Items)
      {
        if (comboBoxTextItem.Value == Settings.Default.Language)
          this.comboBoxLanguage.SelectedItem = (object) comboBoxTextItem;
      }
      foreach (OptionsForm.ComboBoxTextItem comboBoxTextItem in this.comboBoxCountry.Items)
      {
        if (comboBoxTextItem.Value == Settings.Default.Country)
          this.comboBoxCountry.SelectedItem = (object) comboBoxTextItem;
      }
      this.comboBoxPort.Items.Clear();
      this.comboBoxPort.Items.Add((object) "Auto");
      this.comboBoxPort.SelectedItem = (object) "Auto";
      foreach (string portName in SerialPort.GetPortNames())
      {
        this.comboBoxPort.Items.Add((object) portName);
        if (portName == Settings.Default.ComPort)
          this.comboBoxPort.SelectedItem = (object) portName;
      }
      this.comboBoxLanguage.SelectedIndexChanged += new EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
      this.comboBoxCountry.SelectedIndexChanged += new EventHandler(this.comboBoxCountry_SelectedIndexChanged);
      this.comboBoxPort.SelectedIndexChanged += new EventHandler(this.comboBoxPort_SelectedIndexChanged);
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e) => this.Close();

    private string CountryOrLanguageChanged(ComboBox comboBox, string currentSetting) => comboBox.SelectedItem is OptionsForm.ComboBoxTextItem selectedItem && currentSetting != selectedItem.Value ? selectedItem.Value : currentSetting;

    private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e) => Settings.Default.Country = this.CountryOrLanguageChanged(this.comboBoxCountry, Settings.Default.Country);

    private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
      Settings.Default.Language = this.CountryOrLanguageChanged(this.comboBoxLanguage, Settings.Default.Language);
      int num = (int) MessageBox.Show(ml.ml_string(165, "Please restart the program to apply the new language"), Defines.MessageBoxCaption);
    }

    private void comboBoxPort_SelectedIndexChanged(object sender, EventArgs e) => Settings.Default.ComPort = this.comboBoxPort.SelectedItem as string;

    private void buttonTest_Click(object sender, EventArgs e)
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

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (OptionsForm));
      this.groupBoxSerialPort = new GroupBox();
      this.comboBoxPort = new ComboBox();
      this.label3 = new Label();
      this.groupBoxLocalisation = new GroupBox();
      this.label2 = new Label();
      this.label1 = new Label();
      this.comboBoxCountry = new ComboBox();
      this.comboBoxLanguage = new ComboBox();
      this.groupBoxAutomaticUpdates = new GroupBox();
      this.checkBoxInstallAutomatically = new CheckBox();
      this.checkBoxCheckForNewerVersion = new CheckBox();
      this.checkBoxDownloadAutomatically = new CheckBox();
      this.buttonOK = new Button();
      this.buttonCancel = new Button();
      this.groupBoxBC = new GroupBox();
      this.buttonTest = new Button();
      this.textBoxBCPassword = new TextBox();
      this.textBoxBCUser = new TextBox();
      this.labelBCPassword = new Label();
      this.labelBCUser = new Label();
      this.checkBoxSendToBC = new CheckBox();
      this.groupBoxSerialPort.SuspendLayout();
      this.groupBoxLocalisation.SuspendLayout();
      this.groupBoxAutomaticUpdates.SuspendLayout();
      this.groupBoxBC.SuspendLayout();
      this.SuspendLayout();
      this.groupBoxSerialPort.Controls.Add((Control) this.comboBoxPort);
      this.groupBoxSerialPort.Controls.Add((Control) this.label3);
      componentResourceManager.ApplyResources((object) this.groupBoxSerialPort, "groupBoxSerialPort");
      this.groupBoxSerialPort.Name = "groupBoxSerialPort";
      this.groupBoxSerialPort.TabStop = false;
      this.comboBoxPort.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxPort.FormattingEnabled = true;
      componentResourceManager.ApplyResources((object) this.comboBoxPort, "comboBoxPort");
      this.comboBoxPort.Name = "comboBoxPort";
      this.comboBoxPort.SelectedIndexChanged += new EventHandler(this.comboBoxPort_SelectedIndexChanged);
      componentResourceManager.ApplyResources((object) this.label3, "label3");
      this.label3.Name = "label3";
      this.groupBoxLocalisation.Controls.Add((Control) this.label2);
      this.groupBoxLocalisation.Controls.Add((Control) this.label1);
      this.groupBoxLocalisation.Controls.Add((Control) this.comboBoxCountry);
      this.groupBoxLocalisation.Controls.Add((Control) this.comboBoxLanguage);
      componentResourceManager.ApplyResources((object) this.groupBoxLocalisation, "groupBoxLocalisation");
      this.groupBoxLocalisation.Name = "groupBoxLocalisation";
      this.groupBoxLocalisation.TabStop = false;
      componentResourceManager.ApplyResources((object) this.label2, "label2");
      this.label2.Name = "label2";
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      this.comboBoxCountry.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxCountry.FormattingEnabled = true;
      componentResourceManager.ApplyResources((object) this.comboBoxCountry, "comboBoxCountry");
      this.comboBoxCountry.Name = "comboBoxCountry";
      this.comboBoxCountry.SelectedIndexChanged += new EventHandler(this.comboBoxCountry_SelectedIndexChanged);
      this.comboBoxLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxLanguage.FormattingEnabled = true;
      componentResourceManager.ApplyResources((object) this.comboBoxLanguage, "comboBoxLanguage");
      this.comboBoxLanguage.Name = "comboBoxLanguage";
      this.comboBoxLanguage.SelectedIndexChanged += new EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
      this.groupBoxAutomaticUpdates.Controls.Add((Control) this.checkBoxInstallAutomatically);
      this.groupBoxAutomaticUpdates.Controls.Add((Control) this.checkBoxCheckForNewerVersion);
      this.groupBoxAutomaticUpdates.Controls.Add((Control) this.checkBoxDownloadAutomatically);
      componentResourceManager.ApplyResources((object) this.groupBoxAutomaticUpdates, "groupBoxAutomaticUpdates");
      this.groupBoxAutomaticUpdates.Name = "groupBoxAutomaticUpdates";
      this.groupBoxAutomaticUpdates.TabStop = false;
      componentResourceManager.ApplyResources((object) this.checkBoxInstallAutomatically, "checkBoxInstallAutomatically");
      this.checkBoxInstallAutomatically.Checked = Settings.Default.InstallUpdates;
      this.checkBoxInstallAutomatically.CheckState = CheckState.Checked;
      this.checkBoxInstallAutomatically.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "InstallUpdates", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBoxInstallAutomatically.Name = "checkBoxInstallAutomatically";
      this.checkBoxInstallAutomatically.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.checkBoxCheckForNewerVersion, "checkBoxCheckForNewerVersion");
      this.checkBoxCheckForNewerVersion.Checked = Settings.Default.CheckForUpdates;
      this.checkBoxCheckForNewerVersion.CheckState = CheckState.Checked;
      this.checkBoxCheckForNewerVersion.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "CheckForUpdates", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBoxCheckForNewerVersion.Name = "checkBoxCheckForNewerVersion";
      this.checkBoxCheckForNewerVersion.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.checkBoxDownloadAutomatically, "checkBoxDownloadAutomatically");
      this.checkBoxDownloadAutomatically.Checked = Settings.Default.DownloadUpdates;
      this.checkBoxDownloadAutomatically.CheckState = CheckState.Checked;
      this.checkBoxDownloadAutomatically.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "DownloadUpdates", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBoxDownloadAutomatically.Name = "checkBoxDownloadAutomatically";
      this.checkBoxDownloadAutomatically.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.buttonOK, "buttonOK");
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      componentResourceManager.ApplyResources((object) this.buttonCancel, "buttonCancel");
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      this.groupBoxBC.Controls.Add((Control) this.buttonTest);
      this.groupBoxBC.Controls.Add((Control) this.textBoxBCPassword);
      this.groupBoxBC.Controls.Add((Control) this.textBoxBCUser);
      this.groupBoxBC.Controls.Add((Control) this.labelBCPassword);
      this.groupBoxBC.Controls.Add((Control) this.labelBCUser);
      this.groupBoxBC.Controls.Add((Control) this.checkBoxSendToBC);
      componentResourceManager.ApplyResources((object) this.groupBoxBC, "groupBoxBC");
      this.groupBoxBC.Name = "groupBoxBC";
      this.groupBoxBC.TabStop = false;
      componentResourceManager.ApplyResources((object) this.buttonTest, "buttonTest");
      this.buttonTest.Name = "buttonTest";
      this.buttonTest.UseVisualStyleBackColor = true;
      this.buttonTest.Click += new EventHandler(this.buttonTest_Click);
      this.textBoxBCPassword.DataBindings.Add(new Binding("Text", (object) Settings.Default, "PasswordBriconWeb", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBoxBCPassword, "textBoxBCPassword");
      this.textBoxBCPassword.Name = "textBoxBCPassword";
      this.textBoxBCPassword.Text = Settings.Default.PasswordBriconWeb;
      this.textBoxBCUser.DataBindings.Add(new Binding("Text", (object) Settings.Default, "LoginBriconWeb", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBoxBCUser, "textBoxBCUser");
      this.textBoxBCUser.Name = "textBoxBCUser";
      this.textBoxBCUser.Text = Settings.Default.LoginBriconWeb;
      componentResourceManager.ApplyResources((object) this.labelBCPassword, "labelBCPassword");
      this.labelBCPassword.Name = "labelBCPassword";
      componentResourceManager.ApplyResources((object) this.labelBCUser, "labelBCUser");
      this.labelBCUser.Name = "labelBCUser";
      componentResourceManager.ApplyResources((object) this.checkBoxSendToBC, "checkBoxSendToBC");
      this.checkBoxSendToBC.Checked = Settings.Default.BCSendAutomatic;
      this.checkBoxSendToBC.CheckState = CheckState.Checked;
      this.checkBoxSendToBC.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "BCSendAutomatic", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBoxSendToBC.Name = "checkBoxSendToBC";
      this.checkBoxSendToBC.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.buttonOK;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonCancel;
      this.Controls.Add((Control) this.groupBoxBC);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonOK);
      this.Controls.Add((Control) this.groupBoxSerialPort);
      this.Controls.Add((Control) this.groupBoxLocalisation);
      this.Controls.Add((Control) this.groupBoxAutomaticUpdates);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (OptionsForm);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.groupBoxSerialPort.ResumeLayout(false);
      this.groupBoxSerialPort.PerformLayout();
      this.groupBoxLocalisation.ResumeLayout(false);
      this.groupBoxLocalisation.PerformLayout();
      this.groupBoxAutomaticUpdates.ResumeLayout(false);
      this.groupBoxAutomaticUpdates.PerformLayout();
      this.groupBoxBC.ResumeLayout(false);
      this.groupBoxBC.PerformLayout();
      this.ResumeLayout(false);
    }

    private class ComboBoxTextItem
    {
      private string _text;
      private string _val;

      public ComboBoxTextItem(string text, string val)
      {
        this._text = text;
        this._val = val;
      }

      public override string ToString() => this._text;

      public string Value => this._val;
    }
  }
}
