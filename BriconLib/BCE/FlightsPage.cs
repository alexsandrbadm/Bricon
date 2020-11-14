// Decompiled with JetBrains decompiler
// Type: BriconLib.BCE.FlightsPage
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Communications;
using BriconLib.Data;
using BriconLib.Other;
using BriconLib.Properties;
using MultiLang;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BriconLib.BCE
{
  public class FlightsPage : UserControl
  {
    private int MaxFlightCount = 96;
    private int MaxMasterFlightCount = 80;
    private string _previousFlightName = string.Empty;
    private IContainer components;
    private DataGridView dataGridView1;
    private BCEDataSet bceDataSetLocal;
    internal BindingSource bindingSourceFlights;
    private BindingNavigator bindingNavigator1;
    private ToolStripButton bindingNavigatorAddNewItem;
    private ToolStripLabel bindingNavigatorCountItem;
    private ToolStripButton bindingNavigatorDeleteItem;
    private ToolStripButton bindingNavigatorMovePreviousItem;
    private ToolStripSeparator bindingNavigatorSeparator;
    private ToolStripTextBox bindingNavigatorPositionItem;
    private ToolStripSeparator bindingNavigatorSeparator1;
    private ToolStripButton bindingNavigatorMoveNextItem;
    private ToolStripButton bindingNavigatorMoveLastItem;
    private ToolStripSeparator bindingNavigatorSeparator2;
    private ToolStripButton toolStripButtonToMaster;
    private ToolStripButton bindingNavigatorMoveFirstItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton buttonAddDefaultFlights;
    private ToolStripSeparator toolStripSeparator2;
    private ErrorProvider errorProvider1;
    private DataGridViewCheckBoxColumn Selected;
    private DataGridViewTextBoxColumn losplaatsDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn lWXDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn lWYDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn Place;
    private DataGridViewTextBoxColumn Country;
    private DataGridViewTextBoxColumn VolgordeNummer;
    private ToolStripButton toolStripButtonClearSelection;
    private ToolStripButton toolStripButtonToBA;
    private ToolStripSeparator toolStripSeparator3;

    public FlightsPage() => this.InitializeComponent();

    private void toolStripButtonToMaster_Click(object sender, EventArgs e)
    {
      this.dataGridView1.EndEdit();
      this.bindingSourceFlights.EndEdit();
      if (!this.ValidateAllFlights())
      {
        int num1 = (int) MessageBox.Show(ml.ml_string(284, "Some fields are incorrect, please check for errors."));
      }
      else
      {
        DataRow[] dataRowArray = BCEDatabase.DataSet.Lossingsplaats.Select("Selected = TRUE", "VolgordeNummer");
        if (dataRowArray.Length > this.MaxMasterFlightCount)
        {
          int num2 = (int) MessageBox.Show(string.Format(ml.ml_string(336, "Maximum {0} races are allowed"), (object) this.MaxMasterFlightCount));
        }
        else
        {
          byte num3 = 0;
          foreach (BCEDataSet.LossingsplaatsRow lossingsplaatsRow in dataRowArray)
          {
            if ((int) num3 < this.MaxMasterFlightCount)
              CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new SendFlightCommand(num3++, lossingsplaatsRow.IsLosplaatsNull() ? string.Empty : Conversion.FromUnicode(lossingsplaatsRow.Losplaats), lossingsplaatsRow.IsCodeNull() ? string.Empty : Conversion.FromUnicode(lossingsplaatsRow.Code)));
          }
        }
      }
    }

    private void buttonAddDefaultFlights_Click(object sender, EventArgs e)
    {
      this.dataGridView1.EndEdit();
      this.bindingSourceFlights.EndEdit();
      if (Utils.IsCountry("BE"))
      {
        this.bindingSourceFlights.SuspendBinding();
        switch (MessageBox.Show(ml.ml_string(245, "Do you want to clear the current race calendar before adding the default calendar?"), Defines.MessageBoxCaption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3))
        {
          case DialogResult.Cancel:
            this.bindingSourceFlights.ResumeBinding();
            return;
          case DialogResult.Yes:
            FlightCalenderBelgium.AddFlights(true);
            break;
          case DialogResult.No:
            FlightCalenderBelgium.AddFlights(false);
            break;
        }
        this.bindingSourceFlights.ResetBindings(false);
        this.bindingSourceFlights.ResumeBinding();
      }
      else if (Utils.IsCountry("UK"))
      {
        this.bindingSourceFlights.SuspendBinding();
        switch (MessageBox.Show(ml.ml_string(245, "Do you want to clear the current race calendar before adding the default calendar?"), Defines.MessageBoxCaption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3))
        {
          case DialogResult.Cancel:
            this.bindingSourceFlights.ResumeBinding();
            return;
          case DialogResult.Yes:
            FlightCalenderUK.AddFlights(true);
            break;
          case DialogResult.No:
            FlightCalenderUK.AddFlights(false);
            break;
        }
        this.bindingSourceFlights.ResetBindings(false);
        this.bindingSourceFlights.ResumeBinding();
      }
      else if (Utils.IsCountry("HU"))
      {
        this.bindingSourceFlights.SuspendBinding();
        switch (MessageBox.Show(ml.ml_string(245, "Do you want to clear the current race calendar before adding the default calendar?"), Defines.MessageBoxCaption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3))
        {
          case DialogResult.Cancel:
            this.bindingSourceFlights.ResumeBinding();
            return;
          case DialogResult.Yes:
            FlightCalenderHU.AddFlights(true);
            break;
          case DialogResult.No:
            FlightCalenderHU.AddFlights(false);
            break;
        }
        this.bindingSourceFlights.ResetBindings(false);
        this.bindingSourceFlights.ResumeBinding();
      }
      else
      {
        int num = (int) MessageBox.Show(ml.ml_string(247, "Not supported for this country"));
      }
    }

    private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
    {
      this.dataGridView1.CurrentCell = this.dataGridView1.CurrentRow.Cells["losplaatsDataGridViewTextBoxColumn"];
      this.dataGridView1.BeginEdit(true);
    }

    private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1)
        return;
      if (e.ColumnIndex == this.losplaatsDataGridViewTextBoxColumn.Index)
      {
        BCEDataSet.LossingsplaatsRow row = ((DataRowView) this.bindingSourceFlights.Current).Row as BCEDataSet.LossingsplaatsRow;
        if (row.Losplaats != this._previousFlightName)
        {
          row.Losplaats = row.Losplaats.ToUpper();
          row.Code = row.Losplaats.Replace("'", "").PadRight(4).Substring(0, 4);
        }
      }
      if (e.ColumnIndex == this.losplaatsDataGridViewTextBoxColumn.Index || e.ColumnIndex == this.Selected.Index || e.ColumnIndex == this.codeDataGridViewTextBoxColumn.Index)
        this.ValidateAllFlights();
      this.Invalidate();
    }

    private bool ValidateAllFlights()
    {
      bool flag = false;
      foreach (BCEDataSet.LossingsplaatsRow error in BCEDatabase.DataSet.Lossingsplaats.GetErrors())
      {
        if (error.RowState != DataRowState.Deleted)
          error.RowError = string.Empty;
      }
      int num = 0;
      foreach (BCEDataSet.LossingsplaatsRow lossingsplaat in (TypedTableBase<BCEDataSet.LossingsplaatsRow>) BCEDatabase.DataSet.Lossingsplaats)
      {
        if (lossingsplaat.RowState != DataRowState.Deleted && lossingsplaat.RowState != DataRowState.Detached)
        {
          if (lossingsplaat.Selected && num++ > this.MaxFlightCount)
          {
            lossingsplaat.RowError = string.Format(ml.ml_string(336, "Maximum {0} races are allowed"), (object) this.MaxFlightCount);
            flag = true;
          }
          if (lossingsplaat.Code.Contains("'"))
          {
            lossingsplaat.RowError = ml.ml_string(658, "Race code may not contain a ' ");
            return false;
          }
          if (lossingsplaat.Code.Length != 4)
          {
            lossingsplaat.RowError = ml.ml_string(337, "Race code must be 4 characters long");
            flag = true;
          }
          if (lossingsplaat.Losplaats.Trim().Length == 0)
          {
            lossingsplaat.RowError = ml.ml_string(338, "Race name must be filled in");
            flag = true;
          }
          DataRow[] dataRowArray = BCEDatabase.DataSet.Lossingsplaats.Select("Selected = 1 and CODE = '" + lossingsplaat.Code + "'");
          if (dataRowArray.Length > 1)
          {
            foreach (DataRow dataRow in dataRowArray)
            {
              dataRow.RowError = ml.ml_string(339, "Duplicate Race code in selected records");
              flag = true;
            }
          }
        }
      }
      return !flag;
    }

    private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
      try
      {
        if (e.RowIndex == -1 || e.ColumnIndex != this.losplaatsDataGridViewTextBoxColumn.Index)
          return;
        this._previousFlightName = (((DataRowView) this.bindingSourceFlights.Current).Row as BCEDataSet.LossingsplaatsRow).Losplaats;
      }
      catch (Exception ex)
      {
        this._previousFlightName = "";
      }
    }

    private void bindingSourceFlights_PositionChanged(object sender, EventArgs e) => this.ValidateAllFlights();

    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex == this.Selected.Index && this.bindingSourceFlights.Current != null)
      {
        int num = 0;
        BCEDataSet.LossingsplaatsRow row = ((DataRowView) this.bindingSourceFlights.Current).Row as BCEDataSet.LossingsplaatsRow;
        if (row.Selected)
        {
          foreach (BCEDataSet.LossingsplaatsRow lossingsplaat in (TypedTableBase<BCEDataSet.LossingsplaatsRow>) BCEDatabase.DataSet.Lossingsplaats)
          {
            if (!lossingsplaat.IsVolgordeNummerNull() && lossingsplaat.VolgordeNummer > num)
              num = lossingsplaat.VolgordeNummer;
          }
          if (row.IsVolgordeNummerNull() || row.VolgordeNummer < num)
            row.VolgordeNummer = num + 1;
        }
      }
      this.dataGridView1.Invalidate();
    }

    private void toolStripButtonClearSelection_Click(object sender, EventArgs e)
    {
      foreach (BCEDataSet.LossingsplaatsRow lossingsplaat in (TypedTableBase<BCEDataSet.LossingsplaatsRow>) BCEDatabase.DataSet.Lossingsplaats)
      {
        lossingsplaat.Selected = false;
        lossingsplaat.SetVolgordeNummerNull();
      }
    }

    public void TabPageActivated()
    {
      this.toolStripButtonToBA.Visible = !Utils.IsCountry("BE");
      this.buttonAddDefaultFlights.Visible = Utils.IsCountry("UK") || Utils.IsCountry("HU");
      if (!Utils.IsCountry("BE"))
        return;
      this.bindingNavigatorAddNewItem.Visible = false;
      this.bindingNavigatorDeleteItem.Visible = false;
      this.codeDataGridViewTextBoxColumn.ReadOnly = true;
      this.losplaatsDataGridViewTextBoxColumn.ReadOnly = true;
    }

    private void toolStripButtonToBA_Click(object sender, EventArgs e)
    {
      this.dataGridView1.EndEdit();
      this.bindingSourceFlights.EndEdit();
      if (!this.ValidateAllFlights())
      {
        int num1 = (int) MessageBox.Show(ml.ml_string(284, "Some fields are incorrect, please check for errors."));
      }
      else if (!CommunicationState.Instance.BAFound)
      {
        int num2 = (int) MessageBox.Show(ml.ml_string(523, "Please connect ETS first"));
      }
      else if (!CommunicationState.Instance.IsSpeedyXtreme && !CommunicationState.Instance.IsExtreme && (CommunicationState.Instance.IsSpeedy || Utils.IsCountry("UK") || (Utils.IsCountry("IR") || Utils.IsCountry("JP"))))
      {
        string empty = string.Empty;
        foreach (BCEDataSet.LossingsplaatsRow lossingsplaatsRow in BCEDatabase.DataSet.Lossingsplaats.Select("Selected = TRUE", "VolgordeNummer"))
        {
          if (!lossingsplaatsRow.IsCodeNull())
            empty += lossingsplaatsRow.Code;
        }
        CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new SendFlightNamesCommand(Conversion.FromUnicode(empty)));
      }
      else
      {
        byte num3 = 0;
        CommunicationPool instance = CommunicationPool.Instance;
        int num4 = (int) num3;
        byte num5 = (byte) (num4 + 1);
        SendFlightNamesCommand flightNamesCommand = new SendFlightNamesCommand("", (byte) num4);
        instance.PostCommand((BriconLib.Communications.Command) flightNamesCommand);
        foreach (BCEDataSet.LossingsplaatsRow lossingsplaatsRow in BCEDatabase.DataSet.Lossingsplaats.Select("Selected = TRUE", "VolgordeNummer"))
        {
          if (!lossingsplaatsRow.IsLosplaatsNull() && num5 <= (byte) 96)
            CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new SendFlightNamesCommand(Conversion.FromUnicode(lossingsplaatsRow.Losplaats), num5++));
        }
      }
    }

    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
    }

    private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FlightsPage));
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      this.dataGridView1 = new DataGridView();
      this.Selected = new DataGridViewCheckBoxColumn();
      this.losplaatsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.lWXDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.lWYDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.Place = new DataGridViewTextBoxColumn();
      this.Country = new DataGridViewTextBoxColumn();
      this.VolgordeNummer = new DataGridViewTextBoxColumn();
      this.bindingSourceFlights = new BindingSource(this.components);
      this.bceDataSetLocal = new BCEDataSet();
      this.bindingNavigator1 = new BindingNavigator(this.components);
      this.bindingNavigatorAddNewItem = new ToolStripButton();
      this.bindingNavigatorCountItem = new ToolStripLabel();
      this.bindingNavigatorDeleteItem = new ToolStripButton();
      this.bindingNavigatorMoveFirstItem = new ToolStripButton();
      this.bindingNavigatorMovePreviousItem = new ToolStripButton();
      this.bindingNavigatorSeparator = new ToolStripSeparator();
      this.bindingNavigatorPositionItem = new ToolStripTextBox();
      this.bindingNavigatorSeparator1 = new ToolStripSeparator();
      this.bindingNavigatorMoveNextItem = new ToolStripButton();
      this.bindingNavigatorMoveLastItem = new ToolStripButton();
      this.bindingNavigatorSeparator2 = new ToolStripSeparator();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolStripButtonToMaster = new ToolStripButton();
      this.toolStripButtonClearSelection = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.buttonAddDefaultFlights = new ToolStripButton();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.toolStripButtonToBA = new ToolStripButton();
      this.errorProvider1 = new ErrorProvider(this.components);
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((ISupportInitialize) this.bindingSourceFlights).BeginInit();
      this.bceDataSetLocal.BeginInit();
      this.bindingNavigator1.BeginInit();
      this.bindingNavigator1.SuspendLayout();
      ((ISupportInitialize) this.errorProvider1).BeginInit();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToOrderColumns = true;
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.Selected, (DataGridViewColumn) this.losplaatsDataGridViewTextBoxColumn, (DataGridViewColumn) this.codeDataGridViewTextBoxColumn, (DataGridViewColumn) this.lWXDataGridViewTextBoxColumn, (DataGridViewColumn) this.lWYDataGridViewTextBoxColumn, (DataGridViewColumn) this.Place, (DataGridViewColumn) this.Country, (DataGridViewColumn) this.VolgordeNummer);
      this.dataGridView1.DataSource = (object) this.bindingSourceFlights;
      componentResourceManager.ApplyResources((object) this.dataGridView1, "dataGridView1");
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
      this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
      this.dataGridView1.CellEnter += new DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
      this.dataGridView1.CellValidated += new DataGridViewCellEventHandler(this.dataGridView1_CellValidated);
      this.dataGridView1.CellValidating += new DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
      this.dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
      this.Selected.DataPropertyName = "Selected";
      componentResourceManager.ApplyResources((object) this.Selected, "Selected");
      this.Selected.Name = "Selected";
      this.Selected.SortMode = DataGridViewColumnSortMode.Automatic;
      this.losplaatsDataGridViewTextBoxColumn.DataPropertyName = "Losplaats";
      componentResourceManager.ApplyResources((object) this.losplaatsDataGridViewTextBoxColumn, "losplaatsDataGridViewTextBoxColumn");
      this.losplaatsDataGridViewTextBoxColumn.Name = "losplaatsDataGridViewTextBoxColumn";
      this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
      componentResourceManager.ApplyResources((object) this.codeDataGridViewTextBoxColumn, "codeDataGridViewTextBoxColumn");
      this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
      this.lWXDataGridViewTextBoxColumn.DataPropertyName = "LWX";
      gridViewCellStyle1.Format = "00:00:00','0";
      gridViewCellStyle1.NullValue = (object) "00:00:00,0";
      this.lWXDataGridViewTextBoxColumn.DefaultCellStyle = gridViewCellStyle1;
      componentResourceManager.ApplyResources((object) this.lWXDataGridViewTextBoxColumn, "lWXDataGridViewTextBoxColumn");
      this.lWXDataGridViewTextBoxColumn.Name = "lWXDataGridViewTextBoxColumn";
      this.lWYDataGridViewTextBoxColumn.DataPropertyName = "LWY";
      gridViewCellStyle2.Format = "00:00:00','0";
      gridViewCellStyle2.NullValue = (object) "00:00:00,0";
      this.lWYDataGridViewTextBoxColumn.DefaultCellStyle = gridViewCellStyle2;
      componentResourceManager.ApplyResources((object) this.lWYDataGridViewTextBoxColumn, "lWYDataGridViewTextBoxColumn");
      this.lWYDataGridViewTextBoxColumn.Name = "lWYDataGridViewTextBoxColumn";
      this.Place.DataPropertyName = "Place";
      componentResourceManager.ApplyResources((object) this.Place, "Place");
      this.Place.Name = "Place";
      this.Country.DataPropertyName = "Country";
      componentResourceManager.ApplyResources((object) this.Country, "Country");
      this.Country.Name = "Country";
      this.VolgordeNummer.DataPropertyName = "VolgordeNummer";
      componentResourceManager.ApplyResources((object) this.VolgordeNummer, "VolgordeNummer");
      this.VolgordeNummer.Name = "VolgordeNummer";
      this.bindingSourceFlights.DataMember = "Lossingsplaats";
      this.bindingSourceFlights.DataSource = (object) this.bceDataSetLocal;
      this.bindingSourceFlights.PositionChanged += new EventHandler(this.bindingSourceFlights_PositionChanged);
      this.bceDataSetLocal.DataSetName = "BCEDataSet";
      this.bceDataSetLocal.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.bindingNavigator1.AddNewItem = (ToolStripItem) this.bindingNavigatorAddNewItem;
      this.bindingNavigator1.BindingSource = this.bindingSourceFlights;
      this.bindingNavigator1.CountItem = (ToolStripItem) this.bindingNavigatorCountItem;
      this.bindingNavigator1.DeleteItem = (ToolStripItem) this.bindingNavigatorDeleteItem;
      this.bindingNavigator1.Items.AddRange(new ToolStripItem[18]
      {
        (ToolStripItem) this.bindingNavigatorMoveFirstItem,
        (ToolStripItem) this.bindingNavigatorMovePreviousItem,
        (ToolStripItem) this.bindingNavigatorSeparator,
        (ToolStripItem) this.bindingNavigatorPositionItem,
        (ToolStripItem) this.bindingNavigatorCountItem,
        (ToolStripItem) this.bindingNavigatorSeparator1,
        (ToolStripItem) this.bindingNavigatorMoveNextItem,
        (ToolStripItem) this.bindingNavigatorMoveLastItem,
        (ToolStripItem) this.bindingNavigatorSeparator2,
        (ToolStripItem) this.bindingNavigatorAddNewItem,
        (ToolStripItem) this.bindingNavigatorDeleteItem,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.toolStripButtonToMaster,
        (ToolStripItem) this.toolStripButtonClearSelection,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.buttonAddDefaultFlights,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.toolStripButtonToBA
      });
      componentResourceManager.ApplyResources((object) this.bindingNavigator1, "bindingNavigator1");
      this.bindingNavigator1.MoveFirstItem = (ToolStripItem) this.bindingNavigatorMoveFirstItem;
      this.bindingNavigator1.MoveLastItem = (ToolStripItem) this.bindingNavigatorMoveLastItem;
      this.bindingNavigator1.MoveNextItem = (ToolStripItem) this.bindingNavigatorMoveNextItem;
      this.bindingNavigator1.MovePreviousItem = (ToolStripItem) this.bindingNavigatorMovePreviousItem;
      this.bindingNavigator1.Name = "bindingNavigator1";
      this.bindingNavigator1.PositionItem = (ToolStripItem) this.bindingNavigatorPositionItem;
      this.bindingNavigatorAddNewItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      componentResourceManager.ApplyResources((object) this.bindingNavigatorAddNewItem, "bindingNavigatorAddNewItem");
      this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
      this.bindingNavigatorAddNewItem.Click += new EventHandler(this.bindingNavigatorAddNewItem_Click);
      this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
      componentResourceManager.ApplyResources((object) this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
      this.bindingNavigatorDeleteItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      componentResourceManager.ApplyResources((object) this.bindingNavigatorDeleteItem, "bindingNavigatorDeleteItem");
      this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
      this.bindingNavigatorMoveFirstItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      componentResourceManager.ApplyResources((object) this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
      this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
      this.bindingNavigatorMovePreviousItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      componentResourceManager.ApplyResources((object) this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
      this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
      this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
      componentResourceManager.ApplyResources((object) this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
      componentResourceManager.ApplyResources((object) this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
      this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
      this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
      componentResourceManager.ApplyResources((object) this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
      this.bindingNavigatorMoveNextItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      componentResourceManager.ApplyResources((object) this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
      this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
      this.bindingNavigatorMoveLastItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      componentResourceManager.ApplyResources((object) this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
      this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
      this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
      componentResourceManager.ApplyResources((object) this.bindingNavigatorSeparator2, "bindingNavigatorSeparator2");
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator1, "toolStripSeparator1");
      this.toolStripButtonToMaster.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonToMaster.Image = (Image) Resources.ToMaster;
      componentResourceManager.ApplyResources((object) this.toolStripButtonToMaster, "toolStripButtonToMaster");
      this.toolStripButtonToMaster.Name = "toolStripButtonToMaster";
      this.toolStripButtonToMaster.Click += new EventHandler(this.toolStripButtonToMaster_Click);
      this.toolStripButtonClearSelection.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonClearSelection.Image = (Image) Resources.ClearSelection;
      componentResourceManager.ApplyResources((object) this.toolStripButtonClearSelection, "toolStripButtonClearSelection");
      this.toolStripButtonClearSelection.Name = "toolStripButtonClearSelection";
      this.toolStripButtonClearSelection.Click += new EventHandler(this.toolStripButtonClearSelection_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator2, "toolStripSeparator2");
      this.buttonAddDefaultFlights.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonAddDefaultFlights.Image = (Image) Resources.DefaultFlights;
      componentResourceManager.ApplyResources((object) this.buttonAddDefaultFlights, "buttonAddDefaultFlights");
      this.buttonAddDefaultFlights.Name = "buttonAddDefaultFlights";
      this.buttonAddDefaultFlights.Click += new EventHandler(this.buttonAddDefaultFlights_Click);
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator3, "toolStripSeparator3");
      this.toolStripButtonToBA.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonToBA.Image = (Image) Resources.ToBA;
      componentResourceManager.ApplyResources((object) this.toolStripButtonToBA, "toolStripButtonToBA");
      this.toolStripButtonToBA.Name = "toolStripButtonToBA";
      this.toolStripButtonToBA.Click += new EventHandler(this.toolStripButtonToBA_Click);
      this.errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
      this.errorProvider1.ContainerControl = (ContainerControl) this;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.bindingNavigator1);
      this.Name = nameof (FlightsPage);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((ISupportInitialize) this.bindingSourceFlights).EndInit();
      this.bceDataSetLocal.EndInit();
      this.bindingNavigator1.EndInit();
      this.bindingNavigator1.ResumeLayout(false);
      this.bindingNavigator1.PerformLayout();
      ((ISupportInitialize) this.errorProvider1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
