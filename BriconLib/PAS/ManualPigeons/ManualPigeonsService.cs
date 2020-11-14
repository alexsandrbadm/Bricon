// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.ManualPigeons.ManualPigeonsService
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.Shared;
using Newtonsoft.Json;
using PAS.Admin.Bce.ManualPigeons;
using System;

namespace BriconLib.PAS.ManualPigeons
{
  public class ManualPigeonsService
  {
    public static string Upload(ManualPigeonsRequest request)
    {
      try
      {
        string address = PasRestApiHelper.GetHostName() + "/ManualPigeons/Upload";
        using (PasRestApiHelper.MyWebClient myWebClient = new PasRestApiHelper.MyWebClient())
        {
          myWebClient.Headers.Add("Content-Type: application/json");
          string data = JsonConvert.SerializeObject((object) request);
          ManualPigeonsResponse manualPigeonsResponse = JsonConvert.DeserializeObject<ManualPigeonsResponse>(myWebClient.UploadString(address, "POST", data));
          return manualPigeonsResponse.Success ? string.Format("Success: {0} added, {1} removed", (object) manualPigeonsResponse.Added, (object) manualPigeonsResponse.Removed) : "Error : " + manualPigeonsResponse.Error;
        }
      }
      catch (Exception ex)
      {
        return "Error: " + ex.Message;
      }
    }
  }
}
