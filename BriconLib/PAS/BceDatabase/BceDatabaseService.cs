// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.BceDatabase.BceDatabaseService
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.Shared;
using BriconLib.Properties;
using System;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace BriconLib.PAS.BceDatabase
{
  public class BceDatabaseService
  {
    private static string DecompressString(string compressedText)
    {
      byte[] buffer = Convert.FromBase64String(compressedText);
      using (MemoryStream memoryStream = new MemoryStream())
      {
        int int32 = BitConverter.ToInt32(buffer, 0);
        memoryStream.Write(buffer, 4, buffer.Length - 4);
        byte[] numArray = new byte[int32];
        memoryStream.Position = 0L;
        using (GZipStream gzipStream = new GZipStream((Stream) memoryStream, CompressionMode.Decompress))
          gzipStream.Read(numArray, 0, numArray.Length);
        return Encoding.UTF8.GetString(numArray);
      }
    }

    private static string CompressString(string text)
    {
      if (text == null)
        return (string) null;
      byte[] bytes = Encoding.UTF8.GetBytes(text);
      MemoryStream memoryStream = new MemoryStream();
      using (GZipStream gzipStream = new GZipStream((Stream) memoryStream, CompressionMode.Compress, true))
        gzipStream.Write(bytes, 0, bytes.Length);
      memoryStream.Position = 0L;
      byte[] buffer = new byte[memoryStream.Length];
      memoryStream.Read(buffer, 0, buffer.Length);
      byte[] inArray = new byte[buffer.Length + 4];
      Buffer.BlockCopy((Array) buffer, 0, (Array) inArray, 4, buffer.Length);
      Buffer.BlockCopy((Array) BitConverter.GetBytes(bytes.Length), 0, (Array) inArray, 0, 4);
      return Convert.ToBase64String(inArray);
    }

    public static string UploadOrDownloadXml(bool compress, string xmlString = null)
    {
      try
      {
        string address = PasRestApiHelper.GetHostName() + "/BceDatabase/UploadChangedData";
        using (PasRestApiHelper.MyWebClient myWebClient = new PasRestApiHelper.MyWebClient())
        {
          string compressedText = Encoding.UTF8.GetString(myWebClient.UploadValues(address, "POST", new NameValueCollection()
          {
            ["countryId"] = Settings.Default.Country,
            ["userName"] = Settings.Default.PASUserName,
            ["password"] = Settings.Default.PASPassword,
            ["xmlData"] = !compress ? xmlString : BceDatabaseService.CompressString(xmlString),
            [nameof (compress)] = compress.ToString()
          }));
          if (!string.IsNullOrWhiteSpace(compressedText) & compress)
            compressedText = BceDatabaseService.DecompressString(compressedText);
          return compressedText;
        }
      }
      catch (Exception ex)
      {
        throw;
      }
    }
  }
}
