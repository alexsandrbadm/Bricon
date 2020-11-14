// Decompiled with JetBrains decompiler
// Type: BriconLib.SoftwareUpdater
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.BCE;
using MultiLang;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace BriconLib
{
  public class SoftwareUpdater
  {
    public void Install(string appFolder, string downloadPath, StreamWriter logFile)
    {
      string path1 = "";
      try
      {
        logFile.WriteLine(DateTime.Now.ToString() + ": Installing new version");
        path1 = appFolder + "Backup " + DateTime.Now.ToString("yy-MM-dd hhmm") + "\\";
        logFile.WriteLine("CreateDirectory " + path1);
        Directory.CreateDirectory(path1);
        foreach (string file in Directory.GetFiles(downloadPath, "*.*", SearchOption.AllDirectories))
        {
          string path2 = file.Replace(downloadPath, "");
          string directoryName = Path.GetDirectoryName(path2);
          if (directoryName != "")
          {
            logFile.WriteLine("CreateDirectory " + appFolder + directoryName);
            Directory.CreateDirectory(appFolder + directoryName);
          }
          if (File.Exists(appFolder + path2))
          {
            logFile.WriteLine("Move " + appFolder + path2 + " to backupfolder");
            if (directoryName != "")
            {
              logFile.WriteLine("CreateDirectory " + path1 + directoryName);
              Directory.CreateDirectory(path1 + directoryName);
            }
            File.Move(appFolder + path2, path1 + path2);
          }
          logFile.WriteLine("Move " + downloadPath + path2 + " to " + appFolder + path2);
          File.Copy(downloadPath + path2, appFolder + path2);
        }
        logFile.WriteLine("Deleting " + downloadPath);
        Thread.Sleep(10000);
        Directory.Delete(downloadPath, true);
      }
      catch (Exception ex)
      {
        string text = string.Format(ml.ml_string(184, "Fatal error occurred when updating the program,\nplease try to fix it again by manually copy the original program files from \n'{0}' to '{1}' or try to copy the new files from\n'{2}' to '{3}'\nSee '{4}\\SoftwareUpdates.log' for details.\n\nError: {5}\n"), (object) path1, (object) appFolder, (object) downloadPath, (object) appFolder, (object) appFolder, (object) ex);
        logFile.Write(text);
        int num = (int) MessageBox.Show((IWin32Window) MainForm.Instance, text);
      }
    }
  }
}
