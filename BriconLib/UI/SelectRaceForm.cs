// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.SelectRaceForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PrintManager;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace BriconLib.UI
{
  public class SelectRaceForm : Form
  {
    private ReadOutDataSet.TimersRow _activeRow;
    private IContainer components;
    private DataGridView dataGridView1;
    private BindingSource timersBindingSource;
    private ReadOutDataSet readOutDataSet;
    private Button buttonSelect;
    private Button buttonCancel;
    private Label label1;
    private DataGridViewTextBoxColumn clubIDDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn flightIDDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn basketingMasterTimeDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn readOutMasterTimeDataGridViewTextBoxColumn;

    public SelectRaceForm(ReadOutDataSet dataSet)
    {
      this.InitializeComponent();
      this.timersBindingSource.DataSource = (object) dataSet;
      this._activeRow = dataSet.Timers[0];
    }

    public ReadOutDataSet.TimersRow ActiveRow => this._activeRow;

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void buttonSelect_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void dataGridView1_SelectionChanged(object sender, EventArgs e) => this._activeRow = ((DataRowView) this.timersBindingSource.Current).Row as ReadOutDataSet.TimersRow;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (SelectRaceForm));
      this.dataGridView1 = new DataGridView();
      this.clubIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.flightIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.basketingMasterTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.readOutMasterTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.timersBindingSource = new BindingSource(this.components);
      this.readOutDataSet = new ReadOutDataSet();
      this.buttonSelect = new Button();
      this.buttonCancel = new Button();
      this.label1 = new Label();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((ISupportInitialize) this.timersBindingSource).BeginInit();
      this.readOutDataSet.BeginInit();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AllowUserToOrderColumns = true;
      this.dataGridView1.AllowUserToResizeRows = false;
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.clubIDDataGridViewTextBoxColumn, (DataGridViewColumn) this.flightIDDataGridViewTextBoxColumn, (DataGridViewColumn) this.basketingMasterTimeDataGridViewTextBoxColumn, (DataGridViewColumn) this.readOutMasterTimeDataGridViewTextBoxColumn);
      this.dataGridView1.DataSource = (object) this.timersBindingSource;
      componentResourceManager.ApplyResources((object) this.dataGridView1, "dataGridView1");
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.SelectionChanged += new EventHandler(this.dataGridView1_SelectionChanged);
      this.clubIDDataGridViewTextBoxColumn.DataPropertyName = "ClubID";
      componentResourceManager.ApplyResources((object) this.clubIDDataGridViewTextBoxColumn, "clubIDDataGridViewTextBoxColumn");
      this.clubIDDataGridViewTextBoxColumn.Name = "clubIDDataGridViewTextBoxColumn";
      this.flightIDDataGridViewTextBoxColumn.DataPropertyName = "FlightID";
      componentResourceManager.ApplyResources((object) this.flightIDDataGridViewTextBoxColumn, "flightIDDataGridViewTextBoxColumn");
      this.flightIDDataGridViewTextBoxColumn.Name = "flightIDDataGridViewTextBoxColumn";
      this.basketingMasterTimeDataGridViewTextBoxColumn.DataPropertyName = "BasketingMasterTime";
      componentResourceManager.ApplyResources((object) this.basketingMasterTimeDataGridViewTextBoxColumn, "basketingMasterTimeDataGridViewTextBoxColumn");
      this.basketingMasterTimeDataGridViewTextBoxColumn.Name = "basketingMasterTimeDataGridViewTextBoxColumn";
      this.readOutMasterTimeDataGridViewTextBoxColumn.DataPropertyName = "ReadOutMasterTime";
      componentResourceManager.ApplyResources((object) this.readOutMasterTimeDataGridViewTextBoxColumn, "readOutMasterTimeDataGridViewTextBoxColumn");
      this.readOutMasterTimeDataGridViewTextBoxColumn.Name = "readOutMasterTimeDataGridViewTextBoxColumn";
      this.timersBindingSource.DataMember = "Timers";
      this.timersBindingSource.DataSource = (object) this.readOutDataSet;
      this.readOutDataSet.DataSetName = "ReadOutDataSet";
      this.readOutDataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      componentResourceManager.ApplyResources((object) this.buttonSelect, "buttonSelect");
      this.buttonSelect.Name = "buttonSelect";
      this.buttonSelect.UseVisualStyleBackColor = true;
      this.buttonSelect.Click += new EventHandler(this.buttonSelect_Click);
      componentResourceManager.ApplyResources((object) this.buttonCancel, "buttonCancel");
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      this.AcceptButton = (IButtonControl) this.buttonSelect;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonCancel;
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonSelect);
      this.Controls.Add((Control) this.dataGridView1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (SelectRaceForm);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((ISupportInitialize) this.timersBindingSource).EndInit();
      this.readOutDataSet.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
