// Decompiled with JetBrains decompiler
// Type: BriconLib.Data.DatabaseFinder
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Properties;
using MultiLang;
using System;
using System.IO;

namespace BriconLib.Data
{
  public class DatabaseFinder
  {
    public static string Find()
    {
      if (File.Exists(Settings.Default.DBLocation))
        return Settings.Default.DBLocation;
      string[] strArray = new string[5]
      {
        "c:\\admin\\AdminBackup.mdb",
        "c:\\program files\\adminclub\\AdminBackup.mdb",
        "AdminBackup.mdb",
        "C:\\Dev\\TestB\\TestB\\BriconLib\\Data\\AdminBackup.mdb",
        "D:\\DEV\\Bawibo\\BCE\\BriconLib\\Data\\AdminBackup.mdb"
      };
      foreach (string path in strArray)
      {
        if (File.Exists(path))
          return path;
      }
      throw new ApplicationException(ml.ml_string(129, "Database not found"));
    }
  }
}
