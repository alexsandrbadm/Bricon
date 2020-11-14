// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.CommandHandling.StartBasketFancierHandling
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.Basket.Commands;
using BriconLib.PAS.Shared;
using BriconLib.PAS.Shared.Commands;
using CoreLib.Helpers;
using System;

namespace BriconLib.PAS.Basket.CommandHandling
{
  public class StartBasketFancierHandling : BriconLib.PAS.Shared.CommandHandling.CommandHandling
  {
    private readonly Func<string, ApiResponseModel> _onStarted;

    public StartBasketFancierHandling(
      BasketContext basketContext,
      Func<string, ApiResponseModel> onStarted)
      : base(basketContext)
    {
      this._onStarted = onStarted;
    }

    public Response Handle(StartBasketFancierCommand command)
    {
      if (!this.CheckTime((Command) command))
        return (Response) new ResponseWithOptionalMessage(command.CMD, Response.StatusType.TimeNotOk);
      this.BasketContext.XtremeSerial = command.XtremeSerial;
      this.BasketContext.ActiveFancierName = command.FancierName;
      this.BasketContext.BasketStartServerDateTime = new DateTime?(NtpClient.GetNetworkTimeCached());
      this.BasketContext.BasketContextChanged();
      ApiResponseModel response = this._onStarted(command.FancierLicense);
      this.BasketContext.ActiveFancierLicense = command.FancierLicense;
      return this.HandleApiResponse((Command) command, response);
    }
  }
}
