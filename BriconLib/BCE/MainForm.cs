// Decompiled with JetBrains decompiler
// Type: BriconLib.BCE.MainForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Communications;
using BriconLib.Data;
using BriconLib.Other;
using BriconLib.Properties;
using BriconLib.UI;
using BriconLib.Updater;
using MultiLang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace BriconLib.BCE
{
  public class MainForm : Form
  {
    public static MainForm Instance;
    private GetFancierCommand _lastfancierCmd;
    private List<GetBandTableCommand> _lastRingCmds = new List<GetBandTableCommand>();
    private bool _checkMasterVersion = true;
    private string previousReading = string.Empty;
    public CheckRingForm _checkRingForm;
    public CheckRingsForm _checkRingsForm;
    private string previousRingNr = string.Empty;
    private IContainer components;
    public BackgroundWorker backgroundCommunication;
    private TabControl tabControl;
    private TabPage tabPageFanciers;
    private TabPage tabPageFancier;
    private TabPage tabPageClubs;
    private TabPage tabPageFlights;
    private TabPage tabPageOptions;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel statusBarStatus;
    private FanciersPage fanciersPage;
    private SplitContainer splitContainer;
    public ClubsPage clubsPage;
    private FlightsPage flightsPage;
    private OptionsPage optionsPage;
    private CalculatorPage calculatorPage;
    public CommunicationsPanel communicationsPanel;
    private TabPage tabPageAbout;
    private ImageList imageList;
    private AboutPage aboutPage;
    public FancierPage fancierPage;
    private TabPage tabPageCalculator;
    private TabPage tabPagePAS;
    private PASPage pasPage;

    public MainForm()
    {
      MainForm.Instance = this;
      if (!Settings.Default.Version.Equals(Assembly.GetEntryAssembly().GetName().Version.ToString()))
      {
        Settings.Default.Upgrade();
        Settings.Default.Version = Assembly.GetEntryAssembly().GetName().Version.ToString();
      }
      this.AdjustLanguage();
      PrerequisitesInstall.InstallIfNeeded();
      SplashForm.ShowSplash();
      UpdateCheckingThread.Start(true);
      this.InitializeComponent();
      if (Settings.Default.MainFormMaximized)
        this.WindowState = FormWindowState.Maximized;
      else
        this.Size = Settings.Default.MainformClientSize;
      this.Location = Settings.Default.MainformLocation;
      try
      {
        this.clubsPage.bindingSourceClubs.DataSource = (object) BCEDatabase.DataSet;
        this.flightsPage.bindingSourceFlights.DataSource = (object) BCEDatabase.DataSet;
        this.fancierPage.SetDataSource(this.clubsPage.bindingSourceClubs);
        this.fanciersPage.SetDataSource(this.fancierPage.bindingSourceAdressen);
      }
      catch (Exception ex)
      {
        SplashForm.HideSplash();
        int num = (int) MessageBox.Show(ml.ml_string(146, "Error when opening the database, please check the database settings in the options page. Error: ") + ex.ToString());
      }
      if (OptionsPage.IsCalulationModuleLicensed())
        return;
      this.tabControl.TabPages.Remove(this.tabPageCalculator);
    }

    private void AdjustLanguage()
    {
      try
      {
        if (!(Settings.Default.Language != "Auto"))
          return;
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.Language);
      }
      catch (Exception ex)
      {
        Settings.Default.Language = "Auto";
        Settings.Default.Save();
      }
    }

    public void backgroundCommunication_DoWork(object sender, DoWorkEventArgs e) => CommunicationPool.Instance.CommunicationsLoop(sender as BackgroundWorker);

    private void backgroundCommunication_ProgressChanged(object sender, ProgressChangedEventArgs e) => this.HandleCommunicationState(e.UserState as CommunicationState);

    [DllImport("user32.dll")]
    private static extern int GetForegroundWindow();

    private void MainForm_Load(object sender, EventArgs e)
    {
      this.backgroundCommunication.RunWorkerAsync();
      if (Utils.IsCountry("BE"))
        FlightCalenderBelgium.AddFlights(true);
      SplashForm.HideSplash();
      foreach (string commandLineArg in Environment.GetCommandLineArgs())
      {
        if (commandLineArg.ToLower().Contains("readout"))
        {
          this.communicationsPanel.IgnoreErrors = true;
          FlightReadoutForm flightReadoutForm = new FlightReadoutForm();
          MainForm.WindowWrapper windowWrapper = new MainForm.WindowWrapper(new IntPtr(MainForm.GetForegroundWindow()));
          flightReadoutForm.ShowInTaskbar = true;
          int num = (int) flightReadoutForm.ShowDialog((IWin32Window) windowWrapper);
          this.Close();
        }
      }
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this.tabControl.SelectedTab == this.tabPageCalculator && !this.calculatorPage.DeActivatePage())
        return;
      if (CommunicationPool.Instance.AreCommandsPending && MessageBox.Show(ml.ml_string(147, "There are still commands ready to send, are you sure you wish to quit?"), ml.ml_string(76, "Bricon Club Editor"), MessageBoxButtons.OKCancel) == DialogResult.Cancel)
      {
        e.Cancel = true;
      }
      else
      {
        CommunicationPool.Instance.Stop();
        this.backgroundCommunication.CancelAsync();
        SplashForm.HideSplash();
        UpdateCheckingThread.Stop();
        Settings.Default.MainFormMaximized = this.WindowState == FormWindowState.Maximized;
        if (!Settings.Default.MainFormMaximized)
          Settings.Default.MainformClientSize = this.Size;
        Settings.Default.MainformLocation = this.Location;
        Settings.Default.AutoLoad = false;
        Settings.Default.Save();
        this.fancierPage.bindingSourceAdressen.EndEdit();
        BCEDatabase.SaveToDisk(false);
      }
    }

    private void tabControl_Selected(object sender, TabControlEventArgs e)
    {
      if (e.TabPage == this.tabPageOptions)
        Settings.Default.Save();
      if (e.TabPage == this.tabPageFancier)
        this.fancierPage.TabPageActivated();
      if (e.TabPage == this.tabPageClubs)
        this.clubsPage.TabPageActivated();
      if (e.TabPage == this.tabPageFanciers)
        this.fanciersPage.TabPageActivated();
      if (e.TabPage == this.tabPageFlights)
        this.flightsPage.TabPageActivated();
      if (!OptionsPage.IsCalulationModuleLicensed() && this.tabControl.TabPages.Contains(this.tabPageCalculator))
        this.tabControl.TabPages.Remove(this.tabPageCalculator);
      if (OptionsPage.IsCalulationModuleLicensed() && !this.tabControl.TabPages.Contains(this.tabPageCalculator))
        this.tabControl.TabPages.Insert(3, this.tabPageCalculator);
      if (Utils.IsPasActiveAndOk() && !this.tabControl.TabPages.Contains(this.tabPagePAS))
        this.tabControl.TabPages.Insert(0, this.tabPagePAS);
      if (Utils.IsPasActiveAndOk() || !this.tabControl.TabPages.Contains(this.tabPagePAS))
        return;
      this.tabControl.TabPages.Remove(this.tabPagePAS);
    }

    private void MainForm_Shown(object sender, EventArgs e)
    {
      if (Settings.Default.Language == "Auto" || Settings.Default.Country == "Auto")
        CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new GetLanguageAndCountryCommand());
      this.Activate();
      this.tabControl.SelectedTab = this.tabPageClubs;
      if (BCEDatabase.DataSet.Clubs.Rows.Count == 1)
        this.tabControl.SelectedTab = this.tabPageFanciers;
      if (Utils.IsCountry("UK") && (Settings.Default.Union == "" || Settings.Default.Union == null))
      {
        int num = (int) MessageBox.Show("Please fill in the Union");
        this.tabControl.SelectedTab = this.tabPageOptions;
      }
      if (!Utils.IsPasActiveAndOk())
        return;
      this.tabControl.SelectedTab = this.tabPagePAS;
    }

    private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
    {
      Settings.Default.AutoLoad = false;
      if (CommunicationPool.Instance.AreReadRingCommandsPending)
      {
        int num = (int) MessageBox.Show(ml.ml_string(264, "Please abort read ring commands first"));
        e.Cancel = true;
      }
      if (BCEDatabase.DataSet.Clubs.Rows.Count == 0)
        BCEDatabase.DataSet.Clubs.AddClubsRow("9999", ml.ml_string(835, "Default"), "999999", "", "", "", "", "", "", "", "", "", "");
      if (this.tabControl.SelectedTab == this.tabPageFancier && BCEDatabase.DataSet.Adressen.Select("ClubID = " + this.clubsPage.GetActiveClubRow().ID.ToString()).Length == 0)
        BCEDatabase.DataSet.Adressen.AddAdressenRow("", "", "", "", "", "", "", "", "", "", 0, 0, "", this.clubsPage.GetActiveClubRow(), "", "", "", "", DateTime.MinValue, "", "", false);
      if (this.tabControl.SelectedTab != this.tabPageCalculator || e.Action != TabControlAction.Selecting)
        return;
      this.calculatorPage.ActivatePage();
    }

    private void tabControl_Deselecting(object sender, TabControlCancelEventArgs e)
    {
      if (this.tabControl.SelectedTab != this.tabPageCalculator || e.Action != TabControlAction.Deselecting)
        return;
      e.Cancel = !this.calculatorPage.DeActivatePage();
    }

    private void HandleCommunicationState(CommunicationState state)
    {
      try
      {
        if (state == null)
          return;
        this.HandleActivationBA(state);
        this.communicationsPanel.UpdateComm(state);
        this.fancierPage.bindingNavigatorAdressen.Enabled = !CommunicationPool.Instance.AreReadRingCommandsPending;
        this.HandleMasterSoftwareUpdate(state);
        foreach (BriconLib.Communications.Command command in state.GetAndClearCommandWithFeedBack())
        {
          if (command is GetLanguageAndCountryCommand)
            this.HandleLanguageAndCountry(command as GetLanguageAndCountryCommand);
          if (command is GetClubIDAndPincodeCommand)
            this.HandleGetClubIDAndPincode(command as GetClubIDAndPincodeCommand);
          if (command is SendClubIDAndPincodeCommand)
            this.HandleSendClubIDAndPincode(command as SendClubIDAndPincodeCommand);
          if (command is SendFancierCommand)
            this.HandleSendFancier(command as SendFancierCommand);
          if (command is SendBandTableCommand)
            this.HandleSendBandTable(command as SendBandTableCommand);
          if (command is ReadRingCommand)
            this.HandleReadRing(command as ReadRingCommand);
          if (command is CheckRingCommand)
            this.HandleCheckRing(command as CheckRingCommand);
          if (command is GetFancierCommand)
            this.HandleGetFancier(command as GetFancierCommand);
          if (command is GetBandTableCommand)
            this.HandleGetBandTable(command as GetBandTableCommand);
          if (command is GetFancierCountCommand)
            this.HandleGetFancierCount(command as GetFancierCountCommand);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show((IWin32Window) MainForm.Instance, ex.ToString());
      }
    }

    private void HandleActivationBA(CommunicationState state)
    {
      if (!state.BAFound || state.PreviousBAVersion != null && state.PreviousBAVersion.Equals(state.BAVersion))
        return;
      state.PreviousBAVersion = state.BAVersion;
      XtremeLoaderBCE.TryToLoad();
      this.AutoLoad(state);
    }

    private void AutoLoad(CommunicationState state)
    {
      try
      {
        if (!Settings.Default.AutoLoad || this.tabControl.SelectedTab != this.tabPageFanciers)
          return;
        string str = Conversion.SerialFromVersion(state.BAVersion, CommunicationState.Instance.BAAddress);
        if (str.Length == 0)
          return;
        bool flag = false;
        foreach (BCEDataSet.AdressenRow row in (InternalDataCollectionBase) BCEDatabase.DataSet.Adressen.Rows)
        {
          if (!row.IsSerialNull() && str.Equals(row.Serial))
          {
            flag = true;
            int num = (int) MessageBox.Show(string.Format(ml.ml_string(218, "Auto Load: Do you want to write the fancier data of '{0}' with loft number '{1}' to the BA with serial '{2}'?"), row.IsNaamNull() ? (object) string.Empty : (object) row.Naam, row.IsLicentieNull() ? (object) string.Empty : (object) row.Licentie, (object) str), Defines.MessageBoxCaption, MessageBoxButtons.YesNoCancel);
            if (num == 6)
              this.fancierPage.SendFancierAndRingsToBA(row);
            if (num == 2)
              Settings.Default.AutoLoad = false;
          }
        }
        if (flag || MessageBox.Show(ml.ml_string(292, "Auto Load : Could not find a fancier for this device, please connect next."), Defines.MessageBoxCaption, MessageBoxButtons.OKCancel) != DialogResult.Cancel)
          return;
        Settings.Default.AutoLoad = false;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void HandleMasterSoftwareUpdate(CommunicationState state)
    {
      if (!state.MasterFound || !this._checkMasterVersion || (state.MasterVersionNumber >= (int) ushort.MaxValue || !SoftwareDownloader.VersionsTxtProcessed))
        return;
      this._checkMasterVersion = false;
      int activeComport = CommunicationPool.Instance.ActiveComport;
      switch (MasterUpdater.UpdateMaster(state.MasterVersionNumber, activeComport, (Form) this, false))
      {
        case 0:
          MasterUpdater.ManualUpdate(activeComport, (Form) this);
          break;
        case 1:
          FancierUpdater.UpdateFancier(state.FancierVersionNumbers, activeComport, (Form) this);
          break;
      }
    }

    private void HandleLanguageAndCountry(GetLanguageAndCountryCommand cmd)
    {
      if (Settings.Default.Country != cmd.ReceivedCountry)
      {
        Settings.Default.Country = cmd.ReceivedCountry;
        MessageDisplayer messageDisplayer = new MessageDisplayer(ml.ml_string(145, "The country code is adjusted to the country code in the master."));
      }
      if (Settings.Default.Language == "Auto")
      {
        Settings.Default.Language = cmd.ReceivedLanguage;
        MessageDisplayer messageDisplayer = new MessageDisplayer(ml.ml_string(144, "The language of this program is adjusted to the language in the master, please restart the program to see it!"));
      }
      if (this.tabControl.SelectedTab != this.tabPageOptions)
        return;
      this.optionsPage.RefreshData();
    }

    [DllImport("user32.dll")]
    private static extern void MessageBeep(uint uType);

    private void HandleReadRing(ReadRingCommand cmd)
    {
      if (this.previousReading == cmd.ReceivedElRing)
      {
        this.communicationsPanel.RemoveLastMasterCommand();
        cmd.AskNextRing();
      }
      else
      {
        if (this.fancierPage.adressenPigeonsBindingSource.Current == null || !(((DataRowView) this.fancierPage.adressenPigeonsBindingSource.Current).Row is BCEDataSet.PigeonsRow row))
          return;
        string elRing = row.ELRing;
        row.ELRing = cmd.ReceivedElRing;
        this.fancierPage.adressenPigeonsBindingSource.ResetItem(this.fancierPage.adressenPigeonsBindingSource.Position);
        foreach (BCEDataSet.PigeonsRow pigeonRow in BCEDatabase.DataSet.Pigeons.Select(string.Format("(ELRing = '{0}' or ELRing = '{1}') and ELRing <> '' and fancierID = {2} ", (object) elRing, (object) row.ELRing, (object) row.FancierID)))
        {
          if (pigeonRow.RowState != DataRowState.Deleted)
            FancierPage.ValidatePigeonRow(pigeonRow, true, true);
        }
        FancierPage.ValidatePigeonRow(row, true, true);
        this.tabPageFancier.Invalidate(true);
        this.fancierPage.EnableLicenceTextBox();
        bool flag = false;
        if (this.fancierPage.adressenPigeonsBindingSource.Position != this.fancierPage.adressenPigeonsBindingSource.Count - 1)
        {
          this.fancierPage.adressenPigeonsBindingSource.MoveNext();
          flag = true;
        }
        if (flag)
          cmd.AskNextRing();
        this.previousReading = cmd.ReceivedElRing;
        MainForm.MessageBeep(0U);
      }
    }

    private void HandleCheckRing(CheckRingCommand cmd)
    {
      if (this.previousRingNr == cmd.Ring)
      {
        this.communicationsPanel.RemoveLastMasterCommand();
        cmd.AskNextRing();
      }
      else
      {
        if (this.fancierPage.bindingSourceAdressen.Current == null)
          return;
        if (this._checkRingForm != null && this._checkRingForm.Visible)
        {
          this._checkRingForm.SetData(cmd, ((DataRowView) this.fancierPage.bindingSourceAdressen.Current).Row as BCEDataSet.AdressenRow);
          if (!this._checkRingForm.IsRingAlreadyLinked)
            cmd.AskNextRing();
        }
        if (this._checkRingsForm != null && this._checkRingsForm.Visible)
        {
          this._checkRingsForm.AddRing(cmd);
          cmd.AskNextRing();
        }
        this.tabPageFancier.Invalidate(true);
        this.previousRingNr = cmd.Ring;
      }
    }

    private void HandleGetClubIDAndPincode(GetClubIDAndPincodeCommand cmd)
    {
      BCEDataSet.ClubsRow byId = BCEDatabase.DataSet.Clubs.FindByID(cmd.ClubID);
      if (byId != null)
      {
        byId.ClubID = cmd.ReceivedClubID;
        byId.Pincode = cmd.ReceivedPinCode;
        if (this.tabControl.SelectedTab != this.tabPageClubs)
          return;
        this.tabPageClubs.Invalidate(true);
      }
      else
      {
        MessageDisplayer messageDisplayer = new MessageDisplayer(string.Format(ml.ml_string(138, "Club '{0}' with ID {1} could not be found anymore, ignoring the received data."), (object) cmd.Name, (object) cmd.ClubID));
      }
    }

    private void HandleSendClubIDAndPincode(SendClubIDAndPincodeCommand cmd)
    {
      BCEDataSet.ClubsRow byId = BCEDatabase.DataSet.Clubs.FindByID(cmd.ID);
      if (byId != null)
      {
        byId.SerieNrMaster = Conversion.SerialFromVersionMaster(CommunicationState.Instance.MasterVersion);
        if (this.tabControl.SelectedTab != this.tabPageClubs)
          return;
        this.tabPageClubs.Invalidate(true);
      }
      else
      {
        MessageDisplayer messageDisplayer = new MessageDisplayer(string.Format(ml.ml_string(380, "Club with ID {0} could not be found anymore, ignoring the received serialnumber."), (object) cmd.ID));
      }
    }

    private void HandleSendFancier(SendFancierCommand cmd)
    {
      BCEDataSet.AdressenRow byId = BCEDatabase.DataSet.Adressen.FindById(cmd.FancierID);
      if (byId == null)
        return;
      byId.Serial = cmd.ReceivedSerial;
      this.fancierPage.bindingSourceAdressen.ResetItem(this.fancierPage.bindingSourceAdressen.Position);
    }

    private void HandleSendBandTable(SendBandTableCommand cmd)
    {
      if (!Settings.Default.AutoLoad || !cmd.LastRecord || MessageBox.Show(ml.ml_string(293, "Please connect next device"), Defines.MessageBoxCaption, MessageBoxButtons.OKCancel) != DialogResult.Cancel)
        return;
      Settings.Default.AutoLoad = false;
    }

    private void HandleGetFancier(GetFancierCommand cmd)
    {
      this._lastfancierCmd = cmd;
      this._lastRingCmds = new List<GetBandTableCommand>();
    }

    private void HandleGetFancierCount(GetFancierCountCommand cmd)
    {
      for (int index = 0; index < (int) cmd.ReceivedCount; ++index)
      {
        CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new GetFancierCommand());
        CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new GetBandTableCommand());
      }
    }

    private void HandleGetBandTable(GetBandTableCommand cmd)
    {
      bool flag = false;
      if (this._lastfancierCmd == null)
        flag = true;
      if (!flag)
      {
        GetBandTableCommand bandTableCommand = cmd;
        if (!bandTableCommand.NoMoreRecords)
        {
          this._lastRingCmds.Add(bandTableCommand);
        }
        else
        {
          foreach (GetBandTableCommand lastRingCmd in this._lastRingCmds)
          {
            if (lastRingCmd.FancierID != this._lastfancierCmd.FancierID)
              flag = true;
          }
          if (!flag)
            this.HandleGetBandTableLastRecord();
          this._lastfancierCmd = (GetFancierCommand) null;
        }
      }
      if (!flag)
        return;
      int num = (int) MessageBox.Show((IWin32Window) MainForm.Instance, ml.ml_string(265, "Error occurred when trying to update the received data, please try again"));
    }

    private void HandleGetBandTableLastRecord()
    {
      BCEDataSet.AdressenRow row = (BCEDataSet.AdressenRow) null;
      int fancierId = this._lastfancierCmd.FancierID;
      if (fancierId == -1)
      {
        DataRow[] dataRowArray = BCEDatabase.DataSet.Adressen.Select("Serial = '" + this._lastfancierCmd.ReceivedSerial + "'");
        if (dataRowArray.Length == 1)
        {
          row = dataRowArray[0] as BCEDataSet.AdressenRow;
          if (MessageBox.Show((IWin32Window) MainForm.Instance, string.Format(ml.ml_string(294, "Do you wish to overwrite fancier '{0}'-'{1}' with the received data?"), (object) row.Licentie, (object) row.Naam), Defines.MessageBoxCaption, MessageBoxButtons.YesNo) == DialogResult.No)
            row = (BCEDataSet.AdressenRow) null;
        }
        if (dataRowArray.Length == 0 && MessageBox.Show((IWin32Window) MainForm.Instance, ml.ml_string(295, "No fancier found with this serial, do you wish to create a new fancier with the received data?"), Defines.MessageBoxCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
          row = BCEDatabase.DataSet.Adressen.AddAdressenRow("", "", "", "", "", "", "", "", "", "", 0, 0, "", ((DataRowView) this.clubsPage.bindingSourceClubs.Current).Row as BCEDataSet.ClubsRow, "", "", "", "", DateTime.MinValue, "", "", false);
        if (dataRowArray.Length > 1)
        {
          MessageDisplayer messageDisplayer = new MessageDisplayer(ml.ml_string(296, "Multiple fanciers found with serial '") + this._lastfancierCmd.ReceivedSerial + ml.ml_string(297, "' please read it manual."));
        }
      }
      else
        row = BCEDatabase.DataSet.Adressen.FindById(fancierId);
      if (row != null)
        this.HandleGetBandTableFillData(row);
      else if (fancierId >= 0)
      {
        MessageDisplayer messageDisplayer1 = new MessageDisplayer(string.Format(ml.ml_string(140, "Fancier {0} with loft number {1} and ID {2} could not be found anymore, ignoring the received data."), (object) this._lastfancierCmd.OldName, (object) this._lastfancierCmd.OldLicence, (object) this._lastfancierCmd.FancierID));
      }
      this.fancierPage.EnableLicenceTextBox();
    }

    private void HandleGetBandTableFillData(BCEDataSet.AdressenRow row)
    {
      row.BeginEdit();
      row.Serial = this._lastfancierCmd.ReceivedSerial;
      row.Licentie = this._lastfancierCmd.ReceivedLicentie;
      row.Naam = this._lastfancierCmd.ReceivedNaam;
      row.Adres = this._lastfancierCmd.ReceivedAdres;
      row.Postcode = this._lastfancierCmd.ReceivedPostcode;
      row.Gemeente = this._lastfancierCmd.ReceivedGemeente;
      row.KWX = this._lastfancierCmd.ReceivedCoordX;
      row.KWY = this._lastfancierCmd.ReceivedCoordY;
      row.EndEdit();
      BCEDatabase.DeletePigeonsForFancier(row.Id);
      int num1 = 1;
      foreach (GetBandTableCommand lastRingCmd in this._lastRingCmds)
        BCEDatabase.DataSet.Pigeons.AddPigeonsRow(row, lastRingCmd.ReceivedDBRing, lastRingCmd.ReceivedElRing, lastRingCmd.ReceivedSex, lastRingCmd.ReceivedColor, 0, false, num1++);
      List<BCEDataSet.PigeonsRow> pigeonsRowList = new List<BCEDataSet.PigeonsRow>();
      foreach (BCEDataSet.PigeonsRow pigeonsRow1 in BCEDatabase.DataSet.Pigeons.Select(string.Format("FancierID = {0}", (object) row.Id)))
      {
        if (pigeonsRow1.DBRing.StartsWith("00-"))
        {
          string str = pigeonsRow1.DBRing.Replace("00-", Settings.Default.Country + "-");
          if (Utils.IsCountry("KSA") || Utils.IsCountry("IQ") || Utils.IsCountry("RN"))
            str = pigeonsRow1.DBRing.Replace("00-", Settings.Default.Country);
          DataRow[] dataRowArray = BCEDatabase.DataSet.Pigeons.Select(string.Format("FancierID = {0} AND DBRING = '{1}'", (object) row.Id, (object) str));
          if (dataRowArray.Length != 0)
          {
            foreach (BCEDataSet.PigeonsRow pigeonsRow2 in dataRowArray)
              pigeonsRow2.ELRing = pigeonsRow1.ELRing;
            pigeonsRowList.Add(pigeonsRow1);
          }
          else
            pigeonsRow1.DBRing = str;
        }
      }
      if (pigeonsRowList.Count > 0)
      {
        for (int index = 0; index < pigeonsRowList.Count; ++index)
          pigeonsRowList[index].Delete();
        int num2 = (int) MessageBox.Show((IWin32Window) MainForm.Instance, ml.ml_string(298, "Emergency Rings Replaced"));
      }
      this.fancierPage.ValidateAllData(true, row, true);
    }

    private void pasPage_Load(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MainForm));
      this.splitContainer = new SplitContainer();
      this.tabControl = new TabControl();
      this.tabPagePAS = new TabPage();
      this.pasPage = new PASPage();
      this.tabPageFanciers = new TabPage();
      this.fanciersPage = new FanciersPage();
      this.tabPageFancier = new TabPage();
      this.fancierPage = new FancierPage();
      this.tabPageClubs = new TabPage();
      this.clubsPage = new ClubsPage();
      this.tabPageFlights = new TabPage();
      this.flightsPage = new FlightsPage();
      this.tabPageCalculator = new TabPage();
      this.calculatorPage = new CalculatorPage();
      this.tabPageOptions = new TabPage();
      this.optionsPage = new OptionsPage();
      this.tabPageAbout = new TabPage();
      this.aboutPage = new AboutPage();
      this.imageList = new ImageList(this.components);
      this.communicationsPanel = new CommunicationsPanel();
      this.backgroundCommunication = new BackgroundWorker();
      this.statusStrip = new StatusStrip();
      this.statusBarStatus = new ToolStripStatusLabel();
      this.splitContainer.BeginInit();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      this.tabControl.SuspendLayout();
      this.tabPagePAS.SuspendLayout();
      this.tabPageFanciers.SuspendLayout();
      this.tabPageFancier.SuspendLayout();
      this.tabPageClubs.SuspendLayout();
      this.tabPageFlights.SuspendLayout();
      this.tabPageCalculator.SuspendLayout();
      this.tabPageOptions.SuspendLayout();
      this.tabPageAbout.SuspendLayout();
      this.SuspendLayout();
      this.splitContainer.DataBindings.Add(new Binding("SplitterDistance", (object) Settings.Default, "Mainform_SplitterDistance", true, DataSourceUpdateMode.OnPropertyChanged));
      componentResourceManager.ApplyResources((object) this.splitContainer, "splitContainer");
      this.splitContainer.Name = "splitContainer";
      this.splitContainer.Panel1.Controls.Add((Control) this.tabControl);
      this.splitContainer.Panel2.Controls.Add((Control) this.communicationsPanel);
      this.splitContainer.SplitterDistance = Settings.Default.Mainform_SplitterDistance;
      this.tabControl.Controls.Add((Control) this.tabPagePAS);
      this.tabControl.Controls.Add((Control) this.tabPageFanciers);
      this.tabControl.Controls.Add((Control) this.tabPageFancier);
      this.tabControl.Controls.Add((Control) this.tabPageClubs);
      this.tabControl.Controls.Add((Control) this.tabPageFlights);
      this.tabControl.Controls.Add((Control) this.tabPageCalculator);
      this.tabControl.Controls.Add((Control) this.tabPageOptions);
      this.tabControl.Controls.Add((Control) this.tabPageAbout);
      componentResourceManager.ApplyResources((object) this.tabControl, "tabControl");
      this.tabControl.ImageList = this.imageList;
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Selecting += new TabControlCancelEventHandler(this.tabControl_Selecting);
      this.tabControl.Selected += new TabControlEventHandler(this.tabControl_Selected);
      this.tabControl.Deselecting += new TabControlCancelEventHandler(this.tabControl_Deselecting);
      this.tabPagePAS.Controls.Add((Control) this.pasPage);
      componentResourceManager.ApplyResources((object) this.tabPagePAS, "tabPagePAS");
      this.tabPagePAS.Name = "tabPagePAS";
      this.tabPagePAS.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.pasPage, "pasPage");
      this.pasPage.Name = "pasPage";
      this.pasPage.Load += new EventHandler(this.pasPage_Load);
      this.tabPageFanciers.Controls.Add((Control) this.fanciersPage);
      componentResourceManager.ApplyResources((object) this.tabPageFanciers, "tabPageFanciers");
      this.tabPageFanciers.Name = "tabPageFanciers";
      this.tabPageFanciers.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.fanciersPage, "fanciersPage");
      this.fanciersPage.Name = "fanciersPage";
      this.tabPageFancier.Controls.Add((Control) this.fancierPage);
      componentResourceManager.ApplyResources((object) this.tabPageFancier, "tabPageFancier");
      this.tabPageFancier.Name = "tabPageFancier";
      this.tabPageFancier.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.fancierPage, "fancierPage");
      this.fancierPage.Name = "fancierPage";
      this.tabPageClubs.Controls.Add((Control) this.clubsPage);
      componentResourceManager.ApplyResources((object) this.tabPageClubs, "tabPageClubs");
      this.tabPageClubs.Name = "tabPageClubs";
      this.tabPageClubs.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.clubsPage, "clubsPage");
      this.clubsPage.Name = "clubsPage";
      this.tabPageFlights.Controls.Add((Control) this.flightsPage);
      componentResourceManager.ApplyResources((object) this.tabPageFlights, "tabPageFlights");
      this.tabPageFlights.Name = "tabPageFlights";
      this.tabPageFlights.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.flightsPage, "flightsPage");
      this.flightsPage.Name = "flightsPage";
      this.tabPageCalculator.Controls.Add((Control) this.calculatorPage);
      componentResourceManager.ApplyResources((object) this.tabPageCalculator, "tabPageCalculator");
      this.tabPageCalculator.Name = "tabPageCalculator";
      this.tabPageCalculator.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.calculatorPage, "calculatorPage");
      this.calculatorPage.Name = "calculatorPage";
      this.tabPageOptions.Controls.Add((Control) this.optionsPage);
      componentResourceManager.ApplyResources((object) this.tabPageOptions, "tabPageOptions");
      this.tabPageOptions.Name = "tabPageOptions";
      this.tabPageOptions.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.optionsPage, "optionsPage");
      this.optionsPage.Name = "optionsPage";
      this.tabPageAbout.Controls.Add((Control) this.aboutPage);
      componentResourceManager.ApplyResources((object) this.tabPageAbout, "tabPageAbout");
      this.tabPageAbout.Name = "tabPageAbout";
      this.tabPageAbout.UseVisualStyleBackColor = true;
      this.aboutPage.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.aboutPage, "aboutPage");
      this.aboutPage.Name = "aboutPage";
      this.imageList.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageList.ImageStream");
      this.imageList.TransparentColor = Color.Fuchsia;
      this.imageList.Images.SetKeyName(0, "Fanciers.bmp");
      this.imageList.Images.SetKeyName(1, "Fancier.bmp");
      this.imageList.Images.SetKeyName(2, "Clubs.bmp");
      this.imageList.Images.SetKeyName(3, "Flights.bmp");
      this.imageList.Images.SetKeyName(4, "Calculator.bmp");
      this.imageList.Images.SetKeyName(5, "Options.bmp");
      this.imageList.Images.SetKeyName(6, "infoBubble.bmp");
      this.imageList.Images.SetKeyName(7, "SaveAll.bmp");
      this.imageList.Images.SetKeyName(8, "BriconWeb.bmp");
      componentResourceManager.ApplyResources((object) this.communicationsPanel, "communicationsPanel");
      this.communicationsPanel.Name = "communicationsPanel";
      this.backgroundCommunication.WorkerReportsProgress = true;
      this.backgroundCommunication.WorkerSupportsCancellation = true;
      this.backgroundCommunication.DoWork += new DoWorkEventHandler(this.backgroundCommunication_DoWork);
      this.backgroundCommunication.ProgressChanged += new ProgressChangedEventHandler(this.backgroundCommunication_ProgressChanged);
      componentResourceManager.ApplyResources((object) this.statusStrip, "statusStrip");
      this.statusStrip.Name = "statusStrip";
      this.statusBarStatus.Name = "statusBarStatus";
      componentResourceManager.ApplyResources((object) this.statusBarStatus, "statusBarStatus");
      this.statusBarStatus.Spring = true;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.splitContainer);
      this.Controls.Add((Control) this.statusStrip);
      this.Name = nameof (MainForm);
      this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
      this.Load += new EventHandler(this.MainForm_Load);
      this.Shown += new EventHandler(this.MainForm_Shown);
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel2.ResumeLayout(false);
      this.splitContainer.EndInit();
      this.splitContainer.ResumeLayout(false);
      this.tabControl.ResumeLayout(false);
      this.tabPagePAS.ResumeLayout(false);
      this.tabPageFanciers.ResumeLayout(false);
      this.tabPageFancier.ResumeLayout(false);
      this.tabPageClubs.ResumeLayout(false);
      this.tabPageFlights.ResumeLayout(false);
      this.tabPageCalculator.ResumeLayout(false);
      this.tabPageOptions.ResumeLayout(false);
      this.tabPageAbout.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public class WindowWrapper : IWin32Window
    {
      private IntPtr _hwnd;

      public WindowWrapper(IntPtr handle) => this._hwnd = handle;

      public IntPtr Handle => this._hwnd;
    }
  }
}
