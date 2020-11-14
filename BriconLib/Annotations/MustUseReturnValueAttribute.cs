// Decompiled with JetBrains decompiler
// Type: BriconLib.Annotations.MustUseReturnValueAttribute
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Annotations
{
  [AttributeUsage(AttributeTargets.Method)]
  public sealed class MustUseReturnValueAttribute : Attribute
  {
    public MustUseReturnValueAttribute()
    {
    }

    public MustUseReturnValueAttribute([NotNull] string justification) => this.Justification = justification;

    [CanBeNull]
    public string Justification { get; private set; }
  }
}
