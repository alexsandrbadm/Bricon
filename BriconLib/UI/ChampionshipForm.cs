// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.ChampionshipForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using BriconLib.Printing;
using BriconLib.Properties;
using MultiLang;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace BriconLib.UI
{
  public class ChampionshipForm : Form
  {
    private IContainer components;
    private Button buttonPrint;
    private Button buttonCancel;
    private Button buttonExport;
    private CheckedListBox checkedListBoxRaces;
    private GroupBox groupBoxRaces;
    private GroupBox groupBoxSettings;
    private GroupBox groupBoxQuery1;
    private Label labelQuery1Desc;
    private Label labelQuery1Name;
    private CheckBox checkBoxQuery1;
    private NumericUpDown numericUpDownPercentage;
    private Label labelPercentage;
    private GroupBox groupBoxQuery4;
    private TextBox textBox6;
    private TextBox textBox7;
    private Label label5;
    private Label label6;
    private CheckBox checkBoxQuery4;
    private GroupBox groupBoxQuery3;
    private TextBox textBox4;
    private TextBox textBox5;
    private Label label3;
    private Label label4;
    private CheckBox checkBoxQuery3;
    private GroupBox groupBoxQuery2;
    private TextBox textBox2;
    private TextBox textBox3;
    private Label label1;
    private Label label2;
    private CheckBox checkBoxQuery2;
    private TextBox textBoxQuery1Desc;
    private TextBox textBox1;
    private NumericUpDown numericUpDownQuery3;
    private Label label9;
    private NumericUpDown numericUpDown2;
    private Label label11;
    private ImageList imageList1;
    private NumericUpDown numericUpDown3;
    private Label label12;
    private BindingSource settingsBindingSource;
    private ChampignonShip champignonShip;
    private GroupBox groupBoxQuery6;
    private ComboBox comboBox1;
    private NumericUpDown numericUpDown4;
    private TextBox textBox10;
    private Label label16;
    private Label label13;
    private TextBox textBox11;
    private Label label14;
    private Label label15;
    private CheckBox checkBoxQuery6;
    private Label label17;
    private TextBox textBox12;
    private NumericUpDown numericUpDown6;
    private Label label19;
    private NumericUpDown numericUpDown7;
    private Label label20;
    private NumericUpDown numericUpDown8;
    private Label label21;
    private NumericUpDown numericUpDown9;
    private Label label22;
    private NumericUpDown numericUpDown10;
    private Label label23;
    private GroupBox groupBoxQuery6b;
    private NumericUpDown numericUpDown1;
    private Label label7;
    private TextBox textBox8;
    private TextBox textBox9;
    private Label label8;
    private Label label10;
    private CheckBox checkBoxQuery6b;

    public ChampionshipForm()
    {
      this.InitializeComponent();
      if (Settings.Default.Language == "hu")
      {
        this.groupBoxQuery1.Text += " : Helyezés/Tenyésztő";
        this.groupBoxQuery2.Text += " : Ászgalamb";
        this.groupBoxQuery3.Text += " : Szuper Ász";
        this.groupBoxQuery4.Text += " : Bajnokság";
        this.groupBoxQuery6.Text += " : Olimpia";
      }
      else
      {
        this.groupBoxQuery1.Text += ml.ml_string(735, " : Prices/Fancier");
        this.groupBoxQuery2.Text += ml.ml_string(736, " : Ace Pigeon");
        this.groupBoxQuery3.Text += ml.ml_string(737, " : Super Ace");
        this.groupBoxQuery4.Text += ml.ml_string(738, " : Championship");
        this.groupBoxQuery6.Text += ml.ml_string(740, " : Olympiade");
      }
      if (File.Exists("ChampignonsSettings.xml"))
      {
        int num = (int) this.champignonShip.ReadXml("ChampignonsSettings.xml");
      }
      else
        this.champignonShip.Settings.AddSettingsRow(33M, ml.ml_string(829, "Name"), ml.ml_string(11, "Name"), ml.ml_string(11, "Name"), ml.ml_string(11, "Name"), ml.ml_string(11, "Name"), ml.ml_string(11, "Name"), ml.ml_string(457, "Description"), ml.ml_string(457, "Description"), ml.ml_string(457, "Description"), ml.ml_string(457, "Description"), ml.ml_string(457, "Description"), ml.ml_string(457, "Description"), 10, 10, 10, 10, 10, true, true, true, true, true, true, "FCI-AB", ml.ml_string(741, "Title"), 20, 20, 20, 20, 20, 20, 20, "Overal points", false, "Overal Points");
      foreach (string file in Directory.GetFiles(CalculatorPage.CalculationsFolder, "*.xml"))
      {
        this.checkedListBoxRaces.Items.Add((object) Path.GetFileNameWithoutExtension(file));
        if (this.champignonShip.Flights.FindByName(Path.GetFileNameWithoutExtension(file)) != null)
          this.checkedListBoxRaces.SetItemChecked(this.checkedListBoxRaces.Items.Count - 1, true);
      }
    }

    private void buttonCancel_Click(object sender, EventArgs e) => this.Close();

    private void buttonExport_Click(object sender, EventArgs e)
    {
      this.Calculate();
      int num = (int) MessageBox.Show("TODO: This button places the data on the clipboard so you can use it in excel");
      this.Close();
    }

    private void buttonPrint_Click(object sender, EventArgs e)
    {
      this.Calculate();
      PrintHelper.PrintChampignonShip(this.champignonShip);
      this.Close();
    }

    private void EnableQuery(GroupBox groupBoxQuery, bool enable)
    {
      foreach (Control control in (ArrangedElementCollection) groupBoxQuery.Controls)
      {
        if (control.GetType() != typeof (CheckBox))
          control.Enabled = enable;
      }
    }

    private void checkBoxQuery1_CheckedChanged(object sender, EventArgs e) => this.EnableQuery(this.groupBoxQuery1, (sender as CheckBox).Checked);

    private void checkBoxQuery2_CheckedChanged(object sender, EventArgs e) => this.EnableQuery(this.groupBoxQuery2, (sender as CheckBox).Checked);

    private void checkBoxQuery3_CheckedChanged(object sender, EventArgs e) => this.EnableQuery(this.groupBoxQuery3, (sender as CheckBox).Checked);

    private void checkBoxQuery4_CheckedChanged(object sender, EventArgs e) => this.EnableQuery(this.groupBoxQuery4, (sender as CheckBox).Checked);

    private void checkBoxQuery6b_CheckedChanged(object sender, EventArgs e) => this.EnableQuery(this.groupBoxQuery6b, (sender as CheckBox).Checked);

    private void ChampionshipForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.champignonShip.Flights.Clear();
      foreach (string checkedItem in this.checkedListBoxRaces.CheckedItems)
        this.champignonShip.Flights.AddFlightsRow(checkedItem);
      this.champignonShip.WriteXml("ChampignonsSettings.xml");
    }

    private void Calculate()
    {
      try
      {
        CalculationDataSet[] calculationDataSetArray = new CalculationDataSet[this.checkedListBoxRaces.CheckedItems.Count];
        int index1 = 0;
        foreach (string checkedItem in this.checkedListBoxRaces.CheckedItems)
        {
          calculationDataSetArray[index1] = new CalculationDataSet();
          string str = CalculatorPage.CalculationsFolder + checkedItem + ".xml";
          if (!File.ReadAllText(str).StartsWith("<"))
          {
            BCEDatabase.DecryptFile(str, str + "tmp");
            int num = (int) calculationDataSetArray[index1].ReadXml(str + "tmp");
            File.Delete(str + "tmp");
          }
          else
          {
            int num1 = (int) calculationDataSetArray[index1].ReadXml(str);
          }
          ++index1;
        }
        this.champignonShip.Query1.Clear();
        this.champignonShip.Query2.Clear();
        this.champignonShip.Query3.Clear();
        this.champignonShip.Query4.Clear();
        this.champignonShip.Query5.Clear();
        this.champignonShip.Query6.Clear();
        this.champignonShip.Query6b.Clear();
        this.champignonShip.Settings[0].Print5 = false;
        Collection<string> collection = new Collection<string>();
        CalculationDataSet calculationDataSet = new CalculationDataSet();
        List<string> stringList = new List<string>();
        for (int index2 = 0; index2 < calculationDataSetArray.Length; ++index2)
        {
          foreach (ChampignonShip.Query4Row query4Row in this.champignonShip.Query4.Select(""))
            query4Row.CountPerRace = 0;
          stringList.Clear();
          if (calculationDataSetArray[index2].Information.Count == 0)
            throw new ApplicationException(ml.ml_string(1094, "No information record found in the readout, is the readoutfile in the correct format?"));
          int int32 = Convert.ToInt32((Decimal) calculationDataSetArray[index2].Information[0].TotalBasketted * this.champignonShip.Settings[0].Percentage / 100M);
          foreach (CalculationDataSet.ResultsRow resultsRow in calculationDataSetArray[index2].Results.Select("", "Speed desc"))
          {
            if (!collection.Contains(resultsRow.RingNumber))
              collection.Add(resultsRow.RingNumber);
            if (resultsRow.IsOveralPointsNull())
              resultsRow.OveralPoints = 0M;
            if (resultsRow.IsTimeZoneNull())
              resultsRow.TimeZone = 0M;
            calculationDataSet.Results.AddResultsRow(resultsRow.Number, resultsRow.FancierName, resultsRow.RingNumber, resultsRow.ClockingTime, resultsRow.Distance, resultsRow.DistanceString, resultsRow.Speed, resultsRow.CorrectedTime, resultsRow.Basketed, resultsRow.ClubID, resultsRow.Position1, resultsRow.Position2, resultsRow.Position3, resultsRow.Position4, resultsRow.Percentage, resultsRow.FCIAB, resultsRow.FCICD, resultsRow.FCIE, calculationDataSetArray[index2].Information[0].ReleaseTime, calculationDataSetArray[index2].Information[0].TotalBasketted, resultsRow.FCI, calculationDataSetArray[index2].Information[0].Flight, resultsRow.CorrectedTimeDigit, resultsRow.FlightTime, resultsRow.TeamNbr, resultsRow.Points100, resultsRow.NaamUnicode, resultsRow.GemeenteUnicode, resultsRow.License, resultsRow.OveralPoints, resultsRow.TimeZone);
            if (!this.champignonShip.Settings[0].IsPrint1Null() && this.champignonShip.Settings[0].Print1 && int32 > 0)
            {
              DataRow[] dataRowArray = this.champignonShip.Query1.Select("Name = '" + resultsRow.FancierName + "'");
              if (dataRowArray.Length == 0)
              {
                this.champignonShip.Query1.AddQuery1Row(resultsRow.FancierName, 1, Convert.ToDecimal(resultsRow.Percentage), resultsRow.Basketed);
                stringList.Add(resultsRow.FancierName);
              }
              else
              {
                ++(dataRowArray[0] as ChampignonShip.Query1Row).PriceCount;
                (dataRowArray[0] as ChampignonShip.Query1Row).TotalCoefficient += Convert.ToDecimal(resultsRow.Percentage);
                if (!stringList.Contains(resultsRow.FancierName))
                  (dataRowArray[0] as ChampignonShip.Query1Row).BaskettedCount += resultsRow.Basketed;
                stringList.Add(resultsRow.FancierName);
              }
            }
            if (!this.champignonShip.Settings[0].IsPrint2Null() && this.champignonShip.Settings[0].Print2 && int32 > 0)
            {
              DataRow[] dataRowArray = this.champignonShip.Query2.Select("Name = '" + resultsRow.FancierName + "' and RingNumber = '" + resultsRow.RingNumber + "'");
              if (dataRowArray.Length == 0)
              {
                this.champignonShip.Query2.AddQuery2Row(resultsRow.FancierName, resultsRow.RingNumber, Convert.ToDecimal(resultsRow.Percentage), 1);
              }
              else
              {
                ++(dataRowArray[0] as ChampignonShip.Query2Row).PriceCount;
                (dataRowArray[0] as ChampignonShip.Query2Row).TotalCoefficient += Convert.ToDecimal(resultsRow.Percentage);
              }
            }
            if (!this.champignonShip.Settings[0].IsPrint3Null() && this.champignonShip.Settings[0].Print3 && int32 > 0)
              this.champignonShip.Query3.AddQuery3Row(resultsRow.FancierName, resultsRow.RingNumber, 0, Convert.ToDecimal(resultsRow.Percentage));
            if (!this.champignonShip.Settings[0].IsPrint4Null() && this.champignonShip.Settings[0].Print4 && (int32 > 0 && resultsRow.Position1 <= this.champignonShip.Settings[0].Number4a) && (resultsRow.Position2 <= this.champignonShip.Settings[0].Number4a && resultsRow.Position3 <= this.champignonShip.Settings[0].Number4a && resultsRow.Position4 <= this.champignonShip.Settings[0].Number4a))
            {
              DataRow[] dataRowArray = this.champignonShip.Query4.Select("Name = '" + resultsRow.FancierName + "'");
              if (dataRowArray.Length == 0)
                this.champignonShip.Query4.AddQuery4Row(resultsRow.FancierName, 1, Convert.ToDecimal(resultsRow.Percentage), 1);
              else if ((dataRowArray[0] as ChampignonShip.Query4Row).CountPerRace < this.champignonShip.Settings[0].Number4b)
              {
                ++(dataRowArray[0] as ChampignonShip.Query4Row).CountPerRace;
                ++(dataRowArray[0] as ChampignonShip.Query4Row).PointCount;
                (dataRowArray[0] as ChampignonShip.Query4Row).TotalCoefficient += Convert.ToDecimal(resultsRow.Percentage);
              }
            }
            if (!this.champignonShip.Settings[0].IsPrint6bNull() && this.champignonShip.Settings[0].Print6b && int32 > 0)
            {
              DataRow[] dataRowArray = this.champignonShip.Query6b.Select("Name = '" + resultsRow.FancierName + "'");
              if (dataRowArray.Length == 0)
              {
                this.champignonShip.Query6b.AddQuery6bRow(resultsRow.FancierName, 1, resultsRow.OveralPoints, resultsRow.Basketed);
                stringList.Add(resultsRow.FancierName);
              }
              else
              {
                ++(dataRowArray[0] as ChampignonShip.Query6bRow).PriceCount;
                (dataRowArray[0] as ChampignonShip.Query6bRow).TotalCoefficient += resultsRow.OveralPoints;
                if (!stringList.Contains(resultsRow.FancierName))
                  (dataRowArray[0] as ChampignonShip.Query6bRow).BaskettedCount += resultsRow.Basketed;
                stringList.Add(resultsRow.FancierName);
              }
            }
            --int32;
          }
        }
        if (!this.champignonShip.Settings[0].IsPrint3Null() && this.champignonShip.Settings[0].Print3)
        {
          foreach (ChampignonShip.Query3Row query3Row1 in this.champignonShip.Query3.Select("", "TotalCoefficient"))
          {
            if (query3Row1.RowState != DataRowState.Detached)
            {
              int PriceCount = 0;
              Decimal TotalCoefficient = 0M;
              string name = query3Row1.Name;
              string ringNumber = query3Row1.RingNumber;
              ChampignonShip.Query3DataTable query3 = this.champignonShip.Query3;
              string filterExpression = "Name = '" + query3Row1.Name + "' and RingNumber = '" + query3Row1.RingNumber + "' and PriceCount = 0";
              foreach (ChampignonShip.Query3Row query3Row2 in query3.Select(filterExpression, "TotalCoefficient"))
              {
                if (PriceCount < this.champignonShip.Settings[0].Number3)
                {
                  ++PriceCount;
                  TotalCoefficient += query3Row2.TotalCoefficient;
                }
                query3Row2.Delete();
              }
              this.champignonShip.Query3.AddQuery3Row(name, ringNumber, PriceCount, TotalCoefficient);
            }
          }
        }
        int num2 = 1;
        foreach (string RingNumber in collection)
        {
          string sort = "FCIAB desc";
          if (this.champignonShip.Settings[0].Categorie6 == "FCI-CD")
            sort = "FCICD desc";
          if (this.champignonShip.Settings[0].Categorie6 == "FCI-E")
            sort = "FCIE desc";
          int num1 = 0;
          Decimal num3 = 0M;
          Decimal num4 = 0M;
          foreach (CalculationDataSet.ResultsRow resultsRow in calculationDataSet.Results.Select("Ringnumber = '" + RingNumber + "'", sort))
          {
            Decimal FCI = 0M;
            if (this.champignonShip.Settings[0].Categorie6 == "FCI-AB" || this.champignonShip.Settings[0].Categorie6 == "")
            {
              if (resultsRow.FCIAB > 0.0)
              {
                num3 += Convert.ToDecimal(resultsRow.FCIAB);
                FCI = Convert.ToDecimal(resultsRow.FCIAB);
              }
              else
                continue;
            }
            else if (this.champignonShip.Settings[0].Categorie6 == "FCI-CD")
            {
              num3 += Convert.ToDecimal(resultsRow.FCICD);
              FCI = Convert.ToDecimal(resultsRow.FCICD);
            }
            else if (this.champignonShip.Settings[0].Categorie6 == "FCI-E")
            {
              num3 += Convert.ToDecimal(resultsRow.FCIE);
              FCI = Convert.ToDecimal(resultsRow.FCIE);
            }
            num4 += resultsRow.Distance;
            this.champignonShip.Query6.AddQuery6Row(0, resultsRow.FancierName, RingNumber, 0, 0M, 0M, resultsRow.Flight, resultsRow.CorrectedTime, resultsRow.Distance, resultsRow.Number, resultsRow.ReleaseTime, resultsRow.TotalBasketed, FCI);
            if (++num1 >= this.champignonShip.Settings[0].Number6)
              break;
          }
          if (!this.champignonShip.Settings[0].IsPrint6Null() && this.champignonShip.Settings[0].Print6)
          {
            foreach (ChampignonShip.Query6Row query6Row in this.champignonShip.Query6.Select("RingNumber = '" + RingNumber + "'"))
            {
              query6Row.Nr = num2;
              query6Row.FlightCount = num1;
              query6Row.TotalCoefficient = num3;
              query6Row.TotalDistance = num4;
            }
            if (num1 < this.champignonShip.Settings[0].Number6)
            {
              foreach (DataRow dataRow in this.champignonShip.Query6.Select("RingNumber = '" + RingNumber + "'"))
                dataRow.Delete();
            }
            else
              ++num2;
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void checkBoxQuery6_CheckedChanged(object sender, EventArgs e) => this.EnableQuery(this.groupBoxQuery6, (sender as CheckBox).Checked);

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ChampionshipForm));
      this.buttonPrint = new Button();
      this.imageList1 = new ImageList(this.components);
      this.buttonCancel = new Button();
      this.buttonExport = new Button();
      this.checkedListBoxRaces = new CheckedListBox();
      this.groupBoxRaces = new GroupBox();
      this.groupBoxSettings = new GroupBox();
      this.groupBoxQuery6b = new GroupBox();
      this.numericUpDown1 = new NumericUpDown();
      this.settingsBindingSource = new BindingSource(this.components);
      this.champignonShip = new ChampignonShip();
      this.label7 = new Label();
      this.textBox8 = new TextBox();
      this.textBox9 = new TextBox();
      this.label8 = new Label();
      this.label10 = new Label();
      this.checkBoxQuery6b = new CheckBox();
      this.groupBoxQuery6 = new GroupBox();
      this.numericUpDown6 = new NumericUpDown();
      this.label19 = new Label();
      this.comboBox1 = new ComboBox();
      this.numericUpDown4 = new NumericUpDown();
      this.textBox10 = new TextBox();
      this.label16 = new Label();
      this.label13 = new Label();
      this.textBox11 = new TextBox();
      this.label14 = new Label();
      this.label15 = new Label();
      this.checkBoxQuery6 = new CheckBox();
      this.textBox12 = new TextBox();
      this.groupBoxQuery4 = new GroupBox();
      this.numericUpDown7 = new NumericUpDown();
      this.label20 = new Label();
      this.numericUpDown3 = new NumericUpDown();
      this.numericUpDown2 = new NumericUpDown();
      this.label12 = new Label();
      this.textBox6 = new TextBox();
      this.label11 = new Label();
      this.textBox7 = new TextBox();
      this.label5 = new Label();
      this.label6 = new Label();
      this.checkBoxQuery4 = new CheckBox();
      this.groupBoxQuery3 = new GroupBox();
      this.numericUpDown8 = new NumericUpDown();
      this.label21 = new Label();
      this.numericUpDownQuery3 = new NumericUpDown();
      this.label9 = new Label();
      this.textBox4 = new TextBox();
      this.textBox5 = new TextBox();
      this.label3 = new Label();
      this.label4 = new Label();
      this.checkBoxQuery3 = new CheckBox();
      this.groupBoxQuery2 = new GroupBox();
      this.numericUpDown9 = new NumericUpDown();
      this.label22 = new Label();
      this.textBox2 = new TextBox();
      this.textBox3 = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.checkBoxQuery2 = new CheckBox();
      this.groupBoxQuery1 = new GroupBox();
      this.numericUpDown10 = new NumericUpDown();
      this.label23 = new Label();
      this.textBoxQuery1Desc = new TextBox();
      this.textBox1 = new TextBox();
      this.labelQuery1Desc = new Label();
      this.labelQuery1Name = new Label();
      this.checkBoxQuery1 = new CheckBox();
      this.numericUpDownPercentage = new NumericUpDown();
      this.label17 = new Label();
      this.labelPercentage = new Label();
      this.groupBoxRaces.SuspendLayout();
      this.groupBoxSettings.SuspendLayout();
      this.groupBoxQuery6b.SuspendLayout();
      this.numericUpDown1.BeginInit();
      ((ISupportInitialize) this.settingsBindingSource).BeginInit();
      this.champignonShip.BeginInit();
      this.groupBoxQuery6.SuspendLayout();
      this.numericUpDown6.BeginInit();
      this.numericUpDown4.BeginInit();
      this.groupBoxQuery4.SuspendLayout();
      this.numericUpDown7.BeginInit();
      this.numericUpDown3.BeginInit();
      this.numericUpDown2.BeginInit();
      this.groupBoxQuery3.SuspendLayout();
      this.numericUpDown8.BeginInit();
      this.numericUpDownQuery3.BeginInit();
      this.groupBoxQuery2.SuspendLayout();
      this.numericUpDown9.BeginInit();
      this.groupBoxQuery1.SuspendLayout();
      this.numericUpDown10.BeginInit();
      this.numericUpDownPercentage.BeginInit();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.buttonPrint, "buttonPrint");
      this.buttonPrint.ImageList = this.imageList1;
      this.buttonPrint.Name = "buttonPrint";
      this.buttonPrint.UseVisualStyleBackColor = true;
      this.buttonPrint.Click += new EventHandler(this.buttonPrint_Click);
      this.imageList1.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageList1.ImageStream");
      this.imageList1.TransparentColor = Color.Fuchsia;
      this.imageList1.Images.SetKeyName(0, "Print.bmp");
      this.imageList1.Images.SetKeyName(1, "Excel.bmp");
      componentResourceManager.ApplyResources((object) this.buttonCancel, "buttonCancel");
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      componentResourceManager.ApplyResources((object) this.buttonExport, "buttonExport");
      this.buttonExport.ImageList = this.imageList1;
      this.buttonExport.Name = "buttonExport";
      this.buttonExport.UseVisualStyleBackColor = true;
      this.buttonExport.Click += new EventHandler(this.buttonExport_Click);
      this.checkedListBoxRaces.CheckOnClick = true;
      componentResourceManager.ApplyResources((object) this.checkedListBoxRaces, "checkedListBoxRaces");
      this.checkedListBoxRaces.FormattingEnabled = true;
      this.checkedListBoxRaces.Name = "checkedListBoxRaces";
      componentResourceManager.ApplyResources((object) this.groupBoxRaces, "groupBoxRaces");
      this.groupBoxRaces.Controls.Add((Control) this.checkedListBoxRaces);
      this.groupBoxRaces.Name = "groupBoxRaces";
      this.groupBoxRaces.TabStop = false;
      componentResourceManager.ApplyResources((object) this.groupBoxSettings, "groupBoxSettings");
      this.groupBoxSettings.Controls.Add((Control) this.groupBoxQuery6b);
      this.groupBoxSettings.Controls.Add((Control) this.groupBoxQuery6);
      this.groupBoxSettings.Controls.Add((Control) this.textBox12);
      this.groupBoxSettings.Controls.Add((Control) this.groupBoxQuery4);
      this.groupBoxSettings.Controls.Add((Control) this.groupBoxQuery3);
      this.groupBoxSettings.Controls.Add((Control) this.groupBoxQuery2);
      this.groupBoxSettings.Controls.Add((Control) this.groupBoxQuery1);
      this.groupBoxSettings.Controls.Add((Control) this.numericUpDownPercentage);
      this.groupBoxSettings.Controls.Add((Control) this.label17);
      this.groupBoxSettings.Controls.Add((Control) this.labelPercentage);
      this.groupBoxSettings.Name = "groupBoxSettings";
      this.groupBoxSettings.TabStop = false;
      this.groupBoxQuery6b.Controls.Add((Control) this.numericUpDown1);
      this.groupBoxQuery6b.Controls.Add((Control) this.label7);
      this.groupBoxQuery6b.Controls.Add((Control) this.textBox8);
      this.groupBoxQuery6b.Controls.Add((Control) this.textBox9);
      this.groupBoxQuery6b.Controls.Add((Control) this.label8);
      this.groupBoxQuery6b.Controls.Add((Control) this.label10);
      this.groupBoxQuery6b.Controls.Add((Control) this.checkBoxQuery6b);
      componentResourceManager.ApplyResources((object) this.groupBoxQuery6b, "groupBoxQuery6b");
      this.groupBoxQuery6b.Name = "groupBoxQuery6b";
      this.groupBoxQuery6b.TabStop = false;
      this.numericUpDown1.DataBindings.Add(new Binding("Value", (object) this.settingsBindingSource, "MaxRowCount6b", true));
      componentResourceManager.ApplyResources((object) this.numericUpDown1, "numericUpDown1");
      this.numericUpDown1.Maximum = new Decimal(new int[4]
      {
        10000,
        0,
        0,
        0
      });
      this.numericUpDown1.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Value = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.settingsBindingSource.DataMember = "Settings";
      this.settingsBindingSource.DataSource = (object) this.champignonShip;
      this.champignonShip.DataSetName = "ChampignonShip";
      this.champignonShip.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      componentResourceManager.ApplyResources((object) this.label7, "label7");
      this.label7.Name = "label7";
      componentResourceManager.ApplyResources((object) this.textBox8, "textBox8");
      this.textBox8.DataBindings.Add(new Binding("Text", (object) this.settingsBindingSource, "Description6b", true));
      this.textBox8.Name = "textBox8";
      componentResourceManager.ApplyResources((object) this.textBox9, "textBox9");
      this.textBox9.DataBindings.Add(new Binding("Text", (object) this.settingsBindingSource, "Name6b", true));
      this.textBox9.Name = "textBox9";
      componentResourceManager.ApplyResources((object) this.label8, "label8");
      this.label8.Name = "label8";
      componentResourceManager.ApplyResources((object) this.label10, "label10");
      this.label10.Name = "label10";
      this.checkBoxQuery6b.BackColor = Color.Transparent;
      this.checkBoxQuery6b.Checked = true;
      this.checkBoxQuery6b.CheckState = CheckState.Checked;
      this.checkBoxQuery6b.DataBindings.Add(new Binding("Checked", (object) this.settingsBindingSource, "Print6b", true));
      componentResourceManager.ApplyResources((object) this.checkBoxQuery6b, "checkBoxQuery6b");
      this.checkBoxQuery6b.Name = "checkBoxQuery6b";
      this.checkBoxQuery6b.UseVisualStyleBackColor = false;
      this.checkBoxQuery6b.CheckedChanged += new EventHandler(this.checkBoxQuery6b_CheckedChanged);
      this.groupBoxQuery6.Controls.Add((Control) this.numericUpDown6);
      this.groupBoxQuery6.Controls.Add((Control) this.label19);
      this.groupBoxQuery6.Controls.Add((Control) this.comboBox1);
      this.groupBoxQuery6.Controls.Add((Control) this.numericUpDown4);
      this.groupBoxQuery6.Controls.Add((Control) this.textBox10);
      this.groupBoxQuery6.Controls.Add((Control) this.label16);
      this.groupBoxQuery6.Controls.Add((Control) this.label13);
      this.groupBoxQuery6.Controls.Add((Control) this.textBox11);
      this.groupBoxQuery6.Controls.Add((Control) this.label14);
      this.groupBoxQuery6.Controls.Add((Control) this.label15);
      this.groupBoxQuery6.Controls.Add((Control) this.checkBoxQuery6);
      componentResourceManager.ApplyResources((object) this.groupBoxQuery6, "groupBoxQuery6");
      this.groupBoxQuery6.Name = "groupBoxQuery6";
      this.groupBoxQuery6.TabStop = false;
      this.numericUpDown6.DataBindings.Add(new Binding("Value", (object) this.settingsBindingSource, "MaxRowCount6", true));
      componentResourceManager.ApplyResources((object) this.numericUpDown6, "numericUpDown6");
      this.numericUpDown6.Maximum = new Decimal(new int[4]
      {
        10000,
        0,
        0,
        0
      });
      this.numericUpDown6.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown6.Name = "numericUpDown6";
      this.numericUpDown6.Value = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      componentResourceManager.ApplyResources((object) this.label19, "label19");
      this.label19.Name = "label19";
      this.comboBox1.DataBindings.Add(new Binding("SelectedItem", (object) this.settingsBindingSource, "Categorie6", true));
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[3]
      {
        (object) componentResourceManager.GetString("comboBox1.Items"),
        (object) componentResourceManager.GetString("comboBox1.Items1"),
        (object) componentResourceManager.GetString("comboBox1.Items2")
      });
      componentResourceManager.ApplyResources((object) this.comboBox1, "comboBox1");
      this.comboBox1.Name = "comboBox1";
      this.numericUpDown4.DataBindings.Add(new Binding("Value", (object) this.settingsBindingSource, "Number6", true));
      componentResourceManager.ApplyResources((object) this.numericUpDown4, "numericUpDown4");
      this.numericUpDown4.Maximum = new Decimal(new int[4]
      {
        1000,
        0,
        0,
        0
      });
      this.numericUpDown4.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown4.Name = "numericUpDown4";
      this.numericUpDown4.Value = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      componentResourceManager.ApplyResources((object) this.textBox10, "textBox10");
      this.textBox10.DataBindings.Add(new Binding("Text", (object) this.settingsBindingSource, "Description6", true));
      this.textBox10.Name = "textBox10";
      componentResourceManager.ApplyResources((object) this.label16, "label16");
      this.label16.Name = "label16";
      componentResourceManager.ApplyResources((object) this.label13, "label13");
      this.label13.Name = "label13";
      componentResourceManager.ApplyResources((object) this.textBox11, "textBox11");
      this.textBox11.DataBindings.Add(new Binding("Text", (object) this.settingsBindingSource, "Name6", true));
      this.textBox11.Name = "textBox11";
      componentResourceManager.ApplyResources((object) this.label14, "label14");
      this.label14.Name = "label14";
      componentResourceManager.ApplyResources((object) this.label15, "label15");
      this.label15.Name = "label15";
      this.checkBoxQuery6.BackColor = Color.Transparent;
      this.checkBoxQuery6.Checked = true;
      this.checkBoxQuery6.CheckState = CheckState.Checked;
      this.checkBoxQuery6.DataBindings.Add(new Binding("Checked", (object) this.settingsBindingSource, "Print6", true));
      componentResourceManager.ApplyResources((object) this.checkBoxQuery6, "checkBoxQuery6");
      this.checkBoxQuery6.Name = "checkBoxQuery6";
      this.checkBoxQuery6.UseVisualStyleBackColor = false;
      this.checkBoxQuery6.CheckedChanged += new EventHandler(this.checkBoxQuery6_CheckedChanged);
      componentResourceManager.ApplyResources((object) this.textBox12, "textBox12");
      this.textBox12.DataBindings.Add(new Binding("Text", (object) this.settingsBindingSource, "MainTitle", true));
      this.textBox12.Name = "textBox12";
      this.groupBoxQuery4.Controls.Add((Control) this.numericUpDown7);
      this.groupBoxQuery4.Controls.Add((Control) this.label20);
      this.groupBoxQuery4.Controls.Add((Control) this.numericUpDown3);
      this.groupBoxQuery4.Controls.Add((Control) this.numericUpDown2);
      this.groupBoxQuery4.Controls.Add((Control) this.label12);
      this.groupBoxQuery4.Controls.Add((Control) this.textBox6);
      this.groupBoxQuery4.Controls.Add((Control) this.label11);
      this.groupBoxQuery4.Controls.Add((Control) this.textBox7);
      this.groupBoxQuery4.Controls.Add((Control) this.label5);
      this.groupBoxQuery4.Controls.Add((Control) this.label6);
      this.groupBoxQuery4.Controls.Add((Control) this.checkBoxQuery4);
      componentResourceManager.ApplyResources((object) this.groupBoxQuery4, "groupBoxQuery4");
      this.groupBoxQuery4.Name = "groupBoxQuery4";
      this.groupBoxQuery4.TabStop = false;
      this.numericUpDown7.DataBindings.Add(new Binding("Value", (object) this.settingsBindingSource, "MaxRowCount4", true));
      componentResourceManager.ApplyResources((object) this.numericUpDown7, "numericUpDown7");
      this.numericUpDown7.Maximum = new Decimal(new int[4]
      {
        10000,
        0,
        0,
        0
      });
      this.numericUpDown7.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown7.Name = "numericUpDown7";
      this.numericUpDown7.Value = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      componentResourceManager.ApplyResources((object) this.label20, "label20");
      this.label20.Name = "label20";
      this.numericUpDown3.DataBindings.Add(new Binding("Value", (object) this.settingsBindingSource, "Number4b", true));
      componentResourceManager.ApplyResources((object) this.numericUpDown3, "numericUpDown3");
      this.numericUpDown3.Maximum = new Decimal(new int[4]
      {
        1000,
        0,
        0,
        0
      });
      this.numericUpDown3.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown3.Name = "numericUpDown3";
      this.numericUpDown3.Value = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown2.DataBindings.Add(new Binding("Value", (object) this.settingsBindingSource, "Number4a", true));
      componentResourceManager.ApplyResources((object) this.numericUpDown2, "numericUpDown2");
      this.numericUpDown2.Maximum = new Decimal(new int[4]
      {
        1000,
        0,
        0,
        0
      });
      this.numericUpDown2.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown2.Name = "numericUpDown2";
      this.numericUpDown2.Value = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      componentResourceManager.ApplyResources((object) this.label12, "label12");
      this.label12.Name = "label12";
      componentResourceManager.ApplyResources((object) this.textBox6, "textBox6");
      this.textBox6.DataBindings.Add(new Binding("Text", (object) this.settingsBindingSource, "Description4", true));
      this.textBox6.Name = "textBox6";
      componentResourceManager.ApplyResources((object) this.label11, "label11");
      this.label11.Name = "label11";
      componentResourceManager.ApplyResources((object) this.textBox7, "textBox7");
      this.textBox7.DataBindings.Add(new Binding("Text", (object) this.settingsBindingSource, "Name4", true));
      this.textBox7.Name = "textBox7";
      componentResourceManager.ApplyResources((object) this.label5, "label5");
      this.label5.Name = "label5";
      componentResourceManager.ApplyResources((object) this.label6, "label6");
      this.label6.Name = "label6";
      this.checkBoxQuery4.BackColor = Color.Transparent;
      this.checkBoxQuery4.Checked = true;
      this.checkBoxQuery4.CheckState = CheckState.Checked;
      this.checkBoxQuery4.DataBindings.Add(new Binding("Checked", (object) this.settingsBindingSource, "Print4", true));
      componentResourceManager.ApplyResources((object) this.checkBoxQuery4, "checkBoxQuery4");
      this.checkBoxQuery4.Name = "checkBoxQuery4";
      this.checkBoxQuery4.UseVisualStyleBackColor = false;
      this.checkBoxQuery4.CheckedChanged += new EventHandler(this.checkBoxQuery4_CheckedChanged);
      this.groupBoxQuery3.Controls.Add((Control) this.numericUpDown8);
      this.groupBoxQuery3.Controls.Add((Control) this.label21);
      this.groupBoxQuery3.Controls.Add((Control) this.numericUpDownQuery3);
      this.groupBoxQuery3.Controls.Add((Control) this.label9);
      this.groupBoxQuery3.Controls.Add((Control) this.textBox4);
      this.groupBoxQuery3.Controls.Add((Control) this.textBox5);
      this.groupBoxQuery3.Controls.Add((Control) this.label3);
      this.groupBoxQuery3.Controls.Add((Control) this.label4);
      this.groupBoxQuery3.Controls.Add((Control) this.checkBoxQuery3);
      componentResourceManager.ApplyResources((object) this.groupBoxQuery3, "groupBoxQuery3");
      this.groupBoxQuery3.Name = "groupBoxQuery3";
      this.groupBoxQuery3.TabStop = false;
      this.numericUpDown8.DataBindings.Add(new Binding("Value", (object) this.settingsBindingSource, "MaxRowCount3", true));
      componentResourceManager.ApplyResources((object) this.numericUpDown8, "numericUpDown8");
      this.numericUpDown8.Maximum = new Decimal(new int[4]
      {
        10000,
        0,
        0,
        0
      });
      this.numericUpDown8.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown8.Name = "numericUpDown8";
      this.numericUpDown8.Value = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      componentResourceManager.ApplyResources((object) this.label21, "label21");
      this.label21.Name = "label21";
      this.numericUpDownQuery3.DataBindings.Add(new Binding("Value", (object) this.settingsBindingSource, "Number3", true));
      componentResourceManager.ApplyResources((object) this.numericUpDownQuery3, "numericUpDownQuery3");
      this.numericUpDownQuery3.Maximum = new Decimal(new int[4]
      {
        1000,
        0,
        0,
        0
      });
      this.numericUpDownQuery3.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDownQuery3.Name = "numericUpDownQuery3";
      this.numericUpDownQuery3.Value = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      componentResourceManager.ApplyResources((object) this.label9, "label9");
      this.label9.Name = "label9";
      componentResourceManager.ApplyResources((object) this.textBox4, "textBox4");
      this.textBox4.DataBindings.Add(new Binding("Text", (object) this.settingsBindingSource, "Description3", true));
      this.textBox4.Name = "textBox4";
      componentResourceManager.ApplyResources((object) this.textBox5, "textBox5");
      this.textBox5.DataBindings.Add(new Binding("Text", (object) this.settingsBindingSource, "Name3", true));
      this.textBox5.Name = "textBox5";
      componentResourceManager.ApplyResources((object) this.label3, "label3");
      this.label3.Name = "label3";
      componentResourceManager.ApplyResources((object) this.label4, "label4");
      this.label4.Name = "label4";
      this.checkBoxQuery3.BackColor = Color.Transparent;
      this.checkBoxQuery3.Checked = true;
      this.checkBoxQuery3.CheckState = CheckState.Checked;
      this.checkBoxQuery3.DataBindings.Add(new Binding("Checked", (object) this.settingsBindingSource, "Print3", true));
      componentResourceManager.ApplyResources((object) this.checkBoxQuery3, "checkBoxQuery3");
      this.checkBoxQuery3.Name = "checkBoxQuery3";
      this.checkBoxQuery3.UseVisualStyleBackColor = false;
      this.checkBoxQuery3.CheckedChanged += new EventHandler(this.checkBoxQuery3_CheckedChanged);
      this.groupBoxQuery2.Controls.Add((Control) this.numericUpDown9);
      this.groupBoxQuery2.Controls.Add((Control) this.label22);
      this.groupBoxQuery2.Controls.Add((Control) this.textBox2);
      this.groupBoxQuery2.Controls.Add((Control) this.textBox3);
      this.groupBoxQuery2.Controls.Add((Control) this.label1);
      this.groupBoxQuery2.Controls.Add((Control) this.label2);
      this.groupBoxQuery2.Controls.Add((Control) this.checkBoxQuery2);
      componentResourceManager.ApplyResources((object) this.groupBoxQuery2, "groupBoxQuery2");
      this.groupBoxQuery2.Name = "groupBoxQuery2";
      this.groupBoxQuery2.TabStop = false;
      this.numericUpDown9.DataBindings.Add(new Binding("Value", (object) this.settingsBindingSource, "MaxRowCount2", true));
      componentResourceManager.ApplyResources((object) this.numericUpDown9, "numericUpDown9");
      this.numericUpDown9.Maximum = new Decimal(new int[4]
      {
        10000,
        0,
        0,
        0
      });
      this.numericUpDown9.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown9.Name = "numericUpDown9";
      this.numericUpDown9.Value = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      componentResourceManager.ApplyResources((object) this.label22, "label22");
      this.label22.Name = "label22";
      componentResourceManager.ApplyResources((object) this.textBox2, "textBox2");
      this.textBox2.DataBindings.Add(new Binding("Text", (object) this.settingsBindingSource, "Description2", true));
      this.textBox2.Name = "textBox2";
      componentResourceManager.ApplyResources((object) this.textBox3, "textBox3");
      this.textBox3.DataBindings.Add(new Binding("Text", (object) this.settingsBindingSource, "Name2", true));
      this.textBox3.Name = "textBox3";
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      componentResourceManager.ApplyResources((object) this.label2, "label2");
      this.label2.Name = "label2";
      this.checkBoxQuery2.BackColor = Color.Transparent;
      this.checkBoxQuery2.Checked = true;
      this.checkBoxQuery2.CheckState = CheckState.Checked;
      this.checkBoxQuery2.DataBindings.Add(new Binding("Checked", (object) this.settingsBindingSource, "Print2", true));
      componentResourceManager.ApplyResources((object) this.checkBoxQuery2, "checkBoxQuery2");
      this.checkBoxQuery2.Name = "checkBoxQuery2";
      this.checkBoxQuery2.UseVisualStyleBackColor = false;
      this.checkBoxQuery2.CheckedChanged += new EventHandler(this.checkBoxQuery2_CheckedChanged);
      this.groupBoxQuery1.Controls.Add((Control) this.numericUpDown10);
      this.groupBoxQuery1.Controls.Add((Control) this.label23);
      this.groupBoxQuery1.Controls.Add((Control) this.textBoxQuery1Desc);
      this.groupBoxQuery1.Controls.Add((Control) this.textBox1);
      this.groupBoxQuery1.Controls.Add((Control) this.labelQuery1Desc);
      this.groupBoxQuery1.Controls.Add((Control) this.labelQuery1Name);
      this.groupBoxQuery1.Controls.Add((Control) this.checkBoxQuery1);
      componentResourceManager.ApplyResources((object) this.groupBoxQuery1, "groupBoxQuery1");
      this.groupBoxQuery1.Name = "groupBoxQuery1";
      this.groupBoxQuery1.TabStop = false;
      this.numericUpDown10.DataBindings.Add(new Binding("Value", (object) this.settingsBindingSource, "MaxRowCount1", true));
      componentResourceManager.ApplyResources((object) this.numericUpDown10, "numericUpDown10");
      this.numericUpDown10.Maximum = new Decimal(new int[4]
      {
        10000,
        0,
        0,
        0
      });
      this.numericUpDown10.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown10.Name = "numericUpDown10";
      this.numericUpDown10.Value = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      componentResourceManager.ApplyResources((object) this.label23, "label23");
      this.label23.Name = "label23";
      componentResourceManager.ApplyResources((object) this.textBoxQuery1Desc, "textBoxQuery1Desc");
      this.textBoxQuery1Desc.DataBindings.Add(new Binding("Text", (object) this.settingsBindingSource, "Description1", true));
      this.textBoxQuery1Desc.Name = "textBoxQuery1Desc";
      componentResourceManager.ApplyResources((object) this.textBox1, "textBox1");
      this.textBox1.DataBindings.Add(new Binding("Text", (object) this.settingsBindingSource, "Name1", true));
      this.textBox1.Name = "textBox1";
      componentResourceManager.ApplyResources((object) this.labelQuery1Desc, "labelQuery1Desc");
      this.labelQuery1Desc.Name = "labelQuery1Desc";
      componentResourceManager.ApplyResources((object) this.labelQuery1Name, "labelQuery1Name");
      this.labelQuery1Name.Name = "labelQuery1Name";
      this.checkBoxQuery1.BackColor = Color.Transparent;
      this.checkBoxQuery1.Checked = true;
      this.checkBoxQuery1.CheckState = CheckState.Checked;
      this.checkBoxQuery1.DataBindings.Add(new Binding("Checked", (object) this.settingsBindingSource, "Print1", true));
      componentResourceManager.ApplyResources((object) this.checkBoxQuery1, "checkBoxQuery1");
      this.checkBoxQuery1.Name = "checkBoxQuery1";
      this.checkBoxQuery1.UseVisualStyleBackColor = false;
      this.checkBoxQuery1.CheckedChanged += new EventHandler(this.checkBoxQuery1_CheckedChanged);
      this.numericUpDownPercentage.DataBindings.Add(new Binding("Value", (object) this.settingsBindingSource, "Percentage", true));
      componentResourceManager.ApplyResources((object) this.numericUpDownPercentage, "numericUpDownPercentage");
      this.numericUpDownPercentage.Name = "numericUpDownPercentage";
      this.numericUpDownPercentage.Value = new Decimal(new int[4]
      {
        100,
        0,
        0,
        0
      });
      componentResourceManager.ApplyResources((object) this.label17, "label17");
      this.label17.Name = "label17";
      componentResourceManager.ApplyResources((object) this.labelPercentage, "labelPercentage");
      this.labelPercentage.Name = "labelPercentage";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.groupBoxSettings);
      this.Controls.Add((Control) this.groupBoxRaces);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonExport);
      this.Controls.Add((Control) this.buttonPrint);
      this.Name = nameof (ChampionshipForm);
      this.FormClosing += new FormClosingEventHandler(this.ChampionshipForm_FormClosing);
      this.groupBoxRaces.ResumeLayout(false);
      this.groupBoxSettings.ResumeLayout(false);
      this.groupBoxSettings.PerformLayout();
      this.groupBoxQuery6b.ResumeLayout(false);
      this.groupBoxQuery6b.PerformLayout();
      this.numericUpDown1.EndInit();
      ((ISupportInitialize) this.settingsBindingSource).EndInit();
      this.champignonShip.EndInit();
      this.groupBoxQuery6.ResumeLayout(false);
      this.groupBoxQuery6.PerformLayout();
      this.numericUpDown6.EndInit();
      this.numericUpDown4.EndInit();
      this.groupBoxQuery4.ResumeLayout(false);
      this.groupBoxQuery4.PerformLayout();
      this.numericUpDown7.EndInit();
      this.numericUpDown3.EndInit();
      this.numericUpDown2.EndInit();
      this.groupBoxQuery3.ResumeLayout(false);
      this.groupBoxQuery3.PerformLayout();
      this.numericUpDown8.EndInit();
      this.numericUpDownQuery3.EndInit();
      this.groupBoxQuery2.ResumeLayout(false);
      this.groupBoxQuery2.PerformLayout();
      this.numericUpDown9.EndInit();
      this.groupBoxQuery1.ResumeLayout(false);
      this.groupBoxQuery1.PerformLayout();
      this.numericUpDown10.EndInit();
      this.numericUpDownPercentage.EndInit();
      this.ResumeLayout(false);
    }
  }
}
