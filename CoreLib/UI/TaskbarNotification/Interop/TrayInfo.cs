// Decompiled with JetBrains decompiler
// Type: CoreLib.UI.TaskbarNotification.Interop.TrayInfo
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System.Drawing;

namespace CoreLib.UI.TaskbarNotification.Interop
{
  public static class TrayInfo
  {
    public static Point GetTrayLocation()
    {
      AppBarInfo appBarInfo = new AppBarInfo();
      appBarInfo.GetSystemTaskBarPosition();
      Rectangle workArea = appBarInfo.WorkArea;
      int num1 = 0;
      int num2 = 0;
      if (appBarInfo.Edge == AppBarInfo.ScreenEdge.Left)
      {
        num1 = workArea.Left + 2;
        num2 = workArea.Bottom;
      }
      else if (appBarInfo.Edge == AppBarInfo.ScreenEdge.Bottom)
      {
        num1 = workArea.Right;
        num2 = workArea.Bottom;
      }
      else if (appBarInfo.Edge == AppBarInfo.ScreenEdge.Top)
      {
        num1 = workArea.Right;
        num2 = workArea.Top;
      }
      else if (appBarInfo.Edge == AppBarInfo.ScreenEdge.Right)
      {
        num1 = workArea.Right;
        num2 = workArea.Bottom;
      }
      return new Point() { X = num1, Y = num2 };
    }
  }
}
