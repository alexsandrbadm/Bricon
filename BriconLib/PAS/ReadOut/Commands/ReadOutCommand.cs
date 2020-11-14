// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.ReadOut.Commands.ReadOutCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using BriconLib.PAS.Shared.Commands;

namespace BriconLib.PAS.ReadOut.Commands
{
  public class ReadOutCommand : Command
  {
    public string MasterSerial { get; set; }

    public ReadOutCommand(byte[] bytes)
      : base(bytes)
      => this.MasterSerial = "M-" + Conversion.ByteArrayToString(this.DataBytes, this.ParseCommonFields(), 5);

    public override string ToString() => string.Format("{0} - {1} - {2} - {3} - {4} -  {5}", (object) this.CMD, (object) this.MasterSerial, (object) this.MasterTime, (object) this.FancierName, (object) this.FancierLicense, (object) HexEncoding.ToString(this.DataBytes));
  }
}
