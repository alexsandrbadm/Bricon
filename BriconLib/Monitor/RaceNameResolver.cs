// Decompiled with JetBrains decompiler
// Type: BriconLib.Monitor.RaceNameResolver
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using BriconLib.Other;

namespace BriconLib.Monitor
{
  internal class RaceNameResolver
  {
    public static string Resolve(string flightID) => Utils.IsCountry("BE") && FlightCalenderBelgium.Names.ContainsKey(flightID) ? FlightCalenderBelgium.Names[flightID] : flightID;
  }
}
