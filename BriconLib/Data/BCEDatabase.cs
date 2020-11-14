// Decompiled with JetBrains decompiler
// Type: BriconLib.Data.BCEDatabase
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.BceDatabase;
using BriconLib.Properties;
using MultiLang;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;

namespace BriconLib.Data
{
  public static class BCEDatabase
  {
    public const string BCEDataFileName = "BCEData.bce";
    private static string _previousRing = string.Empty;
    private static BCEDataSet _dataSet;

    public static BCEDataSet DataSet
    {
      get
      {
        if (BCEDatabase._dataSet == null)
        {
          BCEDatabase._dataSet = new BCEDataSet();
          BCEDatabase._dataSet.Pigeons.RowChanging += new DataRowChangeEventHandler(BCEDatabase.Pigeons_RowChanging);
          BCEDatabase._dataSet.Pigeons.RowChanged += new DataRowChangeEventHandler(BCEDatabase.Pigeons_RowChanged);
          BCEDatabase.FillTables();
        }
        return BCEDatabase._dataSet;
      }
    }

    private static void Pigeons_RowChanged(object sender, DataRowChangeEventArgs e)
    {
    }

    private static void Pigeons_RowChanging(object sender, DataRowChangeEventArgs e)
    {
      if (!(e.Row is BCEDataSet.PigeonsRow row) || e.Action != DataRowAction.Change && e.Action != DataRowAction.Add)
        return;
      BCEDataSet.PigeonsRow pigeonsRow1 = (BCEDataSet.PigeonsRow) null;
      foreach (BCEDataSet.PigeonsRow pigeonsRow2 in BCEDatabase.DataSet.Pigeons.Select("FANCIERID=" + row.FancierID.ToString(), "DBRing"))
      {
        if (pigeonsRow2 != row)
          pigeonsRow1 = pigeonsRow2;
        else
          break;
      }
      BCEDatabase._previousRing = pigeonsRow1 == null ? string.Empty : pigeonsRow1.DBRing;
    }

    public static void DeletePigeonsForFancier(int fancierID)
    {
      List<BCEDataSet.PigeonsRow> pigeonsRowList = new List<BCEDataSet.PigeonsRow>();
      foreach (BCEDataSet.PigeonsRow row in (InternalDataCollectionBase) BCEDatabase.DataSet.Pigeons.Rows)
      {
        if (row.RowState != DataRowState.Deleted && row.FancierID == fancierID)
          pigeonsRowList.Add(row);
      }
      for (int index = 0; index < pigeonsRowList.Count; ++index)
        pigeonsRowList[index].Delete();
    }

    public static void DeleteEmergencyRings(int fancierID)
    {
      List<BCEDataSet.PigeonsRow> pigeonsRowList = new List<BCEDataSet.PigeonsRow>();
      foreach (BCEDataSet.PigeonsRow row in (InternalDataCollectionBase) BCEDatabase.DataSet.Pigeons.Rows)
      {
        if (row.RowState != DataRowState.Deleted && row.FancierID == fancierID)
          pigeonsRowList.Add(row);
      }
      for (int index = 0; index < pigeonsRowList.Count; ++index)
        pigeonsRowList[index].Delete();
    }

    public static void FillTables()
    {
      if (File.Exists("BCEData.bce"))
      {
        BCEDatabase.DecryptFile("BCEData.bce", "BCEData.bce.tmp");
        int num = (int) BCEDatabase._dataSet.ReadXml("BCEData.bce.tmp");
        File.Delete("BCEData.bce.tmp");
      }
      else if (File.Exists(Path.ChangeExtension("BCEData.bce", ".xml")))
      {
        int num = (int) BCEDatabase._dataSet.ReadXml(Path.ChangeExtension("BCEData.bce", ".xml"));
        if (File.Exists(Path.ChangeExtension("BCEData.bce", ".OLDxml")))
          File.Delete(Path.ChangeExtension("BCEData.bce", ".OLDxml"));
        File.Move(Path.ChangeExtension("BCEData.bce", ".xml"), Path.ChangeExtension("BCEData.bce", ".OLDxml"));
      }
      else
        BCEDatabase.DataSet.Clubs.AddClubsRow("9999", ml.ml_string(282, "Default"), "999999", "", "", "", "", "", "", "", "", "", "");
      if (BCEDatabase.DataSet.Settings.Count == 0)
        BCEDatabase.DataSet.Settings.AddSettingsRow(false, false, false, false, false, false, false, false, 100M, false, false, false, false, false);
      if (BCEDatabase.DataSet.Settings[0].IsCalculationPrintLicenseNull())
        BCEDatabase.DataSet.Settings[0].CalculationPrintLicense = false;
      if (BCEDatabase.DataSet.Settings[0].IsCalculationPrintPoints100Null())
        BCEDatabase.DataSet.Settings[0].CalculationPrintPoints100 = false;
      if (BCEDatabase.DataSet.Settings[0].IsCalculationPrintOveralPointsNull())
        BCEDatabase.DataSet.Settings[0].CalculationPrintOveralPoints = false;
      if (!Settings.Default.PASAlwaysLoad)
        return;
      new PasDataLoader().Load(false);
    }

