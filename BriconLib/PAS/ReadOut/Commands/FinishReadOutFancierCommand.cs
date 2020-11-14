// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.ReadOut.Commands.FinishReadOutFancierCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.Shared.Commands;

namespace BriconLib.PAS.ReadOut.Commands
{
  public class FinishReadOutFancierCommand : Command
  {
    public FinishReadOutFancierCommand(byte[] bytes)
      : base(bytes)
      => this.ParseCommonFields();

    public override string ToString() => string.Format("{0} - {1} - {2} - {3} - {4}", (object) this.CMD, (object) this.MasterTime, (object) this.FancierName, (object) this.FancierLicense, (object) HexEncoding.ToString(this.DataBytes));
  }
}
