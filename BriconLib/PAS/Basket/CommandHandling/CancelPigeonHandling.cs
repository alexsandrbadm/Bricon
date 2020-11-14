// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.CommandHandling.CancelPigeonHandling
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.Basket.Commands;
using BriconLib.PAS.Shared.Commands;
using System;

namespace BriconLib.PAS.Basket.CommandHandling
{
  public class CancelPigeonHandling : BriconLib.PAS.Shared.CommandHandling.CommandHandling
  {
    private readonly Action<CancelPigeonHandling.Model> _onPigeonCancelled;

    public CancelPigeonHandling(
      BasketContext basketContext,
      Action<CancelPigeonHandling.Model> onPigeonCancelled)
      : base(basketContext)
    {
      this._onPigeonCancelled = onPigeonCancelled;
    }

    public Response Handle(CancelPigeonCommand command)
    {
      if (!this.CheckTime((Command) command))
        return (Response) new CancelPigeonResponse(Response.StatusType.TimeNotOk);
      if (!this.CheckFancier((Command) command))
        return (Response) new CancelPigeonResponse(Response.StatusType.FancierMismatch);
      this._onPigeonCancelled(new CancelPigeonHandling.Model()
      {
        Chip = command.Chip,
        CancelDateTime = command.MasterTime
      });
      return (Response) new CancelPigeonResponse(Response.StatusType.Ok);
    }

    public class Model
    {
      public string Chip { get; set; }

      public DateTime CancelDateTime { get; set; }
    }
  }
}
