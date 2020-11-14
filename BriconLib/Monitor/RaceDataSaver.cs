// Decompiled with JetBrains decompiler
// Type: BriconLib.Monitor.RaceDataSaver
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace BriconLib.Monitor
{
  internal class RaceDataSaver
  {
    private static MonitorDataSet _dataSet;

    public static void FillInIfPossible(RaceCommand cmd)
    {
      if (cmd.RaceIsDeleted)
        return;
      if (RaceDataSaver._dataSet == null)
      {
        RaceDataSaver._dataSet = new MonitorDataSet();
        string str = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MonitorData.xml";
        if (File.Exists(str))
        {
          int num = (int) RaceDataSaver._dataSet.ReadXml(str);
        }
      }
      MonitorDataSet.RacesRow byRaceName = RaceDataSaver._dataSet.Races.FindByRaceName(cmd.RaceNameShort);
      if (byRaceName == null)
        return;
      cmd.Show = byRaceName.Show;
      cmd.ReleaseDate = byRaceName.ReleaseDateTime.Date;
      cmd.ReleaseTime = new DateTime(2000, 1, 1, 0, 0, 0) + byRaceName.ReleaseDateTime.TimeOfDay;
      cmd.DistanceInMeter = byRaceName.Distance;
      if (!byRaceName.IsEmailNull())
        cmd.Email = byRaceName.Email;
      if (!byRaceName.IsEmail2Null())
        cmd.Email2 = byRaceName.Email2;
      if (!byRaceName.IsPigeonCloudNull())
        cmd.PigeonCloud = byRaceName.PigeonCloud;
      if (!byRaceName.IsPlaySoundNull())
        cmd.PlaySound = byRaceName.PlaySound;
      else
        cmd.PlaySound = true;
    }

    public static void FillInIfPossible(PigeonCommand cmd)
    {
      if (RaceDataSaver._dataSet == null)
      {
        RaceDataSaver._dataSet = new MonitorDataSet();
        string str = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MonitorData.xml";
        if (File.Exists(str))
        {
          int num = (int) RaceDataSaver._dataSet.ReadXml(str);
        }
      }
      MonitorDataSet.GummiesRow byDbRingTime = RaceDataSaver._dataSet.Gummies.FindByDBRingTime(cmd.DBRing, cmd.Time2);
      cmd.SendedToExtenalParties = false;
      if (cmd.Time2 < DateTime.Now - TimeSpan.FromMinutes(15.0))
        cmd.SendedToExtenalParties = true;
      cmd.SendedToPigeonCloud = false;
      if (cmd.Time2 < DateTime.Now - TimeSpan.FromMinutes(15.0))
        cmd.SendedToPigeonCloud = true;
      cmd.SendedToCompuClub = false;
      if (cmd.Time2 < DateTime.Now - TimeSpan.FromMinutes(15.0))
        cmd.SendedToCompuClub = true;
      if (byDbRingTime == null)
        return;
      if (!byDbRingTime.IsSendedToExtenalPartiesNull() && byDbRingTime.SendedToExtenalParties)
        cmd.SendedToExtenalParties = true;
      if (!byDbRingTime.IsSendedToPigeonCloudNull() && byDbRingTime.SendedToPigeonCloud)
        cmd.SendedToPigeonCloud = true;
      if (!byDbRingTime.IsSendedToCompuClubNull() && byDbRingTime.SendedToCompuClub)
        cmd.SendedToCompuClub = true;
      if (!byDbRingTime.IsGummyNull())
        cmd.Gummy = byDbRingTime.Gummy;
      if (byDbRingTime.IsWingmarkNull())
        return;
      cmd.Wingmark = byDbRingTime.Wingmark;
    }

    public static void SetSendedToExternalParties(PigeonCommand cmd)
    {
      cmd.SendedToExtenalParties = true;
      MonitorDataSet.GummiesRow byDbRingTime = RaceDataSaver._dataSet.Gummies.FindByDBRingTime(cmd.DBRing, cmd.Time2);
      if (byDbRingTime == null)
      {
        MonitorDataSet.GummiesRow row = RaceDataSaver._dataSet.Gummies.NewGummiesRow();
        row.DBRing = cmd.DBRing;
        row.Time = cmd.Time2;
        row.SendedToExtenalParties = true;
        RaceDataSaver._dataSet.Gummies.AddGummiesRow(row);
      }
      else
      {
        byDbRingTime.SendedToExtenalParties = true;
        byDbRingTime.EndEdit();
      }
    }

    public static void SetSendedToPigeonCloud(PigeonCommand cmd)
    {
      cmd.SendedToPigeonCloud = true;
      MonitorDataSet.GummiesRow byDbRingTime = RaceDataSaver._dataSet.Gummies.FindByDBRingTime(cmd.DBRing, cmd.Time2);
      if (byDbRingTime == null)
      {
        MonitorDataSet.GummiesRow row = RaceDataSaver._dataSet.Gummies.NewGummiesRow();
        row.DBRing = cmd.DBRing;
        row.Time = cmd.Time2;
        row.SendedToPigeonCloud = true;
        RaceDataSaver._dataSet.Gummies.AddGummiesRow(row);
      }
      else
      {
        byDbRingTime.SendedToPigeonCloud = true;
        byDbRingTime.EndEdit();
      }
    }

    public static void SetSendedToCompuClub(PigeonCommand cmd)
    {
      cmd.SendedToCompuClub = true;
      MonitorDataSet.GummiesRow byDbRingTime = RaceDataSaver._dataSet.Gummies.FindByDBRingTime(cmd.DBRing, cmd.Time2);
      if (byDbRingTime == null)
      {
        MonitorDataSet.GummiesRow row = RaceDataSaver._dataSet.Gummies.NewGummiesRow();
        row.DBRing = cmd.DBRing;
        row.Time = cmd.Time2;
        row.SendedToCompuClub = true;
        RaceDataSaver._dataSet.Gummies.AddGummiesRow(row);
      }
      else
      {
        byDbRingTime.SendedToCompuClub = true;
        byDbRingTime.EndEdit();
      }
    }

    public static void AddGummyAndWingmark(PigeonCommand cmd)
    {
      MonitorDataSet.GummiesRow byDbRingTime = RaceDataSaver._dataSet.Gummies.FindByDBRingTime(cmd.DBRing, cmd.Time2);
      if (byDbRingTime == null)
      {
        MonitorDataSet.GummiesRow row = RaceDataSaver._dataSet.Gummies.NewGummiesRow();
        row.DBRing = cmd.DBRing;
        row.Time = cmd.Time2;
        row.Gummy = cmd.Gummy;
        row.Wingmark = cmd.Wingmark;
        RaceDataSaver._dataSet.Gummies.AddGummiesRow(row);
      }
      else
      {
        byDbRingTime.Gummy = cmd.Gummy;
        byDbRingTime.Wingmark = cmd.Wingmark;
        byDbRingTime.EndEdit();
      }
    }

    public static void Save(List<RaceCommand> cmds, List<PigeonCommand> pigeons)
    {
      if (cmds == null)
        return;
      foreach (PigeonCommand pigeon in pigeons)
      {
        if (!string.IsNullOrEmpty(pigeon.Gummy))
        {
          MonitorDataSet.GummiesRow byDbRingTime = RaceDataSaver._dataSet.Gummies.FindByDBRingTime(pigeon.DBRing, pigeon.Time2);
          if (byDbRingTime == null)
          {
            MonitorDataSet.GummiesRow row = RaceDataSaver._dataSet.Gummies.NewGummiesRow();
            row.DBRing = pigeon.DBRing;
            row.Time = pigeon.Time2;
            row.Gummy = pigeon.Gummy;
            row.Wingmark = pigeon.Wingmark;
            RaceDataSaver._dataSet.Gummies.AddGummiesRow(row);
          }
          else
          {
            byDbRingTime.Gummy = pigeon.Gummy;
            byDbRingTime.EndEdit();
          }
        }
      }
      foreach (RaceCommand cmd in cmds)
      {
        if (!cmd.RaceIsDeleted)
        {
          MonitorDataSet.RacesRow row = RaceDataSaver._dataSet.Races.FindByRaceName(cmd.RaceNameShort);
          int num = row == null ? 1 : 0;
          if (num != 0)
            row = RaceDataSaver._dataSet.Races.NewRacesRow();
          row.Show = cmd.Show;
          row.RaceName = cmd.RaceNameShort;
          row.ReleaseDateTime = cmd.ReleaseDate.Date + cmd.ReleaseTime.TimeOfDay;
          row.Distance = cmd.DistanceInMeter;
          row.Email = cmd.Email;
          row.Email2 = cmd.Email2;
          row.PlaySound = cmd.PlaySound;
          row.PigeonCloud = cmd.PigeonCloud;
          if (num != 0)
            RaceDataSaver._dataSet.Races.AddRacesRow(row);
          else
            row.EndEdit();
        }
      }
      string fileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MonitorData.xml";
      RaceDataSaver._dataSet.WriteXml(fileName);
    }
  }
}
