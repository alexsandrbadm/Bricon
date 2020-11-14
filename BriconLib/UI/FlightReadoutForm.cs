// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.FlightReadoutForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.BCE;
using BriconLib.Communications;
using BriconLib.Data;
using BriconLib.Other;
using BriconLib.PrintManager;
using BriconLib.Properties;
using MultiLang;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BriconLib.UI
{
  public class FlightReadoutForm : Form
  {
    private string _extension = ".xml";
    private DateTime _readoutTime = DateTime.Now;
    private IContainer components;
    private Label labelClubID;
    public TextBox textBoxClubID;
    private Label labelVluchtID;
    public TextBox textBoxFlightID;
    private Label labelFolder;
    public TextBox textBoxFolder;
    private Button buttonReadOut;
    private Button buttonCancel;
    private Button buttonFolder;
    private FolderBrowserDialog folderBrowserDialog1;
    private Label labelFileName;
    private Label labelUsedFileName;
    private Button buttonDelete;
    private Button buttonView;
    private ListView listView1;
    private ImageList imageList1;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private TabPage tabPage3;
    private DateTimePicker dateTimePicker1;
    private Label label1;
    private CheckBox checkBoxWinspeed;
    private NumericUpDown numericUpDownWeek;
    private Label labelWeeknbr;
    private Label labelFlightnr;
    private TextBox textBoxRaceIndex;
    private CheckBox checkBoxClkFormat;
    private Label labelTimeZoneHours;
    private Label labelTimeZone;
    private NumericUpDown numericUpDownTimeZone;

    public FlightReadoutForm() => this.InitializeComponent();

    private void buttonFolder_Click(object sender, EventArgs e)
    {
      if (this.folderBrowserDialog1.ShowDialog() != DialogResult.OK)
        return;
      this.textBoxFolder.Text = this.folderBrowserDialog1.SelectedPath;
    }

    private void textBoxFolder_TextChanged(object sender, EventArgs e) => this.labelUsedFileName.Text = this.BuildFileName();

    private string BuildFileName()
    {
      if (Utils.IsCountry("US") && this.checkBoxWinspeed.Checked)
      {
        this.numericUpDownWeek.Visible = true;
        this.labelWeeknbr.Visible = true;
        this.textBoxRaceIndex.Visible = true;
        this.labelFlightnr.Visible = true;
        return string.Format("c:\\Bricon\\Bricon{0}.txt", (object) this.numericUpDownWeek.Value.ToString().PadLeft(2, '0'));
      }
      this.numericUpDownWeek.Visible = false;
      this.labelWeeknbr.Visible = false;
      this.textBoxRaceIndex.Visible = false;
      this.labelFlightnr.Visible = false;
      return this.checkBoxClkFormat.Checked ? string.Format("{0}\\{1}\\{2}.clk", (object) this.textBoxFolder.Text.TrimEnd('\\', ' '), (object) this.dateTimePicker1.Value.ToString("dd_MM_yyyy"), (object) this._readoutTime.ToString("HH_mm_ss")) : string.Format("{0}\\ReadOut_{1}_{2}_{3}{4}", (object) this.textBoxFolder.Text.TrimEnd('\\', ' '), (object) this.textBoxClubID.Text, (object) this.textBoxFlightID.Text, (object) this.dateTimePicker1.Value.ToString("yyyy-MM-dd"), (object) this._extension);
    }

    private void WinSpeed(string flight, string club)
    {
      ReadOutDataSet readOut = new ReadOutDataSet();
      string path = this.BuildFileName();
      if (!new FlightsReadOut().ReadOut(readOut, club, flight, this.numericUpDownTimeZone.Value))
        return;
      if (!Directory.Exists("c:\\Bricon"))
        Directory.CreateDirectory("c:\\Bricon");
      DateTime dateTime;
      if (!File.Exists(path))
      {
        dateTime = this.dateTimePicker1.Value;
        string contents = string.Format("0{0}\n", (object) dateTime.ToString("ddMMyy"));
        File.WriteAllText(path, contents);
      }
      StringBuilder stringBuilder1 = new StringBuilder();
      foreach (ReadOutDataSet.FancierRow fancierRow in (TypedTableBase<ReadOutDataSet.FancierRow>) readOut.Fancier)
      {
        stringBuilder1.AppendFormat("1{0}{1}{2}{3}\n", (object) this.textBoxClubID.Text.PadLeft(4, '0').Substring(1, 3), (object) fancierRow.License.Replace("/", "").Replace("-", "").PadLeft(10, '0').Substring(7, 3), (object) readOut.Pigeons.Count.ToString().PadLeft(3, '0'), (object) fancierRow.Name.PadRight(20).Substring(0, 20));
        foreach (ReadOutDataSet.TimersRow timer in (TypedTableBase<ReadOutDataSet.TimersRow>) readOut.Timers)
        {
          StringBuilder stringBuilder2 = stringBuilder1;
          object[] objArray = new object[7];
          objArray[0] = (object) this.textBoxClubID.Text.PadLeft(4, '0').Substring(1, 3);
          objArray[1] = (object) fancierRow.License.Replace("/", "").Replace("-", "").PadLeft(10, '0').Substring(7, 3);
          dateTime = timer.BasketingMasterTime;
          objArray[2] = (object) dateTime.ToString("ddMM");
          dateTime = timer.BasketingMasterTime;
          objArray[3] = (object) dateTime.ToString("HHmmss");
          dateTime = timer.ReadOutMasterTime;
          objArray[4] = (object) dateTime.ToString("ddMM");
          dateTime = timer.ReadOutMasterTime;
          objArray[5] = (object) dateTime.ToString("HHmmss");
          dateTime = timer.ReadOutInternalTime;
          objArray[6] = (object) dateTime.ToString("HHmmss");
          stringBuilder2.AppendFormat("2{0}{1}1{2}{3}{4}{5}{6}\n", objArray);
        }
        foreach (ReadOutDataSet.PigeonsRow pigeon in (TypedTableBase<ReadOutDataSet.PigeonsRow>) readOut.Pigeons)
        {
          string str1 = pigeon.FedBand.Replace("-", "").PadRight(18, ' ').PadLeft(19, ' ');
          string str2 = str1.Substring(str1.Length - 4);
          string str3 = "C";
          if (str1.EndsWith("H" + str2))
            str3 = "H";
          stringBuilder1.AppendFormat("3{0}{1}{2}{3}{4}{5}00000000{6}{7}\n", (object) this.textBoxClubID.Text.PadLeft(4, '0').Substring(1, 3), (object) fancierRow.License.Replace("/", "").Replace("-", "").PadLeft(10, '0').Substring(7, 3), (object) (str1.Substring(1, 4) + " " + str1.Substring(5, 9) + str3), (object) this.textBoxRaceIndex.Text.PadLeft(2, '0').Substring(0, 2), pigeon.Evaluation == "1" ? (object) "1" : (object) "0", (object) pigeon.Time.ToString("ddMMHHmmss"), (object) "00000000000000000000", (object) str2);
        }
      }
      File.AppendAllText(path, stringBuilder1.ToString());
    }

    private void buttonReadOut_Click(object sender, EventArgs e)
    {
      try
      {
        CommunicationPool.Instance.FullStop();
        ReadOutDataSet dataSet = new ReadOutDataSet();
        AllFlightsReadOut allFlightsReadOut = new AllFlightsReadOut();
        string str1 = this.textBoxFlightID.Text;
        string str2 = this.textBoxClubID.Text;
        ReadOutDataSet readOut1 = dataSet;
        if (allFlightsReadOut.ReadOut(readOut1))
        {
          if (dataSet.Timers.Count == 0)
          {
            int num = (int) MessageBox.Show(ml.ml_string(610, "No races in ETS"));
            MainForm.Instance.backgroundCommunication.RunWorkerAsync();
            return;
          }
          if (dataSet.Timers.Select("ClubID = '" + this.textBoxClubID.Text + "' AND FlightID = '" + this.textBoxFlightID.Text + "'").Length == 0)
          {
            SelectRaceForm selectRaceForm = new SelectRaceForm(dataSet);
            if (selectRaceForm.ShowDialog() == DialogResult.Cancel)
            {
              MainForm.Instance.backgroundCommunication.RunWorkerAsync();
              return;
            }
            str2 = selectRaceForm.ActiveRow.ClubID;
            str1 = selectRaceForm.ActiveRow.FlightID;
          }
          if (Utils.IsCountry("US") && this.checkBoxWinspeed.Checked)
            this.WinSpeed(str1, str2);
          else if (this.checkBoxClkFormat.Checked)
          {
            this.ClkReadout(str1, str2);
          }
          else
          {
            ReadOutDataSet readOut2 = new ReadOutDataSet();
            string str3 = this.BuildFileName();
            if (File.Exists(str3))
            {
              if (!File.ReadAllText(str3).StartsWith("<"))
              {
                BCEDatabase.DecryptFile(str3, str3 + "tmp");
                int num = (int) readOut2.ReadXml(str3 + "tmp");
                File.Delete(str3 + "tmp");
              }
              else
              {
                int num1 = (int) readOut2.ReadXml(str3);
              }
            }
            Thread.Sleep(1000);
            if (new FlightsReadOut().ReadOut(readOut2, str2, str1, this.numericUpDownTimeZone.Value))
            {
              if (!Directory.Exists(this.textBoxFolder.Text))
                Directory.CreateDirectory(this.textBoxFolder.Text);
              if (Utils.EncryptReadouts())
              {
                readOut2.WriteXml(str3 + "tmp");
                BCEDatabase.EncryptFile(str3 + "tmp", str3);
                File.Delete(str3 + "tmp");
              }
              else
                readOut2.WriteXml(str3);
              this.RefreshFileList();
            }
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
      MainForm.Instance.backgroundCommunication.RunWorkerAsync();
    }

    private void ClkReadout(string flight, string club)
    {
      ReadOutDataSet readOut = new ReadOutDataSet();
      string path = this.BuildFileName();
      if (!new FlightsReadOut().ReadOut(readOut, club, flight, this.numericUpDownTimeZone.Value) || ActivateBACommand.LastDataRecord == null || GetFancierCommand.LastDataRecord == null)
        return;
      if (!Directory.Exists(this.textBoxFolder.Text))
        Directory.CreateDirectory(this.textBoxFolder.Text);
      if (!Directory.Exists(Path.GetDirectoryName(path)))
        Directory.CreateDirectory(Path.GetDirectoryName(path));
      using (FileStream fileStream = File.Open(path, FileMode.Append, FileAccess.Write))
      {
        fileStream.Write(ActivateBACommand.LastDataRecord, 0, ActivateBACommand.LastDataRecord.Length);
        for (int length = ActivateBACommand.LastDataRecord.Length; length < 128; ++length)
          fileStream.WriteByte((byte) 0);
        fileStream.Write(GetFancierCommand.LastDataRecord, 0, GetFancierCommand.LastDataRecord.Length);
        for (int length = GetFancierCommand.LastDataRecord.Length; length < 128; ++length)
          fileStream.WriteByte((byte) 0);
        fileStream.WriteByte((byte) GetTimerCommand.LastDataRecords.Count);
        for (int index1 = 0; index1 < GetTimerCommand.LastDataRecords.Count; ++index1)
        {
          fileStream.Write(GetTimerCommand.LastDataRecords[index1], 1, GetTimerCommand.LastDataRecords[index1].Length - 1);
          for (int index2 = GetTimerCommand.LastDataRecords[index1].Length - 1; index2 < 128; ++index2)
            fileStream.WriteByte((byte) 0);
        }
        fileStream.WriteByte((byte) (GetPigeonCommand.LastDataRecords.Count >> 8));
        fileStream.WriteByte((byte) (GetPigeonCommand.LastDataRecords.Count & (int) byte.MaxValue));
        for (int index1 = 0; index1 < GetPigeonCommand.LastDataRecords.Count; ++index1)
        {
          fileStream.Write(GetPigeonCommand.LastDataRecords[index1], 2, GetPigeonCommand.LastDataRecords[index1].Length - 2);
          for (int index2 = GetPigeonCommand.LastDataRecords[index1].Length - 2; index2 < 128; ++index2)
            fileStream.WriteByte((byte) 0);
        }
      }
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void FlightReadoutForm_Load(object sender, EventArgs e)
    {
      if (Utils.IsCountry("KSA") && this.checkBoxClkFormat.Checked)
        this.textBoxFolder.Text = "c:\\clockup";
      this.checkBoxWinspeed.Visible = Utils.IsCountry("US");
      TextBox textBoxFolder = this.textBoxFolder;
      textBoxFolder.Text = textBoxFolder.Text + "\\" + DateTime.Now.Year.ToString();
      this.textBoxClubID.Text = MainForm.Instance.clubsPage.GetActiveClubRow().ClubID;
      this.textBoxFolder_TextChanged(sender, e);
      this.RefreshFileList();
      this.dateTimePicker1.Value = DateTime.Now;
      this.checkBoxWinspeed_CheckedChanged(sender, e);
      this.numericUpDownTimeZone.Value = !Settings.Default.UseTimeZone ? 0M : Convert.ToDecimal(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).TotalHours);
      this.labelTimeZone.Visible = Settings.Default.UseTimeZone;
      this.numericUpDownTimeZone.Visible = Settings.Default.UseTimeZone;
      this.labelTimeZoneHours.Visible = Settings.Default.UseTimeZone;
    }

    private void buttonDelete_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(ml.ml_string(455, "This will delete the selected ReadOut, are you sure?"), ml.ml_string(23, "Delete"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
        return;
      foreach (ListViewItem selectedItem in this.listView1.SelectedItems)
        File.Delete(this.textBoxFolder.Text + "\\" + selectedItem.Text + this._extension);
      this.RefreshFileList();
    }

    private void RefreshFileList()
    {
      this.listView1.Clear();
      if (!Directory.Exists(this.textBoxFolder.Text))
        Directory.CreateDirectory(this.textBoxFolder.Text);
      foreach (string file in Directory.GetFiles(this.textBoxFolder.Text + "\\", "*" + this._extension))
        this.listView1.Items.Add(Path.GetFileNameWithoutExtension(file)).ImageIndex = 0;
      this.listView1.SelectedItems.Clear();
      if (this.listView1.Items.Count <= 0)
        return;
      this.listView1.SelectedIndices.Add(this.listView1.Items.Count - 1);
    }

    private void buttonView_Click(object sender, EventArgs e)
    {
      foreach (ListViewItem selectedItem in this.listView1.SelectedItems)
      {
        int num = (int) new ViewDataForm(this.textBoxFolder.Text + "\\" + selectedItem.Text + this._extension).ShowDialog();
      }
      this.RefreshFileList();
    }

    private void tabPage1_Enter(object sender, EventArgs e) => this.RefreshFileList();

    private void dateTimePicker1_ValueChanged(object sender, EventArgs e) => this.textBoxFolder_TextChanged(sender, e);

    private void listView1_MouseDoubleClick(object sender, MouseEventArgs e) => this.buttonView_Click(sender, (EventArgs) e);

    private void checkBoxWinspeed_CheckedChanged(object sender, EventArgs e) => this.labelUsedFileName.Text = this.BuildFileName();

    private void numericUpDownWeek_ValueChanged(object sender, EventArgs e) => this.labelUsedFileName.Text = this.BuildFileName();

    private void checkBoxClkFormat_CheckedChanged(object sender, EventArgs e)
    {
      if (Utils.IsCountry("KSA") && this.checkBoxClkFormat.Checked)
      {
        if (this.textBoxFolder.Text.StartsWith("c:\\ReadOuts"))
          this.textBoxFolder.Text = "c:\\clockup";
      }
      else if (this.textBoxFolder.Text.StartsWith("c:\\clockup"))
        this.textBoxFolder.Text = "c:\\ReadOuts";
      this.labelUsedFileName.Text = this.BuildFileName();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FlightReadoutForm));
      this.labelClubID = new Label();
      this.textBoxClubID = new TextBox();
      this.labelVluchtID = new Label();
      this.labelFolder = new Label();
      this.textBoxFolder = new TextBox();
      this.buttonReadOut = new Button();
      this.buttonCancel = new Button();
      this.buttonFolder = new Button();
      this.labelFileName = new Label();
      this.labelUsedFileName = new Label();
      this.buttonDelete = new Button();
      this.buttonView = new Button();
      this.listView1 = new ListView();
      this.imageList1 = new ImageList(this.components);
      this.tabControl1 = new TabControl();
      this.tabPage2 = new TabPage();
      this.labelTimeZoneHours = new Label();
      this.labelTimeZone = new Label();
      this.numericUpDownTimeZone = new NumericUpDown();
      this.checkBoxClkFormat = new CheckBox();
      this.textBoxRaceIndex = new TextBox();
      this.labelFlightnr = new Label();
      this.numericUpDownWeek = new NumericUpDown();
      this.checkBoxWinspeed = new CheckBox();
      this.dateTimePicker1 = new DateTimePicker();
      this.labelWeeknbr = new Label();
      this.label1 = new Label();
      this.textBoxFlightID = new TextBox();
      this.tabPage1 = new TabPage();
      this.tabPage3 = new TabPage();
      this.folderBrowserDialog1 = new FolderBrowserDialog();
      this.tabControl1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.numericUpDownTimeZone.BeginInit();
      this.numericUpDownWeek.BeginInit();
      this.tabPage1.SuspendLayout();
      this.tabPage3.SuspendLayout();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.labelClubID, "labelClubID");
      this.labelClubID.Name = "labelClubID";
      componentResourceManager.ApplyResources((object) this.textBoxClubID, "textBoxClubID");
      this.textBoxClubID.Name = "textBoxClubID";
      this.textBoxClubID.TextChanged += new EventHandler(this.textBoxFolder_TextChanged);
      componentResourceManager.ApplyResources((object) this.labelVluchtID, "labelVluchtID");
      this.labelVluchtID.Name = "labelVluchtID";
      componentResourceManager.ApplyResources((object) this.labelFolder, "labelFolder");
      this.labelFolder.Name = "labelFolder";
      componentResourceManager.ApplyResources((object) this.textBoxFolder, "textBoxFolder");
      this.textBoxFolder.Name = "textBoxFolder";
      this.textBoxFolder.TabStop = false;
      this.textBoxFolder.TextChanged += new EventHandler(this.textBoxFolder_TextChanged);
      componentResourceManager.ApplyResources((object) this.buttonReadOut, "buttonReadOut");
      this.buttonReadOut.Name = "buttonReadOut";
      this.buttonReadOut.TabStop = false;
      this.buttonReadOut.UseVisualStyleBackColor = true;
      this.buttonReadOut.Click += new EventHandler(this.buttonReadOut_Click);
      componentResourceManager.ApplyResources((object) this.buttonCancel, "buttonCancel");
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.TabStop = false;
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      componentResourceManager.ApplyResources((object) this.buttonFolder, "buttonFolder");
      this.buttonFolder.Name = "buttonFolder";
      this.buttonFolder.TabStop = false;
      this.buttonFolder.UseVisualStyleBackColor = true;
      this.buttonFolder.Click += new EventHandler(this.buttonFolder_Click);
      componentResourceManager.ApplyResources((object) this.labelFileName, "labelFileName");
      this.labelFileName.Name = "labelFileName";
      componentResourceManager.ApplyResources((object) this.labelUsedFileName, "labelUsedFileName");
      this.labelUsedFileName.Name = "labelUsedFileName";
      componentResourceManager.ApplyResources((object) this.buttonDelete, "buttonDelete");
      this.buttonDelete.Name = "buttonDelete";
      this.buttonDelete.TabStop = false;
      this.buttonDelete.UseVisualStyleBackColor = true;
      this.buttonDelete.Click += new EventHandler(this.buttonDelete_Click);
      componentResourceManager.ApplyResources((object) this.buttonView, "buttonView");
      this.buttonView.Name = "buttonView";
      this.buttonView.TabStop = false;
      this.buttonView.UseVisualStyleBackColor = true;
      this.buttonView.Click += new EventHandler(this.buttonView_Click);
      componentResourceManager.ApplyResources((object) this.listView1, "listView1");
      this.listView1.FullRowSelect = true;
      this.listView1.HideSelection = false;
      this.listView1.Items.AddRange(new ListViewItem[1]
      {
        (ListViewItem) componentResourceManager.GetObject("listView1.Items")
      });
      this.listView1.MultiSelect = false;
      this.listView1.Name = "listView1";
      this.listView1.SmallImageList = this.imageList1;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = View.List;
      this.listView1.MouseDoubleClick += new MouseEventHandler(this.listView1_MouseDoubleClick);
      this.imageList1.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageList1.ImageStream");
      this.imageList1.TransparentColor = Color.Fuchsia;
      this.imageList1.Images.SetKeyName(0, "FromBA.bmp");
      this.imageList1.Images.SetKeyName(1, "Delete.bmp");
      this.imageList1.Images.SetKeyName(2, "EditInformation.bmp");
      this.imageList1.Images.SetKeyName(3, "Properties.bmp");
      this.imageList1.Images.SetKeyName(4, "Help.bmp");
      this.imageList1.Images.SetKeyName(5, "Print.bmp");
      this.imageList1.Images.SetKeyName(6, "CriticalError.bmp");
      componentResourceManager.ApplyResources((object) this.tabControl1, "tabControl1");
      this.tabControl1.Controls.Add((Control) this.tabPage2);
      this.tabControl1.Controls.Add((Control) this.tabPage1);
      this.tabControl1.Controls.Add((Control) this.tabPage3);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabPage2.Controls.Add((Control) this.labelTimeZoneHours);
      this.tabPage2.Controls.Add((Control) this.labelTimeZone);
      this.tabPage2.Controls.Add((Control) this.numericUpDownTimeZone);
      this.tabPage2.Controls.Add((Control) this.checkBoxClkFormat);
      this.tabPage2.Controls.Add((Control) this.textBoxRaceIndex);
      this.tabPage2.Controls.Add((Control) this.labelFlightnr);
      this.tabPage2.Controls.Add((Control) this.numericUpDownWeek);
      this.tabPage2.Controls.Add((Control) this.checkBoxWinspeed);
      this.tabPage2.Controls.Add((Control) this.dateTimePicker1);
      this.tabPage2.Controls.Add((Control) this.buttonReadOut);
      this.tabPage2.Controls.Add((Control) this.labelClubID);
      this.tabPage2.Controls.Add((Control) this.labelWeeknbr);
      this.tabPage2.Controls.Add((Control) this.label1);
      this.tabPage2.Controls.Add((Control) this.labelVluchtID);
      this.tabPage2.Controls.Add((Control) this.labelFileName);
      this.tabPage2.Controls.Add((Control) this.textBoxFlightID);
      this.tabPage2.Controls.Add((Control) this.textBoxClubID);
      this.tabPage2.Controls.Add((Control) this.labelUsedFileName);
      componentResourceManager.ApplyResources((object) this.tabPage2, "tabPage2");
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.labelTimeZoneHours, "labelTimeZoneHours");
      this.labelTimeZoneHours.Name = "labelTimeZoneHours";
      componentResourceManager.ApplyResources((object) this.labelTimeZone, "labelTimeZone");
      this.labelTimeZone.Name = "labelTimeZone";
      this.numericUpDownTimeZone.DecimalPlaces = 1;
      componentResourceManager.ApplyResources((object) this.numericUpDownTimeZone, "numericUpDownTimeZone");
      this.numericUpDownTimeZone.Maximum = new Decimal(new int[4]
      {
        23,
        0,
        0,
        0
      });
      this.numericUpDownTimeZone.Minimum = new Decimal(new int[4]
      {
        23,
        0,
        0,
        int.MinValue
      });
      this.numericUpDownTimeZone.Name = "numericUpDownTimeZone";
      componentResourceManager.ApplyResources((object) this.checkBoxClkFormat, "checkBoxClkFormat");
      this.checkBoxClkFormat.Checked = Settings.Default.CLKFormatChecked;
      this.checkBoxClkFormat.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "CLKFormatChecked", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBoxClkFormat.Name = "checkBoxClkFormat";
      this.checkBoxClkFormat.UseVisualStyleBackColor = true;
      this.checkBoxClkFormat.CheckedChanged += new EventHandler(this.checkBoxClkFormat_CheckedChanged);
      this.textBoxRaceIndex.DataBindings.Add(new Binding("Text", (object) Settings.Default, "RaceIndexText", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBoxRaceIndex, "textBoxRaceIndex");
      this.textBoxRaceIndex.Name = "textBoxRaceIndex";
      this.textBoxRaceIndex.Text = Settings.Default.RaceIndexText;
      componentResourceManager.ApplyResources((object) this.labelFlightnr, "labelFlightnr");
      this.labelFlightnr.Name = "labelFlightnr";
      this.numericUpDownWeek.DataBindings.Add(new Binding("Value", (object) Settings.Default, "WinspeedWeek", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.numericUpDownWeek, "numericUpDownWeek");
      this.numericUpDownWeek.Maximum = new Decimal(new int[4]
      {
        99,
        0,
        0,
        0
      });
      this.numericUpDownWeek.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDownWeek.Name = "numericUpDownWeek";
      this.numericUpDownWeek.Value = Settings.Default.WinspeedWeek;
      this.numericUpDownWeek.ValueChanged += new EventHandler(this.numericUpDownWeek_ValueChanged);
      componentResourceManager.ApplyResources((object) this.checkBoxWinspeed, "checkBoxWinspeed");
      this.checkBoxWinspeed.Checked = Settings.Default.WinspeedFormat;
      this.checkBoxWinspeed.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "WinspeedFormat", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBoxWinspeed.Name = "checkBoxWinspeed";
      this.checkBoxWinspeed.UseVisualStyleBackColor = true;
      this.checkBoxWinspeed.CheckedChanged += new EventHandler(this.checkBoxWinspeed_CheckedChanged);
      this.dateTimePicker1.Format = DateTimePickerFormat.Short;
      componentResourceManager.ApplyResources((object) this.dateTimePicker1, "dateTimePicker1");
      this.dateTimePicker1.Name = "dateTimePicker1";
      this.dateTimePicker1.Value = new DateTime(2008, 4, 10, 0, 0, 0, 0);
      this.dateTimePicker1.ValueChanged += new EventHandler(this.dateTimePicker1_ValueChanged);
      componentResourceManager.ApplyResources((object) this.labelWeeknbr, "labelWeeknbr");
      this.labelWeeknbr.Name = "labelWeeknbr";
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      this.textBoxFlightID.CharacterCasing = CharacterCasing.Upper;
      this.textBoxFlightID.DataBindings.Add(new Binding("Text", (object) Settings.Default, "FlightID", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBoxFlightID, "textBoxFlightID");
      this.textBoxFlightID.Name = "textBoxFlightID";
      this.textBoxFlightID.Text = Settings.Default.FlightID;
      this.textBoxFlightID.TextChanged += new EventHandler(this.textBoxFolder_TextChanged);
      this.tabPage1.Controls.Add((Control) this.listView1);
      this.tabPage1.Controls.Add((Control) this.buttonDelete);
      this.tabPage1.Controls.Add((Control) this.buttonView);
      componentResourceManager.ApplyResources((object) this.tabPage1, "tabPage1");
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.UseVisualStyleBackColor = true;
      this.tabPage1.Enter += new EventHandler(this.tabPage1_Enter);
      this.tabPage3.Controls.Add((Control) this.textBoxFolder);
      this.tabPage3.Controls.Add((Control) this.buttonFolder);
      this.tabPage3.Controls.Add((Control) this.labelFolder);
      componentResourceManager.ApplyResources((object) this.tabPage3, "tabPage3");
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.folderBrowserDialog1, "folderBrowserDialog1");
      this.folderBrowserDialog1.SelectedPath = Settings.Default.OutputFolder;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonCancel;
      this.Controls.Add((Control) this.tabControl1);
      this.Controls.Add((Control) this.buttonCancel);
      this.Name = nameof (FlightReadoutForm);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.Load += new EventHandler(this.FlightReadoutForm_Load);
      this.tabControl1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.numericUpDownTimeZone.EndInit();
      this.numericUpDownWeek.EndInit();
      this.tabPage1.ResumeLayout(false);
      this.tabPage3.ResumeLayout(false);
      this.tabPage3.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
