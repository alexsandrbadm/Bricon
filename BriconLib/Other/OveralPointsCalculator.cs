// Decompiled with JetBrains decompiler
// Type: BriconLib.Other.OveralPointsCalculator
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Other
{
  public class OveralPointsCalculator
  {
    public static Decimal CalcOveralPoints(int position, Decimal distanceInKm)
    {
      Decimal num1;
      Decimal num2;
      if (distanceInKm < 250M)
      {
        num1 = 100M;
        num2 = 100M;
      }
      else if (distanceInKm < 600M)
      {
        num1 = 100M;
        num2 = 200M;
      }
      else
      {
        num1 = 100M;
        num2 = 300M;
      }
      if ((Decimal) position > num1 || position < 1)
        return 0M;
      Decimal num3 = num2 / num1;
      Decimal num4 = num2;
      Decimal num5 = (num4 - num3) / (num1 - 1M);
      return Math.Round(num4 - (Decimal) (position - 1) * num5, 2);
    }
  }
}
