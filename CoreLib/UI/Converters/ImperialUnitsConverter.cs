// Decompiled with JetBrains decompiler
// Type: CoreLib.UI.Converters.ImperialUnitsConverter
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using CoreLib.UI.App;
using System;
using System.Globalization;
using System.Windows.Data;

namespace CoreLib.UI.Converters
{
  public class ImperialUnitsConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      int num1 = (int) value;
      if (!ApplicationHelper.IsImperial())
        return (object) string.Format("{0}m", (object) num1);
      int num2;
      int int32 = System.Convert.ToInt32(((double) (num2 = (int) ((double) num1 * 0.00062137)) - (double) num2) * 1760.0);
      return (object) string.Format("{0}m{1}y", (object) num2, (object) int32);
    }

    public object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      string str = value as string;
      if (string.IsNullOrWhiteSpace(str))
        return (object) 0;
      string lower = str.ToLower();
      if (ApplicationHelper.IsImperial())
      {
        if (!lower.Contains("m") || !lower.Contains("y"))
          return (object) 0;
        int result1;
        if (!int.TryParse(lower.Substring(0, lower.IndexOf("m", StringComparison.InvariantCulture)), out result1))
          return (object) 0;
        int result2;
        if (!int.TryParse(lower.Substring(lower.IndexOf("m", StringComparison.InvariantCulture) + 1).Replace("y", ""), out result2))
          return (object) 0;
        return result2 < 0 || result2 >= 1760 ? (object) 0 : (object) System.Convert.ToInt32(((double) result1 + (double) result2 / 1760.0) / 0.00062137);
      }
      string s = lower.Replace("m", "").Replace(" ", "");
      int result = 0;
      return int.TryParse(s, out result) ? (object) result : (object) 0;
    }
  }
}
