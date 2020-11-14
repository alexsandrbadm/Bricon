// Decompiled with JetBrains decompiler
// Type: PAS.Bce.Basket.GetBasketModel
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.Shared;
using PAS.ApplicationCore.Enums;
using System;
using System.Collections.Generic;

namespace PAS.Bce.Basket
{
  public class GetBasketModel : ApiResponseModel
  {
    public List<GetBasketModel.Pigeon> Pigeons { get; set; } = new List<GetBasketModel.Pigeon>();

    public class Pigeon
    {
      public string Chip { get; set; }

      public string Ring { get; set; }

      public bool? Female { get; set; }

      public int? Designated { get; set; }

      public Category Category { get; set; }

      public string Basket { get; set; }

      public DateTime? BasketDateTime { get; set; }

      public DateTime? CancelDateTime { get; set; }
    }
  }
}
