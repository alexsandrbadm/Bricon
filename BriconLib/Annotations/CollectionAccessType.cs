// Decompiled with JetBrains decompiler
// Type: BriconLib.Annotations.CollectionAccessType
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Annotations
{
  [Flags]
  public enum CollectionAccessType
  {
    None = 0,
    Read = 1,
    ModifyExistingContent = 2,
    UpdatedContent = 6,
  }
}
