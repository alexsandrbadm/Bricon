﻿// Decompiled with JetBrains decompiler
// Type: CoreLib.UI.TaskbarNotification.Interop.BalloonFlags
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

namespace CoreLib.UI.TaskbarNotification.Interop
{
  public enum BalloonFlags
  {
    None = 0,
    Info = 1,
    Warning = 2,
    Error = 3,
    User = 4,
    NoSound = 16, // 0x00000010
    LargeIcon = 32, // 0x00000020
    RespectQuietTime = 128, // 0x00000080
  }
}
