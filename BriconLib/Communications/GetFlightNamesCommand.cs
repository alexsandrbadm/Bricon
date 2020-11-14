// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.GetFlightNamesCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using MultiLang;

namespace BriconLib.Communications
{
  public class GetFlightNamesCommand : Command
  {
    public byte _index;
    public byte[] FlightNames;

    public GetFlightNamesCommand()
    {
    }

    private GetFlightNamesCommand(byte index) => this._index = index;

    public override string ToString() => this.AddStatusText(string.Format(ml.ml_string(1101, "Get Flightnames {0}"), (object) this._index));

    public override byte[] ToBytes()
    {
      byte[] bytes = this.CreateBytes(CommunicationState.Instance.BAAddress, (byte) 250, (byte) 2);
      bytes[3] = (byte) 12;
      bytes[4] = this._index;
      return bytes;
    }

    public override void HandleResponse(Response response)
    {
      base.HandleResponse(response);
      if (response.Status != ResponseStatus.OK)
        return;
      this.FlightNames = response.DataBytes;
      CommunicationPool.Instance.PostNextCommand((Command) new GetFlightNamesCommand(++this._index));
    }

    public override bool HasFeedBack => true;
  }
}
