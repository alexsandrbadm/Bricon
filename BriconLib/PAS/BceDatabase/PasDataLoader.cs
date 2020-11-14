// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.BceDatabase.PasDataLoader
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using BriconLib.Properties;
using MultiLang;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Windows;

namespace BriconLib.PAS.BceDatabase
{
  public class PasDataLoader
  {
    public bool Load(bool showFeedback)
    {
      try
      {
        this.LoadDataSetFromXmlString(BceDatabaseService.UploadOrDownloadXml(true));
        if (showFeedback)
        {
          int num = (int) MessageBox.Show(ml.ml_string(1382, "Data received from PAS-Live"));
        }
        Settings.Default.PASOk = true;
        Settings.Default.Save();
        return true;
      }
      catch (WebException ex)
      {
        if (ex.Response != null)
        {
          using (ex.Response.GetResponseStream())
          {
            int num = (int) MessageBox.Show(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
          }
        }
        else
        {
          int num1 = (int) MessageBox.Show(ex.Message);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
      return false;
    }

    private void LoadDataSetFromXmlString(string xmlData)
    {
      using (StringReader stringReader = new StringReader(xmlData))
      {
        BCEDataSet bceDataSet = new BCEDataSet();
        int num = (int) bceDataSet.ReadXml((TextReader) stringReader);
        BCEDatabase.DataSet.Pigeons.Clear();
        BCEDatabase.DataSet.Adressen.Clear();
        BCEDatabase.DataSet.Clubs.Clear();
        if (bceDataSet.Clubs.Count == 0)
          bceDataSet.Clubs.AddClubsRow("9999", ml.ml_string(282, "Default"), "999999", "", "", "", "", "", "", "", "", "", "");
        foreach (DataRow club in (TypedTableBase<BCEDataSet.ClubsRow>) bceDataSet.Clubs)
          BCEDatabase.DataSet.Clubs.ImportRow(club);
        foreach (DataRow row in (TypedTableBase<BCEDataSet.AdressenRow>) bceDataSet.Adressen)
          BCEDatabase.DataSet.Adressen.ImportRow(row);
        foreach (DataRow pigeon in (TypedTableBase<BCEDataSet.PigeonsRow>) bceDataSet.Pigeons)
          BCEDatabase.DataSet.Pigeons.ImportRow(pigeon);
      }
    }
  }
}
