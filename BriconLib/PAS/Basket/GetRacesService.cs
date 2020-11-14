// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.GetRacesService
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.Shared;
using BriconLib.Properties;
using System;
using System.Collections.Generic;

namespace BriconLib.PAS.Basket
{
  public class GetRacesService
  {
    public GetRacesService.GetRacesModel Get() => PasRestApiHelper.Get<GetRacesService.GetRacesModel>("/api/bce/races?countryId=" + Settings.Default.Country);

    public static BasketContext GetRaceDataFromCode(
      GetRacesService.GetRacesModel.Race race,
      string clubId,
      string clubName)
    {
      return new BasketContext()
      {
        FlightCode = race.RaceCode,
        FlightName = race.RaceName,
        Date = race.RaceDate.ToShortDateString(),
        ClubCode = clubId,
        ClubName = clubName
      };
    }

    public class GetRacesModel : ApiResponseModel
    {
      public List<GetRacesService.GetRacesModel.Race> Races { get; set; }

      public class Race
      {
        public string RaceCode { get; set; }

        public string RaceName { get; set; }

        public DateTime RaceDate { get; set; }

        public string Level { get; set; }

        public override string ToString() => this.RaceCode + " - " + this.RaceName + " - " + this.RaceDate.ToShortDateString() + " - " + this.Level;
      }
    }
  }
}
