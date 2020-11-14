// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.BasketProcess
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Basket;
using BriconLib.PAS.BceDatabase;
using CoreLib.Helpers;

namespace BriconLib.PAS.Basket
{
  public class BasketProcess
  {
    public void Start(string clubId, string clubName)
    {
      if (!NtpClient.CheckPcTime())
        return;
      StartBasketWindow startBasketWindow = new StartBasketWindow();
      bool? nullable = startBasketWindow.ShowDialog();
      bool flag = true;
      if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue) || !new PasDataLoader().Load(false))
        return;
      using (BasketViewModel model = new BasketViewModel(GetRacesService.GetRaceDataFromCode(startBasketWindow.SelectedRace, clubId, clubName)))
        new BasketWindow(model).ShowDialog();
    }
  }
}
