// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.ClubPrinterForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using BriconLib.Other;
using BriconLib.PrintManager;
using BriconLib.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BriconLib.UI
{
  public class ClubPrinterForm : Form
  {
    private string _readoutFileName = "c:\\Readouts\\clubreadout.xml";
    private BackgroundWorker _worker = new BackgroundWorker();
    private IContainer components;
    private Button button1;
    private Button button2;
    private CheckedListBox checkedListBoxComports;
    private Label label1;
    private Button buttonRefreshComPorts;
    private Label labelWaiting;
    private Button button3;
    private PrintDialog printDialog1;
    private TextBox textBox1;
    private CheckBox checkBox1;
    private CheckBox checkBox2;
    private Button button4;

    public ClubPrinterForm()
    {
      this.InitializeComponent();
      this._worker.DoWork += new DoWorkEventHandler(this._worker_DoWork);
      this._worker.ProgressChanged += new ProgressChangedEventHandler(this._worker_ProgressChanged);
      this._worker.WorkerSupportsCancellation = true;
      this._worker.WorkerReportsProgress = true;
      string path = "c:\\Readouts\\" + DateTime.Now.Year.ToString() + "\\Clubprinter\\";
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      string[] strArray = new string[6]
      {
        path,
        "Readout",
        null,
        null,
        null,
        null
      };
      DateTime now = DateTime.Now;
      strArray[2] = now.Year.ToString("D4");
      now = DateTime.Now;
      int num = now.Month;
      strArray[3] = num.ToString("D2");
      now = DateTime.Now;
      num = now.Day;
      strArray[4] = num.ToString("D2");
      strArray[5] = ".xml";
      this._readoutFileName = string.Concat(strArray);
      BriconLib.Printing.PrintHelper.SelectPrinter();
    }

    private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e) => this.textBox1.Text += e.UserState as string;

    private void ProcessInkorving(string data)
    {
      try
      {
        ClubPrinterDataSet dataSet = new ClubPrinterDataSet();
        ClubPrinterDataSet.SettingsRow row1 = dataSet.Settings.NewSettingsRow();
        int startIndex1 = 0;
        row1.DateTime = Conversion.DateTimeFromStrings(data.Substring(startIndex1, 6), data.Substring(startIndex1 + 6, 6));
        int startIndex2 = startIndex1 + 12;
        row1.ClubID = data.Substring(startIndex2, 4);
        int startIndex3 = startIndex2 + 4;
        row1.FlightID = data.Substring(startIndex3, 4);
        int startIndex4 = startIndex3 + 4;
        row1.FlightName = data.Substring(startIndex4, 12);
        int startIndex5 = startIndex4 + 12;
        row1.Name = Conversion.ToUnicode(data.Substring(startIndex5, 25)).Trim();
        int startIndex6 = startIndex5 + 25;
        row1.License = data.Substring(startIndex6, 10).Trim();
        int startIndex7 = startIndex6 + 10;
        row1.Address = data.Substring(startIndex7, 25);
        int startIndex8 = startIndex7 + 25;
        row1.ZipCode = data.Substring(startIndex8, 6);
        int startIndex9 = startIndex8 + 6;
        row1.City = data.Substring(startIndex9, 20);
        int startIndex10 = startIndex9 + 20;
        row1.CoordX = Conversion.CoordinateToString(Conversion.CoordinateToInt(data.Substring(startIndex10, 10)), true);
        int startIndex11 = startIndex10 + 10;
        row1.CoordY = Conversion.CoordinateToString(Conversion.CoordinateToInt(data.Substring(startIndex11, 10)), true);
        int startIndex12 = startIndex11 + 10;
        row1.BASerial = data.Substring(startIndex12, 20);
        int startIndex13 = startIndex12 + 20;
        row1.Serial = data.Substring(startIndex13, 19);
        int startIndex14 = startIndex13 + 19;
        string date1 = data.Substring(startIndex14, 6);
        int startIndex15 = startIndex14 + 6;
        row1.BasketingMasterTime = Conversion.DateTimeFromStrings(date1, data.Substring(startIndex15, 6));
        int startIndex16 = startIndex15 + 6;
        row1.BasketingInternalTime = Conversion.DateTimeFromStrings(date1, data.Substring(startIndex16, 6));
        int startIndex17 = startIndex16 + 6;
        row1.BasketingDiff = data.Substring(startIndex17, 4);
        int startIndex18 = startIndex17 + 4;
        string date2 = data.Substring(startIndex18, 6);
        int startIndex19 = startIndex18 + 6;
        row1.ReadOutMasterTime = Conversion.DateTimeFromStrings(date2, data.Substring(startIndex19, 6));
        int startIndex20 = startIndex19 + 6;
        row1.ReadOutInternalTime = Conversion.DateTimeFromStrings(date2, data.Substring(startIndex20, 6));
        int startIndex21 = startIndex20 + 6;
        row1.ReadOutDiff = data.Substring(startIndex21, 4);
        int startIndex22 = startIndex21 + 4;
        row1.Diff = data.Substring(startIndex22, 4);
        int startIndex23 = startIndex22 + 4;
        row1.Count = Convert.ToInt32(data.Substring(startIndex23, 4));
        int startIndex24 = startIndex23 + 4;
        dataSet.Settings.AddSettingsRow(row1);
        for (int index = 0; index < row1.Count; ++index)
        {
          ClubPrinterDataSet.PigeonsRow row2 = dataSet.Pigeons.NewPigeonsRow();
          row2.Nr = Convert.ToInt32(data.Substring(startIndex24, 4)).ToString();
          int startIndex25 = startIndex24 + 4;
          row2.ElBand = data.Substring(startIndex25, 8);
          int startIndex26 = startIndex25 + 8;
          row2.FedBand = data.Substring(startIndex26, 18).TrimStart();
          int startIndex27 = startIndex26 + 18;
          row2.FedBand += data.Substring(startIndex27, 4);
          int startIndex28 = startIndex27 + 4;
          row2.Time = Conversion.DateTimeFromStrings(data.Substring(startIndex28, 6), data.Substring(startIndex28 + 6, 6));
          int startIndex29 = startIndex28 + 12;
          row2.Position1 = Convert.ToInt32(data.Substring(startIndex29, 3));
          int startIndex30 = startIndex29 + 3;
          row2.Position2 = Convert.ToInt32(data.Substring(startIndex30, 3));
          int startIndex31 = startIndex30 + 3;
          row2.Position3 = Convert.ToInt32(data.Substring(startIndex31, 3));
          int startIndex32 = startIndex31 + 3;
          row2.Position4 = Convert.ToInt32(data.Substring(startIndex32, 3));
          startIndex24 = startIndex32 + 3 + 9;
          dataSet.Pigeons.AddPigeonsRow(row2);
        }
        if (this.checkBox1.Checked)
          new Thread((ThreadStart) (() => BriconLib.Printing.PrintHelper.PrintBasketingList(dataSet))).Start();
        if (!this.checkBox2.Checked)
          return;
        this.SaveReadout(dataSet);
      }
      catch (Exception ex)
      {
        this._worker.ReportProgress(0, (object) ("ERROR: " + ex.Message + "\r\n"));
        this._worker.ReportProgress(0, (object) ("ERROR: " + ex.ToString() + "\r\n"));
        this._worker.ReportProgress(0, (object) ("Data:" + data + "\r\n"));
      }
    }

    private void ProcessAfslag(string data)
    {
      try
      {
        ClubPrinterDataSet dataSet = new ClubPrinterDataSet();
        ClubPrinterDataSet.SettingsRow row1 = dataSet.Settings.NewSettingsRow();
        int startIndex1 = 0;
        row1.DateTime = Conversion.DateTimeFromStrings(data.Substring(startIndex1, 6), data.Substring(startIndex1 + 6, 6));
        int startIndex2 = startIndex1 + 12;
        row1.ClubID = data.Substring(startIndex2, 4);
        int startIndex3 = startIndex2 + 4;
        row1.FlightID = data.Substring(startIndex3, 4);
        int startIndex4 = startIndex3 + 4;
        row1.FlightName = data.Substring(startIndex4, 12);
        int startIndex5 = startIndex4 + 12;
        row1.Name = Conversion.ToUnicode(data.Substring(startIndex5, 25)).Trim();
        int startIndex6 = startIndex5 + 25;
        row1.License = data.Substring(startIndex6, 10).Trim();
        int startIndex7 = startIndex6 + 10;
        row1.Address = data.Substring(startIndex7, 25);
        int startIndex8 = startIndex7 + 25;
        row1.ZipCode = data.Substring(startIndex8, 6);
        int startIndex9 = startIndex8 + 6;
        row1.City = data.Substring(startIndex9, 20);
        int startIndex10 = startIndex9 + 20;
        row1.CoordX = Conversion.CoordinateToString(Conversion.CoordinateToInt(data.Substring(startIndex10, 10)), true);
        int startIndex11 = startIndex10 + 10;
        row1.CoordY = Conversion.CoordinateToString(Conversion.CoordinateToInt(data.Substring(startIndex11, 10)), true);
        int startIndex12 = startIndex11 + 10;
        row1.BASerial = data.Substring(startIndex12, 20);
        int startIndex13 = startIndex12 + 20;
        row1.Serial = data.Substring(startIndex13, 19);
        int startIndex14 = startIndex13 + 19;
        string date1 = data.Substring(startIndex14, 6);
        int startIndex15 = startIndex14 + 6;
        row1.BasketingMasterTime = Conversion.DateTimeFromStrings(date1, data.Substring(startIndex15, 6));
        int startIndex16 = startIndex15 + 6;
        row1.BasketingInternalTime = Conversion.DateTimeFromStrings(date1, data.Substring(startIndex16, 6));
        int startIndex17 = startIndex16 + 6;
        row1.BasketingDiff = data.Substring(startIndex17, 4);
        int startIndex18 = startIndex17 + 4;
        string date2 = data.Substring(startIndex18, 6);
        int startIndex19 = startIndex18 + 6;
        row1.ReadOutMasterTime = Conversion.DateTimeFromStrings(date2, data.Substring(startIndex19, 6));
        int startIndex20 = startIndex19 + 6;
        row1.ReadOutInternalTime = Conversion.DateTimeFromStrings(date2, data.Substring(startIndex20, 6));
        int startIndex21 = startIndex20 + 6;
        row1.ReadOutDiff = data.Substring(startIndex21, 4);
        int startIndex22 = startIndex21 + 4;
        row1.Diff = data.Substring(startIndex22, 4);
        int startIndex23 = startIndex22 + 4;
        row1.Count = Convert.ToInt32(data.Substring(startIndex23, 4));
        int pos1 = startIndex23 + 4;
        dataSet.Settings.AddSettingsRow(row1);
        int number = 1;
        bool newFormat = true;
        int pos2 = pos1;
        for (int index = 0; index < row1.Count; ++index)
        {
          bool clocked;
          ClubPrinterDataSet.PigeonsRow row2 = this.BuildPigeonRow(dataSet, data, ref pos1, newFormat, out clocked, ref number);
          if (clocked)
          {
            ++number;
            dataSet.Pigeons.AddPigeonsRow(row2);
          }
        }
        for (int index = 0; index < row1.Count & newFormat; ++index)
        {
          bool clocked;
          ClubPrinterDataSet.PigeonsRow row2 = this.BuildPigeonRow(dataSet, data, ref pos2, newFormat, out clocked, ref number);
          if (!clocked)
          {
            ++number;
            dataSet.Pigeons.AddPigeonsRow(row2);
          }
        }
        if (this.checkBox1.Checked)
          new Thread((ThreadStart) (() => BriconLib.Printing.PrintHelper.PrintReadOutList(dataSet))).Start();
        if (!this.checkBox2.Checked)
          return;
        this.SaveReadout(dataSet);
      }
      catch (Exception ex)
      {
        this._worker.ReportProgress(0, (object) ("ERROR: " + ex.Message + "\r\n"));
        this._worker.ReportProgress(0, (object) ("ERROR: " + ex.ToString() + "\r\n"));
        this._worker.ReportProgress(0, (object) ("Data:" + data + "\r\n"));
      }
    }

    private ClubPrinterDataSet.PigeonsRow BuildPigeonRow(
      ClubPrinterDataSet dataSet,
      string data,
      ref int pos,
      bool newFormat,
      out bool clocked,
      ref int number)
    {
      clocked = false;
      ClubPrinterDataSet.PigeonsRow pigeonsRow = dataSet.Pigeons.NewPigeonsRow();
      pigeonsRow.Nr = number.ToString();
      pos += 4;
      pigeonsRow.ElBand = data.Substring(pos, 8);
      pos += 8;
      pigeonsRow.FedBand = data.Substring(pos, 18).TrimStart();
      pos += 18;
      pigeonsRow.FedBand += data.Substring(pos, 4);
      pos += 4;
      pigeonsRow.Time = Conversion.DateTimeFromStrings(data.Substring(pos, 6), data.Substring(pos + 6, 6));
      pos += 12;
      pigeonsRow.Position1 = Convert.ToInt32(data.Substring(pos, 3));
      pos += 3;
      pigeonsRow.Position2 = Convert.ToInt32(data.Substring(pos, 3));
      pos += 3;
      pigeonsRow.Position3 = Convert.ToInt32(data.Substring(pos, 3));
      pos += 3;
      pigeonsRow.Position4 = Convert.ToInt32(data.Substring(pos, 3));
      pos += 3;
      if (newFormat)
      {
        pigeonsRow.Serial = data.Substring(pos, 8);
        pos += 8;
        clocked = data.Substring(pos, 1) != "2";
        bool flag = data.Substring(pos, 1) == "!";
        if (!clocked)
        {
          pigeonsRow.Evaluatie = "-";
          pigeonsRow.SetTimeNull();
        }
        else
          pigeonsRow.Evaluatie = !flag ? "OK" : "!";
        ++pos;
      }
      else
      {
        clocked = true;
        pigeonsRow.Serial = "-";
      }
      return pigeonsRow;
    }

    private void _worker_DoWork(object sender, DoWorkEventArgs e)
    {
      List<string> stringList = e.Argument as List<string>;
      List<SerialPort> serialPortList = new List<SerialPort>();
      foreach (string portName in stringList)
      {
        try
        {
          SerialPort serialPort = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
          serialPort.Open();
          serialPortList.Add(serialPort);
          this._worker.ReportProgress(0, (object) ("Port " + portName + " opened\r\n"));
        }
        catch (Exception ex)
        {
          this._worker.ReportProgress(0, (object) ("Error while opening " + portName + " " + ex.Message + "\r\n"));
        }
      }
      while (!this._worker.CancellationPending)
      {
        foreach (SerialPort serialPort in serialPortList)
        {
          serialPort.ReadTimeout = 2000;
          if (serialPort.BytesToRead > 1)
          {
            this._worker.ReportProgress(0, (object) "Bytes received\r\n");
            try
            {
              if (serialPort.ReadByte() == 27)
              {
                if (serialPort.ReadByte() == 27)
                {
                  this._worker.ReportProgress(0, (object) "Start receiving Datablock...\n");
                  StringBuilder stringBuilder = new StringBuilder();
                  int num = serialPort.ReadByte();
                  do
                  {
                    switch (num)
                    {
                      case 0:
                        num = 32;
                        break;
                      case 28:
                        goto label_17;
                    }
                    stringBuilder.Append((char) num);
                    num = serialPort.ReadByte();
                  }
                  while (!e.Cancel);
label_17:
                  if (serialPort.ReadByte() == 28)
                  {
                    string str = stringBuilder.ToString();
                    if (str.Contains("INKORVINGEN"))
                    {
                      string data = str.Substring(str.IndexOf("INKORVINGEN") + "INKORVINGEN".Length);
                      this._worker.ReportProgress(0, (object) "Basketing datablock received\r\n");
                      this.ProcessInkorving(data);
                    }
                    else if (str.Contains("BESTATIGINGEN"))
                    {
                      string data = str.Substring(str.IndexOf("BESTATIGINGEN") + "BESTATIGINGEN".Length);
                      this._worker.ReportProgress(0, (object) "Readout datablock received\r\n");
                      this.ProcessAfslag(data);
                    }
                    else
                      this._worker.ReportProgress(0, (object) "ERROR: Unknown datablock received, IGNORING\r\n");
                  }
                  else
                    this._worker.ReportProgress(0, (object) ("ERROR: Datablock without end received, IGNORING data :" + stringBuilder?.ToString()));
                }
              }
            }
            catch (TimeoutException ex)
            {
              this._worker.ReportProgress(0, (object) "ERROR: TimeOut\r\n");
            }
          }
          Thread.Sleep(50);
          if (this._worker.CancellationPending)
            break;
        }
      }
      try
      {
        foreach (Component component in serialPortList)
          component.Dispose();
      }
      catch (Exception ex)
      {
      }
    }

    private void button1_Click(object sender, EventArgs e) => this.Close();

    private void buttonRefreshComPorts_Click(object sender, EventArgs e)
    {
      this.checkedListBoxComports.Items.Clear();
      foreach (object portName in SerialPort.GetPortNames())
        this.checkedListBoxComports.SetItemChecked(this.checkedListBoxComports.Items.Add(portName), true);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.labelWaiting.Visible = !this.labelWaiting.Visible;
      if (!this.labelWaiting.Visible)
      {
        this._worker.CancelAsync();
        this.button2.Text = "Start";
      }
      else
      {
        this.button2.Text = "Stop";
        List<string> stringList = new List<string>();
        foreach (string checkedItem in this.checkedListBoxComports.CheckedItems)
          stringList.Add(checkedItem);
        this._worker.RunWorkerAsync((object) stringList);
      }
    }

    private void ClubPrinterForm_Load(object sender, EventArgs e) => this.buttonRefreshComPorts_Click(sender, e);

    private void button3_Click(object sender, EventArgs e)
    {
      int num = (int) this.printDialog1.ShowDialog();
    }

    private void ClubPrinterForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      this._worker.CancelAsync();
      Thread.Sleep(600);
    }

    private void button4_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.FileName = this._readoutFileName;
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      this._readoutFileName = saveFileDialog.FileName;
    }

    private void SaveReadout(ClubPrinterDataSet dataSet)
    {
      ReadOutDataSet readOutDataSet = new ReadOutDataSet();
      if (File.Exists(this._readoutFileName))
      {
        int num = (int) readOutDataSet.ReadXml(this._readoutFileName);
      }
      ClubPrinterDataSet.SettingsRow setting = dataSet.Settings[0];
      ReadOutDataSet.FancierRow fancierRow = readOutDataSet.Fancier.AddFancierRow(setting.License, setting.Name, setting.Address, setting.ZipCode, setting.City, setting.CoordX, setting.CoordY, setting.BASerial, 0M, "m", "0m", "", "", "", 0M);
      foreach (ClubPrinterDataSet.PigeonsRow pigeon in (TypedTableBase<ClubPrinterDataSet.PigeonsRow>) dataSet.Pigeons)
      {
        DateTime Time = DateTime.MinValue;
        if (!pigeon.IsTimeNull())
          Time = pigeon.Time;
        string Evaluation = "";
        if (!pigeon.IsEvaluatieNull())
          Evaluation = pigeon.Evaluatie;
        readOutDataSet.Pigeons.AddPigeonsRow(fancierRow.ID, pigeon.ElBand, pigeon.FedBand, setting.ClubID, setting.FlightID, pigeon.Position1, pigeon.Position2, pigeon.Position3, pigeon.Position4, Time, Evaluation, pigeon.Nr, 0);
      }
      readOutDataSet.Timers.AddTimersRow(fancierRow.ID, setting.ClubID, setting.FlightID, setting.BasketingMasterTime, setting.BasketingInternalTime, setting.BasketingDiff, setting.ReadOutMasterTime, setting.ReadOutInternalTime, setting.ReadOutDiff, setting.Diff);
      readOutDataSet.WriteXml(this._readoutFileName);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ClubPrinterForm));
      this.button1 = new Button();
      this.button2 = new Button();
      this.checkedListBoxComports = new CheckedListBox();
      this.label1 = new Label();
      this.buttonRefreshComPorts = new Button();
      this.labelWaiting = new Label();
      this.button3 = new Button();
      this.printDialog1 = new PrintDialog();
      this.textBox1 = new TextBox();
      this.checkBox2 = new CheckBox();
      this.button4 = new Button();
      this.checkBox1 = new CheckBox();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.button1, "button1");
      this.button1.Name = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      componentResourceManager.ApplyResources((object) this.button2, "button2");
      this.button2.Name = "button2";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.checkedListBoxComports.FormattingEnabled = true;
      componentResourceManager.ApplyResources((object) this.checkedListBoxComports, "checkedListBoxComports");
      this.checkedListBoxComports.Name = "checkedListBoxComports";
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      componentResourceManager.ApplyResources((object) this.buttonRefreshComPorts, "buttonRefreshComPorts");
      this.buttonRefreshComPorts.Name = "buttonRefreshComPorts";
      this.buttonRefreshComPorts.UseVisualStyleBackColor = true;
      this.buttonRefreshComPorts.Click += new EventHandler(this.buttonRefreshComPorts_Click);
      componentResourceManager.ApplyResources((object) this.labelWaiting, "labelWaiting");
      this.labelWaiting.Name = "labelWaiting";
      componentResourceManager.ApplyResources((object) this.button3, "button3");
      this.button3.Name = "button3";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.printDialog1.UseEXDialog = true;
      componentResourceManager.ApplyResources((object) this.textBox1, "textBox1");
      this.textBox1.Name = "textBox1";
      componentResourceManager.ApplyResources((object) this.checkBox2, "checkBox2");
      this.checkBox2.Checked = Settings.Default.SaveEachReadout;
      this.checkBox2.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "SaveEachReadout", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.button4, "button4");
      this.button4.Name = "button4";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new EventHandler(this.button4_Click);
      componentResourceManager.ApplyResources((object) this.checkBox1, "checkBox1");
      this.checkBox1.Checked = Settings.Default.PrintEachReadout;
      this.checkBox1.CheckState = CheckState.Checked;
      this.checkBox1.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "PrintEachReadout", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.checkBox2);
      this.Controls.Add((Control) this.checkBox1);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.labelWaiting);
      this.Controls.Add((Control) this.buttonRefreshComPorts);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.checkedListBoxComports);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Name = nameof (ClubPrinterForm);
      this.ShowInTaskbar = false;
      this.FormClosing += new FormClosingEventHandler(this.ClubPrinterForm_FormClosing);
      this.Load += new EventHandler(this.ClubPrinterForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
