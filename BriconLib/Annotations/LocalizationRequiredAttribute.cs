// Decompiled with JetBrains decompiler
// Type: BriconLib.Annotations.LocalizationRequiredAttribute
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Annotations
{
  [AttributeUsage(AttributeTargets.All)]
  public sealed class LocalizationRequiredAttribute : Attribute
  {
    public LocalizationRequiredAttribute()
      : this(true)
    {
    }

    public LocalizationRequiredAttribute(bool required) => this.Required = required;

    public bool Required { get; private set; }
  }
}
