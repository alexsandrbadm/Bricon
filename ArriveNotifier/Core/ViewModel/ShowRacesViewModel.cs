// Decompiled with JetBrains decompiler
// Type: ArriveNotifier.Core.ViewModel.ShowRacesViewModel
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using ArriveNotifier.Core.Models;
using ArriveNotifier.WCFService.Data;
using CoreLib.ViewModels;
using System;
using System.Timers;

namespace ArriveNotifier.Core.ViewModel
{
  public class ShowRacesViewModel : ViewModelBase
  {
    private readonly ArriveNotifierModel _model;
    private Timer _timer;

    public int RefreshRate { get; set; }

    public ArriveNotifierData AllData { get; private set; }

    public event EventHandler DataChanged;

    public bool NoRacesYet => this.AllData == null || this.AllData.ActiveRaces == null || this.AllData.ActiveRaces.Length == 0;

    public ShowRacesViewModel(ArriveNotifierModel model)
    {
      this._model = model;
      this.RefreshRate = 60000;
    }

    public override void OnNavigatingTo()
    {
      this.OnNavigatingFrom();
      this._timer = new Timer((double) Math.Min(this.RefreshRate / 60, 100));
      this._timer.Elapsed += new ElapsedEventHandler(this._timer_Elapsed);
      this._timer.Start();
    }

    public override bool OnNavigatingFrom()
    {
      if (this._timer != null)
      {
        this._timer.Stop();
        this._timer.Dispose();
        this._timer = (Timer) null;
      }
      return true;
    }

    private void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
      ArriveNotifierData data = this._model.GetData();
      if (!this._model.AreEqual(this.AllData, data) && this.DataChanged != null)
        this.DataChanged((object) this, (EventArgs) e);
      this.AllData = data;
      this.FirePropertyChanged("AllData");
      this.FirePropertyChanged("NoRacesYet");
      if (this._timer == null)
        return;
      this._timer.Interval = (double) this.RefreshRate;
      this._timer.Start();
    }
  }
}
