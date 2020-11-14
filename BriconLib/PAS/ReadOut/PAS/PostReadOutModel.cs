// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.ReadOut.PAS.PostReadOutModel
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.Collections.Generic;

namespace BriconLib.PAS.ReadOut.PAS
{
  public class PostReadOutModel
  {
    public string CountryId { get; set; }

    public string FancierLicense { get; set; }

    public string RaceCode { get; set; }

    public string ClubCode { get; set; }

    public DateTime ReadOutInternalDateTime { get; set; }

    public DateTime ReadOutExternalDateTime { get; set; }

    public string MasterSerial { get; set; }

    public string MasterVersion { get; set; }

    public string XtremeSerial { get; set; }

    public bool ReadOutIsFinal { get; set; }

    public List<PostReadOutModel.Pigeon> ClockedPigeons { get; set; }

    public class Pigeon
    {
      public string Chip { get; set; }

      public string Ring { get; set; }

      public string Code { get; set; }

      public bool? Female { get; set; }

      public string Status { get; set; }

      public int Designated { get; set; }

      public DateTime ClockedTime { get; set; }
    }
  }
}
