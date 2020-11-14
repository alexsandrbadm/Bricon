// Decompiled with JetBrains decompiler
// Type: BriconLib.PrintManager.BetForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using MultiLang;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BriconLib.PrintManager
{
  public class BetForm : Form
  {
    private ReadOutDataSet _dataset = new ReadOutDataSet();
    private IContainer components;
    private DataGridView dataGridView1;
    private Button buttonCancel;
    private Button buttonSend;
    private Label label1;
    private ComboBox comboBox1;
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
    private DataGridView dataGridViewPigeons;
    private DataGridView dataGridViewRaces;
    private Label label2;
    private Label label3;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
    private Label label4;
    private Label labelDesignated;
    private Button buttonPrint;
    private Label label5;
    private Label label6;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
    private DataGridViewTextBoxColumn DBRingColumn;
    private DataGridViewTextBoxColumn PositionColumn;
    private DataGridViewTextBoxColumn Pos2Column;
    private DataGridViewTextBoxColumn Pos3Column;
    private DataGridViewTextBoxColumn FlightColumn;
    private Label labelDesignated2;
    private Label labelDesignated3;
    private Button buttonClear;
    private Label labelError;
    private DataGridViewTextBoxColumn Column1;
    private DataGridViewTextBoxColumn Column2;
    private DataGridViewTextBoxColumn Column3;
    private DataGridViewTextBoxColumn Column4;
    private DataGridViewTextBoxColumn Column5;
    private DataGridViewTextBoxColumn Column6;
    private DataGridViewTextBoxColumn Column7;
    private DataGridViewTextBoxColumn Column8;
    private DataGridViewTextBoxColumn Column9;
    private DataGridViewTextBoxColumn Column10;
    private DataGridViewTextBoxColumn Column11;
    private DataGridViewTextBoxColumn Column12;
    private DataGridViewTextBoxColumn Column13;
    private DataGridViewTextBoxColumn Column14;
    private DataGridViewTextBoxColumn Column15;
    private DataGridViewTextBoxColumn Column16;
    private DataGridViewTextBoxColumn Column17;
    private DataGridViewTextBoxColumn Column18;
    private DataGridViewTextBoxColumn Column19;

    public BetForm(ReadOutDataSet dataset)
    {
      this.InitializeComponent();
      this._dataset = dataset;
      if (Utils.IsCountry("BE"))
      {
        this.Width = this.dataGridView1.Left - 1;
        this.comboBox1.Visible = false;
        this.label1.Visible = false;
      }
      else
      {
        if (!Utils.IsCountry("NL"))
        {
          this.Width = this.dataGridView1.Left - 1;
          this.Text = ml.ml_string(1393, "Aanwijzen en Poelen");
        }
        this.Pos3Column.Visible = false;
        this.Pos2Column.Visible = false;
        this.labelDesignated2.Visible = false;
        this.labelDesignated3.Visible = false;
        this.PositionColumn.HeaderText = ml.ml_string(1088, "Pos");
      }
      this.ClearPositions();
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridViewRaces.AutoGenerateColumns = false;
      this.dataGridViewPigeons.AutoGenerateColumns = false;
      this.dataGridViewRaces.DataSource = (object) dataset.Timers;
      this.dataGridView1.DataSource = (object) dataset.PoulLetter;
      this.dataGridViewPigeons.DataSource = (object) dataset.Pigeons;
      this.comboBox1.Items.Clear();
      foreach (ReadOutDataSet.RaceNamesRow row in (InternalDataCollectionBase) dataset.RaceNames.Rows)
        this.comboBox1.Items.Add((object) new BetForm.myComboItem()
        {
          Text = row.Name,
          FlightID = row.FlightID,
          RaceIndex = (byte) (row.ID - 1)
        });
      dataset.PoulLetter.Clear();
      ReadOutDataSet.PoulLetterRow row1 = dataset.PoulLetter.NewPoulLetterRow();
      row1.Col0 = ml.ml_string(1085, "Uits");
      dataset.PoulLetter.AddPoulLetterRow(row1);
      ReadOutDataSet.PoulLetterRow row2 = dataset.PoulLetter.NewPoulLetterRow();
      row2.Col0 = ml.ml_string(1086, "Gez");
      dataset.PoulLetter.AddPoulLetterRow(row2);
      for (int index = 1; index <= 32; ++index)
      {
        ReadOutDataSet.PoulLetterRow row3 = dataset.PoulLetter.NewPoulLetterRow();
        row3.Col0 = index.ToString();
        dataset.PoulLetter.AddPoulLetterRow(row3);
      }
      this.dataGridView1.Rows[1].Cells[1].Value = (object) 0;
    }

    private void ClearPositions()
    {
      this.labelDesignated.Text = this.labelDesignated2.Text = this.labelDesignated3.Text = "0";
      foreach (ReadOutDataSet.PigeonsRow row in (InternalDataCollectionBase) this._dataset.Pigeons.Rows)
      {
        if (row.Evaluation == "0")
        {
          row.SetPosition1Null();
          row.SetPosition2Null();
          row.SetPosition3Null();
        }
      }
    }

    private void BetForm_Load(object sender, EventArgs e)
    {
    }

    private void dataGridViewPigeons_CellFormatting(
      object sender,
      DataGridViewCellFormattingEventArgs e)
    {
      if (!(this._dataset.Pigeons[e.RowIndex].Evaluation != "0"))
        return;
      e.CellStyle.ForeColor = Color.Red;
    }

    private void dataGridViewPigeons_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this._dataset.Pigeons[e.RowIndex].Evaluation != "0")
        return;
      if (e.ColumnIndex == this.PositionColumn.Index)
      {
        int int32 = Convert.ToInt32(this.labelDesignated.Text);
        if (this._dataset.Pigeons[e.RowIndex].IsPosition1Null())
        {
          int num = int32 + 1;
          this._dataset.Pigeons[e.RowIndex].Position1 = num;
          this.labelDesignated.Text = num.ToString();
          if (this.dataGridView1.Rows.Count < 2 || (int) (ushort) this.dataGridView1.Rows[1].Cells[1].Value >= num)
            return;
          this.dataGridView1.Rows[1].Cells[1].Value = (object) num;
        }
        else
        {
          int num = int32 - 1;
          this._dataset.Pigeons[e.RowIndex].SetPosition1Null();
          this.labelDesignated.Text = num.ToString();
          foreach (ReadOutDataSet.PigeonsRow row in (InternalDataCollectionBase) this._dataset.Pigeons.Rows)
          {
            if (!row.IsPosition1Null() && row.Position1 > num)
              --row.Position1;
          }
        }
      }
      else
      {
        if (!Utils.IsCountry("BE"))
          return;
        if (e.ColumnIndex == this.Pos2Column.Index)
        {
          int int32 = Convert.ToInt32(this.labelDesignated2.Text);
          if (this._dataset.Pigeons[e.RowIndex].IsPosition2Null())
          {
            int num = int32 + 1;
            this._dataset.Pigeons[e.RowIndex].Position2 = num;
            this.labelDesignated2.Text = num.ToString();
          }
          else
          {
            int num = int32 - 1;
            this._dataset.Pigeons[e.RowIndex].SetPosition2Null();
            this.labelDesignated2.Text = num.ToString();
            foreach (ReadOutDataSet.PigeonsRow row in (InternalDataCollectionBase) this._dataset.Pigeons.Rows)
            {
              if (this._dataset.Pigeons[e.RowIndex].Evaluation == "0" && !row.IsPosition2Null() && row.Position2 > num)
                --row.Position2;
            }
          }
        }
        else
        {
          if (e.ColumnIndex != this.Pos3Column.Index)
            return;
          int int32 = Convert.ToInt32(this.labelDesignated3.Text);
          if (this._dataset.Pigeons[e.RowIndex].IsPosition3Null())
          {
            int num = int32 + 1;
            this._dataset.Pigeons[e.RowIndex].Position3 = num;
            this.labelDesignated3.Text = num.ToString();
          }
          else
          {
            int num = int32 - 1;
            this._dataset.Pigeons[e.RowIndex].SetPosition3Null();
            this.labelDesignated3.Text = num.ToString();
            foreach (ReadOutDataSet.PigeonsRow row in (InternalDataCollectionBase) this._dataset.Pigeons.Rows)
            {
              if (this._dataset.Pigeons[e.RowIndex].Evaluation == "0" && !row.IsPosition3Null() && row.Position3 > num)
                --row.Position3;
            }
          }
        }
      }
    }

    private bool CheckIfFlightIsSelected()
    {
      if (Utils.IsCountry("BE") || this.comboBox1.SelectedItem is BetForm.myComboItem)
        return true;
      int num = (int) MessageBox.Show(ml.ml_string(1090, "Please select a race"));
      return false;
    }

    private string GetFlightID() => Utils.IsCountry("BE") ? (this.dataGridViewRaces.SelectedRows.Count == 0 ? "" : this.dataGridViewRaces.SelectedRows[0].Cells[0].ToString()) : (!(this.comboBox1.SelectedItem is BetForm.myComboItem) ? "" : (this.comboBox1.SelectedItem as BetForm.myComboItem).FlightID);

    private byte GetRaceIndex()
    {
      if (!Utils.IsCountry("BE"))
        return (this.comboBox1.SelectedItem as BetForm.myComboItem).RaceIndex;
      return this.dataGridViewRaces.SelectedRows.Count == 0 ? (byte) 0 : (byte) this.dataGridViewRaces.SelectedRows[0].Index;
    }

    private void buttonSend_Click(object sender, EventArgs e)
    {
      if (!this.CheckIfFlightIsSelected() || !new SendPoulLetter().SendIt(this._dataset, this.GetFlightID(), this.GetRaceIndex()))
        return;
      int num = (int) MessageBox.Show(ml.ml_string(77, "Ready"));
      this.buttonSend.Text = ml.ml_string(1089, "Resend");
      this.buttonPrint.Enabled = true;
    }

    private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
      this.labelError.Visible = false;
      this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
      if (e.ColumnIndex == 0 || e.RowIndex == 0 || e.RowIndex != 1 && e.FormattedValue as string == "")
        return;
      if (e.RowIndex == 1)
      {
        int num = 0;
        foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
        {
          if (row.Index != 0 && row.Index != 1)
          {
            DataGridViewCell cell = row.Cells[e.ColumnIndex];
            if (cell.Value.GetType() == typeof (ushort) && (int) (ushort) cell.Value > num)
              num = (int) (ushort) cell.Value;
          }
        }
        if (e.ColumnIndex == 1)
        {
          foreach (DataGridViewCell cell in (BaseCollection) this.dataGridView1.Rows[1].Cells)
          {
            if (cell.ColumnIndex > 1 && cell.Value.GetType() == typeof (ushort) && (int) (ushort) cell.Value > num)
              num = (int) (ushort) cell.Value;
          }
        }
        if (num == 0 && e.FormattedValue as string == "")
          return;
        ushort result = 0;
        if (!ushort.TryParse(e.FormattedValue as string, out result))
        {
          this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
          this.labelError.Visible = true;
          e.Cancel = true;
        }
        else
        {
          if ((int) result < num)
          {
            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
            this.labelError.Visible = true;
            e.Cancel = true;
          }
          if (e.ColumnIndex == 1 || !(this.dataGridView1.Rows[1].Cells[1].Value.GetType() != typeof (ushort)) && (int) result <= (int) (ushort) this.dataGridView1.Rows[1].Cells[1].Value)
            return;
          this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
          this.labelError.Visible = true;
          e.Cancel = true;
        }
      }
      else
      {
        ushort result = 0;
        if (!ushort.TryParse(e.FormattedValue as string, out result))
        {
          this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
          this.labelError.Visible = true;
          e.Cancel = true;
        }
        else
        {
          if (!(this.dataGridView1.Rows[1].Cells[e.ColumnIndex].Value.GetType() != typeof (ushort)) && (int) result <= (int) (ushort) this.dataGridView1.Rows[1].Cells[e.ColumnIndex].Value)
            return;
          this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
          this.labelError.Visible = true;
          e.Cancel = true;
        }
      }
    }

    private void buttonClear_Click(object sender, EventArgs e)
    {
      this.ClearPositions();
      foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
      {
        foreach (DataGridViewCell cell in (BaseCollection) row.Cells)
        {
          if (cell.ColumnIndex != 0)
            cell.Value = (object) DBNull.Value;
        }
      }
    }

    private void buttonPrint_Click(object sender, EventArgs e)
    {
      this._dataset.Fancier[0].FlightDesignated = this.GetFlightID();
      PrintHelper.PrintBetForm(this._dataset);
    }

    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if (e.RowIndex != 1)
        return;
      e.CellStyle.ForeColor = Color.Blue;
      e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (BetForm));
      this.dataGridView1 = new DataGridView();
      this.buttonCancel = new Button();
      this.buttonSend = new Button();
      this.label1 = new Label();
      this.comboBox1 = new ComboBox();
      this.dataGridViewPigeons = new DataGridView();
      this.DBRingColumn = new DataGridViewTextBoxColumn();
      this.PositionColumn = new DataGridViewTextBoxColumn();
      this.Pos2Column = new DataGridViewTextBoxColumn();
      this.Pos3Column = new DataGridViewTextBoxColumn();
      this.FlightColumn = new DataGridViewTextBoxColumn();
      this.dataGridViewRaces = new DataGridView();
      this.dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn15 = new DataGridViewTextBoxColumn();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.labelDesignated = new Label();
      this.buttonPrint = new Button();
      this.label5 = new Label();
      this.label6 = new Label();
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
      this.dataGridViewTextBoxColumn16 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn17 = new DataGridViewTextBoxColumn();
      this.labelDesignated2 = new Label();
      this.labelDesignated3 = new Label();
      this.buttonClear = new Button();
      this.labelError = new Label();
      this.Column1 = new DataGridViewTextBoxColumn();
      this.Column2 = new DataGridViewTextBoxColumn();
      this.Column3 = new DataGridViewTextBoxColumn();
      this.Column4 = new DataGridViewTextBoxColumn();
      this.Column5 = new DataGridViewTextBoxColumn();
      this.Column6 = new DataGridViewTextBoxColumn();
      this.Column7 = new DataGridViewTextBoxColumn();
      this.Column8 = new DataGridViewTextBoxColumn();
      this.Column9 = new DataGridViewTextBoxColumn();
      this.Column10 = new DataGridViewTextBoxColumn();
      this.Column11 = new DataGridViewTextBoxColumn();
      this.Column12 = new DataGridViewTextBoxColumn();
      this.Column13 = new DataGridViewTextBoxColumn();
      this.Column14 = new DataGridViewTextBoxColumn();
      this.Column15 = new DataGridViewTextBoxColumn();
      this.Column16 = new DataGridViewTextBoxColumn();
      this.Column17 = new DataGridViewTextBoxColumn();
      this.Column18 = new DataGridViewTextBoxColumn();
      this.Column19 = new DataGridViewTextBoxColumn();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((ISupportInitialize) this.dataGridViewPigeons).BeginInit();
      ((ISupportInitialize) this.dataGridViewRaces).BeginInit();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AllowUserToResizeColumns = false;
      this.dataGridView1.AllowUserToResizeRows = false;
      componentResourceManager.ApplyResources((object) this.dataGridView1, "dataGridView1");
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.Column1, (DataGridViewColumn) this.Column2, (DataGridViewColumn) this.Column3, (DataGridViewColumn) this.Column4, (DataGridViewColumn) this.Column5, (DataGridViewColumn) this.Column6, (DataGridViewColumn) this.Column7, (DataGridViewColumn) this.Column8, (DataGridViewColumn) this.Column9, (DataGridViewColumn) this.Column10, (DataGridViewColumn) this.Column11, (DataGridViewColumn) this.Column12, (DataGridViewColumn) this.Column13, (DataGridViewColumn) this.Column14, (DataGridViewColumn) this.Column15, (DataGridViewColumn) this.Column16, (DataGridViewColumn) this.Column17, (DataGridViewColumn) this.Column18, (DataGridViewColumn) this.Column19);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.RowTemplate.Height = 18;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
      this.dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
      this.dataGridView1.CellValidating += new DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
      componentResourceManager.ApplyResources((object) this.buttonCancel, "buttonCancel");
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.buttonSend, "buttonSend");
      this.buttonSend.Name = "buttonSend";
      this.buttonSend.UseVisualStyleBackColor = true;
      this.buttonSend.Click += new EventHandler(this.buttonSend_Click);
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      componentResourceManager.ApplyResources((object) this.comboBox1, "comboBox1");
      this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[13]
      {
        (object) componentResourceManager.GetString("comboBox1.Items"),
        (object) componentResourceManager.GetString("comboBox1.Items1"),
        (object) componentResourceManager.GetString("comboBox1.Items2"),
        (object) componentResourceManager.GetString("comboBox1.Items3"),
        (object) componentResourceManager.GetString("comboBox1.Items4"),
        (object) componentResourceManager.GetString("comboBox1.Items5"),
        (object) componentResourceManager.GetString("comboBox1.Items6"),
        (object) componentResourceManager.GetString("comboBox1.Items7"),
        (object) componentResourceManager.GetString("comboBox1.Items8"),
        (object) componentResourceManager.GetString("comboBox1.Items9"),
        (object) componentResourceManager.GetString("comboBox1.Items10"),
        (object) componentResourceManager.GetString("comboBox1.Items11"),
        (object) componentResourceManager.GetString("comboBox1.Items12")
      });
      this.comboBox1.Name = "comboBox1";
      this.dataGridViewPigeons.AllowUserToAddRows = false;
      this.dataGridViewPigeons.AllowUserToDeleteRows = false;
      this.dataGridViewPigeons.AllowUserToResizeColumns = false;
      this.dataGridViewPigeons.AllowUserToResizeRows = false;
      componentResourceManager.ApplyResources((object) this.dataGridViewPigeons, "dataGridViewPigeons");
      this.dataGridViewPigeons.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridViewPigeons.Columns.AddRange((DataGridViewColumn) this.DBRingColumn, (DataGridViewColumn) this.PositionColumn, (DataGridViewColumn) this.Pos2Column, (DataGridViewColumn) this.Pos3Column, (DataGridViewColumn) this.FlightColumn);
      this.dataGridViewPigeons.Name = "dataGridViewPigeons";
      this.dataGridViewPigeons.ReadOnly = true;
      this.dataGridViewPigeons.RowHeadersVisible = false;
      this.dataGridViewPigeons.RowTemplate.Height = 18;
      this.dataGridViewPigeons.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridViewPigeons.CellClick += new DataGridViewCellEventHandler(this.dataGridViewPigeons_CellClick);
      this.dataGridViewPigeons.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dataGridViewPigeons_CellFormatting);
      this.DBRingColumn.DataPropertyName = "FedBand";
      componentResourceManager.ApplyResources((object) this.DBRingColumn, "DBRingColumn");
      this.DBRingColumn.Name = "DBRingColumn";
      this.DBRingColumn.ReadOnly = true;
      this.PositionColumn.DataPropertyName = "Position1";
      componentResourceManager.ApplyResources((object) this.PositionColumn, "PositionColumn");
      this.PositionColumn.Name = "PositionColumn";
      this.PositionColumn.ReadOnly = true;
      this.Pos2Column.DataPropertyName = "Position2";
      componentResourceManager.ApplyResources((object) this.Pos2Column, "Pos2Column");
      this.Pos2Column.Name = "Pos2Column";
      this.Pos2Column.ReadOnly = true;
      this.Pos3Column.DataPropertyName = "Position3";
      componentResourceManager.ApplyResources((object) this.Pos3Column, "Pos3Column");
      this.Pos3Column.Name = "Pos3Column";
      this.Pos3Column.ReadOnly = true;
      this.FlightColumn.DataPropertyName = "FlightID";
      componentResourceManager.ApplyResources((object) this.FlightColumn, "FlightColumn");
      this.FlightColumn.Name = "FlightColumn";
      this.FlightColumn.ReadOnly = true;
      this.dataGridViewRaces.AllowUserToAddRows = false;
      this.dataGridViewRaces.AllowUserToDeleteRows = false;
      this.dataGridViewRaces.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridViewRaces.Columns.AddRange((DataGridViewColumn) this.dataGridViewTextBoxColumn14, (DataGridViewColumn) this.dataGridViewTextBoxColumn15);
      componentResourceManager.ApplyResources((object) this.dataGridViewRaces, "dataGridViewRaces");
      this.dataGridViewRaces.Name = "dataGridViewRaces";
      this.dataGridViewRaces.ReadOnly = true;
      this.dataGridViewRaces.RowHeadersVisible = false;
      this.dataGridViewRaces.RowTemplate.Height = 18;
      this.dataGridViewRaces.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridViewRaces.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dataGridViewPigeons_CellFormatting);
      this.dataGridViewTextBoxColumn14.DataPropertyName = "FlightID";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn14, "dataGridViewTextBoxColumn14");
      this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
      this.dataGridViewTextBoxColumn14.ReadOnly = true;
      this.dataGridViewTextBoxColumn15.DataPropertyName = "BasketingMasterTime";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn15, "dataGridViewTextBoxColumn15");
      this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
      this.dataGridViewTextBoxColumn15.ReadOnly = true;
      componentResourceManager.ApplyResources((object) this.label2, "label2");
      this.label2.Name = "label2";
      componentResourceManager.ApplyResources((object) this.label3, "label3");
      this.label3.Name = "label3";
      componentResourceManager.ApplyResources((object) this.label4, "label4");
      this.label4.Name = "label4";
      componentResourceManager.ApplyResources((object) this.labelDesignated, "labelDesignated");
      this.labelDesignated.Name = "labelDesignated";
      componentResourceManager.ApplyResources((object) this.buttonPrint, "buttonPrint");
      this.buttonPrint.Name = "buttonPrint";
      this.buttonPrint.UseVisualStyleBackColor = true;
      this.buttonPrint.Click += new EventHandler(this.buttonPrint_Click);
      componentResourceManager.ApplyResources((object) this.label5, "label5");
      this.label5.Name = "label5";
      componentResourceManager.ApplyResources((object) this.label6, "label6");
      this.label6.Name = "label6";
      this.dataGridViewTextBoxColumn1.DataPropertyName = "Col0";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      this.dataGridViewTextBoxColumn1.ReadOnly = true;
      this.dataGridViewTextBoxColumn2.DataPropertyName = "Col1";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      this.dataGridViewTextBoxColumn2.ReadOnly = true;
      this.dataGridViewTextBoxColumn3.DataPropertyName = "Col2";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
      this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
      this.dataGridViewTextBoxColumn3.ReadOnly = true;
      this.dataGridViewTextBoxColumn4.DataPropertyName = "Col3";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
      this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
      this.dataGridViewTextBoxColumn4.ReadOnly = true;
      this.dataGridViewTextBoxColumn5.DataPropertyName = "Col4";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
      this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
      this.dataGridViewTextBoxColumn5.ReadOnly = true;
      this.dataGridViewTextBoxColumn6.DataPropertyName = "Col5";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn6, "dataGridViewTextBoxColumn6");
      this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
      this.dataGridViewTextBoxColumn6.ReadOnly = true;
      this.dataGridViewTextBoxColumn7.DataPropertyName = "Col6";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
      this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
      this.dataGridViewTextBoxColumn7.ReadOnly = true;
      this.dataGridViewTextBoxColumn8.DataPropertyName = "Col7";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn8, "dataGridViewTextBoxColumn8");
      this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
      this.dataGridViewTextBoxColumn8.ReadOnly = true;
      this.dataGridViewTextBoxColumn9.DataPropertyName = "Col8";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn9, "dataGridViewTextBoxColumn9");
      this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
      this.dataGridViewTextBoxColumn9.ReadOnly = true;
      this.dataGridViewTextBoxColumn10.DataPropertyName = "Col9";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn10, "dataGridViewTextBoxColumn10");
      this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
      this.dataGridViewTextBoxColumn10.ReadOnly = true;
      this.dataGridViewTextBoxColumn11.DataPropertyName = "Col10";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn11, "dataGridViewTextBoxColumn11");
      this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
      this.dataGridViewTextBoxColumn11.ReadOnly = true;
      this.dataGridViewTextBoxColumn12.DataPropertyName = "Col11";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn12, "dataGridViewTextBoxColumn12");
      this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
      this.dataGridViewTextBoxColumn12.ReadOnly = true;
      this.dataGridViewTextBoxColumn13.DataPropertyName = "FedBand";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn13, "dataGridViewTextBoxColumn13");
      this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
      this.dataGridViewTextBoxColumn13.ReadOnly = true;
      this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
      this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
      componentResourceManager.ApplyResources((object) this.labelDesignated2, "labelDesignated2");
      this.labelDesignated2.Name = "labelDesignated2";
      componentResourceManager.ApplyResources((object) this.labelDesignated3, "labelDesignated3");
      this.labelDesignated3.Name = "labelDesignated3";
      componentResourceManager.ApplyResources((object) this.buttonClear, "buttonClear");
      this.buttonClear.Name = "buttonClear";
      this.buttonClear.UseVisualStyleBackColor = true;
      this.buttonClear.Click += new EventHandler(this.buttonClear_Click);
      componentResourceManager.ApplyResources((object) this.labelError, "labelError");
      this.labelError.ForeColor = Color.Red;
      this.labelError.Name = "labelError";
      this.Column1.DataPropertyName = "Col0";
      componentResourceManager.ApplyResources((object) this.Column1, "Column1");
      this.Column1.Name = "Column1";
      this.Column2.DataPropertyName = "Col1";
      componentResourceManager.ApplyResources((object) this.Column2, "Column2");
      this.Column2.Name = "Column2";
      this.Column3.DataPropertyName = "Col2";
      componentResourceManager.ApplyResources((object) this.Column3, "Column3");
      this.Column3.Name = "Column3";
      this.Column4.DataPropertyName = "Col3";
      componentResourceManager.ApplyResources((object) this.Column4, "Column4");
      this.Column4.Name = "Column4";
      this.Column5.DataPropertyName = "Col4";
      componentResourceManager.ApplyResources((object) this.Column5, "Column5");
      this.Column5.Name = "Column5";
      this.Column6.DataPropertyName = "Col5";
      componentResourceManager.ApplyResources((object) this.Column6, "Column6");
      this.Column6.Name = "Column6";
      this.Column7.DataPropertyName = "Col6";
      componentResourceManager.ApplyResources((object) this.Column7, "Column7");
      this.Column7.Name = "Column7";
      this.Column8.DataPropertyName = "Col7";
      componentResourceManager.ApplyResources((object) this.Column8, "Column8");
      this.Column8.Name = "Column8";
      this.Column9.DataPropertyName = "Col8";
      componentResourceManager.ApplyResources((object) this.Column9, "Column9");
      this.Column9.Name = "Column9";
      this.Column10.DataPropertyName = "Col9";
      componentResourceManager.ApplyResources((object) this.Column10, "Column10");
      this.Column10.Name = "Column10";
      this.Column11.DataPropertyName = "Col10";
      componentResourceManager.ApplyResources((object) this.Column11, "Column11");
      this.Column11.Name = "Column11";
      this.Column12.DataPropertyName = "Col11";
      componentResourceManager.ApplyResources((object) this.Column12, "Column12");
      this.Column12.Name = "Column12";
      this.Column13.DataPropertyName = "Col12";
      componentResourceManager.ApplyResources((object) this.Column13, "Column13");
      this.Column13.Name = "Column13";
      this.Column14.DataPropertyName = "Col13";
      componentResourceManager.ApplyResources((object) this.Column14, "Column14");
      this.Column14.Name = "Column14";
      this.Column15.DataPropertyName = "Col14";
      componentResourceManager.ApplyResources((object) this.Column15, "Column15");
      this.Column15.Name = "Column15";
      this.Column16.DataPropertyName = "Col15";
      componentResourceManager.ApplyResources((object) this.Column16, "Column16");
      this.Column16.Name = "Column16";
      this.Column17.DataPropertyName = "Col16";
      componentResourceManager.ApplyResources((object) this.Column17, "Column17");
      this.Column17.Name = "Column17";
      this.Column18.DataPropertyName = "Col17";
      componentResourceManager.ApplyResources((object) this.Column18, "Column18");
      this.Column18.Name = "Column18";
      this.Column19.DataPropertyName = "Col18";
      componentResourceManager.ApplyResources((object) this.Column19, "Column19");
      this.Column19.Name = "Column19";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.Control;
      this.CancelButton = (IButtonControl) this.buttonCancel;
      this.Controls.Add((Control) this.comboBox1);
      this.Controls.Add((Control) this.labelDesignated3);
      this.Controls.Add((Control) this.labelDesignated2);
      this.Controls.Add((Control) this.labelDesignated);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.labelError);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.buttonClear);
      this.Controls.Add((Control) this.buttonPrint);
      this.Controls.Add((Control) this.buttonSend);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.dataGridViewRaces);
      this.Controls.Add((Control) this.dataGridViewPigeons);
      this.Controls.Add((Control) this.dataGridView1);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (BetForm);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Load += new EventHandler(this.BetForm_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((ISupportInitialize) this.dataGridViewPigeons).EndInit();
      ((ISupportInitialize) this.dataGridViewRaces).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private class myComboItem
    {
      public string Text = "";
      public string FlightID = "";
      public byte RaceIndex;

      public override string ToString() => this.Text;
    }
  }
}
