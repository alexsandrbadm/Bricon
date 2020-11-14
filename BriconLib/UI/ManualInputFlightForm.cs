// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.ManualInputFlightForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.BCE;
using BriconLib.Data;
using BriconLib.Other;
using BriconLib.PrintManager;
using BriconLib.Properties;
using MultiLang;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BriconLib.UI
{
  public class ManualInputFlightForm : Form
  {
    private string _previousRing = string.Empty;
    private string _extension = ".xml";
    private string _readoutFolder;
    private IContainer components;
    private Button buttonOK;
    private Label label1;
    private Label labelDistance;
    private NumericUpDown numericUpDownBasketed;
    private GroupBox groupBox3;
    private Label labelFancier;
    private ComboBox comboBoxFancier;
    private BindingSource adressenBindingSource;
    private BindingSource informationBindingSource;
    private ManualReadOut manualReadOut;
    private DataGridView dataGridView1;
    private BindingSource pigeonsBindingSource;
    private BindingSource manualReadOutBindingSource;
    private GroupBox groupBoxManualInput;
    private Button buttonClear;
    private DateTimePicker dateTimePicker1;
    private Label labelClubID;
    private Label label5;
    private Label labelVluchtID;
    private Label labelFileName;
    public TextBox textBoxFlightID;
    public TextBox textBoxClubID;
    private Label labelUsedFileName;
    private ListView listView1;
    private Label label6;
    private GroupBox groupBox2;
    private Button buttonClose;
    private ImageList imageList1;
    private Button buttonDelete;
    private Button buttonView;
    private DateTimePicker dateTimePickerTimeSetDate;
    private Label labelTimeSet;
    private Label labelCoordinates;
    private Label labelCoordinatesHeader;
    private DateTimePicker dateTimePickerClockDate;
    private Label labelClockTime;
    private DateTimePicker dateTimePickerStrikeOfDate;
    private Label labelStrikeOf;
    private Label labelUnit2;
    private Label labelUnit;
    private NumericUpDown numericUpDownMeter;
    private NumericUpDown numericUpDownDistance;
    private DataGridViewTextBoxColumn fedBandDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn Position;
    private DataGridViewTextBoxColumn TeamNbr;
    private DateTimePicker dateTimePickerTimeSetClockDate;
    private Label label2;
    private Label labelTimeZoneHours;
    private Label labelTimeZone;
    private NumericUpDown numericUpDownTimeZone;

    public ManualInputFlightForm()
    {
      this._readoutFolder = "c:\\ReadOuts\\" + DateTime.Now.Year.ToString() + "\\";
      this.InitializeComponent();
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      this.informationBindingSource.EndEdit();
      this.manualReadOut.Information[0].Distance = this.numericUpDownDistance.Value + this.numericUpDownMeter.Value / 1760M;
      this.manualReadOut.Information[0].DistanceString = Utils.GetDistanceString(this.numericUpDownDistance.Value, this.numericUpDownMeter.Value);
      this.comboBoxFancier.Focus();
      if (!Validation.ClubID(this.textBoxClubID.Text))
      {
        int num1 = (int) MessageBox.Show(ml.ml_string(106, "ClubID not correct."));
      }
      else if (!Validation.FlightID(this.textBoxFlightID.Text))
      {
        int num2 = (int) MessageBox.Show(ml.ml_string(493, "RaceID not correct"));
      }
      else if (this.numericUpDownBasketed.Value == 0M)
      {
        int num3 = (int) MessageBox.Show(ml.ml_string(611, "Please fill in the basketed count."));
      }
      else if (this.manualReadOut.Information[0].Distance == 0M && (Utils.IsCountry("UK") || Utils.IsCountry("IR")))
      {
        int num4 = (int) MessageBox.Show(ml.ml_string(612, "Please fill in the distance."));
      }
      else if (this.numericUpDownBasketed.Value < (Decimal) this.manualReadOut.Pigeons.Count)
      {
        int num5 = (int) MessageBox.Show("Number of pigeons entered is more then the basketed count, please correct it.");
      }
      else if (this.comboBoxFancier.SelectedValue == null)
      {
        int num6 = (int) MessageBox.Show(ml.ml_string(614, "Please select a Fancier"));
      }
      else
      {
        BCEDataSet.AdressenRow byId = BCEDatabase.DataSet.Adressen.FindById((int) this.comboBoxFancier.SelectedValue);
        if (byId == null)
        {
          int num7 = (int) MessageBox.Show(ml.ml_string(615, "Fancier not found"));
        }
        else
        {
          ReadOutDataSet readOutDataSet = new ReadOutDataSet();
          string text = this.labelUsedFileName.Text;
          if (!File.Exists(text))
          {
            if (Utils.EncryptReadouts())
            {
              readOutDataSet.WriteXml(text + "tmp");
              BCEDatabase.EncryptFile(text + "tmp", text);
              File.Delete(text + "tmp");
            }
            else
              readOutDataSet.WriteXml(text);
            this.RefreshFileList();
          }
          if (!File.ReadAllText(text).StartsWith("<"))
          {
            BCEDatabase.DecryptFile(text, text + "tmp");
            int num8 = (int) readOutDataSet.ReadXml(text + "tmp");
            File.Delete(text + "tmp");
          }
          else
          {
            int num9 = (int) readOutDataSet.ReadXml(text);
          }
          DataRow[] dataRowArray1 = readOutDataSet.Fancier.Select("License = '" + byId.Licentie + "' and Name = '" + byId.Naam + "'");
          if (dataRowArray1.Length != 0)
          {
            switch (MessageBox.Show(ml.ml_string(659, "Fancier '") + byId.Naam + ml.ml_string(660, "' with license '") + byId.Licentie + ml.ml_string(661, "' already in this ReadOut, do you wish to overwrite it?"), ml.ml_string(662, "Duplicate Fancier"), MessageBoxButtons.YesNoCancel))
            {
              case DialogResult.Cancel:
                return;
              case DialogResult.Yes:
                foreach (DataRow dataRow1 in dataRowArray1)
                {
                  foreach (DataRow dataRow2 in readOutDataSet.Timers.Select("fancierID = " + dataRow1["ID"].ToString()))
                    dataRow2.Delete();
                  foreach (DataRow dataRow2 in readOutDataSet.Pigeons.Select("fancierID = " + dataRow1["ID"].ToString()))
                    dataRow2.Delete();
                  dataRow1.Delete();
                }
                break;
            }
          }
          string GemeenteUnicode = "";
          DataRow[] dataRowArray2 = BCEDatabase.DataSet.Adressen.Select("Licentie = '" + byId.Licentie + "'");
          string NaamUnicode;
          if (dataRowArray2.Length == 1)
          {
            NaamUnicode = (dataRowArray2[0] as BCEDataSet.AdressenRow).NaamUnicode;
            GemeenteUnicode = (dataRowArray2[0] as BCEDataSet.AdressenRow).GemeenteUnicode;
          }
          else
            NaamUnicode = dataRowArray2.Length != 0 ? ml.ml_string(1360, "Multiple matches") : ml.ml_string(1359, "No exact match");
          int id = readOutDataSet.Fancier.AddFancierRow(byId.Licentie, byId.Naam, byId.Adres, byId.Postcode, byId.Gemeente, Conversion.CoordinateToString(byId.KWX, true), Conversion.CoordinateToString(byId.KWY, true), "", this.manualReadOut.Information[0].Distance, Utils.UnitsUsed(), this.manualReadOut.Information[0].DistanceString, "", NaamUnicode, GemeenteUnicode, this.numericUpDownTimeZone.Value).ID;
          TimeSpan timeSpan1 = this.manualReadOut.Information[0].ClockTime - this.manualReadOut.Information[0].StrikeOff;
          string ReadOutDiff = Conversion.DifferenceToString(Convert.ToInt32(timeSpan1.TotalSeconds));
          TimeSpan timeSpan2 = this.manualReadOut.Information[0].TimeSetClock - this.manualReadOut.Information[0].TimeSet;
          string BasketingDiff = Conversion.DifferenceToString(Convert.ToInt32(timeSpan2.TotalSeconds));
          string Diff = Conversion.DifferenceToString(Convert.ToInt32(timeSpan1.TotalSeconds - timeSpan2.TotalSeconds));
          readOutDataSet.Timers.AddTimersRow(id, this.textBoxClubID.Text, this.textBoxFlightID.Text, this.manualReadOut.Information[0].TimeSet, this.manualReadOut.Information[0].TimeSetClock, BasketingDiff, this.manualReadOut.Information[0].StrikeOff, this.manualReadOut.Information[0].ClockTime, ReadOutDiff, Diff);
          int num10 = 1;
          foreach (ManualReadOut.PigeonsRow pigeon in (TypedTableBase<ManualReadOut.PigeonsRow>) this.manualReadOut.Pigeons)
          {
            readOutDataSet.Pigeons.AddPigeonsRow(id, "FFFFFFFF", pigeon.FedBand, this.textBoxClubID.Text, this.textBoxFlightID.Text, pigeon.IsPositionNull() ? 0 : pigeon.Position, 0, 0, 0, pigeon.Time, "1", num10.ToString(), pigeon.TeamNbr);
            ++num10;
          }
          for (; (Decimal) num10 <= this.numericUpDownBasketed.Value; ++num10)
            readOutDataSet.Pigeons.AddPigeonsRow(id, "FFFFFFFF", "DUMMY", this.textBoxClubID.Text, this.textBoxFlightID.Text, 0, 0, 0, 0, DateTime.Now, "2", num10.ToString(), 0);
          if (Utils.EncryptReadouts())
          {
            readOutDataSet.WriteXml(text + "tmp");
            BCEDatabase.EncryptFile(text + "tmp", text);
            File.Delete(text + "tmp");
          }
          else
            readOutDataSet.WriteXml(text);
          int num11 = (int) MessageBox.Show(ml.ml_string(616, "Manual input added"));
          this.numericUpDownDistance.Value = 0M;
          this.numericUpDownMeter.Value = 0M;
          this.numericUpDownBasketed.Value = 0M;
          this.comboBoxFancier.SelectedIndex = -1;
          this.manualReadOut.Pigeons.Clear();
        }
      }
    }

    private DateTime GetNow()
    {
      DateTime now = DateTime.Now;
      return new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
    }

    private void ManualInputFlightForm_Load(object sender, EventArgs e)
    {
      if (Utils.IsCountry("HU") || Utils.IsCountry("RO") || Utils.IsCountry("MD"))
        this.TeamNbr.Visible = true;
      else
        this.TeamNbr.Visible = false;
      this.adressenBindingSource.Sort = "";
      this.adressenBindingSource.DataSource = (object) BCEDatabase.DataSet;
      this.adressenBindingSource.DataMember = "Adressen";
      this.adressenBindingSource.Sort = "Naam";
      DateTime now = this.GetNow();
      this.manualReadOut.Information.AddInformationRow(0, 0, now, now, now, 0M, "0", now);
      this.manualReadOut.Pigeons.TableNewRow += new DataTableNewRowEventHandler(this.Pigeons_TableNewRow);
      this.textBoxClubID.Text = MainForm.Instance.clubsPage.GetActiveClubRow().ClubID;
      this.textBoxClubID_TextChanged(sender, e);
      this.RefreshFileList();
      this.dateTimePicker1.Value = now;
      this.SetCoordinates();
      this.numericUpDownTimeZone.Value = !Settings.Default.UseTimeZone ? 0M : Convert.ToDecimal(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).TotalHours);
      this.labelTimeZone.Visible = Settings.Default.UseTimeZone;
      this.numericUpDownTimeZone.Visible = Settings.Default.UseTimeZone;
      this.labelTimeZoneHours.Visible = Settings.Default.UseTimeZone;
    }

    private void RefreshFileList()
    {
      this.listView1.Clear();
      if (!Directory.Exists(this._readoutFolder))
        Directory.CreateDirectory(this._readoutFolder);
      foreach (string file in Directory.GetFiles(this._readoutFolder + "\\", "*" + this._extension))
        this.listView1.Items.Add(Path.GetFileNameWithoutExtension(file)).ImageIndex = 0;
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.listView1.SelectedItems.Count != 1)
        return;
      string text = this.listView1.SelectedItems[0].Text;
      if (text == null)
        return;
      string[] strArray = text.Replace("ReadOut_", "").Replace(this._extension, "").Split('_');
      if (strArray.Length != 3)
        return;
      this.textBoxClubID.Text = strArray[0];
      this.textBoxFlightID.Text = strArray[1];
      this.dateTimePicker1.Value = Convert.ToDateTime(strArray[2]);
    }

    private void Pigeons_TableNewRow(object sender, DataTableNewRowEventArgs e)
    {
      if (this.manualReadOut.Pigeons.Count == 0)
        (e.Row as ManualReadOut.PigeonsRow).Time = this.GetNow();
      else
        (e.Row as ManualReadOut.PigeonsRow).Time = this.manualReadOut.Pigeons[this.manualReadOut.Pigeons.Count - 1].Time;
      (e.Row as ManualReadOut.PigeonsRow).Position = this.manualReadOut.Pigeons.Count + 1;
    }

    private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
    {
      if (!(((DataRowView) this.pigeonsBindingSource.Current).Row is ManualReadOut.PigeonsRow row))
        return;
      ManualReadOut.PigeonsRow pigeonsRow1 = (ManualReadOut.PigeonsRow) null;
      string sort = string.Empty;
      if (this.dataGridView1.SortedColumn != null)
        sort = this.dataGridView1.SortedColumn.DataPropertyName;
      if (this.dataGridView1.SortOrder == SortOrder.Descending)
        sort += " desc";
      foreach (ManualReadOut.PigeonsRow pigeonsRow2 in this.manualReadOut.Pigeons.Select("", sort))
      {
        if (pigeonsRow2 != row)
          pigeonsRow1 = pigeonsRow2;
        else
          break;
      }
      string previousRing = pigeonsRow1 == null ? string.Empty : pigeonsRow1.FedBand;
      string str = Validation.MakeDBRing(row.FedBand, previousRing);
      if (!str.Equals(row.FedBand))
        row.FedBand = str;
      row.FedBand = row.FedBand.ToUpper();
    }

    private void buttonClose_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void buttonClear_Click(object sender, EventArgs e)
    {
      this.manualReadOut.Information.Clear();
      DateTime now = this.GetNow();
      this.manualReadOut.Information.AddInformationRow(0, 0, now, now, now, 0M, "0", now);
      this.manualReadOut.Pigeons.Clear();
    }

    private void textBoxClubID_TextChanged(object sender, EventArgs e) => this.labelUsedFileName.Text = this.BuildFileName();

    private string BuildFileName() => string.Format("{0}\\ReadOut_{1}_{2}_{3}{4}", (object) this._readoutFolder.TrimEnd('\\', ' '), (object) this.textBoxClubID.Text, (object) this.textBoxFlightID.Text, (object) this.dateTimePicker1.Value.ToString("yyyy-MM-dd"), (object) this._extension);

    private void listView1_DoubleClick(object sender, EventArgs e) => this.buttonView_Click(sender, e);

    private void buttonView_Click(object sender, EventArgs e)
    {
      foreach (ListViewItem selectedItem in this.listView1.SelectedItems)
      {
        int num = (int) new ViewDataForm(this._readoutFolder + "\\" + selectedItem.Text + this._extension).ShowDialog();
      }
    }

    private void buttonDelete_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(ml.ml_string(455, "This will delete the selected ReadOut, are you sure?"), ml.ml_string(23, "Delete"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
        return;
      foreach (ListViewItem selectedItem in this.listView1.SelectedItems)
        File.Delete(this._readoutFolder + "\\" + selectedItem.Text + this._extension);
      this.RefreshFileList();
    }

    private void SetCoordinates()
    {
      this.numericUpDownDistance.Visible = Utils.IsCountry("UK") || Utils.IsCountry("IR");
      this.numericUpDownMeter.Visible = Utils.IsCountry("UK") || Utils.IsCountry("IR");
      this.labelUnit.Visible = Utils.IsCountry("UK") || Utils.IsCountry("IR");
      this.labelUnit2.Visible = Utils.IsCountry("UK") || Utils.IsCountry("IR");
      this.labelDistance.Visible = Utils.IsCountry("UK") || Utils.IsCountry("IR");
      this.labelCoordinatesHeader.Visible = !Utils.IsCountry("UK") || Utils.IsCountry("IR");
      if (this.comboBoxFancier.SelectedValue != null && !Utils.IsCountry("UK") && !Utils.IsCountry("IR"))
      {
        BCEDataSet.AdressenRow byId = BCEDatabase.DataSet.Adressen.FindById((int) this.comboBoxFancier.SelectedValue);
        if (byId != null)
          this.labelCoordinates.Text = string.Format("{0} / {1}", (object) Conversion.CoordinateToString(byId.KWX, true), (object) Conversion.CoordinateToString(byId.KWY, true));
        else
          this.labelCoordinates.Text = string.Format("");
      }
      else
        this.labelCoordinates.Text = string.Format("");
    }

    private void comboBoxFancier_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.SetCoordinates();
      if (!Settings.Default.UseDistanceDB || this.comboBoxFancier.SelectedValue == null)
        return;
      foreach (BCEDataSet.DistancesRow distancesRow in BCEDatabase.DataSet.Distances.Select("FancierID = " + ((int) this.comboBoxFancier.SelectedValue).ToString() + " and distance <> 0"))
      {
        if (!distancesRow.IsRaceCodeNull() && distancesRow.RaceCode.ToLower() == this.textBoxFlightID.Text.ToLower())
        {
          this.numericUpDownMeter.Value = (Decimal) (distancesRow.IsDistanceYardsNull() ? 0 : distancesRow.DistanceYards);
          this.numericUpDownDistance.Value = (Decimal) (distancesRow.IsDistanceNull() ? 0 : distancesRow.Distance);
        }
      }
    }

    private void dateTimePickerTimeSetDate_ValueChanged(object sender, EventArgs e) => this.dateTimePickerTimeSetClockDate.Value = this.dateTimePickerTimeSetDate.Value;

    private void dateTimePickerStrikeOfDate_ValueChanged(object sender, EventArgs e) => this.dateTimePickerClockDate.Value = this.dateTimePickerStrikeOfDate.Value;

    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if (e.ColumnIndex != 0 || e.RowIndex == -1 || !(e.Value is string))
        return;
      e.Value = (object) e.Value.ToString().ToUpper();
    }

    private void numericUpDownMeter_Enter(object sender, EventArgs e) => (sender as NumericUpDown).Select(0, (sender as NumericUpDown).Text.Length);

    private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
    {
      if (e.ColumnIndex != 1)
        return;
      string str = e.Value as string;
      if (str.Length == 0)
        return;
      foreach (char c in str)
      {
        if (!char.IsDigit(c))
          return;
      }
      ManualReadOut.PigeonsRow row = ((DataRowView) this.pigeonsBindingSource.Current).Row as ManualReadOut.PigeonsRow;
      ManualReadOut.PigeonsRow pigeonsRow1 = (ManualReadOut.PigeonsRow) null;
      string sort = string.Empty;
      if (this.dataGridView1.SortedColumn != null)
        sort = this.dataGridView1.SortedColumn.DataPropertyName;
      if (this.dataGridView1.SortOrder == SortOrder.Descending)
        sort += " desc";
      foreach (ManualReadOut.PigeonsRow pigeonsRow2 in this.manualReadOut.Pigeons.Select("", sort))
      {
        if (pigeonsRow2 != row)
          pigeonsRow1 = pigeonsRow2;
        else
          break;
      }
      DateTime dateTime = pigeonsRow1 == null ? this.GetNow() : pigeonsRow1.Time;
      if (str.Length <= 2)
        dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, Convert.ToInt32(str));
      else if (str.Length <= 4)
      {
        if (str.Length <= 3)
          str = "0" + str;
        dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, Convert.ToInt32(str.Substring(0, 2)), Convert.ToInt32(str.Substring(2, 2)));
      }
      else if (str.Length <= 6)
      {
        if (str.Length <= 5)
          str = "0" + str;
        dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, Convert.ToInt32(str.Substring(0, 2)), Convert.ToInt32(str.Substring(2, 2)), Convert.ToInt32(str.Substring(4, 2)));
      }
      e.Value = (object) dateTime;
      e.ParsingApplied = true;
    }

    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e) => this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

    private void dateTimePickerTimeSetClockDate_ValueChanged(object sender, EventArgs e)
    {
    }

    private void dateTimePickerClockDate_ValueChanged(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ManualInputFlightForm));
      DataGridViewCellStyle gridViewCellStyle = new DataGridViewCellStyle();
      this.buttonOK = new Button();
      this.imageList1 = new ImageList(this.components);
      this.label1 = new Label();
      this.labelDistance = new Label();
      this.numericUpDownBasketed = new NumericUpDown();
      this.informationBindingSource = new BindingSource(this.components);
      this.manualReadOut = new ManualReadOut();
      this.groupBox3 = new GroupBox();
      this.dataGridView1 = new DataGridView();
      this.fedBandDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.timeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.Position = new DataGridViewTextBoxColumn();
      this.TeamNbr = new DataGridViewTextBoxColumn();
      this.pigeonsBindingSource = new BindingSource(this.components);
      this.manualReadOutBindingSource = new BindingSource(this.components);
      this.labelFancier = new Label();
      this.comboBoxFancier = new ComboBox();
      this.adressenBindingSource = new BindingSource(this.components);
      this.groupBoxManualInput = new GroupBox();
      this.labelUnit2 = new Label();
      this.labelUnit = new Label();
      this.numericUpDownMeter = new NumericUpDown();
      this.numericUpDownDistance = new NumericUpDown();
      this.buttonClear = new Button();
      this.dateTimePickerClockDate = new DateTimePicker();
      this.labelClockTime = new Label();
      this.dateTimePickerStrikeOfDate = new DateTimePicker();
      this.dateTimePickerTimeSetClockDate = new DateTimePicker();
      this.labelStrikeOf = new Label();
      this.label2 = new Label();
      this.dateTimePickerTimeSetDate = new DateTimePicker();
      this.labelTimeSet = new Label();
      this.labelCoordinates = new Label();
      this.labelCoordinatesHeader = new Label();
      this.dateTimePicker1 = new DateTimePicker();
      this.labelClubID = new Label();
      this.label5 = new Label();
      this.labelVluchtID = new Label();
      this.labelFileName = new Label();
      this.textBoxFlightID = new TextBox();
      this.textBoxClubID = new TextBox();
      this.labelUsedFileName = new Label();
      this.listView1 = new ListView();
      this.label6 = new Label();
      this.groupBox2 = new GroupBox();
      this.labelTimeZoneHours = new Label();
      this.labelTimeZone = new Label();
      this.buttonDelete = new Button();
      this.numericUpDownTimeZone = new NumericUpDown();
      this.buttonView = new Button();
      this.buttonClose = new Button();
      this.numericUpDownBasketed.BeginInit();
      ((ISupportInitialize) this.informationBindingSource).BeginInit();
      this.manualReadOut.BeginInit();
      this.groupBox3.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((ISupportInitialize) this.pigeonsBindingSource).BeginInit();
      ((ISupportInitialize) this.manualReadOutBindingSource).BeginInit();
      ((ISupportInitialize) this.adressenBindingSource).BeginInit();
      this.groupBoxManualInput.SuspendLayout();
      this.numericUpDownMeter.BeginInit();
      this.numericUpDownDistance.BeginInit();
      this.groupBox2.SuspendLayout();
      this.numericUpDownTimeZone.BeginInit();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.buttonOK, "buttonOK");
      this.buttonOK.ImageList = this.imageList1;
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
      this.imageList1.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageList1.ImageStream");
      this.imageList1.TransparentColor = Color.Fuchsia;
      this.imageList1.Images.SetKeyName(0, "FromBA.bmp");
      this.imageList1.Images.SetKeyName(1, "Delete.bmp");
      this.imageList1.Images.SetKeyName(2, "EditInformation.bmp");
      this.imageList1.Images.SetKeyName(3, "Properties.bmp");
      this.imageList1.Images.SetKeyName(4, "Help.bmp");
      this.imageList1.Images.SetKeyName(5, "Print.bmp");
      this.imageList1.Images.SetKeyName(6, "CriticalError.bmp");
      this.imageList1.Images.SetKeyName(7, "Add.bmp");
      this.imageList1.Images.SetKeyName(8, "arrowright_green16.bmp");
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      componentResourceManager.ApplyResources((object) this.labelDistance, "labelDistance");
      this.labelDistance.Name = "labelDistance";
      this.numericUpDownBasketed.DataBindings.Add(new Binding("Value", (object) this.informationBindingSource, "Basketed", true));
      componentResourceManager.ApplyResources((object) this.numericUpDownBasketed, "numericUpDownBasketed");
      this.numericUpDownBasketed.Maximum = new Decimal(new int[4]
      {
        9999,
        0,
        0,
        0
      });
      this.numericUpDownBasketed.Name = "numericUpDownBasketed";
      this.numericUpDownBasketed.Value = new Decimal(new int[4]
      {
        1000,
        0,
        0,
        0
      });
      this.informationBindingSource.DataMember = "Information";
      this.informationBindingSource.DataSource = (object) this.manualReadOut;
      this.manualReadOut.DataSetName = "ManualReadOut";
      this.manualReadOut.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.groupBox3.Controls.Add((Control) this.dataGridView1);
      componentResourceManager.ApplyResources((object) this.groupBox3, "groupBox3");
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.TabStop = false;
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.fedBandDataGridViewTextBoxColumn, (DataGridViewColumn) this.timeDataGridViewTextBoxColumn, (DataGridViewColumn) this.Position, (DataGridViewColumn) this.TeamNbr);
      this.dataGridView1.DataSource = (object) this.pigeonsBindingSource;
      componentResourceManager.ApplyResources((object) this.dataGridView1, "dataGridView1");
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
      this.dataGridView1.CellParsing += new DataGridViewCellParsingEventHandler(this.dataGridView1_CellParsing);
      this.dataGridView1.CellValidated += new DataGridViewCellEventHandler(this.dataGridView1_CellValidated);
      this.dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
      this.fedBandDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.fedBandDataGridViewTextBoxColumn.DataPropertyName = "FedBand";
      this.fedBandDataGridViewTextBoxColumn.FillWeight = 150f;
      componentResourceManager.ApplyResources((object) this.fedBandDataGridViewTextBoxColumn, "fedBandDataGridViewTextBoxColumn");
      this.fedBandDataGridViewTextBoxColumn.Name = "fedBandDataGridViewTextBoxColumn";
      this.timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
      gridViewCellStyle.Format = "G";
      gridViewCellStyle.NullValue = (object) null;
      this.timeDataGridViewTextBoxColumn.DefaultCellStyle = gridViewCellStyle;
      componentResourceManager.ApplyResources((object) this.timeDataGridViewTextBoxColumn, "timeDataGridViewTextBoxColumn");
      this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
      this.Position.DataPropertyName = "Position";
      componentResourceManager.ApplyResources((object) this.Position, "Position");
      this.Position.Name = "Position";
      this.TeamNbr.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
      this.TeamNbr.DataPropertyName = "TeamNbr";
      componentResourceManager.ApplyResources((object) this.TeamNbr, "TeamNbr");
      this.TeamNbr.Name = "TeamNbr";
      this.pigeonsBindingSource.DataMember = "Pigeons";
      this.pigeonsBindingSource.DataSource = (object) this.manualReadOutBindingSource;
      this.manualReadOutBindingSource.DataSource = (object) this.manualReadOut;
      this.manualReadOutBindingSource.Position = 0;
      componentResourceManager.ApplyResources((object) this.labelFancier, "labelFancier");
      this.labelFancier.Name = "labelFancier";
      this.comboBoxFancier.DataBindings.Add(new Binding("SelectedValue", (object) this.informationBindingSource, "FancierID", true));
      this.comboBoxFancier.DataSource = (object) this.adressenBindingSource;
      this.comboBoxFancier.DisplayMember = "Naam";
      this.comboBoxFancier.FormattingEnabled = true;
      componentResourceManager.ApplyResources((object) this.comboBoxFancier, "comboBoxFancier");
      this.comboBoxFancier.Name = "comboBoxFancier";
      this.comboBoxFancier.ValueMember = "Id";
      this.comboBoxFancier.SelectedIndexChanged += new EventHandler(this.comboBoxFancier_SelectedIndexChanged);
      this.adressenBindingSource.Sort = "Naam";
      this.groupBoxManualInput.Controls.Add((Control) this.labelUnit2);
      this.groupBoxManualInput.Controls.Add((Control) this.labelUnit);
      this.groupBoxManualInput.Controls.Add((Control) this.numericUpDownMeter);
      this.groupBoxManualInput.Controls.Add((Control) this.numericUpDownDistance);
      this.groupBoxManualInput.Controls.Add((Control) this.buttonClear);
      this.groupBoxManualInput.Controls.Add((Control) this.dateTimePickerClockDate);
      this.groupBoxManualInput.Controls.Add((Control) this.labelClockTime);
      this.groupBoxManualInput.Controls.Add((Control) this.dateTimePickerStrikeOfDate);
      this.groupBoxManualInput.Controls.Add((Control) this.dateTimePickerTimeSetClockDate);
      this.groupBoxManualInput.Controls.Add((Control) this.labelStrikeOf);
      this.groupBoxManualInput.Controls.Add((Control) this.label2);
      this.groupBoxManualInput.Controls.Add((Control) this.dateTimePickerTimeSetDate);
      this.groupBoxManualInput.Controls.Add((Control) this.labelTimeSet);
      this.groupBoxManualInput.Controls.Add((Control) this.groupBox3);
      this.groupBoxManualInput.Controls.Add((Control) this.label1);
      this.groupBoxManualInput.Controls.Add((Control) this.labelCoordinates);
      this.groupBoxManualInput.Controls.Add((Control) this.labelCoordinatesHeader);
      this.groupBoxManualInput.Controls.Add((Control) this.labelFancier);
      this.groupBoxManualInput.Controls.Add((Control) this.comboBoxFancier);
      this.groupBoxManualInput.Controls.Add((Control) this.numericUpDownBasketed);
      this.groupBoxManualInput.Controls.Add((Control) this.labelDistance);
      componentResourceManager.ApplyResources((object) this.groupBoxManualInput, "groupBoxManualInput");
      this.groupBoxManualInput.Name = "groupBoxManualInput";
      this.groupBoxManualInput.TabStop = false;
      componentResourceManager.ApplyResources((object) this.labelUnit2, "labelUnit2");
      this.labelUnit2.Name = "labelUnit2";
      componentResourceManager.ApplyResources((object) this.labelUnit, "labelUnit");
      this.labelUnit.Name = "labelUnit";
      componentResourceManager.ApplyResources((object) this.numericUpDownMeter, "numericUpDownMeter");
      this.numericUpDownMeter.Maximum = new Decimal(new int[4]
      {
        1759,
        0,
        0,
        0
      });
      this.numericUpDownMeter.Name = "numericUpDownMeter";
      this.numericUpDownMeter.Enter += new EventHandler(this.numericUpDownMeter_Enter);
      componentResourceManager.ApplyResources((object) this.numericUpDownDistance, "numericUpDownDistance");
      this.numericUpDownDistance.Maximum = new Decimal(new int[4]
      {
        999,
        0,
        0,
        0
      });
      this.numericUpDownDistance.Name = "numericUpDownDistance";
      this.numericUpDownDistance.Enter += new EventHandler(this.numericUpDownMeter_Enter);
      componentResourceManager.ApplyResources((object) this.buttonClear, "buttonClear");
      this.buttonClear.ImageList = this.imageList1;
      this.buttonClear.Name = "buttonClear";
      this.buttonClear.UseVisualStyleBackColor = true;
      this.buttonClear.Click += new EventHandler(this.buttonClear_Click);
      componentResourceManager.ApplyResources((object) this.dateTimePickerClockDate, "dateTimePickerClockDate");
      this.dateTimePickerClockDate.DataBindings.Add(new Binding("Value", (object) this.informationBindingSource, "ClockTime", true, DataSourceUpdateMode.OnPropertyChanged, (object) null, "d"));
      this.dateTimePickerClockDate.Format = DateTimePickerFormat.Custom;
      this.dateTimePickerClockDate.Name = "dateTimePickerClockDate";
      this.dateTimePickerClockDate.ShowUpDown = true;
      this.dateTimePickerClockDate.Value = new DateTime(2008, 4, 10, 0, 0, 0, 0);
      this.dateTimePickerClockDate.ValueChanged += new EventHandler(this.dateTimePickerClockDate_ValueChanged);
      componentResourceManager.ApplyResources((object) this.labelClockTime, "labelClockTime");
      this.labelClockTime.Name = "labelClockTime";
      componentResourceManager.ApplyResources((object) this.dateTimePickerStrikeOfDate, "dateTimePickerStrikeOfDate");
      this.dateTimePickerStrikeOfDate.DataBindings.Add(new Binding("Value", (object) this.informationBindingSource, "StrikeOff", true, DataSourceUpdateMode.OnPropertyChanged, (object) null, "d"));
      this.dateTimePickerStrikeOfDate.Format = DateTimePickerFormat.Custom;
      this.dateTimePickerStrikeOfDate.Name = "dateTimePickerStrikeOfDate";
      this.dateTimePickerStrikeOfDate.ShowUpDown = true;
      this.dateTimePickerStrikeOfDate.Value = new DateTime(2008, 4, 10, 0, 0, 0, 0);
      this.dateTimePickerStrikeOfDate.ValueChanged += new EventHandler(this.dateTimePickerStrikeOfDate_ValueChanged);
      componentResourceManager.ApplyResources((object) this.dateTimePickerTimeSetClockDate, "dateTimePickerTimeSetClockDate");
      this.dateTimePickerTimeSetClockDate.DataBindings.Add(new Binding("Value", (object) this.informationBindingSource, "TimeSetClock", true));
      this.dateTimePickerTimeSetClockDate.Format = DateTimePickerFormat.Custom;
      this.dateTimePickerTimeSetClockDate.Name = "dateTimePickerTimeSetClockDate";
      this.dateTimePickerTimeSetClockDate.ShowUpDown = true;
      this.dateTimePickerTimeSetClockDate.Value = new DateTime(2008, 4, 10, 0, 0, 0, 0);
      this.dateTimePickerTimeSetClockDate.ValueChanged += new EventHandler(this.dateTimePickerTimeSetClockDate_ValueChanged);
      componentResourceManager.ApplyResources((object) this.labelStrikeOf, "labelStrikeOf");
      this.labelStrikeOf.Name = "labelStrikeOf";
      componentResourceManager.ApplyResources((object) this.label2, "label2");
      this.label2.Name = "label2";
      componentResourceManager.ApplyResources((object) this.dateTimePickerTimeSetDate, "dateTimePickerTimeSetDate");
      this.dateTimePickerTimeSetDate.DataBindings.Add(new Binding("Value", (object) this.informationBindingSource, "TimeSet", true, DataSourceUpdateMode.OnPropertyChanged, (object) null, "d"));
      this.dateTimePickerTimeSetDate.Format = DateTimePickerFormat.Custom;
      this.dateTimePickerTimeSetDate.Name = "dateTimePickerTimeSetDate";
      this.dateTimePickerTimeSetDate.ShowUpDown = true;
      this.dateTimePickerTimeSetDate.Value = new DateTime(2008, 4, 10, 0, 0, 0, 0);
      this.dateTimePickerTimeSetDate.ValueChanged += new EventHandler(this.dateTimePickerTimeSetDate_ValueChanged);
      componentResourceManager.ApplyResources((object) this.labelTimeSet, "labelTimeSet");
      this.labelTimeSet.Name = "labelTimeSet";
      componentResourceManager.ApplyResources((object) this.labelCoordinates, "labelCoordinates");
      this.labelCoordinates.Name = "labelCoordinates";
      componentResourceManager.ApplyResources((object) this.labelCoordinatesHeader, "labelCoordinatesHeader");
      this.labelCoordinatesHeader.Name = "labelCoordinatesHeader";
      this.dateTimePicker1.Format = DateTimePickerFormat.Short;
      componentResourceManager.ApplyResources((object) this.dateTimePicker1, "dateTimePicker1");
      this.dateTimePicker1.Name = "dateTimePicker1";
      this.dateTimePicker1.Value = new DateTime(2008, 4, 10, 0, 0, 0, 0);
      this.dateTimePicker1.ValueChanged += new EventHandler(this.textBoxClubID_TextChanged);
      componentResourceManager.ApplyResources((object) this.labelClubID, "labelClubID");
      this.labelClubID.Name = "labelClubID";
      componentResourceManager.ApplyResources((object) this.label5, "label5");
      this.label5.Name = "label5";
      componentResourceManager.ApplyResources((object) this.labelVluchtID, "labelVluchtID");
      this.labelVluchtID.Name = "labelVluchtID";
      componentResourceManager.ApplyResources((object) this.labelFileName, "labelFileName");
      this.labelFileName.Name = "labelFileName";
      this.textBoxFlightID.CharacterCasing = CharacterCasing.Upper;
      this.textBoxFlightID.DataBindings.Add(new Binding("Text", (object) Settings.Default, "FlightID", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBoxFlightID, "textBoxFlightID");
      this.textBoxFlightID.Name = "textBoxFlightID";
      this.textBoxFlightID.Text = Settings.Default.FlightID;
      this.textBoxFlightID.TextChanged += new EventHandler(this.textBoxClubID_TextChanged);
      componentResourceManager.ApplyResources((object) this.textBoxClubID, "textBoxClubID");
      this.textBoxClubID.Name = "textBoxClubID";
      this.textBoxClubID.TextChanged += new EventHandler(this.textBoxClubID_TextChanged);
      componentResourceManager.ApplyResources((object) this.labelUsedFileName, "labelUsedFileName");
      this.labelUsedFileName.Name = "labelUsedFileName";
      componentResourceManager.ApplyResources((object) this.listView1, "listView1");
      this.listView1.FullRowSelect = true;
      this.listView1.HideSelection = false;
      this.listView1.Items.AddRange(new ListViewItem[1]
      {
        (ListViewItem) componentResourceManager.GetObject("listView1.Items")
      });
      this.listView1.MultiSelect = false;
      this.listView1.Name = "listView1";
      this.listView1.SmallImageList = this.imageList1;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = View.List;
      this.listView1.SelectedIndexChanged += new EventHandler(this.listView1_SelectedIndexChanged);
      this.listView1.DoubleClick += new EventHandler(this.listView1_DoubleClick);
      componentResourceManager.ApplyResources((object) this.label6, "label6");
      this.label6.Name = "label6";
      this.groupBox2.Controls.Add((Control) this.labelTimeZoneHours);
      this.groupBox2.Controls.Add((Control) this.labelTimeZone);
      this.groupBox2.Controls.Add((Control) this.buttonDelete);
      this.groupBox2.Controls.Add((Control) this.numericUpDownTimeZone);
      this.groupBox2.Controls.Add((Control) this.buttonView);
      this.groupBox2.Controls.Add((Control) this.labelFileName);
      this.groupBox2.Controls.Add((Control) this.labelUsedFileName);
      this.groupBox2.Controls.Add((Control) this.listView1);
      this.groupBox2.Controls.Add((Control) this.textBoxClubID);
      this.groupBox2.Controls.Add((Control) this.dateTimePicker1);
      this.groupBox2.Controls.Add((Control) this.textBoxFlightID);
      this.groupBox2.Controls.Add((Control) this.labelClubID);
      this.groupBox2.Controls.Add((Control) this.label6);
      this.groupBox2.Controls.Add((Control) this.label5);
      this.groupBox2.Controls.Add((Control) this.labelVluchtID);
      componentResourceManager.ApplyResources((object) this.groupBox2, "groupBox2");
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.TabStop = false;
      componentResourceManager.ApplyResources((object) this.labelTimeZoneHours, "labelTimeZoneHours");
      this.labelTimeZoneHours.Name = "labelTimeZoneHours";
      componentResourceManager.ApplyResources((object) this.labelTimeZone, "labelTimeZone");
      this.labelTimeZone.Name = "labelTimeZone";
      componentResourceManager.ApplyResources((object) this.buttonDelete, "buttonDelete");
      this.buttonDelete.ImageList = this.imageList1;
      this.buttonDelete.Name = "buttonDelete";
      this.buttonDelete.TabStop = false;
      this.buttonDelete.UseVisualStyleBackColor = true;
      this.buttonDelete.Click += new EventHandler(this.buttonDelete_Click);
      this.numericUpDownTimeZone.DecimalPlaces = 1;
      componentResourceManager.ApplyResources((object) this.numericUpDownTimeZone, "numericUpDownTimeZone");
      this.numericUpDownTimeZone.Maximum = new Decimal(new int[4]
      {
        23,
        0,
        0,
        0
      });
      this.numericUpDownTimeZone.Minimum = new Decimal(new int[4]
      {
        23,
        0,
        0,
        int.MinValue
      });
      this.numericUpDownTimeZone.Name = "numericUpDownTimeZone";
      componentResourceManager.ApplyResources((object) this.buttonView, "buttonView");
      this.buttonView.ImageList = this.imageList1;
      this.buttonView.Name = "buttonView";
      this.buttonView.TabStop = false;
      this.buttonView.UseVisualStyleBackColor = true;
      this.buttonView.Click += new EventHandler(this.buttonView_Click);
      componentResourceManager.ApplyResources((object) this.buttonClose, "buttonClose");
      this.buttonClose.DialogResult = DialogResult.Cancel;
      this.buttonClose.Name = "buttonClose";
      this.buttonClose.UseVisualStyleBackColor = true;
      this.buttonClose.Click += new EventHandler(this.buttonClose_Click);
      this.AcceptButton = (IButtonControl) this.buttonOK;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonClose;
      this.Controls.Add((Control) this.buttonClose);
      this.Controls.Add((Control) this.buttonOK);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBoxManualInput);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (ManualInputFlightForm);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Load += new EventHandler(this.ManualInputFlightForm_Load);
      this.numericUpDownBasketed.EndInit();
      ((ISupportInitialize) this.informationBindingSource).EndInit();
      this.manualReadOut.EndInit();
      this.groupBox3.ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((ISupportInitialize) this.pigeonsBindingSource).EndInit();
      ((ISupportInitialize) this.manualReadOutBindingSource).EndInit();
      ((ISupportInitialize) this.adressenBindingSource).EndInit();
      this.groupBoxManualInput.ResumeLayout(false);
      this.groupBoxManualInput.PerformLayout();
      this.numericUpDownMeter.EndInit();
      this.numericUpDownDistance.EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.numericUpDownTimeZone.EndInit();
      this.ResumeLayout(false);
    }
  }
}
