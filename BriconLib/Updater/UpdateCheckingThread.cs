// Decompiled with JetBrains decompiler
// Type: BriconLib.Updater.UpdateCheckingThread
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.BCE;
using BriconLib.Other;
using BriconLib.Properties;
using MultiLang;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace BriconLib.Updater
{
  internal class UpdateCheckingThread
  {
    private static Thread _thread;
    private static bool _busyInstalling;
    private static bool _isBce;

    public static void Start(bool isBce)
    {
      UpdateCheckingThread._isBce = isBce;
      if (!Settings.Default.CheckForUpdates)
        return;
      UpdateCheckingThread._thread = new Thread(new ThreadStart(UpdateCheckingThread.StartChecking));
      if (Settings.Default.Language != "Auto")
        UpdateCheckingThread._thread.CurrentUICulture = new CultureInfo(Settings.Default.Language);
      UpdateCheckingThread._thread.Start();
    }

    public static void Stop()
    {
      if (UpdateCheckingThread._busyInstalling)
      {
        int num = (int) MessageBox.Show(ml.ml_string(267, "A new version is being installed, the program will close when it is ready."), Defines.MessageBoxCaption);
        while (UpdateCheckingThread._busyInstalling)
          Thread.Sleep(100);
      }
      if (UpdateCheckingThread._thread == null)
        return;
      UpdateCheckingThread._thread.Abort();
    }

    private static void StartChecking()
    {
      try
      {
        Thread.Sleep(10000);
        string appFolder1 = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\";
        string downloadPath1 = appFolder1 + "downloadedversion\\";
        using (StreamWriter logFile1 = new StreamWriter(appFolder1 + "\\SoftwareUpdates.log", true))
        {
          SoftwareDownloader softwareDownloader = new SoftwareDownloader(UpdateCheckingThread._isBce);
          if (!softwareDownloader.IsNewerVersionAvailable(appFolder1, logFile1) || MessageBox.Show((IWin32Window) MainForm.Instance, ml.ml_string(180, "A new version is available for download, do you wish to download it?")) != DialogResult.OK || !softwareDownloader.DownloadNewVersion(downloadPath1, logFile1) || !Settings.Default.InstallUpdates && MessageBox.Show((IWin32Window) MainForm.Instance, ml.ml_string(183, "A new version is downloaded, do you wish to install it?")) != DialogResult.OK)
            return;
          SoftwareUpdater softwareUpdater = new SoftwareUpdater();
          UpdateCheckingThread._busyInstalling = true;
          string appFolder2 = appFolder1;
          string downloadPath2 = downloadPath1;
          StreamWriter logFile2 = logFile1;
          softwareUpdater.Install(appFolder2, downloadPath2, logFile2);
          int num = (int) MessageBox.Show((IWin32Window) MainForm.Instance, ml.ml_string(182, "A new version is downloaded and installed, to start using it, please restart the program"));
          UpdateCheckingThread._busyInstalling = false;
        }
      }
      catch (Exception ex)
      {
      }
    }
  }
}
