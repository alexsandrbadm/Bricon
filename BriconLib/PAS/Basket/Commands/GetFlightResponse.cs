// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.Commands.GetFlightResponse
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using BriconLib.PAS.Shared.Commands;

namespace BriconLib.PAS.Basket.Commands
{
  public class GetFlightResponse : Response
  {
    public GetFlightResponse(
      Response.StatusType status,
      string clubCode,
      string flightCode,
      string flightName)
      : base(Command.CommandType.GetFlight, status, GetFlightResponse.BuildDataBytes(clubCode, flightCode, flightName))
    {
    }

    public static byte[] BuildDataBytes(string clubCode, string flightCode, string flightName) => Conversion.StringToByteArray(clubCode.PadRight(10) + flightCode.PadRight(10) + flightName.PadRight(20), 40);

    public override string ToString() => string.Format("{0} - {1} - {2}", (object) this.CMD, (object) this.Status, (object) HexEncoding.ToString(this.DataBytes));
  }
}
