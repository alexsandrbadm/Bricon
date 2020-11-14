// Decompiled with JetBrains decompiler
// Type: BriconLib.PrintManager.ViewDataForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using BriconLib.Other;
using BriconLib.UI;
using MultiLang;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace BriconLib.PrintManager
{
  public class ViewDataForm : Form
  {
    private IContainer components;
    private DataGridView dataGridView1;
    private BindingSource readOutDataSetBindingSource;
    private ReadOutDataSet readOutDataSet;
    private Button buttonClose;
    private Label label1;
    private DataGridView dataGridView2;
    private Label label2;
    private DataGridView dataGridView3;
    private Label label3;
    private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn FancierID;
    private DataGridViewTextBoxColumn elBandDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn fedBandDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn clubIDDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn flightIDDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn position1DataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn position2DataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn position3DataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn position4DataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn evaluationDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn2;
    private DataGridViewTextBoxColumn fancierIDDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn clubIDDataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn flightIDDataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn basketingMasterTimeDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn basketingInternalTimeDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn basketingDiffDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn readOutMasterTimeDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn readOutInternalTimeDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn readOutDiffDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn diffDataGridViewTextBoxColumn;
    private Button buttonSaveAs;
    private SaveFileDialog saveFileDialog1;
    private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn licenseDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn zipCodeDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn coordXDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn coordYDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn Serial;
    private DataGridViewTextBoxColumn DistanceString;
    private DataGridViewTextBoxColumn Distance;
    private DataGridViewTextBoxColumn DistanceUnit;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
    private Button buttonEdit;

    public ViewDataForm(string fileName)
    {
      this.InitializeComponent();
      if (Utils.IsCountry("IQ") || Utils.IsCountry("RN"))
        this.SetEditMode(false);
      if (!File.ReadAllText(fileName).StartsWith("<"))
      {
        BCEDatabase.DecryptFile(fileName, fileName + "tmp");
        int num = (int) this.readOutDataSet.ReadXml(fileName + "tmp");
        File.Delete(fileName + "tmp");
      }
      else
      {
        int num1 = (int) this.readOutDataSet.ReadXml(fileName);
      }
      this.saveFileDialog1.FileName = fileName;
      this.saveFileDialog1.InitialDirectory = Path.GetFullPath(fileName);
    }

    private void ViewDataForm_Load(object sender, EventArgs e)
    {
      if (Utils.IsCountry("JP"))
      {
        this.addressDataGridViewTextBoxColumn.Visible = false;
        this.zipCodeDataGridViewTextBoxColumn.Visible = false;
        this.cityDataGridViewTextBoxColumn.Visible = false;
        string headerText = this.coordXDataGridViewTextBoxColumn.HeaderText;
        this.coordXDataGridViewTextBoxColumn.HeaderText = this.coordYDataGridViewTextBoxColumn.HeaderText;
        this.coordYDataGridViewTextBoxColumn.HeaderText = headerText;
      }
      this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
      this.dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
      this.dataGridView3.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
    }

    private void buttonClose_Click(object sender, EventArgs e) => this.Close();

    private void buttonSaveAs_Click(object sender, EventArgs e)
    {
      if (this.saveFileDialog1.ShowDialog() != DialogResult.OK)
        return;
      this.readOutDataSet.WriteXml(this.saveFileDialog1.FileName);
    }

    private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void buttonEdit_Click(object sender, EventArgs e)
    {
      PasswordForm passwordForm = new PasswordForm("Edit", ml.ml_string(1397, "Enter password to change the data"));
      string str = "141516";
      if (Utils.IsCountry("IQ") || Utils.IsCountry("RN"))
        str = "1967-1986";
      if (passwordForm.ShowDialog() != DialogResult.OK || !(passwordForm.Code == str))
        return;
      this.SetEditMode(true);
    }

    private void SetEditMode(bool editable)
    {
      this.buttonSaveAs.Enabled = editable;
      this.dataGridView1.ReadOnly = !editable;
      this.dataGridView2.ReadOnly = !editable;
      this.dataGridView3.ReadOnly = !editable;
      this.buttonEdit.Visible = !editable;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ViewDataForm));
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle9 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle10 = new DataGridViewCellStyle();
      this.dataGridView1 = new DataGridView();
      this.readOutDataSetBindingSource = new BindingSource(this.components);
      this.readOutDataSet = new ReadOutDataSet();
      this.buttonClose = new Button();
      this.label1 = new Label();
      this.dataGridView2 = new DataGridView();
      this.label2 = new Label();
      this.dataGridView3 = new DataGridView();
      this.label3 = new Label();
      this.buttonSaveAs = new Button();
      this.saveFileDialog1 = new SaveFileDialog();
      this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn15 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn16 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn17 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn18 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn19 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn20 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn21 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn22 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn23 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn24 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn25 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn26 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn27 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn28 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn29 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn30 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn31 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn32 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn33 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn34 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn35 = new DataGridViewTextBoxColumn();
      this.iDDataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      this.fancierIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.clubIDDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      this.flightIDDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      this.basketingMasterTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.basketingInternalTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.basketingDiffDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.readOutMasterTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.readOutInternalTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.readOutDiffDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.diffDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.iDDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      this.FancierID = new DataGridViewTextBoxColumn();
      this.elBandDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.fedBandDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.clubIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.flightIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.position1DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.position2DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.position3DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.position4DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.timeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.evaluationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.licenseDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.addressDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.zipCodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.cityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.coordXDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.coordYDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.Serial = new DataGridViewTextBoxColumn();
      this.DistanceString = new DataGridViewTextBoxColumn();
      this.Distance = new DataGridViewTextBoxColumn();
      this.DistanceUnit = new DataGridViewTextBoxColumn();
      this.buttonEdit = new Button();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((ISupportInitialize) this.readOutDataSetBindingSource).BeginInit();
      this.readOutDataSet.BeginInit();
      ((ISupportInitialize) this.dataGridView2).BeginInit();
      ((ISupportInitialize) this.dataGridView3).BeginInit();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.dataGridView1, "dataGridView1");
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.iDDataGridViewTextBoxColumn, (DataGridViewColumn) this.licenseDataGridViewTextBoxColumn, (DataGridViewColumn) this.nameDataGridViewTextBoxColumn, (DataGridViewColumn) this.addressDataGridViewTextBoxColumn, (DataGridViewColumn) this.zipCodeDataGridViewTextBoxColumn, (DataGridViewColumn) this.cityDataGridViewTextBoxColumn, (DataGridViewColumn) this.coordXDataGridViewTextBoxColumn, (DataGridViewColumn) this.coordYDataGridViewTextBoxColumn, (DataGridViewColumn) this.Serial, (DataGridViewColumn) this.DistanceString, (DataGridViewColumn) this.Distance, (DataGridViewColumn) this.DistanceUnit);
      this.dataGridView1.DataMember = "Fancier";
      this.dataGridView1.DataSource = (object) this.readOutDataSetBindingSource;
      this.dataGridView1.Name = "dataGridView1";
      this.readOutDataSetBindingSource.DataSource = (object) this.readOutDataSet;
      this.readOutDataSetBindingSource.Position = 0;
      this.readOutDataSet.DataSetName = "ReadOutDataSet";
      this.readOutDataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      componentResourceManager.ApplyResources((object) this.buttonClose, "buttonClose");
      this.buttonClose.Name = "buttonClose";
      this.buttonClose.UseVisualStyleBackColor = true;
      this.buttonClose.Click += new EventHandler(this.buttonClose_Click);
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      componentResourceManager.ApplyResources((object) this.dataGridView2, "dataGridView2");
      this.dataGridView2.AutoGenerateColumns = false;
      this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView2.Columns.AddRange((DataGridViewColumn) this.iDDataGridViewTextBoxColumn1, (DataGridViewColumn) this.FancierID, (DataGridViewColumn) this.elBandDataGridViewTextBoxColumn, (DataGridViewColumn) this.fedBandDataGridViewTextBoxColumn, (DataGridViewColumn) this.clubIDDataGridViewTextBoxColumn, (DataGridViewColumn) this.flightIDDataGridViewTextBoxColumn, (DataGridViewColumn) this.position1DataGridViewTextBoxColumn, (DataGridViewColumn) this.position2DataGridViewTextBoxColumn, (DataGridViewColumn) this.position3DataGridViewTextBoxColumn, (DataGridViewColumn) this.position4DataGridViewTextBoxColumn, (DataGridViewColumn) this.timeDataGridViewTextBoxColumn, (DataGridViewColumn) this.evaluationDataGridViewTextBoxColumn);
      this.dataGridView2.DataMember = "Pigeons";
      this.dataGridView2.DataSource = (object) this.readOutDataSetBindingSource;
      this.dataGridView2.Name = "dataGridView2";
      componentResourceManager.ApplyResources((object) this.label2, "label2");
      this.label2.Name = "label2";
      componentResourceManager.ApplyResources((object) this.dataGridView3, "dataGridView3");
      this.dataGridView3.AutoGenerateColumns = false;
      this.dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView3.Columns.AddRange((DataGridViewColumn) this.iDDataGridViewTextBoxColumn2, (DataGridViewColumn) this.fancierIDDataGridViewTextBoxColumn, (DataGridViewColumn) this.clubIDDataGridViewTextBoxColumn1, (DataGridViewColumn) this.flightIDDataGridViewTextBoxColumn1, (DataGridViewColumn) this.basketingMasterTimeDataGridViewTextBoxColumn, (DataGridViewColumn) this.basketingInternalTimeDataGridViewTextBoxColumn, (DataGridViewColumn) this.basketingDiffDataGridViewTextBoxColumn, (DataGridViewColumn) this.readOutMasterTimeDataGridViewTextBoxColumn, (DataGridViewColumn) this.readOutInternalTimeDataGridViewTextBoxColumn, (DataGridViewColumn) this.readOutDiffDataGridViewTextBoxColumn, (DataGridViewColumn) this.diffDataGridViewTextBoxColumn);
      this.dataGridView3.DataMember = "Timers";
      this.dataGridView3.DataSource = (object) this.readOutDataSetBindingSource;
      this.dataGridView3.Name = "dataGridView3";
      this.dataGridView3.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
      componentResourceManager.ApplyResources((object) this.label3, "label3");
      this.label3.Name = "label3";
      componentResourceManager.ApplyResources((object) this.buttonSaveAs, "buttonSaveAs");
      this.buttonSaveAs.Name = "buttonSaveAs";
      this.buttonSaveAs.UseVisualStyleBackColor = true;
      this.buttonSaveAs.Click += new EventHandler(this.buttonSaveAs_Click);
      this.saveFileDialog1.DefaultExt = "xml";
      componentResourceManager.ApplyResources((object) this.saveFileDialog1, "saveFileDialog1");
      this.saveFileDialog1.RestoreDirectory = true;
      this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      this.dataGridViewTextBoxColumn2.DataPropertyName = "License";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
      this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
      this.dataGridViewTextBoxColumn4.DataPropertyName = "Address";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
      this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
      this.dataGridViewTextBoxColumn5.DataPropertyName = "ZipCode";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
      this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
      this.dataGridViewTextBoxColumn6.DataPropertyName = "City";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn6, "dataGridViewTextBoxColumn6");
      this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
      this.dataGridViewTextBoxColumn7.DataPropertyName = "CoordX";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
      this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
      this.dataGridViewTextBoxColumn8.DataPropertyName = "CoordY";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn8, "dataGridViewTextBoxColumn8");
      this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
      this.dataGridViewTextBoxColumn9.DataPropertyName = "Serial";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn9, "dataGridViewTextBoxColumn9");
      this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
      this.dataGridViewTextBoxColumn10.DataPropertyName = "DistanceString";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn10, "dataGridViewTextBoxColumn10");
      this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
      this.dataGridViewTextBoxColumn11.DataPropertyName = "Distance";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn11, "dataGridViewTextBoxColumn11");
      this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
      this.dataGridViewTextBoxColumn12.DataPropertyName = "DistanceUnit";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn12, "dataGridViewTextBoxColumn12");
      this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
      this.dataGridViewTextBoxColumn13.DataPropertyName = "ID";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn13, "dataGridViewTextBoxColumn13");
      this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
      this.dataGridViewTextBoxColumn14.DataPropertyName = "FancierID";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn14, "dataGridViewTextBoxColumn14");
      this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
      this.dataGridViewTextBoxColumn15.DataPropertyName = "ElBand";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn15, "dataGridViewTextBoxColumn15");
      this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
      this.dataGridViewTextBoxColumn16.DataPropertyName = "FedBand";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn16, "dataGridViewTextBoxColumn16");
      this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
      this.dataGridViewTextBoxColumn17.DataPropertyName = "ClubID";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn17, "dataGridViewTextBoxColumn17");
      this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
      this.dataGridViewTextBoxColumn18.DataPropertyName = "FlightID";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn18, "dataGridViewTextBoxColumn18");
      this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
      this.dataGridViewTextBoxColumn19.DataPropertyName = "Position1";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn19, "dataGridViewTextBoxColumn19");
      this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
      this.dataGridViewTextBoxColumn20.DataPropertyName = "Position2";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn20, "dataGridViewTextBoxColumn20");
      this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
      this.dataGridViewTextBoxColumn21.DataPropertyName = "Position3";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn21, "dataGridViewTextBoxColumn21");
      this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
      this.dataGridViewTextBoxColumn22.DataPropertyName = "Position4";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn22, "dataGridViewTextBoxColumn22");
      this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
      this.dataGridViewTextBoxColumn23.DataPropertyName = "Time";
      gridViewCellStyle1.Format = "G";
      gridViewCellStyle1.NullValue = (object) null;
      this.dataGridViewTextBoxColumn23.DefaultCellStyle = gridViewCellStyle1;
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn23, "dataGridViewTextBoxColumn23");
      this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
      this.dataGridViewTextBoxColumn24.DataPropertyName = "Evaluation";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn24, "dataGridViewTextBoxColumn24");
      this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
      this.dataGridViewTextBoxColumn25.DataPropertyName = "ID";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn25, "dataGridViewTextBoxColumn25");
      this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
      this.dataGridViewTextBoxColumn26.DataPropertyName = "FancierID";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn26, "dataGridViewTextBoxColumn26");
      this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
      this.dataGridViewTextBoxColumn27.DataPropertyName = "ClubID";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn27, "dataGridViewTextBoxColumn27");
      this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
      this.dataGridViewTextBoxColumn28.DataPropertyName = "FlightID";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn28, "dataGridViewTextBoxColumn28");
      this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
      this.dataGridViewTextBoxColumn29.DataPropertyName = "BasketingMasterTime";
      gridViewCellStyle2.Format = "G";
      this.dataGridViewTextBoxColumn29.DefaultCellStyle = gridViewCellStyle2;
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn29, "dataGridViewTextBoxColumn29");
      this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
      this.dataGridViewTextBoxColumn30.DataPropertyName = "BasketingInternalTime";
      gridViewCellStyle3.Format = "G";
      this.dataGridViewTextBoxColumn30.DefaultCellStyle = gridViewCellStyle3;
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn30, "dataGridViewTextBoxColumn30");
      this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
      this.dataGridViewTextBoxColumn31.DataPropertyName = "BasketingDiff";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn31, "dataGridViewTextBoxColumn31");
      this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
      this.dataGridViewTextBoxColumn32.DataPropertyName = "ReadOutMasterTime";
      gridViewCellStyle4.Format = "G";
      this.dataGridViewTextBoxColumn32.DefaultCellStyle = gridViewCellStyle4;
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn32, "dataGridViewTextBoxColumn32");
      this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
      this.dataGridViewTextBoxColumn33.DataPropertyName = "ReadOutInternalTime";
      gridViewCellStyle5.Format = "G";
      this.dataGridViewTextBoxColumn33.DefaultCellStyle = gridViewCellStyle5;
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn33, "dataGridViewTextBoxColumn33");
      this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
      this.dataGridViewTextBoxColumn34.DataPropertyName = "ReadOutDiff";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn34, "dataGridViewTextBoxColumn34");
      this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
      this.dataGridViewTextBoxColumn35.DataPropertyName = "Diff";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn35, "dataGridViewTextBoxColumn35");
      this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
      this.iDDataGridViewTextBoxColumn2.DataPropertyName = "ID";
      componentResourceManager.ApplyResources((object) this.iDDataGridViewTextBoxColumn2, "iDDataGridViewTextBoxColumn2");
      this.iDDataGridViewTextBoxColumn2.Name = "iDDataGridViewTextBoxColumn2";
      this.fancierIDDataGridViewTextBoxColumn.DataPropertyName = "FancierID";
      componentResourceManager.ApplyResources((object) this.fancierIDDataGridViewTextBoxColumn, "fancierIDDataGridViewTextBoxColumn");
      this.fancierIDDataGridViewTextBoxColumn.Name = "fancierIDDataGridViewTextBoxColumn";
      this.clubIDDataGridViewTextBoxColumn1.DataPropertyName = "ClubID";
      componentResourceManager.ApplyResources((object) this.clubIDDataGridViewTextBoxColumn1, "clubIDDataGridViewTextBoxColumn1");
      this.clubIDDataGridViewTextBoxColumn1.Name = "clubIDDataGridViewTextBoxColumn1";
      this.flightIDDataGridViewTextBoxColumn1.DataPropertyName = "FlightID";
      componentResourceManager.ApplyResources((object) this.flightIDDataGridViewTextBoxColumn1, "flightIDDataGridViewTextBoxColumn1");
      this.flightIDDataGridViewTextBoxColumn1.Name = "flightIDDataGridViewTextBoxColumn1";
      this.basketingMasterTimeDataGridViewTextBoxColumn.DataPropertyName = "BasketingMasterTime";
      gridViewCellStyle6.Format = "G";
      this.basketingMasterTimeDataGridViewTextBoxColumn.DefaultCellStyle = gridViewCellStyle6;
      componentResourceManager.ApplyResources((object) this.basketingMasterTimeDataGridViewTextBoxColumn, "basketingMasterTimeDataGridViewTextBoxColumn");
      this.basketingMasterTimeDataGridViewTextBoxColumn.Name = "basketingMasterTimeDataGridViewTextBoxColumn";
      this.basketingInternalTimeDataGridViewTextBoxColumn.DataPropertyName = "BasketingInternalTime";
      gridViewCellStyle7.Format = "G";
      this.basketingInternalTimeDataGridViewTextBoxColumn.DefaultCellStyle = gridViewCellStyle7;
      componentResourceManager.ApplyResources((object) this.basketingInternalTimeDataGridViewTextBoxColumn, "basketingInternalTimeDataGridViewTextBoxColumn");
      this.basketingInternalTimeDataGridViewTextBoxColumn.Name = "basketingInternalTimeDataGridViewTextBoxColumn";
      this.basketingDiffDataGridViewTextBoxColumn.DataPropertyName = "BasketingDiff";
      componentResourceManager.ApplyResources((object) this.basketingDiffDataGridViewTextBoxColumn, "basketingDiffDataGridViewTextBoxColumn");
      this.basketingDiffDataGridViewTextBoxColumn.Name = "basketingDiffDataGridViewTextBoxColumn";
      this.readOutMasterTimeDataGridViewTextBoxColumn.DataPropertyName = "ReadOutMasterTime";
      gridViewCellStyle8.Format = "G";
      this.readOutMasterTimeDataGridViewTextBoxColumn.DefaultCellStyle = gridViewCellStyle8;
      componentResourceManager.ApplyResources((object) this.readOutMasterTimeDataGridViewTextBoxColumn, "readOutMasterTimeDataGridViewTextBoxColumn");
      this.readOutMasterTimeDataGridViewTextBoxColumn.Name = "readOutMasterTimeDataGridViewTextBoxColumn";
      this.readOutInternalTimeDataGridViewTextBoxColumn.DataPropertyName = "ReadOutInternalTime";
      gridViewCellStyle9.Format = "G";
      this.readOutInternalTimeDataGridViewTextBoxColumn.DefaultCellStyle = gridViewCellStyle9;
      componentResourceManager.ApplyResources((object) this.readOutInternalTimeDataGridViewTextBoxColumn, "readOutInternalTimeDataGridViewTextBoxColumn");
      this.readOutInternalTimeDataGridViewTextBoxColumn.Name = "readOutInternalTimeDataGridViewTextBoxColumn";
      this.readOutDiffDataGridViewTextBoxColumn.DataPropertyName = "ReadOutDiff";
      componentResourceManager.ApplyResources((object) this.readOutDiffDataGridViewTextBoxColumn, "readOutDiffDataGridViewTextBoxColumn");
      this.readOutDiffDataGridViewTextBoxColumn.Name = "readOutDiffDataGridViewTextBoxColumn";
      this.diffDataGridViewTextBoxColumn.DataPropertyName = "Diff";
      componentResourceManager.ApplyResources((object) this.diffDataGridViewTextBoxColumn, "diffDataGridViewTextBoxColumn");
      this.diffDataGridViewTextBoxColumn.Name = "diffDataGridViewTextBoxColumn";
      this.iDDataGridViewTextBoxColumn1.DataPropertyName = "ID";
      componentResourceManager.ApplyResources((object) this.iDDataGridViewTextBoxColumn1, "iDDataGridViewTextBoxColumn1");
      this.iDDataGridViewTextBoxColumn1.Name = "iDDataGridViewTextBoxColumn1";
      this.FancierID.DataPropertyName = "FancierID";
      componentResourceManager.ApplyResources((object) this.FancierID, "FancierID");
      this.FancierID.Name = "FancierID";
      this.elBandDataGridViewTextBoxColumn.DataPropertyName = "ElBand";
      componentResourceManager.ApplyResources((object) this.elBandDataGridViewTextBoxColumn, "elBandDataGridViewTextBoxColumn");
      this.elBandDataGridViewTextBoxColumn.Name = "elBandDataGridViewTextBoxColumn";
      this.fedBandDataGridViewTextBoxColumn.DataPropertyName = "FedBand";
      componentResourceManager.ApplyResources((object) this.fedBandDataGridViewTextBoxColumn, "fedBandDataGridViewTextBoxColumn");
      this.fedBandDataGridViewTextBoxColumn.Name = "fedBandDataGridViewTextBoxColumn";
      this.clubIDDataGridViewTextBoxColumn.DataPropertyName = "ClubID";
      componentResourceManager.ApplyResources((object) this.clubIDDataGridViewTextBoxColumn, "clubIDDataGridViewTextBoxColumn");
      this.clubIDDataGridViewTextBoxColumn.Name = "clubIDDataGridViewTextBoxColumn";
      this.flightIDDataGridViewTextBoxColumn.DataPropertyName = "FlightID";
      componentResourceManager.ApplyResources((object) this.flightIDDataGridViewTextBoxColumn, "flightIDDataGridViewTextBoxColumn");
      this.flightIDDataGridViewTextBoxColumn.Name = "flightIDDataGridViewTextBoxColumn";
      this.position1DataGridViewTextBoxColumn.DataPropertyName = "Position1";
      componentResourceManager.ApplyResources((object) this.position1DataGridViewTextBoxColumn, "position1DataGridViewTextBoxColumn");
      this.position1DataGridViewTextBoxColumn.Name = "position1DataGridViewTextBoxColumn";
      this.position2DataGridViewTextBoxColumn.DataPropertyName = "Position2";
      componentResourceManager.ApplyResources((object) this.position2DataGridViewTextBoxColumn, "position2DataGridViewTextBoxColumn");
      this.position2DataGridViewTextBoxColumn.Name = "position2DataGridViewTextBoxColumn";
      this.position3DataGridViewTextBoxColumn.DataPropertyName = "Position3";
      componentResourceManager.ApplyResources((object) this.position3DataGridViewTextBoxColumn, "position3DataGridViewTextBoxColumn");
      this.position3DataGridViewTextBoxColumn.Name = "position3DataGridViewTextBoxColumn";
      this.position4DataGridViewTextBoxColumn.DataPropertyName = "Position4";
      componentResourceManager.ApplyResources((object) this.position4DataGridViewTextBoxColumn, "position4DataGridViewTextBoxColumn");
      this.position4DataGridViewTextBoxColumn.Name = "position4DataGridViewTextBoxColumn";
      this.timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
      gridViewCellStyle10.Format = "G";
      gridViewCellStyle10.NullValue = (object) null;
      this.timeDataGridViewTextBoxColumn.DefaultCellStyle = gridViewCellStyle10;
      componentResourceManager.ApplyResources((object) this.timeDataGridViewTextBoxColumn, "timeDataGridViewTextBoxColumn");
      this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
      this.evaluationDataGridViewTextBoxColumn.DataPropertyName = "Evaluation";
      componentResourceManager.ApplyResources((object) this.evaluationDataGridViewTextBoxColumn, "evaluationDataGridViewTextBoxColumn");
      this.evaluationDataGridViewTextBoxColumn.Name = "evaluationDataGridViewTextBoxColumn";
      this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
      componentResourceManager.ApplyResources((object) this.iDDataGridViewTextBoxColumn, "iDDataGridViewTextBoxColumn");
      this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
      this.licenseDataGridViewTextBoxColumn.DataPropertyName = "License";
      componentResourceManager.ApplyResources((object) this.licenseDataGridViewTextBoxColumn, "licenseDataGridViewTextBoxColumn");
      this.licenseDataGridViewTextBoxColumn.Name = "licenseDataGridViewTextBoxColumn";
      this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
      componentResourceManager.ApplyResources((object) this.nameDataGridViewTextBoxColumn, "nameDataGridViewTextBoxColumn");
      this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
      this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
      componentResourceManager.ApplyResources((object) this.addressDataGridViewTextBoxColumn, "addressDataGridViewTextBoxColumn");
      this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
      this.zipCodeDataGridViewTextBoxColumn.DataPropertyName = "ZipCode";
      componentResourceManager.ApplyResources((object) this.zipCodeDataGridViewTextBoxColumn, "zipCodeDataGridViewTextBoxColumn");
      this.zipCodeDataGridViewTextBoxColumn.Name = "zipCodeDataGridViewTextBoxColumn";
      this.cityDataGridViewTextBoxColumn.DataPropertyName = "City";
      componentResourceManager.ApplyResources((object) this.cityDataGridViewTextBoxColumn, "cityDataGridViewTextBoxColumn");
      this.cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
      this.coordXDataGridViewTextBoxColumn.DataPropertyName = "CoordX";
      componentResourceManager.ApplyResources((object) this.coordXDataGridViewTextBoxColumn, "coordXDataGridViewTextBoxColumn");
      this.coordXDataGridViewTextBoxColumn.Name = "coordXDataGridViewTextBoxColumn";
      this.coordYDataGridViewTextBoxColumn.DataPropertyName = "CoordY";
      componentResourceManager.ApplyResources((object) this.coordYDataGridViewTextBoxColumn, "coordYDataGridViewTextBoxColumn");
      this.coordYDataGridViewTextBoxColumn.Name = "coordYDataGridViewTextBoxColumn";
      this.Serial.DataPropertyName = "Serial";
      componentResourceManager.ApplyResources((object) this.Serial, "Serial");
      this.Serial.Name = "Serial";
      this.DistanceString.DataPropertyName = "DistanceString";
      componentResourceManager.ApplyResources((object) this.DistanceString, "DistanceString");
      this.DistanceString.Name = "DistanceString";
      this.Distance.DataPropertyName = "Distance";
      componentResourceManager.ApplyResources((object) this.Distance, "Distance");
      this.Distance.Name = "Distance";
      this.DistanceUnit.DataPropertyName = "DistanceUnit";
      componentResourceManager.ApplyResources((object) this.DistanceUnit, "DistanceUnit");
      this.DistanceUnit.Name = "DistanceUnit";
      componentResourceManager.ApplyResources((object) this.buttonEdit, "buttonEdit");
      this.buttonEdit.Name = "buttonEdit";
      this.buttonEdit.UseVisualStyleBackColor = true;
      this.buttonEdit.Click += new EventHandler(this.buttonEdit_Click);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.buttonEdit);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.buttonSaveAs);
      this.Controls.Add((Control) this.buttonClose);
      this.Controls.Add((Control) this.dataGridView3);
      this.Controls.Add((Control) this.dataGridView2);
      this.Controls.Add((Control) this.dataGridView1);
      this.Name = nameof (ViewDataForm);
      this.Load += new EventHandler(this.ViewDataForm_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((ISupportInitialize) this.readOutDataSetBindingSource).EndInit();
      this.readOutDataSet.EndInit();
      ((ISupportInitialize) this.dataGridView2).EndInit();
      ((ISupportInitialize) this.dataGridView3).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
