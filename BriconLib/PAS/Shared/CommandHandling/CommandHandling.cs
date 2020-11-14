// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Shared.CommandHandling.CommandHandling
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using BriconLib.PAS.Basket;
using BriconLib.PAS.Shared.Commands;
using CoreLib.Helpers;
using System;
using System.Data;

namespace BriconLib.PAS.Shared.CommandHandling
{
  public class CommandHandling
  {
    protected BasketContext BasketContext;

    public CommandHandling(BasketContext basketContext) => this.BasketContext = basketContext;

    public bool CheckTime(Command command) => Math.Abs((NtpClient.GetNetworkTimeCached() - command.MasterTime).TotalSeconds) <= 10.0;

    public bool CheckFancier(Command command) => !string.IsNullOrWhiteSpace(this.BasketContext.ActiveFancierLicense) && (string.IsNullOrWhiteSpace(this.BasketContext.XtremeSerial) || !(this.BasketContext.ActiveFancierLicense != command.FancierLicense) && !(this.BasketContext.ActiveFancierName != command.FancierName));

    protected int? GetFancierId()
    {
      DataRow[] dataRowArray = BCEDatabase.DataSet.Adressen.Select("Licentie = '" + this.BasketContext.ActiveFancierLicense + "'");
      if (dataRowArray.Length != 1)
        return new int?();
      return !(dataRowArray[0] is BCEDataSet.AdressenRow adressenRow) ? new int?() : new int?(adressenRow.Id);
    }

    protected Response HandleApiResponse(Command command, ApiResponseModel response)
    {
      if (!response.Success)
        return (Response) new ResponseWithOptionalMessage(command.CMD, Response.StatusType.BCEOrPasError, response.ShortErrorMessage);
      return string.IsNullOrWhiteSpace(response.ShortErrorMessage) ? (Response) new ResponseWithOptionalMessage(command.CMD, Response.StatusType.Ok) : (Response) new ResponseWithOptionalMessage(command.CMD, Response.StatusType.BCEOrPasWarning, response.ShortErrorMessage);
    }
  }
}
