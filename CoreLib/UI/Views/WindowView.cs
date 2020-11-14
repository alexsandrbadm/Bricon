// Decompiled with JetBrains decompiler
// Type: CoreLib.UI.Views.WindowView
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System.Reflection;
using System.Windows;

namespace CoreLib.UI.Views
{
  public class WindowView : Window
  {
    public WindowView()
    {
      MethodInfo method = this.GetType().GetMethod("InitializeComponent", BindingFlags.Instance | BindingFlags.Public);
      if (!(method != (MethodInfo) null))
        return;
      method.Invoke((object) this, new object[0]);
    }
  }
}
