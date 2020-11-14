// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.CommandHandling.EmergencyLinkHandling
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using BriconLib.PAS.Basket.Commands;
using BriconLib.PAS.Basket.PAS;
using BriconLib.PAS.Shared;
using BriconLib.PAS.Shared.Commands;
using BriconLib.Properties;
using CoreLib.Helpers;
using System;
using System.Data;

namespace BriconLib.PAS.Basket.CommandHandling
{
  public class EmergencyLinkHandling : BriconLib.PAS.Shared.CommandHandling.CommandHandling
  {
    private readonly Func<CreateRingModel, ApiResponseModel> _onHandle;

    public EmergencyLinkHandling(
      BasketContext basketContext,
      Func<CreateRingModel, ApiResponseModel> onHandle)
      : base(basketContext)
    {
      this._onHandle = onHandle;
    }

    public Response Handle(EmergencyLinkCommand command)
    {
      if (!this.CheckTime((Command) command))
        return (Response) new EmergencyLinkResponse(Response.StatusType.TimeNotOk);
      int? nullable1 = new int?();
      bool flag = false;
      if (string.IsNullOrWhiteSpace(this.BasketContext.ActiveFancierLicense) && string.IsNullOrWhiteSpace(command.FancierLicense) && string.IsNullOrWhiteSpace(command.FancierName))
      {
        flag = true;
      }
      else
      {
        if (!this.CheckFancier((Command) command))
          return (Response) new EmergencyLinkResponse(Response.StatusType.FancierMismatch);
        nullable1 = this.GetFancierId();
        if (!nullable1.HasValue)
          return (Response) new EmergencyLinkResponse(Response.StatusType.FancierNotFound);
      }
      foreach (BCEDataSet.PigeonsRow pigeon in (TypedTableBase<BCEDataSet.PigeonsRow>) BCEDatabase.DataSet.Pigeons)
      {
        if (pigeon.DBRing?.ToLower() + (pigeon.FEMALE ? "v" : "") == command.Ring?.ToLower())
        {
          if (flag)
          {
            BCEDataSet.AdressenRow byId = BCEDatabase.DataSet.Adressen.FindById(pigeon.FancierID);
            if (byId == null)
              return (Response) new EmergencyLinkResponse(Response.StatusType.FancierNotFound);
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
              return (Response) new EmergencyLinkResponse(Response.StatusType.RingOfOtherFancier);
          }
          ApiResponseModel response = this._onHandle(new CreateRingModel()
          {
            ChipCode = command.Chip,
            FancierLicense = this.BasketContext.ActiveFancierLicense,
            CountryId = Settings.Default.Country,
            Ring = command.Ring
          });
          if (response.Success)
            pigeon.ELRing = command.Chip;
          return this.HandleApiResponse((Command) command, response);
        }
      }
      return (Response) new EmergencyLinkResponse(Response.StatusType.RingUnknown);
    }
  }
}
