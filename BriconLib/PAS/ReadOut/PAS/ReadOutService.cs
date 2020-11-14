// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.ReadOut.PAS.ReadOutService
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.Shared;

namespace BriconLib.PAS.ReadOut.PAS
{
  public class ReadOutService
  {
    public static ApiResponseModel Save(PostReadOutModel model) => PasRestApiHelper.Post("/api/bce/readout", (object) model);
  }
}
