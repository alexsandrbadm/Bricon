// Decompiled with JetBrains decompiler
// Type: BriconLib.Annotations.StringFormatMethodAttribute
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Annotations
{
  [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Delegate)]
  public sealed class StringFormatMethodAttribute : Attribute
  {
    public StringFormatMethodAttribute([NotNull] string formatParameterName) => this.FormatParameterName = formatParameterName;

    [NotNull]
    public string FormatParameterName { get; private set; }
  }
}
