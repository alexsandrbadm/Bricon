// Decompiled with JetBrains decompiler
// Type: CoreLib.UI.TaskbarNotification.Interop.IconDataMembers
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace CoreLib.UI.TaskbarNotification.Interop
{
  [Flags]
  public enum IconDataMembers
  {
    Message = 1,
    Icon = 2,
    Tip = 4,
    State = 8,
    Info = 16, // 0x00000010
    Realtime = 64, // 0x00000040
    UseLegacyToolTips = 128, // 0x00000080
  }
}
