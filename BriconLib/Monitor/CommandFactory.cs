// Decompiled with JetBrains decompiler
// Type: BriconLib.Monitor.CommandFactory
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

namespace BriconLib.Monitor
{
  internal class CommandFactory
  {
    public static Command CreateCommand(byte[] bytes)
    {
      if (bytes.Length <= 5)
        return (Command) null;
      switch (bytes[2])
      {
        case 16:
          return (Command) new StatusCommand(bytes);
        case 17:
          return (Command) new PigeonCommand(bytes);
        case 18:
          return (Command) new FancierCommand(bytes);
        case 19:
          return (Command) new RaceCommand(bytes);
        default:
          return (Command) null;
      }
    }
  }
}
