// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.BceDatabase.PasDataSaver
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using MultiLang;
using System;
using System.IO;
using System.Net;
using System.Windows;

namespace BriconLib.PAS.BceDatabase
{
  public class PasDataSaver
  {
    public void Save(bool showFeedback)
    {
      try
      {
        string messageBoxText = BceDatabaseService.UploadOrDownloadXml(true, this.GetDataSetAsString(BCEDatabase.DataSet));
        if (messageBoxText != "")
        {
          int num1 = (int) MessageBox.Show(messageBoxText, ml.ml_string(1383, "Save to PAS-Live"));
        }
        else
        {
          if (!showFeedback)
            return;
          int num2 = (int) MessageBox.Show(ml.ml_string(1384, "No differences with PAS-Live"), ml.ml_string(1383, "Save to PAS-Live"));
        }
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
    }

    private string GetDataSetAsString(BCEDataSet dataSet)
    {
      using (StringWriter stringWriter = new StringWriter())
      {
        dataSet.WriteXml((TextWriter) stringWriter);
        return stringWriter.ToString();
      }
    }
  }
}
