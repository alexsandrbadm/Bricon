﻿// Decompiled with JetBrains decompiler
// Type: BriconLib.Annotations.RazorDirectiveAttribute
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Annotations
{
  [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
  public sealed class RazorDirectiveAttribute : Attribute
  {
    public RazorDirectiveAttribute([NotNull] string directive) => this.Directive = directive;

    [NotNull]
    public string Directive { get; private set; }
  }
}
