// Decompiled with JetBrains decompiler
// Type: BriconLib.PrintManager.TestXtreme
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using MultiLang;
using System.Windows.Forms;

namespace BriconLib.PrintManager
{
  public class TestXtreme
  {
    public void DoIt()
    {
      if (new FancierReadOut().ReadOut(true, true) == null)
        return;
      int num = (int) MessageBox.Show(ml.ml_string(1396, "Test OK!"));
    }
  }
}
