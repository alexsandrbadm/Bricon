// Decompiled with JetBrains decompiler
// Type: ArriveNotifier.Core.Models.ArriveNotifierModel
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using ArriveNotifier.WCFService.Data;
using System;

namespace ArriveNotifier.Core.Models
{
  public class ArriveNotifierModel
  {
    private readonly IArriveNotifier _webService;

    public ArriveNotifierModel(IArriveNotifier webService)
    {
      this._webService = webService;
      this.ErrorMessage = "";
      this.CountryCode = "BE";
      this.UserName = "";
      this.PassWord = "";
    }

    public bool TryLogin() => this.GetData() != null;

    public bool CanTryLogin() => this.UserName != null && this.PassWord != null && (this.UserName.Length >= 4 && this.UserName.Length < 30) && this.PassWord.Length >= 4 && this.PassWord.Length < 30;

    public ArriveNotifierData GetData()
    {
      try
      {
        ArriveNotifierResponse data = this._webService.GetData(this.CountryCode + this.UserName, this.PassWord);
        if (data != null)
        {
          if (data.Success)
            return data.AllData;
          this.ErrorMessage = data.Message;
        }
        else
          this.ErrorMessage = "Error with webservice";
      }
      catch (Exception ex)
      {
        this.ErrorMessage = ex.Message;
      }
      return (ArriveNotifierData) null;
    }

    public bool AreEqual(ArriveNotifierData currentData, ArriveNotifierData newData)
    {
      if (currentData == null && newData == null)
        return true;
      if (currentData == null || newData == null || (currentData.ActiveRaces == null || newData.ActiveRaces == null) || currentData.ActiveRaces.Length != newData.ActiveRaces.Length)
        return false;
      for (int index = 0; index < currentData.ActiveRaces.Length; ++index)
      {
        ArriveNotifierData.ActiveRaceData activeRace1 = currentData.ActiveRaces[index];
        ArriveNotifierData.ActiveRaceData activeRace2 = newData.ActiveRaces[index];
        if (activeRace1.DistanceInMeter != activeRace2.DistanceInMeter || activeRace1.RaceName != activeRace2.RaceName || (activeRace1.ReleaseTime != activeRace2.ReleaseTime || activeRace1.MyPigeonsArrivedCount != activeRace2.MyPigeonsArrivedCount) || (activeRace1.ArrivalDataClub.ArrivalDataCategoryOld.IsArrived != activeRace2.ArrivalDataClub.ArrivalDataCategoryOld.IsArrived || activeRace1.ArrivalDataClub.ArrivalDataCategoryYearling.IsArrived != activeRace2.ArrivalDataClub.ArrivalDataCategoryYearling.IsArrived || (activeRace1.ArrivalDataClub.ArrivalDataCategoryYoung.IsArrived != activeRace2.ArrivalDataClub.ArrivalDataCategoryYoung.IsArrived || activeRace1.ArrivalDataNational.ArrivalDataCategoryOld.IsArrived != activeRace2.ArrivalDataNational.ArrivalDataCategoryOld.IsArrived)) || (activeRace1.ArrivalDataNational.ArrivalDataCategoryYearling.IsArrived != activeRace2.ArrivalDataNational.ArrivalDataCategoryYearling.IsArrived || activeRace1.ArrivalDataNational.ArrivalDataCategoryYoung.IsArrived != activeRace2.ArrivalDataNational.ArrivalDataCategoryYoung.IsArrived))
          return false;
      }
      return true;
    }

    public string CountryCode { get; set; }

    public string UserName { get; set; }

    public string PassWord { get; set; }

    public string ErrorMessage { get; private set; }
  }
}
