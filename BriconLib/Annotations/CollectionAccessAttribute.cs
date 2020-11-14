// Decompiled with JetBrains decompiler
// Type: BriconLib.Annotations.CollectionAccessAttribute
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Annotations
{
  [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property)]
  public sealed class CollectionAccessAttribute : Attribute
  {
    public CollectionAccessAttribute(CollectionAccessType collectionAccessType) => this.CollectionAccessType = collectionAccessType;

    public CollectionAccessType CollectionAccessType { get; private set; }
  }
}
