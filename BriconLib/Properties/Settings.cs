// Decompiled with JetBrains decompiler
// Type: BriconLib.Properties.Settings
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace BriconLib.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.3.0.0")]
  public sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
    {
    }

    private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
    {
    }

    public static Settings Default => Settings.defaultInstance;

    [ApplicationScopedSetting]
    [DebuggerNonUserCode]
    [SpecialSetting(SpecialSetting.ConnectionString)]
    [DefaultSettingValue("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\DEV\\Bawibo\\BCE\\BriconLib\\Data\\AdminBackup.mdb;Persist Security Info=True")]
    public string BCEConnectionString => (string) this[nameof (BCEConnectionString)];

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool DownloadUpdates
    {
      get => (bool) this[nameof (DownloadUpdates)];
      set => this[nameof (DownloadUpdates)] = (object) value;
    }

    [ApplicationScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public string CurrentClubID => (string) this[nameof (CurrentClubID)];

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool InstallUpdates
    {
      get => (bool) this[nameof (InstallUpdates)];
      set => this[nameof (InstallUpdates)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool CheckForUpdates
    {
      get => (bool) this[nameof (CheckForUpdates)];
      set => this[nameof (CheckForUpdates)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Auto")]
    public string Language
    {
      get => (string) this[nameof (Language)];
      set => this[nameof (Language)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Auto")]
    public string Country
    {
      get => (string) this[nameof (Country)];
      set => this[nameof (Country)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Auto")]
    public string ComPort
    {
      get => (string) this[nameof (ComPort)];
      set => this[nameof (ComPort)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue(".\\AdminBackup.mdb")]
    public string DBLocation
    {
      get => (string) this[nameof (DBLocation)];
      set => this[nameof (DBLocation)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("5")]
    public Decimal AutoSaveMinutes
    {
      get => (Decimal) this[nameof (AutoSaveMinutes)];
      set => this[nameof (AutoSaveMinutes)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("71")]
    public int Mainform_SplitterDistance
    {
      get => (int) this[nameof (Mainform_SplitterDistance)];
      set => this[nameof (Mainform_SplitterDistance)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0, 0")]
    public Point MainformLocation
    {
      get => (Point) this[nameof (MainformLocation)];
      set => this[nameof (MainformLocation)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("771, 627")]
    public Size MainformClientSize
    {
      get => (Size) this[nameof (MainformClientSize)];
      set => this[nameof (MainformClientSize)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool AutoLoad
    {
      get => (bool) this[nameof (AutoLoad)];
      set => this[nameof (AutoLoad)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("1.0.0.0")]
    public string Version
    {
      get => (string) this[nameof (Version)];
      set => this[nameof (Version)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("200")]
    public int TimeOutPolling
    {
      get => (int) this[nameof (TimeOutPolling)];
      set => this[nameof (TimeOutPolling)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool USBDriverInstalled
    {
      get => (bool) this[nameof (USBDriverInstalled)];
      set => this[nameof (USBDriverInstalled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public int LastShowedMessage
    {
      get => (int) this[nameof (LastShowedMessage)];
      set => this[nameof (LastShowedMessage)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool AntenneWithoutMaster
    {
      get => (bool) this[nameof (AntenneWithoutMaster)];
      set => this[nameof (AntenneWithoutMaster)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool DeleteExistingRings
    {
      get => (bool) this[nameof (DeleteExistingRings)];
      set => this[nameof (DeleteExistingRings)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("c:\\ReadOuts")]
    public string OutputFolder
    {
      get => (string) this[nameof (OutputFolder)];
      set => this[nameof (OutputFolder)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string FlightID
    {
      get => (string) this[nameof (FlightID)];
      set => this[nameof (FlightID)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("<NONE>")]
    public string ActivationCode
    {
      get => (string) this[nameof (ActivationCode)];
      set => this[nameof (ActivationCode)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string Union
    {
      get => (string) this[nameof (Union)];
      set => this[nameof (Union)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool MainFormMaximized
    {
      get => (bool) this[nameof (MainFormMaximized)];
      set => this[nameof (MainFormMaximized)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool WinspeedFormat
    {
      get => (bool) this[nameof (WinspeedFormat)];
      set => this[nameof (WinspeedFormat)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("1")]
    public Decimal WinspeedWeek
    {
      get => (Decimal) this[nameof (WinspeedWeek)];
      set => this[nameof (WinspeedWeek)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("1")]
    public Decimal WinspeedFlightIndex
    {
      get => (Decimal) this[nameof (WinspeedFlightIndex)];
      set => this[nameof (WinspeedFlightIndex)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("c:\\")]
    public string CheckRingsInitialDirectory
    {
      get => (string) this[nameof (CheckRingsInitialDirectory)];
      set => this[nameof (CheckRingsInitialDirectory)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("exportedrings.csv")]
    public string CheckRingsFileName
    {
      get => (string) this[nameof (CheckRingsFileName)];
      set => this[nameof (CheckRingsFileName)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string LoginBriconWeb
    {
      get => (string) this[nameof (LoginBriconWeb)];
      set => this[nameof (LoginBriconWeb)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string PasswordBriconWeb
    {
      get => (string) this[nameof (PasswordBriconWeb)];
      set => this[nameof (PasswordBriconWeb)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string EmailAddress
    {
      get => (string) this[nameof (EmailAddress)];
      set => this[nameof (EmailAddress)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("smtp.gmail.com")]
    public string OutMailServer
    {
      get => (string) this[nameof (OutMailServer)];
      set => this[nameof (OutMailServer)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool EnableNetWorkPolling
    {
      get => (bool) this[nameof (EnableNetWorkPolling)];
      set => this[nameof (EnableNetWorkPolling)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool BriconWebTestMode
    {
      get => (bool) this[nameof (BriconWebTestMode)];
      set => this[nameof (BriconWebTestMode)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string EmailAddressSignon
    {
      get => (string) this[nameof (EmailAddressSignon)];
      set => this[nameof (EmailAddressSignon)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool SendToPipa
    {
      get => (bool) this[nameof (SendToPipa)];
      set => this[nameof (SendToPipa)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool SendToPitts
    {
      get => (bool) this[nameof (SendToPitts)];
      set => this[nameof (SendToPitts)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string RaceIndexText
    {
      get => (string) this[nameof (RaceIndexText)];
      set => this[nameof (RaceIndexText)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("80")]
    public Decimal WebServerPort
    {
      get => (Decimal) this[nameof (WebServerPort)];
      set => this[nameof (WebServerPort)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool CLKFormatChecked
    {
      get => (bool) this[nameof (CLKFormatChecked)];
      set => this[nameof (CLKFormatChecked)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    public StringCollection EmailAdresses
    {
      get => (StringCollection) this[nameof (EmailAdresses)];
      set => this[nameof (EmailAdresses)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    public StringCollection EmailAdressesSignon
    {
      get => (StringCollection) this[nameof (EmailAdressesSignon)];
      set => this[nameof (EmailAdressesSignon)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    public StringCollection EmailAdressesActive
    {
      get => (StringCollection) this[nameof (EmailAdressesActive)];
      set => this[nameof (EmailAdressesActive)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    public StringCollection EmailAdressesSignonActive
    {
      get => (StringCollection) this[nameof (EmailAdressesSignonActive)];
      set => this[nameof (EmailAdressesSignonActive)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool UseDistanceDB
    {
      get => (bool) this[nameof (UseDistanceDB)];
      set => this[nameof (UseDistanceDB)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool SendToOmar
    {
      get => (bool) this[nameof (SendToOmar)];
      set => this[nameof (SendToOmar)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool SendMonitorDataToBW
    {
      get => (bool) this[nameof (SendMonitorDataToBW)];
      set => this[nameof (SendMonitorDataToBW)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool CryptBCEReadoutFiles
    {
      get => (bool) this[nameof (CryptBCEReadoutFiles)];
      set => this[nameof (CryptBCEReadoutFiles)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool SendToPigeonCloud
    {
      get => (bool) this[nameof (SendToPigeonCloud)];
      set => this[nameof (SendToPigeonCloud)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("25")]
    public Decimal EmailServerPort
    {
      get => (Decimal) this[nameof (EmailServerPort)];
      set => this[nameof (EmailServerPort)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool EmailUseSSL
    {
      get => (bool) this[nameof (EmailUseSSL)];
      set => this[nameof (EmailUseSSL)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string EmailUser
    {
      get => (string) this[nameof (EmailUser)];
      set => this[nameof (EmailUser)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string EmailPWD
    {
      get => (string) this[nameof (EmailPWD)];
      set => this[nameof (EmailPWD)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Printmanager")]
    public string EmailFromName
    {
      get => (string) this[nameof (EmailFromName)];
      set => this[nameof (EmailFromName)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Printmanager@bricon.be")]
    public string EmailFromAddress
    {
      get => (string) this[nameof (EmailFromAddress)];
      set => this[nameof (EmailFromAddress)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool PrintEachReadout
    {
      get => (bool) this[nameof (PrintEachReadout)];
      set => this[nameof (PrintEachReadout)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool SaveEachReadout
    {
      get => (bool) this[nameof (SaveEachReadout)];
      set => this[nameof (SaveEachReadout)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowTotalsPerCategory
    {
      get => (bool) this[nameof (ShowTotalsPerCategory)];
      set => this[nameof (ShowTotalsPerCategory)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Beep")]
    public string SelectedAlarmSound
    {
      get => (string) this[nameof (SelectedAlarmSound)];
      set => this[nameof (SelectedAlarmSound)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool PlayAlarmInLoop
    {
      get => (bool) this[nameof (PlayAlarmInLoop)];
      set => this[nameof (PlayAlarmInLoop)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool BCSendAutomatic
    {
      get => (bool) this[nameof (BCSendAutomatic)];
      set => this[nameof (BCSendAutomatic)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string BCLogin
    {
      get => (string) this[nameof (BCLogin)];
      set => this[nameof (BCLogin)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string BCPWD
    {
      get => (string) this[nameof (BCPWD)];
      set => this[nameof (BCPWD)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool OnlyFirstSignon
    {
      get => (bool) this[nameof (OnlyFirstSignon)];
      set => this[nameof (OnlyFirstSignon)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool SendToCompuClub
    {
      get => (bool) this[nameof (SendToCompuClub)];
      set => this[nameof (SendToCompuClub)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("<NONE>")]
    public string ActivationCode2
    {
      get => (string) this[nameof (ActivationCode2)];
      set => this[nameof (ActivationCode2)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string PASUserName
    {
      get => (string) this[nameof (PASUserName)];
      set => this[nameof (PASUserName)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string PASPassword
    {
      get => (string) this[nameof (PASPassword)];
      set => this[nameof (PASPassword)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool PASAlwaysLoad
    {
      get => (bool) this[nameof (PASAlwaysLoad)];
      set => this[nameof (PASAlwaysLoad)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool PASAlwaysSave
    {
      get => (bool) this[nameof (PASAlwaysSave)];
      set => this[nameof (PASAlwaysSave)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool PASOk
    {
      get => (bool) this[nameof (PASOk)];
      set => this[nameof (PASOk)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("http://pas.adgsoft.be:9300/pasadmin")]
    public string PASBetaUrl
    {
      get => (string) this[nameof (PASBetaUrl)];
      set => this[nameof (PASBetaUrl)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool UseTimeZone
    {
      get => (bool) this[nameof (UseTimeZone)];
      set => this[nameof (UseTimeZone)] = (object) value;
    }
  }
}
