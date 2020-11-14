// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Shared.ApiResponseModel
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System.Collections.Generic;

namespace BriconLib.PAS.Shared
{
  public class ApiResponseModel
  {
    public bool Success { get; set; }

    public List<ApiResponseModel.LogMessage> LogMessages { get; set; } = new List<ApiResponseModel.LogMessage>();

    public string ShortErrorMessage { get; set; }

    public enum LogType
    {
      Info,
      Warning,
      Error,
      FatalError,
      Debug,
    }

    public class LogMessage
    {
      public ApiResponseModel.LogType LogType { get; set; }

      public string Message { get; set; }
    }
  }
}
