// Decompiled with JetBrains decompiler
// Type: BriconLib.Annotations.NotifyPropertyChangedInvocatorAttribute
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Annotations
{
  [AttributeUsage(AttributeTargets.Method)]
  public sealed class NotifyPropertyChangedInvocatorAttribute : Attribute
  {
    public NotifyPropertyChangedInvocatorAttribute()
    {
    }

    public NotifyPropertyChangedInvocatorAttribute([NotNull] string parameterName) => this.ParameterName = parameterName;

    [CanBeNull]
    public string ParameterName { get; private set; }
  }
}
