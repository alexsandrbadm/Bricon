// Decompiled with JetBrains decompiler
// Type: BriconLib.Annotations.AspMvcActionAttribute
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Annotations
{
  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter)]
  public sealed class AspMvcActionAttribute : Attribute
  {
    public AspMvcActionAttribute()
    {
    }

    public AspMvcActionAttribute([NotNull] string anonymousProperty) => this.AnonymousProperty = anonymousProperty;

    [CanBeNull]
    public string AnonymousProperty { get; private set; }
  }
}
