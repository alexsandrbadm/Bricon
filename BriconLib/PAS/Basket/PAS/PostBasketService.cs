// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.PAS.PostBasketService
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.Shared;

namespace BriconLib.PAS.Basket.PAS
{
  public class PostBasketService
  {
    public static ApiResponseModel Save(PostBasketModel model) => PasRestApiHelper.Post("/api/bce/basket", (object) model);
  }
}
