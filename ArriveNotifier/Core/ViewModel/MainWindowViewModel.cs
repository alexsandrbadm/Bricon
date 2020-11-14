// Decompiled with JetBrains decompiler
// Type: ArriveNotifier.Core.ViewModel.MainWindowViewModel
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using ArriveNotifier.Core.Models;
using CoreLib.ViewModels;
using System;
using System.Windows.Input;

namespace ArriveNotifier.Core.ViewModel
{
  public class MainWindowViewModel : ViewModelBase
  {
    private readonly ArriveNotifierModel _loginModel;

    public NavigationViewModel Navigation { get; private set; }

    public event EventHandler DataChanged;

    public MainWindowViewModel(string user, string pwd)
    {
      try
      {
        this._loginModel = new ArriveNotifierModel((IArriveNotifier) new ArriveNotifierClient())
        {
          CountryCode = "BE",
          UserName = user,
          PassWord = pwd
        };
      }
      catch (Exception ex)
      {
      }
      this.Init();
    }

    public MainWindowViewModel(IArriveNotifier webService)
    {
      this._loginModel = new ArriveNotifierModel(webService);
      this.Init();
    }

    public string UserName => this._loginModel.UserName;

    public string PassWord => this._loginModel.PassWord;

    private void Init()
    {
      ShowRacesViewModel racesPage = new ShowRacesViewModel(this._loginModel);
      racesPage.DataChanged += new EventHandler(this.racesPage_DataChanged);
      this.GoToSettings = (ICommand) new RelayCommand((Action<object>) (o => this.Navigation.Navigate((ViewModelBase) new FirstTimeUseViewModel(this._loginModel, this.Navigation, (ViewModelBase) racesPage))));
      ShowRacesViewModel showRacesViewModel = new ShowRacesViewModel(this._loginModel);
      showRacesViewModel.DataChanged += new EventHandler(this.racesPage_DataChanged);
      this.Navigation = new NavigationViewModel();
      if (this._loginModel.CanTryLogin() && this._loginModel.TryLogin())
        this.Navigation.Navigate((ViewModelBase) new ShowRacesViewModel(this._loginModel));
      else
        this.Navigation.Navigate((ViewModelBase) new FirstTimeUseViewModel(this._loginModel, this.Navigation, (ViewModelBase) showRacesViewModel));
    }

    private void racesPage_DataChanged(object sender, EventArgs e)
    {
      if (this.DataChanged == null)
        return;
      this.DataChanged(sender, e);
    }

    public ICommand GoToSettings { get; private set; }
  }
}
