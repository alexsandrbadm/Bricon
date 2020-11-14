// Decompiled with JetBrains decompiler
// Type: BriconLib.KBDB.SendBceDataToKbdb
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace BriconLib.KBDB
{
  public class SendBceDataToKbdb
  {
    public static void Send(string clubId)
    {
      string address = "https://www.kbdb-online.be/Admin/Import_koppellijsten.php?clubid=" + clubId;
      using (WebClient webClient = new WebClient())
      {
        XmlWriterSettings settings = new XmlWriterSettings()
        {
          Encoding = Encoding.UTF8
        };
        MemoryStream memoryStream = new MemoryStream();
        using (XmlWriter writer = XmlWriter.Create((Stream) memoryStream, settings))
          BCEDatabase.DataSet.WriteXml(writer);
        webClient.UploadData(address, memoryStream.ToArray());
      }
    }
  }
}
