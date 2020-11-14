// Decompiled with JetBrains decompiler
// Type: BriconLib.Monitor.PigeonCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using BriconLib.Properties;
using MultiLang;
using System;
using System.Globalization;
using System.Text;

namespace BriconLib.Monitor
{
  public class PigeonCommand : Command
  {
    public bool NoMoreRecords;
    private byte[] _bytes;

    public PigeonCommand(string license, int pos)
    {
      this.RaceIndex = 0;
      this.DBRing = Settings.Default.Country + "-" + pos.ToString("X2") + "-" + license;
      this.Time2 = DateTime.Now;
      this.Time = this.Time2.ToString();
      switch (new Random().Next(3))
      {
        case 0:
          this.Old = pos * 2;
          break;
        case 1:
          this.Year = pos * 2;
          break;
        case 2:
          this.Young = pos * 2;
          break;
      }
      this.Antenna = 12;
    }

    public PigeonCommand(byte[] bytes)
    {
      this._bytes = bytes;
      if (this._bytes.Length > 4)
        this.NoMoreRecords = bytes[4] == (byte) 5;
      if (this._bytes.Length <= 63)
        return;
      int num1 = 7;
      this.RaceIndex = (int) this._bytes[7 + num1];
      if (this.RaceIndex > 14)
        this.RaceIndex = -1;
      this.DBRing = Conversion.ByteArrayToString(this._bytes, 8 + num1, 4) + "-" + this._bytes[12 + num1].ToString().PadLeft(2, '0') + "-" + Conversion.ByteArrayToString(this._bytes, 13 + num1, 11) + " " + Conversion.ByteArrayToString(this._bytes, 24 + num1, 4);
      int num2 = 34 + num1;
      object[] objArray = new object[6];
      byte[] bytes1 = this._bytes;
      int index1 = num2;
      int num3 = index1 + 1;
      objArray[0] = (object) bytes1[index1].ToString("X").PadLeft(2, '0');
      byte[] bytes2 = this._bytes;
      int index2 = num3;
      int num4 = index2 + 1;
      objArray[1] = (object) bytes2[index2].ToString("X").PadLeft(2, '0');
      byte[] bytes3 = this._bytes;
      int index3 = num4;
      int num5 = index3 + 1;
      objArray[2] = (object) bytes3[index3].ToString("X").PadLeft(2, '0');
      byte[] bytes4 = this._bytes;
      int index4 = num5;
      int num6 = index4 + 1;
      objArray[3] = (object) bytes4[index4].ToString("X").PadLeft(2, '0');
      byte[] bytes5 = this._bytes;
      int index5 = num6;
      int num7 = index5 + 1;
      objArray[4] = (object) bytes5[index5].ToString("X").PadLeft(2, '0');
      byte[] bytes6 = this._bytes;
      int index6 = num7;
      int num8 = index6 + 1;
      objArray[5] = (object) bytes6[index6].ToString("X").PadLeft(2, '0');
      this.Time = string.Format("{2}/{1}/{0} {3}:{4}:{5}", objArray);
      try
      {
        this.Time2 = Convert.ToDateTime(this.Time, (IFormatProvider) new CultureInfo("nl-NL"));
      }
      catch (Exception ex)
      {
        this.Time2 = DateTime.MinValue;
      }
      this.Time = this.Time2.ToString();
      byte[] bytes7 = this._bytes;
      int index7 = num8;
      int num9 = index7 + 1;
      int num10 = (int) bytes7[index7];
      byte[] bytes8 = this._bytes;
      int index8 = num9;
      int num11 = index8 + 1;
      int num12 = (int) bytes8[index8] << 8;
      this.Old = num10 + num12;
      byte[] bytes9 = this._bytes;
      int index9 = num11;
      int num13 = index9 + 1;
      int num14 = (int) bytes9[index9];
      byte[] bytes10 = this._bytes;
      int index10 = num13;
      int num15 = index10 + 1;
      int num16 = (int) bytes10[index10] << 8;
      this.Year = num14 + num16;
      byte[] bytes11 = this._bytes;
      int index11 = num15;
      int num17 = index11 + 1;
      int num18 = (int) bytes11[index11];
      byte[] bytes12 = this._bytes;
      int index12 = num17;
      int num19 = index12 + 1;
      int num20 = (int) bytes12[index12] << 8;
      this.Young = num18 + num20;
      int num21 = num19 + 10;
      byte[] bytes13 = this._bytes;
      int index13 = num21;
      int num22 = index13 + 1;
      this.Antenna = (int) bytes13[index13] + 1;
      RaceDataSaver.FillInIfPossible(this);
    }

    public string ToEmailString(int totalPigeons)
    {
      string str1 = "";
      int num;
      if (this.Old > 0)
      {
        string str2 = str1;
        num = this.Old;
        string str3 = num.ToString();
        str1 = str2 + "O:" + str3;
      }
      if (this.Year > 0)
      {
        string str2 = str1;
        num = this.Year;
        string str3 = num.ToString();
        str1 = str2 + "X:" + str3;
      }
      if (this.Young > 0)
      {
        string str2 = str1;
        num = this.Young;
        string str3 = num.ToString();
        string str4 = str2 + "Y:" + str3;
      }
      return string.Format(ml.ml_string(1143, "{0}/{1}: {2} in {3} at {4} {5}  {6}m/min\r\n"), (object) this.Pos, (object) totalPigeons, (object) this.DBRing, (object) this.RaceName, (object) this.Time, (object) "", (object) Math.Round(this.Speed));
    }

