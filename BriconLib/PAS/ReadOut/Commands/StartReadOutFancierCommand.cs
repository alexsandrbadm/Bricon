// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.ReadOut.Commands.StartReadOutFancierCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using BriconLib.PAS.Shared.Commands;
using System;

namespace BriconLib.PAS.ReadOut.Commands
{
  public class StartReadOutFancierCommand : Command
  {
    public string Club { get; set; }

    public string Race { get; set; }

    public DateTime ReadOutInternalDateTime { get; set; }

    public DateTime ReadOutExternalDateTime { get; set; }

    public StartReadOutFancierCommand(byte[] bytes)
      : base(bytes)
    {
      int commonFields = this.ParseCommonFields();
      this.Race = Conversion.ByteArrayToString(this.DataBytes, commonFields, 4);
      int start1 = commonFields + 4;
      this.Club = Conversion.ByteArrayToString(this.DataBytes, start1, 4);
      int start2 = start1 + 4;
      string date1 = Conversion.ByteArrayToString(this.DataBytes, start2, 6);
      int start3 = start2 + 6;
      string time1 = Conversion.ByteArrayToString(this.DataBytes, start3, 6);
      int start4 = start3 + 6;
      this.ReadOutExternalDateTime = Conversion.DateTimeFromStrings(date1, time1);
      string date2 = Conversion.ByteArrayToString(this.DataBytes, start4, 6);
      int start5 = start4 + 6;
      string time2 = Conversion.ByteArrayToString(this.DataBytes, start5, 6);
      int num = start5 + 6;
      this.ReadOutInternalDateTime = Conversion.DateTimeFromStrings(date2, time2);
    }

    public override string ToString() => string.Format("{0} - {1} - {2} - {3} - {4} - {5} - I:{6} - E:{7}", (object) this.CMD, (object) this.MasterTime, (object) this.FancierName, (object) this.FancierLicense, (object) this.Race, (object) this.Club, (object) this.ReadOutInternalDateTime, (object) this.ReadOutExternalDateTime);
  }
}
