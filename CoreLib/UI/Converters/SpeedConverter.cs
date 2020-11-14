// Decompiled with JetBrains decompiler
// Type: CoreLib.UI.Converters.SpeedConverter
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.Globalization;
using System.Windows.Data;

namespace CoreLib.UI.Converters
{
  public class SpeedConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value == null ? (object) "" : (object) string.Format("{0}m/min", (object) Math.Round((double) value, 2));

    public object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
