// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Shared.PasRestApiHelper
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using MultiLang;
using Newtonsoft.Json;
using System;
using System.Net;

namespace BriconLib.PAS.Shared
{
  public class PasRestApiHelper
  {
    public static string GetHostName(bool doLocalForDebug = false) => "https://www.pas-live.nl/pasadmin";

    public static ApiResponseModel Post(string route, object model)
    {
      try
      {
        string address = PasRestApiHelper.GetHostName() + route;
        string data = JsonConvert.SerializeObject(model);
        using (PasRestApiHelper.MyWebClient myWebClient = new PasRestApiHelper.MyWebClient())
        {
          myWebClient.Headers.Add("Content-Type: application/json");
          return JsonConvert.DeserializeObject<ApiResponseModel>(myWebClient.UploadString(address, "POST", data));
        }
      }
      catch (Exception ex)
      {
        return new ApiResponseModel()
        {
          ShortErrorMessage = ml.ml_string(1374, "Error in BCE"),
          Success = false,
          LogMessages = {
            new ApiResponseModel.LogMessage()
            {
              LogType = ApiResponseModel.LogType.FatalError,
              Message = ex.Message
            },
            new ApiResponseModel.LogMessage()
            {
              LogType = ApiResponseModel.LogType.Debug,
              Message = ex.ToString()
            }
          }
        };
      }
    }

    public static T Get<T>(string route) where T : ApiResponseModel, new()
    {
      try
      {
        string address = PasRestApiHelper.GetHostName() + route;
        using (PasRestApiHelper.MyWebClient myWebClient = new PasRestApiHelper.MyWebClient())
          return JsonConvert.DeserializeObject<T>(myWebClient.DownloadString(address));
      }
      catch (Exception ex)
      {
        T obj = new T();
        obj.ShortErrorMessage = ml.ml_string(1374, "Error in BCE");
        obj.Success = false;
        obj.LogMessages.Add(new ApiResponseModel.LogMessage()
        {
          LogType = ApiResponseModel.LogType.FatalError,
          Message = ex.Message
        });
        obj.LogMessages.Add(new ApiResponseModel.LogMessage()
        {
          LogType = ApiResponseModel.LogType.Debug,
          Message = ex.ToString()
        });
        return obj;
      }
    }

    public class MyWebClient : WebClient
    {
      protected override WebRequest GetWebRequest(Uri uri)
      {
        WebRequest webRequest = base.GetWebRequest(uri);
        webRequest.Timeout = 600000;
        return webRequest;
      }
    }
  }
}
