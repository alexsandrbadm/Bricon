// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.CheckRingForm
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

namespace BriconLib.UI
{
  public class CheckRingForm : Form
  {
    private CheckRingCommand _cmd;
    private BCEDataSet.AdressenRow _fancierRow;
    private int _foundedRingID = -1;
    private IContainer components;
    private Button buttonCancel;
    private GroupBox groupBoxDataInRing;
    private Label labelYear1;
    private Label labelLicence1;
    private Label labelRing;
    private Label labelYearLabel1;
    private Label labelLicenceLabel1;
    private Label labelRingHeader;
    private GroupBox groupBoxDataInBCE;
    private Label labelYear2;
    private Label labelLicence2;
    private Label labelDBRing;
    private Label labelYearLabel2;
    private Label labelLicenceLabel2;
    private Label labelDBRingHeader;
    private Label labelRingCorrect;
    private Label labelYearInvalid;
    private Label labelRingFound;
    private Label labelLicenseWrong;
    private Label labelAlreadyExistWithIncorrectLicence;
    private Button buttonDelete;
    private Button buttonKeep;
    private Label label1;
    private Label labelEmptyRing;

    public CheckRingForm() => this.InitializeComponent();

    public void SetData(CheckRingCommand cmd, BCEDataSet.AdressenRow fancierRow)
    {
      this._cmd = cmd;
      this._fancierRow = fancierRow;
      this._foundedRingID = -1;
      this.labelRing.Text = this._cmd.Ring;
      this.labelDBRing.Text = ml.ml_string(498, "Not Found");
      foreach (BCEDataSet.PigeonsRow pigeonsRow in BCEDatabase.DataSet.Pigeons.Select(string.Format("ELRing = '{0}' and ELRing <> '' and fancierID = {1} ", (object) this._cmd.Ring, (object) this._fancierRow.Id)))
      {
        if (pigeonsRow.RowState != DataRowState.Deleted)
        {
          this._foundedRingID = pigeonsRow.ID;
          this.labelDBRing.Text = pigeonsRow.DBRing;
        }
      }
      this.labelLicence2.Text = Conversion.StripLicense(this._fancierRow.Licentie.Replace(" ", ""));
      this.labelYear2.Text = DateTime.Now.Year.ToString("0000");
      bool flag1 = false;
      if (this._cmd.StatusSecondPage == (byte) 1)
      {
        if (Utils.IsCountry("BE"))
          this.labelLicence1.Text = this._cmd.Licence.ToString("00000000");
        else
          this.labelLicence1.Text = this._cmd.Licence.ToString("00000000");
        int year = (int) this._cmd.Year;
        this.labelYear1.Text = (year <= 50 ? year + 2000 : year + 1900).ToString("0000");
      }
      else
      {
        this.labelLicence1.Text = ml.ml_string(491, "NOT Locked");
        this.labelYear1.Text = ml.ml_string(491, "NOT Locked");
        flag1 = true;
      }
      bool flag2 = true;
      if (!Utils.IsCountry("HU") && !Utils.IsCountry("RO") && (!Utils.IsCountry("MD") && Utils.IsUKProtocol()))
      {
        this.labelLicence1.Text = ml.ml_string(522, "Not Active");
        this.labelYear1.Text = ml.ml_string(522, "Not Active");
        flag2 = false;
      }
      bool flag3 = false;
      this.labelYearInvalid.Visible = false;
      if (this.labelYear1.Text == this.labelYear2.Text & flag2)
      {
        this.labelYearInvalid.Visible = true;
        flag3 = true;
      }
      this.labelLicenseWrong.Visible = false;
      if (((!(this.labelLicence1.Text != this.labelLicence2.Text) ? 0 : (!flag1 ? 1 : 0)) & (flag2 ? 1 : 0)) != 0)
      {
        this.labelLicenseWrong.Visible = true;
        flag3 = true;
      }
      this.labelEmptyRing.Visible = false;
      if (flag1 || !flag2)
      {
        this.labelEmptyRing.Visible = true;
        flag3 = true;
      }
      this.buttonKeep.Visible = false;
      this.buttonDelete.Visible = false;
      this.labelRingFound.Visible = false;
      this.labelAlreadyExistWithIncorrectLicence.Visible = false;
      if (this._foundedRingID != -1)
      {
        this.labelRingFound.ForeColor = Color.Black;
        this.labelRingFound.Visible = true;
        this.labelRingFound.Text = string.Format(ml.ml_string(472, "Ring already linked with {0}"), (object) this.labelDBRing.Text);
        this.buttonKeep.Visible = true;
        this.buttonDelete.Visible = true;
        if (this.labelLicenseWrong.Visible)
        {
          this.buttonKeep.Visible = false;
          this.buttonDelete.Visible = false;
          BCEDatabase.DataSet.Pigeons.FindByID(this._foundedRingID).Delete();
          this.labelRingFound.ForeColor = Color.Red;
          this.labelAlreadyExistWithIncorrectLicence.Visible = true;
        }
      }
      this.labelRingCorrect.Visible = !flag3;
    }

