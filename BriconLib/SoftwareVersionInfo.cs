// Decompiled with JetBrains decompiler
// Type: BriconLib.SoftwareVersionInfo
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

namespace BriconLib
{
  public class SoftwareVersionInfo
  {
    public int Version;
    public SoftwareVersionInfo.VersionTypes VersionType;
    public byte Storage;
    public string LocalFileName;
    public string MenuString;
    public string Url;

    public enum VersionTypes
    {
      Master,
      Speedy,
      BPlus,
      Little,
      Esa,
      Xtreme,
      SpeedyXtreme,
    }
  }
}
