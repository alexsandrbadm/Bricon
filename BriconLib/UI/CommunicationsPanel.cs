// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.CommunicationsPanel
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.BCE;
using BriconLib.Communications;
using BriconLib.Other;
using BriconLib.Properties;
using MultiLang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BriconLib.UI
{
  public class CommunicationsPanel : UserControl
  {
    public bool IgnoreErrors;
    private IContainer components;
    private ImageList imageList1;
    private SplitContainer splitContainer1;
    private Panel panelMaster;
    private CheckedListBox checkedListBoxMaster;
    private Label labelMasterVersion;
    private Label labelMasterFound;
    private PictureBox pictureBoxMaster;
    private Panel panel1;
    private Label labelBAVersion;
    private Label labelBAFound;
    private PictureBox pictureBoxBA;
    private Button buttonClearMaster;
    private CheckedListBox checkedListBoxBA;
    private Button buttonClearBA;
    private Label labelConnectMaster;
    private Label labelConnectBA;
    private Label labelReadingRing;
    private Button buttonCancel;
    private Timer timerHideMaster;
    private Timer timerHideBA;

    public CommunicationsPanel() => this.InitializeComponent();

    private void CommunicationsPanel_Load(object sender, EventArgs e)
    {
    }

    public void RemoveLastMasterCommand() => this.checkedListBoxMaster.Items.RemoveAt(this.checkedListBoxMaster.Items.Count - 1);

    public void UpdateComm(CommunicationState state)
    {
      if (this.imageList1.Images.Count == 0)
        return;
      if (Settings.Default.AntenneWithoutMaster)
      {
        this.pictureBoxMaster.Image = this.imageList1.Images[8];
        this.labelReadingRing.Text = ml.ml_string(749, "Reading ring... Press <ESC> to stop");
      }
      else
      {
        this.pictureBoxMaster.Image = this.imageList1.Images[0];
        this.labelReadingRing.Text = ml.ml_string(860, "Reading ring...Press <C> on master to stop");
      }
      this.pictureBoxBA.Image = this.imageList1.Images[2];
      if (state.MasterFound)
      {
        this.pictureBoxMaster.Visible = state.MasterFound;
        this.labelMasterFound.Visible = state.MasterFound && !state.ReadingRing;
        this.labelMasterVersion.Visible = state.MasterFound && !state.ReadingRing;
        this.labelMasterVersion.Text = state.MasterVersion;
      }
      this.timerHideMaster.Enabled = !state.MasterFound;
      if (state.ReadingRing != this.labelReadingRing.Visible)
      {
        this.labelReadingRing.Visible = state.ReadingRing;
        this.buttonCancel.Visible = state.ReadingRing;
        this.labelMasterFound.Visible = state.MasterFound && !state.ReadingRing;
        this.labelMasterVersion.Visible = state.MasterFound && !state.ReadingRing;
      }
      if (state.BAFound)
      {
        this.labelBAVersion.Text = state.BAVersion;
        if (state.IsExtreme)
          this.pictureBoxBA.Image = this.imageList1.Images["BAExtreme.bmp"];
        else if (state.IsSpeedy)
          this.pictureBoxBA.Image = this.imageList1.Images["BASpeedy.bmp"];
        else if (state.IsSpeedyXtreme)
        {
          this.pictureBoxBA.Image = this.imageList1.Images["BASPX.bmp"];
        }
        else
        {
          switch ((Adresses) state.BAAddress)
          {
            case Adresses.ClubAntennaOrBriconInUK:
            case Adresses.BA_Bricon:
              this.pictureBoxBA.Image = this.imageList1.Images[2];
              break;
            case Adresses.BA_First:
              this.pictureBoxBA.Image = this.imageList1.Images[3];
              break;
            case Adresses.BA_Benzing:
              this.pictureBoxBA.Image = this.imageList1.Images[1];
              break;
            case Adresses.BA_Tauris:
              this.pictureBoxBA.Image = this.imageList1.Images[5];
              break;
            case Adresses.BA_Tipes:
              this.pictureBoxBA.Image = this.imageList1.Images[6];
              break;
            case Adresses.BA_Unikon:
              this.pictureBoxBA.Image = this.imageList1.Images[7];
              break;
          }
        }
        this.pictureBoxBA.Visible = state.BAFound;
        this.labelBAFound.Visible = state.BAFound;
        this.labelBAVersion.Visible = state.BAFound;
      }
      this.timerHideBA.Enabled = !state.BAFound;
      List<BriconLib.Communications.Command> andClearCommands = state.GetAndClearCommands();
      if (andClearCommands.Count > 0)
      {
        this.checkedListBoxMaster.BeginUpdate();
        this.checkedListBoxBA.BeginUpdate();
        foreach (BriconLib.Communications.Command command in andClearCommands)
          (command.IsMasterCommand ? this.checkedListBoxMaster : this.checkedListBoxBA).Items.Add((object) command, false);
        this.checkedListBoxMaster.EndUpdate();
        this.checkedListBoxBA.EndUpdate();
        if (this.checkedListBoxBA.Items.Count > 0)
          this.checkedListBoxBA.TopIndex = this.checkedListBoxBA.Items.Count - 1;
        if (this.checkedListBoxMaster.Items.Count > 0)
          this.checkedListBoxMaster.TopIndex = this.checkedListBoxMaster.Items.Count - 1;
      }
      int num1 = -1;
      int num2 = -1;
      foreach (BriconLib.Communications.Command completedCommand in state.GetAndClearCompletedCommands())
      {
        CheckedListBox checkedListBox = completedCommand.IsMasterCommand ? this.checkedListBoxMaster : this.checkedListBoxBA;
        int index = checkedListBox.Items.IndexOf((object) completedCommand);
        if (index != -1)
        {
          checkedListBox.SetItemChecked(index, completedCommand.Success);
          checkedListBox.Invalidate(checkedListBox.GetItemRectangle(index));
          if (completedCommand.IsMasterCommand)
            num1 = index - 2;
          else
            num2 = index - 2;
        }
        if (!completedCommand.Success && completedCommand.Status != ResponseStatus.UserAbort && (completedCommand.Status != ResponseStatus.None && !this.IgnoreErrors))
        {
          checkedListBox.BackColor = Color.Red;
          checkedListBox.ForeColor = Color.White;
        }
        if (completedCommand.Status == ResponseStatus.UserAbort && MainForm.Instance._checkRingForm != null && MainForm.Instance._checkRingForm.Visible)
          MainForm.Instance._checkRingForm.Close();
      }
      if (num2 >= 0)
        this.checkedListBoxBA.TopIndex = num2;
      if (num1 >= 0)
        this.checkedListBoxMaster.TopIndex = num1;
      if (state.WaitingToConnectMaster != this.labelConnectMaster.Visible)
        this.labelConnectMaster.Visible = state.WaitingToConnectMaster;
      if (state.WaitingToConnectBA != this.labelConnectBA.Visible)
        this.labelConnectBA.Visible = state.WaitingToConnectBA;
      state.Modified = false;
      this.Invalidate(true);
    }

    private void buttonClearMaster_Click(object sender, EventArgs e)
    {
      CommunicationPool.Instance.ClearMessages(true);
      this.checkedListBoxMaster.Items.Clear();
      this.checkedListBoxMaster.BackColor = SystemColors.Window;
      this.checkedListBoxMaster.ForeColor = SystemColors.WindowText;
      CommunicationState.Instance.WaitingToConnectMaster = false;
    }

    public void buttonClearBA_Click(object sender, EventArgs e)
    {
      CommunicationPool.Instance.ClearMessages(false);
      this.checkedListBoxBA.Items.Clear();
      this.checkedListBoxBA.BackColor = SystemColors.Window;
      this.checkedListBoxBA.ForeColor = SystemColors.WindowText;
      CommunicationState.Instance.WaitingToConnectBA = false;
    }

    private void checkedListBoxMaster_DoubleClick(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show(ml.ml_string(128, "Please don't change the check boxes, it does not affect anything"), Defines.MessageBoxCaption);
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      CommunicationState.Instance.ReadingRing = false;
      (sender as Button).Visible = false;
      if (!Settings.Default.AntenneWithoutMaster)
      {
        int num = (int) MessageBox.Show(ml.ml_string(210, "Please press <C> on the master for at least one second to activate the master again"), Defines.MessageBoxCaption);
      }
      CommunicationState.Instance.Modified = true;
    }

    private void timerHideMaster_Tick(object sender, EventArgs e)
    {
      this.pictureBoxMaster.Visible = false;
      this.labelMasterFound.Visible = false;
      this.labelMasterVersion.Visible = false;
    }

    private void timerHideBA_Tick(object sender, EventArgs e)
    {
      this.pictureBoxBA.Visible = false;
      this.labelBAFound.Visible = false;
      this.labelBAVersion.Visible = false;
      if (CommunicationState.Instance.BAFound)
        return;
      CommunicationState.Instance.PreviousBAVersion = string.Empty;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (CommunicationsPanel));
      this.splitContainer1 = new SplitContainer();
      this.checkedListBoxMaster = new CheckedListBox();
      this.panelMaster = new Panel();
      this.buttonCancel = new Button();
      this.buttonClearMaster = new Button();
      this.labelReadingRing = new Label();
      this.labelConnectMaster = new Label();
      this.labelMasterVersion = new Label();
      this.labelMasterFound = new Label();
      this.pictureBoxMaster = new PictureBox();
      this.checkedListBoxBA = new CheckedListBox();
      this.panel1 = new Panel();
      this.labelConnectBA = new Label();
      this.buttonClearBA = new Button();
      this.labelBAVersion = new Label();
      this.labelBAFound = new Label();
      this.pictureBoxBA = new PictureBox();
      this.imageList1 = new ImageList(this.components);
      this.timerHideMaster = new Timer(this.components);
      this.timerHideBA = new Timer(this.components);
      this.splitContainer1.BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.panelMaster.SuspendLayout();
      ((ISupportInitialize) this.pictureBoxMaster).BeginInit();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.pictureBoxBA).BeginInit();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.splitContainer1, "splitContainer1");
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Panel1.Controls.Add((Control) this.checkedListBoxMaster);
      this.splitContainer1.Panel1.Controls.Add((Control) this.panelMaster);
      this.splitContainer1.Panel2.Controls.Add((Control) this.checkedListBoxBA);
      this.splitContainer1.Panel2.Controls.Add((Control) this.panel1);
      componentResourceManager.ApplyResources((object) this.checkedListBoxMaster, "checkedListBoxMaster");
      this.checkedListBoxMaster.Name = "checkedListBoxMaster";
      this.checkedListBoxMaster.SelectionMode = SelectionMode.None;
      this.checkedListBoxMaster.DoubleClick += new EventHandler(this.checkedListBoxMaster_DoubleClick);
      this.panelMaster.Controls.Add((Control) this.buttonCancel);
      this.panelMaster.Controls.Add((Control) this.buttonClearMaster);
      this.panelMaster.Controls.Add((Control) this.labelReadingRing);
      this.panelMaster.Controls.Add((Control) this.labelConnectMaster);
      this.panelMaster.Controls.Add((Control) this.labelMasterVersion);
      this.panelMaster.Controls.Add((Control) this.labelMasterFound);
      this.panelMaster.Controls.Add((Control) this.pictureBoxMaster);
      componentResourceManager.ApplyResources((object) this.panelMaster, "panelMaster");
      this.panelMaster.Name = "panelMaster";
      componentResourceManager.ApplyResources((object) this.buttonCancel, "buttonCancel");
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      componentResourceManager.ApplyResources((object) this.buttonClearMaster, "buttonClearMaster");
      this.buttonClearMaster.Name = "buttonClearMaster";
      this.buttonClearMaster.UseVisualStyleBackColor = true;
      this.buttonClearMaster.Click += new EventHandler(this.buttonClearMaster_Click);
      componentResourceManager.ApplyResources((object) this.labelReadingRing, "labelReadingRing");
      this.labelReadingRing.Name = "labelReadingRing";
      componentResourceManager.ApplyResources((object) this.labelConnectMaster, "labelConnectMaster");
      this.labelConnectMaster.Name = "labelConnectMaster";
      componentResourceManager.ApplyResources((object) this.labelMasterVersion, "labelMasterVersion");
      this.labelMasterVersion.Name = "labelMasterVersion";
      componentResourceManager.ApplyResources((object) this.labelMasterFound, "labelMasterFound");
      this.labelMasterFound.Name = "labelMasterFound";
      this.pictureBoxMaster.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.pictureBoxMaster, "pictureBoxMaster");
      this.pictureBoxMaster.Name = "pictureBoxMaster";
      this.pictureBoxMaster.TabStop = false;
      componentResourceManager.ApplyResources((object) this.checkedListBoxBA, "checkedListBoxBA");
      this.checkedListBoxBA.Name = "checkedListBoxBA";
      this.checkedListBoxBA.SelectionMode = SelectionMode.None;
      this.panel1.Controls.Add((Control) this.labelConnectBA);
      this.panel1.Controls.Add((Control) this.buttonClearBA);
      this.panel1.Controls.Add((Control) this.labelBAVersion);
      this.panel1.Controls.Add((Control) this.labelBAFound);
      this.panel1.Controls.Add((Control) this.pictureBoxBA);
      componentResourceManager.ApplyResources((object) this.panel1, "panel1");
      this.panel1.Name = "panel1";
      componentResourceManager.ApplyResources((object) this.labelConnectBA, "labelConnectBA");
      this.labelConnectBA.Name = "labelConnectBA";
      componentResourceManager.ApplyResources((object) this.buttonClearBA, "buttonClearBA");
      this.buttonClearBA.Name = "buttonClearBA";
      this.buttonClearBA.UseVisualStyleBackColor = true;
      this.buttonClearBA.Click += new EventHandler(this.buttonClearBA_Click);
      componentResourceManager.ApplyResources((object) this.labelBAVersion, "labelBAVersion");
      this.labelBAVersion.Name = "labelBAVersion";
      componentResourceManager.ApplyResources((object) this.labelBAFound, "labelBAFound");
      this.labelBAFound.Name = "labelBAFound";
      this.pictureBoxBA.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.pictureBoxBA, "pictureBoxBA");
      this.pictureBoxBA.Name = "pictureBoxBA";
      this.pictureBoxBA.TabStop = false;
      this.imageList1.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageList1.ImageStream");
      this.imageList1.TransparentColor = Color.Fuchsia;
      this.imageList1.Images.SetKeyName(0, "");
      this.imageList1.Images.SetKeyName(1, "BABenzing.bmp");
      this.imageList1.Images.SetKeyName(2, "BABricon.bmp");
      this.imageList1.Images.SetKeyName(3, "BAMega.bmp");
      this.imageList1.Images.SetKeyName(4, "BASpeedy.bmp");
      this.imageList1.Images.SetKeyName(5, "BATauris.bmp");
      this.imageList1.Images.SetKeyName(6, "BATipes.bmp");
      this.imageList1.Images.SetKeyName(7, "BAUnikon.bmp");
      this.imageList1.Images.SetKeyName(8, "AntennaActive.bmp");
      this.imageList1.Images.SetKeyName(9, "BAExtreme.bmp");
      this.imageList1.Images.SetKeyName(10, "BASPX.bmp");
      this.timerHideMaster.Interval = 5000;
      this.timerHideMaster.Tick += new EventHandler(this.timerHideMaster_Tick);
      this.timerHideBA.Interval = 3000;
      this.timerHideBA.Tick += new EventHandler(this.timerHideBA_Tick);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.splitContainer1);
      this.Name = nameof (CommunicationsPanel);
      this.Load += new EventHandler(this.CommunicationsPanel_Load);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.panelMaster.ResumeLayout(false);
      this.panelMaster.PerformLayout();
      ((ISupportInitialize) this.pictureBoxMaster).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.pictureBoxBA).EndInit();
      this.ResumeLayout(false);
    }
  }
}