    public bool IsRingAlreadyLinked => this.buttonKeep.Visible || this.buttonDelete.Visible;

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      CommunicationState.Instance.ReadingRing = false;
      if (!Settings.Default.AntenneWithoutMaster)
      {
        int num = (int) MessageBox.Show(ml.ml_string(210, "Please press <C> on the master for at least one second to activate the master again"), Defines.MessageBoxCaption);
      }
      CommunicationState.Instance.Modified = true;
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void buttonKeep_Click(object sender, EventArgs e)
    {
      this._foundedRingID = -1;
      this.buttonKeep.Visible = false;
      this.buttonDelete.Visible = false;
      this.labelEmptyRing.Visible = false;
      this.labelRingFound.Visible = false;
      this.labelAlreadyExistWithIncorrectLicence.Visible = false;
      this.labelLicenseWrong.Visible = false;
      this.labelYearInvalid.Visible = false;
      this._cmd.AskNextRing();
    }

    private void buttonDelete_Click(object sender, EventArgs e)
    {
      if (this._foundedRingID >= 0)
        BCEDatabase.DataSet.Pigeons.FindByID(this._foundedRingID).Delete();
      this.labelEmptyRing.Visible = false;
      this.buttonKeep.Visible = false;
      this.buttonDelete.Visible = false;
      this._foundedRingID = -1;
      this.labelRingFound.Visible = false;
      this.labelAlreadyExistWithIncorrectLicence.Visible = false;
      this.labelLicenseWrong.Visible = false;
      this.labelYearInvalid.Visible = false;
      this._cmd.AskNextRing();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (CheckRingForm));
      this.buttonCancel = new Button();
      this.groupBoxDataInRing = new GroupBox();
      this.labelYear1 = new Label();
      this.labelLicence1 = new Label();
      this.labelRing = new Label();
      this.labelYearLabel1 = new Label();
      this.labelLicenceLabel1 = new Label();
      this.labelRingHeader = new Label();
      this.groupBoxDataInBCE = new GroupBox();
      this.labelYear2 = new Label();
      this.labelLicence2 = new Label();
      this.labelDBRing = new Label();
      this.labelYearLabel2 = new Label();
      this.labelLicenceLabel2 = new Label();
      this.labelDBRingHeader = new Label();
      this.labelRingCorrect = new Label();
      this.labelYearInvalid = new Label();
      this.labelRingFound = new Label();
      this.labelLicenseWrong = new Label();
      this.labelAlreadyExistWithIncorrectLicence = new Label();
      this.buttonDelete = new Button();
      this.buttonKeep = new Button();
      this.label1 = new Label();
      this.labelEmptyRing = new Label();
      this.groupBoxDataInRing.SuspendLayout();
      this.groupBoxDataInBCE.SuspendLayout();
      this.SuspendLayout();
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      componentResourceManager.ApplyResources((object) this.buttonCancel, "buttonCancel");
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      this.groupBoxDataInRing.Controls.Add((Control) this.labelYear1);
      this.groupBoxDataInRing.Controls.Add((Control) this.labelLicence1);
      this.groupBoxDataInRing.Controls.Add((Control) this.labelRing);
      this.groupBoxDataInRing.Controls.Add((Control) this.labelYearLabel1);
      this.groupBoxDataInRing.Controls.Add((Control) this.labelLicenceLabel1);
      this.groupBoxDataInRing.Controls.Add((Control) this.labelRingHeader);
      componentResourceManager.ApplyResources((object) this.groupBoxDataInRing, "groupBoxDataInRing");
      this.groupBoxDataInRing.Name = "groupBoxDataInRing";
      this.groupBoxDataInRing.TabStop = false;
      componentResourceManager.ApplyResources((object) this.labelYear1, "labelYear1");
      this.labelYear1.Name = "labelYear1";
      componentResourceManager.ApplyResources((object) this.labelLicence1, "labelLicence1");
      this.labelLicence1.Name = "labelLicence1";
      componentResourceManager.ApplyResources((object) this.labelRing, "labelRing");
      this.labelRing.Name = "labelRing";
      componentResourceManager.ApplyResources((object) this.labelYearLabel1, "labelYearLabel1");
      this.labelYearLabel1.Name = "labelYearLabel1";
      componentResourceManager.ApplyResources((object) this.labelLicenceLabel1, "labelLicenceLabel1");
      this.labelLicenceLabel1.Name = "labelLicenceLabel1";
      componentResourceManager.ApplyResources((object) this.labelRingHeader, "labelRingHeader");
      this.labelRingHeader.Name = "labelRingHeader";
      this.groupBoxDataInBCE.Controls.Add((Control) this.labelYear2);
      this.groupBoxDataInBCE.Controls.Add((Control) this.labelLicence2);
      this.groupBoxDataInBCE.Controls.Add((Control) this.labelDBRing);
      this.groupBoxDataInBCE.Controls.Add((Control) this.labelYearLabel2);
      this.groupBoxDataInBCE.Controls.Add((Control) this.labelLicenceLabel2);
      this.groupBoxDataInBCE.Controls.Add((Control) this.labelDBRingHeader);
      componentResourceManager.ApplyResources((object) this.groupBoxDataInBCE, "groupBoxDataInBCE");
      this.groupBoxDataInBCE.Name = "groupBoxDataInBCE";
      this.groupBoxDataInBCE.TabStop = false;
      componentResourceManager.ApplyResources((object) this.labelYear2, "labelYear2");
      this.labelYear2.Name = "labelYear2";
      componentResourceManager.ApplyResources((object) this.labelLicence2, "labelLicence2");
      this.labelLicence2.Name = "labelLicence2";
      componentResourceManager.ApplyResources((object) this.labelDBRing, "labelDBRing");
      this.labelDBRing.Name = "labelDBRing";
      componentResourceManager.ApplyResources((object) this.labelYearLabel2, "labelYearLabel2");
      this.labelYearLabel2.Name = "labelYearLabel2";
      componentResourceManager.ApplyResources((object) this.labelLicenceLabel2, "labelLicenceLabel2");
      this.labelLicenceLabel2.Name = "labelLicenceLabel2";
      componentResourceManager.ApplyResources((object) this.labelDBRingHeader, "labelDBRingHeader");
      this.labelDBRingHeader.Name = "labelDBRingHeader";
      componentResourceManager.ApplyResources((object) this.labelRingCorrect, "labelRingCorrect");
      this.labelRingCorrect.ForeColor = Color.Green;
      this.labelRingCorrect.Name = "labelRingCorrect";
      componentResourceManager.ApplyResources((object) this.labelYearInvalid, "labelYearInvalid");
      this.labelYearInvalid.ForeColor = Color.Red;
      this.labelYearInvalid.Name = "labelYearInvalid";
      componentResourceManager.ApplyResources((object) this.labelRingFound, "labelRingFound");
      this.labelRingFound.ForeColor = Color.Black;
      this.labelRingFound.Name = "labelRingFound";
      componentResourceManager.ApplyResources((object) this.labelLicenseWrong, "labelLicenseWrong");
      this.labelLicenseWrong.ForeColor = Color.Red;
      this.labelLicenseWrong.Name = "labelLicenseWrong";
      componentResourceManager.ApplyResources((object) this.labelAlreadyExistWithIncorrectLicence, "labelAlreadyExistWithIncorrectLicence");
      this.labelAlreadyExistWithIncorrectLicence.ForeColor = Color.Red;
      this.labelAlreadyExistWithIncorrectLicence.Name = "labelAlreadyExistWithIncorrectLicence";
      componentResourceManager.ApplyResources((object) this.buttonDelete, "buttonDelete");
      this.buttonDelete.Name = "buttonDelete";
      this.buttonDelete.UseVisualStyleBackColor = true;
      this.buttonDelete.Click += new EventHandler(this.buttonDelete_Click);
      componentResourceManager.ApplyResources((object) this.buttonKeep, "buttonKeep");
      this.buttonKeep.Name = "buttonKeep";
      this.buttonKeep.UseVisualStyleBackColor = true;
      this.buttonKeep.Click += new EventHandler(this.buttonKeep_Click);
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.ForeColor = Color.Black;
      this.label1.Name = "label1";
      componentResourceManager.ApplyResources((object) this.labelEmptyRing, "labelEmptyRing");
      this.labelEmptyRing.ForeColor = Color.Green;
      this.labelEmptyRing.Name = "labelEmptyRing";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonCancel;
      this.Controls.Add((Control) this.labelEmptyRing);
      this.Controls.Add((Control) this.buttonKeep);
      this.Controls.Add((Control) this.buttonDelete);
      this.Controls.Add((Control) this.labelAlreadyExistWithIncorrectLicence);
      this.Controls.Add((Control) this.labelLicenseWrong);
      this.Controls.Add((Control) this.labelRingFound);
      this.Controls.Add((Control) this.labelYearInvalid);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.labelRingCorrect);
      this.Controls.Add((Control) this.groupBoxDataInBCE);
      this.Controls.Add((Control) this.groupBoxDataInRing);
      this.Controls.Add((Control) this.buttonCancel);
      this.Name = nameof (CheckRingForm);
      this.ShowInTaskbar = false;
      this.groupBoxDataInRing.ResumeLayout(false);
      this.groupBoxDataInRing.PerformLayout();
      this.groupBoxDataInBCE.ResumeLayout(false);
      this.groupBoxDataInBCE.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
