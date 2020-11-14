// Decompiled with JetBrains decompiler
// Type: BriconLib.PrintManager.PoulLetter
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

namespace BriconLib.PrintManager
{
  public class PoulLetter
  {
    public void DoIt()
    {
      ReadOutDataSet dataset = new FancierReadOut().ReadOut(true);
      if (dataset == null)
        return;
      int num = (int) new BetForm(dataset).ShowDialog();
    }
  }
}
