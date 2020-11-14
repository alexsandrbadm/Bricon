// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.ReadOut.ReadOutProcess
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.Basket;
using BriconLib.PAS.BceDatabase;
using CoreLib.Helpers;

namespace BriconLib.PAS.ReadOut
{
  public class ReadOutProcess
  {
    public void Start(string clubId, string clubName, bool readoutIsFinal)
    {
      if (!NtpClient.CheckPcTime() || !new PasDataLoader().Load(false))
        return;
      using (ReadOutViewModel model = new ReadOutViewModel(new BasketContext()
      {
        ClubCode = clubId,
        ClubName = clubName
      }, readoutIsFinal))
        new ReadOutWindow(model).ShowDialog();
    }
  }
}
