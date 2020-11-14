// Decompiled with JetBrains decompiler
// Type: BriconLib.Other.Utils
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Properties;
using System;
using System.IO;
using System.Reflection;

namespace BriconLib.Other
{
  internal class Utils
  {
    public static bool IsPasActive() => Utils.IsCountry("NL");

    public static bool IsPasActiveAndOk() => Utils.IsPasActive() && Settings.Default.PASOk;

    public static bool IsCountry(string countryCode) => Settings.Default.Country.Equals(countryCode, StringComparison.InvariantCultureIgnoreCase);

    public static bool EncryptReadouts() => Settings.Default.CryptBCEReadoutFiles;

    public static bool IsInternationaal() => Utils.IsCountry("AU") || Utils.IsCountry("US") || (Utils.IsCountry("HU") || Utils.IsCountry("RO")) || (Utils.IsCountry("MD") || Utils.IsCountry("CZ") || (Utils.IsCountry("SK") || Utils.IsCountry("TS"))) || Utils.IsCountry("MX") || Utils.IsCountry("NZ");

    public static bool IsUKProtocol() => Utils.IsCountry("IN") || Utils.IsCountry("KV") || (Utils.IsCountry("UK") || Utils.IsCountry("PL")) || (Utils.IsCountry("HU") || Utils.IsCountry("RO") || (Utils.IsCountry("MD") || Utils.IsCountry("JP"))) || (Utils.IsCountry("AU") || Utils.IsCountry("IR") || (Utils.IsCountry("SA") || Utils.IsCountry("SK")) || (Utils.IsCountry("TS") || Utils.IsCountry("CZ") || (Utils.IsCountry("NZ") || Utils.IsCountry("MX")))) || (Utils.IsCountry("US") || Utils.IsCountry("ES") || Utils.IsCountry("PT")) || Utils.IsCountry("FI");

    public static bool UseCoordinatesInsteadOfDistance() => !Utils.IsCountry("UK") && !Utils.IsCountry("IR");

    public static string UnitsUsed() => Utils.IsCountry("UK") || Utils.IsCountry("IR") ? "Imperial" : "Metric";

    public static string GetDistanceString(Decimal miles, Decimal yards) => miles.ToString() + "m " + yards.ToString() + "y";

    public static string GetDistanceString(Decimal distance)
    {
      if (!(Utils.UnitsUsed() == "Imperial"))
        return Math.Round(distance, 3).ToString("N3");
      Decimal d = Math.Round(distance, 4);
      Decimal num = distance * 1760M;
      Decimal miles = Math.Truncate(d);
      Decimal yards = Math.Truncate(num - miles * 1760M + 0.5M);
      return Utils.GetDistanceString(miles, yards);
    }

    internal static bool IsFarEast() => Utils.IsCountry("JP") || Utils.IsCountry("AU") || Utils.IsCountry("NZ");

    public static void LogErrorToBWLog(string text) => File.AppendAllText("briconwebErrors.log", Environment.NewLine + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ":" + text);

    public static bool IsBeta() => Path.GetFileName(Assembly.GetEntryAssembly().Location).Contains("_Beta");
  }
}
