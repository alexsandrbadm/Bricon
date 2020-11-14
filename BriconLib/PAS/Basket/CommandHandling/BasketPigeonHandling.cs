// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.CommandHandling.BasketPigeonHandling
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using BriconLib.PAS.Basket.Commands;
using BriconLib.PAS.Shared.Commands;
using CoreLib.Helpers;
using System;
using System.Data;

namespace BriconLib.PAS.Basket.CommandHandling
{
  public class BasketPigeonHandling : BriconLib.PAS.Shared.CommandHandling.CommandHandling
  {
    private readonly Action<BasketPigeonHandling.Model> _onPigeonBasketted;

    public static string BasketStatus(DateTime? basketDateTime, DateTime? cancelDateTime)
    {
      if (!basketDateTime.HasValue)
        return "";
      if (!cancelDateTime.HasValue)
        return "OK";
      DateTime? nullable1 = basketDateTime;
      DateTime? nullable2 = cancelDateTime;
      return (nullable1.HasValue & nullable2.HasValue ? (nullable1.GetValueOrDefault() > nullable2.GetValueOrDefault() ? 1 : 0) : 0) != 0 ? "OK(2x)" : "Ann.";
    }

    public BasketPigeonHandling(
      BasketContext basketContext,
      Action<BasketPigeonHandling.Model> onPigeonBasketted)
      : base(basketContext)
    {
      this._onPigeonBasketted = onPigeonBasketted;
    }

    public Response Handle(BasketPigeonCommand command)
    {
      if (!this.CheckTime((Command) command))
        return (Response) new BasketPigeonResponse(Response.StatusType.TimeNotOk);
      int? nullable1 = new int?();
      bool flag = false;
      if (string.IsNullOrWhiteSpace(this.BasketContext.ActiveFancierLicense) && string.IsNullOrWhiteSpace(command.FancierLicense) && string.IsNullOrWhiteSpace(command.FancierName))
      {
        flag = true;
      }
      else
      {
        if (!this.CheckFancier((Command) command))
          return (Response) new BasketPigeonResponse(Response.StatusType.FancierMismatch);
        nullable1 = this.GetFancierId();
        if (!nullable1.HasValue)
          return (Response) new BasketPigeonResponse(Response.StatusType.FancierNotFound);
      }
      foreach (BCEDataSet.PigeonsRow pigeon in (TypedTableBase<BCEDataSet.PigeonsRow>) BCEDatabase.DataSet.Pigeons)
      {
        if (pigeon.ELRing?.ToLower() == command.Chip?.ToLower())
        {
          if (flag)
          {
            BCEDataSet.AdressenRow byId = BCEDatabase.DataSet.Adressen.FindById(pigeon.FancierID);
            if (byId == null)
              return (Response) new BasketPigeonResponse(Response.StatusType.FancierNotFound);
            this.BasketContext.ActiveFancierLicense = byId.Licentie;
            this.BasketContext.ActiveFancierName = byId.Naam;
            this.BasketContext.BasketStartServerDateTime = new DateTime?(NtpClient.GetNetworkTimeCached());
            this.BasketContext.BasketContextChanged();
          }
          else
          {
            int fancierId = pigeon.FancierID;
            int? nullable2 = nullable1;
            int valueOrDefault = nullable2.GetValueOrDefault();
            if (!(fancierId == valueOrDefault & nullable2.HasValue))
              return (Response) new BasketPigeonResponse(Response.StatusType.RingOfOtherFancier);
          }
          if (!command.OnlyCheck)
            this._onPigeonBasketted(new BasketPigeonHandling.Model()
            {
              Nbr = (this.BasketContext.BasketCount + 1).ToString(),
              Chip = command.Chip,
              Ring = pigeon.DBRing,
              BasketDateTime = new DateTime?(command.MasterTime),
              DesignatedInt = new int?(this.BasketContext.MaxDesignated + 1),
              Female = new bool?(pigeon.FEMALE),
              Code = command.Code
            });
          return (Response) new BasketPigeonResponse(Response.StatusType.Ok, pigeon.DBRing + (pigeon.FEMALE ? "V" : ""), this.BasketContext.ActiveFancierLicense, this.BasketContext.ActiveFancierName, this.BasketContext.BasketCount + (command.OnlyCheck ? 0 : 1));
        }
      }
      return (Response) new BasketPigeonResponse(Response.StatusType.RingUnknown);
    }

    public class Model
    {
      public string Nbr { get; set; }

      public string Chip { get; set; }

      public string Ring { get; set; }

      public string Code { get; set; }

      public string Sex
      {
        get
        {
          bool? female1 = this.Female;
          bool flag1 = true;
          if (female1.GetValueOrDefault() == flag1 & female1.HasValue)
            return "V";
          bool? female2 = this.Female;
          bool flag2 = false;
          return !(female2.GetValueOrDefault() == flag2 & female2.HasValue) ? "" : "M";
        }
      }

      public string Designated
      {
        get
        {
          int? designatedInt = this.DesignatedInt;
          ref int? local = ref designatedInt;
          return !local.HasValue ? (string) null : local.GetValueOrDefault().ToString();
        }
      }

      public int? DesignatedInt { get; set; }

      public string Basket { get; set; }

      public bool? Female { get; set; }

      public string BasketTime
      {
        get
        {
          DateTime? basketDateTime = this.BasketDateTime;
          ref DateTime? local = ref basketDateTime;
          return !local.HasValue ? (string) null : local.GetValueOrDefault().ToString("G");
        }
      }

      public DateTime? BasketDateTime { get; set; }

      public DateTime? CancelDateTime { get; set; }

      public string Ok => BasketPigeonHandling.BasketStatus(this.BasketDateTime, this.CancelDateTime);
    }
  }
}
