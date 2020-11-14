// Decompiled with JetBrains decompiler
// Type: BriconLib.Annotations.MacroAttribute
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Annotations
{
  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true)]
  public sealed class MacroAttribute : Attribute
  {
    [CanBeNull]
    public string Expression { get; set; }

    public int Editable { get; set; }

    [CanBeNull]
    public string Target { get; set; }
  }
}
