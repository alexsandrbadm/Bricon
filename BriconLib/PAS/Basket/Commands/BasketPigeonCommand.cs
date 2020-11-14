// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.Commands.BasketPigeonCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using BriconLib.PAS.Shared.Commands;

namespace BriconLib.PAS.Basket.Commands
{
  public class BasketPigeonCommand : Command
  {
    public string Chip { get; set; }

    public string Code { get; set; }

    public bool OnlyCheck { get; set; }

    public BasketPigeonCommand(byte[] bytes)
      : base(bytes)
    {
      int commonFields = this.ParseCommonFields();
      this.Chip = Conversion.ByteArrayToString(this.DataBytes, commonFields, 8);
      int start = commonFields + 8;
      this.Code = Conversion.ByteArrayToString(this.DataBytes, start, 10);
      int num1 = start + 10;
      byte[] dataBytes = this.DataBytes;
      int index = num1;
      int num2 = index + 1;
      this.OnlyCheck = dataBytes[index] == (byte) 1;
    }

    public override string ToString() => string.Format("{0} - {1} - {2} - {3} - {4} - OnlyCheck:{5} - {6}", (object) this.CMD, (object) this.MasterTime, (object) this.FancierName, (object) this.FancierLicense, (object) this.Chip, (object) this.OnlyCheck, (object) HexEncoding.ToString(this.DataBytes));
  }
}
