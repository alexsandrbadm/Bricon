// Decompiled with JetBrains decompiler
// Type: PAS.Admin.Bce.ManualPigeons.ManualPigeonsRequest
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System.Collections.Generic;

namespace PAS.Admin.Bce.ManualPigeons
{
  public class ManualPigeonsRequest
  {
    public string CountryId { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string FancierLicense { get; set; }

    public List<ManualPigeonsRequest.Pigeon> Pigeons { get; set; } = new List<ManualPigeonsRequest.Pigeon>();

    public class Pigeon
    {
      public string Ring { get; set; }

      public string ChipCode { get; set; }
    }
  }
}
