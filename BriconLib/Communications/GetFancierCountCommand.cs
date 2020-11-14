// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.GetFancierCountCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using MultiLang;

namespace BriconLib.Communications
{
  public class GetFancierCountCommand : Command
  {
    public byte ReceivedCount;

    public override string ToString() => this.AddStatusText(ml.ml_string(409, "Get Fancier Count"));

    public override byte[] ToBytes()
    {
      byte[] bytes = this.CreateBytes(CommunicationState.Instance.BAAddress, (byte) 250, (byte) 2);
      bytes[3] = (byte) 10;
      bytes[4] = (byte) 0;
      return bytes;
    }

    public override void HandleResponse(Response response)
    {
      base.HandleResponse(response);
      if (response.Status != ResponseStatus.OK)
        return;
      this.ReceivedCount = response.DataBytes[0];
    }

    public override bool HasFeedBack => true;
  }
}
