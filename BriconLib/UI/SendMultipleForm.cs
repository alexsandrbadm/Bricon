// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.SendMultipleForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using BriconLib.Other;
using MultiLang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace BriconLib.UI
{
  public class SendMultipleForm : Form
  {
    public List<int> _ids;
    private IContainer components;
    private DataGridView dataGridView1;
    private BCEDataSet bCEDataSet;
    private Button buttonSend;
    private Button buttonStop;
    private Label labelSelectFancier;
    private BindingSource adressenBindingSource;
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

    public SendMultipleForm(List<int> ids)
    {
      this._ids = ids;
      this.InitializeComponent();
      this.adressenBindingSource.DataSource = (object) BCEDatabase.DataSet;
      string str = ml.ml_string(410, "FIRST");
      if (ids.Count == 1)
        str = ml.ml_string(414, "SECOND");
      if (ids.Count == 2)
        str = ml.ml_string(413, "THIRD");
      this.labelSelectFancier.Text = string.Format(this.labelSelectFancier.Text, (object) str);
    }

    private void SendMultipleForm_Load(object sender, EventArgs e)
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

    private void buttonStop_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private int GetSelectedID() => this.dataGridView1.CurrentRow == null ? -1 : (int) this.dataGridView1.CurrentRow.Cells[0].Value;

    private void buttonSend_Click(object sender, EventArgs e)
    {
      if (this.GetSelectedID() == -1)
      {
        int num = (int) MessageBox.Show(ml.ml_string(837, "Please select a fancier"));
        this.DialogResult = DialogResult.None;
      }
      else
      {
        foreach (int id in this._ids)
        {
          if (id == this.GetSelectedID())
          {
            int num = (int) MessageBox.Show(ml.ml_string(411, "Fancier already choosen"));
            this.DialogResult = DialogResult.None;
            return;
          }
        }
        this._ids.Add(this.GetSelectedID());
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void dataGridView1_DoubleClick(object sender, EventArgs e) => this.buttonSend_Click(sender, e);

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (SendMultipleForm));
      this.dataGridView1 = new DataGridView();
      this.adressenBindingSource = new BindingSource(this.components);
      this.bCEDataSet = new BCEDataSet();
      this.buttonSend = new Button();
      this.buttonStop = new Button();
      this.labelSelectFancier = new Label();
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
      this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
      this.adressenBindingSource.DataMember = "Adressen";
      this.adressenBindingSource.DataSource = (object) this.bCEDataSet;
      this.bCEDataSet.DataSetName = "BCEDataSet";
      this.bCEDataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      componentResourceManager.ApplyResources((object) this.buttonSend, "buttonSend");
      this.buttonSend.Name = "buttonSend";
      this.buttonSend.UseVisualStyleBackColor = true;
      this.buttonSend.Click += new EventHandler(this.buttonSend_Click);
      componentResourceManager.ApplyResources((object) this.buttonStop, "buttonStop");
      this.buttonStop.DialogResult = DialogResult.Cancel;
      this.buttonStop.Name = "buttonStop";
      this.buttonStop.UseVisualStyleBackColor = true;
      this.buttonStop.Click += new EventHandler(this.buttonStop_Click);
      componentResourceManager.ApplyResources((object) this.labelSelectFancier, "labelSelectFancier");
      this.labelSelectFancier.Name = "labelSelectFancier";
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
      this.AcceptButton = (IButtonControl) this.buttonSend;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonStop;
      this.Controls.Add((Control) this.labelSelectFancier);
      this.Controls.Add((Control) this.buttonStop);
      this.Controls.Add((Control) this.buttonSend);
      this.Controls.Add((Control) this.dataGridView1);
      this.Name = nameof (SendMultipleForm);
      this.Load += new EventHandler(this.SendMultipleForm_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((ISupportInitialize) this.adressenBindingSource).EndInit();
      this.bCEDataSet.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
