// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.ReadOut.Commands.ReadOutPigeonCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using BriconLib.PAS.Shared.Commands;
using System;

namespace BriconLib.PAS.ReadOut.Commands
{
  public class ReadOutPigeonCommand : Command
  {
    public int Nbr { get; set; }

    public string Ring { get; set; }

    public DateTime ReadOutDateTime { get; set; }

    public int Designated { get; set; }

    public string Chip { get; set; }

    public string Status { get; set; }

    public ReadOutPigeonCommand(byte[] bytes)
      : base(bytes)
    {
      int commonFields = this.ParseCommonFields();
      this.Chip = Conversion.ByteArrayToString(this.DataBytes, commonFields, 8);
      int start1 = commonFields + 8;
      string date = Conversion.ByteArrayToString(this.DataBytes, start1, 6);
      int start2 = start1 + 6;
      string time = Conversion.ByteArrayToString(this.DataBytes, start2, 6);
      int num1 = start2 + 6;
      this.ReadOutDateTime = Conversion.DateTimeFromStrings(date, time);
      byte[] dataBytes1 = this.DataBytes;
      int index1 = num1;
      int num2 = index1 + 1;
      int num3 = (int) dataBytes1[index1] << 8;
      byte[] dataBytes2 = this.DataBytes;
      int index2 = num2;
      int num4 = index2 + 1;
      int num5 = (int) dataBytes2[index2];
      this.Designated = num3 + num5;
      byte[] dataBytes3 = this.DataBytes;
      int index3 = num4;
      int num6 = index3 + 1;
      int num7 = (int) dataBytes3[index3] << 8;
      byte[] dataBytes4 = this.DataBytes;
      int index4 = num6;
      int start3 = index4 + 1;
      int num8 = (int) dataBytes4[index4];
      this.Nbr = num7 + num8;
      this.Ring = Conversion.ByteArrayToString(this.DataBytes, start3, 18);
      int start4 = start3 + 18;
      this.Status = Conversion.ByteArrayToString(this.DataBytes, start4, 1);
      int num9 = start4 + 1;
    }

    public override string ToString() => string.Format("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8} -  {9}", (object) this.CMD, (object) this.Ring, (object) this.Chip, (object) this.Designated, (object) this.Nbr, (object) this.Status, (object) this.ReadOutDateTime, (object) this.FancierName, (object) this.FancierLicense, (object) HexEncoding.ToString(this.DataBytes));
  }
}
