// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.BceDatabase.PasDataTester
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System.Windows;

namespace BriconLib.PAS.BceDatabase
{
  public class PasDataTester
  {
    public void Test()
    {
      int num = (int) MessageBox.Show(BceDatabaseService.UploadOrDownloadXml(false, "TEST"));
    }
  }
}
