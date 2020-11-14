// Decompiled with JetBrains decompiler
// Type: BriconLib.Data.FlightCalenderBelgium
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Properties;
using System;
using System.Collections.Generic;

namespace BriconLib.Data
{
  internal class FlightCalenderBelgium
  {
    private static bool ForPM = false;
    public static Dictionary<string, string> Names = new Dictionary<string, string>();

    static FlightCalenderBelgium()
    {
      FlightCalenderBelgium.ForPM = true;
      FlightCalenderBelgium.AddFlights(false);
      FlightCalenderBelgium.ForPM = false;
    }

    private static void Add(
      string name,
      string code,
      string address,
      int coordX,
      int coordY,
      string countryNL,
      string countryFR)
    {
      if (code == null)
        code = name.Replace("-", "").Replace(" ", "").Replace(".", "").PadRight(4).Substring(0, 4);
      string Country = countryNL;
      if (Settings.Default.Language.Equals("FR", StringComparison.InvariantCultureIgnoreCase))
        Country = countryFR;
      if (!FlightCalenderBelgium.ForPM)
        BCEDatabase.DataSet.Lossingsplaats.AddLossingsplaatsRow(name, code, coordX, coordY, false, address, Country, 1, 0, 0, "");
      else
        FlightCalenderBelgium.Names[code] = name;
    }

