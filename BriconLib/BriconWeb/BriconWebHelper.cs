// Decompiled with JetBrains decompiler
// Type: BriconLib.BriconWeb.BriconWebHelper
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using BriconLib.Monitor;
using BriconLib.Other;
using BriconLib.PrintManager;
using BriconLib.Properties;
using MultiLang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BriconLib.BriconWeb
{
  internal class BriconWebHelper
  {
    public static bool TestConnection()
    {
      PrintmanagerClient printmanagerClient = (PrintmanagerClient) null;
      try
      {
        if (Settings.Default.LoginBriconWeb == "")
          return true;
        printmanagerClient = new PrintmanagerClient();
        string header = BriconWebHelper.BuildHeader(Settings.Default.LoginBriconWeb);
        string status = printmanagerClient.GetStatus(header);
        if (!status.StartsWith("Error"))
        {
          if (Settings.Default.SendMonitorDataToBW)
          {
            try
            {
              printmanagerClient = new PrintmanagerClient();
              string str = printmanagerClient.SendMonitorData(header, "");
              if (str.StartsWith("Error"))
              {
                if (str.Contains("license"))
                {
                  Settings.Default.SendMonitorDataToBW = false;
                }
                else
                {
                  int num = (int) MessageBox.Show(ml.ml_string(1242, "Error with send monitordata, response: ") + str);
                  return false;
                }
              }
            }
            finally
            {
              printmanagerClient?.Close();
            }
          }
        }
        if (!(status != "OK"))
          return true;
        int num1 = (int) MessageBox.Show(ml.ml_string(1091, "Error with briconweb, response: ") + status);
        return false;
      }
      catch (EndpointNotFoundException ex)
      {
        int num = (int) MessageBox.Show(ml.ml_string(1092, "Error with briconweb, could not send to BriconWeb, please check your internet connection and firewall."));
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ml.ml_string(1093, "Error with briconweb, exception: ") + ex.ToString());
      }
      finally
      {
        printmanagerClient?.Close();
      }
      return false;
    }

    public static bool Send(
      List<RaceCommand> races,
      List<PigeonCommand> pigeons,
      string license,
      MonitorForm monitorForm)
    {
      try
      {
        Stopwatch.StartNew();
        StringBuilder stringBuilder = new StringBuilder();
        string header = BriconWebHelper.BuildHeader(license);
        foreach (PigeonCommand pigeon in pigeons)
        {
          if (pigeon.RaceIndex >= 0 && pigeon.RaceIndex + 1 < races.Count && races[pigeon.RaceIndex + 1].ActiveInBriconWeb)
            stringBuilder.AppendLine(pigeon.ToBriconWebString(races[pigeon.RaceIndex + 1].FlightIDBriconWeb, races[pigeon.RaceIndex + 1].ClubID));
        }
        string str = "";
        PrintmanagerClient printmanagerClient = (PrintmanagerClient) null;
        try
        {
          printmanagerClient = new PrintmanagerClient();
          str = printmanagerClient.GetPigeons(header, stringBuilder.ToString());
        }
        finally
        {
          printmanagerClient?.Close();
        }
        if (Settings.Default.BriconWebTestMode && str != "")
        {
          int num = (int) MessageBox.Show(str);
        }
        if (str.StartsWith("Error"))
          Utils.LogErrorToBWLog(str);
        foreach (PigeonCommand pigeon in pigeons)
        {
          if (pigeon.RaceIndex >= 0 && pigeon.RaceIndex + 1 < races.Count && races[pigeon.RaceIndex + 1].ActiveInBriconWeb)
            pigeon.FromBriconWebString(str);
        }
        if (!str.StartsWith("Error"))
        {
          if (Settings.Default.SendMonitorDataToBW)
          {
            try
            {
              printmanagerClient = new PrintmanagerClient();
              string text = printmanagerClient.SendMonitorData(header, monitorForm.GetDataForWebserver());
              if (text.StartsWith("Error"))
              {
                Utils.LogErrorToBWLog(text);
                if (text.Contains(nameof (license)))
                  Settings.Default.SendMonitorDataToBW = false;
              }
            }
            finally
            {
              printmanagerClient?.Close();
            }
          }
        }
        return str.Length > 0;
      }
      catch (Exception ex)
      {
        Utils.LogErrorToBWLog(ex.ToString());
        return false;
      }
    }

    private static string BuildHeader(string license)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(Settings.Default.Country);
      stringBuilder.Append("|");
      stringBuilder.Append(license);
      stringBuilder.Append("|");
      stringBuilder.Append(Settings.Default.Country + Settings.Default.LoginBriconWeb);
      stringBuilder.Append("|");
      stringBuilder.Append(Settings.Default.PasswordBriconWeb);
      return stringBuilder.ToString();
    }

    public static bool GetFlights(List<RaceCommand> races)
    {
      try
      {
        List<RaceCommand> list = races.ToList<RaceCommand>();
        Utils.LogErrorToBWLog(nameof (GetFlights));
        if (races.Count <= 1)
        {
          Thread.Sleep(1000);
          Utils.LogErrorToBWLog("races.Count <= 1");
          return false;
        }
        Stopwatch stopwatch = Stopwatch.StartNew();
        StringBuilder stringBuilder = new StringBuilder();
        foreach (RaceCommand raceCommand in list)
        {
          if (raceCommand.Index != -1 && !raceCommand.RaceIsDeleted)
          {
            string str = !Settings.Default.SendToPipa || !raceCommand.Email2 ? "0" : "1";
            stringBuilder.AppendLine(raceCommand.RaceName + "|" + raceCommand.BasketDate.ToString("yyyy-MM-dd HH:mm:ss") + "|" + str + "|" + raceCommand.ClubID);
          }
        }
        if (stringBuilder.ToString() == "")
        {
          Thread.Sleep(1000);
          Utils.LogErrorToBWLog("sb.ToString() == ''");
          foreach (RaceCommand raceCommand in list)
            Utils.LogErrorToBWLog("raceindex:" + raceCommand.Index.ToString() + " deleted: " + raceCommand.RaceIsDeleted.ToString());
          return false;
        }
        string header = BriconWebHelper.BuildHeader((string) null);
        string text = "";
        PrintmanagerClient printmanagerClient = (PrintmanagerClient) null;
        try
        {
          printmanagerClient = new PrintmanagerClient();
          text = printmanagerClient.GetFlights(header, stringBuilder.ToString());
        }
        finally
        {
          printmanagerClient?.Close();
        }
        if (Settings.Default.BriconWebTestMode && text != "")
        {
          int num1 = (int) MessageBox.Show(text);
        }
        if (text.StartsWith("Error"))
          Utils.LogErrorToBWLog(text);
        if (text.StartsWith("Error") || text == "")
        {
          Utils.LogErrorToBWLog("ERROR : ret.StartsWith('Error') || ret == '' ");
          Utils.LogErrorToBWLog("Send : " + stringBuilder.ToString());
          Thread.Sleep(1000);
          return false;
        }
        int index = 1;
        string str1 = text;
        char[] separator = new char[2]{ '\n', '\r' };
        foreach (string str2 in str1.Split(separator, StringSplitOptions.RemoveEmptyEntries))
        {
          while (races[index].RaceIsDeleted)
            ++index;
          string[] strArray = str2.Split('|');
          if (strArray.Length >= 6 && strArray[0].Equals(races[index].RaceName))
          {
            races[index].FlightIDBriconWeb = Convert.ToInt32(strArray[4]);
            races[index].AskGummy = Convert.ToInt32(strArray[5]) > 0;
            races[index].AskOnlyFirstTwoGummies = Convert.ToInt32(strArray[6]) > 0;
            races[index].AskWingmark = Convert.ToInt32(strArray[7]) > 0;
            races[index].IsNationalFlight = Convert.ToInt32(strArray[8]) > 0;
            races[index].ClubIDBriconWeb = Convert.ToInt32(strArray[9]);
          }
          else
          {
            races[index].FlightIDBriconWeb = 0;
            races[index].AskGummy = false;
            races[index].AskOnlyFirstTwoGummies = false;
            races[index].AskWingmark = false;
            races[index].IsNationalFlight = false;
            races[index].ClubIDBriconWeb = 0;
          }
          ++index;
        }
        Utils.LogErrorToBWLog("GetFlights took " + stopwatch.ElapsedMilliseconds.ToString() + "ms");
        foreach (RaceCommand raceCommand in list)
        {
          string[] strArray = new string[8];
          strArray[0] = "CP: raceindex:";
          int num2 = raceCommand.Index;
          strArray[1] = num2.ToString();
          strArray[2] = " deleted: ";
          strArray[3] = raceCommand.RaceIsDeleted.ToString();
          strArray[4] = " ";
          strArray[5] = raceCommand.RaceName;
          strArray[6] = " ";
          num2 = raceCommand.FlightIDBriconWeb;
          strArray[7] = num2.ToString();
          Utils.LogErrorToBWLog(string.Concat(strArray));
        }
        foreach (RaceCommand raceCommand in races.ToList<RaceCommand>())
        {
          string[] strArray = new string[8];
          strArray[0] = "raceindex:";
          int num2 = raceCommand.Index;
          strArray[1] = num2.ToString();
          strArray[2] = " deleted: ";
          strArray[3] = raceCommand.RaceIsDeleted.ToString();
          strArray[4] = " ";
          strArray[5] = raceCommand.RaceName;
          strArray[6] = " ";
          num2 = raceCommand.FlightIDBriconWeb;
          strArray[7] = num2.ToString();
          Utils.LogErrorToBWLog(string.Concat(strArray));
        }
        return true;
      }
      catch (Exception ex)
      {
        Utils.LogErrorToBWLog(ex.ToString());
        Thread.Sleep(1000);
        return false;
      }
    }

    public static string SendBCEData(BCEDataSet.ClubsRow clubRow)
    {
      try
      {
        Stopwatch.StartNew();
        StringBuilder stringBuilder = new StringBuilder();
        string text = "";
        PrintmanagerClient printmanagerClient = (PrintmanagerClient) null;
        try
        {
          printmanagerClient = new PrintmanagerClient();
          BCEDataSet bceDataSet = new BCEDataSet();
          clubRow.Union = Settings.Default.Union;
          bceDataSet.Clubs.ImportRow((DataRow) clubRow);
          foreach (BCEDataSet.AdressenRow adressenRow in clubRow.GetAdressenRows())
          {
            bceDataSet.Adressen.ImportRow((DataRow) adressenRow);
            foreach (BCEDataSet.DistancesRow distancesRow in adressenRow.GetDistancesRows())
            {
              distancesRow.LosplaatsNaam = distancesRow.LossingsplaatsRow.Losplaats;
              bceDataSet.Distances.ImportRow((DataRow) distancesRow);
            }
          }
          using (StringWriter stringWriter = new StringWriter())
          {
            bceDataSet.WriteXml((TextWriter) stringWriter);
            string data = stringWriter.GetStringBuilder().ToString();
            text = printmanagerClient.SendBCEData(clubRow.ClubID, BriconWebHelper.BuildHeader((string) null), data);
          }
        }
        finally
        {
          printmanagerClient?.Close();
        }
        if (text.StartsWith("Error"))
          Utils.LogErrorToBWLog(text);
        return text;
      }
      catch (Exception ex)
      {
        Utils.LogErrorToBWLog(ex.ToString());
        return ex.Message;
      }
    }

    public static void SendSettings(bool sendToPipa)
    {
      try
      {
        if (Settings.Default.LoginBriconWeb == "")
          return;
        StringBuilder stringBuilder = new StringBuilder();
        string text = "";
        PrintmanagerClient printmanagerClient = (PrintmanagerClient) null;
        try
        {
          printmanagerClient = new PrintmanagerClient();
          text = printmanagerClient.SendSettings(BriconWebHelper.BuildHeader(Settings.Default.LoginBriconWeb), "SendToPipa=" + (sendToPipa ? "1" : "0"));
        }
        finally
        {
          printmanagerClient?.Close();
        }
        if (!text.StartsWith("Error"))
          return;
        Utils.LogErrorToBWLog(text);
      }
      catch (Exception ex)
      {
        Utils.LogErrorToBWLog(ex.ToString());
      }
    }

    public static string SendPmReadOut(string fileName)
    {
      ReadOutDataSet dataset = new ReadOutDataSet();
      if (!File.Exists(fileName))
        return ml.ml_string(1351, "Error: File does not exists ") + fileName;
      int num = (int) dataset.ReadXml(fileName);
      FileInfo fileInfo = new FileInfo(fileName);
      DateTime result;
      if (fileInfo.Name.Length < 15 || !DateTime.TryParseExact(fileInfo.Name.Substring(0, 15), "yyyy-MM-dd HHmm", (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
        result = fileInfo.LastWriteTime;
      return BriconWebHelper.SendPmReadOut(dataset, fileInfo.Name, fileInfo.LastWriteTime, result);
    }

    private static string SendPmReadOut(
      ReadOutDataSet dataset,
      string fileName,
      DateTime fileTime,
      DateTime readOutTime)
    {
      try
      {
        Stopwatch.StartNew();
        StringBuilder stringBuilder = new StringBuilder();
        string text = "";
        PrintmanagerClient printmanagerClient = (PrintmanagerClient) null;
        try
        {
          printmanagerClient = new PrintmanagerClient();
          using (StringWriter stringWriter = new StringWriter())
          {
            dataset.WriteXml((TextWriter) stringWriter);
            string data = stringWriter.GetStringBuilder().ToString();
            text = printmanagerClient.SendPmReadOut(BriconWebHelper.BuildHeader(Settings.Default.LoginBriconWeb), data, fileName, fileTime, readOutTime);
          }
        }
        finally
        {
          printmanagerClient?.Close();
        }
        if (text.StartsWith("Error"))
          Utils.LogErrorToBWLog(text);
        return text;
      }
      catch (Exception ex)
      {
        Utils.LogErrorToBWLog(ex.ToString());
        return ex.Message;
      }
    }
  }
}
