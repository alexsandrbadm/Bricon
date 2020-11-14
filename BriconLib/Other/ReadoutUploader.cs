// Decompiled with JetBrains decompiler
// Type: BriconLib.Other.ReadoutUploader
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Communications;
using BriconLib.PrintManager;
using MultiLang;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace BriconLib.Other
{
  public class ReadoutUploader
  {
    private readonly string _raceId;
    private readonly string _license;
    private readonly string _clubId;

    public ReadoutUploader(string raceId, string license, string clubId)
    {
      this._raceId = raceId;
      this._license = license;
      this._clubId = clubId;
    }

    public void DoIt()
    {
      if (MessageBox.Show(string.Format(ml.ml_string(1319, "Do you want to readout {0} and send your data to the server? Then press OK button below and disconnect the power to the Xtreme and reconnect it. If not press Cancel"), (object) this._raceId), ml.ml_string(1317, "Upload readout"), MessageBoxButtons.OKCancel) == DialogResult.Cancel)
        return;
      ReadOutDataSet dataSet = new FancierReadOut().ReadOut(false, raceId: this._raceId, clubId: this._clubId);
      if (dataSet == null)
      {
        int num = (int) MessageBox.Show(ml.ml_string(1318, "Readout cancelled"));
      }
      else
      {
        this.UploadXml(this.GetReadoutAsString(dataSet));
        CommunicationPool.Instance.Stop();
      }
    }

    private string GetReadoutAsString(ReadOutDataSet dataSet)
    {
      using (StringWriter stringWriter = new StringWriter())
      {
        dataSet.WriteXml((TextWriter) stringWriter);
        return stringWriter.ToString();
      }
    }

    private void UploadXml(string xmlString)
    {
      try
      {
        string address = "http://www.briconweb.com:9001/api/UploadReadout";
        if (Utils.IsBeta())
          address = "http://briconweb.adgsoft.be:9001/api/UploadReadout";
        using (WebClient webClient = new WebClient())
        {
          byte[] bytes = webClient.UploadValues(address, "POST", new NameValueCollection()
          {
            ["body"] = xmlString,
            ["license"] = this._license,
            ["race"] = this._raceId
          });
          int num = (int) MessageBox.Show(string.Format(ml.ml_string(1321, "Response: {0}"), (object) Encoding.UTF8.GetString(bytes)));
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ml.ml_string(1320, "Error when sending to server: ") + ex.ToString());
      }
    }
  }
}
