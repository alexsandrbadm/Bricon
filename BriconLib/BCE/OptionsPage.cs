// Decompiled with JetBrains decompiler
// Type: BriconLib.BCE.OptionsPage
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.BriconWeb;
using BriconLib.Communications;
using BriconLib.Data;
using BriconLib.Other;
using BriconLib.Properties;
using BriconLib.UI;
using MultiLang;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace BriconLib.BCE
{
  public class OptionsPage : UserControl
  {
    private int _oldCountry;
    private IContainer components;
    private GroupBox groupBoxAutomaticUpdates;
    private CheckBox checkBoxInstallAutomatically;
    private CheckBox checkBoxDownloadAutomatically;
    private CheckBox checkBoxCheckForNewerVersion;
    private GroupBox groupBoxLocalisation;
    private ComboBox comboBoxLanguage;
    private Label label2;
    private Label label1;
    private ComboBox comboBoxCountry;
    private GroupBox groupBoxSerialPort;
    private Label label3;
    private ComboBox comboBoxPort;
    private GroupBox groupBoxDatabase;
    private NumericUpDown numericUpDownAutoSave;
    private Label labelMinutes;
    private Label labelAutoSave;
    private Timer timerAutoSave;
    private Button buttonReInitComm;
    private TrackBar trackBarTimeOut;
    private Label label5;
    private Label label6;
    private Label label4;
    private Button buttonStopComm;
    private Label labelInfo;
    private Button buttonBackup;
    private Button buttonRestore;
    private Button buttonLoadMaster;
    private CheckBox checkBoxAntennaWithoutMaster;
    private TextBox textBoxActivationCode;
    private Label label7;
    private Label labelSerialNumberHeader;
    private GroupBox groupBoxCalculationModule;
    private TextBox textBoxSerial;
    private ComboBox comboBoxUnion;
    private Label labelUnion;
    private Button buttonClubPrinter;
    private ImageList imageList1;
    private Button buttonLoadAntenna;
    private CheckBox checkBoxUseDistanceDB;
    private TextBox textBox4;
    private Label label8;
    private Button button1;
    private TextBox textBox2;
    private TextBox textBox1;
    private Label label10;
    private GroupBox groupBoxInternet;
    private CheckBox checkBoxEncrypt;
    private Label labelPass;
    private CheckBox checkBoxPoints100;
    private TextBox textBoxActivationCode2;
    private CheckBox checkBox1;

    public OptionsPage()
    {
      this.InitializeComponent();
      this.comboBoxLanguage.Items.Clear();
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(149, "Automatic from Master"), "Auto"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem("Arabic (SA)", "ar-SA"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem("Albanian", "sq"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(743, "Bulgarian"), "bg"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(617, "Croatian"), "hr"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(151, "Czech"), "cs"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(155, "Dutch"), "nl"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(152, "English"), "en"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(153, "French"), "fr"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(535, "Greek"), "el"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(150, "German"), "de"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(156, "Hungarian"), "hu"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(511, "Japanese"), "ja"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(618, "Lithuanian"), "lt"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem("Morocan", "ar-MA"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(619, "Polish"), "pl"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(157, "Portuguese"), "pt"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(620, "Romanian"), "ro"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem("Russian", "ru"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(1131, "Serbian"), "sr"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(621, "Slovakia"), "sk"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(154, "Spanish"), "es"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(744, "Turkish"), "tr"));
      this.comboBoxLanguage.Items.Add((object) new OptionsPage.ComboBoxTextItem("Ukraine", "uk"));
      this.comboBoxCountry.Items.Clear();
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(149, "Automatic from Master"), "Auto"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem("Albania", "AL"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(226, "Australia"), "AU"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(158, "Belgium"), "BE"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(745, "Bulgaria"), "BG"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(227, "Croatia"), "CR"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(228, "Spain"), "ES"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(982, "Finland"), "FI"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(161, "France"), "FR"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(159, "Germany"), "DE"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(536, "Greece"), "GR"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem("India", "IN"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem("Iran", "RN"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(750, "Iraq"), "IQ"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(229, "Hungary"), "HU"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(513, "Japan"), "JP"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem("Kosovo", "KV"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(230, "Luxembourg"), "LU"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(984, "Moroco"), "MA"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(231, "Mexico"), "MX"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(160, "Netherlands"), "NL"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(232, "New Zealand"), "NZ"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(233, "Poland"), "PL"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(234, "Portugal"), "PT"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(235, "Saudi Arabia"), "KSA"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(236, "South Africa"), "SA"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(169, "Taiwan"), "TW"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(238, "Czech"), "CZ"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(237, "Turkey"), "TR"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(168, "United Kingdom/Ireland"), "UK"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(167, "United States"), "US"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(622, "Romania"), "RO"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem("Moldavia", "MD"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(1133, "Russia"), "RU"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(623, "Lithuania"), "LT"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(1132, "Serbia"), "SR"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(679, "Slovakia"), "SK"));
      this.comboBoxCountry.Items.Add((object) new OptionsPage.ComboBoxTextItem(ml.ml_string(624, "Ukraine"), "UA"));
      this.numericUpDownAutoSave_ValueChanged((object) null, (EventArgs) null);
      this.checkBoxPoints100.Checked = BCEDatabase.DataSet.Settings[0].CalculationPrintPoints100;
      this.checkBoxEncrypt.Checked = Settings.Default.CryptBCEReadoutFiles;
      if (Utils.IsCountry("IQ") || Utils.IsCountry("RN"))
        return;
      this.checkBoxPoints100.Visible = false;
    }

    private string CountryOrLanguageChanged(ComboBox comboBox, string currentSetting)
    {
      if (!(comboBox.SelectedItem is OptionsPage.ComboBoxTextItem selectedItem) || !(currentSetting != selectedItem.Value))
        return currentSetting;
      if (selectedItem.Value == "Auto")
        CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new GetLanguageAndCountryCommand());
      return selectedItem.Value;
    }

    private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Utils.IsCountry("BE") || !Utils.IsCountry("NL") && (this.comboBoxCountry.SelectedItem is OptionsPage.ComboBoxTextItem selectedItem ? selectedItem.Value : (string) null) == "NL")
      {
        PasswordForm passwordForm = new PasswordForm();
        if (passwordForm.ShowDialog() != DialogResult.OK || passwordForm.Code != "211073")
        {
          this.comboBoxCountry.SelectedIndexChanged -= new EventHandler(this.comboBoxCountry_SelectedIndexChanged);
          this.comboBoxCountry.SelectedIndex = this._oldCountry;
          this.comboBoxCountry.SelectedIndexChanged += new EventHandler(this.comboBoxCountry_SelectedIndexChanged);
          return;
        }
      }
      Settings.Default.Country = this.CountryOrLanguageChanged(this.comboBoxCountry, Settings.Default.Country);
      this._oldCountry = this.comboBoxCountry.SelectedIndex;
      this.ShowAntennaCheckbox();
      this.labelUnion.Visible = Utils.IsCountry("UK");
      this.comboBoxUnion.Visible = Utils.IsCountry("UK");
      this.textBox4.Visible = Utils.IsCountry("BE");
      this.label8.Visible = Utils.IsCountry("BE");
    }

    private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
      Settings.Default.Language = this.CountryOrLanguageChanged(this.comboBoxLanguage, Settings.Default.Language);
      if (!(Settings.Default.Language != "Auto"))
        return;
      int num = (int) MessageBox.Show(ml.ml_string(165, "Please restart the program to apply the new language"), Defines.MessageBoxCaption);
    }

    private void comboBoxPort_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (CommunicationPool.Instance.AreCommandsPending && MessageBox.Show(ml.ml_string(164, "The pending commands will be cleared with this action, do you want to continue?"), ml.ml_string(832, "Bricon Club Editor"), MessageBoxButtons.OKCancel) == DialogResult.Cancel)
      {
        this.OptionsPage_VisibleChanged(sender, e);
      }
      else
      {
        Settings.Default.ComPort = this.comboBoxPort.SelectedItem as string;
        CommunicationPool.Instance.RefreshComPort();
      }
    }

    public void RefreshData()
    {
      this.labelUnion.Visible = Utils.IsCountry("UK");
      this.comboBoxUnion.Visible = Utils.IsCountry("UK");
      this.textBox4.Visible = Utils.IsCountry("BE");
      this.label8.Visible = Utils.IsCountry("BE");
      this.comboBoxLanguage.SelectedIndexChanged -= new EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
      this.comboBoxCountry.SelectedIndexChanged -= new EventHandler(this.comboBoxCountry_SelectedIndexChanged);
      this.comboBoxPort.SelectedIndexChanged -= new EventHandler(this.comboBoxPort_SelectedIndexChanged);
      this.comboBoxCountry.SelectedIndex = 0;
      this.comboBoxLanguage.SelectedIndex = 0;
      foreach (OptionsPage.ComboBoxTextItem comboBoxTextItem in this.comboBoxLanguage.Items)
      {
        if (comboBoxTextItem.Value == Settings.Default.Language)
          this.comboBoxLanguage.SelectedItem = (object) comboBoxTextItem;
      }
      foreach (OptionsPage.ComboBoxTextItem comboBoxTextItem in this.comboBoxCountry.Items)
      {
        if (comboBoxTextItem.Value == Settings.Default.Country)
          this.comboBoxCountry.SelectedItem = (object) comboBoxTextItem;
      }
      this._oldCountry = this.comboBoxCountry.SelectedIndex;
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
      this.ShowAntennaCheckbox();
    }

    private void ShowAntennaCheckbox()
    {
      if (Utils.IsCountry("BE") || Utils.IsCountry("JP") || (Utils.IsCountry("KSA") || Utils.IsCountry("IQ")) || Utils.IsCountry("RN"))
      {
        this.checkBoxAntennaWithoutMaster.Visible = false;
        Settings.Default.AntenneWithoutMaster = false;
      }
      else
        this.checkBoxAntennaWithoutMaster.Visible = true;
      this.checkBoxAntennaWithoutMaster_CheckedChanged((object) null, (EventArgs) null);
    }

    private void OptionsPage_VisibleChanged(object sender, EventArgs e)
    {
      if (!this.Visible)
        return;
      this.RefreshData();
    }

    private void buttonDBLocation_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = ml.ml_string(163, "Database Files (*.mdb)|*.mdb|All files (*.*)|*.*");
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      Settings.Default.DBLocation = openFileDialog.FileName;
    }

    private void comboBoxDBLocation_TextUpdate(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show(ml.ml_string(162, "Please restart the program to apply the new database location"), Defines.MessageBoxCaption);
    }

    private void numericUpDownAutoSave_ValueChanged(object sender, EventArgs e)
    {
      this.timerAutoSave.Stop();
      if (!(this.numericUpDownAutoSave.Value > 0M))
        return;
      this.timerAutoSave.Interval = Convert.ToInt32(this.numericUpDownAutoSave.Value) * 60000;
      this.timerAutoSave.Start();
    }

    private void timerAutoSave_Tick(object sender, EventArgs e)
    {
      if (this.DesignMode)
        return;
      try
      {
        BCEDatabase.SaveToDisk(true);
        Settings.Default.Save();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ml.ml_string(310, "Error in AutoSave: ") + ex.ToString());
      }
    }

    private void buttonReInitComm_Click(object sender, EventArgs e) => CommunicationPool.Instance.RefreshComPort();

    private void buttonImport_Click(object sender, EventArgs e) => Upload95Importer.Import();

    private void buttonBackup_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = ml.ml_string(1235, "BCE Database Files (*.bce)|*.bce|All files (*.*)|*.*");
      saveFileDialog.DefaultExt = ".bce";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      try
      {
        BCEDatabase.DataSet.WriteXml(saveFileDialog.FileName + ".tmp");
        BCEDatabase.EncryptFile(saveFileDialog.FileName + ".tmp", saveFileDialog.FileName);
        File.Delete(saveFileDialog.FileName + ".tmp");
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void buttonRestore_Click(object sender, EventArgs e)
    {
      if (Control.ModifierKeys.HasFlag((Enum) Keys.Control) && Control.ModifierKeys.HasFlag((Enum) Keys.Shift))
        this.RestoreOldbce();
      else if (Control.ModifierKeys.HasFlag((Enum) Keys.Alt))
      {
        this.RestoreOldXml();
      }
      else
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = ml.ml_string(1236, "BCE Database Files (*.xml,*.bce)|*.xml;*.bce|All files (*.*)|*.*");
        if (openFileDialog.ShowDialog() != DialogResult.OK)
          return;
        if (!File.Exists(openFileDialog.FileName))
          return;
        try
        {
          if (Path.GetExtension(openFileDialog.FileName).ToLower() == ".bce")
          {
            BCEDatabase.DecryptFile(openFileDialog.FileName, openFileDialog.FileName + ".tmp");
            BCEDatabase.DataSet.Clear();
            int num = (int) BCEDatabase.DataSet.ReadXml(openFileDialog.FileName + ".tmp");
            File.Delete(openFileDialog.FileName + ".tmp");
          }
          else
          {
            BCEDatabase.DataSet.Clear();
            int num = (int) BCEDatabase.DataSet.ReadXml(openFileDialog.FileName);
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.ToString());
        }
      }
    }

    private void buttonStopComm_Click(object sender, EventArgs e) => CommunicationPool.Instance.Stop();

    private void buttonLoadMaster_Click(object sender, EventArgs e)
    {
      CommunicationPool.Instance.Stop();
      int num = (int) new LoadMasterForm(false).ShowDialog();
      CommunicationPool.Instance.RefreshComPort();
    }

    private void button1_Click(object sender, EventArgs e)
    {
    }

    private void OptionsPage_Load(object sender, EventArgs e) => this.textBoxSerial.Text = OptionsPage.GetSerial().ToUpper();

    public static string GetSerial()
    {
      try
      {
        int num1;
        uint num2 = (uint) (num1 = ~(int) Convert.ToUInt32(OptionsPage.gs("C")));
        uint num3 = (uint) num1;
        uint num4 = (uint) num1;
        string str1 = Convert.ToString((long) num2, 16);
        uint num5 = ~num2 + num4;
        OptionsPage.gs("C");
        while (str1.Length < 8)
          str1 = "0" + str1;
        uint num6 = ~num5 + num3;
        uint num7 = num5 & 0U;
        string str2 = str1.Substring(1, 6);
        uint num8 = ~num5 - num6;
        OptionsPage.gs("C");
        byte num9 = 0;
        uint num10 = ~num8 + num7;
        OptionsPage.gs("C");
        for (int index = 0; index < str2.Length; ++index)
          num9 += (byte) ((uint) (byte) str2[index] + (uint) (byte) num7);
        uint num11 = ~num10;
        OptionsPage.gs("C");
        string str3 = Convert.ToString(num9, 16);
        uint num12 = ~num11;
        while (str3.Length < 2)
          str3 = "0" + str3;
        if (str2.Length > 0)
          return str2 + str3;
      }
      catch
      {
        return OptionsPage.gk();
      }
      int num13;
      uint num14 = (uint) (num13 = ~(int) Convert.ToUInt32(OptionsPage.gs("C")));
      uint num15 = (uint) num13;
      uint num16 = (uint) num13;
      string str4 = Convert.ToString((long) num14, 16);
      uint num17 = ~num14 + num16;
      OptionsPage.gs("C");
      while (str4.Length < 8)
        str4 = "0" + str4;
      uint num18 = ~num17 + num15;
      uint num19 = num17 & 0U;
      string str5 = str4.Substring(1, 6);
      uint num20 = ~num17 - num18;
      OptionsPage.gs("C");
      byte num21 = 0;
      uint num22 = ~num20 + num19;
      OptionsPage.gs("C");
      for (int index = 0; index < str5.Length; ++index)
        num21 += (byte) ((uint) (byte) str5[index] + (uint) (byte) num19);
      uint num23 = ~num22;
      OptionsPage.gs("C");
      string str6 = Convert.ToString(num21, 16);
      uint num24 = ~num23;
      while (str6.Length < 2)
        str6 = "0" + str6;
      return "";
    }

    private static uint GetKeyValue1() => 1165529430;

    private static uint GetKeyValue5() => 848380946;

    private static uint GetKeyValue2() => 344004931;

    private static string gk() => "72FCB665";

    public static string gs() => "87842533";

    private static string KeyFromSerial(string serial)
    {
      try
      {
        return Convert.ToString((long) (uint) (((int) Convert.ToUInt32(serial, 16) ^ (int) OptionsPage.GetKeyValue1() | int.MinValue) & -1879087617), 16);
      }
      catch
      {
        return OptionsPage.gs();
      }
    }

    private static string KeyFromSerialXmlUpload(string serial)
    {
      try
      {
        return Convert.ToString((long) (uint) (((int) Convert.ToUInt32(serial, 16) ^ (int) OptionsPage.GetKeyValue5() | int.MinValue) & -1879087617), 16);
      }
      catch
      {
        return OptionsPage.gs();
      }
    }

    public static string KeyFromSerialOneLoft(string serial)
    {
      try
      {
        return Convert.ToString((long) (uint) (((int) Convert.ToUInt32(serial, 16) ^ (int) OptionsPage.GetKeyValue2() | int.MinValue) & -1879087617), 16);
      }
      catch
      {
        return OptionsPage.gs();
      }
    }

    [DllImport("kernel32.dll")]
    private static extern long GetVolumeInformation(
      string PathName,
      StringBuilder VolumeNameBuffer,
      uint VolumeNameSize,
      ref uint VolumeSerialNumber,
      ref uint MaximumComponentLength,
      ref uint FileSystemFlags,
      StringBuilder FileSystemNameBuffer,
      uint FileSystemNameSize);

    public static string gs(string strDriveLetter)
    {
      uint VolumeSerialNumber = 0;
      uint MaximumComponentLength = 0;
      StringBuilder VolumeNameBuffer = new StringBuilder(256);
      uint FileSystemFlags = 0;
      StringBuilder FileSystemNameBuffer = new StringBuilder(256);
      strDriveLetter += ":\\";
      OptionsPage.GetVolumeInformation(strDriveLetter, VolumeNameBuffer, (uint) VolumeNameBuffer.Capacity, ref VolumeSerialNumber, ref MaximumComponentLength, ref FileSystemFlags, FileSystemNameBuffer, (uint) FileSystemNameBuffer.Capacity);
      return Convert.ToString(VolumeSerialNumber);
    }

    public static bool IsCalulationModuleLicensed()
    {
      try
      {
        if (OptionsPage.KeyFromSerial(OptionsPage.GetSerial()).ToLower() == Settings.Default.ActivationCode.ToLower())
          return true;
      }
      catch
      {
      }
      return false;
    }

    public static bool IsXmlUploadModuleLicensed()
    {
      try
      {
        if (OptionsPage.KeyFromSerialXmlUpload(OptionsPage.GetSerial()).ToLower() == Settings.Default.ActivationCode2.ToLower())
          return true;
      }
      catch
      {
      }
      return false;
    }

    public static bool IsOneLoftModuleLicensed()
    {
      try
      {
        if (OptionsPage.KeyFromSerialOneLoft(OptionsPage.GetSerial()).ToLower() == Settings.Default.ActivationCode.ToLower())
          return true;
      }
      catch
      {
      }
      return false;
    }

    private void textBoxActivationCode_TextChanged(object sender, EventArgs e)
    {
      if (OptionsPage.KeyFromSerial(OptionsPage.GetSerial()).ToLower() == this.textBoxActivationCode.Text.ToLower() || OptionsPage.KeyFromSerialOneLoft(OptionsPage.GetSerial()).ToLower() == this.textBoxActivationCode.Text.ToLower())
        this.textBoxActivationCode.ForeColor = Color.Green;
      else
        this.textBoxActivationCode.ForeColor = Color.Red;
      if (!(this.textBoxActivationCode.Text == "<NONE>"))
        return;
      this.textBoxActivationCode.ForeColor = Color.Black;
    }

    private void buttonClubPrinter_Click(object sender, EventArgs e)
    {
      CommunicationPool.Instance.Stop();
      CommunicationPool.Instance.FullStop();
      int num = (int) new ClubPrinterForm().ShowDialog();
      MainForm.Instance.backgroundCommunication.RunWorkerAsync();
      CommunicationPool.Instance.ReInit();
    }

    private void buttonLoadAntenna_Click(object sender, EventArgs e)
    {
      CommunicationPool.Instance.Stop();
      int num = (int) new LoadMasterForm(true).ShowDialog();
      CommunicationPool.Instance.RefreshComPort();
    }

    private void checkBoxAntennaWithoutMaster_CheckedChanged(object sender, EventArgs e) => this.buttonLoadAntenna.Visible = this.checkBoxAntennaWithoutMaster.Visible && this.checkBoxAntennaWithoutMaster.Checked;

    private void button1_Click_1(object sender, EventArgs e)
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

    private void RestoreOldXml()
    {
      long num1 = 0;
      if (File.Exists("BCEData.bce"))
        num1 = new FileInfo("BCEData.bce").Length;
      long num2 = 0;
      if (File.Exists(Path.ChangeExtension("BCEData.bce", ".xml")))
        num2 = new FileInfo(Path.ChangeExtension("BCEData.bce", ".xml")).Length;
      long num3 = 0;
      if (File.Exists(Path.ChangeExtension("BCEData.bce", ".OLDxml")))
        num3 = new FileInfo(Path.ChangeExtension("BCEData.bce", ".OLDxml")).Length;
      if (MessageBox.Show(string.Format(ml.ml_string(1408, "Restore BCEData.OLDxml ({0}b) to BCEData.xml({1}b) and delete the compressed BCEData.bce({2}b), program will exit after restore?"), (object) num3, (object) num2, (object) num1), "Restore", MessageBoxButtons.OKCancel) != DialogResult.OK)
        return;
      if (File.Exists(Path.ChangeExtension("BCEData.bce", ".OLDxml")))
      {
        if (File.Exists(Path.ChangeExtension("BCEData.bce", ".xml")))
          File.Move(Path.ChangeExtension("BCEData.bce", ".xml"), Path.ChangeExtension("BCEData.bce", ".xmlBeforeRestore"));
        if (File.Exists("BCEData.bce"))
          File.Move("BCEData.bce", Path.ChangeExtension("BCEData.bce", ".bceBeforeRestore"));
        File.Move(Path.ChangeExtension("BCEData.bce", ".OLDxml"), Path.ChangeExtension("BCEData.bce", ".xml"));
        BCEDatabase.Reload();
        Application.Exit();
      }
      else
      {
        int num4 = (int) MessageBox.Show(Path.ChangeExtension("BCEData.bce", ".OLDxml") + " does not exist, can't restore");
      }
    }

    private void RestoreOldbce()
    {
      long num1 = 0;
      if (File.Exists("BCEData.bce"))
        num1 = new FileInfo("BCEData.bce").Length;
      long num2 = 0;
      if (File.Exists("BCEDataOLD.bce"))
        num2 = new FileInfo("BCEDataOLD.bce").Length;
      if (MessageBox.Show(string.Format(ml.ml_string(1409, "Restore BCEDataOLD.bce ({0}b) to BCEData.bce({1}b), program will exit after restore?"), (object) num2, (object) num1), "Restore", MessageBoxButtons.OKCancel) != DialogResult.OK)
        return;
      if (File.Exists("BCEDataOLD.bce"))
      {
        if (File.Exists(Path.ChangeExtension("BCEData.bce", ".bceBeforeRestore")))
          File.Delete(Path.ChangeExtension("BCEData.bce", ".bceBeforeRestore"));
        if (File.Exists("BCEData.bce"))
          File.Move("BCEData.bce", Path.ChangeExtension("BCEData.bce", ".bceBeforeRestore"));
        File.Move("BCEDataOLD.bce", "BCEData.bce");
        BCEDatabase.Reload();
        Application.Exit();
      }
      else
      {
        int num3 = (int) MessageBox.Show(ml.ml_string(1411, "BCEDataOLD.bce does not exist, can't restore"));
      }
    }

    private void checkBoxPoints100_CheckedChanged(object sender, EventArgs e)
    {
      if (BCEDatabase.DataSet.Settings[0].CalculationPrintPoints100 == this.checkBoxPoints100.Checked)
        return;
      PasswordForm passwordForm = new PasswordForm();
      passwordForm.Text = ml.ml_string(1410, "Enter code");
      passwordForm.label1.Text = ml.ml_string(1410, "Enter code");
      string str = "100";
      if (passwordForm.ShowDialog() != DialogResult.OK || passwordForm.Code != str)
        this.checkBoxPoints100.Checked = BCEDatabase.DataSet.Settings[0].CalculationPrintPoints100;
      else
        BCEDatabase.DataSet.Settings[0].CalculationPrintPoints100 = this.checkBoxPoints100.Checked;
    }

    private void checkBoxEncrypt_CheckedChanged(object sender, EventArgs e)
    {
      if (!Utils.IsCountry("IQ") && !Utils.IsCountry("RN") || Settings.Default.CryptBCEReadoutFiles == this.checkBoxEncrypt.Checked)
        return;
      PasswordForm passwordForm = new PasswordForm();
      passwordForm.Text = ml.ml_string(1410, "Enter code");
      passwordForm.label1.Text = ml.ml_string(1410, "Enter code");
      string str = "100";
      if (Utils.IsCountry("IQ") || Utils.IsCountry("RN"))
        str = "111";
      if (passwordForm.ShowDialog() == DialogResult.OK && !(passwordForm.Code != str))
        return;
      this.checkBoxEncrypt.Checked = Settings.Default.CryptBCEReadoutFiles;
    }

    private void textBoxActivationCode2_TextChanged(object sender, EventArgs e)
    {
      if (OptionsPage.KeyFromSerialXmlUpload(OptionsPage.GetSerial()).ToLower() == this.textBoxActivationCode2.Text.ToLower())
        this.textBoxActivationCode2.ForeColor = Color.Green;
      else
        this.textBoxActivationCode2.ForeColor = Color.Red;
      if (!(this.textBoxActivationCode2.Text == "<NONE>"))
        return;
      this.textBoxActivationCode2.ForeColor = Color.Black;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (OptionsPage));
      this.groupBoxAutomaticUpdates = new GroupBox();
      this.checkBoxEncrypt = new CheckBox();
      this.checkBoxInstallAutomatically = new CheckBox();
      this.checkBoxCheckForNewerVersion = new CheckBox();
      this.checkBoxDownloadAutomatically = new CheckBox();
      this.groupBoxLocalisation = new GroupBox();
      this.comboBoxUnion = new ComboBox();
      this.labelUnion = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.comboBoxCountry = new ComboBox();
      this.comboBoxLanguage = new ComboBox();
      this.groupBoxSerialPort = new GroupBox();
      this.label6 = new Label();
      this.label4 = new Label();
      this.trackBarTimeOut = new TrackBar();
      this.label5 = new Label();
      this.comboBoxPort = new ComboBox();
      this.label3 = new Label();
      this.groupBoxDatabase = new GroupBox();
      this.buttonBackup = new Button();
      this.buttonRestore = new Button();
      this.numericUpDownAutoSave = new NumericUpDown();
      this.labelMinutes = new Label();
      this.labelAutoSave = new Label();
      this.timerAutoSave = new Timer(this.components);
      this.buttonReInitComm = new Button();
      this.buttonStopComm = new Button();
      this.labelInfo = new Label();
      this.buttonLoadMaster = new Button();
      this.label7 = new Label();
      this.labelSerialNumberHeader = new Label();
      this.groupBoxCalculationModule = new GroupBox();
      this.checkBoxPoints100 = new CheckBox();
      this.checkBoxUseDistanceDB = new CheckBox();
      this.textBoxSerial = new TextBox();
      this.textBoxActivationCode2 = new TextBox();
      this.textBoxActivationCode = new TextBox();
      this.buttonClubPrinter = new Button();
      this.imageList1 = new ImageList(this.components);
      this.buttonLoadAntenna = new Button();
      this.label8 = new Label();
      this.button1 = new Button();
      this.label10 = new Label();
      this.groupBoxInternet = new GroupBox();
      this.labelPass = new Label();
      this.textBox1 = new TextBox();
      this.textBox4 = new TextBox();
      this.textBox2 = new TextBox();
      this.checkBoxAntennaWithoutMaster = new CheckBox();
      this.checkBox1 = new CheckBox();
      this.groupBoxAutomaticUpdates.SuspendLayout();
      this.groupBoxLocalisation.SuspendLayout();
      this.groupBoxSerialPort.SuspendLayout();
      this.trackBarTimeOut.BeginInit();
      this.groupBoxDatabase.SuspendLayout();
      this.numericUpDownAutoSave.BeginInit();
      this.groupBoxCalculationModule.SuspendLayout();
      this.groupBoxInternet.SuspendLayout();
      this.SuspendLayout();
      this.groupBoxAutomaticUpdates.Controls.Add((Control) this.checkBoxEncrypt);
      this.groupBoxAutomaticUpdates.Controls.Add((Control) this.checkBoxInstallAutomatically);
      this.groupBoxAutomaticUpdates.Controls.Add((Control) this.checkBoxCheckForNewerVersion);
      this.groupBoxAutomaticUpdates.Controls.Add((Control) this.checkBoxDownloadAutomatically);
      componentResourceManager.ApplyResources((object) this.groupBoxAutomaticUpdates, "groupBoxAutomaticUpdates");
      this.groupBoxAutomaticUpdates.Name = "groupBoxAutomaticUpdates";
      this.groupBoxAutomaticUpdates.TabStop = false;
      componentResourceManager.ApplyResources((object) this.checkBoxEncrypt, "checkBoxEncrypt");
      this.checkBoxEncrypt.Name = "checkBoxEncrypt";
      this.checkBoxEncrypt.UseVisualStyleBackColor = true;
      this.checkBoxEncrypt.CheckedChanged += new EventHandler(this.checkBoxEncrypt_CheckedChanged);
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
      this.groupBoxLocalisation.Controls.Add((Control) this.comboBoxUnion);
      this.groupBoxLocalisation.Controls.Add((Control) this.labelUnion);
      this.groupBoxLocalisation.Controls.Add((Control) this.label2);
      this.groupBoxLocalisation.Controls.Add((Control) this.label1);
      this.groupBoxLocalisation.Controls.Add((Control) this.comboBoxCountry);
      this.groupBoxLocalisation.Controls.Add((Control) this.comboBoxLanguage);
      componentResourceManager.ApplyResources((object) this.groupBoxLocalisation, "groupBoxLocalisation");
      this.groupBoxLocalisation.Name = "groupBoxLocalisation";
      this.groupBoxLocalisation.TabStop = false;
      this.comboBoxUnion.DataBindings.Add(new Binding("Text", (object) Settings.Default, "Union", true, DataSourceUpdateMode.OnPropertyChanged));
      this.comboBoxUnion.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxUnion.FormattingEnabled = true;
      this.comboBoxUnion.Items.AddRange(new object[6]
      {
        (object) componentResourceManager.GetString("comboBoxUnion.Items"),
        (object) componentResourceManager.GetString("comboBoxUnion.Items1"),
        (object) componentResourceManager.GetString("comboBoxUnion.Items2"),
        (object) componentResourceManager.GetString("comboBoxUnion.Items3"),
        (object) componentResourceManager.GetString("comboBoxUnion.Items4"),
        (object) componentResourceManager.GetString("comboBoxUnion.Items5")
      });
      componentResourceManager.ApplyResources((object) this.comboBoxUnion, "comboBoxUnion");
      this.comboBoxUnion.Name = "comboBoxUnion";
      this.comboBoxUnion.Text = Settings.Default.Union;
      componentResourceManager.ApplyResources((object) this.labelUnion, "labelUnion");
      this.labelUnion.Name = "labelUnion";
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
      this.groupBoxSerialPort.Controls.Add((Control) this.label6);
      this.groupBoxSerialPort.Controls.Add((Control) this.label4);
      this.groupBoxSerialPort.Controls.Add((Control) this.trackBarTimeOut);
      this.groupBoxSerialPort.Controls.Add((Control) this.label5);
      this.groupBoxSerialPort.Controls.Add((Control) this.comboBoxPort);
      this.groupBoxSerialPort.Controls.Add((Control) this.label3);
      componentResourceManager.ApplyResources((object) this.groupBoxSerialPort, "groupBoxSerialPort");
      this.groupBoxSerialPort.Name = "groupBoxSerialPort";
      this.groupBoxSerialPort.TabStop = false;
      componentResourceManager.ApplyResources((object) this.label6, "label6");
      this.label6.Name = "label6";
      componentResourceManager.ApplyResources((object) this.label4, "label4");
      this.label4.Name = "label4";
      componentResourceManager.ApplyResources((object) this.trackBarTimeOut, "trackBarTimeOut");
      this.trackBarTimeOut.DataBindings.Add(new Binding("Value", (object) Settings.Default, "TimeOutPolling", true, DataSourceUpdateMode.OnPropertyChanged));
      this.trackBarTimeOut.LargeChange = 100;
      this.trackBarTimeOut.Maximum = 500;
      this.trackBarTimeOut.Minimum = 200;
      this.trackBarTimeOut.Name = "trackBarTimeOut";
      this.trackBarTimeOut.SmallChange = 50;
      this.trackBarTimeOut.TickFrequency = 100;
      this.trackBarTimeOut.Value = Settings.Default.TimeOutPolling;
      componentResourceManager.ApplyResources((object) this.label5, "label5");
      this.label5.Name = "label5";
      this.comboBoxPort.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxPort.FormattingEnabled = true;
      componentResourceManager.ApplyResources((object) this.comboBoxPort, "comboBoxPort");
      this.comboBoxPort.Name = "comboBoxPort";
      this.comboBoxPort.SelectedIndexChanged += new EventHandler(this.comboBoxPort_SelectedIndexChanged);
      componentResourceManager.ApplyResources((object) this.label3, "label3");
      this.label3.Name = "label3";
      this.groupBoxDatabase.Controls.Add((Control) this.buttonBackup);
      this.groupBoxDatabase.Controls.Add((Control) this.buttonRestore);
      this.groupBoxDatabase.Controls.Add((Control) this.numericUpDownAutoSave);
      this.groupBoxDatabase.Controls.Add((Control) this.labelMinutes);
      this.groupBoxDatabase.Controls.Add((Control) this.labelAutoSave);
      componentResourceManager.ApplyResources((object) this.groupBoxDatabase, "groupBoxDatabase");
      this.groupBoxDatabase.Name = "groupBoxDatabase";
      this.groupBoxDatabase.TabStop = false;
      componentResourceManager.ApplyResources((object) this.buttonBackup, "buttonBackup");
      this.buttonBackup.Name = "buttonBackup";
      this.buttonBackup.UseVisualStyleBackColor = true;
      this.buttonBackup.Click += new EventHandler(this.buttonBackup_Click);
      componentResourceManager.ApplyResources((object) this.buttonRestore, "buttonRestore");
      this.buttonRestore.Name = "buttonRestore";
      this.buttonRestore.UseVisualStyleBackColor = true;
      this.buttonRestore.Click += new EventHandler(this.buttonRestore_Click);
      this.numericUpDownAutoSave.DataBindings.Add(new Binding("Value", (object) Settings.Default, "AutoSaveMinutes", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.numericUpDownAutoSave, "numericUpDownAutoSave");
      this.numericUpDownAutoSave.Maximum = new Decimal(new int[4]
      {
        999,
        0,
        0,
        0
      });
      this.numericUpDownAutoSave.Name = "numericUpDownAutoSave";
      this.numericUpDownAutoSave.Value = Settings.Default.AutoSaveMinutes;
      this.numericUpDownAutoSave.ValueChanged += new EventHandler(this.numericUpDownAutoSave_ValueChanged);
      componentResourceManager.ApplyResources((object) this.labelMinutes, "labelMinutes");
      this.labelMinutes.Name = "labelMinutes";
      componentResourceManager.ApplyResources((object) this.labelAutoSave, "labelAutoSave");
      this.labelAutoSave.Name = "labelAutoSave";
      this.timerAutoSave.Tick += new EventHandler(this.timerAutoSave_Tick);
      componentResourceManager.ApplyResources((object) this.buttonReInitComm, "buttonReInitComm");
      this.buttonReInitComm.Name = "buttonReInitComm";
      this.buttonReInitComm.UseVisualStyleBackColor = true;
      this.buttonReInitComm.Click += new EventHandler(this.buttonReInitComm_Click);
      componentResourceManager.ApplyResources((object) this.buttonStopComm, "buttonStopComm");
      this.buttonStopComm.Name = "buttonStopComm";
      this.buttonStopComm.UseVisualStyleBackColor = true;
      this.buttonStopComm.Click += new EventHandler(this.buttonStopComm_Click);
      componentResourceManager.ApplyResources((object) this.labelInfo, "labelInfo");
      this.labelInfo.Name = "labelInfo";
      componentResourceManager.ApplyResources((object) this.buttonLoadMaster, "buttonLoadMaster");
      this.buttonLoadMaster.Name = "buttonLoadMaster";
      this.buttonLoadMaster.UseVisualStyleBackColor = true;
      this.buttonLoadMaster.Click += new EventHandler(this.buttonLoadMaster_Click);
      componentResourceManager.ApplyResources((object) this.label7, "label7");
      this.label7.Name = "label7";
      componentResourceManager.ApplyResources((object) this.labelSerialNumberHeader, "labelSerialNumberHeader");
      this.labelSerialNumberHeader.Name = "labelSerialNumberHeader";
      this.groupBoxCalculationModule.Controls.Add((Control) this.checkBoxPoints100);
      this.groupBoxCalculationModule.Controls.Add((Control) this.checkBoxUseDistanceDB);
      this.groupBoxCalculationModule.Controls.Add((Control) this.textBoxSerial);
      this.groupBoxCalculationModule.Controls.Add((Control) this.textBoxActivationCode2);
      this.groupBoxCalculationModule.Controls.Add((Control) this.textBoxActivationCode);
      this.groupBoxCalculationModule.Controls.Add((Control) this.label7);
      this.groupBoxCalculationModule.Controls.Add((Control) this.labelSerialNumberHeader);
      componentResourceManager.ApplyResources((object) this.groupBoxCalculationModule, "groupBoxCalculationModule");
      this.groupBoxCalculationModule.Name = "groupBoxCalculationModule";
      this.groupBoxCalculationModule.TabStop = false;
      componentResourceManager.ApplyResources((object) this.checkBoxPoints100, "checkBoxPoints100");
      this.checkBoxPoints100.Name = "checkBoxPoints100";
      this.checkBoxPoints100.UseVisualStyleBackColor = true;
      this.checkBoxPoints100.CheckedChanged += new EventHandler(this.checkBoxPoints100_CheckedChanged);
      componentResourceManager.ApplyResources((object) this.checkBoxUseDistanceDB, "checkBoxUseDistanceDB");
      this.checkBoxUseDistanceDB.Checked = Settings.Default.UseDistanceDB;
      this.checkBoxUseDistanceDB.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "UseDistanceDB", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBoxUseDistanceDB.Name = "checkBoxUseDistanceDB";
      this.checkBoxUseDistanceDB.UseVisualStyleBackColor = true;
      this.textBoxSerial.CharacterCasing = CharacterCasing.Upper;
      componentResourceManager.ApplyResources((object) this.textBoxSerial, "textBoxSerial");
      this.textBoxSerial.Name = "textBoxSerial";
      this.textBoxSerial.ReadOnly = true;
      this.textBoxActivationCode2.CharacterCasing = CharacterCasing.Upper;
      this.textBoxActivationCode2.DataBindings.Add(new Binding("Text", (object) Settings.Default, "ActivationCode2", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBoxActivationCode2, "textBoxActivationCode2");
      this.textBoxActivationCode2.Name = "textBoxActivationCode2";
      this.textBoxActivationCode2.Text = Settings.Default.ActivationCode2;
      this.textBoxActivationCode2.TextChanged += new EventHandler(this.textBoxActivationCode2_TextChanged);
      this.textBoxActivationCode.CharacterCasing = CharacterCasing.Upper;
      this.textBoxActivationCode.DataBindings.Add(new Binding("Text", (object) Settings.Default, "ActivationCode", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBoxActivationCode, "textBoxActivationCode");
      this.textBoxActivationCode.Name = "textBoxActivationCode";
      this.textBoxActivationCode.Text = Settings.Default.ActivationCode;
      this.textBoxActivationCode.TextChanged += new EventHandler(this.textBoxActivationCode_TextChanged);
      componentResourceManager.ApplyResources((object) this.buttonClubPrinter, "buttonClubPrinter");
      this.buttonClubPrinter.ImageList = this.imageList1;
      this.buttonClubPrinter.Name = "buttonClubPrinter";
      this.buttonClubPrinter.UseVisualStyleBackColor = true;
      this.buttonClubPrinter.Click += new EventHandler(this.buttonClubPrinter_Click);
      this.imageList1.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageList1.ImageStream");
      this.imageList1.TransparentColor = Color.Fuchsia;
      this.imageList1.Images.SetKeyName(0, "Print.bmp");
      componentResourceManager.ApplyResources((object) this.buttonLoadAntenna, "buttonLoadAntenna");
      this.buttonLoadAntenna.Name = "buttonLoadAntenna";
      this.buttonLoadAntenna.UseVisualStyleBackColor = true;
      this.buttonLoadAntenna.Click += new EventHandler(this.buttonLoadAntenna_Click);
      componentResourceManager.ApplyResources((object) this.label8, "label8");
      this.label8.Name = "label8";
      componentResourceManager.ApplyResources((object) this.button1, "button1");
      this.button1.Name = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click_1);
      componentResourceManager.ApplyResources((object) this.label10, "label10");
      this.label10.Name = "label10";
      this.groupBoxInternet.Controls.Add((Control) this.labelPass);
      this.groupBoxInternet.Controls.Add((Control) this.textBox1);
      this.groupBoxInternet.Controls.Add((Control) this.textBox4);
      this.groupBoxInternet.Controls.Add((Control) this.label8);
      this.groupBoxInternet.Controls.Add((Control) this.button1);
      this.groupBoxInternet.Controls.Add((Control) this.label10);
      this.groupBoxInternet.Controls.Add((Control) this.textBox2);
      componentResourceManager.ApplyResources((object) this.groupBoxInternet, "groupBoxInternet");
      this.groupBoxInternet.Name = "groupBoxInternet";
      this.groupBoxInternet.TabStop = false;
      componentResourceManager.ApplyResources((object) this.labelPass, "labelPass");
      this.labelPass.Name = "labelPass";
      this.textBox1.DataBindings.Add(new Binding("Text", (object) Settings.Default, "LoginBriconWeb", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBox1, "textBox1");
      this.textBox1.Name = "textBox1";
      this.textBox1.Text = Settings.Default.LoginBriconWeb;
      this.textBox4.DataBindings.Add(new Binding("Text", (object) Settings.Default, "OutMailServer", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBox4, "textBox4");
      this.textBox4.Name = "textBox4";
      this.textBox4.Text = Settings.Default.OutMailServer;
      this.textBox2.DataBindings.Add(new Binding("Text", (object) Settings.Default, "PasswordBriconWeb", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBox2, "textBox2");
      this.textBox2.Name = "textBox2";
      this.textBox2.Text = Settings.Default.PasswordBriconWeb;
      componentResourceManager.ApplyResources((object) this.checkBoxAntennaWithoutMaster, "checkBoxAntennaWithoutMaster");
      this.checkBoxAntennaWithoutMaster.Checked = Settings.Default.AntenneWithoutMaster;
      this.checkBoxAntennaWithoutMaster.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "AntenneWithoutMaster", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBoxAntennaWithoutMaster.Name = "checkBoxAntennaWithoutMaster";
      this.checkBoxAntennaWithoutMaster.UseVisualStyleBackColor = true;
      this.checkBoxAntennaWithoutMaster.CheckedChanged += new EventHandler(this.checkBoxAntennaWithoutMaster_CheckedChanged);
      componentResourceManager.ApplyResources((object) this.checkBox1, "checkBox1");
      this.checkBox1.Checked = Settings.Default.UseTimeZone;
      this.checkBox1.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "UseTimeZone", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.checkBox1);
      this.Controls.Add((Control) this.groupBoxInternet);
      this.Controls.Add((Control) this.buttonLoadAntenna);
      this.Controls.Add((Control) this.buttonClubPrinter);
      this.Controls.Add((Control) this.groupBoxCalculationModule);
      this.Controls.Add((Control) this.checkBoxAntennaWithoutMaster);
      this.Controls.Add((Control) this.buttonLoadMaster);
      this.Controls.Add((Control) this.labelInfo);
      this.Controls.Add((Control) this.buttonStopComm);
      this.Controls.Add((Control) this.buttonReInitComm);
      this.Controls.Add((Control) this.groupBoxDatabase);
      this.Controls.Add((Control) this.groupBoxSerialPort);
      this.Controls.Add((Control) this.groupBoxLocalisation);
      this.Controls.Add((Control) this.groupBoxAutomaticUpdates);
      this.Name = nameof (OptionsPage);
      this.Load += new EventHandler(this.OptionsPage_Load);
      this.VisibleChanged += new EventHandler(this.OptionsPage_VisibleChanged);
      this.groupBoxAutomaticUpdates.ResumeLayout(false);
      this.groupBoxAutomaticUpdates.PerformLayout();
      this.groupBoxLocalisation.ResumeLayout(false);
      this.groupBoxLocalisation.PerformLayout();
      this.groupBoxSerialPort.ResumeLayout(false);
      this.groupBoxSerialPort.PerformLayout();
      this.trackBarTimeOut.EndInit();
      this.groupBoxDatabase.ResumeLayout(false);
      this.groupBoxDatabase.PerformLayout();
      this.numericUpDownAutoSave.EndInit();
      this.groupBoxCalculationModule.ResumeLayout(false);
      this.groupBoxCalculationModule.PerformLayout();
      this.groupBoxInternet.ResumeLayout(false);
      this.groupBoxInternet.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
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
