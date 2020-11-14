// Decompiled with JetBrains decompiler
// Type: BriconLib.Updater.XtremeLoaderBCE
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Communications;
using BriconLib.PrintManager;
using BriconLib.UI;
using MultiLang;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace BriconLib.Updater
{
  internal class XtremeLoaderBCE
  {
    private static string versionExtreme = "";
    private static string versionFileName = "";

    public static void TryToLoad()
    {
      bool flag1 = false;
      if (!CommunicationState.Instance.BAVersion.StartsWith("BRX") && !CommunicationState.Instance.BAVersion.StartsWith("SPX"))
        return;
      if (CommunicationState.Instance.BAVersion.StartsWith("SPX"))
        flag1 = true;
      bool flag2 = false;
      foreach (SoftwareVersionInfo version in SoftwareDownloader.Versions)
      {
        if (version.VersionType == SoftwareVersionInfo.VersionTypes.Xtreme && !flag1 || version.VersionType == SoftwareVersionInfo.VersionTypes.SpeedyXtreme && flag1)
        {
          int startIndex = CommunicationState.Instance.BAVersion.IndexOf(version.MenuString.Substring(0, 3));
          if (startIndex >= 0 && CommunicationState.Instance.BAVersion.Substring(startIndex).CompareTo(version.MenuString) < 0)
          {
            XtremeLoaderBCE.versionExtreme = version.MenuString;
            XtremeLoaderBCE.versionFileName = version.LocalFileName;
            flag2 = true;
            try
            {
              SoftwareDownloader.DownloadFile(version.Url, version.LocalFileName);
              break;
            }
            catch (Exception ex)
            {
              File.AppendAllText("SoftwareUpdates.log", ex.ToString());
              return;
            }
          }
        }
      }
      if (!flag2 || MessageBox.Show(ml.ml_string(1415, "New version available. ") + ml.ml_string(1258, "Make sure that you have read the pigeons out of the clock before you continue, since all data will be lost, continue?"), ml.ml_string(1259, "Loading Xtreme"), MessageBoxButtons.YesNo) == DialogResult.No)
        return;
      CommunicationForm communicationForm = new CommunicationForm(false);
      communicationForm.OnFinish += new EventHandler(XtremeLoaderBCE.commFrm_OnFinish);
      int num = (int) communicationForm.ShowDialog();
    }

    private static void commFrm_OnFinish(object sender, EventArgs e)
    {
      int activeComport = CommunicationPool.Instance.ActiveComport;
      if (new LoadingXtreme(CommunicationState.Instance.BAVersion.Substring(3), XtremeLoaderBCE.versionExtreme).ShowDialog() != DialogResult.OK)
        return;
      CommunicationPool.Instance.Stop();
      int num1 = 70;
      (sender as CommunicationForm).SecondsRemaining = num1;
      Process.Start(new ProcessStartInfo("mode", "com" + activeComport.ToString() + " Data=8 Parity=n Baud=115200 DTR=OFF RTS=OFF")
      {
        CreateNoWindow = true,
        WindowStyle = ProcessWindowStyle.Hidden
      }).WaitForExit();
      try
      {
        Environment.CurrentDirectory += "\\Updates";
        Process process = Process.Start(new ProcessStartInfo("Xtreme.bin", "-dXtreme -e -if" + XtremeLoaderBCE.versionFileName.Replace("Updates\\", "") + " -pf -vf -X -cCOM" + activeComport.ToString())
        {
          UseShellExecute = false,
          WorkingDirectory = Environment.CurrentDirectory,
          RedirectStandardOutput = true,
          CreateNoWindow = true
        });
        for (int index = 0; index < num1 * 2; ++index)
        {
          Application.DoEvents();
          Thread.Sleep(500);
        }
        string end = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        if (end.Contains("Equal!") && end.Contains("Restart device..."))
        {
          int num2 = (int) MessageBox.Show(ml.ml_string(1165, "Software loaded successful, please erase the clock now, if the device asks for a factory reset, please contact Bricon support"));
        }
        else if (end.Contains("Error opening COM port"))
        {
          int num3 = (int) MessageBox.Show(ml.ml_string(1166, "Error loading the device, make sure the blue light is flashing, please retry and follow the instructions carefully"));
        }
        else
        {
          int num4 = (int) MessageBox.Show(end.Replace("\r\n", "\n"));
        }
      }
      finally
      {
        Environment.CurrentDirectory = Environment.CurrentDirectory.Replace("\\Updates", "");
      }
      CommunicationPool.Instance.ReInit();
    }
  }
}
