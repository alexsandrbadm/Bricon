// Decompiled with JetBrains decompiler
// Type: BriconLib.Monitor.Command
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Monitor
{
  public abstract class Command
  {
    public override string ToString() => throw new NotImplementedException();

    public virtual byte[] ToBytes() => throw new NotImplementedException();
  }
}
