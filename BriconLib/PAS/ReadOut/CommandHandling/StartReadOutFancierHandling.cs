// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.ReadOut.CommandHandling.StartReadOutFancierHandling
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.Basket;
using BriconLib.PAS.ReadOut.Commands;
using BriconLib.PAS.Shared.Commands;
using System;

namespace BriconLib.PAS.ReadOut.CommandHandling
{
  public class StartReadOutFancierHandling : BriconLib.PAS.Shared.CommandHandling.CommandHandling
  {
    private readonly Func<bool> _onStarted;

    public StartReadOutFancierHandling(BasketContext basketContext, Func<bool> onStarted)
      : base(basketContext)
      => this._onStarted = onStarted;

    public Response Handle(StartReadOutFancierCommand command)
    {
      if (!this.CheckTime((Command) command))
        return (Response) new StartReadOutFancierResponse(Response.StatusType.TimeNotOk);
      if (!this._onStarted())
        return (Response) new StartReadOutFancierResponse(Response.StatusType.CantAddAnymore);
      this.BasketContext.ActiveFancierLicense = command.FancierLicense;
      this.BasketContext.ActiveFancierName = command.FancierName;
      this.BasketContext.ClubCode = command.Club;
      this.BasketContext.ClubName = "Club " + command.Club;
      this.BasketContext.FlightCode = command.Race;
      this.BasketContext.FlightName = "Race " + command.Race;
      this.BasketContext.ReadOutInternalDateTime = new DateTime?(command.ReadOutInternalDateTime);
      this.BasketContext.ReadOutExternalDateTime = new DateTime?(command.ReadOutExternalDateTime);
      this.BasketContext.BasketContextChanged();
      return (Response) new StartReadOutFancierResponse(Response.StatusType.Ok);
    }
  }
}
