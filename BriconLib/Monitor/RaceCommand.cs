// Decompiled with JetBrains decompiler
// Type: BriconLib.Monitor.RaceCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using MultiLang;
using System;
using System.Globalization;

namespace BriconLib.Monitor
{
  public class RaceCommand : Command
  {
    public bool RaceIsDeleted;
    private byte[] _bytes;

    public RaceCommand(string raceName, string clubID)
    {
      this.RaceName = raceName;
      this.ClubID = clubID;
      this.Speed = "-";
    }

    public RaceCommand(byte[] bytes)
    {
      this.Speed = "-";
      this.Show = true;
      if (Utils.UnitsUsed() == "Imperial")
      {
        this.DistanceInMeter = 100;
        this.DistanceYards = 0;
      }
      else
        this.DistanceInMeter = 100000;
      this.ReleaseTime = new DateTime(2000, 1, 1, 0, 0, 0);
      this.ReleaseDate = DateTime.Now.Subtract(TimeSpan.FromDays(1.0));
      if (bytes == null)
      {
        this.Index = -1;
        this.RaceNameShort = this.RaceName = ml.ml_string(896, "Training");
        RaceDataSaver.FillInIfPossible(this);
      }
      else
      {
        this._bytes = bytes;
        this.RaceIsDeleted = bytes[4] == (byte) 5;
        if (this._bytes.Length < 61 || this.RaceIsDeleted)
          return;
        this.RaceIsDeleted = (int) this._bytes[5] + (int) this._bytes[17] + (int) this._bytes[18] + (int) this._bytes[19] == 0;
        if (this.RaceIsDeleted)
          return;
        this.RaceNameShort = Conversion.ByteArrayToString(this._bytes, 21, 4);
        this.ClubID = Conversion.ByteArrayToString(this._bytes, 17, 4);
        string str = HexEncoding.ToString(this._bytes, 31, 3);
        this.BasketDate = Convert.ToDateTime(str.Substring(2, 2) + "/" + str.Substring(4, 2) + "/20" + str.Substring(0, 2), (IFormatProvider) CultureInfo.InvariantCulture);
        this.RaceName = RaceNameResolver.Resolve(this.RaceNameShort);
        RaceDataSaver.FillInIfPossible(this);
      }
    }

    public override string ToString() => string.Format(ml.ml_string(1157, "Race ") + this.RaceName + ml.ml_string(1158, " received"));

    public int Index { get; set; }

    public int PigeonCount { get; set; }

    public string RaceNameShort { get; private set; }

    public string ClubID { get; private set; }

    public string RaceName { get; private set; }

    public int FlightIDBriconWeb { get; set; }

    public int ClubIDBriconWeb { get; set; }

    public bool ActiveInBriconWeb => (uint) this.FlightIDBriconWeb > 0U;

    public bool Show { get; set; }

    public DateTime BasketDate { get; set; }

    public DateTime ReleaseDate { get; set; }

    public DateTime ReleaseTime { get; set; }

    public int DistanceInMeter { get; set; }

    public int DistanceYards { get; set; }

    public bool Email { get; set; }

    public bool Email2 { get; set; }

    public bool PigeonCloud { get; set; }

    public bool AskGummy { get; set; }

    public bool AskOnlyFirstTwoGummies { get; set; }

    public bool AskWingmark { get; set; }

    public bool IsNationalFlight { get; set; }

    public bool PlaySound { get; set; }

    public string Speed { get; set; }
  }
}
