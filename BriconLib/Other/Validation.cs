// Decompiled with JetBrains decompiler
// Type: BriconLib.Other.Validation
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Properties;
using System;

namespace BriconLib.Other
{
  internal class Validation
  {
    public static bool ElRing(string text)
    {
      if (text == null || text.Length != 8 || (Utils.IsCountry("HU") || Utils.IsCountry("RO") || Utils.IsCountry("MD")) && !text.ToUpper().StartsWith("C5"))
        return false;
      foreach (char c in text)
      {
        if (!char.IsDigit(c) && (c < 'A' || c > 'F') && (c < 'a' || c > 'f'))
          return false;
      }
      return true;
    }

    public static DateTime MakeDateTime(string incompleteDate, DateTime previousDate) => previousDate;

    public static string MakeDBRing(string incompleteRing, string previousRing)
    {
      if (Validation.RingType == Validation.RingTypes.PLRing)
        return incompleteRing;
      int num = 13;
      if (Utils.IsCountry("CZ") || Utils.IsCountry("SK"))
        num = 12;
      if (Validation.RingType == Validation.RingTypes.UKRing || Validation.RingType == Validation.RingTypes.HURing || Validation.RingType == Validation.RingTypes.PLRing)
      {
        num = 17;
        int startIndex = incompleteRing.IndexOf('-');
        if ((startIndex == -1 ? -1 : incompleteRing.IndexOf('-', startIndex)) != -1 && Validation.RingType != Validation.RingTypes.PLRing)
        {
          switch (startIndex)
          {
            case 2:
              incompleteRing = "  " + incompleteRing;
              break;
            case 3:
              incompleteRing = " " + incompleteRing;
              break;
          }
          while (incompleteRing.Length < num && incompleteRing.Length > 8)
            incompleteRing = incompleteRing.Substring(0, 8) + " " + incompleteRing.Substring(8);
        }
      }
      if (incompleteRing.Length <= num && incompleteRing.Length > 0 && Validation.DBRing(previousRing))
      {
        string text = previousRing.Substring(0, previousRing.Length - incompleteRing.Length) + incompleteRing;
        if (Validation.DBRing(text))
          return text;
      }
      return incompleteRing;
    }

    public static string GetRingSample()
    {
      string str1 = (DateTime.Now.Year - 2000).ToString("D2");
      string str2 = Settings.Default.Country + ("-" + str1 + "-");
      switch (Settings.Default.Country)
      {
        case "AU":
        case "HU":
        case "MX":
        case "SA":
        case "US":
          return str2 + "AB1234567";
        case "BE":
        case "BG":
        case "ES":
        case "FR":
        case "GR":
        case "IQ":
        case "LU":
        case "MD":
        case "NL":
        case "PT":
        case "RN":
        case "RO":
        case "TR":
        case "TW":
          return str2 + "1234567";
        case "CZ":
        case "SK":
          return str2 + "-1234-1234";
        case "DE":
          return "DV-" + str1 + "-12345-12345";
        case "FI":
          return "FIN-" + str1 + "-ABC123456";
        case "IN":
        case "JP":
          return str2 + "ABC123456";
        case "KSA":
          return "KSA-" + str1 + "-1234567";
        case "NZ":
          return str2 + "ABC12345";
        case "PL":
          return str2 + "-1234-123456";
        case "UK":
          return string.IsNullOrWhiteSpace(Settings.Default.Union) ? "GB-" + str1 + "-AB123456" : Settings.Default.Union + "-" + str1 + "-AB123456";
        default:
          return "";
      }
    }

    public static Validation.RingTypes RingType
    {
      get
      {
        if (Utils.IsCountry("ES"))
          return Validation.RingTypes.ShortES;
        if (Utils.IsCountry("KSA") || Utils.IsCountry("IQ") || Utils.IsCountry("RN"))
          return Validation.RingTypes.ShortWithLongCountry;
        if (Utils.IsCountry("LT") || Utils.IsCountry("CR") || (Utils.IsCountry("SR") || Utils.IsCountry("TR")))
          return Validation.RingTypes.LongWithoutColor;
        if (Utils.IsCountry("RU") || Utils.IsCountry("UA"))
          return Validation.RingTypes.LongWithColor;
        if (Utils.IsCountry("HU") || Utils.IsCountry("RO") || Utils.IsCountry("MD"))
          return Validation.RingTypes.HURing;
        if (Utils.IsCountry("CZ") || Utils.IsCountry("SK") || Utils.IsCountry("PL"))
          return Validation.RingTypes.PLRing;
        return Utils.IsUKProtocol() && !Utils.IsCountry("PT") && !Utils.IsCountry("ES") ? Validation.RingTypes.UKRing : Validation.RingTypes.Short;
      }
    }

