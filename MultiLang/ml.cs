// Decompiled with JetBrains decompiler
// Type: MultiLang.ml
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace MultiLang
{
  internal class ml
  {
    private static ResourceManager ResMgr;
    public static string[] SupportedCultures = new string[27]
    {
      "bg",
      "cs",
      "de",
      "el",
      "en",
      "es",
      "fr",
      "hu",
      "it",
      "ja",
      "nl",
      "pl",
      "pt",
      "ro",
      "ru",
      "hr",
      "sk",
      "sq",
      "tr",
      "uk",
      "lt",
      "vi",
      "ar-SA",
      "tr-TR",
      "ar-MA",
      "sr",
      "jv-Java"
    };
    private static string RootNamespace = "BriconLib";

    static ml() => ml.ResMgr = new ResourceManager(Assembly.GetExecutingAssembly().GetName().Name + ".MultiLang", Assembly.GetExecutingAssembly());

    public static void ml_UseCulture(CultureInfo ci) => Thread.CurrentThread.CurrentUICulture = ci;

    public static string ml_string(int StringID, string Text) => ml.ResMgr.GetString("_" + StringID.ToString());

    public static string ml_resource(int StringID) => ml.ResMgr.GetString("_" + StringID.ToString());
  }
}
