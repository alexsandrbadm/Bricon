// Decompiled with JetBrains decompiler
// Type: BriconLib.BCE.FancierPage
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Communications;
using BriconLib.Data;
using BriconLib.Other;
using BriconLib.PAS.ManualPigeons;
using BriconLib.Printing;
using BriconLib.Properties;
using BriconLib.UI;
using MultiLang;
using PAS.Admin.Bce.ManualPigeons;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BriconLib.BCE
{
  public class FancierPage : UserControl
  {
    private BindingSource _clubsDataSource;
    private string _oldDBRing = string.Empty;
    private IContainer components;
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
    private TextBox textBoxName;
    private BCEDataSet bceDataSetLocal;
    public BindingSource bindingSourceAdressen;
    private TextBox textBoxAddress;
    private TextBox textBoxZipCode;
    private TextBox textBoxCity;
    private DataGridView dataGridView1;
    private BindingNavigator bindingNavigatorPigeons;
    private ToolStripButton bindingNavigatorAddNewItem1;
    private ToolStripLabel bindingNavigatorCountItem1;
    private ToolStripButton bindingNavigatorDeleteItem1;
    private ToolStripSeparator bindingNavigatorSeparator3;
    private ToolStripTextBox bindingNavigatorPositionItem1;
    private ToolStripSeparator bindingNavigatorSeparator4;
    private ToolStripSeparator bindingNavigatorSeparator5;
    public BindingSource bindingSourceClubsLocal;
    private Panel panelLeft;
    private ToolStripButton toolStripButtonReadRing;
    private TextBox textBoxCoordinateY;
    private TextBox textBoxCoordinateX;
    private TextBox textBoxLicense;
    private TextBox textBoxTelephone2;
    private TextBox textBoxTelephone;
    private TextBox textBoxNotes;
    private TextBox textBoxCountry;
    private TextBox textBoxEmail;
    private TextBox textBoxBankAccount;
    private TextBox textBoxSerial;
    private TextBox textBoxLastAccess;
    private ToolStripButton toolStripButtonToBA;
    private ToolStripButton toolStripButtonFromBA;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton buttonGenerateRings;
    private MaskedTextBox maskedTextBoxCoordinateX;
    private MaskedTextBox maskedTextBoxCoordinateY;
    public BindingSource adressenPigeonsBindingSource;
    internal BindingNavigator bindingNavigatorAdressen;
    private ErrorProvider errorProvider1;
    private MaskedTextBox maskedTextBoxLicense;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripButton toolStripButtonPrint;
    private ToolStripButton toolStripButtonCheckRing;
    private Label labelName;
    private Label labelBankAccount;
    private Label labelAddress;
    private Label labelCity;
    private Label labelTelephone;
    private Label labelCountry;
    private Label labelEmail;
    private Label labelLastAccess;
    private Button button1;
    private Label labelClub2;
    private Label labelClub1;
    private TextBox textBoxClub2;
    private TextBox textBoxClub1;
    private DataGridViewTextBoxColumn Nr;
    private DataGridViewTextBoxColumn dBRingDataGridViewTextBoxColumn;
    private DataGridViewCheckBoxColumn FEMALE;
    private DataGridViewTextBoxColumn eLRingDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn colordDataGridViewTextBoxColumn;
    private DataGridViewCheckBoxColumn Sel;
    private DataGridViewTextBoxColumn OrderColumn;
    private ToolStripButton toolStripButtonDistances;
    private Label labelLastSend;
    private ToolStripButton toolStripButtonSelectAll;
    private Panel panel1;
    private Label labelRingFormat;
    private Label labelNaamUnicode;
    private TextBox textBoxNaamUnicode;
    private Label labelCityUnicode;
    private TextBox textBoxCityUnicode;
    private Button buttonCloud;
    private CheckBox checkBoxManual;

    public FancierPage() => this.InitializeComponent();

    public void SetDataSource(BindingSource clubsDataSource)
    {
      this.bindingSourceAdressen.DataSource = (object) clubsDataSource;
      this._clubsDataSource = clubsDataSource;
    }

    private void toolStripButtonToBA_Click(object sender, EventArgs e)
    {
      this.textBoxLicense.Focus();
      this.dataGridView1.EndEdit();
      if (this.bindingSourceAdressen.Current == null)
        return;
      this.SendFancierAndRingsToBA(((DataRowView) this.bindingSourceAdressen.Current).Row as BCEDataSet.AdressenRow);
    }

    private void toolStripButtonFromBA_Click(object sender, EventArgs e)
    {
      this.dataGridView1.EndEdit();
      if (this.bindingSourceAdressen.Current == null)
        return;
      DialogResult dialogResult = MessageBox.Show(ml.ml_string(243, "This will override the current fancier, are you sure you want to do this? Pressing No will add a new fancier"), Defines.MessageBoxCaption, MessageBoxButtons.YesNoCancel);
      if (dialogResult == DialogResult.Cancel)
        return;
      BCEDataSet.AdressenRow row = ((DataRowView) this.bindingSourceAdressen.Current).Row as BCEDataSet.AdressenRow;
      if (dialogResult == DialogResult.No)
        row = BCEDatabase.DataSet.Adressen.AddAdressenRow("", "", "", "", "", "", "", "", "", "", 0, 0, "", ((DataRowView) this._clubsDataSource.Current).Row as BCEDataSet.ClubsRow, "", "", "", "", DateTime.MinValue, "", "", false);
      this.GetFancierAndRingsFromBA(row);
    }

    public void SendFancierAndRingsToBA(BCEDataSet.AdressenRow row)
    {
      this.bindingSourceAdressen.EndEdit();
      this.adressenPigeonsBindingSource.EndEdit();
      if (row != null)
      {
        if (!this.ValidateAllData(true, row, true))
        {
          int num1 = (int) MessageBox.Show(ml.ml_string(284, "Some fields are incorrect, please check for errors."));
        }
        else
        {
          int id = row.Id;
          if (!Validation.License(row.IsLicentieNull() ? string.Empty : row.Licentie))
          {
            int num2 = (int) MessageBox.Show(ml.ml_string(211, "Loft number not correct."));
          }
          else
          {
            string str = string.Empty;
            BCEDataSet.ClubsRow byId = BCEDatabase.DataSet.Clubs.FindByID(row.ClubID);
            if (byId != null)
              str = byId.IsPincodeNull() ? string.Empty : byId.Pincode;
            if (!Validation.Pincode(str))
            {
              int num3 = (int) MessageBox.Show(ml.ml_string(132, "Pincode for current club not correct."));
            }
            else
            {
              row.LastSendedToBA = DateTime.Now;
              row.EndEdit();
              this.bindingSourceAdressen.EndEdit();
              int coordinate1 = row.IsKWXNull() ? 0 : row.KWX;
              int coordinate2 = row.IsKWYNull() ? 0 : row.KWY;
              CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new SendFancierCommand(row.Id, row.IsLicentieNull() ? string.Empty : row.Licentie.Trim(), row.IsNaamNull() ? string.Empty : row.Naam.Trim(), row.IsAdresNull() ? string.Empty : row.Adres.Trim(), row.IsPostcodeNull() ? string.Empty : row.Postcode.Trim(), row.IsGemeenteNull() ? string.Empty : row.Gemeente.Trim(), Conversion.CoordinateToString(coordinate1, false), Conversion.CoordinateToString(coordinate2, false), row.IsSerialNull() ? string.Empty : row.Serial));
              SendBandTableCommand bandTableCommand = (SendBandTableCommand) null;
              int num4 = 1;
              if (SendFancierCommand.fancierPos == (byte) 0)
              {
                bandTableCommand = new SendBandTableCommand(str);
                CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) bandTableCommand);
              }
              string sort = "DBRing";
              if (Utils.IsCountry("PL"))
              {
                foreach (BCEDataSet.PigeonsRow pigeonsRow in BCEDatabase.DataSet.Pigeons.Select("FancierID = " + id.ToString()))
                {
                  if (pigeonsRow.RowState != DataRowState.Deleted && (pigeonsRow.IsOrderNull() || pigeonsRow.Order < 1))
                    pigeonsRow.Order = 999;
                }
                sort = "Order, DBRing";
              }
              foreach (BCEDataSet.PigeonsRow pigeonsRow in BCEDatabase.DataSet.Pigeons.Select("FancierID = " + id.ToString(), sort))
              {
                if (pigeonsRow.RowState != DataRowState.Deleted)
                {
                  bandTableCommand = new SendBandTableCommand(num4++, pigeonsRow.ELRing, pigeonsRow.DBRing, pigeonsRow.FEMALE, pigeonsRow.Color);
                  CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) bandTableCommand);
                }
              }
              bandTableCommand.LastRecord = true;
            }
          }
        }
      }
      else
      {
        int num5 = (int) MessageBox.Show(ml.ml_string(108, "Please select a record"));
      }
    }

    public void GetFancierAndRingsFromBA(BCEDataSet.AdressenRow row)
    {
      int id1 = row.Id;
      this.bindingSourceAdressen.EndEdit();
      this.adressenPigeonsBindingSource.EndEdit();
      if ((((DataRowView) this.bindingSourceAdressen.Current).Row as BCEDataSet.AdressenRow).Id != id1)
      {
        this.bindingSourceAdressen.Position = 0;
        while ((((DataRowView) this.bindingSourceAdressen.Current).Row as BCEDataSet.AdressenRow).Id != id1 && this.bindingSourceAdressen.Position != this.bindingSourceAdressen.Count - 1)
          this.bindingSourceAdressen.MoveNext();
      }
      if (row != null)
      {
        int id2 = row.Id;
        string oldLicence = row.IsLicentieNull() ? string.Empty : row.Licentie;
        string oldName = row.IsNaamNull() ? string.Empty : row.Naam;
        CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new GetFancierCommand(id2, oldName, oldLicence));
        CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new GetBandTableCommand(id2));
      }
      else
      {
        int num = (int) MessageBox.Show(ml.ml_string(108, "Please select a record"));
      }
    }

    private void toolStripButtonReadRing_Click(object sender, EventArgs e)
    {
      if (Utils.IsCountry("UK") && (Settings.Default.Union == "" || Settings.Default.Union == null))
      {
        int num1 = (int) MessageBox.Show("Please fill in the Union in the options page");
      }
      BCEDataSet.AdressenRow currentRow = this.SaveAndGetCurrentRow();
      this.ValidateAllData(false, currentRow, true);
      if (currentRow != null)
      {
        if (CommunicationState.Instance.MasterFound && CommunicationState.Instance.MasterVersionNumber < 4096 && Utils.IsCountry("BE"))
        {
          int num2 = (int) MessageBox.Show(ml.ml_string(1405, "Master version is too old! (") + CommunicationState.Instance.MasterVersionNumber.ToString() + ")");
        }
        else if (!CommunicationState.Instance.MasterFound && Utils.IsCountry("BE"))
        {
          int num3 = (int) MessageBox.Show(ml.ml_string(1406, "Master is not connected!"));
        }
        else if (Utils.IsCountry("BE") && !Validation.License(currentRow.IsLicentieNull() ? string.Empty : currentRow.Licentie))
        {
          int num4 = (int) MessageBox.Show(ml.ml_string(211, "Loft number not correct."));
        }
        else
          CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new ReadRingCommand(currentRow.Licentie, currentRow.Naam, currentRow.Id));
      }
      else
      {
        int num5 = (int) MessageBox.Show(ml.ml_string(108, "Please select a record"));
      }
    }

    private void buttonGenerateRings_Click(object sender, EventArgs e)
    {
      try
      {
        BCEDataSet.AdressenRow currentRow = this.SaveAndGetCurrentRow();
        if (currentRow == null || new GenerateRingsForm(currentRow.Id).ShowDialog() == DialogResult.Cancel)
          return;
        this.adressenPigeonsBindingSource.ResetBindings(false);
        this.ValidateAllData(true, currentRow, true);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString(), Defines.MessageBoxCaption);
      }
    }

    private BCEDataSet.AdressenRow SaveAndGetCurrentRow()
    {
      if (this.bindingSourceAdressen.Current == null)
        return (BCEDataSet.AdressenRow) null;
      int position = this.adressenPigeonsBindingSource.Position;
      this.dataGridView1.EndEdit();
      this.bindingSourceAdressen.EndEdit();
      this.adressenPigeonsBindingSource.EndEdit();
      this.adressenPigeonsBindingSource.Position = position;
      return ((DataRowView) this.bindingSourceAdressen.Current).Row as BCEDataSet.AdressenRow;
    }

    private void maskedTextBoxCoordinateX_Leave(object sender, EventArgs e)
    {
      int num = Conversion.CoordinateToInt(this.maskedTextBoxCoordinateX.Text);
      this.textBoxCoordinateX.TextChanged -= new EventHandler(this.textBoxCoordinateX_TextChanged);
      this.textBoxCoordinateX.Text = num.ToString();
      this.textBoxCoordinateX.TextChanged += new EventHandler(this.textBoxCoordinateX_TextChanged);
    }

    private void maskedTextBoxCoordinateY_Leave(object sender, EventArgs e)
    {
      int num = Conversion.CoordinateToInt(this.maskedTextBoxCoordinateY.Text);
      this.textBoxCoordinateY.TextChanged -= new EventHandler(this.textBoxCoordinateY_TextChanged);
      this.textBoxCoordinateY.Text = num.ToString();
      this.textBoxCoordinateY.TextChanged += new EventHandler(this.textBoxCoordinateY_TextChanged);
    }

    private void textBoxCoordinateX_TextChanged(object sender, EventArgs e) => this.maskedTextBoxCoordinateX.Text = Conversion.CoordinateToString(this.textBoxCoordinateX.Text, true);

    private void textBoxCoordinateY_TextChanged(object sender, EventArgs e) => this.maskedTextBoxCoordinateY.Text = Conversion.CoordinateToString(this.textBoxCoordinateY.Text, true);

    private void maskedTextBoxCoordinateX_Enter(object sender, EventArgs e)
    {
      if (Conversion.CoordinateToInt((sender as MaskedTextBox).Text) == 0)
        (sender as MaskedTextBox).Text = "";
      (sender as MaskedTextBox).SelectAll();
    }

    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if (e.ColumnIndex == 0 && e.RowIndex != -1)
        e.Value = (object) (e.RowIndex + 1).ToString();
      if (e.ColumnIndex == 1 && e.RowIndex != -1 && e.Value is string)
        e.Value = (object) e.Value.ToString().ToUpper();
      if (e.ColumnIndex != 3 || e.RowIndex == -1 || !(e.Value is string))
        return;
      e.Value = (object) e.Value.ToString().ToUpper();
    }

    private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
    {
      this.dataGridView1.EndEdit();
      if (this.bindingSourceAdressen.Current != null)
        this.DeleteCurrentFancier(((DataRowView) this.bindingSourceAdressen.Current).Row as BCEDataSet.AdressenRow);
      if (BCEDatabase.DataSet.Adressen.Count != 0)
        return;
      BCEDatabase.DataSet.Adressen.AddAdressenRow("", "", "", "", "", "", "", "", "", "", 0, 0, "", ((DataRowView) this._clubsDataSource.Current).Row as BCEDataSet.ClubsRow, "", "", "", "", DateTime.MinValue, "", "", false);
    }

    public void DeleteCurrentFancier(BCEDataSet.AdressenRow row)
    {
      this.bindingSourceAdressen.EndEdit();
      this.adressenPigeonsBindingSource.EndEdit();
      if (row == null || MessageBox.Show(ml.ml_string(244, "Are you sure you want delete this fancier?"), Defines.MessageBoxCaption, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
        return;
      BCEDatabase.DataSet.Adressen.RemoveAdressenRow(row);
    }

    private void dataGridView1_Enter(object sender, EventArgs e)
    {
      if (BCEDatabase.DataSet.Adressen.Count == 0)
        this.bindingSourceAdressen.AddNew();
      this.bindingSourceAdressen.EndEdit();
    }

    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e) => this.dataGridView1.Invalidate();

    public static bool ValidatePigeonRow(
      BCEDataSet.PigeonsRow pigeonRow,
      bool checkOnDuplicates,
      bool checkElRing)
    {
      bool flag = false;
      pigeonRow.RowError = "";
      if (checkElRing && !Validation.ElRing(pigeonRow.ELRing))
      {
        pigeonRow.RowError = ml.ml_string(289, "ELRing not correct");
        flag = true;
      }
      if (!Validation.DBRing(pigeonRow.DBRing))
      {
        pigeonRow.RowError = ml.ml_string(288, "DBRing not correct");
        flag = true;
      }
      if (checkElRing && !Validation.ElRing(pigeonRow.ELRing) && !Validation.DBRing(pigeonRow.DBRing))
      {
        pigeonRow.RowError = ml.ml_string(287, "DBRing and ELRing not correct");
        flag = true;
      }
      if (!flag & checkOnDuplicates)
      {
        string dbRing = pigeonRow.DBRing;
        string elRing = pigeonRow.ELRing;
        foreach (BCEDataSet.PigeonsRow pigeonsRow in BCEDatabase.DataSet.Pigeons.Select("FancierID = " + pigeonRow.FancierID.ToString()))
        {
          if (pigeonsRow.RowState != DataRowState.Deleted && pigeonRow != pigeonsRow)
          {
            if (pigeonsRow.DBRing.Length > 0 && pigeonsRow.DBRing.Equals(dbRing, StringComparison.InvariantCultureIgnoreCase))
            {
              pigeonRow.RowError = ml.ml_string(286, "Duplicate DBRing");
              pigeonsRow.RowError = ml.ml_string(286, "Duplicate DBRing");
              flag = true;
            }
            if (checkElRing && pigeonsRow.ELRing.Length > 0 && pigeonsRow.ELRing.Equals(elRing, StringComparison.InvariantCultureIgnoreCase))
            {
              pigeonRow.RowError = ml.ml_string(285, "Duplicate ELRing");
              pigeonsRow.RowError = ml.ml_string(285, "Duplicate ELRing");
              flag = true;
            }
          }
        }
      }
      return !flag;
    }

    public bool ValidateAllData(
      bool bCheckRings,
      BCEDataSet.AdressenRow adresRow,
      bool checkElRing)
    {
      Cursor.Current = Cursors.WaitCursor;
      bool flag = false;
      this.errorProvider1.Clear();
      if (adresRow.IsLicentieNull() || !Validation.License(adresRow.Licentie))
      {
        this.errorProvider1.SetError((Control) this.maskedTextBoxLicense, ml.ml_string(211, "Loft number not correct."));
        this.errorProvider1.SetIconPadding((Control) this.maskedTextBoxLicense, -20);
        flag = true;
      }
      if (adresRow.IsNaamNull() || adresRow.Naam.Trim().Length == 0)
      {
        this.errorProvider1.SetError((Control) this.textBoxName, ml.ml_string(290, "Field must be filled in"));
        this.errorProvider1.SetIconPadding((Control) this.textBoxName, -20);
        flag = true;
      }
      if ((adresRow.IsGemeenteNull() || adresRow.Gemeente.Trim().Length == 0) && !Utils.IsCountry("JP"))
      {
        this.errorProvider1.SetError((Control) this.textBoxCity, ml.ml_string(290, "Field must be filled in"));
        this.errorProvider1.SetIconPadding((Control) this.textBoxCity, -20);
        flag = true;
      }
      if (bCheckRings)
      {
        foreach (BCEDataSet.PigeonsRow pigeonRow in BCEDatabase.DataSet.Pigeons.Select("FancierID = " + adresRow.Id.ToString()))
        {
          if (pigeonRow.RowState != DataRowState.Deleted && !FancierPage.ValidatePigeonRow(pigeonRow, !flag, checkElRing))
            flag = true;
        }
      }
      Cursor.Current = Cursors.Default;
      return !flag;
    }

    private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
    {
      if (!(((DataRowView) this.adressenPigeonsBindingSource.Current).Row is BCEDataSet.PigeonsRow row))
        return;
      BCEDataSet.PigeonsRow pigeonsRow1 = (BCEDataSet.PigeonsRow) null;
      string sort = string.Empty;
      if (this.dataGridView1.SortedColumn != null)
        sort = this.dataGridView1.SortedColumn.DataPropertyName;
      if (this.dataGridView1.SortOrder == SortOrder.Descending)
        sort += " desc";
      foreach (BCEDataSet.PigeonsRow pigeonsRow2 in BCEDatabase.DataSet.Pigeons.Select("FANCIERID=" + row.FancierID.ToString(), sort))
      {
        if (pigeonsRow2 != row)
          pigeonsRow1 = pigeonsRow2;
        else
          break;
      }
      string previousRing = pigeonsRow1 == null ? string.Empty : pigeonsRow1.DBRing;
      string str = Validation.MakeDBRing(row.DBRing, previousRing);
      if (!str.Equals(row.DBRing))
        row.DBRing = str;
      foreach (BCEDataSet.PigeonsRow pigeonRow in BCEDatabase.DataSet.Pigeons.Select(string.Format("DBRing <> '' and (DBRing = '{0}' or DBRing = '{1}') and fancierID = {2} ", (object) this._oldDBRing, (object) row.DBRing, (object) row.FancierID)))
      {
        if (pigeonRow.RowState != DataRowState.Deleted)
          FancierPage.ValidatePigeonRow(pigeonRow, true, true);
      }
      FancierPage.ValidatePigeonRow(row, true, true);
    }

    private void bindingSourceAdressen_PositionChanged(object sender, EventArgs e)
    {
      if (this.bindingSourceAdressen.Current == null)
        return;
      BCEDataSet.AdressenRow row = ((DataRowView) this.bindingSourceAdressen.Current).Row as BCEDataSet.AdressenRow;
      this.ValidateAllData(false, row, true);
      foreach (BCEDataSet.PigeonsRow error in BCEDatabase.DataSet.Pigeons.GetErrors())
      {
        if (row.RowState != DataRowState.Deleted && error.FancierID == row.Id)
          error.RowError = "";
      }
      this.EnableLicenceTextBox();
    }

    private void FancierPage_Load(object sender, EventArgs e) => this.bindingSourceAdressen_PositionChanged((object) null, (EventArgs) null);

    private void dataGridView1_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
    {
    }

    private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.ColumnIndex != 0 || e.RowIndex != -1)
        return;
      this.adressenPigeonsBindingSource.Sort = "";
    }

    public void TabPageActivated()
    {
      TextBox textBoxNaamUnicode = this.textBoxNaamUnicode;
      TextBox textBoxCityUnicode = this.textBoxCityUnicode;
      Label labelCityUnicode = this.labelCityUnicode;
      bool flag1;
      this.labelNaamUnicode.Visible = flag1 = Utils.IsCountry("KSA") || Utils.IsCountry("IQ") || Utils.IsCountry("RN");
      int num1;
      bool flag2 = (num1 = flag1 ? 1 : 0) != 0;
      labelCityUnicode.Visible = num1 != 0;
      int num2;
      bool flag3 = (num2 = flag2 ? 1 : 0) != 0;
      textBoxCityUnicode.Visible = num2 != 0;
      int num3 = flag3 ? 1 : 0;
      textBoxNaamUnicode.Visible = num3 != 0;
      this.labelRingFormat.Text = Validation.GetRingSample();
      if ((Validation.RingType == Validation.RingTypes.LongWithColor || Validation.RingType == Validation.RingTypes.PLRing || Validation.RingType == Validation.RingTypes.UKRing) && (!Utils.IsCountry("PT") && !Utils.IsCountry("ES")))
      {
        this.colordDataGridViewTextBoxColumn.Visible = true;
        if (Utils.IsCountry("PL"))
          this.panelLeft.Width = 490;
        else
          this.panelLeft.Width = 430;
      }
      else
      {
        this.colordDataGridViewTextBoxColumn.Visible = false;
        if (Utils.IsCountry("PL"))
          this.panelLeft.Width = 460;
        else
          this.panelLeft.Width = 400;
      }
      this.maskedTextBoxLicense.Mask = !Utils.IsCountry("BE") ? (!Utils.IsCountry("NL") ? (Utils.IsCountry("FR") || Utils.IsCountry("GR") || (Utils.IsCountry("PT") || Utils.IsCountry("ES")) ? "AAAAAAAA" : (Utils.IsCountry("UK") || Utils.IsCountry("IR") ? "AA00000" : (Utils.IsCountry("HU") || Utils.IsCountry("RO") || (Utils.IsCountry("MD") || Utils.IsCountry("KV")) ? "00A0000000" : "AAAAAAAAAA"))) : "0000-0000") : "000000/00";
      if (!Utils.IsCountry("BE"))
      {
        TextBox textBoxZipCode = this.textBoxZipCode;
        Point location = this.textBoxAddress.Location;
        int x = location.X + this.textBoxCity.Width + 4;
        location = this.textBoxZipCode.Location;
        int y = location.Y;
        Point point = new Point(x, y);
        textBoxZipCode.Location = point;
        this.textBoxCity.Location = new Point(this.textBoxAddress.Location.X, this.textBoxCity.Location.Y);
        this.maskedTextBoxCoordinateX.Mask = !Utils.IsFarEast() ? "#00 00 00.00" : "000 00 00.00";
        this.maskedTextBoxCoordinateY.Mask = "#00 00 00.00";
      }
      else
      {
        TextBox textBoxCity = this.textBoxCity;
        Point location = this.textBoxAddress.Location;
        int x = location.X + this.textBoxZipCode.Width + 4;
        location = this.textBoxCity.Location;
        int y = location.Y;
        Point point = new Point(x, y);
        textBoxCity.Location = point;
        this.textBoxZipCode.Location = new Point(this.textBoxAddress.Location.X, this.textBoxZipCode.Location.Y);
        this.maskedTextBoxCoordinateX.Mask = "00:00:00,0";
        this.maskedTextBoxCoordinateY.Mask = "00:00:00,0";
      }
      if (Utils.IsCountry("JP"))
      {
        this.labelLastSend.Visible = false;
        this.maskedTextBoxCoordinateX.Mask = "000 00 00.0";
        this.maskedTextBoxCoordinateY.Mask = "#00 00 00.0";
        this.labelAddress.Visible = false;
        this.textBoxAddress.Visible = false;
        this.labelCity.Visible = false;
        this.textBoxCity.Visible = false;
        this.textBoxZipCode.Visible = false;
        this.labelCountry.Visible = false;
        this.textBoxCountry.Visible = false;
        this.labelTelephone.Visible = false;
        this.textBoxTelephone.Visible = false;
        this.textBoxTelephone2.Visible = false;
        this.labelEmail.Visible = false;
        this.textBoxEmail.Visible = false;
        this.labelLastAccess.Visible = false;
        this.textBoxLastAccess.Visible = false;
        this.labelClub1.Visible = true;
        this.labelClub2.Visible = true;
        this.textBoxClub1.Visible = true;
        this.textBoxClub2.Visible = true;
        this.labelClub1.Location = this.labelCity.Location;
        this.textBoxClub1.Location = this.textBoxCity.Location;
        this.labelClub2.Location = this.labelCountry.Location;
        this.textBoxClub2.Location = this.textBoxCountry.Location;
        this.textBoxBankAccount.Width = this.textBoxAddress.Width;
        this.textBoxBankAccount.Location = this.textBoxAddress.Location;
        this.labelBankAccount.Location = this.labelAddress.Location;
        this.maskedTextBoxCoordinateX.Location = this.textBoxCoordinateY.Location;
        this.maskedTextBoxCoordinateY.Location = this.textBoxCoordinateX.Location;
      }
      this.OrderColumn.Visible = Utils.IsCountry("PL");
      this.toolStripButtonDistances.Visible = Settings.Default.UseDistanceDB;
    }

    private void bindingNavigatorAddNewItem1_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1.IsCurrentCellInEditMode)
      {
        this.dataGridView1.EndEdit();
        FancierPage.ValidatePigeonRow(((DataRowView) this.adressenPigeonsBindingSource.Current).Row as BCEDataSet.PigeonsRow, true, true);
      }
      this.bindingSourceAdressen.EndEdit();
      this.adressenPigeonsBindingSource.AddNew();
      this.dataGridView1.CurrentCell = this.dataGridView1.CurrentRow.Cells["dBRingDataGridViewTextBoxColumn"];
      this.dataGridView1.BeginEdit(true);
    }

    private void textBoxLicense_TextChanged(object sender, EventArgs e) => this.maskedTextBoxLicense.Text = this.textBoxLicense.Text;

    private void maskedTextBoxLicense_Enter(object sender, EventArgs e)
    {
    }

    private void maskedTextBoxLicense_Leave(object sender, EventArgs e)
    {
      if (!(sender is MaskedTextBox maskedTextBox))
        return;
      if (Validation.License(maskedTextBox.Text))
      {
        this.errorProvider1.SetError((Control) maskedTextBox, "");
      }
      else
      {
        this.errorProvider1.SetError((Control) maskedTextBox, ml.ml_string(211, "Loft number not correct."));
        this.errorProvider1.SetIconPadding((Control) maskedTextBox, -20);
      }
      this.textBoxLicense.Text = maskedTextBox.Text;
    }

    private void textBoxName_Leave(object sender, EventArgs e)
    {
      if (!(sender is TextBox textBox))
        return;
      if (textBox.Text.Trim().Length > 0)
      {
        this.errorProvider1.SetError((Control) textBox, "");
      }
      else
      {
        this.errorProvider1.SetError((Control) textBox, ml.ml_string(290, "Field must be filled in"));
        this.errorProvider1.SetIconPadding((Control) textBox, -20);
      }
    }

    private void toolStripButtonPrint_Click(object sender, EventArgs e)
    {
      this.bindingSourceAdressen.EndEdit();
      this.adressenPigeonsBindingSource.EndEdit();
      if (this.bindingSourceAdressen.Current == null)
        return;
      PrintHelper.PrintFancierDetail((((DataRowView) this.bindingSourceAdressen.Current).Row as BCEDataSet.AdressenRow).Id);
    }

    private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
      if (!(((DataRowView) this.adressenPigeonsBindingSource.Current).Row is BCEDataSet.PigeonsRow row))
        return;
      this._oldDBRing = row.DBRing;
    }

    public void EnableLicenceTextBox()
    {
      if (!Utils.IsCountry("BE"))
        return;
      this.maskedTextBoxLicense.Enabled = BCEDatabase.DataSet.Pigeons.Select(string.Format("FancierID = {0} and ELRing <> ''", (object) (((DataRowView) this.bindingSourceAdressen.Current).Row as BCEDataSet.AdressenRow).Id)).Length == 0;
      this.maskedTextBoxLicense.ReadOnly = !this.maskedTextBoxLicense.Enabled;
      this.textBoxLicense.Enabled = this.maskedTextBoxLicense.Enabled;
      this.textBoxLicense.ReadOnly = !this.maskedTextBoxLicense.Enabled;
    }

    private void bindingNavigatorDeleteItem1_Click(object sender, EventArgs e)
    {
      this.textBoxLicense.Focus();
      this.EnableLicenceTextBox();
      this.bindingSourceAdressen.EndEdit();
      this.dataGridView1.EndEdit();
      this.adressenPigeonsBindingSource.EndEdit();
      if (!(((DataRowView) this.adressenPigeonsBindingSource.Current).Row is BCEDataSet.PigeonsRow row))
        return;
      DataRow[] dataRowArray = BCEDatabase.DataSet.Pigeons.Select("Sel = true AND fancierID = " + row.FancierID.ToString());
      if ((uint) dataRowArray.Length > 0U)
      {
        if (MessageBox.Show(ml.ml_string(728, "This will delete all ring selected with the sel checkbox, are you sure?") + "  (" + dataRowArray.Length.ToString() + "/" + this.adressenPigeonsBindingSource.Count.ToString() + ")", Defines.MessageBoxCaption, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
          return;
        foreach (BCEDataSet.PigeonsRow row in dataRowArray)
          BCEDatabase.DataSet.Pigeons.RemovePigeonsRow(row);
      }
      else
      {
        if (MessageBox.Show(ml.ml_string(1255, "Delete the selected ring?"), Defines.MessageBoxCaption, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
          return;
        BCEDatabase.DataSet.Pigeons.RemovePigeonsRow(row);
      }
    }

    private void toolStripButtonCheckRing_Click(object sender, EventArgs e)
    {
      this.bindingSourceAdressen.EndEdit();
      this.adressenPigeonsBindingSource.EndEdit();
      if (this.bindingSourceAdressen.Current == null)
        return;
      CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new CheckRingCommand((((DataRowView) this.bindingSourceAdressen.Current).Row as BCEDataSet.AdressenRow).Naam));
      MainForm.Instance._checkRingForm = new CheckRingForm();
      int num = (int) MainForm.Instance._checkRingForm.ShowDialog();
      MainForm.Instance._checkRingForm = (CheckRingForm) null;
    }

    private void textBoxName_KeyPress(object sender, KeyPressEventArgs e) => e.KeyChar = Conversion.IsValidUnicode(e.KeyChar);

    private void textBoxName_TextChanged(object sender, EventArgs e) => this.errorProvider1.SetError(sender as Control, "");

    private void button1_Click(object sender, EventArgs e)
    {
      string text = "";
      foreach (char ch in this.textBoxName.Text)
        text = text + Convert.ToInt64(ch).ToString("X") + " ";
      int num = (int) MessageBox.Show(text);
    }

    private void toolStripButtonDistances_Click(object sender, EventArgs e)
    {
      if (this.bindingSourceAdressen.Current == null || !(((DataRowView) this.bindingSourceAdressen.Current).Row is BCEDataSet.AdressenRow row))
        return;
      int num = (int) new FlightDistanceForm(row.Id).ShowDialog();
    }

    private void toolStripButtonSelectAll_Click(object sender, EventArgs e)
    {
      BCEDataSet.AdressenRow currentRow = this.SaveAndGetCurrentRow();
      if (currentRow == null)
        return;
      int id = currentRow.Id;
      bool flag = false;
      foreach (BCEDataSet.PigeonsRow pigeonsRow in BCEDatabase.DataSet.Pigeons.Select("Sel = false and FancierID = " + id.ToString()))
      {
        if (pigeonsRow.RowState != DataRowState.Deleted)
        {
          pigeonsRow.Sel = true;
          flag = true;
        }
      }
      if (flag)
        return;
      foreach (BCEDataSet.PigeonsRow pigeonsRow in BCEDatabase.DataSet.Pigeons.Select("Sel = true and FancierID = " + id.ToString()))
      {
        if (pigeonsRow.RowState != DataRowState.Deleted)
          pigeonsRow.Sel = false;
      }
    }

    private void checkBoxManual_CheckedChanged(object sender, EventArgs e)
    {
      this.buttonCloud.Visible = this.checkBoxManual.Checked;
      this.toolStripButtonToBA.Visible = !this.checkBoxManual.Checked;
    }

    private void buttonCloud_Click(object sender, EventArgs e)
    {
      BCEDataSet.AdressenRow currentRow = this.SaveAndGetCurrentRow();
      if (currentRow == null)
        return;
      ManualPigeonsRequest request = new ManualPigeonsRequest()
      {
        CountryId = Settings.Default.Country,
        FancierLicense = currentRow.Licentie?.Replace("-", "").Replace("/", "").Trim(),
        UserName = Settings.Default.PASUserName,
        Password = Settings.Default.PASPassword
      };
      foreach (BCEDataSet.PigeonsRow pigeonsRow in BCEDatabase.DataSet.Pigeons.Select("FancierID = " + currentRow.Id.ToString()))
      {
        if (pigeonsRow.RowState != DataRowState.Deleted)
          request.Pigeons.Add(new ManualPigeonsRequest.Pigeon()
          {
            ChipCode = pigeonsRow.ELRing,
            Ring = pigeonsRow.DBRing
          });
      }
      int num = (int) MessageBox.Show(ManualPigeonsService.Upload(request));
    }

    private void textBoxSerial_TextChanged(object sender, EventArgs e)
    {
      if (!string.IsNullOrWhiteSpace(this.textBoxSerial.Text))
      {
        this.checkBoxManual.Checked = false;
        this.checkBoxManual.Visible = false;
      }
      else
        this.checkBoxManual.Visible = true;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FancierPage));
      DataGridViewCellStyle gridViewCellStyle = new DataGridViewCellStyle();
      this.labelAddress = new Label();
      this.labelCity = new Label();
      this.labelTelephone = new Label();
      this.labelCountry = new Label();
      this.labelEmail = new Label();
      this.labelLastAccess = new Label();
      this.labelName = new Label();
      this.labelBankAccount = new Label();
      this.bindingNavigatorAdressen = new BindingNavigator(this.components);
      this.bindingNavigatorAddNewItem = new ToolStripButton();
      this.bindingSourceAdressen = new BindingSource(this.components);
      this.bindingSourceClubsLocal = new BindingSource(this.components);
      this.bceDataSetLocal = new BCEDataSet();
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
      this.toolStripButtonToBA = new ToolStripButton();
      this.toolStripButtonFromBA = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.toolStripButtonPrint = new ToolStripButton();
      this.toolStripButtonDistances = new ToolStripButton();
      this.textBoxName = new TextBox();
      this.textBoxAddress = new TextBox();
      this.textBoxZipCode = new TextBox();
      this.textBoxCity = new TextBox();
      this.dataGridView1 = new DataGridView();
      this.Nr = new DataGridViewTextBoxColumn();
      this.dBRingDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.FEMALE = new DataGridViewCheckBoxColumn();
      this.eLRingDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.colordDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.Sel = new DataGridViewCheckBoxColumn();
      this.OrderColumn = new DataGridViewTextBoxColumn();
      this.adressenPigeonsBindingSource = new BindingSource(this.components);
      this.bindingNavigatorPigeons = new BindingNavigator(this.components);
      this.bindingNavigatorCountItem1 = new ToolStripLabel();
      this.bindingNavigatorSeparator3 = new ToolStripSeparator();
      this.bindingNavigatorPositionItem1 = new ToolStripTextBox();
      this.bindingNavigatorSeparator4 = new ToolStripSeparator();
      this.bindingNavigatorAddNewItem1 = new ToolStripButton();
      this.bindingNavigatorDeleteItem1 = new ToolStripButton();
      this.bindingNavigatorSeparator5 = new ToolStripSeparator();
      this.toolStripButtonReadRing = new ToolStripButton();
      this.buttonGenerateRings = new ToolStripButton();
      this.toolStripButtonCheckRing = new ToolStripButton();
      this.toolStripButtonSelectAll = new ToolStripButton();
      this.panelLeft = new Panel();
      this.panel1 = new Panel();
      this.labelRingFormat = new Label();
      this.textBoxCoordinateY = new TextBox();
      this.textBoxCoordinateX = new TextBox();
      this.textBoxLicense = new TextBox();
      this.textBoxTelephone2 = new TextBox();
      this.textBoxTelephone = new TextBox();
      this.textBoxNotes = new TextBox();
      this.textBoxCountry = new TextBox();
      this.textBoxEmail = new TextBox();
      this.textBoxBankAccount = new TextBox();
      this.textBoxSerial = new TextBox();
      this.textBoxLastAccess = new TextBox();
      this.maskedTextBoxCoordinateX = new MaskedTextBox();
      this.maskedTextBoxCoordinateY = new MaskedTextBox();
      this.errorProvider1 = new ErrorProvider(this.components);
      this.maskedTextBoxLicense = new MaskedTextBox();
      this.button1 = new Button();
      this.textBoxClub1 = new TextBox();
      this.labelClub1 = new Label();
      this.textBoxClub2 = new TextBox();
      this.labelClub2 = new Label();
      this.labelLastSend = new Label();
      this.labelNaamUnicode = new Label();
      this.textBoxNaamUnicode = new TextBox();
      this.textBoxCityUnicode = new TextBox();
      this.labelCityUnicode = new Label();
      this.checkBoxManual = new CheckBox();
      this.buttonCloud = new Button();
      Label label1 = new Label();
      Label label2 = new Label();
      Label label3 = new Label();
      Label label4 = new Label();
      this.bindingNavigatorAdressen.BeginInit();
      this.bindingNavigatorAdressen.SuspendLayout();
      ((ISupportInitialize) this.bindingSourceAdressen).BeginInit();
      ((ISupportInitialize) this.bindingSourceClubsLocal).BeginInit();
      this.bceDataSetLocal.BeginInit();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((ISupportInitialize) this.adressenPigeonsBindingSource).BeginInit();
      this.bindingNavigatorPigeons.BeginInit();
      this.bindingNavigatorPigeons.SuspendLayout();
      this.panelLeft.SuspendLayout();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.errorProvider1).BeginInit();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) label1, "labelCoordinates");
      label1.Name = "labelCoordinates";
      componentResourceManager.ApplyResources((object) label2, "labelLicense");
      label2.Name = "labelLicense";
      componentResourceManager.ApplyResources((object) label3, "labelSlash");
      label3.Name = "labelSlash";
      componentResourceManager.ApplyResources((object) label4, "labelSerial");
      label4.Name = "labelSerial";
      componentResourceManager.ApplyResources((object) this.labelAddress, "labelAddress");
      this.labelAddress.Name = "labelAddress";
      componentResourceManager.ApplyResources((object) this.labelCity, "labelCity");
      this.labelCity.Name = "labelCity";
      componentResourceManager.ApplyResources((object) this.labelTelephone, "labelTelephone");
      this.labelTelephone.Name = "labelTelephone";
      componentResourceManager.ApplyResources((object) this.labelCountry, "labelCountry");
      this.labelCountry.Name = "labelCountry";
      componentResourceManager.ApplyResources((object) this.labelEmail, "labelEmail");
      this.labelEmail.Name = "labelEmail";
      componentResourceManager.ApplyResources((object) this.labelLastAccess, "labelLastAccess");
      this.labelLastAccess.Name = "labelLastAccess";
      componentResourceManager.ApplyResources((object) this.labelName, "labelName");
      this.labelName.Name = "labelName";
      componentResourceManager.ApplyResources((object) this.labelBankAccount, "labelBankAccount");
      this.labelBankAccount.Name = "labelBankAccount";
      this.bindingNavigatorAdressen.AddNewItem = (ToolStripItem) this.bindingNavigatorAddNewItem;
      this.bindingNavigatorAdressen.BindingSource = this.bindingSourceAdressen;
      this.bindingNavigatorAdressen.CountItem = (ToolStripItem) this.bindingNavigatorCountItem;
      this.bindingNavigatorAdressen.DeleteItem = (ToolStripItem) null;
      this.bindingNavigatorAdressen.Items.AddRange(new ToolStripItem[17]
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
        (ToolStripItem) this.toolStripButtonToBA,
        (ToolStripItem) this.toolStripButtonFromBA,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.toolStripButtonPrint,
        (ToolStripItem) this.toolStripButtonDistances
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
      this.bindingSourceAdressen.DataMember = "Clubs_Adressen";
      this.bindingSourceAdressen.DataSource = (object) this.bindingSourceClubsLocal;
      this.bindingSourceAdressen.Sort = "Naam";
      this.bindingSourceAdressen.PositionChanged += new EventHandler(this.bindingSourceAdressen_PositionChanged);
      this.bindingSourceClubsLocal.DataMember = "Clubs";
      this.bindingSourceClubsLocal.DataSource = (object) this.bceDataSetLocal;
      this.bceDataSetLocal.DataSetName = "BCEDataSet";
      this.bceDataSetLocal.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
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
      this.toolStripButtonToBA.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonToBA.Image = (Image) Resources.ToBA;
      componentResourceManager.ApplyResources((object) this.toolStripButtonToBA, "toolStripButtonToBA");
      this.toolStripButtonToBA.Name = "toolStripButtonToBA";
      this.toolStripButtonToBA.Click += new EventHandler(this.toolStripButtonToBA_Click);
      this.toolStripButtonFromBA.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonFromBA.Image = (Image) Resources.FromBA;
      componentResourceManager.ApplyResources((object) this.toolStripButtonFromBA, "toolStripButtonFromBA");
      this.toolStripButtonFromBA.Name = "toolStripButtonFromBA";
      this.toolStripButtonFromBA.Click += new EventHandler(this.toolStripButtonFromBA_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator2, "toolStripSeparator2");
      this.toolStripButtonPrint.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonPrint.Image = (Image) Resources.Print;
      componentResourceManager.ApplyResources((object) this.toolStripButtonPrint, "toolStripButtonPrint");
      this.toolStripButtonPrint.Name = "toolStripButtonPrint";
      this.toolStripButtonPrint.Click += new EventHandler(this.toolStripButtonPrint_Click);
      this.toolStripButtonDistances.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonDistances.Image = (Image) Resources.DefaultFlights;
      componentResourceManager.ApplyResources((object) this.toolStripButtonDistances, "toolStripButtonDistances");
      this.toolStripButtonDistances.Name = "toolStripButtonDistances";
      this.toolStripButtonDistances.Click += new EventHandler(this.toolStripButtonDistances_Click);
      this.textBoxName.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.textBoxName.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "Naam", true));
      componentResourceManager.ApplyResources((object) this.textBoxName, "textBoxName");
      this.textBoxName.Name = "textBoxName";
      this.textBoxName.TextChanged += new EventHandler(this.textBoxName_TextChanged);
      this.textBoxName.KeyPress += new KeyPressEventHandler(this.textBoxName_KeyPress);
      this.textBoxName.Leave += new EventHandler(this.textBoxName_Leave);
      this.textBoxAddress.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.textBoxAddress.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "Adres", true));
      componentResourceManager.ApplyResources((object) this.textBoxAddress, "textBoxAddress");
      this.textBoxAddress.Name = "textBoxAddress";
      this.textBoxZipCode.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.textBoxZipCode.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "Postcode", true));
      componentResourceManager.ApplyResources((object) this.textBoxZipCode, "textBoxZipCode");
      this.textBoxZipCode.Name = "textBoxZipCode";
      this.textBoxCity.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.textBoxCity.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "Gemeente", true));
      componentResourceManager.ApplyResources((object) this.textBoxCity, "textBoxCity");
      this.textBoxCity.Name = "textBoxCity";
      this.textBoxCity.TextChanged += new EventHandler(this.textBoxName_TextChanged);
      this.textBoxCity.Leave += new EventHandler(this.textBoxName_Leave);
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.Nr, (DataGridViewColumn) this.dBRingDataGridViewTextBoxColumn, (DataGridViewColumn) this.FEMALE, (DataGridViewColumn) this.eLRingDataGridViewTextBoxColumn, (DataGridViewColumn) this.colordDataGridViewTextBoxColumn, (DataGridViewColumn) this.Sel, (DataGridViewColumn) this.OrderColumn);
      this.dataGridView1.DataSource = (object) this.adressenPigeonsBindingSource;
      componentResourceManager.ApplyResources((object) this.dataGridView1, "dataGridView1");
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.TabStop = false;
      this.dataGridView1.CellEnter += new DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
      this.dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
      this.dataGridView1.CellMouseClick += new DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
      this.dataGridView1.CellValidated += new DataGridViewCellEventHandler(this.dataGridView1_CellValidated);
      this.dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
      this.dataGridView1.ColumnSortModeChanged += new DataGridViewColumnEventHandler(this.dataGridView1_ColumnSortModeChanged);
      this.dataGridView1.Enter += new EventHandler(this.dataGridView1_Enter);
      this.Nr.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      this.Nr.Frozen = true;
      componentResourceManager.ApplyResources((object) this.Nr, "Nr");
      this.Nr.Name = "Nr";
      this.Nr.ReadOnly = true;
      this.Nr.Resizable = DataGridViewTriState.False;
      this.Nr.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dBRingDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.dBRingDataGridViewTextBoxColumn.DataPropertyName = "DBRing";
      this.dBRingDataGridViewTextBoxColumn.Frozen = true;
      componentResourceManager.ApplyResources((object) this.dBRingDataGridViewTextBoxColumn, "dBRingDataGridViewTextBoxColumn");
      this.dBRingDataGridViewTextBoxColumn.Name = "dBRingDataGridViewTextBoxColumn";
      this.FEMALE.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      this.FEMALE.DataPropertyName = "FEMALE";
      this.FEMALE.Frozen = true;
      componentResourceManager.ApplyResources((object) this.FEMALE, "FEMALE");
      this.FEMALE.Name = "FEMALE";
      this.FEMALE.SortMode = DataGridViewColumnSortMode.Automatic;
      this.eLRingDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.eLRingDataGridViewTextBoxColumn.DataPropertyName = "ELRing";
      gridViewCellStyle.ForeColor = Color.Gray;
      this.eLRingDataGridViewTextBoxColumn.DefaultCellStyle = gridViewCellStyle;
      this.eLRingDataGridViewTextBoxColumn.Frozen = true;
      componentResourceManager.ApplyResources((object) this.eLRingDataGridViewTextBoxColumn, "eLRingDataGridViewTextBoxColumn");
      this.eLRingDataGridViewTextBoxColumn.Name = "eLRingDataGridViewTextBoxColumn";
      this.eLRingDataGridViewTextBoxColumn.ReadOnly = true;
      this.colordDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
      this.colordDataGridViewTextBoxColumn.DataPropertyName = "Color";
      this.colordDataGridViewTextBoxColumn.Frozen = true;
      componentResourceManager.ApplyResources((object) this.colordDataGridViewTextBoxColumn, "colordDataGridViewTextBoxColumn");
      this.colordDataGridViewTextBoxColumn.Name = "colordDataGridViewTextBoxColumn";
      this.Sel.DataPropertyName = "Sel";
      this.Sel.Frozen = true;
      componentResourceManager.ApplyResources((object) this.Sel, "Sel");
      this.Sel.Name = "Sel";
      this.OrderColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.OrderColumn.DataPropertyName = "Order";
      this.OrderColumn.FillWeight = 60f;
      this.OrderColumn.Frozen = true;
      componentResourceManager.ApplyResources((object) this.OrderColumn, "OrderColumn");
      this.OrderColumn.Name = "OrderColumn";
      this.adressenPigeonsBindingSource.AllowNew = true;
      this.adressenPigeonsBindingSource.DataMember = "Adressen_Pigeons";
      this.adressenPigeonsBindingSource.DataSource = (object) this.bindingSourceAdressen;
      this.adressenPigeonsBindingSource.Sort = "";
      this.bindingNavigatorPigeons.AddNewItem = (ToolStripItem) null;
      this.bindingNavigatorPigeons.BindingSource = this.adressenPigeonsBindingSource;
      this.bindingNavigatorPigeons.CountItem = (ToolStripItem) this.bindingNavigatorCountItem1;
      this.bindingNavigatorPigeons.DeleteItem = (ToolStripItem) null;
      this.bindingNavigatorPigeons.Items.AddRange(new ToolStripItem[11]
      {
        (ToolStripItem) this.bindingNavigatorSeparator3,
        (ToolStripItem) this.bindingNavigatorPositionItem1,
        (ToolStripItem) this.bindingNavigatorCountItem1,
        (ToolStripItem) this.bindingNavigatorSeparator4,
        (ToolStripItem) this.bindingNavigatorAddNewItem1,
        (ToolStripItem) this.bindingNavigatorDeleteItem1,
        (ToolStripItem) this.bindingNavigatorSeparator5,
        (ToolStripItem) this.toolStripButtonReadRing,
        (ToolStripItem) this.buttonGenerateRings,
        (ToolStripItem) this.toolStripButtonCheckRing,
        (ToolStripItem) this.toolStripButtonSelectAll
      });
      componentResourceManager.ApplyResources((object) this.bindingNavigatorPigeons, "bindingNavigatorPigeons");
      this.bindingNavigatorPigeons.MoveFirstItem = (ToolStripItem) null;
      this.bindingNavigatorPigeons.MoveLastItem = (ToolStripItem) null;
      this.bindingNavigatorPigeons.MoveNextItem = (ToolStripItem) null;
      this.bindingNavigatorPigeons.MovePreviousItem = (ToolStripItem) null;
      this.bindingNavigatorPigeons.Name = "bindingNavigatorPigeons";
      this.bindingNavigatorPigeons.PositionItem = (ToolStripItem) this.bindingNavigatorPositionItem1;
      this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
      componentResourceManager.ApplyResources((object) this.bindingNavigatorCountItem1, "bindingNavigatorCountItem1");
      this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
      componentResourceManager.ApplyResources((object) this.bindingNavigatorSeparator3, "bindingNavigatorSeparator3");
      componentResourceManager.ApplyResources((object) this.bindingNavigatorPositionItem1, "bindingNavigatorPositionItem1");
      this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
      this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
      componentResourceManager.ApplyResources((object) this.bindingNavigatorSeparator4, "bindingNavigatorSeparator4");
      this.bindingNavigatorAddNewItem1.DisplayStyle = ToolStripItemDisplayStyle.Image;
      componentResourceManager.ApplyResources((object) this.bindingNavigatorAddNewItem1, "bindingNavigatorAddNewItem1");
      this.bindingNavigatorAddNewItem1.Name = "bindingNavigatorAddNewItem1";
      this.bindingNavigatorAddNewItem1.Click += new EventHandler(this.bindingNavigatorAddNewItem1_Click);
      this.bindingNavigatorDeleteItem1.DisplayStyle = ToolStripItemDisplayStyle.Image;
      componentResourceManager.ApplyResources((object) this.bindingNavigatorDeleteItem1, "bindingNavigatorDeleteItem1");
      this.bindingNavigatorDeleteItem1.Name = "bindingNavigatorDeleteItem1";
      this.bindingNavigatorDeleteItem1.Click += new EventHandler(this.bindingNavigatorDeleteItem1_Click);
      this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
      componentResourceManager.ApplyResources((object) this.bindingNavigatorSeparator5, "bindingNavigatorSeparator5");
      this.toolStripButtonReadRing.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonReadRing.Image = (Image) Resources.ReadRing;
      componentResourceManager.ApplyResources((object) this.toolStripButtonReadRing, "toolStripButtonReadRing");
      this.toolStripButtonReadRing.Name = "toolStripButtonReadRing";
      this.toolStripButtonReadRing.Click += new EventHandler(this.toolStripButtonReadRing_Click);
      this.buttonGenerateRings.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonGenerateRings.Image = (Image) Resources.GenerateRings;
      componentResourceManager.ApplyResources((object) this.buttonGenerateRings, "buttonGenerateRings");
      this.buttonGenerateRings.Name = "buttonGenerateRings";
      this.buttonGenerateRings.Click += new EventHandler(this.buttonGenerateRings_Click);
      this.toolStripButtonCheckRing.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonCheckRing.Image = (Image) Resources.CheckRing;
      componentResourceManager.ApplyResources((object) this.toolStripButtonCheckRing, "toolStripButtonCheckRing");
      this.toolStripButtonCheckRing.Name = "toolStripButtonCheckRing";
      this.toolStripButtonCheckRing.Click += new EventHandler(this.toolStripButtonCheckRing_Click);
      this.toolStripButtonSelectAll.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonSelectAll.Image = (Image) Resources.SelectAll;
      componentResourceManager.ApplyResources((object) this.toolStripButtonSelectAll, "toolStripButtonSelectAll");
      this.toolStripButtonSelectAll.Name = "toolStripButtonSelectAll";
      this.toolStripButtonSelectAll.Click += new EventHandler(this.toolStripButtonSelectAll_Click);
      this.panelLeft.Controls.Add((Control) this.dataGridView1);
      this.panelLeft.Controls.Add((Control) this.panel1);
      this.panelLeft.Controls.Add((Control) this.bindingNavigatorPigeons);
      componentResourceManager.ApplyResources((object) this.panelLeft, "panelLeft");
      this.panelLeft.Name = "panelLeft";
      this.panel1.BackColor = SystemColors.ActiveCaption;
      this.panel1.Controls.Add((Control) this.labelRingFormat);
      componentResourceManager.ApplyResources((object) this.panel1, "panel1");
      this.panel1.Name = "panel1";
      componentResourceManager.ApplyResources((object) this.labelRingFormat, "labelRingFormat");
      this.labelRingFormat.BackColor = Color.Transparent;
      this.labelRingFormat.ForeColor = SystemColors.Control;
      this.labelRingFormat.Name = "labelRingFormat";
      this.textBoxCoordinateY.BackColor = Color.White;
      this.textBoxCoordinateY.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "KWY", true));
      componentResourceManager.ApplyResources((object) this.textBoxCoordinateY, "textBoxCoordinateY");
      this.textBoxCoordinateY.Name = "textBoxCoordinateY";
      this.textBoxCoordinateY.TabStop = false;
      this.textBoxCoordinateY.TextChanged += new EventHandler(this.textBoxCoordinateY_TextChanged);
      this.textBoxCoordinateX.BackColor = Color.White;
      this.textBoxCoordinateX.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "KWX", true));
      componentResourceManager.ApplyResources((object) this.textBoxCoordinateX, "textBoxCoordinateX");
      this.textBoxCoordinateX.Name = "textBoxCoordinateX";
      this.textBoxCoordinateX.TabStop = false;
      this.textBoxCoordinateX.TextChanged += new EventHandler(this.textBoxCoordinateX_TextChanged);
      this.textBoxLicense.BackColor = SystemColors.Window;
      this.textBoxLicense.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "Licentie", true));
      componentResourceManager.ApplyResources((object) this.textBoxLicense, "textBoxLicense");
      this.textBoxLicense.Name = "textBoxLicense";
      this.textBoxLicense.TabStop = false;
      this.textBoxLicense.TextChanged += new EventHandler(this.textBoxLicense_TextChanged);
      this.textBoxTelephone2.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "Fax", true));
      componentResourceManager.ApplyResources((object) this.textBoxTelephone2, "textBoxTelephone2");
      this.textBoxTelephone2.Name = "textBoxTelephone2";
      this.textBoxTelephone.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "Telefoon", true));
      componentResourceManager.ApplyResources((object) this.textBoxTelephone, "textBoxTelephone");
      this.textBoxTelephone.Name = "textBoxTelephone";
      this.textBoxNotes.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "Notes", true));
      componentResourceManager.ApplyResources((object) this.textBoxNotes, "textBoxNotes");
      this.textBoxNotes.Name = "textBoxNotes";
      this.textBoxCountry.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "Country", true));
      componentResourceManager.ApplyResources((object) this.textBoxCountry, "textBoxCountry");
      this.textBoxCountry.Name = "textBoxCountry";
      this.textBoxEmail.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "Email", true));
      componentResourceManager.ApplyResources((object) this.textBoxEmail, "textBoxEmail");
      this.textBoxEmail.Name = "textBoxEmail";
      this.textBoxBankAccount.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "Bankrekening", true));
      componentResourceManager.ApplyResources((object) this.textBoxBankAccount, "textBoxBankAccount");
      this.textBoxBankAccount.Name = "textBoxBankAccount";
      this.textBoxSerial.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.textBoxSerial.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "Serial", true));
      componentResourceManager.ApplyResources((object) this.textBoxSerial, "textBoxSerial");
      this.textBoxSerial.Name = "textBoxSerial";
      this.textBoxSerial.ReadOnly = true;
      this.textBoxSerial.TextChanged += new EventHandler(this.textBoxSerial_TextChanged);
      this.textBoxLastAccess.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "Laatste", true));
      componentResourceManager.ApplyResources((object) this.textBoxLastAccess, "textBoxLastAccess");
      this.textBoxLastAccess.Name = "textBoxLastAccess";
      this.maskedTextBoxCoordinateX.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      componentResourceManager.ApplyResources((object) this.maskedTextBoxCoordinateX, "maskedTextBoxCoordinateX");
      this.maskedTextBoxCoordinateX.Name = "maskedTextBoxCoordinateX";
      this.maskedTextBoxCoordinateX.Enter += new EventHandler(this.maskedTextBoxCoordinateX_Enter);
      this.maskedTextBoxCoordinateX.Leave += new EventHandler(this.maskedTextBoxCoordinateX_Leave);
      this.maskedTextBoxCoordinateY.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      componentResourceManager.ApplyResources((object) this.maskedTextBoxCoordinateY, "maskedTextBoxCoordinateY");
      this.maskedTextBoxCoordinateY.Name = "maskedTextBoxCoordinateY";
      this.maskedTextBoxCoordinateY.Enter += new EventHandler(this.maskedTextBoxCoordinateX_Enter);
      this.maskedTextBoxCoordinateY.Leave += new EventHandler(this.maskedTextBoxCoordinateY_Leave);
      this.errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
      this.errorProvider1.ContainerControl = (ContainerControl) this;
      this.maskedTextBoxLicense.AsciiOnly = true;
      this.maskedTextBoxLicense.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      componentResourceManager.ApplyResources((object) this.maskedTextBoxLicense, "maskedTextBoxLicense");
      this.maskedTextBoxLicense.Name = "maskedTextBoxLicense";
      this.maskedTextBoxLicense.TextChanged += new EventHandler(this.textBoxName_TextChanged);
      this.maskedTextBoxLicense.Enter += new EventHandler(this.maskedTextBoxLicense_Enter);
      this.maskedTextBoxLicense.Leave += new EventHandler(this.maskedTextBoxLicense_Leave);
      componentResourceManager.ApplyResources((object) this.button1, "button1");
      this.button1.Name = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.textBoxClub1.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "Club1", true));
      componentResourceManager.ApplyResources((object) this.textBoxClub1, "textBoxClub1");
      this.textBoxClub1.Name = "textBoxClub1";
      componentResourceManager.ApplyResources((object) this.labelClub1, "labelClub1");
      this.labelClub1.Name = "labelClub1";
      this.textBoxClub2.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "Club2", true));
      componentResourceManager.ApplyResources((object) this.textBoxClub2, "textBoxClub2");
      this.textBoxClub2.Name = "textBoxClub2";
      componentResourceManager.ApplyResources((object) this.labelClub2, "labelClub2");
      this.labelClub2.Name = "labelClub2";
      componentResourceManager.ApplyResources((object) this.labelLastSend, "labelLastSend");
      this.labelLastSend.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "LastSendedToBA", true));
      this.labelLastSend.Name = "labelLastSend";
      componentResourceManager.ApplyResources((object) this.labelNaamUnicode, "labelNaamUnicode");
      this.labelNaamUnicode.Name = "labelNaamUnicode";
      this.textBoxNaamUnicode.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.textBoxNaamUnicode.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "NaamUnicode", true));
      componentResourceManager.ApplyResources((object) this.textBoxNaamUnicode, "textBoxNaamUnicode");
      this.textBoxNaamUnicode.Name = "textBoxNaamUnicode";
      this.textBoxCityUnicode.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.textBoxCityUnicode.DataBindings.Add(new Binding("Text", (object) this.bindingSourceAdressen, "GemeenteUnicode", true));
      componentResourceManager.ApplyResources((object) this.textBoxCityUnicode, "textBoxCityUnicode");
      this.textBoxCityUnicode.Name = "textBoxCityUnicode";
      componentResourceManager.ApplyResources((object) this.labelCityUnicode, "labelCityUnicode");
      this.labelCityUnicode.Name = "labelCityUnicode";
      componentResourceManager.ApplyResources((object) this.checkBoxManual, "checkBoxManual");
      this.checkBoxManual.DataBindings.Add(new Binding("Checked", (object) this.bindingSourceAdressen, "IsManual", true));
      this.checkBoxManual.Name = "checkBoxManual";
      this.checkBoxManual.UseVisualStyleBackColor = true;
      this.checkBoxManual.CheckedChanged += new EventHandler(this.checkBoxManual_CheckedChanged);
      componentResourceManager.ApplyResources((object) this.buttonCloud, "buttonCloud");
      this.buttonCloud.Name = "buttonCloud";
      this.buttonCloud.UseVisualStyleBackColor = true;
      this.buttonCloud.Click += new EventHandler(this.buttonCloud_Click);
      this.AutoScaleMode = AutoScaleMode.None;
      this.Controls.Add((Control) this.buttonCloud);
      this.Controls.Add((Control) this.checkBoxManual);
      this.Controls.Add((Control) this.labelNaamUnicode);
      this.Controls.Add((Control) this.textBoxNaamUnicode);
      this.Controls.Add((Control) this.labelLastSend);
      this.Controls.Add((Control) this.labelClub2);
      this.Controls.Add((Control) this.labelClub1);
      this.Controls.Add((Control) this.textBoxClub2);
      this.Controls.Add((Control) this.textBoxClub1);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.maskedTextBoxLicense);
      this.Controls.Add((Control) this.maskedTextBoxCoordinateY);
      this.Controls.Add((Control) this.maskedTextBoxCoordinateX);
      this.Controls.Add((Control) this.labelLastAccess);
      this.Controls.Add((Control) label4);
      this.Controls.Add((Control) this.textBoxLastAccess);
      this.Controls.Add((Control) this.textBoxSerial);
      this.Controls.Add((Control) label3);
      this.Controls.Add((Control) this.labelBankAccount);
      this.Controls.Add((Control) this.labelEmail);
      this.Controls.Add((Control) this.labelTelephone);
      this.Controls.Add((Control) label1);
      this.Controls.Add((Control) this.textBoxBankAccount);
      this.Controls.Add((Control) this.textBoxEmail);
      this.Controls.Add((Control) this.textBoxTelephone);
      this.Controls.Add((Control) this.textBoxTelephone2);
      this.Controls.Add((Control) this.textBoxNotes);
      this.Controls.Add((Control) this.textBoxCoordinateX);
      this.Controls.Add((Control) this.textBoxCoordinateY);
      this.Controls.Add((Control) label2);
      this.Controls.Add((Control) this.labelName);
      this.Controls.Add((Control) this.labelCityUnicode);
      this.Controls.Add((Control) this.labelCity);
      this.Controls.Add((Control) this.textBoxCityUnicode);
      this.Controls.Add((Control) this.textBoxCity);
      this.Controls.Add((Control) this.textBoxZipCode);
      this.Controls.Add((Control) this.labelCountry);
      this.Controls.Add((Control) this.labelAddress);
      this.Controls.Add((Control) this.textBoxCountry);
      this.Controls.Add((Control) this.textBoxAddress);
      this.Controls.Add((Control) this.textBoxLicense);
      this.Controls.Add((Control) this.textBoxName);
      this.Controls.Add((Control) this.bindingNavigatorAdressen);
      this.Controls.Add((Control) this.panelLeft);
      this.Name = nameof (FancierPage);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Load += new EventHandler(this.FancierPage_Load);
      this.bindingNavigatorAdressen.EndInit();
      this.bindingNavigatorAdressen.ResumeLayout(false);
      this.bindingNavigatorAdressen.PerformLayout();
      ((ISupportInitialize) this.bindingSourceAdressen).EndInit();
      ((ISupportInitialize) this.bindingSourceClubsLocal).EndInit();
      this.bceDataSetLocal.EndInit();
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((ISupportInitialize) this.adressenPigeonsBindingSource).EndInit();
      this.bindingNavigatorPigeons.EndInit();
      this.bindingNavigatorPigeons.ResumeLayout(false);
      this.bindingNavigatorPigeons.PerformLayout();
      this.panelLeft.ResumeLayout(false);
      this.panelLeft.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.errorProvider1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
