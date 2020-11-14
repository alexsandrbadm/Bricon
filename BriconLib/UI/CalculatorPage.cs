// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.CalculatorPage
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.BCE;
using BriconLib.Data;
using BriconLib.Other;
using BriconLib.PrintManager;
using BriconLib.Properties;
using MultiLang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace BriconLib.UI
{
  public class CalculatorPage : UserControl
  {
    public static string CalculationsFolder;
    private string _extension = ".xml";
    private string _oldFileName = "";
    private int oldIndex = -1;
    private IContainer components;
    private ToolStrip toolStrip1;
    private ToolStripButton toolStripButtonPrint;
    private ToolStripButton toolStripButtonAdd;
    private ListBox listBoxCalculations;
    private Label label1;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton toolStripButtonDeleteCalculation;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripButton toolStripButtonExport;
    private ToolStripButton toolStripButton4;
    private TabControl tabControlDetail;
    private TabPage tabPageDetails;
    private ListBox listBoxReadOuts;
    private ToolStrip toolStrip2;
    private ToolStripButton toolStripButtonReadFlightdata;
    private ToolStripButton toolStripButtonManualInput;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripButton toolStripButtonAddReadOut;
    private ToolStripButton toolStripButtonViewReadOut;
    private ToolStripButton toolStripButtonDeleteReadOut;
    private Panel panel1;
    private ComboBox comboBoxFlight;
    private DateTimePicker dateTimePickerReleaseTime;
    private DateTimePicker dateTimePickerReleaseDate;
    private TextBox textBoxClub;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label2;
    private TabPage tabPageResults;
    private DataGridView dataGridView1;
    private BindingSource resultsBindingSource;
    private CalculationDataSet calculationDataSet;
    private BindingSource readOutsBindingSource;
    private BindingSource calculationDataSetBindingSource;
    private OpenFileDialog openFileDialog;
    private BindingSource informationBindingSource;
    private BindingSource lossingsplaatsBindingSource;
    private BCEDataSet bCEDataSet;
    private TextBox textBoxName;
    private TextBox textBoxRemarks;
    private Label labelPrices;
    private TextBox textBoxPrices;
    private Label labelRemarks;
    private MaskedTextBox maskedTextBoxCoordinateY;
    private MaskedTextBox maskedTextBoxCoordinateX;
    private TextBox textBoxCoordinateX;
    private TextBox textBoxCoordinateY;
    private CheckBox checkBoxPrintFirstPigeon;
    private Label labelTotalFanciers;
    private Label labelTotalPigeons;
    private GroupBox groupBox1;
    private ToolStripButton toolStripButtonPrintSettings;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripButton toolStripButtonChampions;
    private ComboBox comboBoxYear;
    private CheckBox checkBox2DayRace;
    private DateTimePicker dateTimePickerFrom;
    private Label label6;
    private DateTimePicker dateTimePickerTo;
    private DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn fancierNameDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn ringNumberDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn clockingTimeDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn CorrectedTime;
    private DataGridViewTextBoxColumn FlightTime;
    private DataGridViewTextBoxColumn Distance;
    private DataGridViewTextBoxColumn Speed;
    private DataGridViewTextBoxColumn Basketed;
    private DataGridViewTextBoxColumn ClubID;
    private DataGridViewTextBoxColumn Position3;
    private DataGridViewTextBoxColumn Position4;
    private DataGridViewTextBoxColumn Percentage;
    private DataGridViewTextBoxColumn FCIAB;
    private DataGridViewTextBoxColumn FCICD;
    private DataGridViewTextBoxColumn FCIE;
    private DataGridViewTextBoxColumn Position2;
    private DataGridViewTextBoxColumn Position1;
    private DataGridViewTextBoxColumn FCI;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripButton toolStripButton1;
    private Label labelTimeZoneHours;
    private Label labelTimeZone;
    private NumericUpDown numericUpDownTimeZone;
    private NumericUpDown numericUpDown2;
    private NumericUpDown numericUpDown1;
    private Label labelDistance2;
    private Label labelDistance;
    private NumericUpDown numericUpDownDistance;

    public CalculatorPage()
    {
      this.InitializeComponent();
      CalculatorPage.CalculationsFolder = "c:\\ReadOuts\\" + DateTime.Now.Year.ToString() + "\\Calculations\\";
      DateTime now;
      if (Directory.Exists("C:\\Readouts\\Calculations") && !Directory.Exists("C:\\Readouts\\" + DateTime.Now.Year.ToString() + "\\Calculations"))
      {
        if (!Directory.Exists("c:\\ReadOuts\\" + DateTime.Now.Year.ToString() + "\\"))
          Directory.CreateDirectory("c:\\ReadOuts\\" + DateTime.Now.Year.ToString() + "\\");
        Directory.Move("C:\\Readouts\\Calculations", "C:\\Readouts\\" + DateTime.Now.Year.ToString() + "\\Calculations");
        foreach (string file in Directory.GetFiles("c:\\ReadOuts\\", "*.xml"))
        {
          string sourceFileName = file;
          now = DateTime.Now;
          string destFileName = "c:\\ReadOuts\\" + now.Year.ToString() + "\\" + Path.GetFileName(file);
          System.IO.File.Move(sourceFileName, destFileName);
        }
      }
      if (!Directory.Exists(CalculatorPage.CalculationsFolder))
        Directory.CreateDirectory(CalculatorPage.CalculationsFolder);
      this.comboBoxYear.SelectedIndexChanged -= new EventHandler(this.comboBoxYear_SelectedIndexChanged);
      ComboBox comboBoxYear = this.comboBoxYear;
      now = DateTime.Now;
      string str = now.Year.ToString();
      comboBoxYear.SelectedItem = (object) str;
      this.comboBoxYear.SelectedIndexChanged += new EventHandler(this.comboBoxYear_SelectedIndexChanged);
    }

    private void toolStripButtonReadFlightdata_Click(object sender, EventArgs e)
    {
      MainForm.Instance.communicationsPanel.IgnoreErrors = true;
      int num = (int) new FlightReadoutForm().ShowDialog();
      MainForm.Instance.communicationsPanel.buttonClearBA_Click(sender, e);
      MainForm.Instance.communicationsPanel.IgnoreErrors = false;
    }

    private void toolStripButtonManualInput_Click(object sender, EventArgs e)
    {
      int num = (int) new ManualInputFlightForm().ShowDialog();
    }

    private void toolStripButtonAddReadOut_Click(object sender, EventArgs e)
    {
      if (this.openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      foreach (string fileName in this.openFileDialog.FileNames)
      {
        try
        {
          ReadOutDataSet readOutDataSet = new ReadOutDataSet();
          if (!System.IO.File.ReadAllText(fileName).StartsWith("<"))
          {
            BCEDatabase.DecryptFile(fileName, fileName + "tmp");
            int num = (int) readOutDataSet.ReadXml(fileName + "tmp");
            System.IO.File.Delete(fileName + "tmp");
          }
          else
          {
            int num1 = (int) readOutDataSet.ReadXml(fileName);
          }
          if (this.calculationDataSet.ReadOuts.Select("filename='" + fileName + "'").Length != 0)
          {
            int num2 = (int) MessageBox.Show(ml.ml_string(1399, "File already added: '") + fileName + "'");
          }
          else
            this.calculationDataSet.ReadOuts.AddReadOutsRow(fileName);
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ml.ml_string(603, "Invalid ReadOut file '") + fileName + "'");
        }
      }
      this.SaveDetailPage();
    }

    private void toolStripButtonViewReadOut_Click(object sender, EventArgs e)
    {
      if (this.listBoxReadOuts.SelectedItem == null)
        return;
      int num = (int) new ViewDataForm(((this.listBoxReadOuts.SelectedItem as DataRowView).Row as CalculationDataSet.ReadOutsRow).FileName).ShowDialog();
    }

    private void toolStripButtonDeleteReadOut_Click(object sender, EventArgs e)
    {
      if (!(this.listBoxReadOuts.SelectedItem is DataRowView))
        return;
      (this.listBoxReadOuts.SelectedItem as DataRowView).Row.Delete();
      this.listBoxReadOuts.Refresh();
      this.SaveDetailPage();
    }

    private void CalculatorPage_Load(object sender, EventArgs e) => this.lossingsplaatsBindingSource.DataSource = (object) BCEDatabase.DataSet;

    public void ActivatePage()
    {
      if (!Utils.IsCountry("BE"))
      {
        this.maskedTextBoxCoordinateX.Mask = "#00 00 00.00";
        this.maskedTextBoxCoordinateY.Mask = "#00 00 00.00";
      }
      else
      {
        this.maskedTextBoxCoordinateX.Mask = "00:00:00,0";
        this.maskedTextBoxCoordinateY.Mask = "00:00:00,0";
      }
      if (Utils.IsCountry("UK") || Utils.IsCountry("IR"))
        this.maskedTextBoxCoordinateX.Enabled = this.maskedTextBoxCoordinateY.Enabled = false;
      else
        this.maskedTextBoxCoordinateX.Enabled = this.maskedTextBoxCoordinateY.Enabled = true;
      if (Utils.IsCountry("KSA"))
        this.labelDistance.Visible = this.labelDistance2.Visible = this.numericUpDownDistance.Visible = true;
      else
        this.labelDistance.Visible = this.labelDistance2.Visible = this.numericUpDownDistance.Visible = false;
      this.RefreshCalculations();
      this.LoadDetailPage();
      this.toolStripButton1.Visible = OptionsPage.IsXmlUploadModuleLicensed();
      this.labelTimeZone.Visible = Settings.Default.UseTimeZone;
      this.numericUpDownTimeZone.Visible = Settings.Default.UseTimeZone;
      this.labelTimeZoneHours.Visible = Settings.Default.UseTimeZone;
    }

    public bool DeActivatePage() => this.SaveDetailPage();

    private void LoadDetailPage()
    {
      this.calculationDataSet.Clear();
      this.textBoxName.Text = this.listBoxCalculations.SelectedItem as string;
      if (this.textBoxName.Text == ml.ml_string(604, "New calculation"))
        this.textBoxName.Text = "";
      else if (System.IO.File.Exists(CalculatorPage.CalculationsFolder + this.textBoxName.Text + this._extension))
      {
        string str = CalculatorPage.CalculationsFolder + this.textBoxName.Text + this._extension;
        if (!System.IO.File.ReadAllText(str).StartsWith("<"))
        {
          BCEDatabase.DecryptFile(str, str + "tmp");
          int num = (int) this.calculationDataSet.ReadXml(str + "tmp");
          System.IO.File.Delete(str + "tmp");
        }
        else
        {
          int num1 = (int) this.calculationDataSet.ReadXml(str);
        }
      }
      this.calculationDataSet.AcceptChanges();
      if (this.calculationDataSet.Information.Count == 0)
        this.calculationDataSet.Information.AddInformationRow("", MainForm.Instance.clubsPage.GetActiveClubRow().ClubID, " ", DateTime.Now, Utils.UnitsUsed(), "", "", false, 0, 0, 0, 0, "", "", false, new DateTime(2000, 1, 1, 0, 0, 0), new DateTime(2000, 1, 1, 0, 0, 0), Convert.ToDecimal(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).TotalHours), 0, 0, 0M);
      this.tabControlDetail.Enabled = this.listBoxCalculations.SelectedIndex >= 0;
      int num2 = 0;
      if (!this.calculationDataSet.Information[0].IsTotalFanciersNull())
        num2 = this.calculationDataSet.Information[0].TotalFanciers;
      this.labelTotalFanciers.Text = string.Format(ml.ml_string(656, "{0} Fancier(s)"), (object) num2);
      int num3 = 0;
      if (!this.calculationDataSet.Information[0].IsTotalBaskettedNull())
        num3 = this.calculationDataSet.Information[0].TotalBasketted;
      this.labelTotalPigeons.Text = string.Format(ml.ml_string(657, "{0} Pigeon(s)"), (object) num3);
      this._oldFileName = this.textBoxName.Text;
    }

    private bool SaveDetailPage()
    {
      try
      {
        this.textBoxName.Focus();
        this.informationBindingSource.EndEdit();
        if (!this.tabControlDetail.Enabled)
          return true;
        foreach (char invalidFileNameChar in Path.GetInvalidFileNameChars())
          this.textBoxName.Text.Replace(invalidFileNameChar.ToString(), "");
        if (this.textBoxName.Text.Length == 0)
        {
          int num = (int) MessageBox.Show(ml.ml_string(605, "Please fill in a name"));
          return false;
        }
        if (this._oldFileName != "" && this._oldFileName != this.textBoxName.Text && System.IO.File.Exists(CalculatorPage.CalculationsFolder + this._oldFileName + this._extension))
          System.IO.File.Delete(CalculatorPage.CalculationsFolder + this._oldFileName + this._extension);
        this.Calculate();
        string fileName = CalculatorPage.CalculationsFolder + this.textBoxName.Text + this._extension;
        if (Utils.EncryptReadouts())
          this.calculationDataSet.WriteXml(fileName);
        else
          this.calculationDataSet.WriteXml(fileName);
        this.RefreshCalculations();
        return true;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ml.ml_string(606, "Could not save the calculation.") + ex.ToString());
        return false;
      }
    }

    private void RefreshCalculations()
    {
      object selectedItem = this.listBoxCalculations.SelectedItem;
      this.listBoxCalculations.Items.Clear();
      foreach (string file in Directory.GetFiles(CalculatorPage.CalculationsFolder, "*.xml"))
        this.listBoxCalculations.Items.Add((object) Path.GetFileNameWithoutExtension(file));
      this.listBoxCalculations.SelectedItem = selectedItem;
    }

    private void Calculate()
    {
      CalculationDataSet.ResultsDataTable resultsDataTable = new CalculationDataSet.ResultsDataTable();
      int val1 = 0;
      int num1 = 0;
      this.calculationDataSet.Results.Clear();
      Dictionary<int, int> dictionary = new Dictionary<int, int>();
      int num2 = 0;
      foreach (CalculationDataSet.ReadOutsRow readOutsRow in this.calculationDataSet.ReadOuts.Select())
      {
        ++num2;
        try
        {
          ReadOutDataSet readOutDataSet = new ReadOutDataSet();
          string fileName = readOutsRow.FileName;
          if (!System.IO.File.ReadAllText(fileName).StartsWith("<"))
          {
            BCEDatabase.DecryptFile(fileName, fileName + "tmp");
            int num3 = (int) readOutDataSet.ReadXml(fileName + "tmp");
            System.IO.File.Delete(fileName + "tmp");
          }
          else
          {
            int num4 = (int) readOutDataSet.ReadXml(fileName);
          }
          foreach (ReadOutDataSet.FancierRow fancierRow in (TypedTableBase<ReadOutDataSet.FancierRow>) readOutDataSet.Fancier)
          {
            ++num1;
            if (fancierRow.IsDistanceNull() && !Utils.UseCoordinatesInsteadOfDistance())
            {
              int num3 = (int) MessageBox.Show(ml.ml_string(607, "Error processing ") + readOutsRow.FileName + ml.ml_string(608, " : Distance is not filled in."));
              break;
            }
            ReadOutDataSet.TimersRow timersRow = (ReadOutDataSet.TimersRow) null;
            foreach (ReadOutDataSet.TimersRow timer in (TypedTableBase<ReadOutDataSet.TimersRow>) readOutDataSet.Timers)
            {
              if (timer.FancierID == fancierRow.ID)
                timersRow = timer;
            }
            if (timersRow != null)
            {
              foreach (ReadOutDataSet.PigeonsRow pigeon in (TypedTableBase<ReadOutDataSet.PigeonsRow>) readOutDataSet.Pigeons)
              {
                if (pigeon.FancierID == fancierRow.ID)
                {
                  ++val1;
                  if (!dictionary.ContainsKey(fancierRow.ID + num2 * 10000))
                    dictionary[fancierRow.ID + num2 * 10000] = 0;
                  dictionary[fancierRow.ID + num2 * 10000] = dictionary[fancierRow.ID + num2 * 10000] + 1;
                  if (!(pigeon.Evaluation != "1") || !(pigeon.Evaluation != "4"))
                  {
                    Decimal d = Utils.UseCoordinatesInsteadOfDistance() ? (Decimal) DistanceCalculator.CalculateDistance(this.calculationDataSet.Information[0].CoordinateX, this.calculationDataSet.Information[0].CoordinateY, Conversion.CoordinateToInt(fancierRow.CoordX), Conversion.CoordinateToInt(fancierRow.CoordY)) / 1000.0M : (!fancierRow.DistanceUnit.Equals("Imperial", StringComparison.InvariantCultureIgnoreCase) ? fancierRow.Distance : fancierRow.Distance / 0.621371192237334M);
                    TimeSpan timeSpan1 = timersRow.BasketingInternalTime - timersRow.BasketingMasterTime;
                    TimeSpan timeSpan2 = timersRow.ReadOutInternalTime - timersRow.ReadOutMasterTime - timeSpan1;
                    TimeSpan timeSpan3 = timersRow.ReadOutMasterTime - timersRow.BasketingMasterTime;
                    TimeSpan timeSpan4 = pigeon.Time - timersRow.BasketingMasterTime;
                    double num3 = 1.0;
                    if (timeSpan3.TotalSeconds != 0.0)
                      num3 = timeSpan4.TotalSeconds / timeSpan3.TotalSeconds;
                    timeSpan2 = new TimeSpan(Convert.ToInt64(timeSpan2.TotalSeconds * num3 * 1000.0 * 1000.0 * 10.0));
                    DateTime CorrectedTime = pigeon.Time - timeSpan2 - timeSpan1;
                    int CorrectedTimeDigit = (CorrectedTime.Millisecond + 50) / 100;
                    if (CorrectedTimeDigit > 9)
                    {
                      CorrectedTimeDigit = 0;
                      CorrectedTime += new TimeSpan(0, 0, 1);
                    }
                    if (Settings.Default.UseTimeZone)
                      CorrectedTime = CorrectedTime + TimeSpan.FromHours(Convert.ToDouble(this.calculationDataSet.Information[0].TimeZone)) - TimeSpan.FromHours(Convert.ToDouble(fancierRow.TimeZone));
                    TimeSpan timeSpan5 = CorrectedTime - this.calculationDataSet.Information[0].ReleaseTime;
                    if (!this.calculationDataSet.Information[0].IsTwoDayRaceNull() && this.calculationDataSet.Information[0].TwoDayRace)
                    {
                      DateTime dateTime1;
                      ref DateTime local1 = ref dateTime1;
                      int year1 = this.calculationDataSet.Information[0].ReleaseTime.Year;
                      int month1 = this.calculationDataSet.Information[0].ReleaseTime.Month;
                      DateTime dateTime2 = this.calculationDataSet.Information[0].ReleaseTime;
                      int day1 = dateTime2.Day;
                      dateTime2 = this.calculationDataSet.Information[0].TwoDayRaceFrom;
                      int hour1 = dateTime2.Hour;
                      dateTime2 = this.calculationDataSet.Information[0].TwoDayRaceFrom;
                      int minute1 = dateTime2.Minute;
                      dateTime2 = this.calculationDataSet.Information[0].TwoDayRaceFrom;
                      int second1 = dateTime2.Second;
                      local1 = new DateTime(year1, month1, day1, hour1, minute1, second1);
                      DateTime dateTime3;
                      ref DateTime local2 = ref dateTime3;
                      dateTime2 = this.calculationDataSet.Information[0].ReleaseTime;
                      int year2 = dateTime2.Year;
                      dateTime2 = this.calculationDataSet.Information[0].ReleaseTime;
                      int month2 = dateTime2.Month;
                      dateTime2 = this.calculationDataSet.Information[0].ReleaseTime;
                      int day2 = dateTime2.Day;
                      dateTime2 = this.calculationDataSet.Information[0].TwoDayRaceTo;
                      int hour2 = dateTime2.Hour;
                      dateTime2 = this.calculationDataSet.Information[0].TwoDayRaceTo;
                      int minute2 = dateTime2.Minute;
                      dateTime2 = this.calculationDataSet.Information[0].TwoDayRaceTo;
                      int second2 = dateTime2.Second;
                      local2 = new DateTime(year2, month2, day2, hour2, minute2, second2);
                      dateTime3 += new TimeSpan(1, 0, 0, 0);
                      DateTime dateTime4 = dateTime1 + new TimeSpan(1, 0, 0, 0);
                      DateTime dateTime5 = dateTime3 + new TimeSpan(1, 0, 0, 0);
                      TimeSpan timeSpan6 = dateTime3 - dateTime1;
                      timeSpan5 = !(CorrectedTime < dateTime3) || !(CorrectedTime > dateTime1) ? (!(CorrectedTime < dateTime1) ? (!(CorrectedTime < dateTime4) ? (!(CorrectedTime < dateTime5) ? CorrectedTime - this.calculationDataSet.Information[0].ReleaseTime - timeSpan6 - timeSpan6 : dateTime4 - this.calculationDataSet.Information[0].ReleaseTime - timeSpan6) : CorrectedTime - this.calculationDataSet.Information[0].ReleaseTime - timeSpan6) : CorrectedTime - this.calculationDataSet.Information[0].ReleaseTime) : dateTime1 - this.calculationDataSet.Information[0].ReleaseTime;
                    }
                    DateTime FlightTime = new DateTime(2000, 1, 1, 23, 59, 59);
                    if (timeSpan5.TotalSeconds > 0.0 && timeSpan5.Days < 31)
                      FlightTime = new DateTime(2000, 1, timeSpan5.Days + 1, timeSpan5.Hours, timeSpan5.Minutes, timeSpan5.Seconds);
                    Decimal Speed;
                    string distanceString;
                    Decimal num5;
                    if (Utils.UnitsUsed() == "Imperial")
                    {
                      Decimal num6 = d * 0.621371192237334M;
                      Speed = Math.Round(num6 * 1760M / (Decimal) timeSpan5.TotalMinutes, 4);
                      distanceString = Utils.GetDistanceString(num6);
                      num5 = Math.Round(num6, 4);
                    }
                    else
                    {
                      Speed = Math.Round(d * 1000M / (Decimal) timeSpan5.TotalMinutes, 3);
                      num5 = Math.Round(d, 3);
                      distanceString = Utils.GetDistanceString(num5);
                    }
                    resultsDataTable.AddResultsRow(fancierRow.ID + num2 * 10000, fancierRow.Name, pigeon.FedBand, pigeon.Time, num5, distanceString, Speed, CorrectedTime, 0, timersRow.ClubID, pigeon.Position1, pigeon.Position2, pigeon.Position3, pigeon.Position4, 0.0, 0.0, 0.0, 0.0, this.calculationDataSet.Information[0].ReleaseTime, this.calculationDataSet.Information[0].TotalBasketted, 0.0, this.calculationDataSet.Information[0].Flight, CorrectedTimeDigit, FlightTime, pigeon.IsTeamNbrNull() ? 0 : pigeon.TeamNbr, 0, fancierRow.NaamUnicode, fancierRow.GemeenteUnicode, fancierRow.License, 0M, 0M);
                  }
                }
              }
            }
          }
        }
        catch (Exception ex)
        {
          int num3 = (int) MessageBox.Show(ml.ml_string(607, "Error processing ") + readOutsRow.FileName + " : " + ex.Message);
        }
      }
      if (Utils.IsCountry("IQ") && !this.calculationDataSet.Information[0].IsManualPigeonCountNull() && this.calculationDataSet.Information[0].ManualPigeonCount != 0)
        val1 = this.calculationDataSet.Information[0].ManualPigeonCount;
      if (Utils.IsCountry("IQ") && !this.calculationDataSet.Information[0].IsManualFancierCountNull() && this.calculationDataSet.Information[0].ManualFancierCount != 0)
        num1 = this.calculationDataSet.Information[0].ManualFancierCount;
      int position = 1;
      foreach (CalculationDataSet.ResultsRow resultsRow in resultsDataTable.Select("", "Speed desc"))
      {
        if (dictionary.ContainsKey(resultsRow.Number))
        {
          int Basketed = dictionary[resultsRow.Number];
          double Percentage = Math.Round((double) position * 100.0 / (double) val1, 2);
          int Points100 = 101 - position;
          if (Points100 < 0)
            Points100 = 0;
          int int32_1 = Convert.ToInt32((double) val1 / 5.0);
          Decimal num3 = 100M;
          if (!BCEDatabase.DataSet.Settings[0].IsCalculationPrintFCIPercentageNull())
            num3 = BCEDatabase.DataSet.Settings[0].CalculationPrintFCIPercentage;
          int int32_2 = Convert.ToInt32((Decimal) val1 * num3 / 100M);
          double FCIAB = ((double) (int32_1 - position) + 1.0) * 100.0 / (double) int32_1;
          if (position == 1)
            FCIAB = 100.0;
          if (FCIAB < 0.0)
            FCIAB = 0.0;
          if (FCIAB > 100.0)
            FCIAB = 100.0;
          double FCI = ((double) (int32_2 - position) + 1.0) * 100.0 / (double) int32_2;
          if (position == 1)
            FCI = 100.0;
          if (FCI < 0.0)
            FCI = 0.0;
          if (FCI > 100.0)
            FCI = 100.0;
          double FCICD = (double) position * 1000.0 / (double) Math.Min(val1, 5000);
          double FCIE = (double) position * 1000.0 / (double) val1;
          Decimal distance = resultsRow.Distance;
          if (!this.calculationDataSet.Information[0].IsDistanceNull() && this.calculationDataSet.Information[0].Distance != 0M)
            distance = this.calculationDataSet.Information[0].Distance;
          Decimal OveralPoints = OveralPointsCalculator.CalcOveralPoints(position, distance);
          this.calculationDataSet.Results.AddResultsRow(position++, resultsRow.FancierName, resultsRow.RingNumber, resultsRow.ClockingTime, resultsRow.Distance, resultsRow.DistanceString, resultsRow.Speed, resultsRow.CorrectedTime, Basketed, resultsRow.ClubID, resultsRow.Position1, resultsRow.Position2, resultsRow.Position3, resultsRow.Position4, Percentage, FCIAB, FCICD, FCIE, this.calculationDataSet.Information[0].ReleaseTime, this.calculationDataSet.Information[0].TotalBasketted, FCI, this.calculationDataSet.Information[0].Flight, resultsRow.CorrectedTimeDigit, resultsRow.FlightTime, resultsRow.TeamNbr, Points100, resultsRow.NaamUnicode, resultsRow.GemeenteUnicode, resultsRow.License, OveralPoints, resultsRow.TimeZone);
        }
      }
      this.calculationDataSet.Information[0].Name = this.textBoxName.Text;
      this.calculationDataSet.Information[0].CoordinateXString = Conversion.CoordinateToString(this.calculationDataSet.Information[0].CoordinateX, true);
      this.calculationDataSet.Information[0].CoordinateYString = Conversion.CoordinateToString(this.calculationDataSet.Information[0].CoordinateY, true);
      this.calculationDataSet.Information[0].TotalBasketted = val1;
      this.calculationDataSet.Information[0].TotalFanciers = num1;
      this.labelTotalFanciers.Text = string.Format(ml.ml_string(656, "{0} Fancier(s)"), (object) this.calculationDataSet.Information[0].TotalFanciers);
      this.labelTotalPigeons.Text = string.Format(ml.ml_string(657, "{0} Pigeon(s)"), (object) this.calculationDataSet.Information[0].TotalBasketted);
    }

    private void listBoxCalculations_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.listBoxCalculations.SelectedIndexChanged -= new EventHandler(this.listBoxCalculations_SelectedIndexChanged);
      if (this.SaveDetailPage())
        this.LoadDetailPage();
      else
        this.listBoxCalculations.SelectedIndex = this.oldIndex;
      this.oldIndex = this.listBoxCalculations.SelectedIndex;
      this.listBoxCalculations.SelectedIndexChanged += new EventHandler(this.listBoxCalculations_SelectedIndexChanged);
      this.toolStripButton1.Enabled = this.listBoxCalculations.SelectedIndex != -1;
    }

    private void toolStripButtonAdd_Click(object sender, EventArgs e)
    {
      if (!this.SaveDetailPage())
        return;
      this.listBoxCalculations.SelectedIndexChanged -= new EventHandler(this.listBoxCalculations_SelectedIndexChanged);
      this.listBoxCalculations.Items.Add((object) ml.ml_string(604, "New calculation"));
      this.listBoxCalculations.SelectedIndex = this.listBoxCalculations.Items.Count - 1;
      this.listBoxCalculations.SelectedIndexChanged += new EventHandler(this.listBoxCalculations_SelectedIndexChanged);
      this.LoadDetailPage();
    }

    private void toolStripButtonDeleteCalculation_Click(object sender, EventArgs e)
    {
      if (this.listBoxCalculations.SelectedIndex == -1)
        return;
      this.listBoxCalculations.SelectedIndexChanged -= new EventHandler(this.listBoxCalculations_SelectedIndexChanged);
      System.IO.File.Delete(CalculatorPage.CalculationsFolder + (this.listBoxCalculations.SelectedItem as string) + this._extension);
      this.RefreshCalculations();
      this.LoadDetailPage();
      this.listBoxCalculations.SelectedIndexChanged += new EventHandler(this.listBoxCalculations_SelectedIndexChanged);
    }

    private void tabControlDetail_Deselecting(object sender, TabControlCancelEventArgs e)
    {
      if (e.TabPage != this.tabPageDetails)
        return;
      this.listBoxCalculations.SelectedIndexChanged -= new EventHandler(this.listBoxCalculations_SelectedIndexChanged);
      if (!this.SaveDetailPage())
        e.Cancel = true;
      this.listBoxCalculations.SelectedIndexChanged += new EventHandler(this.listBoxCalculations_SelectedIndexChanged);
    }

    private void toolStripButtonPrint_Click(object sender, EventArgs e)
    {
      if (this.listBoxCalculations.SelectedIndex == -1 || !this.SaveDetailPage())
        return;
      BriconLib.Printing.PrintHelper.PrintCalculation(this.calculationDataSet);
    }

    private void listBoxReadOuts_MouseDoubleClick(object sender, MouseEventArgs e) => this.toolStripButtonViewReadOut_Click(sender, (EventArgs) e);

    private void maskedTextBoxCoordinateX_Enter(object sender, EventArgs e) => (sender as MaskedTextBox).SelectAll();

    private void maskedTextBoxCoordinateX_Leave(object sender, EventArgs e) => this.textBoxCoordinateX.Text = Conversion.CoordinateToInt(this.maskedTextBoxCoordinateX.Text).ToString();

    private void textBoxCoordinateX_TextChanged(object sender, EventArgs e) => this.maskedTextBoxCoordinateX.Text = Conversion.CoordinateToString(this.textBoxCoordinateX.Text, true);

    private void textBoxCoordinateY_TextChanged(object sender, EventArgs e) => this.maskedTextBoxCoordinateY.Text = Conversion.CoordinateToString(this.textBoxCoordinateY.Text, true);

    private void maskedTextBoxCoordinateY_Enter(object sender, EventArgs e) => (sender as MaskedTextBox).SelectAll();

    private void maskedTextBoxCoordinateY_Leave(object sender, EventArgs e) => this.textBoxCoordinateY.Text = Conversion.CoordinateToInt(this.maskedTextBoxCoordinateY.Text).ToString();

    private void dateTimePickerReleaseDate_ValueChanged(object sender, EventArgs e) => this.dateTimePickerReleaseTime.Value = this.dateTimePickerReleaseDate.Value;

    private void dateTimePickerReleaseTime_Leave(object sender, EventArgs e) => this.dateTimePickerReleaseDate.Value = this.dateTimePickerReleaseTime.Value;

    private void toolStripButtonPrintSettings_Click(object sender, EventArgs e)
    {
      int num = (int) new CalculationPrintSettingsForm().ShowDialog();
    }

    private void toolStripButtonChampions_Click(object sender, EventArgs e)
    {
      int num = (int) new ChampionshipForm().ShowDialog();
    }

    private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.SaveDetailPage();
      CalculatorPage.CalculationsFolder = "c:\\ReadOuts\\" + this.comboBoxYear.SelectedItem?.ToString() + "\\Calculations\\";
      if (!Directory.Exists(CalculatorPage.CalculationsFolder))
        Directory.CreateDirectory(CalculatorPage.CalculationsFolder);
      this.ActivatePage();
    }

    private void checkBox2DayRace_CheckedChanged(object sender, EventArgs e)
    {
      this.dateTimePickerFrom.Enabled = this.checkBox2DayRace.Checked;
      this.dateTimePickerTo.Enabled = this.checkBox2DayRace.Checked;
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void comboBoxFlight_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!(this.comboBoxFlight.SelectedItem is DataRowView selectedItem) || !(selectedItem.Row is BCEDataSet.LossingsplaatsRow row))
        return;
      this.maskedTextBoxCoordinateX.Text = Conversion.CoordinateToString(row.LWX.ToString() + "0", true);
      this.maskedTextBoxCoordinateY.Text = Conversion.CoordinateToString(row.LWY.ToString() + "0", true);
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      if (this.listBoxCalculations.SelectedIndex != -1 && OptionsPage.IsXmlUploadModuleLicensed())
      {
        if (!this.SaveDetailPage())
          return;
        try
        {
          string str1 = "https://www.briconweb.com/BRS/uploadbceresult.php";
          int num = (int) MessageBox.Show("Uploading to " + str1 + ".");
          using (WebClient webClient = new WebClient())
          {
            XmlWriterSettings settings = new XmlWriterSettings()
            {
              Encoding = Encoding.UTF8
            };
            MemoryStream memoryStream = new MemoryStream();
            using (XmlWriter writer = XmlWriter.Create((Stream) memoryStream, settings))
              this.calculationDataSet.WriteXml(writer);
            string str2 = "?country=" + Settings.Default.Country + "&Name=" + WebUtility.HtmlEncode(this.textBoxName.Text) + string.Format("&Year={0}", this.comboBoxYear.SelectedItem) + "&AppKey=BCEOneTwoThree";
            if (this.calculationDataSet.Information.Count > 0)
            {
              CalculationDataSet.InformationRow informationRow = this.calculationDataSet.Information[0];
              str2 = str2 + "&club=" + WebUtility.HtmlEncode(informationRow.Club) + "&flight=" + WebUtility.HtmlEncode(informationRow.Flight) + "&releasetime=" + informationRow.ReleaseTime.ToString("O") + "&remarks=" + WebUtility.HtmlEncode(informationRow.Remarks);
            }
            webClient.UploadData(str1 + str2, memoryStream.ToArray());
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message);
        }
      }
      else
      {
        int num1 = (int) MessageBox.Show("Please select a calculation");
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
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (CalculatorPage));
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
      this.toolStrip1 = new ToolStrip();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolStripButtonAdd = new ToolStripButton();
      this.toolStripButton4 = new ToolStripButton();
      this.toolStripButtonDeleteCalculation = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.toolStripButtonExport = new ToolStripButton();
      this.toolStripButtonPrint = new ToolStripButton();
      this.toolStripButtonPrintSettings = new ToolStripButton();
      this.toolStripSeparator4 = new ToolStripSeparator();
      this.toolStripButtonChampions = new ToolStripButton();
      this.toolStripSeparator5 = new ToolStripSeparator();
      this.toolStripButton1 = new ToolStripButton();
      this.listBoxCalculations = new ListBox();
      this.label1 = new Label();
      this.tabControlDetail = new TabControl();
      this.tabPageDetails = new TabPage();
      this.listBoxReadOuts = new ListBox();
      this.readOutsBindingSource = new BindingSource(this.components);
      this.calculationDataSetBindingSource = new BindingSource(this.components);
      this.calculationDataSet = new CalculationDataSet();
      this.toolStrip2 = new ToolStrip();
      this.toolStripButtonReadFlightdata = new ToolStripButton();
      this.toolStripButtonManualInput = new ToolStripButton();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.toolStripButtonAddReadOut = new ToolStripButton();
      this.toolStripButtonViewReadOut = new ToolStripButton();
      this.toolStripButtonDeleteReadOut = new ToolStripButton();
      this.panel1 = new Panel();
      this.labelDistance2 = new Label();
      this.labelTimeZoneHours = new Label();
      this.labelDistance = new Label();
      this.labelTimeZone = new Label();
      this.numericUpDown2 = new NumericUpDown();
      this.informationBindingSource = new BindingSource(this.components);
      this.numericUpDown1 = new NumericUpDown();
      this.numericUpDownDistance = new NumericUpDown();
      this.numericUpDownTimeZone = new NumericUpDown();
      this.label6 = new Label();
      this.checkBox2DayRace = new CheckBox();
      this.groupBox1 = new GroupBox();
      this.labelTotalPigeons = new Label();
      this.labelTotalFanciers = new Label();
      this.checkBoxPrintFirstPigeon = new CheckBox();
      this.maskedTextBoxCoordinateY = new MaskedTextBox();
      this.maskedTextBoxCoordinateX = new MaskedTextBox();
      this.textBoxCoordinateX = new TextBox();
      this.textBoxCoordinateY = new TextBox();
      this.textBoxPrices = new TextBox();
      this.textBoxRemarks = new TextBox();
      this.comboBoxFlight = new ComboBox();
      this.lossingsplaatsBindingSource = new BindingSource(this.components);
      this.bCEDataSet = new BCEDataSet();
      this.dateTimePickerTo = new DateTimePicker();
      this.dateTimePickerFrom = new DateTimePicker();
      this.dateTimePickerReleaseTime = new DateTimePicker();
      this.dateTimePickerReleaseDate = new DateTimePicker();
      this.textBoxName = new TextBox();
      this.textBoxClub = new TextBox();
      this.labelRemarks = new Label();
      this.labelPrices = new Label();
      this.label5 = new Label();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.tabPageResults = new TabPage();
      this.dataGridView1 = new DataGridView();
      this.numberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.fancierNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.ringNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.clockingTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.CorrectedTime = new DataGridViewTextBoxColumn();
      this.FlightTime = new DataGridViewTextBoxColumn();
      this.Distance = new DataGridViewTextBoxColumn();
      this.Speed = new DataGridViewTextBoxColumn();
      this.Basketed = new DataGridViewTextBoxColumn();
      this.ClubID = new DataGridViewTextBoxColumn();
      this.Position3 = new DataGridViewTextBoxColumn();
      this.Position4 = new DataGridViewTextBoxColumn();
      this.Percentage = new DataGridViewTextBoxColumn();
      this.FCIAB = new DataGridViewTextBoxColumn();
      this.FCICD = new DataGridViewTextBoxColumn();
      this.FCIE = new DataGridViewTextBoxColumn();
      this.Position2 = new DataGridViewTextBoxColumn();
      this.Position1 = new DataGridViewTextBoxColumn();
      this.FCI = new DataGridViewTextBoxColumn();
      this.resultsBindingSource = new BindingSource(this.components);
      this.openFileDialog = new OpenFileDialog();
      this.comboBoxYear = new ComboBox();
      Label label1 = new Label();
      Label label2 = new Label();
      this.toolStrip1.SuspendLayout();
      this.tabControlDetail.SuspendLayout();
      this.tabPageDetails.SuspendLayout();
      ((ISupportInitialize) this.readOutsBindingSource).BeginInit();
      ((ISupportInitialize) this.calculationDataSetBindingSource).BeginInit();
      this.calculationDataSet.BeginInit();
      this.toolStrip2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.numericUpDown2.BeginInit();
      ((ISupportInitialize) this.informationBindingSource).BeginInit();
      this.numericUpDown1.BeginInit();
      this.numericUpDownDistance.BeginInit();
      this.numericUpDownTimeZone.BeginInit();
      this.groupBox1.SuspendLayout();
      ((ISupportInitialize) this.lossingsplaatsBindingSource).BeginInit();
      this.bCEDataSet.BeginInit();
      this.tabPageResults.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((ISupportInitialize) this.resultsBindingSource).BeginInit();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) label1, "labelSlash");
      label1.Name = "labelSlash";
      componentResourceManager.ApplyResources((object) label2, "labelCoordinates");
      label2.Name = "labelCoordinates";
      this.toolStrip1.Items.AddRange(new ToolStripItem[12]
      {
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.toolStripButtonAdd,
        (ToolStripItem) this.toolStripButton4,
        (ToolStripItem) this.toolStripButtonDeleteCalculation,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.toolStripButtonExport,
        (ToolStripItem) this.toolStripButtonPrint,
        (ToolStripItem) this.toolStripButtonPrintSettings,
        (ToolStripItem) this.toolStripSeparator4,
        (ToolStripItem) this.toolStripButtonChampions,
        (ToolStripItem) this.toolStripSeparator5,
        (ToolStripItem) this.toolStripButton1
      });
      componentResourceManager.ApplyResources((object) this.toolStrip1, "toolStrip1");
      this.toolStrip1.Name = "toolStrip1";
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator1, "toolStripSeparator1");
      this.toolStripButtonAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonAdd.Image = (Image) Resources.Add;
      componentResourceManager.ApplyResources((object) this.toolStripButtonAdd, "toolStripButtonAdd");
      this.toolStripButtonAdd.Name = "toolStripButtonAdd";
      this.toolStripButtonAdd.Click += new EventHandler(this.toolStripButtonAdd_Click);
      this.toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton4.Image = (Image) Resources.infoBubble;
      componentResourceManager.ApplyResources((object) this.toolStripButton4, "toolStripButton4");
      this.toolStripButton4.Name = "toolStripButton4";
      this.toolStripButtonDeleteCalculation.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonDeleteCalculation.Image = (Image) Resources.Delete;
      componentResourceManager.ApplyResources((object) this.toolStripButtonDeleteCalculation, "toolStripButtonDeleteCalculation");
      this.toolStripButtonDeleteCalculation.Name = "toolStripButtonDeleteCalculation";
      this.toolStripButtonDeleteCalculation.Click += new EventHandler(this.toolStripButtonDeleteCalculation_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator2, "toolStripSeparator2");
      this.toolStripButtonExport.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonExport.Image = (Image) Resources.GenerateRings;
      componentResourceManager.ApplyResources((object) this.toolStripButtonExport, "toolStripButtonExport");
      this.toolStripButtonExport.Name = "toolStripButtonExport";
      this.toolStripButtonPrint.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonPrint.Image = (Image) Resources.Print;
      componentResourceManager.ApplyResources((object) this.toolStripButtonPrint, "toolStripButtonPrint");
      this.toolStripButtonPrint.Name = "toolStripButtonPrint";
      this.toolStripButtonPrint.Click += new EventHandler(this.toolStripButtonPrint_Click);
      this.toolStripButtonPrintSettings.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonPrintSettings.Image = (Image) Resources.CheckRing;
      componentResourceManager.ApplyResources((object) this.toolStripButtonPrintSettings, "toolStripButtonPrintSettings");
      this.toolStripButtonPrintSettings.Name = "toolStripButtonPrintSettings";
      this.toolStripButtonPrintSettings.Click += new EventHandler(this.toolStripButtonPrintSettings_Click);
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator4, "toolStripSeparator4");
      this.toolStripButtonChampions.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonChampions.Image = (Image) Resources.medal;
      componentResourceManager.ApplyResources((object) this.toolStripButtonChampions, "toolStripButtonChampions");
      this.toolStripButtonChampions.Name = "toolStripButtonChampions";
      this.toolStripButtonChampions.Click += new EventHandler(this.toolStripButtonChampions_Click);
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator5, "toolStripSeparator5");
      this.toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
      componentResourceManager.ApplyResources((object) this.toolStripButton1, "toolStripButton1");
      this.toolStripButton1.Image = (Image) Resources.BriconWeb;
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Click += new EventHandler(this.toolStripButton1_Click);
      componentResourceManager.ApplyResources((object) this.listBoxCalculations, "listBoxCalculations");
      this.listBoxCalculations.FormattingEnabled = true;
      this.listBoxCalculations.Items.AddRange(new object[3]
      {
        (object) componentResourceManager.GetString("listBoxCalculations.Items"),
        (object) componentResourceManager.GetString("listBoxCalculations.Items1"),
        (object) componentResourceManager.GetString("listBoxCalculations.Items2")
      });
      this.listBoxCalculations.Name = "listBoxCalculations";
      this.listBoxCalculations.SelectedIndexChanged += new EventHandler(this.listBoxCalculations_SelectedIndexChanged);
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      componentResourceManager.ApplyResources((object) this.tabControlDetail, "tabControlDetail");
      this.tabControlDetail.Controls.Add((Control) this.tabPageDetails);
      this.tabControlDetail.Controls.Add((Control) this.tabPageResults);
      this.tabControlDetail.Name = "tabControlDetail";
      this.tabControlDetail.SelectedIndex = 0;
      this.tabControlDetail.Deselecting += new TabControlCancelEventHandler(this.tabControlDetail_Deselecting);
      this.tabPageDetails.Controls.Add((Control) this.listBoxReadOuts);
      this.tabPageDetails.Controls.Add((Control) this.toolStrip2);
      this.tabPageDetails.Controls.Add((Control) this.panel1);
      componentResourceManager.ApplyResources((object) this.tabPageDetails, "tabPageDetails");
      this.tabPageDetails.Name = "tabPageDetails";
      this.tabPageDetails.UseVisualStyleBackColor = true;
      this.listBoxReadOuts.DataSource = (object) this.readOutsBindingSource;
      this.listBoxReadOuts.DisplayMember = "FileName";
      componentResourceManager.ApplyResources((object) this.listBoxReadOuts, "listBoxReadOuts");
      this.listBoxReadOuts.FormattingEnabled = true;
      this.listBoxReadOuts.Name = "listBoxReadOuts";
      this.listBoxReadOuts.ValueMember = "ID";
      this.listBoxReadOuts.MouseDoubleClick += new MouseEventHandler(this.listBoxReadOuts_MouseDoubleClick);
      this.readOutsBindingSource.DataMember = "ReadOuts";
      this.readOutsBindingSource.DataSource = (object) this.calculationDataSetBindingSource;
      this.calculationDataSetBindingSource.DataSource = (object) this.calculationDataSet;
      this.calculationDataSetBindingSource.Position = 0;
      this.calculationDataSet.DataSetName = "CalculationDataSet";
      this.calculationDataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.toolStrip2.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.toolStripButtonReadFlightdata,
        (ToolStripItem) this.toolStripButtonManualInput,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.toolStripButtonAddReadOut,
        (ToolStripItem) this.toolStripButtonViewReadOut,
        (ToolStripItem) this.toolStripButtonDeleteReadOut
      });
      componentResourceManager.ApplyResources((object) this.toolStrip2, "toolStrip2");
      this.toolStrip2.Name = "toolStrip2";
      this.toolStripButtonReadFlightdata.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonReadFlightdata.Image = (Image) Resources.ReadFlightData;
      componentResourceManager.ApplyResources((object) this.toolStripButtonReadFlightdata, "toolStripButtonReadFlightdata");
      this.toolStripButtonReadFlightdata.Name = "toolStripButtonReadFlightdata";
      this.toolStripButtonReadFlightdata.Click += new EventHandler(this.toolStripButtonReadFlightdata_Click);
      this.toolStripButtonManualInput.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonManualInput.Image = (Image) Resources.CheckRing;
      componentResourceManager.ApplyResources((object) this.toolStripButtonManualInput, "toolStripButtonManualInput");
      this.toolStripButtonManualInput.Name = "toolStripButtonManualInput";
      this.toolStripButtonManualInput.Click += new EventHandler(this.toolStripButtonManualInput_Click);
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator3, "toolStripSeparator3");
      this.toolStripButtonAddReadOut.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonAddReadOut.Image = (Image) Resources.Add;
      componentResourceManager.ApplyResources((object) this.toolStripButtonAddReadOut, "toolStripButtonAddReadOut");
      this.toolStripButtonAddReadOut.Name = "toolStripButtonAddReadOut";
      this.toolStripButtonAddReadOut.Click += new EventHandler(this.toolStripButtonAddReadOut_Click);
      this.toolStripButtonViewReadOut.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonViewReadOut.Image = (Image) Resources.infoBubble;
      componentResourceManager.ApplyResources((object) this.toolStripButtonViewReadOut, "toolStripButtonViewReadOut");
      this.toolStripButtonViewReadOut.Name = "toolStripButtonViewReadOut";
      this.toolStripButtonViewReadOut.Click += new EventHandler(this.toolStripButtonViewReadOut_Click);
      this.toolStripButtonDeleteReadOut.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonDeleteReadOut.Image = (Image) Resources.Delete;
      componentResourceManager.ApplyResources((object) this.toolStripButtonDeleteReadOut, "toolStripButtonDeleteReadOut");
      this.toolStripButtonDeleteReadOut.Name = "toolStripButtonDeleteReadOut";
      this.toolStripButtonDeleteReadOut.Click += new EventHandler(this.toolStripButtonDeleteReadOut_Click);
      this.panel1.Controls.Add((Control) this.labelDistance2);
      this.panel1.Controls.Add((Control) this.labelTimeZoneHours);
      this.panel1.Controls.Add((Control) this.labelDistance);
      this.panel1.Controls.Add((Control) this.labelTimeZone);
      this.panel1.Controls.Add((Control) this.numericUpDown2);
      this.panel1.Controls.Add((Control) this.numericUpDown1);
      this.panel1.Controls.Add((Control) this.numericUpDownDistance);
      this.panel1.Controls.Add((Control) this.numericUpDownTimeZone);
      this.panel1.Controls.Add((Control) this.label6);
      this.panel1.Controls.Add((Control) this.checkBox2DayRace);
      this.panel1.Controls.Add((Control) this.groupBox1);
      this.panel1.Controls.Add((Control) this.checkBoxPrintFirstPigeon);
      this.panel1.Controls.Add((Control) this.maskedTextBoxCoordinateY);
      this.panel1.Controls.Add((Control) this.maskedTextBoxCoordinateX);
      this.panel1.Controls.Add((Control) label1);
      this.panel1.Controls.Add((Control) label2);
      this.panel1.Controls.Add((Control) this.textBoxCoordinateX);
      this.panel1.Controls.Add((Control) this.textBoxCoordinateY);
      this.panel1.Controls.Add((Control) this.textBoxPrices);
      this.panel1.Controls.Add((Control) this.textBoxRemarks);
      this.panel1.Controls.Add((Control) this.comboBoxFlight);
      this.panel1.Controls.Add((Control) this.dateTimePickerTo);
      this.panel1.Controls.Add((Control) this.dateTimePickerFrom);
      this.panel1.Controls.Add((Control) this.dateTimePickerReleaseTime);
      this.panel1.Controls.Add((Control) this.dateTimePickerReleaseDate);
      this.panel1.Controls.Add((Control) this.textBoxName);
      this.panel1.Controls.Add((Control) this.textBoxClub);
      this.panel1.Controls.Add((Control) this.labelRemarks);
      this.panel1.Controls.Add((Control) this.labelPrices);
      this.panel1.Controls.Add((Control) this.label5);
      this.panel1.Controls.Add((Control) this.label4);
      this.panel1.Controls.Add((Control) this.label3);
      this.panel1.Controls.Add((Control) this.label2);
      componentResourceManager.ApplyResources((object) this.panel1, "panel1");
      this.panel1.Name = "panel1";
      componentResourceManager.ApplyResources((object) this.labelDistance2, "labelDistance2");
      this.labelDistance2.Name = "labelDistance2";
      componentResourceManager.ApplyResources((object) this.labelTimeZoneHours, "labelTimeZoneHours");
      this.labelTimeZoneHours.Name = "labelTimeZoneHours";
      componentResourceManager.ApplyResources((object) this.labelDistance, "labelDistance");
      this.labelDistance.Name = "labelDistance";
      componentResourceManager.ApplyResources((object) this.labelTimeZone, "labelTimeZone");
      this.labelTimeZone.Name = "labelTimeZone";
      componentResourceManager.ApplyResources((object) this.numericUpDown2, "numericUpDown2");
      this.numericUpDown2.DataBindings.Add(new Binding("Value", (object) this.informationBindingSource, "ManualFancierCount", true));
      this.numericUpDown2.Maximum = new Decimal(new int[4]
      {
        10000,
        0,
        0,
        0
      });
      this.numericUpDown2.Name = "numericUpDown2";
      this.informationBindingSource.DataMember = "Information";
      this.informationBindingSource.DataSource = (object) this.calculationDataSet;
      componentResourceManager.ApplyResources((object) this.numericUpDown1, "numericUpDown1");
      this.numericUpDown1.DataBindings.Add(new Binding("Value", (object) this.informationBindingSource, "ManualPigeonCount", true));
      this.numericUpDown1.Maximum = new Decimal(new int[4]
      {
        100000,
        0,
        0,
        0
      });
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDownDistance.DataBindings.Add(new Binding("Value", (object) this.informationBindingSource, "Distance", true));
      componentResourceManager.ApplyResources((object) this.numericUpDownDistance, "numericUpDownDistance");
      this.numericUpDownDistance.Maximum = new Decimal(new int[4]
      {
        9999,
        0,
        0,
        0
      });
      this.numericUpDownDistance.Name = "numericUpDownDistance";
      this.numericUpDownTimeZone.DataBindings.Add(new Binding("Value", (object) this.informationBindingSource, "TimeZone", true));
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
      componentResourceManager.ApplyResources((object) this.label6, "label6");
      this.label6.Name = "label6";
      componentResourceManager.ApplyResources((object) this.checkBox2DayRace, "checkBox2DayRace");
      this.checkBox2DayRace.DataBindings.Add(new Binding("Checked", (object) this.informationBindingSource, "TwoDayRace", true));
      this.checkBox2DayRace.Name = "checkBox2DayRace";
      this.checkBox2DayRace.UseVisualStyleBackColor = true;
      this.checkBox2DayRace.CheckedChanged += new EventHandler(this.checkBox2DayRace_CheckedChanged);
      componentResourceManager.ApplyResources((object) this.groupBox1, "groupBox1");
      this.groupBox1.Controls.Add((Control) this.labelTotalPigeons);
      this.groupBox1.Controls.Add((Control) this.labelTotalFanciers);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.TabStop = false;
      componentResourceManager.ApplyResources((object) this.labelTotalPigeons, "labelTotalPigeons");
      this.labelTotalPigeons.Name = "labelTotalPigeons";
      componentResourceManager.ApplyResources((object) this.labelTotalFanciers, "labelTotalFanciers");
      this.labelTotalFanciers.Name = "labelTotalFanciers";
      componentResourceManager.ApplyResources((object) this.checkBoxPrintFirstPigeon, "checkBoxPrintFirstPigeon");
      this.checkBoxPrintFirstPigeon.DataBindings.Add(new Binding("Checked", (object) this.informationBindingSource, "AddFirstPigeonForFancier", true));
      this.checkBoxPrintFirstPigeon.Name = "checkBoxPrintFirstPigeon";
      this.checkBoxPrintFirstPigeon.UseVisualStyleBackColor = true;
      this.maskedTextBoxCoordinateY.BackColor = SystemColors.Window;
      componentResourceManager.ApplyResources((object) this.maskedTextBoxCoordinateY, "maskedTextBoxCoordinateY");
      this.maskedTextBoxCoordinateY.Name = "maskedTextBoxCoordinateY";
      this.maskedTextBoxCoordinateY.Enter += new EventHandler(this.maskedTextBoxCoordinateY_Enter);
      this.maskedTextBoxCoordinateY.Leave += new EventHandler(this.maskedTextBoxCoordinateY_Leave);
      this.maskedTextBoxCoordinateX.BackColor = SystemColors.Window;
      componentResourceManager.ApplyResources((object) this.maskedTextBoxCoordinateX, "maskedTextBoxCoordinateX");
      this.maskedTextBoxCoordinateX.Name = "maskedTextBoxCoordinateX";
      this.maskedTextBoxCoordinateX.Enter += new EventHandler(this.maskedTextBoxCoordinateX_Enter);
      this.maskedTextBoxCoordinateX.Leave += new EventHandler(this.maskedTextBoxCoordinateX_Leave);
      this.textBoxCoordinateX.BackColor = Color.White;
      this.textBoxCoordinateX.DataBindings.Add(new Binding("Text", (object) this.informationBindingSource, "CoordinateX", true));
      componentResourceManager.ApplyResources((object) this.textBoxCoordinateX, "textBoxCoordinateX");
      this.textBoxCoordinateX.Name = "textBoxCoordinateX";
      this.textBoxCoordinateX.TabStop = false;
      this.textBoxCoordinateX.TextChanged += new EventHandler(this.textBoxCoordinateX_TextChanged);
      this.textBoxCoordinateY.BackColor = Color.White;
      this.textBoxCoordinateY.DataBindings.Add(new Binding("Text", (object) this.informationBindingSource, "CoordinateY", true));
      componentResourceManager.ApplyResources((object) this.textBoxCoordinateY, "textBoxCoordinateY");
      this.textBoxCoordinateY.Name = "textBoxCoordinateY";
      this.textBoxCoordinateY.TabStop = false;
      this.textBoxCoordinateY.TextChanged += new EventHandler(this.textBoxCoordinateY_TextChanged);
      this.textBoxPrices.DataBindings.Add(new Binding("Text", (object) this.informationBindingSource, "Prices", true));
      componentResourceManager.ApplyResources((object) this.textBoxPrices, "textBoxPrices");
      this.textBoxPrices.Name = "textBoxPrices";
      componentResourceManager.ApplyResources((object) this.textBoxRemarks, "textBoxRemarks");
      this.textBoxRemarks.DataBindings.Add(new Binding("Text", (object) this.informationBindingSource, "Remarks", true));
      this.textBoxRemarks.Name = "textBoxRemarks";
      componentResourceManager.ApplyResources((object) this.comboBoxFlight, "comboBoxFlight");
      this.comboBoxFlight.DataBindings.Add(new Binding("Text", (object) this.informationBindingSource, "Flight", true));
      this.comboBoxFlight.DataSource = (object) this.lossingsplaatsBindingSource;
      this.comboBoxFlight.DisplayMember = "Losplaats";
      this.comboBoxFlight.FormattingEnabled = true;
      this.comboBoxFlight.Name = "comboBoxFlight";
      this.comboBoxFlight.ValueMember = "Code";
      this.comboBoxFlight.SelectedIndexChanged += new EventHandler(this.comboBoxFlight_SelectedIndexChanged);
      this.lossingsplaatsBindingSource.DataMember = "Lossingsplaats";
      this.lossingsplaatsBindingSource.DataSource = (object) this.bCEDataSet;
      this.lossingsplaatsBindingSource.Sort = "Losplaats";
      this.bCEDataSet.DataSetName = "BCEDataSet";
      this.bCEDataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.dateTimePickerTo.DataBindings.Add(new Binding("Value", (object) this.informationBindingSource, "TwoDayRaceTo", true));
      componentResourceManager.ApplyResources((object) this.dateTimePickerTo, "dateTimePickerTo");
      this.dateTimePickerTo.Format = DateTimePickerFormat.Time;
      this.dateTimePickerTo.Name = "dateTimePickerTo";
      this.dateTimePickerTo.ShowUpDown = true;
      this.dateTimePickerTo.Value = new DateTime(2008, 5, 8, 13, 6, 3, 0);
      this.dateTimePickerFrom.DataBindings.Add(new Binding("Value", (object) this.informationBindingSource, "TwoDayRaceFrom", true));
      componentResourceManager.ApplyResources((object) this.dateTimePickerFrom, "dateTimePickerFrom");
      this.dateTimePickerFrom.Format = DateTimePickerFormat.Time;
      this.dateTimePickerFrom.Name = "dateTimePickerFrom";
      this.dateTimePickerFrom.ShowUpDown = true;
      this.dateTimePickerFrom.Value = new DateTime(2008, 5, 8, 13, 6, 3, 0);
      this.dateTimePickerReleaseTime.Format = DateTimePickerFormat.Time;
      componentResourceManager.ApplyResources((object) this.dateTimePickerReleaseTime, "dateTimePickerReleaseTime");
      this.dateTimePickerReleaseTime.Name = "dateTimePickerReleaseTime";
      this.dateTimePickerReleaseTime.ShowUpDown = true;
      this.dateTimePickerReleaseTime.Value = new DateTime(2008, 5, 8, 13, 6, 3, 0);
      this.dateTimePickerReleaseTime.Leave += new EventHandler(this.dateTimePickerReleaseTime_Leave);
      this.dateTimePickerReleaseDate.DataBindings.Add(new Binding("Value", (object) this.informationBindingSource, "ReleaseTime", true, DataSourceUpdateMode.OnPropertyChanged, (object) null, "d"));
      this.dateTimePickerReleaseDate.Format = DateTimePickerFormat.Short;
      componentResourceManager.ApplyResources((object) this.dateTimePickerReleaseDate, "dateTimePickerReleaseDate");
      this.dateTimePickerReleaseDate.Name = "dateTimePickerReleaseDate";
      this.dateTimePickerReleaseDate.Value = new DateTime(2008, 4, 23, 0, 0, 0, 0);
      this.dateTimePickerReleaseDate.ValueChanged += new EventHandler(this.dateTimePickerReleaseDate_ValueChanged);
      componentResourceManager.ApplyResources((object) this.textBoxName, "textBoxName");
      this.textBoxName.Name = "textBoxName";
      componentResourceManager.ApplyResources((object) this.textBoxClub, "textBoxClub");
      this.textBoxClub.DataBindings.Add(new Binding("Text", (object) this.informationBindingSource, "Club", true));
      this.textBoxClub.Name = "textBoxClub";
      componentResourceManager.ApplyResources((object) this.labelRemarks, "labelRemarks");
      this.labelRemarks.Name = "labelRemarks";
      componentResourceManager.ApplyResources((object) this.labelPrices, "labelPrices");
      this.labelPrices.Name = "labelPrices";
      componentResourceManager.ApplyResources((object) this.label5, "label5");
      this.label5.Name = "label5";
      componentResourceManager.ApplyResources((object) this.label4, "label4");
      this.label4.Name = "label4";
      componentResourceManager.ApplyResources((object) this.label3, "label3");
      this.label3.Name = "label3";
      componentResourceManager.ApplyResources((object) this.label2, "label2");
      this.label2.Name = "label2";
      this.tabPageResults.Controls.Add((Control) this.dataGridView1);
      componentResourceManager.ApplyResources((object) this.tabPageResults, "tabPageResults");
      this.tabPageResults.Name = "tabPageResults";
      this.tabPageResults.UseVisualStyleBackColor = true;
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.numberDataGridViewTextBoxColumn, (DataGridViewColumn) this.fancierNameDataGridViewTextBoxColumn, (DataGridViewColumn) this.ringNumberDataGridViewTextBoxColumn, (DataGridViewColumn) this.clockingTimeDataGridViewTextBoxColumn, (DataGridViewColumn) this.CorrectedTime, (DataGridViewColumn) this.FlightTime, (DataGridViewColumn) this.Distance, (DataGridViewColumn) this.Speed, (DataGridViewColumn) this.Basketed, (DataGridViewColumn) this.ClubID, (DataGridViewColumn) this.Position3, (DataGridViewColumn) this.Position4, (DataGridViewColumn) this.Percentage, (DataGridViewColumn) this.FCIAB, (DataGridViewColumn) this.FCICD, (DataGridViewColumn) this.FCIE, (DataGridViewColumn) this.Position2, (DataGridViewColumn) this.Position1, (DataGridViewColumn) this.FCI);
      this.dataGridView1.DataSource = (object) this.resultsBindingSource;
      componentResourceManager.ApplyResources((object) this.dataGridView1, "dataGridView1");
      this.dataGridView1.MultiSelect = false;
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
      this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
      componentResourceManager.ApplyResources((object) this.numberDataGridViewTextBoxColumn, "numberDataGridViewTextBoxColumn");
      this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
      this.numberDataGridViewTextBoxColumn.ReadOnly = true;
      this.fancierNameDataGridViewTextBoxColumn.DataPropertyName = "FancierName";
      componentResourceManager.ApplyResources((object) this.fancierNameDataGridViewTextBoxColumn, "fancierNameDataGridViewTextBoxColumn");
      this.fancierNameDataGridViewTextBoxColumn.Name = "fancierNameDataGridViewTextBoxColumn";
      this.fancierNameDataGridViewTextBoxColumn.ReadOnly = true;
      this.ringNumberDataGridViewTextBoxColumn.DataPropertyName = "RingNumber";
      componentResourceManager.ApplyResources((object) this.ringNumberDataGridViewTextBoxColumn, "ringNumberDataGridViewTextBoxColumn");
      this.ringNumberDataGridViewTextBoxColumn.Name = "ringNumberDataGridViewTextBoxColumn";
      this.ringNumberDataGridViewTextBoxColumn.ReadOnly = true;
      this.clockingTimeDataGridViewTextBoxColumn.DataPropertyName = "ClockingTime";
      gridViewCellStyle1.Format = "G";
      gridViewCellStyle1.NullValue = (object) null;
      this.clockingTimeDataGridViewTextBoxColumn.DefaultCellStyle = gridViewCellStyle1;
      componentResourceManager.ApplyResources((object) this.clockingTimeDataGridViewTextBoxColumn, "clockingTimeDataGridViewTextBoxColumn");
      this.clockingTimeDataGridViewTextBoxColumn.Name = "clockingTimeDataGridViewTextBoxColumn";
      this.clockingTimeDataGridViewTextBoxColumn.ReadOnly = true;
      this.CorrectedTime.DataPropertyName = "CorrectedTime";
      gridViewCellStyle2.Format = "G";
      this.CorrectedTime.DefaultCellStyle = gridViewCellStyle2;
      componentResourceManager.ApplyResources((object) this.CorrectedTime, "CorrectedTime");
      this.CorrectedTime.Name = "CorrectedTime";
      this.CorrectedTime.ReadOnly = true;
      this.FlightTime.DataPropertyName = "DistanceString";
      gridViewCellStyle3.Format = "T";
      gridViewCellStyle3.NullValue = (object) null;
      this.FlightTime.DefaultCellStyle = gridViewCellStyle3;
      componentResourceManager.ApplyResources((object) this.FlightTime, "FlightTime");
      this.FlightTime.Name = "FlightTime";
      this.FlightTime.ReadOnly = true;
      this.Distance.DataPropertyName = "Speed";
      gridViewCellStyle4.Format = "N3";
      gridViewCellStyle4.NullValue = (object) null;
      this.Distance.DefaultCellStyle = gridViewCellStyle4;
      componentResourceManager.ApplyResources((object) this.Distance, "Distance");
      this.Distance.Name = "Distance";
      this.Distance.ReadOnly = true;
      this.Speed.DataPropertyName = "Basketed";
      gridViewCellStyle5.Format = "N2";
      gridViewCellStyle5.NullValue = (object) null;
      this.Speed.DefaultCellStyle = gridViewCellStyle5;
      componentResourceManager.ApplyResources((object) this.Speed, "Speed");
      this.Speed.Name = "Speed";
      this.Speed.ReadOnly = true;
      this.Basketed.DataPropertyName = "ClubID";
      componentResourceManager.ApplyResources((object) this.Basketed, "Basketed");
      this.Basketed.Name = "Basketed";
      this.Basketed.ReadOnly = true;
      this.ClubID.DataPropertyName = "Flight";
      componentResourceManager.ApplyResources((object) this.ClubID, "ClubID");
      this.ClubID.Name = "ClubID";
      this.ClubID.ReadOnly = true;
      this.Position3.DataPropertyName = "Position1";
      componentResourceManager.ApplyResources((object) this.Position3, "Position3");
      this.Position3.Name = "Position3";
      this.Position3.ReadOnly = true;
      this.Position4.DataPropertyName = "Position2";
      componentResourceManager.ApplyResources((object) this.Position4, "Position4");
      this.Position4.Name = "Position4";
      this.Position4.ReadOnly = true;
      this.Percentage.DataPropertyName = "Position3";
      componentResourceManager.ApplyResources((object) this.Percentage, "Percentage");
      this.Percentage.Name = "Percentage";
      this.Percentage.ReadOnly = true;
      this.FCIAB.DataPropertyName = "Position4";
      gridViewCellStyle6.Format = "N3";
      this.FCIAB.DefaultCellStyle = gridViewCellStyle6;
      componentResourceManager.ApplyResources((object) this.FCIAB, "FCIAB");
      this.FCIAB.Name = "FCIAB";
      this.FCIAB.ReadOnly = true;
      this.FCICD.DataPropertyName = "Percentage";
      gridViewCellStyle7.Format = "N3";
      this.FCICD.DefaultCellStyle = gridViewCellStyle7;
      componentResourceManager.ApplyResources((object) this.FCICD, "FCICD");
      this.FCICD.Name = "FCICD";
      this.FCICD.ReadOnly = true;
      this.FCIE.DataPropertyName = "FCIAB";
      gridViewCellStyle8.Format = "N3";
      this.FCIE.DefaultCellStyle = gridViewCellStyle8;
      componentResourceManager.ApplyResources((object) this.FCIE, "FCIE");
      this.FCIE.Name = "FCIE";
      this.FCIE.ReadOnly = true;
      this.Position2.DataPropertyName = "FCICD";
      componentResourceManager.ApplyResources((object) this.Position2, "Position2");
      this.Position2.Name = "Position2";
      this.Position2.ReadOnly = true;
      this.Position1.DataPropertyName = "FCIE";
      componentResourceManager.ApplyResources((object) this.Position1, "Position1");
      this.Position1.Name = "Position1";
      this.Position1.ReadOnly = true;
      this.FCI.DataPropertyName = "FCI";
      componentResourceManager.ApplyResources((object) this.FCI, "FCI");
      this.FCI.Name = "FCI";
      this.FCI.ReadOnly = true;
      this.resultsBindingSource.DataMember = "Results";
      this.resultsBindingSource.DataSource = (object) this.calculationDataSet;
      this.openFileDialog.DefaultExt = "xml";
      componentResourceManager.ApplyResources((object) this.openFileDialog, "openFileDialog");
      this.openFileDialog.InitialDirectory = "c:\\ReadOuts";
      this.openFileDialog.Multiselect = true;
      this.openFileDialog.RestoreDirectory = true;
      this.openFileDialog.ShowReadOnly = true;
      this.comboBoxYear.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxYear.FormattingEnabled = true;
      this.comboBoxYear.Items.AddRange(new object[27]
      {
        (object) componentResourceManager.GetString("comboBoxYear.Items"),
        (object) componentResourceManager.GetString("comboBoxYear.Items1"),
        (object) componentResourceManager.GetString("comboBoxYear.Items2"),
        (object) componentResourceManager.GetString("comboBoxYear.Items3"),
        (object) componentResourceManager.GetString("comboBoxYear.Items4"),
        (object) componentResourceManager.GetString("comboBoxYear.Items5"),
        (object) componentResourceManager.GetString("comboBoxYear.Items6"),
        (object) componentResourceManager.GetString("comboBoxYear.Items7"),
        (object) componentResourceManager.GetString("comboBoxYear.Items8"),
        (object) componentResourceManager.GetString("comboBoxYear.Items9"),
        (object) componentResourceManager.GetString("comboBoxYear.Items10"),
        (object) componentResourceManager.GetString("comboBoxYear.Items11"),
        (object) componentResourceManager.GetString("comboBoxYear.Items12"),
        (object) componentResourceManager.GetString("comboBoxYear.Items13"),
        (object) componentResourceManager.GetString("comboBoxYear.Items14"),
        (object) componentResourceManager.GetString("comboBoxYear.Items15"),
        (object) componentResourceManager.GetString("comboBoxYear.Items16"),
        (object) componentResourceManager.GetString("comboBoxYear.Items17"),
        (object) componentResourceManager.GetString("comboBoxYear.Items18"),
        (object) componentResourceManager.GetString("comboBoxYear.Items19"),
        (object) componentResourceManager.GetString("comboBoxYear.Items20"),
        (object) componentResourceManager.GetString("comboBoxYear.Items21"),
        (object) componentResourceManager.GetString("comboBoxYear.Items22"),
        (object) componentResourceManager.GetString("comboBoxYear.Items23"),
        (object) componentResourceManager.GetString("comboBoxYear.Items24"),
        (object) componentResourceManager.GetString("comboBoxYear.Items25"),
        (object) componentResourceManager.GetString("comboBoxYear.Items26")
      });
      componentResourceManager.ApplyResources((object) this.comboBoxYear, "comboBoxYear");
      this.comboBoxYear.Name = "comboBoxYear";
      this.comboBoxYear.SelectedIndexChanged += new EventHandler(this.comboBoxYear_SelectedIndexChanged);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.comboBoxYear);
      this.Controls.Add((Control) this.tabControlDetail);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.listBoxCalculations);
      this.Controls.Add((Control) this.toolStrip1);
      this.Name = nameof (CalculatorPage);
      this.Load += new EventHandler(this.CalculatorPage_Load);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.tabControlDetail.ResumeLayout(false);
      this.tabPageDetails.ResumeLayout(false);
      this.tabPageDetails.PerformLayout();
      ((ISupportInitialize) this.readOutsBindingSource).EndInit();
      ((ISupportInitialize) this.calculationDataSetBindingSource).EndInit();
      this.calculationDataSet.EndInit();
      this.toolStrip2.ResumeLayout(false);
      this.toolStrip2.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.numericUpDown2.EndInit();
      ((ISupportInitialize) this.informationBindingSource).EndInit();
      this.numericUpDown1.EndInit();
      this.numericUpDownDistance.EndInit();
      this.numericUpDownTimeZone.EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((ISupportInitialize) this.lossingsplaatsBindingSource).EndInit();
      this.bCEDataSet.EndInit();
      this.tabPageResults.ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((ISupportInitialize) this.resultsBindingSource).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
