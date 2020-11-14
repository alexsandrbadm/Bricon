// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.PAS.GetBasketService
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.Shared;
using PAS.Bce.Basket;

namespace BriconLib.PAS.Basket.PAS
{
  public class GetBasketService
  {
    public static GetBasketModel Get(GetBasketParameters parameters) => PasRestApiHelper.Get<GetBasketModel>("/api/bce/basket?CountryId=" + parameters.CountryId + "&ClubCode=" + parameters.ClubCode + "&FancierLicense=" + parameters.FancierLicense + "&RaceCode=" + parameters.RaceCode);
  }
}
