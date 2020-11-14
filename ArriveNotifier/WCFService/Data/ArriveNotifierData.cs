// Decompiled with JetBrains decompiler
// Type: ArriveNotifier.WCFService.Data.ArriveNotifierData
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ArriveNotifier.WCFService.Data
{
  [DebuggerStepThrough]
  [GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
  [DataContract(Name = "ArriveNotifierData", Namespace = "http://schemas.datacontract.org/2004/07/ArriveNotifier.WCFService.Data")]
  public class ArriveNotifierData : IExtensibleDataObject
  {
    private ExtensionDataObject extensionDataField;
    private ArriveNotifierData.ActiveRaceData[] ActiveRacesField;

    public ExtensionDataObject ExtensionData
    {
      get => this.extensionDataField;
      set => this.extensionDataField = value;
    }

    [DataMember]
    public ArriveNotifierData.ActiveRaceData[] ActiveRaces
    {
      get => this.ActiveRacesField;
      set => this.ActiveRacesField = value;
    }

    [DebuggerStepThrough]
    [GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
    [DataContract(Name = "ArriveNotifierData.ActiveRaceData", Namespace = "http://schemas.datacontract.org/2004/07/ArriveNotifier.WCFService.Data")]
    public class ActiveRaceData : IExtensibleDataObject
    {
      private ExtensionDataObject extensionDataField;
      private ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel ArrivalDataClubField;
      private ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel ArrivalDataNationalField;
      private int DistanceInMeterField;
      private int MyPigeonsArrivedCountField;
      private int PigeonsArrivedCountField;
      private string RaceNameField;
      private DateTime ReleaseTimeField;
      private double SpeedWhenArriveNowField;

      public ExtensionDataObject ExtensionData
      {
        get => this.extensionDataField;
        set => this.extensionDataField = value;
      }

      [DataMember]
      public ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel ArrivalDataClub
      {
        get => this.ArrivalDataClubField;
        set => this.ArrivalDataClubField = value;
      }

      [DataMember]
      public ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel ArrivalDataNational
      {
        get => this.ArrivalDataNationalField;
        set => this.ArrivalDataNationalField = value;
      }

      [DataMember]
      public int DistanceInMeter
      {
        get => this.DistanceInMeterField;
        set => this.DistanceInMeterField = value;
      }

      [DataMember]
      public int MyPigeonsArrivedCount
      {
        get => this.MyPigeonsArrivedCountField;
        set => this.MyPigeonsArrivedCountField = value;
      }

      [DataMember]
      public int PigeonsArrivedCount
      {
        get => this.PigeonsArrivedCountField;
        set => this.PigeonsArrivedCountField = value;
      }

      [DataMember]
      public string RaceName
      {
        get => this.RaceNameField;
        set => this.RaceNameField = value;
      }

      [DataMember]
      public DateTime ReleaseTime
      {
        get => this.ReleaseTimeField;
        set => this.ReleaseTimeField = value;
      }

      [DataMember]
      public double SpeedWhenArriveNow
      {
        get => this.SpeedWhenArriveNowField;
        set => this.SpeedWhenArriveNowField = value;
      }

      [DebuggerStepThrough]
      [GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
      [DataContract(Name = "ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel", Namespace = "http://schemas.datacontract.org/2004/07/ArriveNotifier.WCFService.Data")]
      public class ArrivalDataPerLevel : IExtensibleDataObject
      {
        private ExtensionDataObject extensionDataField;
        private ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel.ArrivalData ArrivalDataCategoryOldField;
        private ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel.ArrivalData ArrivalDataCategoryYearlingField;
        private ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel.ArrivalData ArrivalDataCategoryYoungField;

        public ExtensionDataObject ExtensionData
        {
          get => this.extensionDataField;
          set => this.extensionDataField = value;
        }

        [DataMember]
        public ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel.ArrivalData ArrivalDataCategoryOld
        {
          get => this.ArrivalDataCategoryOldField;
          set => this.ArrivalDataCategoryOldField = value;
        }

        [DataMember]
        public ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel.ArrivalData ArrivalDataCategoryYearling
        {
          get => this.ArrivalDataCategoryYearlingField;
          set => this.ArrivalDataCategoryYearlingField = value;
        }

        [DataMember]
        public ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel.ArrivalData ArrivalDataCategoryYoung
        {
          get => this.ArrivalDataCategoryYoungField;
          set => this.ArrivalDataCategoryYoungField = value;
        }

        [DebuggerStepThrough]
        [GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
        [DataContract(Name = "ArriveNotifierData.ActiveRaceData.ArrivalDataPerLevel.ArrivalData", Namespace = "http://schemas.datacontract.org/2004/07/ArriveNotifier.WCFService.Data")]
        public class ArrivalData : IExtensibleDataObject
        {
          private ExtensionDataObject extensionDataField;
          private DateTime? EstimatedArrivalTimeField;
          private DateTime? FirstArrivalTimeField;
          private string FirstFancierNameField;
          private bool IsArrivedField;
          private double? SpeedField;

          public ExtensionDataObject ExtensionData
          {
            get => this.extensionDataField;
            set => this.extensionDataField = value;
          }

          [DataMember]
          public DateTime? EstimatedArrivalTime
          {
            get => this.EstimatedArrivalTimeField;
            set => this.EstimatedArrivalTimeField = value;
          }

          [DataMember]
          public DateTime? FirstArrivalTime
          {
            get => this.FirstArrivalTimeField;
            set => this.FirstArrivalTimeField = value;
          }

          [DataMember]
          public string FirstFancierName
          {
            get => this.FirstFancierNameField;
            set => this.FirstFancierNameField = value;
          }

          [DataMember]
          public bool IsArrived
          {
            get => this.IsArrivedField;
            set => this.IsArrivedField = value;
          }

          [DataMember]
          public double? Speed
          {
            get => this.SpeedField;
            set => this.SpeedField = value;
          }
        }
      }
    }
  }
}
