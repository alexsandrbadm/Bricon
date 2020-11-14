// Decompiled with JetBrains decompiler
// Type: BriconLib.Updater.FancierUpdater
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.BCE;
using BriconLib.Communications;
using BriconLib.Other;
using BriconLib.UI;
using MultiLang;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace BriconLib.Updater
{
  public class FancierUpdater
  {
    private static int GetVersionForType(int[] fancierVersions, SoftwareVersionInfo info)
    {
      int num = 254;
      switch (info.VersionType)
      {
        case SoftwareVersionInfo.VersionTypes.Speedy:
          num = fancierVersions[2 + (int) info.Storage];
          break;
        case SoftwareVersionInfo.VersionTypes.BPlus:
          num = fancierVersions[4 + (int) info.Storage];
          break;
        case SoftwareVersionInfo.VersionTypes.Little:
          num = fancierVersions[(int) info.Storage];
          break;
      }
      if (num == (int) byte.MaxValue)
        num = 0;
      return num;
    }

    private static bool DoWeNeedToUpdate(int[] fancierVersions)
    {
      foreach (SoftwareVersionInfo version in SoftwareDownloader.Versions)
      {
        if (version.VersionType != SoftwareVersionInfo.VersionTypes.Master && version.VersionType != SoftwareVersionInfo.VersionTypes.Esa && version.Version > FancierUpdater.GetVersionForType(fancierVersions, version))
          return true;
      }
      return false;
    }

    private static void DownLoadVersions(int[] fancierVersions, string path)
    {
      foreach (SoftwareVersionInfo version in SoftwareDownloader.Versions)
      {
        if (version.VersionType != SoftwareVersionInfo.VersionTypes.Master && version.VersionType != SoftwareVersionInfo.VersionTypes.Esa && (version.Version > FancierUpdater.GetVersionForType(fancierVersions, version) && version.Url != version.LocalFileName))
          SoftwareDownloader.DownloadFile(version.Url, version.LocalFileName);
      }
    }

    public static void UpdateFancier(int[] fancierVersions, int comport, Form parent)
    {
      using (LoadingMasterForm loadingMasterForm = new LoadingMasterForm())
      {
        try
        {
          if (!FancierUpdater.DoWeNeedToUpdate(fancierVersions))
            return;
          if (!Utils.IsCountry(SoftwareDownloader.DownloadedCountry))
          {
            int num = (int) MessageBox.Show((IWin32Window) MainForm.Instance, ml.ml_string(406, "Countrycode of downloaded versions not the same like in Master, aborting update"));
            return;
          }
          if (!CommunicationPool.Instance.IsCountryCodeCorrect())
            return;
          string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\";
          loadingMasterForm.Show((IWin32Window) parent);
          loadingMasterForm.labelTime.Text = string.Format(ml.ml_string(369, "Downloading latest fancier versions..."));
          loadingMasterForm.Update();
          loadingMasterForm.Activate();
          FancierUpdater.DownLoadVersions(fancierVersions, path);
          loadingMasterForm.labelTime.Text = string.Format(ml.ml_string(370, "Waiting for master to become active again..."));
          loadingMasterForm.Update();
          while (!CommunicationState.Instance.MasterFound)
          {
            Thread.Sleep(50);
            loadingMasterForm.Update();
          }
          CommunicationPool.Instance.Stop();
          loadingMasterForm.labelTime.Text = string.Format(ml.ml_string(381, "Sending new fancierversions to Master... (can take several minutes)"));
          loadingMasterForm.progressBar.Visible = true;
          loadingMasterForm.Update();
          int activeComport = CommunicationPool.Instance.ActiveComport;
          Communication communication = new Communication();
          communication.StartComm("COM" + activeComport.ToString(), 9600);
          SearchMasterCommand searchMasterCommand1 = new SearchMasterCommand((byte) 2);
          int num1 = (int) communication.SendCommand((BriconLib.Communications.Command) searchMasterCommand1);
          if (searchMasterCommand1.Status != ResponseStatus.OK && searchMasterCommand1.Status != ResponseStatus.SwitchAfterResponceTo38400)
          {
            loadingMasterForm.Hide();
            int num2 = (int) MessageBox.Show((IWin32Window) MainForm.Instance, ml.ml_string(372, "Switch to 38400baud failed, response : ") + searchMasterCommand1.ToString());
            communication.StopComm();
            CommunicationPool.Instance.RefreshComPort();
            return;
          }
          communication.StopComm();
          communication.StartComm("COM" + activeComport.ToString(), 38400);
          foreach (SoftwareVersionInfo version in SoftwareDownloader.Versions)
          {
            if (version.VersionType != SoftwareVersionInfo.VersionTypes.Master && version.VersionType != SoftwareVersionInfo.VersionTypes.Esa && version.Version > FancierUpdater.GetVersionForType(fancierVersions, version))
            {
              loadingMasterForm.labelTime.Text = string.Format(ml.ml_string(382, "Uploading ") + version.MenuString);
              loadingMasterForm.Update();
              SendVersionInfoCommand versionInfoCommand = new SendVersionInfoCommand(version.MenuString, (byte) version.VersionType, (byte) version.Version, version.Storage);
              if (communication.SendCommand((BriconLib.Communications.Command) versionInfoCommand) != ResponseStatus.OK)
              {
                loadingMasterForm.Hide();
                int num2 = (int) MessageBox.Show((IWin32Window) MainForm.Instance, ml.ml_string(373, "Send Version Info failed, response : ") + versionInfoCommand.ToString());
                communication.StopComm();
                CommunicationPool.Instance.RefreshComPort();
                return;
              }
              using (Stream stream = (Stream) new FileStream(version.LocalFileName, FileMode.Open, FileAccess.Read))
              {
                loadingMasterForm.progressBar.Value = 0;
                int int32 = Convert.ToInt32(stream.Length);
                loadingMasterForm.progressBar.Maximum = int32 / 1024;
                byte[] buffer = new byte[int32];
                stream.Read(buffer, 0, int32);
                byte[] data1 = new byte[128];
                SendUpdateFileCommand updateFileCommand1 = new SendUpdateFileCommand(data1, (byte) version.VersionType, (byte) version.Version, version.Storage);
                int sourceIndex;
                for (sourceIndex = 0; sourceIndex < int32 - 128; sourceIndex += 128)
                {
                  Array.Copy((Array) buffer, sourceIndex, (Array) data1, 0, 128);
                  if (communication.SendCommand((BriconLib.Communications.Command) updateFileCommand1, 500) != ResponseStatus.OK)
                  {
                    loadingMasterForm.Hide();
                    int num2 = (int) MessageBox.Show((IWin32Window) MainForm.Instance, ml.ml_string(374, "Failed to send a block, skipping the rest: ") + updateFileCommand1.ToString());
                    SearchMasterCommand searchMasterCommand2 = new SearchMasterCommand((byte) 1);
                    int num3 = (int) communication.SendCommand((BriconLib.Communications.Command) searchMasterCommand2);
                    communication.StopComm();
                    CommunicationPool.Instance.RefreshComPort();
                    return;
                  }
                  if (sourceIndex % 1280 == 0)
                  {
                    loadingMasterForm.progressBar.Value = Convert.ToInt32(sourceIndex) / 1024;
                    loadingMasterForm.Update();
                  }
                }
                byte[] data2 = new byte[int32 - sourceIndex];
                for (int index = 0; index < data2.Length; ++index)
                  data2[index] = buffer[sourceIndex + index];
                SendUpdateFileCommand updateFileCommand2 = new SendUpdateFileCommand(data2, (byte) version.VersionType, (byte) version.Version, version.Storage);
                if (communication.SendCommand((BriconLib.Communications.Command) updateFileCommand2, 500) != ResponseStatus.OK)
                {
                  loadingMasterForm.Hide();
                  int num2 = (int) MessageBox.Show((IWin32Window) MainForm.Instance, ml.ml_string(374, "Failed to send a block, skipping the rest: ") + updateFileCommand2.ToString());
                  SearchMasterCommand searchMasterCommand2 = new SearchMasterCommand((byte) 1);
                  int num3 = (int) communication.SendCommand((BriconLib.Communications.Command) searchMasterCommand2);
                  communication.StopComm();
                  CommunicationPool.Instance.RefreshComPort();
                  return;
                }
              }
            }
          }
          SearchMasterCommand searchMasterCommand3 = new SearchMasterCommand((byte) 1);
          int num4 = (int) communication.SendCommand((BriconLib.Communications.Command) searchMasterCommand3);
          if (searchMasterCommand3.Status != ResponseStatus.OK && searchMasterCommand3.Status != ResponseStatus.SwitchAfterResponceTo9600)
          {
            loadingMasterForm.Hide();
            int num2 = (int) MessageBox.Show((IWin32Window) MainForm.Instance, ml.ml_string(375, "Switch back to 9600baud failed, response : ") + searchMasterCommand3.ToString());
            communication.StopComm();
            CommunicationPool.Instance.RefreshComPort();
            return;
          }
          communication.Stop();
          CommunicationPool.Instance.RefreshComPort();
          loadingMasterForm.Hide();
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show((IWin32Window) parent, ml.ml_string(376, "Error while updating fancier software:") + ex.ToString());
        }
        if (!loadingMasterForm.Visible)
          return;
        loadingMasterForm.Hide();
      }
    }
  }
}
