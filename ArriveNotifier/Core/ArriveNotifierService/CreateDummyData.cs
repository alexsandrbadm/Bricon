// Decompiled with JetBrains decompiler
// Type: ArriveNotifier.Core.ArriveNotifierService.CreateDummyData
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using ArriveNotifier.WCFService.Data;
using System;

namespace ArriveNotifier.Core.ArriveNotifierService
{
  public class CreateDummyData
  {
    public static CreateDummyData Instance = new CreateDummyData();

    public static ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel.ArrivalData CategoryArriveInfo => new ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel.ArrivalData()
    {
      IsArrived = true,
      FirstFancierName = "A Fancier",
      FirstArrivalTime = new DateTime?(DateTime.Now - TimeSpan.FromHours(2.0)),
      Speed = new double?(1400.14),
      EstimatedArrivalTime = new DateTime?(DateTime.Now + TimeSpan.FromHours(1.0))
    };

    public ArriveNotifierData AllData
    {
      get
      {
        ArriveNotifierData arriveNotifierData = new ArriveNotifierData();
        arriveNotifierData.ActiveRaces = new ArriveNotifierData.ActiveRaceData[2]
        {
          new ArriveNotifierData.ActiveRaceData()
          {
            RaceName = "Race 1",
            ReleaseTime = DateTime.Now - TimeSpan.FromHours(8.0),
            SpeedWhenArriveNow = 1337.18,
            DistanceInMeter = 754145,
            PigeonsArrivedCount = 5,
            MyPigeonsArrivedCount = 2,
            ArrivalDataClub = new ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel()
            {
              ArrivalDataCategoryOld = new ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel.ArrivalData()
              {
                IsArrived = true,
                FirstFancierName = "A Fancier",
                FirstArrivalTime = new DateTime?(DateTime.Now - TimeSpan.FromHours(2.0)),
                Speed = new double?(1400.14),
                EstimatedArrivalTime = new DateTime?(DateTime.Now + TimeSpan.FromHours(1.0))
              },
              ArrivalDataCategoryYearling = new ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel.ArrivalData()
              {
                IsArrived = true,
                FirstFancierName = "A Fancier2",
                FirstArrivalTime = new DateTime?(DateTime.Now - TimeSpan.FromHours(3.0)),
                Speed = new double?(1000.14),
                EstimatedArrivalTime = new DateTime?(DateTime.Now + TimeSpan.FromHours(1.0))
              }
            },
            ArrivalDataNational = new ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel()
            {
              ArrivalDataCategoryOld = new ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel.ArrivalData()
              {
                IsArrived = true,
                FirstFancierName = "Another Fancier",
                FirstArrivalTime = new DateTime?(DateTime.Now - TimeSpan.FromHours(3.0)),
                Speed = new double?(1400.14),
                EstimatedArrivalTime = new DateTime?(DateTime.Now + TimeSpan.FromHours(1.0))
              },
              ArrivalDataCategoryYearling = new ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel.ArrivalData()
              {
                IsArrived = true,
                FirstFancierName = "Third Fancier",
                FirstArrivalTime = new DateTime?(DateTime.Now - TimeSpan.FromHours(2.0)),
                Speed = new double?(1500.14),
                EstimatedArrivalTime = new DateTime?(DateTime.Now + TimeSpan.FromHours(1.5))
              }
            }
          },
          new ArriveNotifierData.ActiveRaceData()
          {
            RaceName = "Race 2",
            ReleaseTime = DateTime.Now - TimeSpan.FromHours(7.0),
            SpeedWhenArriveNow = 1237.1825,
            DistanceInMeter = 454145,
            ArrivalDataClub = new ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel()
            {
              ArrivalDataCategoryOld = new ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel.ArrivalData()
              {
                IsArrived = true,
                FirstArrivalTime = new DateTime?(DateTime.Now - TimeSpan.FromHours(2.4)),
                Speed = new double?(1440.145),
                EstimatedArrivalTime = new DateTime?(DateTime.Now + TimeSpan.FromHours(0.5))
              }
            }
          }
        };
        return arriveNotifierData;
      }
    }
  }
}
