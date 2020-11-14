// Decompiled with JetBrains decompiler
// Type: CoreLib.UI.TaskbarNotification.Interop.WindowProcedureHandler
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace CoreLib.UI.TaskbarNotification.Interop
{
  public delegate long WindowProcedureHandler(IntPtr hwnd, uint uMsg, uint wparam, uint lparam);
}
