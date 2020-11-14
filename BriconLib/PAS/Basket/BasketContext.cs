// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.BasketContext
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.PAS.Basket
{
  public class BasketContext
  {
    public string MasterSerial { get; set; }

    public string MasterVersion { get; set; }

    public string XtremeSerial { get; set; }

    public bool FancierAgreed { get; set; }

    public string ClubCode { get; set; }

    public string ClubName { get; set; }

    public string FlightCode { get; set; }

    public string FlightName { get; set; }

    public string Date { get; set; }

    public string ActiveFancierLicense { get; set; }

    public string ActiveFancierName { get; set; }

    public int BasketCount { get; set; }

    public int MaxDesignated { get; set; }

    public DateTime? BasketInternalDateTime { get; set; }

    public DateTime? BasketExternalDateTime { get; set; }

    public DateTime? ReadOutInternalDateTime { get; set; }

    public DateTime? ReadOutExternalDateTime { get; set; }

    public DateTime? BasketStartServerDateTime { get; set; }

    public bool? ReadoutIsFinal { get; set; }

    public Action BasketContextChanged { get; set; }
  }
}
