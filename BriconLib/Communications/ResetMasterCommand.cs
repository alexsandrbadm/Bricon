// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.ResetMasterCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using MultiLang;

namespace BriconLib.Communications
{
  public class ResetMasterCommand : Command
  {
    public override string ToString() => this.AddStatusText(string.Format(ml.ml_string(281, "Reset Master")));

    public override byte[] ToBytes() => this.CreateBytes((byte) 16, (byte) 103, (byte) 0);

    public override void HandleResponse(Response response) => base.HandleResponse(response);

    public override bool IsMasterCommand => true;
  }
}
