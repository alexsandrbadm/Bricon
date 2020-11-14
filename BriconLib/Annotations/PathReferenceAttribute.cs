// Decompiled with JetBrains decompiler
// Type: BriconLib.Annotations.PathReferenceAttribute
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Annotations
{
  [AttributeUsage(AttributeTargets.Parameter)]
  public sealed class PathReferenceAttribute : Attribute
  {
    public PathReferenceAttribute()
    {
    }

    public PathReferenceAttribute([NotNull, PathReference] string basePath) => this.BasePath = basePath;

    [CanBeNull]
    public string BasePath { get; private set; }
  }
}
