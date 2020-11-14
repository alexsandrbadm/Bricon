// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.Commands.StartBasketFancierCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using BriconLib.PAS.Shared.Commands;

namespace BriconLib.PAS.Basket.Commands
{
  public class StartBasketFancierCommand : Command
  {
    public string XtremeSerial;

    public string Club { get; set; }

    public string Race { get; set; }

    public StartBasketFancierCommand(byte[] bytes)
      : base(bytes)
    {
      int commonFields = this.ParseCommonFields();
      this.Race = Conversion.ByteArrayToString(this.DataBytes, commonFields, 4);
      int start1 = commonFields + 4;
      this.Club = Conversion.ByteArrayToString(this.DataBytes, start1, 4);
      int start2 = start1 + 4;
      this.XtremeSerial = Conversion.ByteArrayToString(this.DataBytes, start2, 20);
      int num = start2 + 20;
    }

    public override string ToString() => string.Format("{0} - {1} - {2} - {3} - {4} - {5} - {6}", (object) this.CMD, (object) this.MasterTime, (object) this.FancierName, (object) this.FancierLicense, (object) this.Race, (object) this.Club, (object) this.XtremeSerial);
  }
}
