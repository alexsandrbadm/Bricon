// Decompiled with JetBrains decompiler
// Type: BriconLib.Other.DistanceCalculator
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Other
{
  internal class DistanceCalculator
  {
    private static double ConvertCoordToRadians(int coord)
    {
      double num1 = (double) coord / 10.0;
      double num2 = num1 > 0.0 ? 1.0 : -1.0;
      double num3 = num1 * num2;
      double num4 = (double) (int) (num3 / 10000.0) * num2;
      double num5 = ((double) (int) (num3 / 100.0) / 100.0 - (double) (int) ((double) (int) (num3 / 100.0) / 100.0)) * 100.0 * num2;
      double num6 = (num3 / 100.0 - (double) (int) (num3 / 100.0)) * 100.0 * num2;
      double num7 = num5 / 60.0;
      return (num4 + num7 + num6 / 3600.0) * Math.PI / 180.0;
    }

    public static int CalculateDistance(
      int coordXFrom,
      int coordYFrom,
      int coordXTo,
      int coordYTo)
    {
      if (!Utils.IsCountry("BE"))
      {
        coordXFrom /= 10;
        coordYFrom /= 10;
        coordXTo /= 10;
        coordYTo /= 10;
      }
      double radians1 = DistanceCalculator.ConvertCoordToRadians(coordXFrom);
      double radians2 = DistanceCalculator.ConvertCoordToRadians(coordYFrom);
      double radians3 = DistanceCalculator.ConvertCoordToRadians(coordXTo);
      double radians4 = DistanceCalculator.ConvertCoordToRadians(coordYTo);
      double num1 = 0.99664718933525;
      double num2 = 6378137.0;
      double d1 = (radians1 + radians3) / 2.0;
      double num3 = radians4 - radians2;
      double num4 = Math.Sqrt(1.0 + 0.0067394967422767 * Math.Pow(Math.Cos(d1), 2.0));
      double d2 = num4 * num3;
      double num5 = Math.Atan(num1 * Math.Tan(radians1));
      double num6 = Math.Atan(num1 * Math.Tan(radians3));
      double x = Math.Sin(num5) * Math.Sin(num6) + Math.Cos(num5) * Math.Cos(num6) * Math.Cos(d2);
      return Convert.ToInt32(num2 / num4 * (Math.Atan(-x / Math.Sqrt(1.0 - Math.Pow(x, 2.0))) + 2.0 * Math.Atan(1.0)));
    }
  }
}
