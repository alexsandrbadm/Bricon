// Decompiled with JetBrains decompiler
// Type: BriconLib.PrintManager.MonitorForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.BriconWeb;
using BriconLib.Monitor;
using BriconLib.Other;
using BriconLib.Properties;
using BriconLib.Sounds;
using CoreLib.Helpers;
using MultiLang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace BriconLib.PrintManager
{
  public class MonitorForm : Form
  {
    private SerialPort _serialPort;
    private List<PigeonCommand> _pigeons = new List<PigeonCommand>();
    private List<RaceCommand> _races = new List<RaceCommand>();
    private StatusCommand _status;
    private FancierCommand _fancier;
    private string license;
    private bool _idleMode = true;
    private int _comportIndex;
    private const int MAXMISSES = 20;
    private int _BAMissedCommands = 20;
    private DateTime _lastTimeBeeped = DateTime.Now;
    private byte[] _receivedBytes = new byte[0];
    private bool _pigeonDataChanged;
    private bool _timerRefreshBriconWebBusy;
    private bool _timerRefreshBriconWebBusy2;
    private bool _raceDataChanged;
    private bool _fancierDataChanged;
    private bool _statusDataChanged;
    private bool _initModus = true;
    private int _lastPigeonCount;
    private int _deletedRaces;
    private bool _forceSendMail;
    private System.Timers.Timer _idleModeTimer;
    private NetworkMessaging _networkMessaging;
    private int _lastCountForBriconWeb;
    private bool _BriconWebDisabled;
    private bool _firstTime = true;
    private bool _networkMode = true;
    private bool _noSpeedRefresh;
    private DateTime _lastRefreshFromBriconWeb = DateTime.Now;
    private DateTime _lastFlightRefreshFromBriconWeb = DateTime.Now;
    private StringBuilder _emailAllPigeons = new StringBuilder();
    private StringBuilder _emailClockedPigeons;
    private WebServer _ws;
    private readonly Queue<PigeonCommand> _briconWebBuffer = new Queue<PigeonCommand>();
    private IContainer components;
    private ImageList imageList1;
    private Label label3;
    private Label label4;
    private Button buttonOptions;
    private ImageList imageList2;
    private DataGridView dataGridView1;
    private System.Windows.Forms.Timer timerAskStatus;
    private Label labelAntennaCount;
    private Label labelStatus;
    private Label label5;
    private Label labelPigeonCount;
    private Label label7;
    private Label labelRaceCount;
    private Label label6;
    private Label label8;
    private Label labelLicense;
    private Label labelName;
    private Button buttonExit;
    private System.Windows.Forms.Timer timerRefresh;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private GroupBox groupBox3;
    private DataGridView dataGridView2;
    private ProgressBar progressBar1;
    private Label label1;
    private PictureBox pictureBox1;
    private ImageList imageList3;
    private System.Windows.Forms.Timer timerSendEmailStarter;
    private System.Windows.Forms.Timer timerEndEdit;
    private Button buttonSendMail;
    private Button buttonRefresh;
    private Button buttonClockFakePigeon;
    private Button buttonBriconWeb;
    private Button buttonPrint;
    private System.Windows.Forms.Timer timerRefreshBriconWeb;
    private DataGridViewTextBoxColumn Pos;
    private DataGridViewTextBoxColumn Ringnumber;
    private DataGridViewTextBoxColumn Time;
    private DataGridViewTextBoxColumn Race;
    private DataGridViewTextBoxColumn O;
    private DataGridViewTextBoxColumn X;
    private DataGridViewTextBoxColumn Y;
    private DataGridViewTextBoxColumn Antenna;
    private DataGridViewTextBoxColumn Speed;
    private DataGridViewTextBoxColumn Distance;
    private DataGridViewTextBoxColumn Speed2;
    private DataGridViewTextBoxColumn EnterPositionClub;
    private DataGridViewTextBoxColumn Club;
    private DataGridViewTextBoxColumn Provencial;
    private DataGridViewTextBoxColumn National;
    private GroupBox groupBoxTotals;
    private Label labelCountYoungs;
    private Label labelTotalYoungs;
    private Label labelCountYearlings;
    private Label labelCountOld;
    private Label labelTotalYearlings;
    private Label labelTotalOld;
    private DataGridViewCheckBoxColumn ShowColumn;
    private DataGridViewTextBoxColumn PigeonCountColumn;
    private DataGridViewTextBoxColumn NameColumn;
    private DataGridViewTextBoxColumn ClubColumn;
    private CalendarColumn DateColumn;
    private TimeColumn TimeColumn;
    private DataGridViewTextBoxColumn DistanceColumn;
    private DataGridViewTextBoxColumn Yards;
    private DataGridViewCheckBoxColumn MailColumn;
    private DataGridViewCheckBoxColumn Mail2Column;
    private DataGridViewCheckBoxColumn PigCloud;
    private DataGridViewCheckBoxColumn BriconWebColumn;
    private DataGridViewCheckBoxColumn PlaySoundColumn;
    private DataGridViewTextBoxColumn SpeedColumn;
    private System.Windows.Forms.Timer timerNoSpeedRefresh;
    private ImageList imageList4;
    private Button buttonUploadReadout;

    public MonitorForm()
    {
      Settings.Default.SendMonitorDataToBW = true;
      this._ws = new WebServer(this);
      this._ws.Start();
      MonitorForm.Log = new StringBuilder();
      this.InitializeComponent();
      this.dataGridView2.AutoGenerateColumns = false;
      this.dataGridView2.DataError += new DataGridViewDataErrorEventHandler(this.dataGridView2_DataError);
      RaceCommand raceCommand = new RaceCommand((byte[]) null);
      this.ClearRaces();
      this._raceDataChanged = true;
      this.groupBoxTotals.Visible = Settings.Default.ShowTotalsPerCategory;
      this._lastTimeBeeped = DateTime.Now;
      if (Utils.IsCountry("UK"))
      {
        this.O.HeaderText = "AA";
        this.X.HeaderText = "YL";
        this.Y.HeaderText = "YB";
      }
      if (!Utils.IsCountry("RO") && !Utils.IsCountry("MD"))
        return;
      this.buttonUploadReadout.Visible = true;
    }

    public string GetDataForWebserver()
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      if (this._fancier != null)
        stringBuilder1.AppendLine(string.Join("|", new string[6]
        {
          "Fancier",
          ml.ml_string(846, "Fancier"),
          ml.ml_string(1186, "License:"),
          this._fancier.License,
          ml.ml_string(37, "Name:"),
          this._fancier.Name
        }));
      else
        stringBuilder1.AppendLine(string.Join("|", new string[6]
        {
          "Fancier",
          "",
          "",
          "",
          "",
          ""
        }));
      int num1;
      if (this._status != null)
      {
        StringBuilder stringBuilder2 = stringBuilder1;
        string[] strArray = new string[8];
        strArray[0] = "Status";
        strArray[1] = "green";
        strArray[2] = ml.ml_string(1185, "Clocked:");
        int num2 = this._status.PigeonCount;
        strArray[3] = num2.ToString();
        strArray[4] = ml.ml_string(1187, "Races:");
        num2 = this._status.RaceCount;
        strArray[5] = num2.ToString();
        strArray[6] = ml.ml_string(1184, "Antennas:");
        num1 = this._status.AntennaCount;
        strArray[7] = num1.ToString();
        string str = string.Join("|", strArray);
        stringBuilder2.AppendLine(str);
      }
      else
        stringBuilder1.AppendLine(string.Join("|", new string[8]
        {
          "Status",
          "red",
          ml.ml_string(890, "No response"),
          "",
          "",
          "",
          "",
          ""
        }));
      stringBuilder1.AppendLine(string.Join("|", new string[9]
      {
        "Race",
        ml.ml_string(884, "Show"),
        ml.ml_string(937, "#"),
        ml.ml_string(867, "Race"),
        ml.ml_string(1183, "Club ID"),
        ml.ml_string(1172, "Release Date"),
        ml.ml_string(931, "Distance"),
        ml.ml_string(1182, "E-mail"),
        ml.ml_string(908, "Web")
      }));
      foreach (RaceCommand race in this._races)
      {
        StringBuilder stringBuilder2 = stringBuilder1;
        string[] strArray = new string[9];
        strArray[0] = "Race";
        strArray[1] = race.Show ? "X" : "";
        num1 = race.PigeonCount;
        strArray[2] = num1.ToString();
        strArray[3] = race.RaceName;
        strArray[4] = race.ClubID;
        DateTime releaseDate = race.ReleaseDate;
        string shortDateString = releaseDate.ToShortDateString();
        releaseDate = race.ReleaseDate;
        string shortTimeString = releaseDate.ToShortTimeString();
        strArray[5] = shortDateString + " " + shortTimeString;
        num1 = race.DistanceInMeter;
        strArray[6] = num1.ToString();
        bool flag = race.Email;
        strArray[7] = flag.ToString();
        flag = race.ActiveInBriconWeb;
        strArray[8] = flag.ToString();
        string str = string.Join("|", strArray);
        stringBuilder2.AppendLine(str);
      }
      stringBuilder1.AppendLine(string.Join("|", new string[13]
      {
        "Pigeon",
        ml.ml_string(239, "Nbr"),
        ml.ml_string(558, "RingNumber"),
        ml.ml_string(924, "Time"),
        ml.ml_string(867, "Race"),
        ml.ml_string(1173, "Old"),
        ml.ml_string(1174, "Year"),
        ml.ml_string(1175, "Young"),
        ml.ml_string(1176, "Antenna"),
        ml.ml_string(870, "Velocity"),
        ml.ml_string(1177, "Speed2"),
        ml.ml_string(1178, "A C"),
        ml.ml_string(1179, "E C")
      }));
      foreach (PigeonCommand pigeon in this._pigeons)
      {
        if (this._races[pigeon.RaceIndex + 1].Show)
        {
          StringBuilder stringBuilder2 = stringBuilder1;
          string[] strArray = new string[13];
          strArray[0] = "Pigeon";
          int num2 = pigeon.Pos;
          strArray[1] = num2.ToString();
          strArray[2] = pigeon.DBRing;
          strArray[3] = pigeon.Time;
          strArray[4] = pigeon.RaceName;
          num2 = pigeon.Old;
          strArray[5] = num2.ToString();
          num2 = pigeon.Year;
          strArray[6] = num2.ToString();
          num2 = pigeon.Young;
          strArray[7] = num2.ToString();
          num2 = pigeon.Antenna;
          strArray[8] = num2.ToString();
          strArray[9] = pigeon.Speed.ToString();
          strArray[10] = pigeon.Speed2.ToString();
          num2 = pigeon.ArrivePositionClub;
          strArray[11] = num2.ToString();
          num2 = pigeon.EnterPositionClub;
          strArray[12] = num2.ToString();
          string str = string.Join("|", strArray);
          stringBuilder2.AppendLine(str);
        }
      }
      return stringBuilder1.ToString().Replace("\r\n", "<br>");
    }

    private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e) => this.logit("Error in datagrid : " + e.Exception.ToString());

    public static StringBuilder Log { get; set; }

    public bool IdleMode
    {
      set
      {
        this._idleMode = value;
        if (this._idleMode)
          return;
        if (this._idleModeTimer != null)
          this._idleModeTimer.Dispose();
        this._idleModeTimer = new System.Timers.Timer(5000.0);
        this._idleModeTimer.Elapsed += new ElapsedEventHandler(this._idleModeTimer_Elapsed);
        this._idleModeTimer.Start();
      }
      get => this._idleMode;
    }

    private void _idleModeTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
      this._status = (StatusCommand) null;
      this._fancier = (FancierCommand) null;
      this.IdleMode = true;
      this._BAMissedCommands = 20;
      this._statusDataChanged = true;
      this._idleModeTimer.Dispose();
    }

    private void MonitorForm_Load(object sender, EventArgs e)
    {
      BriconWebHelper.TestConnection();
      this.InitComport();
      this.dataGridView1.AutoGenerateColumns = false;
      this.pictureBox1.Image = !Utils.IsCountry("UK") ? this.imageList3.Images["BAExtreme.bmp"] : this.imageList4.Images["BASPX.bmp"];
      this._networkMessaging = new NetworkMessaging();
      this._networkMessaging.OnMessage += new MessageReceivedEventHandler(this._networkMessaging_OnMessage);
      this.timerRefreshBriconWeb.Interval = 3000;
      this.timerRefreshBriconWeb.Start();
      this.Yards.Visible = Utils.IsCountry("UK");
      if (Utils.IsCountry("UK"))
      {
        this.Distance.HeaderText = "Miles";
        this.Distance.ToolTipText = "Distance in Miles";
      }
      this.SetEmail2Column();
      this.SetPigeonCloudColumn();
    }

    private void SetEmail2Column()
    {
      Settings.Default.SendToOmar = false;
      Settings.Default.SendToPitts = false;
      if (Settings.Default.SendToPipa || Settings.Default.SendToPitts || Settings.Default.SendToOmar || Settings.Default.SendToCompuClub && Utils.IsCountry("NL"))
      {
        this.Mail2Column.Visible = true;
        if (Utils.IsCountry("NL"))
        {
          if (Settings.Default.SendToCompuClub && Settings.Default.SendToPipa)
            this.Mail2Column.HeaderText = "CC & Pipa";
          else if (Settings.Default.SendToCompuClub)
            this.Mail2Column.HeaderText = "CC";
          else
            this.Mail2Column.HeaderText = "Pipa";
        }
        else if (Settings.Default.SendToOmar)
        {
          this.Mail2Column.HeaderText = "Omar";
          if (Settings.Default.SendToPipa)
            this.Mail2Column.HeaderText = "Pipa & O";
          if (Settings.Default.SendToPitts)
            this.Mail2Column.HeaderText = "Pitts & O";
          if (!Settings.Default.SendToPipa || !Settings.Default.SendToPitts)
            return;
          this.Mail2Column.HeaderText = "P & P & O";
        }
        else
        {
          if (Settings.Default.SendToPipa)
            this.Mail2Column.HeaderText = "Pipa";
          if (Settings.Default.SendToPitts)
            this.Mail2Column.HeaderText = "Pitts";
          if (!Settings.Default.SendToPipa || !Settings.Default.SendToPitts)
            return;
          this.Mail2Column.HeaderText = "P & P";
        }
      }
      else
        this.Mail2Column.Visible = false;
    }

    private void SetPigeonCloudColumn() => this.PigCloud.Visible = Settings.Default.SendToPigeonCloud && Utils.IsCountry("NL");

    private void UpdateFlightsFromBriconWeb()
    {
      try
      {
        if (this._BriconWebDisabled || this._status == null || this._races.Count == this._lastCountForBriconWeb || (this._races.Count<RaceCommand>((Func<RaceCommand, bool>) (e => !e.RaceIsDeleted)) != this._status.RaceCount + 1 || !(Settings.Default.LoginBriconWeb != "") || !(Settings.Default.PasswordBriconWeb != "")))
          return;
        this._lastCountForBriconWeb = this._races.Count;
        this.logit("BriconWeb.GetFlights\r\n");
        if (BriconWebHelper.GetFlights(this._races) || BriconWebHelper.GetFlights(this._races) || BriconWebHelper.GetFlights(this._races))
        {
          this.BriconWebColumn.Visible = true;
          Utils.LogErrorToBWLog("BriconWebColumn.Visible = true");
          List<RaceCommand> raceCommandList = new List<RaceCommand>();
          foreach (RaceCommand race in this._races)
          {
            if (!race.RaceIsDeleted)
              raceCommandList.Add(race);
          }
          this.dataGridView2.DataSource = (object) new List<RaceCommand>();
          this.dataGridView2.DataSource = (object) raceCommandList;
        }
        else
        {
          this.BriconWebColumn.Visible = false;
          Utils.LogErrorToBWLog("BriconWebColumn.Visible = false");
        }
      }
      catch (FileNotFoundException ex)
      {
        Utils.LogErrorToBWLog("_BriconWebDisabled = true");
        this._BriconWebDisabled = true;
        int num = (int) MessageBox.Show(ml.ml_string(977, "This functionality requires Microsoft .NET 3.0. You can find it at http://www.microsoft.com/download/en/details.aspx?id=31"));
      }
    }

    private void _networkMessaging_OnMessage(string message)
    {
    }

    private void SendDataToNetWork(byte[] receivedData)
    {
    }

    private void InitComport()
    {
      this.CloseComPort();
      string[] strArray;
      if (Settings.Default.ComPort != "Auto")
        strArray = new string[1]{ Settings.Default.ComPort };
      else
        strArray = SerialPort.GetPortNames();
      if (strArray.Length == 0)
        return;
      if (this._comportIndex >= strArray.Length)
        this._comportIndex = 0;
      try
      {
        this._serialPort = new SerialPort(strArray[this._comportIndex], 9600, Parity.None, 8, StopBits.Two);
        this._serialPort.DataReceived += new SerialDataReceivedEventHandler(this._serialPort_DataReceived);
        this._serialPort.Open();
        this._serialPort.ReadTimeout = 150;
        this._serialPort.RtsEnable = true;
        this.logit("Port opened : " + strArray[this._comportIndex] + "\r\n");
        this.timerAskStatus.Enabled = true;
      }
      catch (Exception ex)
      {
        this.logit("Port could not be opened : " + strArray[this._comportIndex] + "\r\n");
        this.CloseComPort();
      }
      ++this._comportIndex;
    }

    private void CloseComPort()
    {
      try
      {
        if (this._serialPort == null)
          return;
        this.timerAskStatus.Enabled = false;
        this._serialPort.DataReceived -= new SerialDataReceivedEventHandler(this._serialPort_DataReceived);
        this._serialPort.Close();
        this._serialPort.Dispose();
        this._serialPort = (SerialPort) null;
      }
      catch (Exception ex)
      {
      }
    }

    private void buttonOptions_Click(object sender, EventArgs e)
    {
      if (new MonitorOptionsForm().ShowDialog() != DialogResult.OK)
        return;
      this.SetEmail2Column();
      this.SetPigeonCloudColumn();
    }

    private void SendCommand(byte command, int record)
    {
      if (this._serialPort == null || !this._serialPort.IsOpen)
        return;
      Thread.Sleep(10);
      byte[] bytes = this.CreateBytes(command, record);
      this._serialPort.Write(bytes, 0, bytes.Length);
    }

    private void button1_Click_1(object sender, EventArgs e) => this.SendCommand((byte) 16, 0);

    private byte[] CreateBytes(byte command, int record)
    {
      int num1 = 0;
      byte[] numArray1 = new byte[7];
      byte[] numArray2 = numArray1;
      int index1 = num1;
      int num2 = index1 + 1;
      numArray2[index1] = (byte) 108;
      byte[] numArray3 = numArray1;
      int index2 = num2;
      int num3 = index2 + 1;
      numArray3[index2] = (byte) 130;
      byte[] numArray4 = numArray1;
      int index3 = num3;
      int num4 = index3 + 1;
      int num5 = (int) command;
      numArray4[index3] = (byte) num5;
      byte[] numArray5 = numArray1;
      int index4 = num4;
      int num6 = index4 + 1;
      numArray5[index4] = (byte) 2;
      byte[] numArray6 = numArray1;
      int index5 = num6;
      int num7 = index5 + 1;
      int num8 = (int) (byte) (record >> 8);
      numArray6[index5] = (byte) num8;
      byte[] numArray7 = numArray1;
      int index6 = num7;
      int index7 = index6 + 1;
      int num9 = (int) (byte) (record & (int) byte.MaxValue);
      numArray7[index6] = (byte) num9;
      numArray1[index7] = (byte) 0;
      this.logit("\r\nSended:");
      for (int index8 = 0; index8 < numArray1.Length - 1; ++index8)
      {
        this.logit(numArray1[index8].ToString("X") + " ");
        numArray1[index7] += numArray1[index8];
      }
      this.logit("\r\n");
      return numArray1;
    }

    private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      try
      {
        byte[] buffer = new byte[this._serialPort.BytesToRead];
        if (buffer.Length == 0)
          return;
        this._serialPort.Read(buffer, 0, buffer.Length);
        if (buffer[0] == (byte) 51)
        {
          this._receivedBytes = buffer;
        }
        else
        {
          byte[] receivedBytes = this._receivedBytes;
          this._receivedBytes = new byte[buffer.Length + receivedBytes.Length];
          receivedBytes.CopyTo((Array) this._receivedBytes, 0);
          buffer.CopyTo((Array) this._receivedBytes, receivedBytes.Length);
        }
        if (this._receivedBytes.Length <= 5)
          return;
        int num1 = (int) this._receivedBytes[3] + 5;
        if (num1 > this._receivedBytes.Length)
          return;
        byte num2 = 0;
        for (int index = 0; index < num1 - 1; ++index)
          num2 += this._receivedBytes[index];
        if ((int) num2 != (int) this._receivedBytes[num1 - 1])
        {
          ++this._BAMissedCommands;
          this.IdleMode = true;
        }
        else
        {
          this._BAMissedCommands = 0;
          byte[] bytes = (byte[]) this._receivedBytes.Clone();
          this._networkMode = false;
          this.ProcessCommand(bytes);
        }
        this._receivedBytes = new byte[0];
      }
      catch (Exception ex)
      {
        ++this._BAMissedCommands;
        this.IdleMode = true;
      }
    }

    private void ProcessCommand(byte[] bytes)
    {
      this.IdleMode = false;
      BriconLib.Monitor.Command command = CommandFactory.CreateCommand(bytes);
      if (command == null)
        return;
      if (command is StatusCommand)
      {
        this._status = command as StatusCommand;
        this._statusDataChanged = true;
        if (this._status.PigeonCount != this._pigeons.Count)
        {
          if (this._status.PigeonCount > this._pigeons.Count)
          {
            this.SendCommand((byte) 17, this._pigeons.Count);
          }
          else
          {
            this._pigeons.Clear();
            this.SendCommand((byte) 17, 0);
          }
        }
        else if (this._races.Count - 1 != this._status.RaceCount + this._deletedRaces)
        {
          this.ClearRaces();
          this.SendCommand((byte) 19, 0);
        }
        else if (this._fancier == null)
          this.SendCommand((byte) 18, 0);
        else
          this.IdleMode = true;
      }
      if (command is PigeonCommand && this._status != null)
      {
        PigeonCommand pigeonCommand = command as PigeonCommand;
        if (!pigeonCommand.NoMoreRecords && this._pigeons.Count != this._status.PigeonCount)
        {
          this._pigeons.Add(pigeonCommand);
          pigeonCommand.Pos = this._pigeons.Count;
          this._pigeonDataChanged = true;
          this.SendCommand((byte) 17, this._pigeons.Count);
        }
        else if (this._races.Count - 1 != this._status.RaceCount + this._deletedRaces)
        {
          this.ClearRaces();
          this.SendCommand((byte) 19, 0);
        }
        else if (this._fancier == null)
          this.SendCommand((byte) 18, 0);
        else
          this.IdleMode = true;
      }
      if (command is RaceCommand && this._status != null)
      {
        RaceCommand raceCommand = command as RaceCommand;
        if (this._races.Count - 1 != this._status.RaceCount + this._deletedRaces)
        {
          if (raceCommand.RaceIsDeleted)
            ++this._deletedRaces;
          this._races.Add(raceCommand);
          raceCommand.Index = this._races.Count - 1;
          this._raceDataChanged = true;
          this.SendCommand((byte) 19, this._races.Count - 1);
        }
        else if (this._fancier == null)
          this.SendCommand((byte) 18, 0);
        else
          this.IdleMode = true;
      }
      if (!(command is FancierCommand))
        return;
      this._fancier = command as FancierCommand;
      this.license = this._fancier.License;
      this._fancierDataChanged = true;
      this.IdleMode = true;
    }

    private void ClearRaces()
    {
      this._races.Clear();
      this._races.Add(new RaceCommand((byte[]) null));
    }

    private void logit(string text) => MonitorForm.Log.Append(text);

    private void timer1_Tick(object sender, EventArgs e)
    {
      try
      {
        if (this._BAMissedCommands > 20)
        {
          this.InitComport();
          this._status = (StatusCommand) null;
          this._fancier = (FancierCommand) null;
          this._idleMode = true;
          this._statusDataChanged = true;
          this._BAMissedCommands = 0;
        }
        if (!this._idleMode)
          return;
        if (this.progressBar1.Value > this.progressBar1.Maximum - 10)
          this.progressBar1.Value = this.progressBar1.Minimum;
        if (this._BAMissedCommands == 0)
          this.progressBar1.Value += 10;
        else
          this.progressBar1.Value += 5;
        Thread.Sleep(50);
        this.SendCommand((byte) 16, 0);
        ++this._BAMissedCommands;
      }
      catch (Exception ex)
      {
        this._idleMode = true;
      }
    }

    private void MonitorForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      this._ws.Stop();
      this._networkMessaging.Dispose();
      this.CloseComPort();
      RaceDataSaver.Save(this._races, this._pigeons);
    }

    private void buttonExit_Click(object sender, EventArgs e) => this.Close();

    private void timerRefresh_Tick(object sender, EventArgs e)
    {
      try
      {
        this.timerRefresh.Tick -= new EventHandler(this.timerRefresh_Tick);
        if (this._statusDataChanged)
        {
          this._statusDataChanged = false;
          if (this._status == null)
          {
            this.labelStatus.Text = ml.ml_string(890, "No response");
            this.pictureBox1.Visible = false;
            if (this._networkMode)
              this.labelStatus.ForeColor = Color.Purple;
            else
              this.labelStatus.ForeColor = Color.Red;
            this.labelAntennaCount.Text = "";
            this.labelRaceCount.Text = "";
            this.labelPigeonCount.Text = "";
          }
          else
          {
            this.labelStatus.Text = ml.ml_string(891, "Clock responded");
            this.pictureBox1.Visible = true;
            if (this._networkMode)
              this.labelStatus.ForeColor = Color.Blue;
            else
              this.labelStatus.ForeColor = Color.Green;
            if (this._status != null)
              this.labelAntennaCount.Text = this._status.AntennaCount.ToString();
            if (this._status != null)
              this.labelRaceCount.Text = this._status.RaceCount.ToString();
            if (this._status != null)
              this.labelPigeonCount.Text = this._status.PigeonCount.ToString();
          }
        }
        if (this._fancierDataChanged)
        {
          this._fancierDataChanged = false;
          if (this._fancier == null)
          {
            this.labelLicense.Text = "";
            this.labelName.Text = "";
          }
          else
          {
            this.labelLicense.Text = this._fancier.License;
            this.labelName.Text = this._fancier.Name;
            this._pigeonDataChanged = true;
          }
        }
        if (this._raceDataChanged)
        {
          this._raceDataChanged = false;
          List<RaceCommand> raceCommandList = new List<RaceCommand>();
          foreach (RaceCommand race in this._races)
          {
            if (!race.RaceIsDeleted)
              raceCommandList.Add(race);
          }
          this.dataGridView2.DataSource = (object) raceCommandList;
          this._pigeonDataChanged = true;
          this.UpdateFlightsFromBriconWeb();
        }
        if (this._races.Count > 0)
        {
          if (!this._pigeonDataChanged)
          {
            if (!this._forceSendMail)
              goto label_77;
          }
          this._pigeonDataChanged = false;
          List<PigeonCommand> pigeonCommandList = new List<PigeonCommand>();
          this._emailAllPigeons = new StringBuilder(ml.ml_string(892, "\r\nBelow all the pigeons:\r\n"));
          foreach (RaceCommand race in this._races)
            race.PigeonCount = 0;
          foreach (PigeonCommand pigeon in this._pigeons)
          {
            if (pigeon.RaceIndex < this._races.Count - 1)
            {
              RaceCommand race = this._races[pigeon.RaceIndex + 1];
              ++race.PigeonCount;
              if (race.Show)
              {
                pigeon.RaceName = race.RaceName;
                if (race.DistanceInMeter != 0)
                {
                  DateTime time2_1 = pigeon.Time2;
                  DateTime dateTime1 = race.ReleaseDate;
                  DateTime date1 = dateTime1.Date;
                  dateTime1 = race.ReleaseTime;
                  TimeSpan timeOfDay1 = dateTime1.TimeOfDay;
                  DateTime dateTime2 = date1 + timeOfDay1;
                  if (time2_1 > dateTime2)
                  {
                    DateTime time2_2 = pigeon.Time2;
                    dateTime1 = race.ReleaseDate;
                    DateTime date2 = dateTime1.Date;
                    TimeSpan timeSpan1 = time2_2 - date2;
                    dateTime1 = race.ReleaseTime;
                    TimeSpan timeOfDay2 = dateTime1.TimeOfDay;
                    TimeSpan timeSpan2 = timeSpan1 - timeOfDay2;
                    pigeon.Speed = !(Utils.UnitsUsed() == "Imperial") ? Math.Round((double) race.DistanceInMeter / timeSpan2.TotalMinutes, 2) : Math.Round((double) (race.DistanceInMeter * 1760 + race.DistanceYards) / timeSpan2.TotalMinutes, 2);
                  }
                }
              }
              else
                continue;
            }
            pigeonCommandList.Add(pigeon);
            this._emailAllPigeons.Append(pigeon.ToEmailString(this._pigeons.Count));
          }
          List<RaceCommand> raceCommandList = new List<RaceCommand>();
          foreach (RaceCommand race in this._races)
          {
            if (!race.RaceIsDeleted)
              raceCommandList.Add(race);
          }
          this.dataGridView2.DataSource = (object) raceCommandList;
          this._pigeonDataChanged = false;
          bool flag1 = false;
          if (this._lastPigeonCount < this._pigeons.Count || this._forceSendMail)
          {
            if (this._emailClockedPigeons == null)
              this._emailClockedPigeons = new StringBuilder(ml.ml_string(893, "The following pigeon(s) are clocked:\r\n"));
            if (this._forceSendMail)
              this._emailClockedPigeons = new StringBuilder();
            bool flag2 = false;
            for (; this._lastPigeonCount < this._pigeons.Count; ++this._lastPigeonCount)
            {
              PigeonCommand pigeon = this._pigeons[this._lastPigeonCount];
              if (pigeon.RaceIndex < this._races.Count - 1)
              {
                RaceCommand race = this._races[pigeon.RaceIndex + 1];
                if (race.Email || this._forceSendMail)
                {
                  this._emailClockedPigeons.Append(pigeon.ToEmailString(this._pigeons.Count));
                  flag2 = true;
                }
                if (!this._initModus && Utils.IsCountry("NL") && (!pigeon.SendedToPigeonCloud && Settings.Default.SendToPigeonCloud) && race.PigeonCloud)
                  this.SendToPigeonCloud((object) this._pigeons[this._lastPigeonCount]);
                if (!this._initModus && Utils.IsCountry("NL") && (!pigeon.SendedToCompuClub && Settings.Default.SendToCompuClub) && race.Email2)
                  this.SendToCompuClub(this._pigeons[this._lastPigeonCount], race);
                if (race.PlaySound)
                  flag1 = true;
              }
            }
            if (!this._initModus & flag2 || this._forceSendMail)
              new Thread(new ThreadStart(this.SendMail)).Start();
            this._forceSendMail = false;
          }
          this.dataGridView1.DataSource = (object) pigeonCommandList;
          this.SelectLastRow();
          if (flag1)
          {
            if ((DateTime.Now - this._lastTimeBeeped).TotalSeconds > 2.0)
              new SoundManager().Play(Settings.Default.SelectedAlarmSound, Settings.Default.PlayAlarmInLoop);
            this._lastTimeBeeped = DateTime.Now;
          }
        }
      }
      catch (Exception ex)
      {
        this.logit(ex.Message);
      }
      finally
      {
        this.timerRefresh.Tick += new EventHandler(this.timerRefresh_Tick);
      }
label_77:
      this.SetTotalsPerCategory();
    }

    private void SendToPigeonCloud(object pigeon)
    {
      try
      {
        PigeonCommand cmd = pigeon as PigeonCommand;
        string address = string.Format("https://bricon.duifmelden.nl/melden/?var=@Melden@@@{0}@{1}%20{2}@{3}%20{4}@@@@@@@", (object) (cmd.DBRing.Substring(3, 2) + "/" + cmd.DBRing.TrimEnd(' ', 'V').Substring(cmd.DBRing.TrimEnd(' ', 'V').Length - 7)), (object) cmd.Time2.ToString("dd-MM-yyyy"), (object) cmd.Time2.ToString("HH:mm:ss"), (object) DateTime.Now.ToString("dd-MM-yyyy"), (object) DateTime.Now.ToString("HH:mm:ss"));
        using (WebClient webClient = new WebClient())
          webClient.DownloadString(address);
        RaceDataSaver.SetSendedToPigeonCloud(cmd);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ml.ml_string(1234, "Error when sending to Pigeon Cloud:") + ex.ToString());
      }
    }

    private void SelectLastRow()
    {
      if (this.dataGridView1.RowCount <= 0)
        return;
      foreach (DataGridViewRow selectedRow in (BaseCollection) this.dataGridView1.SelectedRows)
        selectedRow.Cells[0].Selected = false;
      this.dataGridView1.Rows[this.dataGridView1.RowCount - 1].Cells[0].Selected = true;
      this.dataGridView1.FirstDisplayedScrollingRowIndex = this.dataGridView1.RowCount - 1;
    }

    private void MonitorForm_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == '?')
        Clipboard.SetText(MonitorForm.Log.ToString());
      new SoundManager().Stop();
    }

    private void dataGridView2_CellValidated(object sender, DataGridViewCellEventArgs e)
    {
      if (!this.dataGridView2.IsCurrentCellInEditMode || !this.dataGridView2.IsCurrentRowDirty)
        return;
      this._lastTimeBeeped = DateTime.Now;
      this._pigeonDataChanged = true;
      this._raceDataChanged = true;
    }

    private void dataGridView2_CellLeave(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex != this.ShowColumn.Index && e.ColumnIndex != this.PlaySoundColumn.Index && (e.ColumnIndex != this.Mail2Column.Index && e.ColumnIndex != this.MailColumn.Index) || !this.dataGridView2.IsCurrentCellInEditMode)
        return;
      this.dataGridView2.EndEdit();
    }

    private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex != this.ShowColumn.Index && e.ColumnIndex != this.PlaySoundColumn.Index && (e.ColumnIndex != this.Mail2Column.Index && e.ColumnIndex != this.MailColumn.Index))
        return;
      this.dataGridView2.EndEdit();
    }

    private void timerSendEmailStarter_Tick(object sender, EventArgs e)
    {
      this._initModus = false;
      this.timerSendEmailStarter.Enabled = false;
    }

    private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex != this.ShowColumn.Index && e.ColumnIndex != this.MailColumn.Index && (e.ColumnIndex != this.PlaySoundColumn.Index && e.ColumnIndex != this.Mail2Column.Index))
        return;
      this.timerEndEdit.Start();
    }

    private void timerEndEdit_Tick(object sender, EventArgs e)
    {
      this.timerEndEdit.Stop();
      this.dataGridView2.EndEdit();
      this._pigeonDataChanged = true;
    }

    private void buttonSendMail_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(ml.ml_string(979, "Are you sure you wish to send all the pigeons by email?"), ml.ml_string(980, "Send Email"), MessageBoxButtons.OKCancel) != DialogResult.OK)
        return;
      this._forceSendMail = true;
    }

    private void buttonRefresh_Click(object sender, EventArgs e)
    {
      RaceDataSaver.Save(this._races, this._pigeons);
      this._pigeons.Clear();
      this.ClearRaces();
      this._fancier = (FancierCommand) null;
      this._status = (StatusCommand) null;
      this._statusDataChanged = true;
      this._raceDataChanged = true;
      this._pigeonDataChanged = true;
      this._lastCountForBriconWeb = 0;
      this._lastRefreshFromBriconWeb = DateTime.MinValue;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.timerAskStatus.Enabled = false;
      this._idleModeTimer.Enabled = false;
      PigeonCommand pigeonCommand = new PigeonCommand(this.license, this._pigeons.Count);
      this._pigeons.Add(pigeonCommand);
      pigeonCommand.Pos = this._pigeons.Count;
      this._pigeonDataChanged = true;
    }

    private int GetCategory(PigeonCommand cmd)
    {
      if (cmd.Old > 0)
        return 1;
      if (cmd.Year > 0)
        return 2;
      return cmd.Young > 0 ? 3 : 0;
    }

    private void timerRefreshBriconWeb_Tick(object sender, EventArgs e)
    {
      if (this._timerRefreshBriconWebBusy2 || this._status == null)
        return;
      if (this._pigeons.Count != this._status.PigeonCount)
        return;
      try
      {
        this._timerRefreshBriconWebBusy2 = true;
        if (this.BriconWebColumn.Visible)
        {
          List<PigeonCommand> pigeons = new List<PigeonCommand>(this._briconWebBuffer.Count);
          if (this._briconWebBuffer.Count > 0)
          {
            Utils.LogErrorToBWLog("Outgoing buffer: " + this._briconWebBuffer.Count.ToString());
            while (this._briconWebBuffer.Count > 0)
              pigeons.Add(this._briconWebBuffer.Dequeue());
            if (BriconWebHelper.Send(this._races, pigeons, this.license, this))
            {
              this.Distance.Visible = this.Speed2.Visible = this.Club.Visible = this.Provencial.Visible = this.National.Visible = this.EnterPositionClub.Visible = true;
              Utils.LogErrorToBWLog("Outgoing buffer sended ");
            }
            object dataSource = this.dataGridView1.DataSource;
            this.dataGridView1.DataSource = (object) null;
            this.dataGridView1.DataSource = dataSource;
          }
        }
      }
      catch (Exception ex)
      {
        Utils.LogErrorToBWLog(ex.ToString());
      }
      finally
      {
        this._timerRefreshBriconWebBusy2 = false;
      }
      if (this._timerRefreshBriconWebBusy)
        return;
      try
      {
        this._timerRefreshBriconWebBusy = true;
        if (!this._noSpeedRefresh)
        {
          List<RaceCommand> raceCommandList = new List<RaceCommand>();
          foreach (RaceCommand race in this._races)
          {
            DateTime dateTime = race.ReleaseDate;
            DateTime date = dateTime.Date;
            dateTime = race.ReleaseTime;
            TimeSpan timeOfDay = dateTime.TimeOfDay;
            double totalMinutes = (DateTime.Now - (date + timeOfDay)).TotalMinutes;
            double num = Math.Round((double) race.DistanceInMeter / totalMinutes, 2);
            race.Speed = num < 500.0 || num > 2500.0 ? "-" : num.ToString();
            if (!race.RaceIsDeleted)
              raceCommandList.Add(race);
          }
          this.dataGridView2.DataSource = (object) raceCommandList;
        }
        if (this._networkMode && sender != null && (this._firstTime && this._status == null || this._status != null && (this._races.Count - 1 != this._status.RaceCount + this._deletedRaces || this._pigeons.Count != this._status.PigeonCount)))
          this._firstTime = false;
        else if (this._BriconWebDisabled || this.license == null)
        {
          Utils.LogErrorToBWLog("_BriconWebDisabled || license == null");
        }
        else
        {
          if (this._status != null && this._status.PigeonCount != this._pigeons.Count)
            return;
          if (this._lastFlightRefreshFromBriconWeb < DateTime.Now.Subtract(TimeSpan.FromMinutes(5.0)))
          {
            this._lastCountForBriconWeb = 0;
            this.UpdateFlightsFromBriconWeb();
            this._lastFlightRefreshFromBriconWeb = DateTime.Now;
          }
          bool flag = false;
          List<PigeonCommand> pigeons = this._pigeons;
          if (this._lastRefreshFromBriconWeb < DateTime.Now.Subtract(TimeSpan.FromMinutes(5.0)))
          {
            flag = true;
          }
          else
          {
            List<PigeonCommand> pigeonCommandList = new List<PigeonCommand>();
            foreach (PigeonCommand pigeon in this._pigeons)
            {
              if (pigeon.RaceIndex < this._races.Count - 1 && this._races[pigeon.RaceIndex + 1].FlightIDBriconWeb > 0 && (pigeon.IDInBriconWeb == 0 || pigeon.ArrivePositionInternational == 0))
              {
                flag = true;
                pigeonCommandList.Add(pigeon);
              }
            }
          }
          if (!flag)
            return;
          this._lastRefreshFromBriconWeb = DateTime.Now;
          this.logit("BriconWeb.Refresh\r\n");
          try
          {
            if (Settings.Default.LoginBriconWeb != "" && Settings.Default.LoginBriconWeb != this.license && this.license != null)
            {
              int num = (int) MessageBox.Show(ml.ml_string(981, "Your login for BriconWeb '" + Settings.Default.LoginBriconWeb + ml.ml_string(1111, "' should be the same as your license number '") + this.license + ml.ml_string(1112, "' , please change it with the optionsbutton below")));
              return;
            }
            for (int index1 = 0; index1 < this._pigeons.Count; ++index1)
            {
              PigeonCommand pigeon1 = this._pigeons[index1];
              if (pigeon1.RaceIndex < this._races.Count - 1)
              {
                RaceDataSaver.FillInIfPossible(pigeon1);
                RaceCommand race = this._races[pigeon1.RaceIndex + 1];
                if (race.FlightIDBriconWeb > 0 && (race.AskGummy || race.AskOnlyFirstTwoGummies) && string.IsNullOrEmpty(pigeon1.Gummy))
                {
                  int num1 = 0;
                  if (race.AskOnlyFirstTwoGummies)
                  {
                    for (int index2 = 0; index2 < this._pigeons.Count && num1 < 2; ++index2)
                    {
                      PigeonCommand pigeon2 = this._pigeons[index2];
                      if (index2 != index1 && pigeon2.RaceIndex == pigeon1.RaceIndex && (this.GetCategory(pigeon2) == this.GetCategory(pigeon1) && !string.IsNullOrEmpty(pigeon2.Gummy)))
                        ++num1;
                    }
                  }
                  if (num1 < 2)
                  {
                    AskGummyForm askGummyForm = new AskGummyForm();
                    askGummyForm.labelText.Text = string.Format("{0}", (object) pigeon1.DBRing);
                    askGummyForm.labelTime.Text = string.Format("{0}", (object) pigeon1.Time);
                    int num2 = (int) askGummyForm.ShowDialog();
                    pigeon1.Gummy = askGummyForm.textBoxGummy.Text;
                  }
                  else
                    pigeon1.Gummy = "----";
                  RaceDataSaver.AddGummyAndWingmark(pigeon1);
                  this._networkMessaging.BroadCastMessage("GummyAdded|" + pigeon1.DBRing + "|" + pigeon1.Time2.ToString((IFormatProvider) CultureInfo.InvariantCulture) + "|" + pigeon1.Gummy + "|" + pigeon1.Wingmark);
                  this.logit("UDP send : GummyAdded\r\n");
                }
                if (race.FlightIDBriconWeb > 0 && race.AskWingmark && string.IsNullOrEmpty(pigeon1.Wingmark))
                {
                  AskWingmarkForm askWingmarkForm = new AskWingmarkForm();
                  askWingmarkForm.labelText.Text = string.Format(askWingmarkForm.labelText.Text, (object) pigeon1.DBRing, (object) pigeon1.Time);
                  int num = (int) askWingmarkForm.ShowDialog();
                  pigeon1.Wingmark = askWingmarkForm.textBoxWingmark.Text;
                  RaceDataSaver.AddGummyAndWingmark(pigeon1);
                  this._networkMessaging.BroadCastMessage("GummyAdded|" + pigeon1.DBRing + "|" + pigeon1.Time2.ToString((IFormatProvider) CultureInfo.InvariantCulture) + "|" + pigeon1.Gummy + "|" + pigeon1.Wingmark);
                  this.logit("UDP send : GummyAdded\r\n");
                }
                if (race.FlightIDBriconWeb > 0 && (pigeon1.IDInBriconWeb == 0 || pigeon1.ArrivePositionInternational == 0) && !this._briconWebBuffer.Contains(pigeon1))
                  this._briconWebBuffer.Enqueue(pigeon1);
              }
            }
            SmtpClient smtpClient = EmailHelper.GetSmtpClient();
            for (int index = 0; index < this._pigeons.Count; ++index)
            {
              PigeonCommand pigeon = this._pigeons[index];
              if (pigeon.RaceIndex < this._races.Count - 1)
              {
                RaceCommand race = this._races[pigeon.RaceIndex + 1];
                if (race.FlightIDBriconWeb > 0 && race.IsNationalFlight && !pigeon.SendedToExtenalParties && (Settings.Default.SendToPipa || Settings.Default.SendToPitts || (Settings.Default.SendToOmar || Settings.Default.EmailAddressSignon.Length > 0)))
                {
                  int num = int.MaxValue;
                  if (Settings.Default.OnlyFirstSignon)
                    num = 1;
                  if (this._pigeons.Count<PigeonCommand>((Func<PigeonCommand, bool>) (p => p.SendedToExtenalParties && p.RaceIndex == pigeon.RaceIndex)) < num)
                    this.SendMailToOthers(smtpClient, pigeon, race);
                }
              }
            }
          }
          catch (FileNotFoundException ex)
          {
            int num = (int) MessageBox.Show(ml.ml_string(977, "This functionality requires Microsoft .NET 3.0. You can find it at http://www.microsoft.com/download/en/details.aspx?id=31"));
            this._BriconWebDisabled = true;
            Utils.LogErrorToBWLog("_BriconWebDisabled = true FileNotFoundException");
          }
          catch (Exception ex)
          {
            int num = (int) MessageBox.Show(ex.ToString());
            this._BriconWebDisabled = true;
            Utils.LogErrorToBWLog("_BriconWebDisabled = true " + ex.ToString());
          }
          object dataSource = this.dataGridView1.DataSource;
          this.dataGridView1.DataSource = (object) null;
          this.dataGridView1.DataSource = dataSource;
          this.SelectLastRow();
        }
      }
      catch (Exception ex)
      {
      }
      finally
      {
        this._timerRefreshBriconWebBusy = false;
      }
    }

    private string GetCompuClubRingnr(string dbring)
    {
      if (dbring.Length <= 6)
        return dbring;
      dbring = dbring.Substring(3).Replace("-", "/");
      if (dbring.IndexOf("/") == -1)
        return dbring;
      return dbring.Split('/')[0] + "/" + dbring.Split('/')[1].Substring(3).TrimEnd(' ', 'V');
    }

    private void SendToCompuClub(PigeonCommand pigeon, RaceCommand race)
    {
      try
      {
        SmtpClient smtpClient = EmailHelper.GetSmtpClient();
        string str = this.license.Replace("/", "").Replace("-", "").Replace(" ", "").Replace(".", "");
        string address = "webmeld@compuclub.eu";
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendFormat("@Melden");
        stringBuilder.AppendFormat("@{0}", (object) "");
        stringBuilder.AppendFormat("@{0}", (object) str);
        stringBuilder.AppendFormat("@{0}", (object) this.GetCompuClubRingnr(pigeon.DBRing));
        stringBuilder.AppendFormat("@{0}", (object) pigeon.Time2.ToString("dd-MM-yyyy HH:mm:ss"));
        stringBuilder.AppendFormat("@{0}", (object) DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
        stringBuilder.AppendFormat("@{0}", (object) "");
        stringBuilder.AppendFormat("@{0}", (object) "");
        stringBuilder.AppendFormat("@{0}", (object) race.ClubID);
        stringBuilder.AppendFormat("@{0}", pigeon.DBRing.EndsWith("V") ? (object) "V" : (object) "M");
        stringBuilder.AppendFormat("@{0}", (object) str);
        stringBuilder.AppendFormat("@{0}", (object) race.RaceNameShort);
        stringBuilder.AppendFormat("@{0}", (object) "BRICON");
        stringBuilder.AppendFormat("@");
        smtpClient.Send(new MailMessage(EmailHelper.GetFromAddress(), new MailAddress(address))
        {
          Subject = stringBuilder.ToString()
        });
        Utils.LogErrorToBWLog("Email verstuurd naar CompuClub op adres: " + address);
      }
      catch (Exception ex)
      {
        Utils.LogErrorToBWLog(ex.ToString());
      }
      RaceDataSaver.SetSendedToCompuClub(pigeon);
    }

    private void SendMailToOthers(SmtpClient smtpClient, PigeonCommand pigeon, RaceCommand race)
    {
      try
      {
        if (pigeon.Distance == 0.0)
          return;
        string str1 = ml.ml_string(1113, "New pigeon clocked in Bricon-Printmanager");
        string emailAddressSignon = Settings.Default.EmailAddressSignon;
        if (Settings.Default.SendToPitts && race.Email2)
          emailAddressSignon += ";support@bricon.be";
        if (Settings.Default.SendToOmar && race.Email2)
          emailAddressSignon += ";support@bricon.be";
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(ml.ml_string(1114, "Fancier : ") + this.labelName.Text);
        if (this._fancier != null)
          stringBuilder.AppendLine(ml.ml_string(1115, "City : ") + this._fancier.City);
        stringBuilder.AppendLine(ml.ml_string(1116, "License : ") + this.license);
        stringBuilder.AppendLine();
        stringBuilder.AppendLine(ml.ml_string(1117, "Race : ") + pigeon.RaceName);
        stringBuilder.AppendLine(ml.ml_string(1118, "BasketDate : ") + race.BasketDate.ToShortDateString());
        stringBuilder.AppendLine(ml.ml_string(1119, "ClubID : ") + race.ClubID);
        stringBuilder.AppendLine();
        stringBuilder.AppendLine(ml.ml_string(1120, "Ring : ") + pigeon.DBRing);
        stringBuilder.AppendLine(ml.ml_string(1121, "Distance : ") + pigeon.Distance.ToString());
        if (pigeon.Speed > 100.0)
          stringBuilder.AppendLine(ml.ml_string(870, "Velocity") + pigeon.Speed.ToString());
        if (pigeon.Old > 0)
          stringBuilder.AppendLine(ml.ml_string(1122, "Category : Old"));
        if (pigeon.Year > 0)
          stringBuilder.AppendLine(ml.ml_string(1123, "Category : Yearling"));
        if (pigeon.Young > 0)
          stringBuilder.AppendLine(ml.ml_string(1124, "Category : Young"));
        stringBuilder.AppendLine(ml.ml_string(1125, "Time Clocked : ") + pigeon.Time);
        if (!string.IsNullOrEmpty(pigeon.Gummy) && pigeon.Gummy != "----")
          stringBuilder.AppendLine(ml.ml_string(1126, "Gummy : ") + pigeon.Gummy);
        if (!string.IsNullOrEmpty(pigeon.Wingmark))
          stringBuilder.AppendLine(ml.ml_string(1189, "Wingmark : ") + pigeon.Wingmark);
        string str2 = emailAddressSignon;
        char[] separator = new char[2]{ ';', ' ' };
        foreach (string address in str2.Split(separator, StringSplitOptions.RemoveEmptyEntries))
        {
          if (!address.ToLower().Contains("@bricon") && !address.ToLower().Contains("@pipa"))
          {
            MailMessage message = new MailMessage(EmailHelper.GetFromAddress(), new MailAddress(address));
            message.Body = stringBuilder.ToString();
            message.Subject = str1;
            if (!address.ToLower().Contains("bricon@bricon.be"))
              smtpClient.Send(message);
          }
        }
      }
      catch (Exception ex)
      {
        Utils.LogErrorToBWLog(ex.ToString());
      }
      RaceDataSaver.SetSendedToExternalParties(pigeon);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (this.dataGridView2.SelectedCells.Count != 1 && this.dataGridView2.SelectedRows.Count != 1)
      {
        Process.Start("http://www.briconweb.com");
      }
      else
      {
        int index = 0;
        if (this.dataGridView2.SelectedCells.Count > 0)
          index = this.dataGridView2.SelectedCells[0].RowIndex;
        if (this.dataGridView2.SelectedRows.Count > 0)
          index = this.dataGridView2.SelectedRows[0].Index;
        RaceCommand race = this._races[index];
        if (!race.ActiveInBriconWeb)
        {
          Process.Start("http://www.briconweb.com");
        }
        else
        {
          int num = 1000;
          Process.Start("http://www.briconweb.com/Aspx/pages/Results.aspx?" + (string.Format("raceID={0}&level={1}&pigeonsToShow={2}&OldBirds={3}&Yearlings={4}&YoungBirds={5}&language={6}&country={7}", (object) race.FlightIDBriconWeb, (object) "Club", (object) num, (object) "true", (object) "true", (object) "true", (object) CultureInfo.CurrentCulture.Name.Substring(0, 2), (object) Settings.Default.Country) + "&clubID=" + race.ClubIDBriconWeb.ToString()));
        }
      }
    }

    private void SendMail()
    {
      try
      {
        Thread.Sleep(30000);
        StringBuilder emailClockedPigeons = this._emailClockedPigeons;
        this._emailClockedPigeons = (StringBuilder) null;
        if (emailClockedPigeons == null)
          return;
        emailClockedPigeons.Append((object) this._emailAllPigeons);
        SmtpClient smtpClient = EmailHelper.GetSmtpClient();
        string str = ml.ml_string(894, "New pigeons arrived");
        if (this._forceSendMail)
          str = ml.ml_string(978, "Pigeons report");
        if (this._fancier != null)
          str = str + " - " + this._fancier.Name;
        string emailAddress = Settings.Default.EmailAddress;
        char[] chArray = new char[2]{ ';', ' ' };
        foreach (string address in emailAddress.Split(chArray))
        {
          if (!address.ToLower().Contains("@bricon") && !address.ToLower().Contains("@pipa"))
          {
            MailMessage message = new MailMessage(EmailHelper.GetFromAddress(), new MailAddress(address));
            message.Body = emailClockedPigeons.ToString();
            message.Subject = str;
            if (!string.IsNullOrWhiteSpace(address) && !address.ToLower().Contains("bricon@bricon.be"))
              smtpClient.Send(message);
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ml.ml_string(895, "Error when sending email, please verify the options: ") + ex.Message);
      }
    }

    private void buttonPrint_Click(object sender, EventArgs e)
    {
      if (this._fancier == null || this._status == null)
        return;
      ReadOutDataSet readout = new ReadOutDataSet();
      ReadOutDataSet.FancierRow fancierRow = readout.Fancier.AddFancierRow(this._fancier.License, this._fancier.Name, "", "", "", "", "", "", 0M, "", "", "", "", "", 0M);
      int num = -1;
      foreach (RaceCommand race in this._races)
      {
        if (!race.Show)
        {
          ++num;
        }
        else
        {
          readout.Timers.AddTimersRow(fancierRow.ID, race.ClubID, race.RaceName, race.BasketDate, race.BasketDate, "", race.BasketDate, race.BasketDate, "", "");
          foreach (PigeonCommand pigeon in this._pigeons)
          {
            if (pigeon.RaceIndex == num)
              readout.PigeonsMonitor.AddPigeonsMonitorRow(fancierRow.ID, "", pigeon.DBRing, race.ClubID, race.RaceName, pigeon.Old, pigeon.Year, pigeon.Young, 0, pigeon.Time2, "", "", 0, pigeon.Speed, pigeon.Distance, pigeon.Speed2, pigeon.ArrivePositionClub, pigeon.ArrivePositionProvincial, pigeon.ArrivePositionNational, pigeon.ArrivePositionInternational, pigeon.EnterPositionClub, pigeon.EnterPositionProvincial, pigeon.EnterPositionNational, pigeon.EnterPositionInternational);
          }
          ++num;
        }
      }
      PrintHelper.Printlist(readout, "MonitorList");
    }

    private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if (this._races != null && this._races.Count<RaceCommand>((Func<RaceCommand, bool>) (r => !r.RaceIsDeleted)) > e.RowIndex && this._races.Where<RaceCommand>((Func<RaceCommand, bool>) (r => !r.RaceIsDeleted)).ToList<RaceCommand>()[e.RowIndex].ActiveInBriconWeb)
        e.CellStyle.BackColor = Color.LightGreen;
      else
        e.CellStyle.BackColor = Color.White;
    }

    private void SetTotalsPerCategory()
    {
      if (!this.groupBoxTotals.Visible)
        return;
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      foreach (PigeonCommand pigeon in this._pigeons)
      {
        if (pigeon.RaceIndex + 1 < this._races.Count && this._races[pigeon.RaceIndex + 1].Show)
        {
          ++num4;
          if (pigeon.Old > 0)
            ++num1;
          if (pigeon.Year > 0)
            ++num2;
          if (pigeon.Young > 0)
            ++num3;
          if (pigeon.Old == 0 && pigeon.Year == 0 && pigeon.Young == 0)
          {
            if (!string.IsNullOrWhiteSpace(pigeon.DBRing))
            {
              int startIndex = pigeon.DBRing.IndexOf('-') + 1;
              if (startIndex > 0 && startIndex + 2 < pigeon.DBRing.Length)
              {
                short int16 = Convert.ToInt16(pigeon.DBRing.Substring(startIndex, 2));
                int num5 = DateTime.Now.Year - 2000;
                if ((int) int16 >= num5)
                  ++num3;
                else if ((int) int16 + 1 == num5)
                  ++num2;
                else
                  ++num1;
              }
              else
                ++num1;
            }
            else
              ++num1;
          }
        }
      }
      this.labelCountOld.Text = num1.ToString();
      this.labelCountYearlings.Text = num2.ToString();
      this.labelCountYoungs.Text = num3.ToString();
      if (Utils.IsCountry("BE"))
        return;
      this.labelCountOld.Text = num4.ToString();
      this.labelCountYearlings.Visible = false;
      this.labelCountYoungs.Visible = false;
      this.labelTotalOld.Visible = false;
      this.labelTotalYearlings.Visible = false;
      this.labelTotalYoungs.Visible = false;
    }

    private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
    {
      this._noSpeedRefresh = true;
      this.timerNoSpeedRefresh.Start();
    }

    private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
    {
      this._noSpeedRefresh = true;
      this.timerNoSpeedRefresh.Start();
    }

    private void timerNoSpeedRefresh_Tick(object sender, EventArgs e)
    {
      this._noSpeedRefresh = false;
      this.timerNoSpeedRefresh.Stop();
    }

    private void buttonUploadReadout_Click(object sender, EventArgs e)
    {
      try
      {
        NtpClient.GetNetworkTimeCached();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ml.ml_string(1314, "Problem with internet Time, can't continue! ") + ex.Message);
        return;
      }
      if (this.dataGridView2.SelectedCells.Count != 1 && this.dataGridView2.SelectedRows.Count != 1)
      {
        int num1 = (int) MessageBox.Show(ml.ml_string(1315, "Please select a Race to send"));
      }
      else
      {
        int index = 0;
        if (this.dataGridView2.SelectedCells.Count > 0)
          index = this.dataGridView2.SelectedCells[0].RowIndex;
        if (this.dataGridView2.SelectedRows.Count > 0)
          index = this.dataGridView2.SelectedRows[0].Index;
        if (index == 0)
        {
          int num2 = (int) MessageBox.Show(ml.ml_string(1315, "Please select a Race to send"));
        }
        else if (this.license == null)
        {
          int num3 = (int) MessageBox.Show(ml.ml_string(1316, "Please wait until all data is received"));
        }
        else
        {
          RaceCommand race = this._races[index];
          this.CloseComPort();
          new ReadoutUploader(race.RaceNameShort, this.license, race.ClubID).DoIt();
          this.InitComport();
        }
      }
    }

    private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
    }

    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MonitorForm));
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle9 = new DataGridViewCellStyle();
      this.imageList1 = new ImageList(this.components);
      this.label3 = new Label();
      this.label4 = new Label();
      this.imageList2 = new ImageList(this.components);
      this.dataGridView1 = new DataGridView();
      this.Pos = new DataGridViewTextBoxColumn();
      this.Ringnumber = new DataGridViewTextBoxColumn();
      this.Time = new DataGridViewTextBoxColumn();
      this.Race = new DataGridViewTextBoxColumn();
      this.O = new DataGridViewTextBoxColumn();
      this.X = new DataGridViewTextBoxColumn();
      this.Y = new DataGridViewTextBoxColumn();
      this.Antenna = new DataGridViewTextBoxColumn();
      this.Speed = new DataGridViewTextBoxColumn();
      this.Distance = new DataGridViewTextBoxColumn();
      this.Speed2 = new DataGridViewTextBoxColumn();
      this.EnterPositionClub = new DataGridViewTextBoxColumn();
      this.Club = new DataGridViewTextBoxColumn();
      this.Provencial = new DataGridViewTextBoxColumn();
      this.National = new DataGridViewTextBoxColumn();
      this.timerAskStatus = new System.Windows.Forms.Timer(this.components);
      this.labelAntennaCount = new Label();
      this.labelStatus = new Label();
      this.label5 = new Label();
      this.labelPigeonCount = new Label();
      this.label7 = new Label();
      this.labelRaceCount = new Label();
      this.label6 = new Label();
      this.label8 = new Label();
      this.labelLicense = new Label();
      this.labelName = new Label();
      this.timerRefresh = new System.Windows.Forms.Timer(this.components);
      this.groupBox1 = new GroupBox();
      this.groupBox2 = new GroupBox();
      this.pictureBox1 = new PictureBox();
      this.buttonExit = new Button();
      this.buttonOptions = new Button();
      this.groupBox3 = new GroupBox();
      this.dataGridView2 = new DataGridView();
      this.ShowColumn = new DataGridViewCheckBoxColumn();
      this.PigeonCountColumn = new DataGridViewTextBoxColumn();
      this.NameColumn = new DataGridViewTextBoxColumn();
      this.ClubColumn = new DataGridViewTextBoxColumn();
      this.DateColumn = new CalendarColumn();
      this.TimeColumn = new TimeColumn();
      this.DistanceColumn = new DataGridViewTextBoxColumn();
      this.Yards = new DataGridViewTextBoxColumn();
      this.MailColumn = new DataGridViewCheckBoxColumn();
      this.Mail2Column = new DataGridViewCheckBoxColumn();
      this.PigCloud = new DataGridViewCheckBoxColumn();
      this.BriconWebColumn = new DataGridViewCheckBoxColumn();
      this.PlaySoundColumn = new DataGridViewCheckBoxColumn();
      this.SpeedColumn = new DataGridViewTextBoxColumn();
      this.progressBar1 = new ProgressBar();
      this.label1 = new Label();
      this.imageList3 = new ImageList(this.components);
      this.timerSendEmailStarter = new System.Windows.Forms.Timer(this.components);
      this.timerEndEdit = new System.Windows.Forms.Timer(this.components);
      this.buttonSendMail = new Button();
      this.buttonRefresh = new Button();
      this.buttonClockFakePigeon = new Button();
      this.timerRefreshBriconWeb = new System.Windows.Forms.Timer(this.components);
      this.buttonBriconWeb = new Button();
      this.buttonPrint = new Button();
      this.groupBoxTotals = new GroupBox();
      this.labelCountYoungs = new Label();
      this.labelTotalYoungs = new Label();
      this.labelCountYearlings = new Label();
      this.labelCountOld = new Label();
      this.labelTotalYearlings = new Label();
      this.labelTotalOld = new Label();
      this.timerNoSpeedRefresh = new System.Windows.Forms.Timer(this.components);
      this.imageList4 = new ImageList(this.components);
      this.buttonUploadReadout = new Button();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.groupBox3.SuspendLayout();
      ((ISupportInitialize) this.dataGridView2).BeginInit();
      this.groupBoxTotals.SuspendLayout();
      this.SuspendLayout();
      this.imageList1.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageList1.ImageStream");
      this.imageList1.TransparentColor = Color.Magenta;
      this.imageList1.Images.SetKeyName(0, "Delete.bmp");
      this.imageList1.Images.SetKeyName(1, "Error.bmp");
      this.imageList1.Images.SetKeyName(2, "Clubs.bmp");
      this.label3.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.label3, "label3");
      this.label3.Name = "label3";
      this.label4.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.label4, "label4");
      this.label4.Name = "label4";
      this.imageList2.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageList2.ImageStream");
      this.imageList2.TransparentColor = Color.Fuchsia;
      this.imageList2.Images.SetKeyName(0, "FromBA.bmp");
      this.imageList2.Images.SetKeyName(1, "Delete.bmp");
      this.imageList2.Images.SetKeyName(2, "EditInformation.bmp");
      this.imageList2.Images.SetKeyName(3, "Properties.bmp");
      this.imageList2.Images.SetKeyName(4, "Help.bmp");
      this.imageList2.Images.SetKeyName(5, "Print.bmp");
      this.imageList2.Images.SetKeyName(6, "CriticalError.bmp");
      this.imageList2.Images.SetKeyName(7, "AutoLoad.bmp");
      this.imageList2.Images.SetKeyName(8, "Mail.png");
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      gridViewCellStyle1.BackColor = Color.FromArgb(192, (int) byte.MaxValue, (int) byte.MaxValue);
      gridViewCellStyle1.ForeColor = Color.Black;
      gridViewCellStyle1.SelectionBackColor = Color.Blue;
      gridViewCellStyle1.SelectionForeColor = Color.White;
      this.dataGridView1.AlternatingRowsDefaultCellStyle = gridViewCellStyle1;
      componentResourceManager.ApplyResources((object) this.dataGridView1, "dataGridView1");
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = SystemColors.Control;
      gridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
      gridViewCellStyle2.ForeColor = SystemColors.WindowText;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.True;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = gridViewCellStyle2;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.Pos, (DataGridViewColumn) this.Ringnumber, (DataGridViewColumn) this.Time, (DataGridViewColumn) this.Race, (DataGridViewColumn) this.O, (DataGridViewColumn) this.X, (DataGridViewColumn) this.Y, (DataGridViewColumn) this.Antenna, (DataGridViewColumn) this.Speed, (DataGridViewColumn) this.Distance, (DataGridViewColumn) this.Speed2, (DataGridViewColumn) this.EnterPositionClub, (DataGridViewColumn) this.Club, (DataGridViewColumn) this.Provencial, (DataGridViewColumn) this.National);
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle3.BackColor = SystemColors.Window;
      gridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Bold);
      gridViewCellStyle3.ForeColor = SystemColors.ControlText;
      gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle3.WrapMode = DataGridViewTriState.False;
      this.dataGridView1.DefaultCellStyle = gridViewCellStyle3;
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle4.BackColor = SystemColors.Control;
      gridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Bold);
      gridViewCellStyle4.ForeColor = SystemColors.WindowText;
      gridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle4.WrapMode = DataGridViewTriState.True;
      this.dataGridView1.RowHeadersDefaultCellStyle = gridViewCellStyle4;
      gridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Bold);
      this.dataGridView1.RowsDefaultCellStyle = gridViewCellStyle5;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
      this.dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
      this.dataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
      this.Pos.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.Pos.DataPropertyName = "Pos";
      gridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Pos.DefaultCellStyle = gridViewCellStyle6;
      componentResourceManager.ApplyResources((object) this.Pos, "Pos");
      this.Pos.Name = "Pos";
      this.Pos.ReadOnly = true;
      this.Ringnumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.Ringnumber.DataPropertyName = "DBRing";
      componentResourceManager.ApplyResources((object) this.Ringnumber, "Ringnumber");
      this.Ringnumber.Name = "Ringnumber";
      this.Ringnumber.ReadOnly = true;
      this.Time.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.Time.DataPropertyName = "Time";
      componentResourceManager.ApplyResources((object) this.Time, "Time");
      this.Time.Name = "Time";
      this.Time.ReadOnly = true;
      this.Race.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.Race.DataPropertyName = "RaceName";
      gridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Race.DefaultCellStyle = gridViewCellStyle7;
      componentResourceManager.ApplyResources((object) this.Race, "Race");
      this.Race.Name = "Race";
      this.Race.ReadOnly = true;
      this.O.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.O.DataPropertyName = "Old";
      componentResourceManager.ApplyResources((object) this.O, "O");
      this.O.Name = "O";
      this.O.ReadOnly = true;
      this.X.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.X.DataPropertyName = "Year";
      componentResourceManager.ApplyResources((object) this.X, "X");
      this.X.Name = "X";
      this.X.ReadOnly = true;
      this.Y.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.Y.DataPropertyName = "Young";
      componentResourceManager.ApplyResources((object) this.Y, "Y");
      this.Y.Name = "Y";
      this.Y.ReadOnly = true;
      this.Antenna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.Antenna.DataPropertyName = "Antenna";
      gridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Antenna.DefaultCellStyle = gridViewCellStyle8;
      componentResourceManager.ApplyResources((object) this.Antenna, "Antenna");
      this.Antenna.Name = "Antenna";
      this.Antenna.ReadOnly = true;
      this.Speed.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.Speed.DataPropertyName = "Speed";
      this.Speed.DividerWidth = 5;
      this.Speed.FillWeight = 50f;
      componentResourceManager.ApplyResources((object) this.Speed, "Speed");
      this.Speed.Name = "Speed";
      this.Speed.ReadOnly = true;
      this.Distance.DataPropertyName = "Distance";
      gridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Distance.DefaultCellStyle = gridViewCellStyle9;
      componentResourceManager.ApplyResources((object) this.Distance, "Distance");
      this.Distance.Name = "Distance";
      this.Distance.ReadOnly = true;
      this.Speed2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.Speed2.DataPropertyName = "Speed2";
      componentResourceManager.ApplyResources((object) this.Speed2, "Speed2");
      this.Speed2.Name = "Speed2";
      this.Speed2.ReadOnly = true;
      this.EnterPositionClub.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.EnterPositionClub.DataPropertyName = "EnterPositionClub";
      componentResourceManager.ApplyResources((object) this.EnterPositionClub, "EnterPositionClub");
      this.EnterPositionClub.Name = "EnterPositionClub";
      this.EnterPositionClub.ReadOnly = true;
      this.Club.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.Club.DataPropertyName = "ArrivePositionClub";
      componentResourceManager.ApplyResources((object) this.Club, "Club");
      this.Club.Name = "Club";
      this.Club.ReadOnly = true;
      this.Provencial.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.Provencial.DataPropertyName = "ArrivePositionProvincial";
      componentResourceManager.ApplyResources((object) this.Provencial, "Provencial");
      this.Provencial.Name = "Provencial";
      this.Provencial.ReadOnly = true;
      this.National.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.National.DataPropertyName = "ArrivePositionNational";
      componentResourceManager.ApplyResources((object) this.National, "National");
      this.National.Name = "National";
      this.National.ReadOnly = true;
      this.timerAskStatus.Enabled = true;
      this.timerAskStatus.Interval = 500;
      this.timerAskStatus.Tick += new EventHandler(this.timer1_Tick);
      this.labelAntennaCount.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.labelAntennaCount, "labelAntennaCount");
      this.labelAntennaCount.Name = "labelAntennaCount";
      this.labelStatus.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.labelStatus, "labelStatus");
      this.labelStatus.Name = "labelStatus";
      this.label5.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.label5, "label5");
      this.label5.Name = "label5";
      this.labelPigeonCount.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.labelPigeonCount, "labelPigeonCount");
      this.labelPigeonCount.Name = "labelPigeonCount";
      this.label7.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.label7, "label7");
      this.label7.Name = "label7";
      this.labelRaceCount.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.labelRaceCount, "labelRaceCount");
      this.labelRaceCount.Name = "labelRaceCount";
      this.label6.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.label6, "label6");
      this.label6.Name = "label6";
      this.label8.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.label8, "label8");
      this.label8.Name = "label8";
      this.labelLicense.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.labelLicense, "labelLicense");
      this.labelLicense.Name = "labelLicense";
      this.labelName.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.labelName, "labelName");
      this.labelName.Name = "labelName";
      this.timerRefresh.Enabled = true;
      this.timerRefresh.Interval = 500;
      this.timerRefresh.Tick += new EventHandler(this.timerRefresh_Tick);
      this.groupBox1.BackColor = Color.Transparent;
      this.groupBox1.Controls.Add((Control) this.label6);
      this.groupBox1.Controls.Add((Control) this.labelLicense);
      this.groupBox1.Controls.Add((Control) this.labelName);
      this.groupBox1.Controls.Add((Control) this.label8);
      componentResourceManager.ApplyResources((object) this.groupBox1, "groupBox1");
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.TabStop = false;
      this.groupBox2.BackColor = Color.Transparent;
      this.groupBox2.Controls.Add((Control) this.pictureBox1);
      this.groupBox2.Controls.Add((Control) this.labelStatus);
      this.groupBox2.Controls.Add((Control) this.label3);
      this.groupBox2.Controls.Add((Control) this.label4);
      this.groupBox2.Controls.Add((Control) this.labelAntennaCount);
      this.groupBox2.Controls.Add((Control) this.label5);
      this.groupBox2.Controls.Add((Control) this.labelPigeonCount);
      this.groupBox2.Controls.Add((Control) this.label7);
      this.groupBox2.Controls.Add((Control) this.labelRaceCount);
      componentResourceManager.ApplyResources((object) this.groupBox2, "groupBox2");
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.TabStop = false;
      componentResourceManager.ApplyResources((object) this.pictureBox1, "pictureBox1");
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.TabStop = false;
      componentResourceManager.ApplyResources((object) this.buttonExit, "buttonExit");
      this.buttonExit.DialogResult = DialogResult.Cancel;
      this.buttonExit.ImageList = this.imageList2;
      this.buttonExit.Name = "buttonExit";
      this.buttonExit.UseVisualStyleBackColor = true;
      this.buttonExit.Click += new EventHandler(this.buttonExit_Click);
      componentResourceManager.ApplyResources((object) this.buttonOptions, "buttonOptions");
      this.buttonOptions.ImageList = this.imageList2;
      this.buttonOptions.Name = "buttonOptions";
      this.buttonOptions.UseVisualStyleBackColor = true;
      this.buttonOptions.Click += new EventHandler(this.buttonOptions_Click);
      componentResourceManager.ApplyResources((object) this.groupBox3, "groupBox3");
      this.groupBox3.BackColor = Color.Transparent;
      this.groupBox3.Controls.Add((Control) this.dataGridView2);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.TabStop = false;
      this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView2.Columns.AddRange((DataGridViewColumn) this.ShowColumn, (DataGridViewColumn) this.PigeonCountColumn, (DataGridViewColumn) this.NameColumn, (DataGridViewColumn) this.ClubColumn, (DataGridViewColumn) this.DateColumn, (DataGridViewColumn) this.TimeColumn, (DataGridViewColumn) this.DistanceColumn, (DataGridViewColumn) this.Yards, (DataGridViewColumn) this.MailColumn, (DataGridViewColumn) this.Mail2Column, (DataGridViewColumn) this.PigCloud, (DataGridViewColumn) this.BriconWebColumn, (DataGridViewColumn) this.PlaySoundColumn, (DataGridViewColumn) this.SpeedColumn);
      componentResourceManager.ApplyResources((object) this.dataGridView2, "dataGridView2");
      this.dataGridView2.EditMode = DataGridViewEditMode.EditOnEnter;
      this.dataGridView2.Name = "dataGridView2";
      this.dataGridView2.CellClick += new DataGridViewCellEventHandler(this.dataGridView2_CellClick);
      this.dataGridView2.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dataGridView2_CellFormatting);
      this.dataGridView2.CellLeave += new DataGridViewCellEventHandler(this.dataGridView2_CellLeave);
      this.dataGridView2.CellValidated += new DataGridViewCellEventHandler(this.dataGridView2_CellValidated);
      this.dataGridView2.CellValueChanged += new DataGridViewCellEventHandler(this.dataGridView2_CellValueChanged);
      this.dataGridView2.KeyDown += new KeyEventHandler(this.dataGridView2_KeyDown);
      this.dataGridView2.MouseDown += new MouseEventHandler(this.dataGridView2_MouseDown);
      this.ShowColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.ShowColumn.DataPropertyName = "Show";
      componentResourceManager.ApplyResources((object) this.ShowColumn, "ShowColumn");
      this.ShowColumn.Name = "ShowColumn";
      this.PigeonCountColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
      this.PigeonCountColumn.DataPropertyName = "PigeonCount";
      componentResourceManager.ApplyResources((object) this.PigeonCountColumn, "PigeonCountColumn");
      this.PigeonCountColumn.Name = "PigeonCountColumn";
      this.PigeonCountColumn.ReadOnly = true;
      this.NameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.NameColumn.DataPropertyName = "RaceName";
      componentResourceManager.ApplyResources((object) this.NameColumn, "NameColumn");
      this.NameColumn.Name = "NameColumn";
      this.NameColumn.ReadOnly = true;
      this.NameColumn.Resizable = DataGridViewTriState.True;
      this.NameColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.ClubColumn.DataPropertyName = "ClubID";
      this.ClubColumn.FillWeight = 50f;
      componentResourceManager.ApplyResources((object) this.ClubColumn, "ClubColumn");
      this.ClubColumn.Name = "ClubColumn";
      this.ClubColumn.ReadOnly = true;
      this.DateColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      this.DateColumn.DataPropertyName = "ReleaseDate";
      componentResourceManager.ApplyResources((object) this.DateColumn, "DateColumn");
      this.DateColumn.Name = "DateColumn";
      this.TimeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      this.TimeColumn.DataPropertyName = "ReleaseTime";
      componentResourceManager.ApplyResources((object) this.TimeColumn, "TimeColumn");
      this.TimeColumn.Name = "TimeColumn";
      this.DistanceColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.DistanceColumn.DataPropertyName = "DistanceInMeter";
      componentResourceManager.ApplyResources((object) this.DistanceColumn, "DistanceColumn");
      this.DistanceColumn.Name = "DistanceColumn";
      this.DistanceColumn.Resizable = DataGridViewTriState.True;
      this.DistanceColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.Yards.DataPropertyName = "DistanceYards";
      componentResourceManager.ApplyResources((object) this.Yards, "Yards");
      this.Yards.Name = "Yards";
      this.MailColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.MailColumn.DataPropertyName = "Email";
      componentResourceManager.ApplyResources((object) this.MailColumn, "MailColumn");
      this.MailColumn.Name = "MailColumn";
      this.Mail2Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.Mail2Column.DataPropertyName = "Email2";
      componentResourceManager.ApplyResources((object) this.Mail2Column, "Mail2Column");
      this.Mail2Column.Name = "Mail2Column";
      this.PigCloud.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.PigCloud.DataPropertyName = "PigeonCloud";
      componentResourceManager.ApplyResources((object) this.PigCloud, "PigCloud");
      this.PigCloud.Name = "PigCloud";
      this.BriconWebColumn.DataPropertyName = "ActiveInBriconWeb";
      componentResourceManager.ApplyResources((object) this.BriconWebColumn, "BriconWebColumn");
      this.BriconWebColumn.Name = "BriconWebColumn";
      this.PlaySoundColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.PlaySoundColumn.DataPropertyName = "PlaySound";
      componentResourceManager.ApplyResources((object) this.PlaySoundColumn, "PlaySoundColumn");
      this.PlaySoundColumn.Name = "PlaySoundColumn";
      this.SpeedColumn.DataPropertyName = "Speed";
      componentResourceManager.ApplyResources((object) this.SpeedColumn, "SpeedColumn");
      this.SpeedColumn.Name = "SpeedColumn";
      componentResourceManager.ApplyResources((object) this.progressBar1, "progressBar1");
      this.progressBar1.Maximum = 60;
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Style = ProgressBarStyle.Continuous;
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.BackColor = Color.Transparent;
      this.label1.Name = "label1";
      this.imageList3.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageList3.ImageStream");
      this.imageList3.TransparentColor = Color.Magenta;
      this.imageList3.Images.SetKeyName(0, "BAExtreme.bmp");
      this.timerSendEmailStarter.Enabled = true;
      this.timerSendEmailStarter.Interval = 10000;
      this.timerSendEmailStarter.Tick += new EventHandler(this.timerSendEmailStarter_Tick);
      this.timerEndEdit.Interval = 500;
      this.timerEndEdit.Tick += new EventHandler(this.timerEndEdit_Tick);
      componentResourceManager.ApplyResources((object) this.buttonSendMail, "buttonSendMail");
      this.buttonSendMail.ImageList = this.imageList2;
      this.buttonSendMail.Name = "buttonSendMail";
      this.buttonSendMail.UseVisualStyleBackColor = true;
      this.buttonSendMail.Click += new EventHandler(this.buttonSendMail_Click);
      componentResourceManager.ApplyResources((object) this.buttonRefresh, "buttonRefresh");
      this.buttonRefresh.ImageList = this.imageList2;
      this.buttonRefresh.Name = "buttonRefresh";
      this.buttonRefresh.UseVisualStyleBackColor = true;
      this.buttonRefresh.Click += new EventHandler(this.buttonRefresh_Click);
      componentResourceManager.ApplyResources((object) this.buttonClockFakePigeon, "buttonClockFakePigeon");
      this.buttonClockFakePigeon.Name = "buttonClockFakePigeon";
      this.buttonClockFakePigeon.UseVisualStyleBackColor = true;
      this.buttonClockFakePigeon.Click += new EventHandler(this.button1_Click);
      this.timerRefreshBriconWeb.Tick += new EventHandler(this.timerRefreshBriconWeb_Tick);
      componentResourceManager.ApplyResources((object) this.buttonBriconWeb, "buttonBriconWeb");
      this.buttonBriconWeb.ImageList = this.imageList2;
      this.buttonBriconWeb.Name = "buttonBriconWeb";
      this.buttonBriconWeb.UseVisualStyleBackColor = true;
      this.buttonBriconWeb.Click += new EventHandler(this.button2_Click);
      componentResourceManager.ApplyResources((object) this.buttonPrint, "buttonPrint");
      this.buttonPrint.ImageList = this.imageList2;
      this.buttonPrint.Name = "buttonPrint";
      this.buttonPrint.UseVisualStyleBackColor = true;
      this.buttonPrint.Click += new EventHandler(this.buttonPrint_Click);
      this.groupBoxTotals.BackColor = Color.Transparent;
      this.groupBoxTotals.Controls.Add((Control) this.labelCountYoungs);
      this.groupBoxTotals.Controls.Add((Control) this.labelTotalYoungs);
      this.groupBoxTotals.Controls.Add((Control) this.labelCountYearlings);
      this.groupBoxTotals.Controls.Add((Control) this.labelCountOld);
      this.groupBoxTotals.Controls.Add((Control) this.labelTotalYearlings);
      this.groupBoxTotals.Controls.Add((Control) this.labelTotalOld);
      componentResourceManager.ApplyResources((object) this.groupBoxTotals, "groupBoxTotals");
      this.groupBoxTotals.Name = "groupBoxTotals";
      this.groupBoxTotals.TabStop = false;
      this.labelCountYoungs.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.labelCountYoungs, "labelCountYoungs");
      this.labelCountYoungs.Name = "labelCountYoungs";
      this.labelTotalYoungs.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.labelTotalYoungs, "labelTotalYoungs");
      this.labelTotalYoungs.Name = "labelTotalYoungs";
      this.labelCountYearlings.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.labelCountYearlings, "labelCountYearlings");
      this.labelCountYearlings.Name = "labelCountYearlings";
      this.labelCountOld.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.labelCountOld, "labelCountOld");
      this.labelCountOld.Name = "labelCountOld";
      this.labelTotalYearlings.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.labelTotalYearlings, "labelTotalYearlings");
      this.labelTotalYearlings.Name = "labelTotalYearlings";
      this.labelTotalOld.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.labelTotalOld, "labelTotalOld");
      this.labelTotalOld.Name = "labelTotalOld";
      this.timerNoSpeedRefresh.Interval = 10000;
      this.timerNoSpeedRefresh.Tick += new EventHandler(this.timerNoSpeedRefresh_Tick);
      this.imageList4.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageList4.ImageStream");
      this.imageList4.TransparentColor = Color.Magenta;
      this.imageList4.Images.SetKeyName(0, "BASPX.bmp");
      componentResourceManager.ApplyResources((object) this.buttonUploadReadout, "buttonUploadReadout");
      this.buttonUploadReadout.BackColor = Color.FromArgb((int) byte.MaxValue, 192, 128);
      this.buttonUploadReadout.FlatAppearance.BorderColor = Color.FromArgb((int) byte.MaxValue, 192, 128);
      this.buttonUploadReadout.FlatAppearance.BorderSize = 0;
      this.buttonUploadReadout.ImageList = this.imageList2;
      this.buttonUploadReadout.Name = "buttonUploadReadout";
      this.buttonUploadReadout.UseVisualStyleBackColor = false;
      this.buttonUploadReadout.Click += new EventHandler(this.buttonUploadReadout_Click);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.LightBlue;
      this.BackgroundImage = (Image) Resources.BackgroundMonitor;
      this.Controls.Add((Control) this.buttonUploadReadout);
      this.Controls.Add((Control) this.groupBoxTotals);
      this.Controls.Add((Control) this.buttonPrint);
      this.Controls.Add((Control) this.buttonBriconWeb);
      this.Controls.Add((Control) this.buttonClockFakePigeon);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.progressBar1);
      this.Controls.Add((Control) this.groupBox3);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.buttonExit);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.buttonRefresh);
      this.Controls.Add((Control) this.buttonSendMail);
      this.Controls.Add((Control) this.buttonOptions);
      this.DoubleBuffered = true;
      this.KeyPreview = true;
      this.Name = nameof (MonitorForm);
      this.ShowInTaskbar = false;
      this.WindowState = FormWindowState.Maximized;
      this.FormClosing += new FormClosingEventHandler(this.MonitorForm_FormClosing);
      this.Load += new EventHandler(this.MonitorForm_Load);
      this.KeyPress += new KeyPressEventHandler(this.MonitorForm_KeyPress);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.groupBox3.ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView2).EndInit();
      this.groupBoxTotals.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private delegate void InvokeDelegate(string text);
  }
}