    public static void AddFlights(bool clearFirst)
    {
      if (clearFirst)
        BCEDatabase.DataSet.Lossingsplaats.Clear();
      FlightCalenderBelgium.Add("AALST", "AALS", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("ABLIS", "ABLI", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("AGEN", "AGEN", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("ALBI", "ALBI", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("ANGERVILLE", "ANGE", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("ANGOULEME", "ANGO", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("ARCIS S/AUBE", "AUBE", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("ARGENTON", "ARGE", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("ARLON", "ARLO", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("ARRAS", "ARRA", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("AURILLAC", "AURI", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("AUXERRE", "AUXE", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("BARCELONA", "BARC", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("BEERSEL", "BEER", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("BERGERAC", "BERG", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("BIARRITZ", "BIAR", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("BIERGES", "BIER", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("BLOIS", "BLOI", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("BOOM", "BOOM", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("BOUILLON", "BOUI", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("BOURGES", "BOUR", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("BOVES", "BOVE", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("BRIARE", "BRIA", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("BRIONNE", "BRIO", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("BRIVE", "BRIV", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("BURDINNE/HERON", "BURD", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("CAHORS", "CAHO", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("CARCASSONNE", "CARC", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("CASTRES", "CAST", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("CHALONS-EN-CHAMPAGNE", "CHAM", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("CHALON-SUR-SAONE", "SAON", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("CHANTILLY", "CHAN", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("CHARTRES", "CHAR", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("CHATEAUDUN", "CHDU", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("CHATEAUROUX ", "CHAT", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("CHEVRAINVILLIERS", "CHEV", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("CHIMAY", "CHIM", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("CLERMONT", "CLER", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("CLERMONT-FERRAND", "FERR", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("COMPIEGNE", "COMP", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("COGNELEE", "COGN", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("CUL DES SARTS", "SART", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("DAX ", "DAX ", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("DE RONDE VAN BELGIË", "DRVB", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("DIJON", "DION", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("DIZY-LE-GROS", "GROS", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("DOURDAN", "DOUR", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("DUDELANGE", "DUDE", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("ECOUEN", "ECOU", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("EIZERINGEN", "EIZE", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("EPEHY", "EPEH", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("EPERNAY", "EPER", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("FAY-AU-LOGES", "LOGE", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("FLEURUS", "FLEU", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("FONTENAY-LE-COMTE", "COMT", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("FONTENAY-SUR-EURE", "FONT", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("GEDINNE", "GEDI", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("GIEN", "GIEN", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("GRAY", "GRAY", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("GUERET", "GUER", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("HANNUT", "HANN", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("ISSOUDUN", "ISSO", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("JARNAC", "JARN", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("JOUY-LE-CHATEL", "JOUY", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("KNOKKE", "KNOK", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("L'AIGLE", "AIGL", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("LA CHATRE", "LACH", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("LA FERTE /S JOUARRE", "JOUA", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("LA FERTE ST.AUBIN", "AUBI", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("LA SOUTERRAINE", "SOUT", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("LAMBERMONT", "LAMB", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("LAON", "LAON", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("LE MANS", "MANS", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("LENS", "LENS", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("LE TOUQUET", "TOUQ", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("LES ISNES", "ISNE", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("LESSINES", "LESS", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("LIBOURNE", "LIBO", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("LIMOGES", "LIMO", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("LISIEUX", "LISI", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("LORRIS", "LORR", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("MAASEIK", "MAAS", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("MACON", "MACO", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("MAISSEMY", "MAIS", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("MARCHE", "MARC", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("MARCHIN", "MARH", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("MARSEILLE", "MARS", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("MECHELEN", "MECH", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("MELUN", "MELU", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("MERCHTEM", "MERC", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("METTET", "METT", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("MOMIGNIES", "MOMI", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("MONT VENTOUX", "VENT", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("MONTARGIS", "ARGI", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("MONTAUBAN", "AUBA", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("MONTELIMAR", "LIMA", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("MONTLUCON", "LUCO", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("MONTRICHARD", "RICH", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("MOULINS", "MOUL", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("MOUSCRON", "MOUS", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("NANTEUIL", "NATE", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("NARBONNE", "NARB", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("NEVERS", "NEVE", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("NIERGNIES", "NIER", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("NOYON", "NOYO", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("OFFENBURG", "OFFE", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("OPWIJK", "OPWI", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("ORANGE", "ORAN", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("ORLEANS", "ORLE", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("OUDENAARDE", "OUDE", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("PAU ", "PAU ", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("PERIGUEUX", "PERI", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("PERONNE", "PERO", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("PERPIGNAN", "PERP", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("PITHIVIERS", "PITH", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("POITIERS", "POIT", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("PONTOISE", "PONT", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("PONT-STE.-MAXENCE", "MAXE", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("PUTTE", "PUTT", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("PUTTERSHOEK", "PUHO", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("QUIEVRAIN", "QUIE", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("RASTATT", "RAST", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("REIMS", "REIM", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("RETHEL", "RETH", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("SAARBRUCKEN", "SAAR", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("SALBRIS", "SALB", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("SAN SEBASTIAN", "SEBA", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("SAUMUR", "SAUM", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("SAVIGNY-SUR-CLAIRIS", "SAVI", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("SCHAARBEEK", "SCHA", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("SENS", "SENS", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("SERMAISES", "SERM", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("SEZANNE", "SEZA", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("SOISSONS", "SOIS", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("SOUILLAC", "SOUI", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("SOURDUN", "SOUR", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("SOUSTONS", "SOUS", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("ST.DIZIER", "DIZI", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("ST.-JUNIEN", "JUNI", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("ST.NIKLAAS", "NIKL", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("ST SOUPPLETS", "SOUP", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("ST.VINCENT", "VINC", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("SUGNY", "SUGN", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("TARBES", "TARB", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("TONGEREN", "TONG", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("TOUL", "TOUL", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("TOURNAI", "TRNA", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("TOURS", "TOUR", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("TOURY", "TOUY", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("TRELOU S/MARNE", "TREL", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("TROYES", "TROY", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("TULLE", "TULL", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("VALENCE", "VALE", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("VERVINS", "VERV", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("VICHY", "VICH", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("VIERZON", "VIER", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("VILLENEUVE-SUR-LOT", "VILL", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("VILLEROY", "VILR", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("VILVOORDE", "VILV", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("VIRTON", "VIRT", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("VOUZIERS", "VOUZ", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("WAVER", "WAVE", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("WOLVERTEM", "WOLV", "", 0, 0, "", "");
      FlightCalenderBelgium.Add("YZEURE", "YZEU", "", 0, 0, "", "");
      if (FlightCalenderBelgium.ForPM)
        return;
      BCEDatabase.SaveFlights();
    }
  }
}
