// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Shared.Commands.Command
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using System;

namespace BriconLib.PAS.Shared.Commands
{
  public class Command
  {
    public Command.CommandType CMD { get; private set; }

    public byte[] DataBytes { get; private set; }

    public DateTime MasterTime { get; set; }

    public string FancierLicense { get; set; }

    public string FancierName { get; set; }

    public Command(byte[] bytes)
    {
      int num1 = 2;
      byte[] numArray1 = bytes;
      int index1 = num1;
      int num2 = index1 + 1;
      this.CMD = (Command.CommandType) numArray1[index1];
      byte[] numArray2 = bytes;
      int index2 = num2;
      int num3 = index2 + 1;
      this.DataBytes = new byte[(int) numArray2[index2]];
      byte[] numArray3 = bytes;
      int sourceIndex = num3;
      int num4 = sourceIndex + 1;
      byte[] dataBytes = this.DataBytes;
      int length = this.DataBytes.Length;
      Array.Copy((Array) numArray3, sourceIndex, (Array) dataBytes, 0, length);
    }

    protected int ParseCommonFields()
    {
      int start1 = 0;
      string date = Conversion.ByteArrayToString(this.DataBytes, start1, 6);
      int start2 = start1 + 6;
      string time = Conversion.ByteArrayToString(this.DataBytes, start2, 6);
      int start3 = start2 + 6;
      this.MasterTime = Conversion.DateTimeFromStrings(date, time);
      this.FancierLicense = Conversion.ByteArrayToString(this.DataBytes, start3, 8);
      int start4 = start3 + 8;
      this.FancierName = Conversion.ByteArrayToString(this.DataBytes, start4, 20);
      return start4 + 20;
    }

    public enum CommandType
    {
      GetFlight,
      StartBasketFancier,
      BasketPigeon,
      FinishBasketFancier,
      EmergencyLink,
      CancelPigeon,
      StartReadOut,
      ReadOutPigeon,
      StartReadOutFancier,
      FinishReadOutFancier,
    }
  }
}
