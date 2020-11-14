// Decompiled with JetBrains decompiler
// Type: BriconLib.Updater.PrerequisitesInstall
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using Microsoft.Win32;
using MultiLang;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace BriconLib.Updater
{
  public class PrerequisitesInstall
  {
    public static bool IsReportViewer2010Installed()
    {
      RegistryKey registryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, string.Empty);
      return registryKey != null && (registryKey.OpenSubKey("Software\\Microsoft\\ReportViewer\\v10.0") ?? registryKey.OpenSubKey("Software\\Wow6432Node\\Microsoft\\ReportViewer\\v10.0")) != null;
    }

    private static bool IsValidOperatingSystem() => Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 5 && (Environment.OSVersion.Version.Major != 5 || Environment.OSVersion.Version.Minor != 1 || !(Environment.OSVersion.ServicePack != "Service Pack 3")) && ((Environment.OSVersion.Version.Major != 5 || Environment.OSVersion.Version.Minor != 2 || !(Environment.OSVersion.ServicePack != "Service Pack 2")) && (Environment.OSVersion.Version.Major != 6 || Environment.OSVersion.Version.Minor != 0 || Environment.OSVersion.ServicePack.StartsWith("Service Pack")));

    public static void InstallIfNeeded()
    {
      if (!PrerequisitesInstall.IsValidOperatingSystem())
      {
        int num1 = (int) MessageBox.Show(ml.ml_string(1145, "Your operating system is no longer supported for this program,\nin order to upgrade to the latest version you need at least windows XP SP3,\nplease install the latest service pack or upgrade your operating system.\nYour system: ") + Environment.OSVersion.VersionString);
      }
      else
      {
        if (PrerequisitesInstall.IsReportViewer2010Installed())
          return;
        int num2 = (int) MessageBox.Show(ml.ml_string(1151, "Microsoft Report Viewer 2010 is not installed, this will downloaded and installed now."), ml.ml_string(1147, "Software Upgrade"), MessageBoxButtons.OK);
        string str = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\";
        if (!File.Exists(str + "ReportViewer2010.exe"))
        {
          SoftwareDownloader.DownloadFile("http://www.briconweb.com/downloads/ReportViewer2010.exe", str + "ReportViewer2010.exe");
          if (!File.Exists(str + "ReportViewer2010.exe"))
          {
            int num3 = (int) MessageBox.Show(ml.ml_string(1152, "Report Viewer 2010 setup could not been downloaded"));
            return;
          }
          int num4 = (int) MessageBox.Show(ml.ml_string(1153, "Microsoft Report Viewer 2010 is downloaded, it will be installed now"));
        }
        Process process = Process.Start(str + "ReportViewer2010.exe", "/passive");
        do
          ;
        while (!process.HasExited);
        if (PrerequisitesInstall.IsReportViewer2010Installed())
        {
          int num5 = (int) MessageBox.Show(ml.ml_string(1154, "Microsoft Report Viewer 2010 is successfully installed"));
        }
        else
        {
          int num6 = (int) MessageBox.Show(ml.ml_string(1155, "Some error occurred while installing the report viewer 2010 runtime, please reboot and retry, otherwise please download it from the Microsoft site and install it manually"));
        }
      }
    }
  }
}