    public string ToBriconWebString(int raceID, string clubID)
    {
      if (this.RaceIndex < 0)
        return "";
      StringBuilder stringBuilder1 = new StringBuilder();
      stringBuilder1.Append(this.IDInBriconWeb.ToString());
      stringBuilder1.Append("|");
      if (this.IDInBriconWeb == 0)
      {
        stringBuilder1.Append(raceID.ToString());
        stringBuilder1.Append("|");
        stringBuilder1.Append(this.DBRing);
        stringBuilder1.Append("|");
        StringBuilder stringBuilder2 = stringBuilder1;
        int num = this.Old;
        string str1 = num.ToString();
        stringBuilder2.Append(str1);
        stringBuilder1.Append("|");
        StringBuilder stringBuilder3 = stringBuilder1;
        num = this.Year;
        string str2 = num.ToString();
        stringBuilder3.Append(str2);
        stringBuilder1.Append("|");
        StringBuilder stringBuilder4 = stringBuilder1;
        num = this.Young;
        string str3 = num.ToString();
        stringBuilder4.Append(str3);
        stringBuilder1.Append("|");
        stringBuilder1.Append(this.Time2.ToString("yyyy-MM-dd HH:mm:ss"));
        stringBuilder1.Append("|");
        stringBuilder1.Append(this.Gummy);
        stringBuilder1.Append("|");
        stringBuilder1.Append(this.Wingmark);
        stringBuilder1.Append("|");
        stringBuilder1.Append(clubID);
        stringBuilder1.Append("|");
      }
      return stringBuilder1.ToString();
    }

    public void FromBriconWebString(string allPigeons)
    {
      string str1 = allPigeons;
      char[] chArray1 = new char[2]{ '\n', '\r' };
      foreach (string str2 in str1.Split(chArray1))
      {
        char[] chArray2 = new char[1]{ '|' };
        string[] strArray1 = str2.Split(chArray2);
        int num1 = 0;
        if (strArray1.Length >= 6)
        {
          string[] strArray2 = strArray1;
          int index1 = num1;
          int num2 = index1 + 1;
          if (strArray2[index1].TrimEnd(' ', 'V', 'H', 'F') == this.DBRing.TrimEnd(' ', 'V', 'H', 'F'))
          {
            string[] strArray3 = strArray1;
            int index2 = num2;
            int num3 = index2 + 1;
            this.IDInBriconWeb = Convert.ToInt32(strArray3[index2]);
            string[] strArray4 = strArray1;
            int index3 = num3;
            int num4 = index3 + 1;
            this.Distance = (double) Convert.ToInt32(strArray4[index3]);
            string[] strArray5 = strArray1;
            int index4 = num4;
            int num5 = index4 + 1;
            this.Speed2 = Convert.ToDouble(strArray5[index4], (IFormatProvider) CultureInfo.InvariantCulture);
            string[] strArray6 = strArray1;
            int index5 = num5;
            int num6 = index5 + 1;
            this.ArrivePositionClub = Convert.ToInt32(strArray6[index5]);
            string[] strArray7 = strArray1;
            int index6 = num6;
            int num7 = index6 + 1;
            this.ArrivePositionProvincial = Convert.ToInt32(strArray7[index6]);
            string[] strArray8 = strArray1;
            int index7 = num7;
            int num8 = index7 + 1;
            this.ArrivePositionNational = Convert.ToInt32(strArray8[index7]);
            string[] strArray9 = strArray1;
            int index8 = num8;
            int num9 = index8 + 1;
            this.ArrivePositionInternational = Convert.ToInt32(strArray9[index8]);
            string[] strArray10 = strArray1;
            int index9 = num9;
            int num10 = index9 + 1;
            this.EnterPositionClub = Convert.ToInt32(strArray10[index9]);
            string[] strArray11 = strArray1;
            int index10 = num10;
            int num11 = index10 + 1;
            this.EnterPositionProvincial = Convert.ToInt32(strArray11[index10]);
            string[] strArray12 = strArray1;
            int index11 = num11;
            int num12 = index11 + 1;
            this.EnterPositionNational = Convert.ToInt32(strArray12[index11]);
            string[] strArray13 = strArray1;
            int index12 = num12;
            int num13 = index12 + 1;
            this.EnterPositionInternational = Convert.ToInt32(strArray13[index12]);
            break;
          }
        }
      }
    }

    public override string ToString() => string.Format(ml.ml_string(1134, "Clocked Pigeon ") + this.DBRing + ml.ml_string(1135, " received."));

    public int Pos { get; set; }

    public string DBRing { get; set; }

    public string Time { get; private set; }

    public DateTime Time2 { get; set; }

    public string RaceName { get; set; }

    public int RaceIndex { get; set; }

    public int Old { get; private set; }

    public int Year { get; private set; }

    public int Young { get; private set; }

    public int Antenna { get; private set; }

    public double Speed { get; set; }

    public double Distance { get; private set; }

    public double Speed2 { get; private set; }

    public int ArrivePositionClub { get; private set; }

    public int ArrivePositionProvincial { get; private set; }

    public int ArrivePositionNational { get; private set; }

    public int ArrivePositionInternational { get; private set; }

    public int EnterPositionClub { get; private set; }

    public int EnterPositionProvincial { get; private set; }

    public int EnterPositionNational { get; private set; }

    public int EnterPositionInternational { get; private set; }

    public int IDInBriconWeb { get; private set; }

    public string Gummy { get; set; }

    public string Wingmark { get; set; }

    public bool SendedToExtenalParties { get; set; }

    public bool SendedToPigeonCloud { get; set; }

    public bool SendedToCompuClub { get; set; }
  }
}