    public static void SaveFlights()
    {
    }

    public static bool IsSaving { get; private set; }

    public static void EncryptFile(string sInputFilename, string sOutputFilename)
    {
      using (Stream stream1 = (Stream) new FileStream(sInputFilename, FileMode.Open, FileAccess.Read))
      {
        using (FileStream fileStream = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write))
        {
          DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
          cryptoServiceProvider.Key = new byte[8]
          {
            (byte) 51,
            (byte) 42,
            (byte) 33,
            (byte) 24,
            (byte) 51,
            (byte) 42,
            (byte) 33,
            (byte) 24
          };
          cryptoServiceProvider.IV = new byte[8]
          {
            (byte) 51,
            (byte) 42,
            (byte) 33,
            (byte) 24,
            (byte) 51,
            (byte) 42,
            (byte) 33,
            (byte) 24
          };
          ICryptoTransform encryptor = cryptoServiceProvider.CreateEncryptor();
          using (CryptoStream cryptoStream = new CryptoStream((Stream) fileStream, encryptor, CryptoStreamMode.Write))
          {
            using (Stream stream2 = (Stream) new GZipStream((Stream) cryptoStream, CompressionMode.Compress))
            {
              byte[] buffer = new byte[stream1.Length];
              stream1.Read(buffer, 0, buffer.Length);
              stream2.Write(buffer, 0, buffer.Length);
            }
          }
        }
      }
    }

    public static void DecryptFile(string sInputFilename, string sOutputFilename)
    {
      DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
      cryptoServiceProvider.Key = new byte[8]
      {
        (byte) 51,
        (byte) 42,
        (byte) 33,
        (byte) 24,
        (byte) 51,
        (byte) 42,
        (byte) 33,
        (byte) 24
      };
      cryptoServiceProvider.IV = new byte[8]
      {
        (byte) 51,
        (byte) 42,
        (byte) 33,
        (byte) 24,
        (byte) 51,
        (byte) 42,
        (byte) 33,
        (byte) 24
      };
      using (CryptoStream cryptoStream = new CryptoStream((Stream) new FileStream(sInputFilename, FileMode.Open, FileAccess.Read), cryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Read))
      {
        using (StreamWriter streamWriter = new StreamWriter(sOutputFilename))
        {
          using (GZipStream gzipStream = new GZipStream((Stream) cryptoStream, CompressionMode.Decompress))
          {
            using (StreamReader streamReader = new StreamReader((Stream) gzipStream))
            {
              streamWriter.Write(streamReader.ReadToEnd());
              streamWriter.Flush();
            }
          }
        }
      }
    }

    public static void SaveToDisk(bool bReload)
    {
      try
      {
        BCEDatabase.IsSaving = true;
        BCEDatabase._dataSet.WriteXml("BCEDataNEW.xml");
        if (File.Exists("BCEData.bce") && (!File.Exists("BCEDataOLD.bce") || new FileInfo("BCEData.bce").Length >= new FileInfo("BCEDataOLD.bce").Length))
          File.Copy("BCEData.bce", "BCEDataOLD.bce", true);
        BCEDatabase.EncryptFile("BCEDataNEW.xml", "BCEData.bce");
        if (BriconLib.Other.Utils.IsCountry("RO") || BriconLib.Other.Utils.IsCountry("MD") || (BriconLib.Other.Utils.IsCountry("JP") || BriconLib.Other.Utils.IsCountry("HU")))
        {
          if (File.Exists("BCEData.xml"))
            File.Delete("BCEData.xml");
          File.Move("BCEDataNEW.xml", "BCEData.xml");
        }
        else
          File.Delete("BCEDataNEW.xml");
        if (!Settings.Default.PASAlwaysSave)
          return;
        new PasDataSaver().Save(false);
      }
      catch (Exception ex)
      {
        throw new Exception(ml.ml_string(105, "Update database failed!"), ex);
      }
      finally
      {
        BCEDatabase.IsSaving = false;
      }
    }

    public static void Reload()
    {
      BCEDatabase._dataSet.Pigeons.RowChanging -= new DataRowChangeEventHandler(BCEDatabase.Pigeons_RowChanging);
      BCEDatabase._dataSet.Pigeons.RowChanged -= new DataRowChangeEventHandler(BCEDatabase.Pigeons_RowChanged);
      BCEDatabase._dataSet = (BCEDataSet) null;
      BCEDataSet dataSet = BCEDatabase.DataSet;
    }
  }
}
