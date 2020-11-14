// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.ReadOut.CommandHandling.ReadOutPigeonHandling
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using BriconLib.PAS.Basket;
using BriconLib.PAS.ReadOut.Commands;
using BriconLib.PAS.Shared.Commands;
using System;
using System.Data;

namespace BriconLib.PAS.ReadOut.CommandHandling
{
  public class ReadOutPigeonHandling : BriconLib.PAS.Shared.CommandHandling.CommandHandling
  {
    private readonly Action<ReadOutPigeonHandling.Model> _onPigeonReadOut;

    public ReadOutPigeonHandling(
      BasketContext basketContext,
      Action<ReadOutPigeonHandling.Model> onPigeonReadOut)
      : base(basketContext)
    {
      this._onPigeonReadOut = onPigeonReadOut;
    }

    public Response Handle(ReadOutPigeonCommand command)
    {
      if (!this.CheckTime((Command) command))
        return (Response) new ReadOutPigeonResponse(Response.StatusType.TimeNotOk);
      this.BasketContext.ActiveFancierLicense = command.FancierLicense;
      this.BasketContext.ActiveFancierName = command.FancierName;
      if (!this.CheckFancier((Command) command))
        return (Response) new ReadOutPigeonResponse(Response.StatusType.FancierMismatch);
      int? fancierId1 = this.GetFancierId();
      if (!fancierId1.HasValue)
        return (Response) new ReadOutPigeonResponse(Response.StatusType.FancierNotFound);
      foreach (BCEDataSet.PigeonsRow pigeon in (TypedTableBase<BCEDataSet.PigeonsRow>) BCEDatabase.DataSet.Pigeons)
      {
        if (pigeon.ELRing?.ToLower() == command.Chip?.ToLower())
        {
          int fancierId2 = pigeon.FancierID;
          int? nullable = fancierId1;
          int valueOrDefault = nullable.GetValueOrDefault();
          if (!(fancierId2 == valueOrDefault & nullable.HasValue))
            return (Response) new ReadOutPigeonResponse(Response.StatusType.RingOfOtherFancier);
          string dbRing = pigeon.DBRing;
          this._onPigeonReadOut(new ReadOutPigeonHandling.Model()
          {
            Nbr = command.Nbr.ToString(),
            Chip = command.Chip,
            Status = command.Status,
            Ring = dbRing,
            Designated = command.Designated.ToString(),
            ReadOutTime = command.ReadOutDateTime.ToString("G"),
            ReadOutDateTime = command.ReadOutDateTime,
            DesignatedInt = command.Designated,
            Female = new bool?(pigeon.FEMALE),
            Sex = pigeon.FEMALE ? "V" : "M"
          });
          return (Response) new ReadOutPigeonResponse(Response.StatusType.Ok);
        }
      }
      return (Response) new ReadOutPigeonResponse(Response.StatusType.RingUnknown);
    }

    public class Model
    {
      public string Nbr { get; set; }

      public string Chip { get; set; }

      public string Ring { get; set; }

      public string Sex { get; set; }

      public string Designated { get; set; }

      public string ReadOutTime { get; set; }

      public bool? Female { get; set; }

      public int DesignatedInt { get; set; }

      public DateTime ReadOutDateTime { get; set; }

      public string Status { get; set; }
    }
  }
}
