// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.Commands.BasketPigeonResponse
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using BriconLib.PAS.Shared.Commands;

namespace BriconLib.PAS.Basket.Commands
{
  public class BasketPigeonResponse : Response
  {
    public BasketPigeonResponse(
      Response.StatusType status,
      string ring = "",
      string license = "",
      string name = "",
      int basketCount = 0)
      : base(Command.CommandType.BasketPigeon, status, BasketPigeonResponse.BuildDataBytes(ring, license, name, basketCount))
    {
    }

    public static byte[] BuildDataBytes(string ring, string license, string name, int basketCount) => Conversion.StringToByteArray(ring.PadRight(20) + license.PadRight(8) + name.PadRight(20) + basketCount.ToString().PadRight(4), 52);

    public override string ToString() => string.Format("{0} - {1} - {2}", (object) this.CMD, (object) this.Status, (object) HexEncoding.ToString(this.DataBytes));
  }
}