    public static bool DBRing(string text)
    {
      if (text == null)
        return false;
      bool flag1 = false;
      bool flag2 = false;
      int index1 = 2;
      if (Validation.RingType == Validation.RingTypes.UKRing || Validation.RingType == Validation.RingTypes.HURing)
      {
        index1 = 4;
        if (text.Length != 17)
          return false;
        flag1 = true;
      }
      if (Validation.RingType == Validation.RingTypes.HURing)
        flag2 = true;
      if (Validation.RingType == Validation.RingTypes.PLRing)
        return text.Length > 10;
      if (Validation.RingType == Validation.RingTypes.ShortES && text.Length != index1 + 10 || (Validation.RingType == Validation.RingTypes.Short || Validation.RingType == Validation.RingTypes.ShortWithLongCountry) && text.Length != index1 + 11)
        return false;
      if (Validation.RingType == Validation.RingTypes.LongWithColor)
      {
        if (text.Length < 12)
          return false;
        flag1 = true;
      }
      if (Validation.RingType == Validation.RingTypes.LongWithoutColor)
      {
        if (text.Length < 7)
          return false;
        flag1 = true;
        if (Utils.IsCountry("CZ") || Utils.IsCountry("SK"))
          flag2 = true;
      }
      if (text[0] != '0' && text[1] != '0')
      {
        for (int index2 = 0; index2 < index1; ++index2)
        {
          if (Validation.RingType != Validation.RingTypes.UKRing && Validation.RingType != Validation.RingTypes.HURing && Validation.RingType != Validation.RingTypes.PLRing)
          {
            if (!char.IsLetter(text[index2]) && text[1] != ' ')
              return false;
          }
          else if (!char.IsLetter(text[index2]) && !char.IsDigit(text[index2]) && text[index2] != ' ')
            return false;
        }
      }
      if (text[index1] != '-' && Validation.RingType != Validation.RingTypes.ShortWithLongCountry)
        return false;
      int index3 = index1 + 1;
      if (!char.IsDigit(text[index3]) || !char.IsDigit(text[index3 + 1]) || text[index3 + 2] != '-')
        return false;
      for (int index2 = index3 + 3; index2 < text.Length; ++index2)
      {
        if (flag1)
        {
          if (!char.IsDigit(text[index2]) && !char.IsLetter(text[index2]) && text[index2] != ' ' && (!flag2 || text[index2] != '-'))
            return false;
        }
        else if (!char.IsDigit(text[index2]) && (!flag2 || text[index2] != '-'))
          return false;
      }
      return true;
    }

    public static bool Pincode(string text)
    {
      if (text == null || text.Length != 6)
        return false;
      foreach (char c in text)
      {
        if (!char.IsDigit(c))
          return false;
      }
      return true;
    }

    public static bool License(string text)
    {
      if (text == null)
        return false;
      text = Conversion.StripLicense(text);
      if (text.Length > 10)
        return false;
      if (Utils.IsCountry("HU") || Utils.IsCountry("RO") || (Utils.IsCountry("MD") || Utils.IsCountry("KV")))
      {
        if (text.Length != 10)
          return false;
        int num = 0;
        foreach (char c in text)
        {
          if (num != 2 && !char.IsDigit(c) || num == 2 && !char.IsLetterOrDigit(c) && c != ' ')
            return false;
          ++num;
        }
      }
      if (Utils.IsCountry("UK") || Utils.IsCountry("IR"))
      {
        if (text.Length != 7)
          return false;
        int num = 0;
        foreach (char c in text)
        {
          if (num >= 2 && !char.IsDigit(c) || num < 2 && !char.IsLetterOrDigit(c) && c != ' ')
            return false;
          ++num;
        }
      }
      if ((Utils.IsCountry("FR") || Utils.IsCountry("GR")) && text.Length != 8)
        return false;
      if (Utils.IsCountry("NL") || Utils.IsCountry("BE"))
      {
        if (text.Length != 8)
          return false;
        foreach (char c in text)
        {
          if (!char.IsDigit(c))
            return false;
        }
      }
      if (Utils.IsCountry("BE"))
      {
        if (Convert.ToInt32(text.Substring(0, 6)) % 97 != Convert.ToInt32(text.Substring(6, 2)))
          return false;
      }
      return true;
    }

    public static bool ClubID(string text)
    {
      if (text == null || text.Length != 4)
        return false;
      foreach (char c in text)
      {
        if (!char.IsDigit(c))
          return false;
      }
      return true;
    }

    public static bool FlightID(string text)
    {
      if (text == null || text.Length != 4)
        return false;
      foreach (char c in text)
      {
        if (!char.IsDigit(c) && !char.IsLetter(c))
          return false;
      }
      return true;
    }

    public enum RingTypes
    {
      Short,
      ShortES,
      ShortWithLongCountry,
      LongWithoutColor,
      LongWithColor,
      UKRing,
      HURing,
      PLRing,
    }
  }
}
