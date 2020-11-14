// Decompiled with JetBrains decompiler
// Type: BriconLib.Monitor.StatusCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using MultiLang;

namespace BriconLib.Monitor
{
  public class StatusCommand : Command
  {
    public StatusCommand()
    {
      this.Status = 1;
      this.PigeonCount = 2;
      this.RaceCount = 3;
      this.AntennaCount = 4;
    }

    public StatusCommand(byte[] bytes)
    {
      this.Status = (int) bytes[4];
      this.PigeonCount = ((int) bytes[5] << 8) + (int) bytes[6];
      this.RaceCount = (int) bytes[7];
      this.AntennaCount = (int) bytes[8];
    }

    public override string ToString() => string.Format(ml.ml_string(1163, "Status received: {0} pigeon(s), {1} race(s), {2} antenna(s)"), (object) this.PigeonCount, (object) this.RaceCount, (object) this.AntennaCount);

    public int Status { get; private set; }

    public int PigeonCount { get; private set; }

    public int RaceCount { get; private set; }

    public int AntennaCount { get; private set; }
  }
}
