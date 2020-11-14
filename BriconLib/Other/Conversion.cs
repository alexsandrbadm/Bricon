// Decompiled with JetBrains decompiler
// Type: BriconLib.Other.Conversion
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Properties;
using MultiLang;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace BriconLib.Other
{
  public abstract class Conversion
  {
    private static Dictionary<ulong, byte> _map;
    private static Dictionary<byte, ulong> _mapRev;

    public static string ByteArrayToString(byte[] ba) => Conversion.ByteArrayToString(ba, 0, ba.Length);

    public static string ByteArrayToString(byte[] ba, int start, int length) => Conversion.ByteArrayToString(ba, start, length, true);

    public static string ByteArrayToString(byte[] ba, int start, int length, bool trim)
    {
      StringBuilder stringBuilder = new StringBuilder(length);
      bool flag = false;
      for (int index = 0; index < length && start + index < ba.Length; ++index)
      {
        if (ba[start + index] == (byte) 0)
          flag = true;
        if (flag)
          stringBuilder.Append(' ');
        else
          stringBuilder.Append((char) ba[start + index]);
      }
      return trim ? stringBuilder.ToString().Trim() : stringBuilder.ToString();
    }

    public static byte[] StringToByteArray(string str, int length) => Conversion.StringToByteArray(str, length, (byte) 0);

    public static byte[] StringToByteArray(string str, int length, byte fillChar)
    {
      byte[] numArray = new byte[length];
      int index;
      for (index = 0; index < str.Length && index < length; ++index)
        numArray[index] = (byte) str[index];
      for (; index < length; ++index)
        numArray[index] = fillChar;
      return numArray;
    }

    public static int CoordinateToInt(string coordinate)
    {
      string str = "0";
      if (!Utils.IsCountry("BE") && (coordinate.IndexOf(",") == coordinate.Length - 2 || coordinate.IndexOf(".") == coordinate.Length - 2))
        coordinate += "0";
      foreach (char c in coordinate)
      {
        if (char.IsDigit(c) || c == '-')
          str += c.ToString();
      }
      try
      {
        return Convert.ToInt32(str.TrimStart('0'));
      }
      catch (Exception ex)
      {
        return 0;
      }
    }

    public static string CoordinateToString(int coordinate, bool insertSemicolons)
    {
      bool flag = false;
      int num = !Utils.IsCountry("BE") ? 1 : 0;
      if (coordinate < 0)
      {
        coordinate *= -1;
        flag = true;
      }
      if (num == 0)
      {
        string str = coordinate.ToString().PadLeft(7, '0');
        if (!insertSemicolons)
          return str;
        return str.Substring(0, 2) + ":" + str.Substring(2, 2) + ":" + str.Substring(4, 2) + "," + str.Substring(6, 1);
      }
      if (coordinate > 99999999)
      {
        string str = coordinate.ToString().PadLeft(9, '0');
        return insertSemicolons ? str.Substring(0, 3) + " " + str.Substring(3, 2) + " " + str.Substring(5, 2) + "." + str.Substring(7, 2) : str.Substring(0, 3) + str.Substring(3, 2) + str.Substring(5, 2) + "." + str.Substring(7, 2);
      }
      string str1 = coordinate.ToString().PadLeft(8, '0');
      string str2;
      if (insertSemicolons)
        str2 = str1.Substring(0, 2) + " " + str1.Substring(2, 2) + " " + str1.Substring(4, 2) + "." + str1.Substring(6, 2);
      else
        str2 = str1.Substring(0, 2) + str1.Substring(2, 2) + str1.Substring(4, 2) + "." + str1.Substring(6, 2);
      return flag ? "-" + str2 : "+" + str2;
    }

    public static string CoordinateToString(string coordinate, bool insertSemicolons) => Conversion.CoordinateToString(Conversion.CoordinateToInt(coordinate), insertSemicolons);

    public static string SerialFromVersionMaster(string version) => version.ToUpper().StartsWith("BRICON") ? "BRICON" + version.Substring(version.Length - 8) : version;

    public static string SerialFromVersion(string version, byte BAAddress)
    {
      if (version.ToUpper().StartsWith("CMB") && version.Length > 9)
        return "COMBO" + version.Substring(3, 6);
      if (version.ToUpper().StartsWith("SPD") && version.Length > 9)
        return "SPEEDY" + version.Substring(0, 9);
      if (version.ToUpper().StartsWith("SPX") && version.Length > 9)
        return "SPEEDY-XTREME" + version.Substring(3, 6);
      if (version.ToUpper().StartsWith("BRX") && version.Length >= 8)
        return "X-TREME" + version.Substring(3, 6);
      if (version.ToUpper().StartsWith("ROMANI ") && version.Length > 7)
        return "LITTLE" + version.Substring(7, 8);
      string[] strArray = version.Split(' ');
      if (strArray.Length >= 3 && version.ToUpper().Contains("BRICON"))
        return "BRICON" + strArray[strArray.Length - 1];
      if (version.ToUpper().StartsWith("BRICON"))
        return "BRICON" + version.Substring(version.Length - 8);
      if (version.ToUpper().StartsWith("MEGA") && version.Length > 9 && version.Contains("SN"))
        return "MEGA" + version.Substring(version.IndexOf("SN"));
      if (BAAddress == (byte) 132 && version.Contains("M"))
        return "TIPES" + version.Substring(version.IndexOf("M"));
      if (version.ToUpper().StartsWith("TAU") && version.Contains("-"))
        return "TAURIS" + version.Substring(version.LastIndexOf("-"));
      if (version.ToUpper().StartsWith("UNI") && version.Contains("/"))
      {
        version = version.Substring(0, version.IndexOf("/"));
        return "UNIKON" + version.Substring(version.LastIndexOf(" "));
      }
      if (version.ToUpper().StartsWith("BENZ") && version.Length > 10)
        return "BENZING" + version.Substring(version.Length - 6);
      MessageDisplayer messageDisplayer = new MessageDisplayer(ml.ml_string(313, "Serial could not be retrieved from response '") + version + "'");
      return version;
    }

    public static string StripLicense(string licenseWithSeperators)
    {
      if (licenseWithSeperators == null)
        return string.Empty;
      return Settings.Default.Country.Equals("NL", StringComparison.InvariantCultureIgnoreCase) || Settings.Default.Country.Equals("BE", StringComparison.InvariantCultureIgnoreCase) ? licenseWithSeperators.Replace("/", "").Replace("-", "") : licenseWithSeperators;
    }

    public static string MakeLicense(string licenseWithoutSeperators)
    {
      if (licenseWithoutSeperators == null)
        return string.Empty;
      if (!Validation.License(licenseWithoutSeperators))
        return licenseWithoutSeperators;
      licenseWithoutSeperators = Conversion.StripLicense(licenseWithoutSeperators);
      if (Settings.Default.Country.Equals("NL", StringComparison.InvariantCultureIgnoreCase))
        return licenseWithoutSeperators.Substring(0, 4) + "-" + licenseWithoutSeperators.Substring(4, 4);
      return Settings.Default.Country.Equals("BE", StringComparison.InvariantCultureIgnoreCase) ? licenseWithoutSeperators.Substring(0, 6) + "/" + licenseWithoutSeperators.Substring(6, 2) : licenseWithoutSeperators;
    }

    public static DateTime DateTimeFromStrings(string date, string time)
    {
      try
      {
        return date == "      " || time == "      " || (date == "000000" || time == "000000") || (date.Length != 6 || time.Length != 6) ? DateTime.MinValue : new DateTime(2000 + Convert.ToInt32(date.Substring(4, 2)), Convert.ToInt32(date.Substring(2, 2)), Convert.ToInt32(date.Substring(0, 2)), Convert.ToInt32(time.Substring(0, 2)), Convert.ToInt32(time.Substring(2, 2)), Convert.ToInt32(time.Substring(4, 2)));
      }
      catch (Exception ex)
      {
        return DateTime.MinValue;
      }
    }

    public static string DifferenceToString(int differenceInSeconds)
    {
      string str;
      if (differenceInSeconds >= 0)
      {
        str = "+";
      }
      else
      {
        str = "-";
        differenceInSeconds *= -1;
      }
      return str + ((char) (differenceInSeconds % 600 / 60 + 48)).ToString() + ((char) (differenceInSeconds % 60 / 10 + 48)).ToString() + ((char) (differenceInSeconds % 10 + 48)).ToString();
    }

    public static char IsValidUnicode(char ch)
    {
      if (!Utils.IsCountry("JP"))
        return ch;
      Conversion.FillMap();
      return ch < 'Ā' || Conversion._map.ContainsKey(Convert.ToUInt64(ch)) ? ch : '?';
    }

    private static void FillMap()
    {
      if (Conversion._map != null)
        return;
      Conversion._map = new Dictionary<ulong, byte>();
      Conversion._mapRev = new Dictionary<byte, ulong>();
      try
      {
        string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Unicode.txt";
        if (!File.Exists(path))
          return;
        foreach (string readAllLine in File.ReadAllLines(path))
        {
          string[] separator = new string[2]{ "->0x", "->" };
          string[] strArray = readAllLine.Split(separator, StringSplitOptions.RemoveEmptyEntries);
          if (strArray.Length == 2)
          {
            ulong key1 = ulong.Parse(strArray[0], NumberStyles.HexNumber);
            byte key2 = byte.Parse(strArray[1], NumberStyles.HexNumber);
            Conversion._map.Add(key1, key2);
            if (!Conversion._mapRev.ContainsKey(key2))
              Conversion._mapRev.Add(key2, key1);
          }
          else
          {
            int num = (int) MessageBox.Show("Invalid line in Unicode.txt (should be ABCD->0xAB: " + readAllLine);
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error in Unicode.txt : " + ex.ToString());
      }
    }

    public static string FromUnicode(string text)
    {
      if (!Utils.IsCountry("JP"))
        return text;
      Conversion.FillMap();
      string str = "";
      foreach (char ch in text)
      {
        ulong uint64 = Convert.ToUInt64(ch);
        str = !Conversion._map.ContainsKey(uint64) ? str + ch.ToString() : str + Convert.ToChar(Conversion._map[uint64]).ToString();
      }
      return str;
    }

    public static string ToUnicode(string text)
    {
      if (!Utils.IsCountry("JP"))
        return text;
      Conversion.FillMap();
      string str = "";
      foreach (char ch in text)
      {
        byte key = Convert.ToByte(ch);
        str = !Conversion._mapRev.ContainsKey(key) ? str + ch.ToString() : str + Convert.ToChar(Conversion._mapRev[key]).ToString();
      }
      return str;
    }
  }
}
