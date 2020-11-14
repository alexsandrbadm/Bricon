// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.Commands.EmergencyLinkCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using BriconLib.PAS.Shared.Commands;

namespace BriconLib.PAS.Basket.Commands
{
  public class EmergencyLinkCommand : Command
  {
    public string Chip { get; set; }

    public string Ring { get; set; }

    public EmergencyLinkCommand(byte[] bytes)
      : base(bytes)
    {
      int commonFields = this.ParseCommonFields();
      this.Chip = Conversion.ByteArrayToString(this.DataBytes, commonFields, 8);
      int start = commonFields + 8;
      this.Ring = Conversion.ByteArrayToString(this.DataBytes, start, 20, true);
      int num = start + 20;
    }

    public override string ToString() => string.Format("{0} - {1} - {2} - {3} - {4} - {5}- {6}", (object) this.CMD, (object) this.MasterTime, (object) this.FancierName, (object) this.FancierLicense, (object) this.Chip, (object) this.Ring, (object) HexEncoding.ToString(this.DataBytes));
  }
}
