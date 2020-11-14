// Decompiled with JetBrains decompiler
// Type: BriconLib.SoftwareDownloader
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.BCE;
using BriconLib.Other;
using BriconLib.Properties;
using BriconLib.UI;
using MultiLang;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace BriconLib
{
  public class SoftwareDownloader
  {
    private bool _isBCE;
    private string _downloadURL;
    private List<string> _filesToDownload = new List<string>();
    public static List<SoftwareVersionInfo> Versions = new List<SoftwareVersionInfo>();
    public static bool VersionsTxtProcessed = false;
    public static string DownloadedCountry = (string) null;

    public SoftwareDownloader(bool isBCE) => this._isBCE = isBCE;

    private string MakePMFileNameIfNeeded(string filename) => this._isBCE ? filename : filename.Replace(".txt", "pm.txt");

    private void DownloadVersionAndMessages()
    {
    }

    public bool IsNewerVersionAvailable(string appFolder, StreamWriter logFile)
    {
      try
      {
        bool flag = false;
        string str1 = "http://www.bricon.be/download/text/versions.txt";
        string filename = "http://www.bricon.be/download/text/messages.txt";
        try
        {
          using (XmlTextReader xmlTextReader = new XmlTextReader(str1))
            xmlTextReader.Read();
          using (XmlTextReader xmlTextReader = new XmlTextReader(this.MakePMFileNameIfNeeded(filename)))
            xmlTextReader.Read();
        }
        catch (Exception ex)
        {
          flag = true;
          logFile.WriteLine(DateTime.Now.ToString() + ": Working in offline modus");
          str1 = appFolder + "Updates\\versions.txt";
          filename = appFolder + "Updates\\messages.txt";
        }
        SoftwareDownloader.DownloadedCountry = Settings.Default.Country;
        using (XmlTextReader xmlTextReader = new XmlTextReader(str1))
        {
          while (xmlTextReader.Read())
          {
            int content = (int) xmlTextReader.MoveToContent();
            if (xmlTextReader.Name == "VERSION")
            {
              if (Utils.IsCountry(xmlTextReader.GetAttribute("country")))
              {
                SoftwareVersionInfo softwareVersionInfo = new SoftwareVersionInfo();
                softwareVersionInfo.Version = (Convert.ToInt32("0" + xmlTextReader.GetAttribute("majorversion")) << 8) + Convert.ToInt32("0" + xmlTextReader.GetAttribute("version"));
                softwareVersionInfo.VersionType = SoftwareVersionInfo.VersionTypes.Master;
                if (xmlTextReader.GetAttribute("softwaretype") != null)
                {
                  softwareVersionInfo.VersionType = (SoftwareVersionInfo.VersionTypes) Convert.ToInt32("0" + xmlTextReader.GetAttribute("softwaretype"));
                  softwareVersionInfo.Storage = Convert.ToByte("0" + xmlTextReader.GetAttribute("storage"));
                  softwareVersionInfo.MenuString = xmlTextReader.GetAttribute("menustring");
                }
                softwareVersionInfo.Url = xmlTextReader.GetAttribute("url");
                string str2 = softwareVersionInfo.Url.Replace("http://www.bricon.be/download/", "Updates\\").Replace("/", "\\");
                softwareVersionInfo.LocalFileName = str2;
                if (flag)
                  softwareVersionInfo.Url = str2;
                SoftwareDownloader.Versions.Add(softwareVersionInfo);
              }
              if (xmlTextReader.GetAttribute("country") == "ESA")
              {
                SoftwareVersionInfo softwareVersionInfo = new SoftwareVersionInfo();
                softwareVersionInfo.Version = 1000;
                softwareVersionInfo.VersionType = SoftwareVersionInfo.VersionTypes.Esa;
                softwareVersionInfo.Url = xmlTextReader.GetAttribute("url");
                string str2 = softwareVersionInfo.Url.Replace("http://www.bricon.be/download/", "Updates\\").Replace("/", "\\");
                softwareVersionInfo.LocalFileName = str2;
                if (flag)
                  softwareVersionInfo.Url = str2;
                SoftwareDownloader.Versions.Add(softwareVersionInfo);
              }
            }
          }
        }
        SoftwareDownloader.VersionsTxtProcessed = true;
        using (XmlTextReader xmlTextReader = new XmlTextReader(this.MakePMFileNameIfNeeded(filename)))
        {
          while (xmlTextReader.Read())
          {
            int content = (int) xmlTextReader.MoveToContent();
            if (xmlTextReader.Name == "MESSAGE" && Settings.Default.Language.Equals(xmlTextReader.GetAttribute("language"), StringComparison.InvariantCultureIgnoreCase) && Settings.Default.Country.Equals(xmlTextReader.GetAttribute("country"), StringComparison.InvariantCultureIgnoreCase))
            {
              Convert.ToInt32(xmlTextReader.GetAttribute("number"));
              string attribute = xmlTextReader.GetAttribute("text");
              AboutPage.Messages = AboutPage.Messages + attribute + "\r\n\r\n";
            }
          }
        }
        if (!flag)
        {
          SoftwareDownloader.DownloadFile(this.MakePMFileNameIfNeeded(filename), appFolder + this.MakePMFileNameIfNeeded("Updates\\messages.txt"));
          SoftwareDownloader.DownloadFile(str1, appFolder + "Updates\\versions.txt");
        }
        string str3 = Path.GetFileName(Assembly.GetEntryAssembly().Location);
        string str4;
        if (str3.Contains("_Beta"))
        {
          str3 = str3.Replace("_Beta", "");
          str4 = "http://briconweb.adgsoft.be/";
        }
        else
          str4 = "http://www.briconweb.com/";
        StreamWriter streamWriter1 = logFile;
        DateTime now = DateTime.Now;
        string str5 = now.ToString() + ": downloading from " + str4;
        streamWriter1.WriteLine(str5);
        using (XmlTextReader xmlTextReader = new XmlTextReader(str4 + "downloads/downloads.xml"))
        {
          while (xmlTextReader.Read())
          {
            int content1 = (int) xmlTextReader.MoveToContent();
            if (xmlTextReader.Name == "PROGRAM")
            {
              string attribute = xmlTextReader.GetAttribute("name");
              if (attribute != null && attribute.ToLower() == str3.ToLower())
              {
                this._downloadURL = str4 + xmlTextReader.GetAttribute("url");
                StreamWriter streamWriter2 = logFile;
                now = DateTime.Now;
                string str2 = now.ToString() + ": downloading from " + this._downloadURL;
                streamWriter2.WriteLine(str2);
                while (xmlTextReader.Read())
                {
                  int content2 = (int) xmlTextReader.MoveToContent();
                  if (xmlTextReader.Name == "FILE")
                  {
                    if (xmlTextReader.GetAttribute("downloadonce") == "true")
                    {
                      if (!System.IO.File.Exists(appFolder + xmlTextReader.GetAttribute("name")))
                        this._filesToDownload.Add(xmlTextReader.GetAttribute("name"));
                    }
                    else
                      this._filesToDownload.Add(xmlTextReader.GetAttribute("name"));
                  }
                  else
                    break;
                }
              }
            }
          }
        }
        if (this._downloadURL != null && this._filesToDownload.Count > 0)
        {
          logFile.WriteLine(DateTime.Now.ToString() + ": Checking for newer version...");
          string tempFileName = Path.GetTempFileName();
          this.DownloadFile2(Path.GetFileName(Assembly.GetEntryAssembly().Location).Replace("_Beta", ""), tempFileName);
          try
          {
            if (AssemblyName.GetAssemblyName(tempFileName).Version > Assembly.GetEntryAssembly().GetName().Version)
              return true;
          }
          catch (BadImageFormatException ex)
          {
            return true;
          }
          finally
          {
            System.IO.File.Delete(tempFileName);
          }
        }
        else
          logFile.WriteLine(DateTime.Now.ToString() + ": Could not contact website to check for newer versions");
      }
      catch (Exception ex)
      {
        logFile.Write(DateTime.Now.ToString() + ": Exception when checking for newer version : \n" + ex.ToString());
      }
      return false;
    }

    public bool DownloadNewVersion(string downloadPath, StreamWriter logFile)
    {
      try
      {
        logFile.WriteLine(DateTime.Now.ToString() + ": Downloading new version");
        logFile.WriteLine("Deleting Directory " + downloadPath);
        if (Directory.Exists(downloadPath))
          Directory.Delete(downloadPath, true);
        logFile.WriteLine("Create Directory " + downloadPath);
        Directory.CreateDirectory(downloadPath);
        foreach (string fileName1 in this._filesToDownload)
        {
          string fileName2 = Path.GetFileName(Assembly.GetEntryAssembly().Location);
          if ((!fileName2.Contains("_Beta") || fileName1.Contains("_Beta") ? 0 : (fileName2.Replace("_Beta", "").ToLower() == fileName1.ToLower().Replace(".exe.config", ".exe") ? 1 : 0)) == 0)
          {
            logFile.WriteLine("Downloading " + this._downloadURL + fileName1 + " to " + downloadPath + fileName1);
            this.DownloadFile2(fileName1, downloadPath + fileName1);
          }
          else
          {
            logFile.WriteLine("Downloading " + this._downloadURL + fileName1 + " to " + downloadPath + fileName1.Replace(".exe", "_Beta.exe"));
            this.DownloadFile2(fileName1, downloadPath + fileName1.Replace(".exe", "_Beta.exe"));
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        string text = ml.ml_string(175, "Fatal error occurred when downloading a newer version,\n") + ml.ml_string(177, "it will be retried next time you run the program, if these problems remain \n") + ml.ml_string(178, "please set off automatic downloads on the optionspage\n\n") + ml.ml_string(179, "Error : ") + ex.ToString();
        logFile.Write(text);
        int num = (int) MessageBox.Show((IWin32Window) MainForm.Instance, text);
      }
      return false;
    }

    public static void DownloadFile(string fileName, string localFileName)
    {
      using (Stream responseStream = WebRequest.Create(fileName).GetResponse().GetResponseStream())
      {
        byte[] buffer = SoftwareDownloader.ReadFully(responseStream);
        if (!Directory.Exists(Path.GetDirectoryName(localFileName)))
          Directory.CreateDirectory(Path.GetDirectoryName(localFileName));
        using (FileStream fileStream = new FileStream(localFileName, FileMode.Create, FileAccess.Write))
          fileStream.Write(buffer, 0, buffer.Length);
      }
    }

    private void DownloadFile2(string fileName, string localFileName) => SoftwareDownloader.DownloadFile(this._downloadURL + fileName, localFileName);

    private static byte[] ReadFully(Stream stream)
    {
      byte[] buffer = new byte[32768];
      int length = 0;
      int num1;
      while ((num1 = stream.Read(buffer, length, buffer.Length - length)) > 0)
      {
        length += num1;
        if (length == buffer.Length)
        {
          int num2 = stream.ReadByte();
          if (num2 == -1)
            return buffer;
          byte[] numArray = new byte[buffer.Length * 2];
          Array.Copy((Array) buffer, (Array) numArray, buffer.Length);
          numArray[length] = (byte) num2;
          buffer = numArray;
          ++length;
        }
      }
      byte[] numArray1 = new byte[length];
      Array.Copy((Array) buffer, (Array) numArray1, length);
      return numArray1;
    }
  }
}
