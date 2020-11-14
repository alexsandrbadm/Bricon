// Decompiled with JetBrains decompiler
// Type: HexEncoding
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.Globalization;

public class HexEncoding
{
  public static int GetByteCount(string hexString)
  {
    int num = 0;
    for (int index = 0; index < hexString.Length; ++index)
    {
      if (HexEncoding.IsHexDigit(hexString[index]))
        ++num;
    }
    if (num % 2 != 0)
      --num;
    return num / 2;
  }

  public static byte[] GetBytes(string hexString)
  {
    int discarded = 0;
    return HexEncoding.GetBytes(hexString, out discarded);
  }

  public static byte[] GetBytes(string hexString, out int discarded)
  {
    discarded = 0;
    string str = "";
    for (int index = 0; index < hexString.Length; ++index)
    {
      char c = hexString[index];
      if (HexEncoding.IsHexDigit(c))
        str += c.ToString();
      else
        ++discarded;
    }
    if (str.Length % 2 != 0)
    {
      ++discarded;
      str = str.Substring(0, str.Length - 1);
    }
    byte[] numArray = new byte[str.Length / 2];
    int index1 = 0;
    for (int index2 = 0; index2 < numArray.Length; ++index2)
    {
      string hex = new string(new char[2]
      {
        str[index1],
        str[index1 + 1]
      });
      numArray[index2] = HexEncoding.HexToByte(hex);
      index1 += 2;
    }
    return numArray;
  }

  public static string ToString(byte[] bytes) => HexEncoding.ToString(bytes, bytes.Length);

  public static string ToString(byte[] bytes, int length) => HexEncoding.ToString(bytes, 0, length);

  public static string ToString(byte[] bytes, int offset, int length)
  {
    string str = "";
    for (int index = offset; index < offset + length; ++index)
      str += bytes[index].ToString("X2");
    return str;
  }

  public static bool InHexFormat(string hexString)
  {
    bool flag = true;
    foreach (char c in hexString)
    {
      if (!HexEncoding.IsHexDigit(c))
      {
        flag = false;
        break;
      }
    }
    return flag;
  }

  public static bool IsHexDigit(char c)
  {
    int int32_1 = Convert.ToInt32('A');
    int int32_2 = Convert.ToInt32('0');
    c = char.ToUpper(c);
    int int32_3 = Convert.ToInt32(c);
    return int32_3 >= int32_1 && int32_3 < int32_1 + 6 || int32_3 >= int32_2 && int32_3 < int32_2 + 10;
  }

  private static byte HexToByte(string hex) => hex.Length <= 2 && hex.Length > 0 ? byte.Parse(hex, NumberStyles.HexNumber) : throw new ArgumentException("hex must be 1 or 2 characters in length");
}
