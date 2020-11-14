// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.FlightDistanceForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using BriconLib.Other;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BriconLib.UI
{
  public class FlightDistanceForm : Form
  {
    private readonly int _fancierId;
    private IContainer components;
    private DataGridView dataGridView1;
    private Button buttonOK;
    private Button buttonCancel;
    private BindingSource lossingsplaatsBindingSource;
    private BCEDataSet bCEDataSet;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private DataGridViewTextBoxColumn losplaatsDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn RaceCode;
    private DataGridViewTextBoxColumn placeDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn distanceDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn Distance;

    public FlightDistanceForm(int fancierId)
    {
      this._fancierId = fancierId;
      this.InitializeComponent();
    }

    private void FlightDistanceForm_Load(object sender, EventArgs e)
    {
      if (Utils.UnitsUsed() != "Imperial")
      {
        this.distanceDataGridViewTextBoxColumn.HeaderText = "km";
        this.Distance.HeaderText = "m";
      }
      foreach (BCEDataSet.DistancesRow distancesRow in BCEDatabase.DataSet.Distances.Select("FancierID = " + this._fancierId.ToString()))
      {
        try
        {
          distancesRow.DistanceYards = distancesRow.DistanceYards;
        }
        catch (Exception ex)
        {
          distancesRow.DistanceYards = 0;
        }
        BCEDataSet.LossingsplaatsRow byid = BCEDatabase.DataSet.Lossingsplaats.FindByid(distancesRow.LosplaatsID);
        if (byid != null)
        {
          byid.Distance = distancesRow.Distance;
          try
          {
            byid.DistanceYards = distancesRow.DistanceYards;
          }
          catch (Exception ex)
          {
            distancesRow.DistanceYards = 0;
          }
        }
      }
      this.lossingsplaatsBindingSource.DataSource = (object) BCEDatabase.DataSet;
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      foreach (BCEDataSet.DistancesRow distancesRow in BCEDatabase.DataSet.Distances.Select("FancierID = " + this._fancierId.ToString()))
      {
        BCEDataSet.LossingsplaatsRow byid = BCEDatabase.DataSet.Lossingsplaats.FindByid(distancesRow.LosplaatsID);
        if (byid == null || byid.Distance == 0)
        {
          distancesRow.Delete();
        }
        else
        {
          distancesRow.Distance = byid.Distance;
          distancesRow.DistanceYards = byid.DistanceYards;
        }
      }
      foreach (BCEDataSet.LossingsplaatsRow lossingsplaat in (TypedTableBase<BCEDataSet.LossingsplaatsRow>) BCEDatabase.DataSet.Lossingsplaats)
      {
        if (lossingsplaat.Distance != 0)
        {
          BCEDataSet.DistancesDataTable distances = BCEDatabase.DataSet.Distances;
          int num = this._fancierId;
          string str1 = num.ToString();
          num = lossingsplaat.id;
          string str2 = num.ToString();
          string filterExpression = "FancierID = " + str1 + " and LosplaatsID = " + str2;
          if (distances.Select(filterExpression).Length == 0)
          {
            BCEDataSet.DistancesRow row = BCEDatabase.DataSet.Distances.NewDistancesRow();
            row.Distance = lossingsplaat.Distance;
            row.DistanceYards = lossingsplaat.DistanceYards;
            row.FancierID = this._fancierId;
            row.LosplaatsID = lossingsplaat.id;
            BCEDatabase.DataSet.Distances.AddDistancesRow(row);
          }
        }
      }
      BCEDatabase.DataSet.AcceptChanges();
    }

    private void FlightDistanceForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      foreach (BCEDataSet.LossingsplaatsRow lossingsplaat in (TypedTableBase<BCEDataSet.LossingsplaatsRow>) BCEDatabase.DataSet.Lossingsplaats)
      {
        lossingsplaat.Distance = 0;
        lossingsplaat.DistanceYards = 0;
      }
    }

    private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
    {
    }

    private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
      if (e.ColumnIndex == this.Distance.Index)
      {
        int result;
        if (int.TryParse(e.FormattedValue as string, out result))
        {
          if (Utils.UnitsUsed() == "Imperial")
          {
            if (result < 0 || result > 1759)
              e.Cancel = true;
          }
          else if (result < 0 || result > 1000)
            e.Cancel = true;
        }
        else
          e.Cancel = true;
      }
      if (e.ColumnIndex != this.distanceDataGridViewTextBoxColumn.Index)
        return;
      int result1;
      if (int.TryParse(e.FormattedValue as string, out result1))
      {
        if (Utils.UnitsUsed() == "Imperial")
        {
          if (result1 >= 0 && result1 <= 999)
            return;
          e.Cancel = true;
        }
        else
        {
          if (result1 >= 0 && result1 <= 1999)
            return;
          e.Cancel = true;
        }
      }
      else
        e.Cancel = true;
    }

    private void button1_Click(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FlightDistanceForm));
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      this.dataGridView1 = new DataGridView();
      this.lossingsplaatsBindingSource = new BindingSource(this.components);
      this.bCEDataSet = new BCEDataSet();
      this.buttonOK = new Button();
      this.buttonCancel = new Button();
      this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      this.losplaatsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.RaceCode = new DataGridViewTextBoxColumn();
      this.placeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.distanceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.Distance = new DataGridViewTextBoxColumn();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((ISupportInitialize) this.lossingsplaatsBindingSource).BeginInit();
      this.bCEDataSet.BeginInit();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      componentResourceManager.ApplyResources((object) this.dataGridView1, "dataGridView1");
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.losplaatsDataGridViewTextBoxColumn, (DataGridViewColumn) this.codeDataGridViewTextBoxColumn, (DataGridViewColumn) this.RaceCode, (DataGridViewColumn) this.placeDataGridViewTextBoxColumn, (DataGridViewColumn) this.distanceDataGridViewTextBoxColumn, (DataGridViewColumn) this.Distance);
      this.dataGridView1.DataSource = (object) this.lossingsplaatsBindingSource;
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.CellValidating += new DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
      this.dataGridView1.RowValidating += new DataGridViewCellCancelEventHandler(this.dataGridView1_RowValidating);
      this.lossingsplaatsBindingSource.AllowNew = false;
      this.lossingsplaatsBindingSource.DataMember = "Lossingsplaats";
      this.lossingsplaatsBindingSource.DataSource = (object) this.bCEDataSet;
      this.bCEDataSet.DataSetName = "BCEDataSet";
      this.bCEDataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      componentResourceManager.ApplyResources((object) this.buttonOK, "buttonOK");
      this.buttonOK.DialogResult = DialogResult.OK;
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
      componentResourceManager.ApplyResources((object) this.buttonCancel, "buttonCancel");
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.dataGridViewTextBoxColumn1.DataPropertyName = "Losplaats";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      this.dataGridViewTextBoxColumn2.DataPropertyName = "Code";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      this.dataGridViewTextBoxColumn3.DataPropertyName = "Place";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
      this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
      this.dataGridViewTextBoxColumn4.DataPropertyName = "Distance";
      gridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dataGridViewTextBoxColumn4.DefaultCellStyle = gridViewCellStyle1;
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
      this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
      this.dataGridViewTextBoxColumn5.DataPropertyName = "DistanceYards";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
      this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
      this.losplaatsDataGridViewTextBoxColumn.DataPropertyName = "Losplaats";
      componentResourceManager.ApplyResources((object) this.losplaatsDataGridViewTextBoxColumn, "losplaatsDataGridViewTextBoxColumn");
      this.losplaatsDataGridViewTextBoxColumn.Name = "losplaatsDataGridViewTextBoxColumn";
      this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
      componentResourceManager.ApplyResources((object) this.codeDataGridViewTextBoxColumn, "codeDataGridViewTextBoxColumn");
      this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
      this.RaceCode.DataPropertyName = "RaceCode";
      componentResourceManager.ApplyResources((object) this.RaceCode, "RaceCode");
      this.RaceCode.Name = "RaceCode";
      this.placeDataGridViewTextBoxColumn.DataPropertyName = "Place";
      componentResourceManager.ApplyResources((object) this.placeDataGridViewTextBoxColumn, "placeDataGridViewTextBoxColumn");
      this.placeDataGridViewTextBoxColumn.Name = "placeDataGridViewTextBoxColumn";
      this.distanceDataGridViewTextBoxColumn.DataPropertyName = "Distance";
      gridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.distanceDataGridViewTextBoxColumn.DefaultCellStyle = gridViewCellStyle2;
      componentResourceManager.ApplyResources((object) this.distanceDataGridViewTextBoxColumn, "distanceDataGridViewTextBoxColumn");
      this.distanceDataGridViewTextBoxColumn.Name = "distanceDataGridViewTextBoxColumn";
      this.Distance.DataPropertyName = "DistanceYards";
      gridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Distance.DefaultCellStyle = gridViewCellStyle3;
      componentResourceManager.ApplyResources((object) this.Distance, "Distance");
      this.Distance.Name = "Distance";
      this.AcceptButton = (IButtonControl) this.buttonOK;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonCancel;
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonOK);
      this.Controls.Add((Control) this.dataGridView1);
      this.Name = nameof (FlightDistanceForm);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.FormClosing += new FormClosingEventHandler(this.FlightDistanceForm_FormClosing);
      this.Load += new EventHandler(this.FlightDistanceForm_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((ISupportInitialize) this.lossingsplaatsBindingSource).EndInit();
      this.bCEDataSet.EndInit();
      this.ResumeLayout(false);
    }
  }
}
