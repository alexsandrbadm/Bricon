// Decompiled with JetBrains decompiler
// Type: BriconLib.BCE.ClubsPage
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Communications;
using BriconLib.Data;
using BriconLib.Other;
using BriconLib.PAS.BceDatabase;
using BriconLib.Properties;
using BriconLib.UI;
using MultiLang;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BriconLib.BCE
{
  public class ClubsPage : UserControl
  {
    private IContainer components;
    private DataGridView dataGridView1;
    private BindingNavigator bindingNavigatorAdressen;
    private ToolStripButton bindingNavigatorAddNewItem;
    private ToolStripLabel bindingNavigatorCountItem;
    private ToolStripButton bindingNavigatorMoveFirstItem;
    private ToolStripButton bindingNavigatorMovePreviousItem;
    private ToolStripSeparator bindingNavigatorSeparator;
    private ToolStripTextBox bindingNavigatorPositionItem;
    private ToolStripSeparator bindingNavigatorSeparator1;
    private ToolStripButton bindingNavigatorMoveNextItem;
    private ToolStripButton bindingNavigatorMoveLastItem;
    private ToolStripSeparator bindingNavigatorSeparator2;
    private BCEDataSet bceDataSetLocal;
    internal BindingSource bindingSourceClubs;
    private ToolStripButton toolStripButtonToMaster;
    private ToolStripButton toolStripButtonFromMaster;
    private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn clubIDDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn Adres;
    private DataGridViewTextBoxColumn Telefoon;
    private DataGridViewTextBoxColumn Verantwoordelijke;
    private DataGridViewTextBoxColumn Email;
    private Panel panelDetail;
    private TextBox adresTextBox;
    private TextBox clubIDTextBox;
    private TextBox nameTextBox;
    private TextBox emailTextBox;
    private TextBox verantwoordelijkeTelefoonTextBox;
    private TextBox verantwoordelijkeTextBox;
    private TextBox serieNrMasterTextBox;
    private TextBox telefoonTextBox;
    private TextBox gemeenteTextBox;
    private TextBox postcodeTextBox;
    private ErrorProvider errorProvider;
    private ToolStripButton bindingNavigatorDeleteItem;
    private ToolStripSeparator toolStripSeparator1;
    private Button buttonChangePincode;
    private Label adresLabel;
    private Label telefoonLabel;
    private Label verantwoordelijkeLabel;
    private Label verantwoordelijkeTelefoonLabel;
    private Label emailLabel;
    private Label gemeenteLabel;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripButton toolStripButtonCheckRings;
    private ToolStripButton toolStripButtonNaarKBDB;
    private TextBox textBoxClubNumber;
    private PictureBox pictureBoxPasClub;
    protected TextBox pincodeTextBox;
    private TextBox textBoxPassword;
    private Label labelLogin;
    private Button buttonTestBW;
    private Label labelPassword;
    private TextBox textBoxLoginPas;
    private Label pincodeLabel;
    private Label serieNrMasterLabel;
    private Button buttonInitPAS;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    private TextBox textBoxPasBetaUrl;
    private Label labelPasBetaUrl;
    private Button buttonChangeBetaUrl;

    public ClubsPage() => this.InitializeComponent();

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      this.dataGridView1.EndEdit();
      this.bindingSourceClubs.EndEdit();
      if (((DataRowView) this.bindingSourceClubs.Current).Row is BCEDataSet.ClubsRow row)
      {
        if (!Validation.ClubID(row.ClubID))
        {
          int num1 = (int) MessageBox.Show(ml.ml_string(106, "ClubID not correct."));
        }
        else if (!Validation.Pincode(row.Pincode))
        {
          int num2 = (int) MessageBox.Show(ml.ml_string(107, "Pincode not correct."));
        }
        else
          CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new SendClubIDAndPincodeCommand(row.ClubID, row.Pincode, row.Name, row.ID));
      }
      else
      {
        int num3 = (int) MessageBox.Show(ml.ml_string(108, "Please select a record"));
      }
    }

    private void toolStripButton2_Click(object sender, EventArgs e)
    {
      this.dataGridView1.EndEdit();
      this.bindingSourceClubs.EndEdit();
      if (((DataRowView) this.bindingSourceClubs.Current).Row is BCEDataSet.ClubsRow row)
      {
        CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new GetClubIDAndPincodeCommand(row.ID, row.Name));
      }
      else
      {
        int num = (int) MessageBox.Show(ml.ml_string(108, "Please select a record"));
      }
    }

    private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
    {
      this.dataGridView1.CurrentCell = this.dataGridView1.CurrentRow.Cells["clubIDDataGridViewTextBoxColumn"];
      this.dataGridView1.BeginEdit(true);
    }

    private bool ValidateTextBox(TextBox txtBox)
    {
      if (txtBox.Text.Trim().Length != 0)
        return true;
      this.errorProvider.SetError((Control) txtBox, ml.ml_string(290, "Field must be filled in"));
      this.errorProvider.SetIconPadding((Control) txtBox, -20);
      return false;
    }

    public bool ValidateAllData()
    {
      this.errorProvider.Clear();
      bool flag1 = true;
      bool flag2 = this.ValidateTextBox(this.nameTextBox) & flag1;
      if (!Utils.IsCountry("JP"))
      {
        bool flag3 = this.ValidateTextBox(this.adresTextBox) & flag2;
        bool flag4 = this.ValidateTextBox(this.postcodeTextBox) & flag3;
        flag2 = this.ValidateTextBox(this.gemeenteTextBox) & flag4;
      }
      bool flag5 = this.ValidateTextBox(this.clubIDTextBox) & flag2;
      bool flag6 = this.ValidateTextBox(this.pincodeTextBox) & flag5;
      if (!Validation.ClubID(this.clubIDTextBox.Text))
      {
        this.errorProvider.SetError((Control) this.clubIDTextBox, ml.ml_string(833, "ClubID not correct."));
        this.errorProvider.SetIconPadding((Control) this.clubIDTextBox, -20);
        flag6 = false;
      }
      if (!Validation.Pincode(this.pincodeTextBox.Text))
      {
        this.errorProvider.SetError((Control) this.pincodeTextBox, ml.ml_string(107, "Pincode not correct."));
        this.errorProvider.SetIconPadding((Control) this.pincodeTextBox, -20);
        flag6 = false;
      }
      return flag6;
    }

    public BCEDataSet.ClubsRow GetActiveClubRow()
    {
      this.bindingSourceClubs.EndEdit();
      return ((DataRowView) this.bindingSourceClubs.Current).Row as BCEDataSet.ClubsRow;
    }

    private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
    {
      if (BCEDatabase.DataSet.Adressen.Select("ClubID = " + this.GetActiveClubRow().ID.ToString()).Length != 0)
      {
        int num1 = (int) MessageBox.Show(ml.ml_string(347, "There are still fanciers for this club, please delete them first"));
      }
      else if (BCEDatabase.DataSet.Clubs.Count <= 1)
      {
        int num2 = (int) MessageBox.Show(ml.ml_string(348, "There must be at least one club"));
      }
      else
        BCEDatabase.DataSet.Clubs.RemoveClubsRow(this.GetActiveClubRow());
    }

    private void nameTextBox_Leave(object sender, EventArgs e) => this.ValidateAllData();

    private void bindingSourceClubs_PositionChanged(object sender, EventArgs e) => this.ValidateAllData();

    private void ClubsPage_Load(object sender, EventArgs e) => this.ValidateAllData();

    private void buttonChangePincode_Click(object sender, EventArgs e)
    {
      PincodeForm pincodeForm = new PincodeForm(this.pincodeTextBox.Text);
      if (pincodeForm.ShowDialog() != DialogResult.OK)
        return;
      this.pincodeTextBox.Text = pincodeForm.Pincode;
    }

    private void nameTextBox_TextChanged(object sender, EventArgs e) => this.errorProvider.SetError(sender as Control, "");

    public void TabPageActivated()
    {
      this.adresLabel.Visible = !Utils.IsCountry("JP");
      this.adresTextBox.Visible = !Utils.IsCountry("JP");
      this.gemeenteLabel.Visible = !Utils.IsCountry("JP");
      this.postcodeTextBox.Visible = !Utils.IsCountry("JP");
      this.gemeenteTextBox.Visible = !Utils.IsCountry("JP");
      this.emailLabel.Visible = !Utils.IsCountry("JP");
      this.emailTextBox.Visible = !Utils.IsCountry("JP");
      this.verantwoordelijkeLabel.Visible = !Utils.IsCountry("JP");
      this.verantwoordelijkeTextBox.Visible = !Utils.IsCountry("JP");
      this.verantwoordelijkeLabel.Visible = !Utils.IsCountry("JP");
      this.verantwoordelijkeTelefoonLabel.Visible = !Utils.IsCountry("JP");
      this.verantwoordelijkeTelefoonTextBox.Visible = !Utils.IsCountry("JP");
      this.telefoonLabel.Visible = !Utils.IsCountry("JP");
      this.telefoonTextBox.Visible = !Utils.IsCountry("JP");
      this.Adres.Visible = !Utils.IsCountry("JP");
      this.Telefoon.Visible = !Utils.IsCountry("JP");
      this.Verantwoordelijke.Visible = !Utils.IsCountry("JP");
      this.Email.Visible = !Utils.IsCountry("JP");
      this.toolStripButtonNaarKBDB.Visible = Utils.IsCountry("BE");
      this.textBoxClubNumber.Visible = Utils.IsCountry("UK");
      if (Utils.IsCountry("BE"))
        this.toolStripButtonToMaster.Visible = false;
      if (!Utils.IsPasActive())
        return;
      this.buttonChangeBetaUrl.Visible = this.textBoxPasBetaUrl.Visible = this.labelPasBetaUrl.Visible = Utils.IsBeta();
      this.pictureBoxPasClub.Visible = true;
      this.pincodeTextBox.Visible = false;
      this.buttonChangePincode.Visible = false;
      this.pincodeLabel.Visible = false;
      this.serieNrMasterLabel.Visible = false;
      this.serieNrMasterTextBox.Visible = false;
      this.textBoxClubNumber.Visible = false;
      this.labelLogin.Visible = true;
      this.textBoxLoginPas.Visible = true;
      this.labelPassword.Visible = true;
      this.textBoxPassword.Visible = true;
      this.buttonTestBW.Visible = true;
      this.buttonInitPAS.Visible = true;
      if (Settings.Default.PASOk)
      {
        this.SetPASOkMode();
        this.buttonInitPAS.Text = ml.ml_string(1400, "Opnieuw Instellen PAS");
      }
      else
        this.buttonInitPAS.Text = ml.ml_string(1347, "Setup PAS");
    }

    private void SetPASOkMode()
    {
      this.toolStripButtonToMaster.Visible = false;
      this.toolStripButtonFromMaster.Visible = false;
      this.toolStripButtonNaarKBDB.Visible = false;
      this.toolStripButtonCheckRings.Visible = false;
      this.bindingNavigatorAddNewItem.Visible = false;
      this.bindingNavigatorDeleteItem.Visible = false;
      this.clubIDTextBox.Enabled = false;
    }

    private void toolStripButtonCheckRings_Click(object sender, EventArgs e)
    {
      CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new CheckRingCommand((string) null));
      MainForm.Instance._checkRingsForm = new CheckRingsForm();
      int num = (int) MainForm.Instance._checkRingsForm.ShowDialog();
      MainForm.Instance._checkRingsForm = (CheckRingsForm) null;
    }

    private void bindingNavigatorAdressen_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      this.toolStripButtonCheckRings_Click(sender, (EventArgs) null);
    }

    private void toolStripButtonNaarKBDB_Click(object sender, EventArgs e) => new SendBCEData().SendToKBDB();

    private void buttonTestBW_Click(object sender, EventArgs e) => new PasDataTester().Test();

    private void buttonInitPAS_Click(object sender, EventArgs e)
    {
      Settings.Default.PASOk = false;
      Settings.Default.Save();
      if (string.IsNullOrWhiteSpace(Settings.Default.PASUserName) || string.IsNullOrWhiteSpace(Settings.Default.PASPassword))
      {
        int num1 = (int) MessageBox.Show(ml.ml_string(1401, "Gelieve uw login en wachtwoord in te vullen."));
      }
      else
      {
        if (!new PasDataLoader().Load(true))
          return;
        Settings.Default.PASOk = true;
        Settings.Default.Save();
        int num2 = (int) MessageBox.Show(ml.ml_string(1402, "Programma wordt nu afgesloten, gelieve het opnieuw te starten"));
        Application.Exit();
      }
    }

    private void ButtonChangeBetaUrl_Click(object sender, EventArgs e)
    {
      PasswordForm passwordForm = new PasswordForm(ml.ml_string(1404, "Change Beta Url"), ml.ml_string(1403, "Enter the code please:"));
      if (passwordForm.ShowDialog() != DialogResult.OK || !(passwordForm.Code == "211073"))
        return;
      this.textBoxPasBetaUrl.ReadOnly = false;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ClubsPage));
      this.pincodeLabel = new Label();
      this.serieNrMasterLabel = new Label();
      this.adresLabel = new Label();
      this.telefoonLabel = new Label();
      this.verantwoordelijkeLabel = new Label();
      this.verantwoordelijkeTelefoonLabel = new Label();
      this.emailLabel = new Label();
      this.gemeenteLabel = new Label();
      this.dataGridView1 = new DataGridView();
      this.iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.clubIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.Adres = new DataGridViewTextBoxColumn();
      this.Telefoon = new DataGridViewTextBoxColumn();
      this.Verantwoordelijke = new DataGridViewTextBoxColumn();
      this.Email = new DataGridViewTextBoxColumn();
      this.bindingSourceClubs = new BindingSource(this.components);
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
      this.toolStripButtonFromMaster = new ToolStripButton();
      this.toolStripButtonToMaster = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.toolStripButtonCheckRings = new ToolStripButton();
      this.toolStripButtonNaarKBDB = new ToolStripButton();
      this.panelDetail = new Panel();
      this.buttonChangeBetaUrl = new Button();
      this.textBoxPasBetaUrl = new TextBox();
      this.labelPasBetaUrl = new Label();
      this.buttonInitPAS = new Button();
      this.textBoxPassword = new TextBox();
      this.labelLogin = new Label();
      this.buttonTestBW = new Button();
      this.labelPassword = new Label();
      this.textBoxLoginPas = new TextBox();
      this.pictureBoxPasClub = new PictureBox();
      this.buttonChangePincode = new Button();
      this.gemeenteTextBox = new TextBox();
      this.postcodeTextBox = new TextBox();
      this.emailTextBox = new TextBox();
      this.verantwoordelijkeTelefoonTextBox = new TextBox();
      this.verantwoordelijkeTextBox = new TextBox();
      this.serieNrMasterTextBox = new TextBox();
      this.telefoonTextBox = new TextBox();
      this.adresTextBox = new TextBox();
      this.pincodeTextBox = new TextBox();
      this.textBoxClubNumber = new TextBox();
      this.clubIDTextBox = new TextBox();
      this.nameTextBox = new TextBox();
      this.errorProvider = new ErrorProvider(this.components);
      this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
      Label label1 = new Label();
      Label label2 = new Label();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((ISupportInitialize) this.bindingSourceClubs).BeginInit();
      this.bceDataSetLocal.BeginInit();
      this.bindingNavigatorAdressen.BeginInit();
      this.bindingNavigatorAdressen.SuspendLayout();
      this.panelDetail.SuspendLayout();
      ((ISupportInitialize) this.pictureBoxPasClub).BeginInit();
      ((ISupportInitialize) this.errorProvider).BeginInit();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) label1, "nameLabel");
      label1.Name = "nameLabel";
      componentResourceManager.ApplyResources((object) label2, "clubIDLabel");
      label2.Name = "clubIDLabel";
      componentResourceManager.ApplyResources((object) this.pincodeLabel, "pincodeLabel");
      this.pincodeLabel.Name = "pincodeLabel";
      componentResourceManager.ApplyResources((object) this.serieNrMasterLabel, "serieNrMasterLabel");
      this.serieNrMasterLabel.Name = "serieNrMasterLabel";
      componentResourceManager.ApplyResources((object) this.adresLabel, "adresLabel");
      this.adresLabel.Name = "adresLabel";
      componentResourceManager.ApplyResources((object) this.telefoonLabel, "telefoonLabel");
      this.telefoonLabel.Name = "telefoonLabel";
      componentResourceManager.ApplyResources((object) this.verantwoordelijkeLabel, "verantwoordelijkeLabel");
      this.verantwoordelijkeLabel.Name = "verantwoordelijkeLabel";
      componentResourceManager.ApplyResources((object) this.verantwoordelijkeTelefoonLabel, "verantwoordelijkeTelefoonLabel");
      this.verantwoordelijkeTelefoonLabel.Name = "verantwoordelijkeTelefoonLabel";
      componentResourceManager.ApplyResources((object) this.emailLabel, "emailLabel");
      this.emailLabel.Name = "emailLabel";
      componentResourceManager.ApplyResources((object) this.gemeenteLabel, "gemeenteLabel");
      this.gemeenteLabel.Name = "gemeenteLabel";
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.iDDataGridViewTextBoxColumn, (DataGridViewColumn) this.clubIDDataGridViewTextBoxColumn, (DataGridViewColumn) this.nameDataGridViewTextBoxColumn, (DataGridViewColumn) this.Adres, (DataGridViewColumn) this.Telefoon, (DataGridViewColumn) this.Verantwoordelijke, (DataGridViewColumn) this.Email);
      this.dataGridView1.DataSource = (object) this.bindingSourceClubs;
      componentResourceManager.ApplyResources((object) this.dataGridView1, "dataGridView1");
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
      componentResourceManager.ApplyResources((object) this.iDDataGridViewTextBoxColumn, "iDDataGridViewTextBoxColumn");
      this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
      this.iDDataGridViewTextBoxColumn.ReadOnly = true;
      this.clubIDDataGridViewTextBoxColumn.DataPropertyName = "ClubID";
      componentResourceManager.ApplyResources((object) this.clubIDDataGridViewTextBoxColumn, "clubIDDataGridViewTextBoxColumn");
      this.clubIDDataGridViewTextBoxColumn.Name = "clubIDDataGridViewTextBoxColumn";
      this.clubIDDataGridViewTextBoxColumn.ReadOnly = true;
      this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
      componentResourceManager.ApplyResources((object) this.nameDataGridViewTextBoxColumn, "nameDataGridViewTextBoxColumn");
      this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
      this.nameDataGridViewTextBoxColumn.ReadOnly = true;
      this.Adres.DataPropertyName = "Adres";
      componentResourceManager.ApplyResources((object) this.Adres, "Adres");
      this.Adres.Name = "Adres";
      this.Adres.ReadOnly = true;
      this.Telefoon.DataPropertyName = "Telefoon";
      componentResourceManager.ApplyResources((object) this.Telefoon, "Telefoon");
      this.Telefoon.Name = "Telefoon";
      this.Telefoon.ReadOnly = true;
      this.Verantwoordelijke.DataPropertyName = "Verantwoordelijke";
      componentResourceManager.ApplyResources((object) this.Verantwoordelijke, "Verantwoordelijke");
      this.Verantwoordelijke.Name = "Verantwoordelijke";
      this.Verantwoordelijke.ReadOnly = true;
      this.Email.DataPropertyName = "Email";
      componentResourceManager.ApplyResources((object) this.Email, "Email");
      this.Email.Name = "Email";
      this.Email.ReadOnly = true;
      this.bindingSourceClubs.DataMember = "Clubs";
      this.bindingSourceClubs.DataSource = (object) this.bceDataSetLocal;
      this.bindingSourceClubs.PositionChanged += new EventHandler(this.bindingSourceClubs_PositionChanged);
      this.bceDataSetLocal.DataSetName = "BCEDataSet";
      this.bceDataSetLocal.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.bindingNavigatorAdressen.AddNewItem = (ToolStripItem) this.bindingNavigatorAddNewItem;
      this.bindingNavigatorAdressen.BindingSource = this.bindingSourceClubs;
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
        (ToolStripItem) this.toolStripButtonFromMaster,
        (ToolStripItem) this.toolStripButtonToMaster,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.toolStripButtonCheckRings,
        (ToolStripItem) this.toolStripButtonNaarKBDB
      });
      componentResourceManager.ApplyResources((object) this.bindingNavigatorAdressen, "bindingNavigatorAdressen");
      this.bindingNavigatorAdressen.MoveFirstItem = (ToolStripItem) this.bindingNavigatorMoveFirstItem;
      this.bindingNavigatorAdressen.MoveLastItem = (ToolStripItem) this.bindingNavigatorMoveLastItem;
      this.bindingNavigatorAdressen.MoveNextItem = (ToolStripItem) this.bindingNavigatorMoveNextItem;
      this.bindingNavigatorAdressen.MovePreviousItem = (ToolStripItem) this.bindingNavigatorMovePreviousItem;
      this.bindingNavigatorAdressen.Name = "bindingNavigatorAdressen";
      this.bindingNavigatorAdressen.PositionItem = (ToolStripItem) this.bindingNavigatorPositionItem;
      this.bindingNavigatorAdressen.Stretch = true;
      this.bindingNavigatorAdressen.MouseDoubleClick += new MouseEventHandler(this.bindingNavigatorAdressen_MouseDoubleClick);
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
      this.toolStripButtonFromMaster.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonFromMaster.Image = (Image) Resources.FromMaster;
      componentResourceManager.ApplyResources((object) this.toolStripButtonFromMaster, "toolStripButtonFromMaster");
      this.toolStripButtonFromMaster.Name = "toolStripButtonFromMaster";
      this.toolStripButtonFromMaster.Click += new EventHandler(this.toolStripButton2_Click);
      this.toolStripButtonToMaster.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonToMaster.Image = (Image) Resources.ToMaster;
      componentResourceManager.ApplyResources((object) this.toolStripButtonToMaster, "toolStripButtonToMaster");
      this.toolStripButtonToMaster.Name = "toolStripButtonToMaster";
      this.toolStripButtonToMaster.Click += new EventHandler(this.toolStripButton1_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator2, "toolStripSeparator2");
      this.toolStripButtonCheckRings.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonCheckRings.Image = (Image) Resources.CheckRing;
      componentResourceManager.ApplyResources((object) this.toolStripButtonCheckRings, "toolStripButtonCheckRings");
      this.toolStripButtonCheckRings.Name = "toolStripButtonCheckRings";
      this.toolStripButtonCheckRings.Click += new EventHandler(this.toolStripButtonCheckRings_Click);
      this.toolStripButtonNaarKBDB.DisplayStyle = ToolStripItemDisplayStyle.Image;
      componentResourceManager.ApplyResources((object) this.toolStripButtonNaarKBDB, "toolStripButtonNaarKBDB");
      this.toolStripButtonNaarKBDB.Name = "toolStripButtonNaarKBDB";
      this.toolStripButtonNaarKBDB.Click += new EventHandler(this.toolStripButtonNaarKBDB_Click);
      this.panelDetail.Controls.Add((Control) this.buttonChangeBetaUrl);
      this.panelDetail.Controls.Add((Control) this.textBoxPasBetaUrl);
      this.panelDetail.Controls.Add((Control) this.labelPasBetaUrl);
      this.panelDetail.Controls.Add((Control) this.buttonInitPAS);
      this.panelDetail.Controls.Add((Control) this.textBoxPassword);
      this.panelDetail.Controls.Add((Control) this.labelLogin);
      this.panelDetail.Controls.Add((Control) this.buttonTestBW);
      this.panelDetail.Controls.Add((Control) this.labelPassword);
      this.panelDetail.Controls.Add((Control) this.textBoxLoginPas);
      this.panelDetail.Controls.Add((Control) this.pictureBoxPasClub);
      this.panelDetail.Controls.Add((Control) this.buttonChangePincode);
      this.panelDetail.Controls.Add((Control) this.gemeenteLabel);
      this.panelDetail.Controls.Add((Control) this.gemeenteTextBox);
      this.panelDetail.Controls.Add((Control) this.postcodeTextBox);
      this.panelDetail.Controls.Add((Control) this.emailLabel);
      this.panelDetail.Controls.Add((Control) this.emailTextBox);
      this.panelDetail.Controls.Add((Control) this.verantwoordelijkeTelefoonLabel);
      this.panelDetail.Controls.Add((Control) this.verantwoordelijkeTelefoonTextBox);
      this.panelDetail.Controls.Add((Control) this.verantwoordelijkeLabel);
      this.panelDetail.Controls.Add((Control) this.verantwoordelijkeTextBox);
      this.panelDetail.Controls.Add((Control) this.serieNrMasterLabel);
      this.panelDetail.Controls.Add((Control) this.serieNrMasterTextBox);
      this.panelDetail.Controls.Add((Control) this.telefoonLabel);
      this.panelDetail.Controls.Add((Control) this.telefoonTextBox);
      this.panelDetail.Controls.Add((Control) this.adresLabel);
      this.panelDetail.Controls.Add((Control) this.adresTextBox);
      this.panelDetail.Controls.Add((Control) this.pincodeLabel);
      this.panelDetail.Controls.Add((Control) this.pincodeTextBox);
      this.panelDetail.Controls.Add((Control) label2);
      this.panelDetail.Controls.Add((Control) this.textBoxClubNumber);
      this.panelDetail.Controls.Add((Control) this.clubIDTextBox);
      this.panelDetail.Controls.Add((Control) label1);
      this.panelDetail.Controls.Add((Control) this.nameTextBox);
      componentResourceManager.ApplyResources((object) this.panelDetail, "panelDetail");
      this.panelDetail.Name = "panelDetail";
      componentResourceManager.ApplyResources((object) this.buttonChangeBetaUrl, "buttonChangeBetaUrl");
      this.buttonChangeBetaUrl.Name = "buttonChangeBetaUrl";
      this.buttonChangeBetaUrl.UseVisualStyleBackColor = true;
      this.buttonChangeBetaUrl.Click += new EventHandler(this.ButtonChangeBetaUrl_Click);
      this.textBoxPasBetaUrl.DataBindings.Add(new Binding("Text", (object) Settings.Default, "PASBetaUrl", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBoxPasBetaUrl, "textBoxPasBetaUrl");
      this.textBoxPasBetaUrl.Name = "textBoxPasBetaUrl";
      this.textBoxPasBetaUrl.ReadOnly = true;
      this.textBoxPasBetaUrl.Text = Settings.Default.PASBetaUrl;
      componentResourceManager.ApplyResources((object) this.labelPasBetaUrl, "labelPasBetaUrl");
      this.labelPasBetaUrl.Name = "labelPasBetaUrl";
      componentResourceManager.ApplyResources((object) this.buttonInitPAS, "buttonInitPAS");
      this.buttonInitPAS.ForeColor = Color.Red;
      this.buttonInitPAS.Name = "buttonInitPAS";
      this.buttonInitPAS.UseVisualStyleBackColor = true;
      this.buttonInitPAS.Click += new EventHandler(this.buttonInitPAS_Click);
      this.textBoxPassword.DataBindings.Add(new Binding("Text", (object) Settings.Default, "PASPassword", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBoxPassword, "textBoxPassword");
      this.textBoxPassword.Name = "textBoxPassword";
      this.textBoxPassword.Text = Settings.Default.PASPassword;
      componentResourceManager.ApplyResources((object) this.labelLogin, "labelLogin");
      this.labelLogin.Name = "labelLogin";
      componentResourceManager.ApplyResources((object) this.buttonTestBW, "buttonTestBW");
      this.buttonTestBW.Name = "buttonTestBW";
      this.buttonTestBW.UseVisualStyleBackColor = true;
      this.buttonTestBW.Click += new EventHandler(this.buttonTestBW_Click);
      componentResourceManager.ApplyResources((object) this.labelPassword, "labelPassword");
      this.labelPassword.Name = "labelPassword";
      this.textBoxLoginPas.DataBindings.Add(new Binding("Text", (object) Settings.Default, "PASUserName", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.textBoxLoginPas, "textBoxLoginPas");
      this.textBoxLoginPas.Name = "textBoxLoginPas";
      this.textBoxLoginPas.Text = Settings.Default.PASUserName;
      componentResourceManager.ApplyResources((object) this.pictureBoxPasClub, "pictureBoxPasClub");
      this.pictureBoxPasClub.Name = "pictureBoxPasClub";
      this.pictureBoxPasClub.TabStop = false;
      componentResourceManager.ApplyResources((object) this.buttonChangePincode, "buttonChangePincode");
      this.buttonChangePincode.Name = "buttonChangePincode";
      this.buttonChangePincode.TabStop = false;
      this.buttonChangePincode.UseVisualStyleBackColor = true;
      this.buttonChangePincode.Click += new EventHandler(this.buttonChangePincode_Click);
      this.gemeenteTextBox.DataBindings.Add(new Binding("Text", (object) this.bindingSourceClubs, "Gemeente", true));
      componentResourceManager.ApplyResources((object) this.gemeenteTextBox, "gemeenteTextBox");
      this.gemeenteTextBox.Name = "gemeenteTextBox";
      this.gemeenteTextBox.TextChanged += new EventHandler(this.nameTextBox_TextChanged);
      this.gemeenteTextBox.Leave += new EventHandler(this.nameTextBox_Leave);
      this.postcodeTextBox.DataBindings.Add(new Binding("Text", (object) this.bindingSourceClubs, "Postcode", true));
      componentResourceManager.ApplyResources((object) this.postcodeTextBox, "postcodeTextBox");
      this.postcodeTextBox.Name = "postcodeTextBox";
      this.postcodeTextBox.TextChanged += new EventHandler(this.nameTextBox_TextChanged);
      this.postcodeTextBox.Leave += new EventHandler(this.nameTextBox_Leave);
      this.emailTextBox.DataBindings.Add(new Binding("Text", (object) this.bindingSourceClubs, "Email", true));
      componentResourceManager.ApplyResources((object) this.emailTextBox, "emailTextBox");
      this.emailTextBox.Name = "emailTextBox";
      this.emailTextBox.Leave += new EventHandler(this.nameTextBox_Leave);
      this.verantwoordelijkeTelefoonTextBox.DataBindings.Add(new Binding("Text", (object) this.bindingSourceClubs, "VerantwoordelijkeTelefoon", true));
      componentResourceManager.ApplyResources((object) this.verantwoordelijkeTelefoonTextBox, "verantwoordelijkeTelefoonTextBox");
      this.verantwoordelijkeTelefoonTextBox.Name = "verantwoordelijkeTelefoonTextBox";
      this.verantwoordelijkeTelefoonTextBox.Leave += new EventHandler(this.nameTextBox_Leave);
      this.verantwoordelijkeTextBox.DataBindings.Add(new Binding("Text", (object) this.bindingSourceClubs, "Verantwoordelijke", true));
      componentResourceManager.ApplyResources((object) this.verantwoordelijkeTextBox, "verantwoordelijkeTextBox");
      this.verantwoordelijkeTextBox.Name = "verantwoordelijkeTextBox";
      this.verantwoordelijkeTextBox.Leave += new EventHandler(this.nameTextBox_Leave);
      this.serieNrMasterTextBox.DataBindings.Add(new Binding("Text", (object) this.bindingSourceClubs, "SerieNrMaster", true));
      componentResourceManager.ApplyResources((object) this.serieNrMasterTextBox, "serieNrMasterTextBox");
      this.serieNrMasterTextBox.Name = "serieNrMasterTextBox";
      this.serieNrMasterTextBox.ReadOnly = true;
      this.serieNrMasterTextBox.Leave += new EventHandler(this.nameTextBox_Leave);
      this.telefoonTextBox.DataBindings.Add(new Binding("Text", (object) this.bindingSourceClubs, "Telefoon", true));
      componentResourceManager.ApplyResources((object) this.telefoonTextBox, "telefoonTextBox");
      this.telefoonTextBox.Name = "telefoonTextBox";
      this.telefoonTextBox.Leave += new EventHandler(this.nameTextBox_Leave);
      this.adresTextBox.DataBindings.Add(new Binding("Text", (object) this.bindingSourceClubs, "Adres", true));
      componentResourceManager.ApplyResources((object) this.adresTextBox, "adresTextBox");
      this.adresTextBox.Name = "adresTextBox";
      this.adresTextBox.TextChanged += new EventHandler(this.nameTextBox_TextChanged);
      this.adresTextBox.Leave += new EventHandler(this.nameTextBox_Leave);
      this.pincodeTextBox.DataBindings.Add(new Binding("Text", (object) this.bindingSourceClubs, "Pincode", true));
      componentResourceManager.ApplyResources((object) this.pincodeTextBox, "pincodeTextBox");
      this.pincodeTextBox.Name = "pincodeTextBox";
      this.pincodeTextBox.ReadOnly = true;
      this.pincodeTextBox.TabStop = false;
      this.pincodeTextBox.UseSystemPasswordChar = true;
      this.pincodeTextBox.Leave += new EventHandler(this.nameTextBox_Leave);
      this.textBoxClubNumber.DataBindings.Add(new Binding("Text", (object) this.bindingSourceClubs, "ClubNumber", true));
      componentResourceManager.ApplyResources((object) this.textBoxClubNumber, "textBoxClubNumber");
      this.textBoxClubNumber.Name = "textBoxClubNumber";
      this.textBoxClubNumber.TextChanged += new EventHandler(this.nameTextBox_TextChanged);
      this.textBoxClubNumber.Leave += new EventHandler(this.nameTextBox_Leave);
      this.clubIDTextBox.DataBindings.Add(new Binding("Text", (object) this.bindingSourceClubs, "ClubID", true));
      componentResourceManager.ApplyResources((object) this.clubIDTextBox, "clubIDTextBox");
      this.clubIDTextBox.Name = "clubIDTextBox";
      this.clubIDTextBox.TextChanged += new EventHandler(this.nameTextBox_TextChanged);
      this.clubIDTextBox.Leave += new EventHandler(this.nameTextBox_Leave);
      this.nameTextBox.DataBindings.Add(new Binding("Text", (object) this.bindingSourceClubs, "Name", true));
      componentResourceManager.ApplyResources((object) this.nameTextBox, "nameTextBox");
      this.nameTextBox.Name = "nameTextBox";
      this.nameTextBox.TextChanged += new EventHandler(this.nameTextBox_TextChanged);
      this.nameTextBox.Leave += new EventHandler(this.nameTextBox_Leave);
      this.errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
      this.errorProvider.ContainerControl = (ContainerControl) this;
      this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      this.dataGridViewTextBoxColumn1.ReadOnly = true;
      this.dataGridViewTextBoxColumn2.DataPropertyName = "ClubID";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      this.dataGridViewTextBoxColumn2.ReadOnly = true;
      this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
      this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
      this.dataGridViewTextBoxColumn3.ReadOnly = true;
      this.dataGridViewTextBoxColumn4.DataPropertyName = "Adres";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
      this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
      this.dataGridViewTextBoxColumn4.ReadOnly = true;
      this.dataGridViewTextBoxColumn5.DataPropertyName = "Telefoon";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
      this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
      this.dataGridViewTextBoxColumn5.ReadOnly = true;
      this.dataGridViewTextBoxColumn6.DataPropertyName = "Verantwoordelijke";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn6, "dataGridViewTextBoxColumn6");
      this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
      this.dataGridViewTextBoxColumn6.ReadOnly = true;
      this.dataGridViewTextBoxColumn7.DataPropertyName = "Email";
      componentResourceManager.ApplyResources((object) this.dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
      this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
      this.dataGridViewTextBoxColumn7.ReadOnly = true;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.bindingNavigatorAdressen);
      this.Controls.Add((Control) this.panelDetail);
      this.Name = nameof (ClubsPage);
      this.Load += new EventHandler(this.ClubsPage_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((ISupportInitialize) this.bindingSourceClubs).EndInit();
      this.bceDataSetLocal.EndInit();
      this.bindingNavigatorAdressen.EndInit();
      this.bindingNavigatorAdressen.ResumeLayout(false);
      this.bindingNavigatorAdressen.PerformLayout();
      this.panelDetail.ResumeLayout(false);
      this.panelDetail.PerformLayout();
      ((ISupportInitialize) this.pictureBoxPasClub).EndInit();
      ((ISupportInitialize) this.errorProvider).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
