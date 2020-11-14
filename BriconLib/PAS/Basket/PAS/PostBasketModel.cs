// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.PAS.PostBasketModel
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.Collections.Generic;

namespace BriconLib.PAS.Basket.PAS
{
  public class PostBasketModel
  {
    public string CountryId { get; set; }

    public string FancierLicense { get; set; }

    public string RaceCode { get; set; }

    public string ClubCode { get; set; }

    public DateTime BasketInternalDateTime { get; set; }

    public DateTime BasketExternalDateTime { get; set; }

    public DateTime BasketStartServerDateTime { get; set; }

    public DateTime BasketStopServerDateTime { get; set; }

    public string MasterSerial { get; set; }

    public string MasterVersion { get; set; }

    public string XtremeSerial { get; set; }

    public bool FancierAgreed { get; set; }

    public List<PostBasketModel.Pigeon> BaskettedPigeons { get; set; }

    public class Pigeon
    {
      public string Chip { get; set; }

      public string Ring { get; set; }

      public string Code { get; set; }

      public bool? Female { get; set; }

      public int? Designated { get; set; }

      public string Basket { get; set; }

      public DateTime? BasketDateTime { get; set; }

      public DateTime? CancelDateTime { get; set; }
    }
  }
}
