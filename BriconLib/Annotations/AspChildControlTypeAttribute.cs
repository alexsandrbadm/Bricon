// Decompiled with JetBrains decompiler
// Type: BriconLib.Annotations.AspChildControlTypeAttribute
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Annotations
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
  public sealed class AspChildControlTypeAttribute : Attribute
  {
    public AspChildControlTypeAttribute([NotNull] string tagName, [NotNull] Type controlType)
    {
      this.TagName = tagName;
      this.ControlType = controlType;
    }

    [NotNull]
    public string TagName { get; private set; }

    [NotNull]
    public Type ControlType { get; private set; }
  }
}
