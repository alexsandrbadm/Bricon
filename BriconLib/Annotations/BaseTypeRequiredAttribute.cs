// Decompiled with JetBrains decompiler
// Type: BriconLib.Annotations.BaseTypeRequiredAttribute
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Annotations
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
  [BaseTypeRequired(typeof (Attribute))]
  public sealed class BaseTypeRequiredAttribute : Attribute
  {
    public BaseTypeRequiredAttribute([NotNull] Type baseType) => this.BaseType = baseType;

    [NotNull]
    public Type BaseType { get; private set; }
  }
}
