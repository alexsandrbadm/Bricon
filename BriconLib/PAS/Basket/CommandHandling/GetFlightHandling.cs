// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.CommandHandling.GetFlightHandling
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.Basket.Commands;
using BriconLib.PAS.Shared.Commands;
using System;

namespace BriconLib.PAS.Basket.CommandHandling
{
  public class GetFlightHandling : BriconLib.PAS.Shared.CommandHandling.CommandHandling
  {
    private readonly Action _onStarted;

    public GetFlightHandling(BasketContext basketContext, Action onStarted)
      : base(basketContext)
      => this._onStarted = onStarted;

    public Response Handle(GetFlightCommand command)
    {
      if (!this.CheckTime((Command) command))
        return (Response) new GetFlightResponse(Response.StatusType.TimeNotOk, "", "", "");
      this.BasketContext.MasterSerial = command.MasterSerial;
      this.BasketContext.MasterVersion = command.MasterVersion;
      this.BasketContext.BasketContextChanged();
      this._onStarted();
      return (Response) new GetFlightResponse(Response.StatusType.Ok, this.BasketContext.ClubCode, this.BasketContext.FlightCode, this.BasketContext.FlightName);
    }
  }
}
