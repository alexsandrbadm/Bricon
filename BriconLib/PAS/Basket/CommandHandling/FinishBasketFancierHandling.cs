// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.CommandHandling.FinishBasketFancierHandling
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.Basket.Commands;
using BriconLib.PAS.Shared;
using BriconLib.PAS.Shared.Commands;
using System;

namespace BriconLib.PAS.Basket.CommandHandling
{
  public class FinishBasketFancierHandling : BriconLib.PAS.Shared.CommandHandling.CommandHandling
  {
    private readonly Func<ApiResponseModel> _onFancierEnded;

    public FinishBasketFancierHandling(
      BasketContext basketContext,
      Func<ApiResponseModel> onFancierEnded)
      : base(basketContext)
    {
      this._onFancierEnded = onFancierEnded;
    }

    public Response Handle(FinishBasketFancierCommand command)
    {
      if (this.BasketContext.XtremeSerial != command.XtremeSerial && command.XtremeSerial != "PASBOX")
      {
        ApiResponseModel response = new ApiResponseModel()
        {
          Success = false
        };
        response.LogMessages.Add(new ApiResponseModel.LogMessage()
        {
          Message = "Serial number different since start basketting fancier",
          LogType = ApiResponseModel.LogType.Error
        });
        response.ShortErrorMessage = "Serialnbr mismatch";
        return this.HandleApiResponse((Command) command, response);
      }
      this.BasketContext.FancierAgreed = command.FancierAgreed;
      this.BasketContext.BasketInternalDateTime = new DateTime?(command.BasketInternalDateTime);
      this.BasketContext.BasketExternalDateTime = new DateTime?(command.BasketExternalDateTime);
      ApiResponseModel response1 = this._onFancierEnded();
      return this.HandleApiResponse((Command) command, response1);
    }
  }
}
