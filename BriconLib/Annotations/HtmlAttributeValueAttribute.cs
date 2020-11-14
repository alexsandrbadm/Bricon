// Decompiled with JetBrains decompiler
// Type: BriconLib.Annotations.HtmlAttributeValueAttribute
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Annotations
{
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
  public sealed class HtmlAttributeValueAttribute : Attribute
  {
    public HtmlAttributeValueAttribute([NotNull] string name) => this.Name = name;

    [NotNull]
    public string Name { get; private set; }
  }
}
