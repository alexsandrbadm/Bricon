// Decompiled with JetBrains decompiler
// Type: BriconLib.BCE.FanciersPage
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.BriconWeb;
using BriconLib.Communications;
using BriconLib.Data;
using BriconLib.Other;
using BriconLib.Printing;
using BriconLib.Properties;
using BriconLib.UI;
using MultiLang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BriconLib.BCE
{
  public class FanciersPage : UserControl
  {
    private string _headerX;
    private string _headerY;
    private string _fieldX;
    private string _fieldY;
    private IContainer components;
    private DataGridView dataGridView1;
    private BindingNavigator bindingNavigatorAdressen;
    private ToolStripButton bindingNavigatorAddNewItem;
    private ToolStripLabel bindingNavigatorCountItem;
    private ToolStripButton bindingNavigatorDeleteItem;
    private ToolStripButton bindingNavigatorMoveFirstItem;
    private ToolStripButton bindingNavigatorMovePreviousItem;
    private ToolStripSeparator bindingNavigatorSeparator;
    private ToolStripTextBox bindingNavigatorPositionItem;
    private ToolStripSeparator bindingNavigatorSeparator1;
    private ToolStripButton bindingNavigatorMoveNextItem;
    private ToolStripButton bindingNavigatorMoveLastItem;
    private ToolStripSeparator bindingNavigatorSeparator2;
    private BCEDataSet bceDataSetLocal;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton toolStripButtonFromBA;
    private ToolStripButton toolStripButtonAutoLoad;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripButton toolStripButton1;
    private ToolStripButton toolStripButtonSendmultiple;
    private ToolStripButton toolStripButtonReadFlightData;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripButton toolStripButtonMergeFanciers;
    private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn licentieDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn naamDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn adresDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn postcodeDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn gemeenteDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn telefoonDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn faxDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn bankrekeningDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn Club1;
    private DataGridViewTextBoxColumn Club2;
    private DataGridViewTextBoxColumn kWXDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn kWYDataGridViewTextBoxColumn;
    private ToolStripButton toolStripButtonSendToBW;
    private ToolStripButton toolStripButtonImportDistances;

    public FanciersPage()
    {
      this.InitializeComponent();
      Settings.Default.SettingChanging += new SettingChangingEventHandler(this.Default_SettingChanging);
      if (Utils.IsCountry("BE"))
      {
        this.kWXDataGridViewTextBoxColumn.DefaultCellStyle.Format = "00:00:00','0";
        this.kWYDataGridViewTextBoxColumn.DefaultCellStyle.Format = "00:00:00','0";
        this.kWXDataGridViewTextBoxColumn.DefaultCellStyle.NullValue = (object) "00:00:00,0";
        this.kWYDataGridViewTextBoxColumn.DefaultCellStyle.NullValue = (object) "00:00:00,0";
      }
      this._headerX = this.kWXDataGridViewTextBoxColumn.HeaderText;
      this._headerY = this.kWYDataGridViewTextBoxColumn.HeaderText;
      this._fieldX = this.kWXDataGridViewTextBoxColumn.DataPropertyName;
      this._fieldY = this.kWYDataGridViewTextBoxColumn.DataPropertyName;
    }

    public void SetDataSource(BindingSource bindingSourceAdressen)
    {
      this.bindingNavigatorAdressen.BindingSource = bindingSourceAdressen;
      this.dataGridView1.DataMember = "";
      this.dataGridView1.DataSource = (object) bindingSourceAdressen;
    }

    private FancierPage GetFancierPage()
    {
      Control parent = this.Parent;
      while (true)
      {
        switch (parent)
        {
          case MainForm _:
          case null:
            goto label_3;
          default:
            parent = parent.Parent;
            continue;
        }
      }
label_3:
      return parent is MainForm ? (parent as MainForm).fancierPage : (FancierPage) null;
    }

    private void toolStripButtonFromBA_Click(object sender, EventArgs e)
    {
      CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new GetFancierCommand());
      CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new GetBandTableCommand());
    }

    private void toolStripButtonAutoLoad_Click(object sender, EventArgs e)
    {
      Settings.Default.AutoLoad = (sender as ToolStripButton).Checked;
      if (!Settings.Default.AutoLoad)
        return;
      CommunicationState.Instance.PreviousBAVersion = string.Empty;
      CommunicationState.Instance.WaitingToConnectBA = true;
    }

    private void Default_SettingChanging(object sender, SettingChangingEventArgs e)
    {
      if (!(e.SettingName == "AutoLoad"))
        return;
      this.toolStripButtonAutoLoad.Checked = (bool) e.NewValue;
    }

    private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
    {
      this.dataGridView1.EndEdit();
      if (this.bindingNavigatorAdressen.BindingSource.Current == null)
        return;
      BCEDataSet.AdressenRow row = ((DataRowView) this.bindingNavigatorAdressen.BindingSource.Current).Row as BCEDataSet.AdressenRow;
      this.GetFancierPage().DeleteCurrentFancier(row);
    }

    private void dataGridView1_DoubleClick(object sender, EventArgs e)
    {
      Control parent = this.Parent;
      while (true)
      {
        switch (parent)
        {
          case TabControl _:
          case null:
            goto label_3;
          default:
            parent = parent.Parent;
            continue;
        }
      }
label_3:
      if (!(parent is TabControl))
        return;
      ++(parent as TabControl).SelectedIndex;
    }

    private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
    {
      this.dataGridView1.CurrentCell = this.dataGridView1.CurrentRow.Cells["licentieDataGridViewTextBoxColumn"];
      this.dataGridView1.BeginEdit(true);
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      this.dataGridView1.EndEdit();
      if (this.bindingNavigatorAdressen.BindingSource.Current == null)
        return;
      PrintHelper.PrintFancierDetail((((DataRowView) this.bindingNavigatorAdressen.BindingSource.Current).Row as BCEDataSet.AdressenRow).Id);
    }

    public void TabPageActivated()
    {
      this.toolStripButtonSendmultiple.Visible = Utils.IsUKProtocol();
      this.adresDataGridViewTextBoxColumn.Visible = !Utils.IsCountry("JP");
      this.postcodeDataGridViewTextBoxColumn.Visible = !Utils.IsCountry("JP");
      this.gemeenteDataGridViewTextBoxColumn.Visible = !Utils.IsCountry("JP");
      this.telefoonDataGridViewTextBoxColumn.Visible = !Utils.IsCountry("JP");
      this.faxDataGridViewTextBoxColumn.Visible = !Utils.IsCountry("JP");
      this.emailDataGridViewTextBoxColumn.Visible = !Utils.IsCountry("JP");
      this.kWXDataGridViewTextBoxColumn.Visible = !Utils.IsCountry("JP");
      this.kWYDataGridViewTextBoxColumn.Visible = !Utils.IsCountry("JP");
      this.toolStripButtonImportDistances.Visible = Utils.IsCountry("UK");
      this.Club1.Visible = Utils.IsCountry("JP");
      this.Club2.Visible = Utils.IsCountry("JP");
      if (!Utils.IsCountry("UK"))
        this.toolStripButtonSendToBW.Visible = false;
      else
        this.toolStripButtonSendToBW.Visible = true;
      if (Utils.IsCountry("JP"))
      {
        this.kWXDataGridViewTextBoxColumn.DataPropertyName = this._fieldY;
        this.kWYDataGridViewTextBoxColumn.DataPropertyName = this._fieldX;
        this.kWXDataGridViewTextBoxColumn.HeaderText = this._headerY;
        this.kWYDataGridViewTextBoxColumn.HeaderText = this._headerX;
      }
      else
      {
        this.kWXDataGridViewTextBoxColumn.DataPropertyName = this._fieldX;
        this.kWYDataGridViewTextBoxColumn.DataPropertyName = this._fieldY;
        this.kWXDataGridViewTextBoxColumn.HeaderText = this._headerX;
        this.kWYDataGridViewTextBoxColumn.HeaderText = this._headerY;
      }
    }

    private void toolStripButtonSendmultiple_Click(object sender, EventArgs e)
    {
      List<int> ids = new List<int>();
      if (new SendMultipleForm(ids).ShowDialog() != DialogResult.OK)
        return;
      if (new SendMultipleForm(ids).ShowDialog() == DialogResult.OK)
      {
        int num = (int) new SendMultipleForm(ids).ShowDialog();
      }
      if (MessageBox.Show(string.Format(ml.ml_string(407, "Do you want to send {0} fanciers?"), (object) ids.Count), ml.ml_string(390, "Send Multiple Fanciers"), MessageBoxButtons.OKCancel) != DialogResult.OK)
        return;
      for (byte index = 0; (int) index < ids.Count; ++index)
      {
        SendFancierCommand.fancierPos = index;
        DataRow[] dataRowArray = BCEDatabase.DataSet.Adressen.Select("id = " + ids[(int) index].ToString());
        if (dataRowArray.Length == 1)
          this.GetFancierPage().SendFancierAndRingsToBA(dataRowArray[0] as BCEDataSet.AdressenRow);
      }
      SendFancierCommand.fancierPos = (byte) 0;
    }

    private void toolStripButtonReadFlightData_Click(object sender, EventArgs e)
    {
      MainForm.Instance.communicationsPanel.IgnoreErrors = true;
      int num = (int) new FlightReadoutForm().ShowDialog();
      MainForm.Instance.communicationsPanel.buttonClearBA_Click(sender, e);
      MainForm.Instance.communicationsPanel.IgnoreErrors = false;
    }

    private void toolStripButtonMergeFanciers_Click(object sender, EventArgs e)
    {
      this.dataGridView1.EndEdit();
      if (this.bindingNavigatorAdressen.BindingSource.Current == null)
        return;
      BCEDataSet.AdressenRow row = ((DataRowView) this.bindingNavigatorAdressen.BindingSource.Current).Row as BCEDataSet.AdressenRow;
      int num = (int) new MergeFanciersForm(row.Id, row.Naam).ShowDialog();
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void toolStripButtonSendToBW_Click(object sender, EventArgs e)
    {
      BCEDataSet.ClubsRow activeClubRow = MainForm.Instance.clubsPage.GetActiveClubRow();
      foreach (BCEDataSet.AdressenRow adressenRow in activeClubRow.GetAdressenRows())
      {
        if (!MainForm.Instance.fancierPage.ValidateAllData(true, adressenRow, false))
        {
          this.bindingNavigatorAdressen.BindingSource.MoveFirst();
          while (((DataRowView) this.bindingNavigatorAdressen.BindingSource.Current).Row != adressenRow)
            this.bindingNavigatorAdressen.BindingSource.MoveNext();
          MainForm.Instance.fancierPage.ValidateAllData(true, adressenRow, false);
          int num = (int) MessageBox.Show(ml.ml_string(284, "Some fields are incorrect, please check for errors."));
          return;
        }
      }
      if (MessageBox.Show(ml.ml_string(1233, "Are you sure you want to add or update the club '") + activeClubRow.ClubID + ml.ml_string(1232, "' and add or update all its ") + activeClubRow.GetAdressenRows().Length.ToString() + ml.ml_string(1231, " fanciers?"), ml.ml_string(1230, "Send to BriconWeb"), MessageBoxButtons.OKCancel) != DialogResult.OK)
        return;
      string str = BriconWebHelper.SendBCEData(MainForm.Instance.clubsPage.GetActiveClubRow());
      int num1 = (int) MessageBox.Show(ml.ml_string(1229, "Response from Briconweb: ") + str);
    }

    private void toolStripButtonImportDistances_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = ml.ml_string(1407, "Distance Files (*.txt)|*.txt|All files (*.*)|*.*");
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      try
      {
        BCEDataSet.ClubsRow activeClubRow = MainForm.Instance.clubsPage.GetActiveClubRow();
        new ImportDistancesFromFile().Do(openFileDialog.FileName, activeClubRow);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FanciersPage));
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      this.dataGridView1 = new DataGridView();
      this.idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.licentieDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.naamDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.adresDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.postcodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.gemeenteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.telefoonDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.faxDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.bankrekeningDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.Club1 = new DataGridViewTextBoxColumn();
      this.Club2 = new DataGridViewTextBoxColumn();
      this.kWXDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.kWYDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.bceDataSetLocal = new BCEDataSet();
      this.bindingNavigatorAdressen = new BindingNavigator(this.components);
      this.bindingNavigatorAddNewItem = new ToolStripButton();
      this.bindingNavigatorCountItem = new ToolStripLabel();
      this.bindingNavigatorMoveFirstItem = new ToolStripButton();
      this.bindingNavigatorMovePreviousItem = new ToolStripButton();
      this.bindingNavigatorSeparator = new ToolStripSeparator();
      this.bindingNavigatorPositionItem = new ToolStripTextBox();
      this.bindingNavigatorSeparator1 = new ToolStripSeparator();
      this.bindingNavigatorMoveNextItem = new ToolStripButton();
      this.bindingNavigatorMoveLastItem = new ToolStripButton();
      this.bindingNavigatorSeparator2 = new ToolStripSeparator();
      this.bindingNavigatorDeleteItem = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolStripButtonAutoLoad = new ToolStripButton();
      this.toolStripButtonFromBA = new ToolStripButton();
      this.toolStripButtonSendmultiple = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.toolStripButton1 = new ToolStripButton();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.toolStripButtonReadFlightData = new ToolStripButton();
      this.toolStripButtonMergeFanciers = new ToolStripButton();
      this.toolStripButtonSendToBW = new ToolStripButton();
      this.toolStripButtonImportDistances = new ToolStripButton();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.bceDataSetLocal.BeginInit();
      this.bindingNavigatorAdressen.BeginInit();
      this.bindingNavigatorAdressen.SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToOrderColumns = true;
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.idDataGridViewTextBoxColumn, (DataGridViewColumn) this.licentieDataGridViewTextBoxColumn, (DataGridViewColumn) this.naamDataGridViewTextBoxColumn, (DataGridViewColumn) this.adresDataGridViewTextBoxColumn, (DataGridViewColumn) this.postcodeDataGridViewTextBoxColumn, (DataGridViewColumn) this.gemeenteDataGridViewTextBoxColumn, (DataGridViewColumn) this.telefoonDataGridViewTextBoxColumn, (DataGridViewColumn) this.faxDataGridViewTextBoxColumn, (DataGridViewColumn) this.emailDataGridViewTextBoxColumn, (DataGridViewColumn) this.bankrekeningDataGridViewTextBoxColumn, (DataGridViewColumn) this.Club1, (DataGridViewColumn) this.Club2, (DataGridViewColumn) this.kWXDataGridViewTextBoxColumn, (DataGridViewColumn) this.kWYDataGridViewTextBoxColumn);
      this.dataGridView1.DataMember = "Clubs.Clubs_Adressen";
      this.dataGridView1.DataSource = (object) this.bceDataSetLocal;
      componentResourceManager.ApplyResources((object) this.dataGridView1, "dataGridView1");
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
      this.dataGridView1.DoubleClick += new EventHandler(this.dataGridView1_DoubleClick);
      this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
      componentResourceManager.ApplyResources((object) this.idDataGridViewTextBoxColumn, "idDataGridViewTextBoxColumn");
      this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
      this.idDataGridViewTextBoxColumn.ReadOnly = true;
      this.licentieDataGridViewTextBoxColumn.DataPropertyName = "Licentie";
      componentResourceManager.ApplyResources((object) this.licentieDataGridViewTextBoxColumn, "licentieDataGridViewTextBoxColumn");
      this.licentieDataGridViewTextBoxColumn.Name = "licentieDataGridViewTextBoxColumn";
      this.licentieDataGridViewTextBoxColumn.ReadOnly = true;
      this.naamDataGridViewTextBoxColumn.DataPropertyName = "Naam";
      componentResourceManager.ApplyResources((object) this.naamDataGridViewTextBoxColumn, "naamDataGridViewTextBoxColumn");
      this.naamDataGridViewTextBoxColumn.Name = "naamDataGridViewTextBoxColumn";
      this.adresDataGridViewTextBoxColumn.DataPropertyName = "Adres";
      componentResourceManager.ApplyResources((object) this.adresDataGridViewTextBoxColumn, "adresDataGridViewTextBoxColumn");
      this.adresDataGridViewTextBoxColumn.Name = "adresDataGridViewTextBoxColumn";
      this.postcodeDataGridViewTextBoxColumn.DataPropertyName = "Postcode";
      componentResourceManager.ApplyResources((object) this.postcodeDataGridViewTextBoxColumn, "postcodeDataGridViewTextBoxColumn");
      this.postcodeDataGridViewTextBoxColumn.Name = "postcodeDataGridViewTextBoxColumn";
      this.gemeenteDataGridViewTextBoxColumn.DataPropertyName = "Gemeente";
      componentResourceManager.ApplyResources((object) this.gemeenteDataGridViewTextBoxColumn, "gemeenteDataGridViewTextBoxColumn");
      this.gemeenteDataGridViewTextBoxColumn.Name = "gemeenteDataGridViewTextBoxColumn";
      this.telefoonDataGridViewTextBoxColumn.DataPropertyName = "Telefoon";
      componentResourceManager.ApplyResources((object) this.telefoonDataGridViewTextBoxColumn, "telefoonDataGridViewTextBoxColumn");
      this.telefoonDataGridViewTextBoxColumn.Name = "telefoonDataGridViewTextBoxColumn";
      this.faxDataGridViewTextBoxColumn.DataPropertyName = "Fax";
      componentResourceManager.ApplyResources((object) this.faxDataGridViewTextBoxColumn, "faxDataGridViewTextBoxColumn");
      this.faxDataGridViewTextBoxColumn.Name = "faxDataGridViewTextBoxColumn";
      this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
      componentResourceManager.ApplyResources((object) this.emailDataGridViewTextBoxColumn, "emailDataGridViewTextBoxColumn");
      this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
      this.bankrekeningDataGridViewTextBoxColumn.DataPropertyName = "Bankrekening";
      componentResourceManager.ApplyResources((object) this.bankrekeningDataGridViewTextBoxColumn, "bankrekeningDataGridViewTextBoxColumn");
      this.bankrekeningDataGridViewTextBoxColumn.Name = "bankrekeningDataGridViewTextBoxColumn";
      this.Club1.DataPropertyName = "Club1";
      componentResourceManager.ApplyResources((object) this.Club1, "Club1");
      this.Club1.Name = "Club1";
      this.Club2.DataPropertyName = "Club2";
      componentResourceManager.ApplyResources((object) this.Club2, "Club2");
      this.Club2.Name = "Club2";
      this.kWXDataGridViewTextBoxColumn.DataPropertyName = "KWX";
      gridViewCellStyle1.Format = "00:00:00','00";
      gridViewCellStyle1.NullValue = (object) "00:00:00,00";
      this.kWXDataGridViewTextBoxColumn.DefaultCellStyle = gridViewCellStyle1;
      componentResourceManager.ApplyResources((object) this.kWXDataGridViewTextBoxColumn, "kWXDataGridViewTextBoxColumn");
      this.kWXDataGridViewTextBoxColumn.Name = "kWXDataGridViewTextBoxColumn";
      this.kWXDataGridViewTextBoxColumn.ReadOnly = true;
      this.kWYDataGridViewTextBoxColumn.DataPropertyName = "KWY";
      gridViewCellStyle2.Format = "00:00:00','00";
      gridViewCellStyle2.NullValue = (object) "00:00:00,00";
      this.kWYDataGridViewTextBoxColumn.DefaultCellStyle = gridViewCellStyle2;
      componentResourceManager.ApplyResources((object) this.kWYDataGridViewTextBoxColumn, "kWYDataGridViewTextBoxColumn");
      this.kWYDataGridViewTextBoxColumn.Name = "kWYDataGridViewTextBoxColumn";
      this.kWYDataGridViewTextBoxColumn.ReadOnly = true;
      this.bceDataSetLocal.DataSetName = "BCEDataSet";
      this.bceDataSetLocal.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.bindingNavigatorAdressen.AddNewItem = (ToolStripItem) this.bindingNavigatorAddNewItem;
      this.bindingNavigatorAdressen.CountItem = (ToolStripItem) this.bindingNavigatorCountItem;
      this.bindingNavigatorAdressen.DeleteItem = (ToolStripItem) null;
      this.bindingNavigatorAdressen.Items.AddRange(new ToolStripItem[22]
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
        (ToolStripItem) this.toolStripButtonAutoLoad,
        (ToolStripItem) this.toolStripButtonFromBA,
        (ToolStripItem) this.toolStripButtonSendmultiple,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.toolStripButton1,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.toolStripButtonReadFlightData,
        (ToolStripItem) this.toolStripButtonMergeFanciers,
        (ToolStripItem) this.toolStripButtonSendToBW,
        (ToolStripItem) this.toolStripButtonImportDistances
      });
      componentResourceManager.ApplyResources((object) this.bindingNavigatorAdressen, "bindingNavigatorAdressen");
      this.bindingNavigatorAdressen.MoveFirstItem = (ToolStripItem) this.bindingNavigatorMoveFirstItem;
      this.bindingNavigatorAdressen.MoveLastItem = (ToolStripItem) this.bindingNavigatorMoveLastItem;
      this.bindingNavigatorAdressen.MoveNextItem = (ToolStripItem) this.bindingNavigatorMoveNextItem;
      this.bindingNavigatorAdressen.MovePreviousItem = (ToolStripItem) this.bindingNavigatorMovePreviousItem;
      this.bindingNavigatorAdressen.Name = "bindingNavigatorAdressen";
      this.bindingNavigatorAdressen.PositionItem = (ToolStripItem) this.bindingNavigatorPositionItem;
      this.bindingNavigatorAddNewItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      componentResourceManager.ApplyResources((object) this.bindingNavigatorAddNewItem, "bindingNavigatorAddNewItem");
      this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
      this.bindingNavigatorAddNewItem.Click += new EventHandler(this.bindingNavigatorAddNewItem_Click);
      this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
      componentResourceManager.ApplyResources((object) this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
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
      this.bindingNavigatorDeleteItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      componentResourceManager.ApplyResources((object) this.bindingNavigatorDeleteItem, "bindingNavigatorDeleteItem");
      this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
      this.bindingNavigatorDeleteItem.Click += new EventHandler(this.bindingNavigatorDeleteItem_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator1, "toolStripSeparator1");
      this.toolStripButtonAutoLoad.Checked = Settings.Default.AutoLoad;
      this.toolStripButtonAutoLoad.CheckOnClick = true;
      this.toolStripButtonAutoLoad.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonAutoLoad.Image = (Image) Resources.ToBA;
      componentResourceManager.ApplyResources((object) this.toolStripButtonAutoLoad, "toolStripButtonAutoLoad");
      this.toolStripButtonAutoLoad.Name = "toolStripButtonAutoLoad";
      this.toolStripButtonAutoLoad.Click += new EventHandler(this.toolStripButtonAutoLoad_Click);
      this.toolStripButtonFromBA.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonFromBA.Image = (Image) Resources.FromBA;
      componentResourceManager.ApplyResources((object) this.toolStripButtonFromBA, "toolStripButtonFromBA");
      this.toolStripButtonFromBA.Name = "toolStripButtonFromBA";
      this.toolStripButtonFromBA.Click += new EventHandler(this.toolStripButtonFromBA_Click);
      this.toolStripButtonSendmultiple.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonSendmultiple.Image = (Image) Resources.SendMultiple;
      componentResourceManager.ApplyResources((object) this.toolStripButtonSendmultiple, "toolStripButtonSendmultiple");
      this.toolStripButtonSendmultiple.Name = "toolStripButtonSendmultiple";
      this.toolStripButtonSendmultiple.Click += new EventHandler(this.toolStripButtonSendmultiple_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator2, "toolStripSeparator2");
      this.toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton1.Image = (Image) Resources.Print;
      componentResourceManager.ApplyResources((object) this.toolStripButton1, "toolStripButton1");
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Click += new EventHandler(this.toolStripButton1_Click);
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator3, "toolStripSeparator3");
      this.toolStripButtonReadFlightData.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonReadFlightData.Image = (Image) Resources.ReadFlightData;
      componentResourceManager.ApplyResources((object) this.toolStripButtonReadFlightData, "toolStripButtonReadFlightData");
      this.toolStripButtonReadFlightData.Name = "toolStripButtonReadFlightData";
      this.toolStripButtonReadFlightData.Click += new EventHandler(this.toolStripButtonReadFlightData_Click);
      this.toolStripButtonMergeFanciers.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonMergeFanciers.Image = (Image) Resources.MergeFanciers;
      componentResourceManager.ApplyResources((object) this.toolStripButtonMergeFanciers, "toolStripButtonMergeFanciers");
      this.toolStripButtonMergeFanciers.Name = "toolStripButtonMergeFanciers";
      this.toolStripButtonMergeFanciers.Click += new EventHandler(this.toolStripButtonMergeFanciers_Click);
      this.toolStripButtonSendToBW.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonSendToBW.Image = (Image) Resources.BriconWeb;
      this.toolStripButtonSendToBW.Name = "toolStripButtonSendToBW";
      componentResourceManager.ApplyResources((object) this.toolStripButtonSendToBW, "toolStripButtonSendToBW");
      this.toolStripButtonSendToBW.Click += new EventHandler(this.toolStripButtonSendToBW_Click);
      this.toolStripButtonImportDistances.DisplayStyle = ToolStripItemDisplayStyle.Image;
      componentResourceManager.ApplyResources((object) this.toolStripButtonImportDistances, "toolStripButtonImportDistances");
      this.toolStripButtonImportDistances.Name = "toolStripButtonImportDistances";
      this.toolStripButtonImportDistances.Click += new EventHandler(this.toolStripButtonImportDistances_Click);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.bindingNavigatorAdressen);
      this.Name = nameof (FanciersPage);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.bceDataSetLocal.EndInit();
      this.bindingNavigatorAdressen.EndInit();
      this.bindingNavigatorAdressen.ResumeLayout(false);
      this.bindingNavigatorAdressen.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
