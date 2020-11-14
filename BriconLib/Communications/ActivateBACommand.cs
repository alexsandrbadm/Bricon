// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.ActivateBACommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using MultiLang;

namespace BriconLib.Communications
{
  public class ActivateBACommand : Command
  {
    private byte _adress;
    public static byte[] LastDataRecord;

    public ActivateBACommand(byte adress) => this._adress = adress;

    public override string ToString() => this.AddStatusText(string.Format(ml.ml_string(102, "Activate ETS")));

    public override byte[] ToBytes()
    {
      byte[] bytes = this.CreateBytes(this._adress, this._adress == (byte) 0 ? (byte) 192 : (byte) 80, (byte) 1);
      bytes[3] = (byte) 0;
      return bytes;
    }

    public override void HandleResponse(Response response)
    {
      base.HandleResponse(response);
      CommunicationState.Instance.WaitingToConnectBA = false;
      CommunicationState.Instance.BAAddress = this._adress;
      ActivateBACommand.LastDataRecord = response.DataBytes;
      for (int index = 0; index < response.DataBytes.Length; ++index)
      {
        if (response.DataBytes[index] == (byte) 0)
          response.DataBytes[index] = (byte) 32;
      }
      CommunicationState.Instance.BAVersion = Conversion.ByteArrayToString(response.DataBytes);
    }

    public override void HandleFailedResponce(ResponseStatus status)
    {
      base.HandleFailedResponce(status);
      CommunicationState.Instance.BAAddress = byte.MaxValue;
    }
  }
}
