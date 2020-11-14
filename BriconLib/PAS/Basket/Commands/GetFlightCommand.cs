// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.Commands.GetFlightCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using BriconLib.PAS.Shared.Commands;

namespace BriconLib.PAS.Basket.Commands
{
  public class GetFlightCommand : Command
  {
    public string MasterSerial { get; set; }

    public string MasterVersion { get; set; }

    public GetFlightCommand(byte[] bytes)
      : base(bytes)
    {
      int commonFields = this.ParseCommonFields();
      this.MasterSerial = "M-" + Conversion.ByteArrayToString(this.DataBytes, commonFields, 5);
      int num1 = commonFields + 5;
      byte[] dataBytes1 = this.DataBytes;
      int index1 = num1;
      int num2 = index1 + 1;
      byte num3 = dataBytes1[index1];
      byte[] dataBytes2 = this.DataBytes;
      int index2 = num2;
      int num4 = index2 + 1;
      byte num5 = dataBytes2[index2];
      if (num4 + 2 > this.DataBytes.Length)
        return;
      this.MasterVersion = string.Format("V-{0}.{1}", (object) num3, (object) num5);
    }

    public override string ToString() => string.Format("{0} - {1} - {2} - {3} - {4} -  {5}", (object) this.CMD, (object) this.MasterSerial, (object) this.MasterTime, (object) this.FancierName, (object) this.FancierLicense, (object) HexEncoding.ToString(this.DataBytes));
  }
}
