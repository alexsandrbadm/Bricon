// Decompiled with JetBrains decompiler
// Type: BriconLib.Annotations.RazorPageBaseTypeAttribute
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Annotations
{
  [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
  public sealed class RazorPageBaseTypeAttribute : Attribute
  {
    public RazorPageBaseTypeAttribute([NotNull] string baseType) => this.BaseType = baseType;

    public RazorPageBaseTypeAttribute([NotNull] string baseType, string pageName)
    {
      this.BaseType = baseType;
      this.PageName = pageName;
    }

    [NotNull]
    public string BaseType { get; private set; }

    [CanBeNull]
    public string PageName { get; private set; }
  }
}
