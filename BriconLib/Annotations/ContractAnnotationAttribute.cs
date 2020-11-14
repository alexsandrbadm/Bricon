// Decompiled with JetBrains decompiler
// Type: BriconLib.Annotations.ContractAnnotationAttribute
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Annotations
{
  [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
  public sealed class ContractAnnotationAttribute : Attribute
  {
    public ContractAnnotationAttribute([NotNull] string contract)
      : this(contract, false)
    {
    }

    public ContractAnnotationAttribute([NotNull] string contract, bool forceFullStates)
    {
      this.Contract = contract;
      this.ForceFullStates = forceFullStates;
    }

    [NotNull]
    public string Contract { get; private set; }

    public bool ForceFullStates { get; private set; }
  }
}
