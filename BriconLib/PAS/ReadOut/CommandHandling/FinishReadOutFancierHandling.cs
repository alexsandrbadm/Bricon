// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.ReadOut.CommandHandling.FinishReadOutFancierHandling
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.Basket;
using BriconLib.PAS.ReadOut.Commands;
using BriconLib.PAS.Shared;
using BriconLib.PAS.Shared.Commands;
using System;

namespace BriconLib.PAS.ReadOut.CommandHandling
{
  public class FinishReadOutFancierHandling : BriconLib.PAS.Shared.CommandHandling.CommandHandling
  {
    private readonly Func<ApiResponseModel> _onFancierEnded;

    public FinishReadOutFancierHandling(
      BasketContext basketContext,
      Func<ApiResponseModel> onFancierEnded)
      : base(basketContext)
    {
      this._onFancierEnded = onFancierEnded;
    }

    public Response Handle(FinishReadOutFancierCommand command)
    {
      ApiResponseModel response = this._onFancierEnded();
      return this.HandleApiResponse((Command) command, response);
    }
  }
}
