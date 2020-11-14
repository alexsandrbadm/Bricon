// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.ReadOut.CommandHandling.ReadOutHandling
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.Basket;
using BriconLib.PAS.ReadOut.Commands;
using BriconLib.PAS.Shared.Commands;

namespace BriconLib.PAS.ReadOut.CommandHandling
{
  public class ReadOutHandling : BriconLib.PAS.Shared.CommandHandling.CommandHandling
  {
    public ReadOutHandling(BasketContext basketContext)
      : base(basketContext)
    {
    }

    public Response Handle(ReadOutCommand command)
    {
      if (!this.CheckTime((Command) command))
        return (Response) new ReadOutResponse(Response.StatusType.TimeNotOk, "");
      this.BasketContext.MasterSerial = command.MasterSerial;
      this.BasketContext.MasterVersion = "TODO";
      this.BasketContext.BasketContextChanged();
      return (Response) new ReadOutResponse(Response.StatusType.Ok, this.BasketContext.ClubCode);
    }
  }
}
