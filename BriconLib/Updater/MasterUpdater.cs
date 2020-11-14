// Decompiled with JetBrains decompiler
// Type: BriconLib.Updater.MasterUpdater
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.BCE;
using BriconLib.Communications;
using BriconLib.UI;
using MultiLang;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace BriconLib.Updater
{
  public class MasterUpdater
  {
    private static string parameters;

    public static bool ManualUpdate(int comport, Form parent)
    {
      if (MessageBox.Show((IWin32Window) MainForm.Instance, ml.ml_string(524, "Automatic Update failed, do you wish to load it manual?"), ml.ml_string(525, "Master Version Update"), MessageBoxButtons.YesNo) == DialogResult.No)
        return false;
      CommunicationPool.Instance.Stop();
      bool flag = MessageBox.Show((IWin32Window) MainForm.Instance, ml.ml_string(526, "Is the master connected over USB?"), ml.ml_string(527, "Manual Master Version Update"), MessageBoxButtons.YesNo) == DialogResult.Yes;
      if (flag)
      {
        if (MessageBox.Show((IWin32Window) MainForm.Instance, ml.ml_string(528, "Connect USB cable to Master and PC\nConnect Power to Master while pressing the OK button.\nRed light appears on the master, (continue pressing the OK button)"), ml.ml_string(527, "Manual Master Version Update"), MessageBoxButtons.OKCancel) == DialogResult.Cancel)
        {
          CommunicationPool.Instance.RefreshComPort();
          return false;
        }
      }
      else if (MessageBox.Show((IWin32Window) MainForm.Instance, ml.ml_string(529, "Connect PC cable to Master and PC"), ml.ml_string(527, "Manual Master Version Update"), MessageBoxButtons.OKCancel) == DialogResult.Cancel)
      {
        CommunicationPool.Instance.RefreshComPort();
        return false;
      }
      using (LoadingMasterForm loadingMasterForm = new LoadingMasterForm())
      {
        try
        {
          string str = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\";
          loadingMasterForm.Show((IWin32Window) parent);
          loadingMasterForm.labelTime.Text = string.Format(ml.ml_string(342, "Stopping communication..."));
          loadingMasterForm.Update();
          loadingMasterForm.labelTime.Text = string.Format(ml.ml_string(343, "Starting loader program..."));
          loadingMasterForm.Update();
          Process process = Process.Start(str + "ApplicationUpdate.exe", MasterUpdater.parameters);
          DateTime now = DateTime.Now;
          if (flag)
          {
            string text = loadingMasterForm.labelText.Text;
            loadingMasterForm.labelText.Text = ml.ml_string(530, "Please wait while holding the OK button pressed");
            loadingMasterForm.Update();
            Thread.Sleep(20000);
            loadingMasterForm.labelText.Text = text;
            loadingMasterForm.Update();
            int num = (int) MessageBox.Show((IWin32Window) MainForm.Instance, ml.ml_string(531, "Release OK button on master and press OK button once!\nLoading will commence."), ml.ml_string(527, "Manual Master Version Update"), MessageBoxButtons.OK);
          }
          else
          {
            int num1 = (int) MessageBox.Show((IWin32Window) MainForm.Instance, ml.ml_string(532, "Connect power to Master and loading will commence"), ml.ml_string(527, "Manual Master Version Update"), MessageBoxButtons.OK);
          }
          while (!process.HasExited)
          {
            Thread.Sleep(500);
            TimeSpan timeSpan = DateTime.Now - now;
            loadingMasterForm.labelTime.Text = string.Format(ml.ml_string(345, "Loading started, time elapsed: {0}m{1}s"), (object) timeSpan.Minutes, (object) timeSpan.Seconds);
            loadingMasterForm.Update();
            if (timeSpan.TotalMinutes > 10.0)
            {
              int num2 = (int) MessageBox.Show((IWin32Window) loadingMasterForm, ml.ml_string(346, "More then 10 minutes are elapsed, there went something wrong when loading the master, please try again by restarting BCE and the master."));
              CommunicationPool.Instance.RefreshComPort();
              return false;
            }
          }
          CommunicationPool.Instance.RefreshComPort();
          if (loadingMasterForm.Visible)
            loadingMasterForm.Hide();
          if (process.ExitCode == 0)
          {
            int num3 = (int) MessageBox.Show((IWin32Window) parent, ml.ml_string(299, "New version of Master loaded..."));
          }
          else
          {
            string text = ml.ml_string(301, "Error ") + process.ExitCode.ToString() + ml.ml_string(302, " when loading new master software : ");
            switch (process.ExitCode)
            {
              case -99:
                text += "Bootloader hangs";
                break;
              case -10:
                text += "Internal error";
                break;
              case -9:
                text += "Not a correct device";
                break;
              case -8:
                text += "Wrong or faulty answer from device";
                break;
              case -7:
                text += "Error while writing to the serial port";
                break;
              case -6:
                text += "File size of selected file not correct";
                break;
              case -5:
              case -4:
              case -3:
                text += "Can not open selected file";
                break;
              case -2:
                text += "Timeout: Synchronisation with Bootloader";
                break;
              case -1:
                text += "Can't open the comport";
                break;
            }
            int num2 = (int) MessageBox.Show((IWin32Window) parent, text);
            return false;
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show((IWin32Window) parent, ml.ml_string(300, "Error while updating master software:") + ex.ToString());
          CommunicationPool.Instance.RefreshComPort();
          return false;
        }
        if (loadingMasterForm.Visible)
          loadingMasterForm.Hide();
        return true;
      }
    }

    public static int UpdateMaster(
      int masterVersion,
      int comport,
      Form parent,
      bool antennaInsteadOfMaster)
    {
      using (LoadingMasterForm loadingMasterForm = new LoadingMasterForm())
      {
        try
        {
          SoftwareVersionInfo softwareVersionInfo = (SoftwareVersionInfo) null;
          foreach (SoftwareVersionInfo version in SoftwareDownloader.Versions)
          {
            if (!antennaInsteadOfMaster && version.VersionType == SoftwareVersionInfo.VersionTypes.Master)
            {
              softwareVersionInfo = version;
              break;
            }
            if (antennaInsteadOfMaster && version.VersionType == SoftwareVersionInfo.VersionTypes.Esa)
            {
              softwareVersionInfo = version;
              break;
            }
          }
          if (softwareVersionInfo != null)
          {
            if (masterVersion < softwareVersionInfo.Version)
            {
              string str1 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\";
              loadingMasterForm.Show((IWin32Window) parent);
              loadingMasterForm.labelTime.Text = string.Format(ml.ml_string(377, "Downloading latest master version..."));
              loadingMasterForm.Update();
              loadingMasterForm.Activate();
              if (softwareVersionInfo.LocalFileName != softwareVersionInfo.Url)
                SoftwareDownloader.DownloadFile(softwareVersionInfo.Url, softwareVersionInfo.LocalFileName);
              File.Delete(softwareVersionInfo.LocalFileName + ".enc");
              File.Copy(softwareVersionInfo.LocalFileName, softwareVersionInfo.LocalFileName + ".enc");
              bool flag = false;
              if (!antennaInsteadOfMaster)
              {
                loadingMasterForm.labelTime.Text = string.Format(ml.ml_string(341, "Resetting master..."));
                loadingMasterForm.Update();
                switch (CommunicationPool.Instance.SendResetMasterCommand())
                {
                  case -1:
                    loadingMasterForm.Hide();
                    return -1;
                  case 0:
                    flag = true;
                    break;
                }
              }
              loadingMasterForm.labelTime.Text = string.Format(ml.ml_string(836, "Stopping communication..."));
              loadingMasterForm.Update();
              CommunicationPool.Instance.Stop();
              loadingMasterForm.labelTime.Text = string.Format(ml.ml_string(343, "Starting loader program..."));
              loadingMasterForm.Update();
              MasterUpdater.parameters = string.Format("/F:{0} /C:{1} /B:38400 /T:60", (object) (softwareVersionInfo.LocalFileName + ".enc"), (object) comport);
              Process process = Process.Start(str1 + "ApplicationUpdate.exe", MasterUpdater.parameters);
              if (flag | antennaInsteadOfMaster)
              {
                int num1 = (int) MessageBox.Show((IWin32Window) loadingMasterForm, ml.ml_string(344, "Could not restart master, please manually restart it now."));
              }
              DateTime now = DateTime.Now;
              while (!process.HasExited)
              {
                Thread.Sleep(500);
                TimeSpan timeSpan = DateTime.Now - now;
                loadingMasterForm.labelTime.Text = string.Format(ml.ml_string(345, "Loading started, time elapsed: {0}m{1}s"), (object) timeSpan.Minutes, (object) timeSpan.Seconds);
                loadingMasterForm.Update();
                if (timeSpan.TotalMinutes > 10.0)
                {
                  int num2 = (int) MessageBox.Show((IWin32Window) loadingMasterForm, ml.ml_string(346, "More then 10 minutes are elapsed, there went something wrong when loading the master, please try again by restarting BCE and the master."));
                  CommunicationPool.Instance.RefreshComPort();
                  return 0;
                }
              }
              if (loadingMasterForm.Visible)
                loadingMasterForm.Hide();
              if (process.ExitCode == 0)
              {
                File.Delete(softwareVersionInfo.LocalFileName + ".enc");
                int num2 = (int) MessageBox.Show((IWin32Window) parent, ml.ml_string(299, "New version of Master loaded..."));
                CommunicationPool.Instance.RefreshComPort();
              }
              else
              {
                string str2 = ml.ml_string(301, "Error ");
                int exitCode = process.ExitCode;
                string str3 = exitCode.ToString();
                string str4 = ml.ml_string(302, " when loading new master software : ");
                string text = str2 + str3 + str4;
                exitCode = process.ExitCode;
                switch (exitCode)
                {
                  case -99:
                    text += "Bootloader hangs";
                    break;
                  case -10:
                    text += "Internal error";
                    break;
                  case -9:
                    text += "Not a correct device";
                    break;
                  case -8:
                    text += "Wrong or faulty answer from device";
                    break;
                  case -7:
                    text += "Error while writing to the serial port";
                    break;
                  case -6:
                    text += "File size of selected file not correct";
                    break;
                  case -5:
                  case -4:
                  case -3:
                    text += "Can not open selected file";
                    break;
                  case -2:
                    text += "Timeout: Synchronisation with Bootloader";
                    break;
                  case -1:
                    text += "Can't open the comport";
                    break;
                }
                int num2 = (int) MessageBox.Show((IWin32Window) parent, text);
                CommunicationPool.Instance.RefreshComPort();
                return 0;
              }
            }
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show((IWin32Window) parent, ml.ml_string(300, "Error while updating master software:") + ex.ToString());
          CommunicationPool.Instance.RefreshComPort();
          return 0;
        }
        if (loadingMasterForm.Visible)
          loadingMasterForm.Hide();
        return 1;
      }
    }
  }
}
