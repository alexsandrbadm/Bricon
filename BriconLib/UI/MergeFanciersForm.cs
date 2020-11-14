// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.MergeFanciersForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using BriconLib.Other;
using MultiLang;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace BriconLib.UI
{
  public class MergeFanciersForm : Form
  {
    public int _fancierID;
    private IContainer components;
    private DataGridView dataGridView1;
    private BCEDataSet bCEDataSet;
    private BindingSource adressenBindingSource;
    private Label labelTitle;
    private Button buttonOK;
    private Button buttonCancel;
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
    private DataGridViewTextBoxColumn laatsteDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn kWXDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn kWYDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn serialDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn clubIDDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn Club1;
    private DataGridViewTextBoxColumn Club2;

    public MergeFanciersForm(int fancierID, string fancierName)
    {
      this._fancierID = fancierID;
      this.InitializeComponent();
      this.adressenBindingSource.DataSource = (object) BCEDatabase.DataSet;
      this.labelTitle.Text = string.Format(this.labelTitle.Text, (object) fancierName);
    }

    private int GetSelectedID() => this.dataGridView1.CurrentRow == null ? -1 : (int) this.dataGridView1.CurrentRow.Cells[0].Value;

    private void dataGridView1_DoubleClick(object sender, EventArgs e) => this.buttonOK_Click(sender, e);

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      if (this.GetSelectedID() == -1)
      {
        int num = (int) MessageBox.Show(ml.ml_string(412, "Please select a fancier"));
        this.DialogResult = DialogResult.None;
      }
      else
      {
        try
        {
          BCEDataSet.AdressenRow byId1 = BCEDatabase.DataSet.Adressen.FindById(this._fancierID);
          BCEDataSet.AdressenRow byId2 = BCEDatabase.DataSet.Adressen.FindById(this.GetSelectedID());
          BCEDataSet.AdressenRow parentAdressenRowByAdressen_Pigeons = BCEDatabase.DataSet.Adressen.AddAdressenRow(byId1.Licentie, "*" + byId1.Naam, byId1.Adres, byId1.Postcode, byId1.Gemeente, byId1.Telefoon, byId1.Fax, byId1.Email, byId1.Bankrekening, byId1.Laatste, byId1.KWX, byId1.KWY, byId1.Serial, byId1.ClubsRow, byId1.Notes, byId1.Country, byId1.Club1, byId1.Club2, DateTime.MinValue, "", "", byId1.IsManual);
          foreach (BCEDataSet.PigeonsRow pigeonsRow in byId1.GetPigeonsRows())
            BCEDatabase.DataSet.Pigeons.AddPigeonsRow(parentAdressenRowByAdressen_Pigeons, pigeonsRow.DBRing, pigeonsRow.ELRing, pigeonsRow.FEMALE, pigeonsRow.Color, pigeonsRow.IsColumnNull() ? 0 : pigeonsRow.Column, !pigeonsRow.IsSelNull() && pigeonsRow.Sel, pigeonsRow.IsOrderNull() ? 0 : pigeonsRow.Order);
          foreach (BCEDataSet.PigeonsRow pigeonsRow in byId2.GetPigeonsRows())
            BCEDatabase.DataSet.Pigeons.AddPigeonsRow(parentAdressenRowByAdressen_Pigeons, pigeonsRow.DBRing, pigeonsRow.ELRing, pigeonsRow.FEMALE, pigeonsRow.Color, pigeonsRow.IsColumnNull() ? 0 : pigeonsRow.Column, !pigeonsRow.IsSelNull() && pigeonsRow.Sel, pigeonsRow.IsOrderNull() ? 0 : pigeonsRow.Order);
          int num = (int) MessageBox.Show(ml.ml_string(791, "The fanciers are merged to a new fancier : '") + parentAdressenRowByAdressen_Pigeons.Naam + "'", ml.ml_string(790, "Merge fancier"));
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ml.ml_string(792, "Error occurred : ") + ex.Message, ml.ml_string(275, "Error"));
          this.DialogResult = DialogResult.None;
          return;
        }
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private void MergeFanciersForm_Load(object sender, EventArgs e)
    {
      if (!Utils.IsCountry("JP"))
        return;
      this.adresDataGridViewTextBoxColumn.Visible = false;
      this.postcodeDataGridViewTextBoxColumn.Visible = false;
      this.gemeenteDataGridViewTextBoxColumn.Visible = false;
      this.telefoonDataGridViewTextBoxColumn.Visible = false;
      this.faxDataGridViewTextBoxColumn.Visible = false;
      this.emailDataGridViewTextBoxColumn.Visible = false;
      this.laatsteDataGridViewTextBoxColumn.Visible = false;
      this.kWXDataGridViewTextBoxColumn.Visible = false;
      this.kWYDataGridViewTextBoxColumn.Visible = false;
      this.serialDataGridViewTextBoxColumn.Visible = false;
      this.clubIDDataGridViewTextBoxColumn.Visible = false;
      this.countryDataGridViewTextBoxColumn.Visible = false;
      this.Club1.Visible = true;
      this.Club2.Visible = true;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MergeFanciersForm));
      this.dataGridView1 = new DataGridView();
      this.adressenBindingSource = new BindingSource(this.components);
      this.bCEDataSet = new BCEDataSet();
      this.labelTitle = new Label();
      this.buttonOK = new Button();
      this.buttonCancel = new Button();
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
      this.laatsteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.kWXDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.kWYDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.serialDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.clubIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.notesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.countryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.Club1 = new DataGridViewTextBoxColumn();
      this.Club2 = new DataGridViewTextBoxColumn();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((ISupportInitialize) this.adressenBindingSource).BeginInit();
      this.bCEDataSet.BeginInit();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AllowUserToOrderColumns = true;
      componentResourceManager.ApplyResources((object) this.dataGridView1, "dataGridView1");
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.idDataGridViewTextBoxColumn, (DataGridViewColumn) this.licentieDataGridViewTextBoxColumn, (DataGridViewColumn) this.naamDataGridViewTextBoxColumn, (DataGridViewColumn) this.adresDataGridViewTextBoxColumn, (DataGridViewColumn) this.postcodeDataGridViewTextBoxColumn, (DataGridViewColumn) this.gemeenteDataGridViewTextBoxColumn, (DataGridViewColumn) this.telefoonDataGridViewTextBoxColumn, (DataGridViewColumn) this.faxDataGridViewTextBoxColumn, (DataGridViewColumn) this.emailDataGridViewTextBoxColumn, (DataGridViewColumn) this.bankrekeningDataGridViewTextBoxColumn, (DataGridViewColumn) this.laatsteDataGridViewTextBoxColumn, (DataGridViewColumn) this.kWXDataGridViewTextBoxColumn, (DataGridViewColumn) this.kWYDataGridViewTextBoxColumn, (DataGridViewColumn) this.serialDataGridViewTextBoxColumn, (DataGridViewColumn) this.clubIDDataGridViewTextBoxColumn, (DataGridViewColumn) this.notesDataGridViewTextBoxColumn, (DataGridViewColumn) this.countryDataGridViewTextBoxColumn, (DataGridViewColumn) this.Club1, (DataGridViewColumn) this.Club2);
      this.dataGridView1.DataSource = (object) this.adressenBindingSource;
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.DoubleClick += new EventHandler(this.dataGridView1_DoubleClick);
      this.adressenBindingSource.DataMember = "Adressen";
      this.adressenBindingSource.DataSource = (object) this.bCEDataSet;
      this.bCEDataSet.DataSetName = "BCEDataSet";
      this.bCEDataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      componentResourceManager.ApplyResources((object) this.labelTitle, "labelTitle");
      this.labelTitle.Name = "labelTitle";
      componentResourceManager.ApplyResources((object) this.buttonOK, "buttonOK");
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      componentResourceManager.ApplyResources((object) this.buttonCancel, "buttonCancel");
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
      componentResourceManager.ApplyResources((object) this.idDataGridViewTextBoxColumn, "idDataGridViewTextBoxColumn");
      this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
      this.licentieDataGridViewTextBoxColumn.DataPropertyName = "Licentie";
      componentResourceManager.ApplyResources((object) this.licentieDataGridViewTextBoxColumn, "licentieDataGridViewTextBoxColumn");
      this.licentieDataGridViewTextBoxColumn.Name = "licentieDataGridViewTextBoxColumn";
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
      this.laatsteDataGridViewTextBoxColumn.DataPropertyName = "Laatste";
      componentResourceManager.ApplyResources((object) this.laatsteDataGridViewTextBoxColumn, "laatsteDataGridViewTextBoxColumn");
      this.laatsteDataGridViewTextBoxColumn.Name = "laatsteDataGridViewTextBoxColumn";
      this.kWXDataGridViewTextBoxColumn.DataPropertyName = "KWX";
      componentResourceManager.ApplyResources((object) this.kWXDataGridViewTextBoxColumn, "kWXDataGridViewTextBoxColumn");
      this.kWXDataGridViewTextBoxColumn.Name = "kWXDataGridViewTextBoxColumn";
      this.kWYDataGridViewTextBoxColumn.DataPropertyName = "KWY";
      componentResourceManager.ApplyResources((object) this.kWYDataGridViewTextBoxColumn, "kWYDataGridViewTextBoxColumn");
      this.kWYDataGridViewTextBoxColumn.Name = "kWYDataGridViewTextBoxColumn";
      this.serialDataGridViewTextBoxColumn.DataPropertyName = "Serial";
      componentResourceManager.ApplyResources((object) this.serialDataGridViewTextBoxColumn, "serialDataGridViewTextBoxColumn");
      this.serialDataGridViewTextBoxColumn.Name = "serialDataGridViewTextBoxColumn";
      this.clubIDDataGridViewTextBoxColumn.DataPropertyName = "ClubID";
      componentResourceManager.ApplyResources((object) this.clubIDDataGridViewTextBoxColumn, "clubIDDataGridViewTextBoxColumn");
      this.clubIDDataGridViewTextBoxColumn.Name = "clubIDDataGridViewTextBoxColumn";
      this.notesDataGridViewTextBoxColumn.DataPropertyName = "Notes";
      componentResourceManager.ApplyResources((object) this.notesDataGridViewTextBoxColumn, "notesDataGridViewTextBoxColumn");
      this.notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
      this.countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
      componentResourceManager.ApplyResources((object) this.countryDataGridViewTextBoxColumn, "countryDataGridViewTextBoxColumn");
      this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
      this.Club1.DataPropertyName = "Club1";
      componentResourceManager.ApplyResources((object) this.Club1, "Club1");
      this.Club1.Name = "Club1";
      this.Club2.DataPropertyName = "Club2";
      componentResourceManager.ApplyResources((object) this.Club2, "Club2");
      this.Club2.Name = "Club2";
      this.AcceptButton = (IButtonControl) this.buttonOK;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonCancel;
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonOK);
      this.Controls.Add((Control) this.labelTitle);
      this.Controls.Add((Control) this.dataGridView1);
      this.Name = nameof (MergeFanciersForm);
      this.Load += new EventHandler(this.MergeFanciersForm_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((ISupportInitialize) this.adressenBindingSource).EndInit();
      this.bCEDataSet.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
