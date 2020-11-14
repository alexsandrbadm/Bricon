// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.Commands.FinishBasketFancierCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using BriconLib.PAS.Shared.Commands;
using CoreLib.Helpers;
using System;

namespace BriconLib.PAS.Basket.Commands
{
  public class FinishBasketFancierCommand : Command
  {
    public DateTime BasketInternalDateTime;
    public DateTime BasketExternalDateTime;
    public string XtremeSerial;

    public bool FancierAgreed { get; set; }

    public FinishBasketFancierCommand(byte[] bytes)
      : base(bytes)
    {
      int commonFields = this.ParseCommonFields();
      byte[] dataBytes = this.DataBytes;
      int index = commonFields;
      int start1 = index + 1;
      this.FancierAgreed = dataBytes[index] == (byte) 1;
      if (this.DataBytes.Length > 45)
      {
        string date1 = Conversion.ByteArrayToString(this.DataBytes, start1, 6);
        int start2 = start1 + 6;
        string time1 = Conversion.ByteArrayToString(this.DataBytes, start2, 6);
        int start3 = start2 + 6;
        this.BasketExternalDateTime = Conversion.DateTimeFromStrings(date1, time1);
        string date2 = Conversion.ByteArrayToString(this.DataBytes, start3, 6);
        int start4 = start3 + 6;
        string time2 = Conversion.ByteArrayToString(this.DataBytes, start4, 6);
        int start5 = start4 + 6;
        this.BasketInternalDateTime = Conversion.DateTimeFromStrings(date2, time2);
        this.XtremeSerial = Conversion.ByteArrayToString(this.DataBytes, start5, 20);
        int num = start5 + 20;
      }
      else
      {
        this.BasketExternalDateTime = NtpClient.GetNetworkTimeCached();
        this.BasketInternalDateTime = this.MasterTime;
        this.XtremeSerial = "PASBOX";
      }
    }

    public override string ToString() => string.Format("{0} - {1} - {2} - {3} - FancierAgreed:{4} - I:{5}, E:{6} - {7}- {8}", (object) this.CMD, (object) this.MasterTime, (object) this.FancierName, (object) this.FancierLicense, (object) this.FancierAgreed, (object) this.BasketInternalDateTime, (object) this.BasketExternalDateTime, (object) this.XtremeSerial, (object) HexEncoding.ToString(this.DataBytes));
  }
}
