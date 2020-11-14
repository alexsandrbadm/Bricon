﻿// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.Commands.CancelPigeonResponse
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.Shared.Commands;

namespace BriconLib.PAS.Basket.Commands
{
  public class CancelPigeonResponse : Response
  {
    public CancelPigeonResponse(Response.StatusType status)
      : base(Command.CommandType.CancelPigeon, status, CancelPigeonResponse.BuildDataBytes())
    {
    }

    public static byte[] BuildDataBytes() => new byte[0];

    public override string ToString() => string.Format("{0} - {1} - {2}", (object) this.CMD, (object) this.Status, (object) HexEncoding.ToString(this.DataBytes));
  }
}
